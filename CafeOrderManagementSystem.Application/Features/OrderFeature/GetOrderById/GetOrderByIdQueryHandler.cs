using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.GetOrderById
{
    public class GetOrderByIdQueryHandler(IRepository<Order> repository) : IRequestHandler<GetOrderByIdQuery, Order>
    {
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result =  await repository
                            .Where(x => x.Id == request.Id)
                            .Include(a => a.OrderDetails)
                            .ThenInclude(b => b.Product)
                            .Include(a => a.OrderDetails)
                            .ThenInclude(b => b.Menu) 
                            .FirstOrDefaultAsync(cancellationToken);

            result.TotalAmount = result.OrderDetails.Sum(a => a.Quantity * a.UnitPrice);

            return result;
        }
    }


}
