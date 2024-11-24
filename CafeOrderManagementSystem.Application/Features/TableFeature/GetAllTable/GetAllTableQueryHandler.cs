using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable
{
    public class GetAllTableQueryHandler(IRepository<Table> repository,IRepository<Order> orderRepository,IRepository<Payment> paymentRepository) : IRequestHandler<GetAllTableQuery, List<TableDto>>
    {
        public async Task<List<TableDto>> Handle(GetAllTableQuery request, CancellationToken cancellationToken)
        {
            var orders = orderRepository.WhereWithTracking(x => !x.IsDeleted && !x.Status)
                                         .Include(m => m.Table)
                                         .Include(a => a.OrderDetails)
                                         .ThenInclude(b => b.Product)
                                         .Include(a => a.OrderDetails)
                                         .ThenInclude(b => b.Menu)
                                         .ToList();

                orders.ForEach(x => x.TotalAmount = x.OrderDetails.Sum(a => a.Quantity * a.UnitPrice));

            var orderIds = orders.Select(x => x.Id).ToList();

            var payments = await paymentRepository.WhereWithTracking(x => !x.IsDeleted && orderIds.Contains(x.OrderId))
                                         .ToListAsync(cancellationToken);

            var tables = await repository.WhereWithTracking(x => !x.IsDeleted)
                                         .ToListAsync(cancellationToken);

            var result = tables.Select(x => new TableDto
            {
                Id = x.Id,
                TableNumber = x.TableNumber,
                State = x.State,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                DeletedDate = x.DeletedDate,
                IsDeleted = x.IsDeleted,
                Order = orders.FirstOrDefault(a => a.TableId == x.Id),
                Payments = orders.FirstOrDefault(a => a.TableId == x.Id) != null
               ? payments.Where(t => t.OrderId == orders.FirstOrDefault(a => a.TableId == x.Id).Id).ToList()
               : default
            }).OrderBy(a=>a.CreatedDate).ToList();

            return result;
        }
        
    }
}
