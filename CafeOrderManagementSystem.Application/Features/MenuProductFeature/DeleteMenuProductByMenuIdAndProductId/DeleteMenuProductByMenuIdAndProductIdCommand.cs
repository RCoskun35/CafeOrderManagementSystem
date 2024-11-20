using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuProductFeature.DeleteMenuProductByMenuIdAndProductId
{
    public sealed record DeleteMenuProductByMenuIdAndProductIdCommand(int MenuId,int ProductId):IRequest<string>;

}
