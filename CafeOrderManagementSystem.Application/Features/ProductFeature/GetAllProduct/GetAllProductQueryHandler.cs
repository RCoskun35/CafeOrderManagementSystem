using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.GetAllProduct
{
    public class GetAllProductQueryHandler(IRepository<Product> repository) : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await repository.WhereWithTracking(x => !x.IsDeleted).Include(a=>a.Category).ToListAsync();
        }
    }
}
