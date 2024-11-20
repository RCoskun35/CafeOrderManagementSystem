using CafeOrderManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderManagementSystem.Application.Features.MenuProductFeature.GetMenuProductByMenuId
{
    public sealed record GetMenuProductByMenuIdQuery(int MenuId) : IRequest<List<MenuProduct>>;


}
