using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable
{
    public sealed record GetAllTableQuery() : IRequest<List<TableDto>>;
}
