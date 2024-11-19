using CafeOrderManagementSystem.Application.StaticServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System;
using CafeOrderManagementSystem.Infrastructure.Context;
using CafeOrderManagementSystem.Domain.Entities;

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
            int result = 0;

            var token = _httpContextAccessor.HttpContext.Request.Cookies.Where(x => x.Key == "jwtToken").FirstOrDefault();
            if (token.Value != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token.Value);
                var payload = jwtSecurityToken.Payload;
                var userIdHash = payload["UserId"].ToString();
                return Convert.ToInt32(HashService.Decrypt(userIdHash));

            }
            return result;

        }

        public static async Task LogAsync(string? detail, string? error, int? userId = null)
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
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
