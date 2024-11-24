using AutoMapper;
using CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.AddOrderDetail
{
    public class UpdateOrderCommandHandler(
           IRepository<Order> repository,
           IRepository<OrderDetail> orderDetailRepository,
           IRepository<Product> productRepository,
           IRepository<Table> tableRepository,
           IUnitOfWork unitOfWork
       ) : IRequestHandler<AddOrderDetailCommand, string>
    {
        public async Task<string> Handle(AddOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var productIds = request.OrderDetails.Select(x => x.ProductId).ToList();
            var products = await productRepository.Where(x => productIds.Contains(x.Id)).ToListAsync(cancellationToken);

            var order = await repository.GetByExpressionAsync(x=>x.Id==request.Id,cancellationToken);
            if (order == null)
            {
                 order = new Order
                {
                    TableId = request.TableId!.Value,
                    OrderDate = DateTime.Now,
                    Status = false,
                };
                await repository.AddAsync(order, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                var table = await tableRepository.Where(x => x.Id == request.TableId).FirstOrDefaultAsync(cancellationToken);
                table!.State = 1;
                tableRepository.Update(table);
            }
            var orderDetails = request.OrderDetails.Select(x => new OrderDetail
            {
                OrderId = order.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                MenuId = x.MenuId,
                UnitPrice = products.FirstOrDefault(a => a.Id == x.ProductId).Price * (x.MenuId.HasValue ? 0.9m : 1m)
            }).ToList();

            await orderDetailRepository.AddRangeAsync(orderDetails, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            order.UpdatedDate = DateTime.Now;
           
            repository.Update(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Sipariş başarıyla güncellendi";

        }
    }
}
