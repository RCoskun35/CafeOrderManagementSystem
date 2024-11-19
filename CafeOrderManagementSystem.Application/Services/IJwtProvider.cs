using CafeOrderManagementSystem.Application.Features.User.Login;
using CafeOrderManagementSystem.Domain.Entities;

namespace CafeOrderManagementSystem.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(User user);
    }
}
