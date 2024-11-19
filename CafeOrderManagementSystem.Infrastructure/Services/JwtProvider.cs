using CafeOrderManagementSystem.Application.Features.UserFeature.Login;
using CafeOrderManagementSystem.Application.Services;
using CafeOrderManagementSystem.Domain.Entities;
using CafeOrderManagementSystem.Infrastructure.Options;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CafeOrderManagementSystem.Infrastructure.Services
{
    internal class JwtProvider(
        IRepository<User> userRepository,
        IOptions<JwtOptions> jwtOptions) : IJwtProvider
    {
        public async Task<LoginCommandResponse> CreateTokenAsync(User user)
        {
            List<Claim> claims = new()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Email", user.Email ?? ""),
                new Claim("UserName", user.UserName ?? "")
            };
            DateTime expires = DateTime.UtcNow.AddMonths(1);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));
            JwtSecurityToken jwtSecurityToken = new(
                issuer: jwtOptions.Value.Issuer,
                audience: jwtOptions.Value.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));
            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(jwtSecurityToken);
            return await Task.FromResult(new LoginCommandResponse(token));
        }
    }
}