using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder
{
    public class CreateOrderCommandHandler(
            IRepository<Order> repository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Product> productRepository,
            IRepository<Table> tableRepository,
            IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateOrderCommand, string>
    {
        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
           var productIds = request.OrderDetails.Select(x => x.ProductId).ToList();
           var products =await productRepository.Where(x => productIds.Contains(x.Id)).ToListAsync(cancellationToken);

            var order = new Order
           {
               TableId = request.TableId,
               OrderDate = DateTime.Now,
                Status = false,
            };
            await repository.AddAsync(order, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var orderDetails = request.OrderDetails.Select(x => new OrderDetail
            {
                OrderId = order.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                MenuId = x.MenuId,
                UnitPrice = products.FirstOrDefault(a => a.Id == x.ProductId).Price * (x.MenuId.HasValue ? 0.9m : 1m)
            }).ToList();


            var table = await tableRepository.Where(x => x.Id == request.TableId).FirstOrDefaultAsync(cancellationToken);
            table!.State = 1;
            tableRepository.Update(table);

            await orderDetailRepository.AddRangeAsync(orderDetails, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Sipariş başarıyla oluşturuldu";
            
        }
    }
}
