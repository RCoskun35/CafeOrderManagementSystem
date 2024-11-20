using MediatR;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.RemoveOrderDetail
{
    public sealed record RemoveOrderDetailCommand(int Id,int Quantity) : IRequest<string>;
}
