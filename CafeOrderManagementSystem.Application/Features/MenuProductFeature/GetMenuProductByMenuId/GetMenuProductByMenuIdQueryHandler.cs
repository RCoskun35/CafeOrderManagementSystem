using CafeOrderManagementSystem.Application.Features.MenuProductFeature.GetMenuProductByMenuId;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.MenuProductFeature.GetMenuProductByMenuId.GetMenuById
{
    public class GetMenuByIdQueryHandler(IRepository<MenuProduct> repository) : IRequestHandler<GetMenuProductByMenuIdQuery, List<MenuProduct>>
    {
        public async Task<List<MenuProduct>> Handle(GetMenuProductByMenuIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.WhereWithTracking(x => x.MenuId == request.MenuId).Include(a=>a.Menu).Include(b=>b.Product).ToListAsync();
        }
    }


}
