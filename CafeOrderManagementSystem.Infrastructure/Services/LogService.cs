using CafeOrderManagementSystem.Application.StaticServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System;
using CafeOrderManagementSystem.Infrastructure.Context;
using CafeOrderManagementSystem.Domain.Entities;
using CafeOrderManagementSystem.Application.UserManagement;

namespace CafeOrderManagementSystem.Infrastructure.Services
{
    public static class LogService
    {
        private static IServiceProvider _serviceProvider;
        private static IHttpContextAccessor _httpContextAccessor;
        public static void Initialize(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }


        public static int UserId()
        {
            return CurrentUser.Id;

        }

        public static void Log(string? detail, string? error=null, int? userId = null)
        {
            try
            {
                var callingMethod = new StackTrace().GetFrame(1)?.GetMethod();

                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var log = new Log
                    {
                        Detail = detail,
                        Error = error,
                        UserId = userId ?? UserId(),
                        LogDate = DateTime.Now,
                        Application = callingMethod?.DeclaringType?.FullName
                    };
                    dbContext.Logs.Add(log);
                     dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
