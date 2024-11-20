using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.GetAllOrder
{
    public class GetAllOrderQueryHandler(IRepository<Order> repository) : IRequestHandler<GetAllOrderQuery, List<Order>>
    {
        public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.WhereWithTracking(x => !x.IsDeleted)
                                         .Include(a => a.OrderDetails)
                                         .ThenInclude(b=>b.Product)
                                         .Include(a => a.OrderDetails)
                                         .ThenInclude(b => b.Menu)
                                         .ToListAsync(cancellationToken);
            result.ForEach(x =>x.TotalAmount = x.OrderDetails.Sum(a => a.Quantity * a.UnitPrice));
            return result;
            
        }
    }
}
