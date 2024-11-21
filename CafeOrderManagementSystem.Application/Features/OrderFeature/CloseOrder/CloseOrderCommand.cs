using MediatR;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.CloseOrder
{
    public sealed record CloseOrderCommand(int Id) : IRequest<string>;
}
