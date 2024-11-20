using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.GetAllOrder
{
    public sealed record GetAllOrderQuery() : IRequest<List<Order>>;
}
