using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu.GetAllMenuQueryHandler;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu
{
    public class GetAllMenuQueryHandler(
        IRepository<Domain.Entities.Menu> repository,
        IRepository<Product> productRepository,
        IRepository<MenuProduct> menuProductRepository
        ) : IRequestHandler<GetAllMenuQuery, List<MenuDto>>
    {
        public async Task<List<MenuDto>> Handle(GetAllMenuQuery request, CancellationToken cancellationToken)
        {
            var menus = await repository
                            .WhereWithTracking(x => !x.IsDeleted)
                            .ToListAsync(cancellationToken);

            var menuProductIds = menus.Select(m => m.Id).ToList();

            var menuProducts = await menuProductRepository
                .WhereWithTracking(mp => menuProductIds.Contains(mp.MenuId))
                .ToListAsync(cancellationToken);

            var productIds = menuProducts.Select(mp => mp.ProductId).Distinct().ToList();
            var products = await productRepository
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            var productDictionary = products.ToDictionary(p => p.Id);
            var menuProductsGrouped = menuProducts.GroupBy(mp => mp.MenuId);

            var result = menus.Select(menu =>
            {
                var productsForMenu = menuProductsGrouped
                    .FirstOrDefault(g => g.Key == menu.Id)?
                    .Select(mp => productDictionary.GetValueOrDefault(mp.ProductId))
                    .Where(p => p != null) 
                    .ToList();
                return new MenuDto
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    CreatedDate = menu.CreatedDate,
                    UpdatedDate = menu.UpdatedDate,
                    DeletedDate = menu.DeletedDate,
                    IsDeleted = menu.IsDeleted,
                    Products = productsForMenu ?? new List<Product>()
                };
            }).OrderByDescending(a=>a.CreatedDate).ToList();

            return result;




        }
        public class MenuDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public DateTime? UpdatedDate { get; set; }
            public DateTime? DeletedDate { get; set; }
            public bool IsDeleted { get; set; } = false;
            public List<Product> Products { get; set; } = new List<Product>();
        }
    }
}
