using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu
{
    public sealed record GetAllMenuQuery() : IRequest<List<Domain.Entities.Menu>>;
}
