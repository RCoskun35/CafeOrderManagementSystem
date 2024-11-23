using CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.GetTableById
{
    public class GetTableByIdQueryHandler(IRepository<Table> repository,IRepository<Order> orderRepository) : IRequestHandler<GetTableByIdQuery, TableDto>
    {
        public async Task<TableDto> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            var order = orderRepository.WhereWithTracking(x => !x.IsDeleted && !x.Status && x.TableId == request.Id)
                             .Include(m => m.Table)
                             .Include(a => a.OrderDetails)
                             .ThenInclude(b => b.Product)
                             .Include(a => a.OrderDetails)
                             .ThenInclude(b => b.Menu)
                             .FirstOrDefault();
            if(order != null)
                order.TotalAmount =order == null ? 0 : order.OrderDetails.Sum(a => a.Quantity * a.UnitPrice);

            var table = await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id);

            var result = new TableDto
            {
                Id = table.Id,
                TableNumber = table.TableNumber,
                State = table.State,
                CreatedDate = table.CreatedDate,
                UpdatedDate = table.UpdatedDate,
                DeletedDate = table.DeletedDate,
                IsDeleted = table.IsDeleted,
                Order = order
            };


            return result;
        }
    }


}
