using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.DeleteMenuById
{
    public sealed record DeleteMenuByIdCommand(int Id):IRequest<string>;

}
