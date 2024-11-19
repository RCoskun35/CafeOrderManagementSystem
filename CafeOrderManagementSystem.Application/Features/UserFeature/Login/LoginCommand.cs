using MediatR;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Login
{
    public sealed record LoginCommand(string Email,
        string Password):IRequest<LoginCommandResponse>;

}
