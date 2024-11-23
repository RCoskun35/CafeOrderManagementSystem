using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.GetAllOrderByDaily
{
    public sealed record GetAllOrderByDailyQuery() : IRequest<List<Order>>;
}
