using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuProductFeature.CreateMenuProduct
{
    public sealed record CreateMenuProductCommand(int MenuId,int ProductId) : IRequest<string>;
}
