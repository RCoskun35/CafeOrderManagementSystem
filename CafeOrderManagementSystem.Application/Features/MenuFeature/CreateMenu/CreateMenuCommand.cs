using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.CreateMenu
{
    public sealed record CreateMenuCommand(string Name) : IRequest<string>;
}
