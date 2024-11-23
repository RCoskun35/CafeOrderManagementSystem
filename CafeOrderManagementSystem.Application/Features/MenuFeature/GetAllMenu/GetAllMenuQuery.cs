using CafeOrderManagementSystem.Domain.Entities;
using MediatR;
using static CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu.GetAllMenuQueryHandler;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu
{
    public sealed record GetAllMenuQuery() : IRequest<List<MenuDto>>;
}
