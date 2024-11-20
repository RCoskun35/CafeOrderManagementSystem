using CafeOrderManagementSystem.Application.Services;
using CafeOrderManagementSystem.Application.StaticServices;
using CafeOrderManagementSystem.Application.UserManagement;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Login
{
    public sealed class LoginCommandHandler(
            IRepository<User> repository,
            IHttpContextAccessor httpContextAccessor
        ) : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await repository.GetByExpressionAsync(x => x.Email == request.Email);
            if (user == null)
                throw new Exception("User not found");

            if (HashService.Decrypt(user.Password)!= request.Password)
                throw new Exception("Invalid password");


            var claims = new List<Claim>
    {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Email", user.Email ?? ""),
                new Claim("UserName", user.UserName ?? "")
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                IsPersistent = true, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
            
            return new($"Giriş Yapıldı:({user.Id.ToString()} - {user.FirstName} {user.LastName})");

        }
    }
}
