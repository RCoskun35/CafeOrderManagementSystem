using CafeOrderManagementSystem.Infrastructure.Context;
using CafeOrderManagementSystem.Infrastructure.Options;
using GenericRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CafeOrderManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.ConfigureOptions<JwtTokenOptionsSetup>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                    .AddCookie(options =>
 {
     options.Cookie.Name = "Cookies"; 
     options.LoginPath = "/Account/Login"; 
     options.LogoutPath = "/Account/Logout"; 
     options.ExpireTimeSpan = TimeSpan.FromDays(7); 
 })
                    .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = configuration["Jwt:Issuer"],
         ValidAudience = configuration["Jwt:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!))
     };
     options.Events = new JwtBearerEvents
     {
         OnChallenge = context =>
         {
             if (!context.HttpContext.User.Identity!.IsAuthenticated)
             {
                 context.HandleResponse();
                 context.Response.Redirect("/Login/Index");
             }
             return Task.CompletedTask;
         }
     };
 });


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }

    }
}