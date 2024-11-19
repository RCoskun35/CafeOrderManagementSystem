using CafeOrderManagementSystem.Application.Features.UserFeature.Login;
using CafeOrderManagementSystem.Domain.Entities;

namespace CafeOrderManagementSystem.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateTokenAsync(User user);
    }
}
