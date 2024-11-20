using CafeOrderManagementSystem.Application.Features.UserFeature.Register;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder
{
    public sealed record CreateOrderCommand(int TableId,List<OrderDetailDto> OrderDetails) : IRequest<string>;
}
