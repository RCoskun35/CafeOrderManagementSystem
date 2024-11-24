using CafeOrderManagementSystem.Infrastructure.Repositories;
using GenericRepository;
using CafeOrderManagementSystem.Application;
using CafeOrderManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CafeOrderManagementSystem.Infrastructure;
using CafeOrderManagementSystem.Application.UserManagement;
using CafeOrderManagementSystem.Web.Middlewares;
using CafeOrderManagementSystem.Infrastructure.Services;
using CafeOrderManagementSystem.Application.Services;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddApplication();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ; 

var app = builder.Build();
app.UseMiddleware<ExceptionHandler>();
var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
var serviceProvider = app.Services;
LogService.Initialize(serviceProvider, httpContextAccessor);
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migrate Hatasý: {ex.Message}");
    }
}
CurrentUser.Configure(httpContextAccessor);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


ExtensionsMiddleware.CreateSeedData(app);

app.Run();
