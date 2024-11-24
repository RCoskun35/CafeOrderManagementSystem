using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.GetAllPayment
{
    public class GetAllPaymentByDailyQueryHandler(IRepository<Payment> repository) : IRequestHandler<GetAllPaymentByDailyQuery, List<Payment>>
    {
        public async Task<List<Payment>> Handle(GetAllPaymentByDailyQuery request, CancellationToken cancellationToken)
        {
            
   

            var result = await repository.WhereWithTracking(x => !x.IsDeleted && x.PaymentDate.Date == DateTime.Now.Date)
                                         .Include(a=> a.Order)
                                         .ThenInclude(b=>b.Table)
                                         .Include(a => a.Order)
                                         .ThenInclude(b => b.OrderDetails)
                                         .ThenInclude(c => c.Product)
                                         .Include(a => a.Order)
                                         .ThenInclude(b => b.OrderDetails)
                                         .ThenInclude(c => c.Menu)
                                         .OrderByDescending(b=>b.PaymentDate)
                                         .ToListAsync(cancellationToken);
            result.ForEach(x=>x.Order.TotalAmount = x.Order.OrderDetails.Sum(a => a.Quantity * a.UnitPrice));

            return result;
        }
    }
}
