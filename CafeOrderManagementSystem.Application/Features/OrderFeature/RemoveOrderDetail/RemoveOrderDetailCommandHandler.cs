using AutoMapper;
using CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder;
using CafeOrderManagementSystem.Application.Features.OrderFeature.RemoveOrderDetail;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.AddOrderDetail
{
    public class RemoveOrderCommandHandler(
           IRepository<OrderDetail> orderDetailRepository,
           IUnitOfWork unitOfWork
       ) : IRequestHandler<RemoveOrderDetailCommand, string>
    {
        public async Task<string> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await orderDetailRepository.GetByExpressionAsync(x=>x.Id==request.Id,cancellationToken);
                 orderDetailRepository.Delete(orderDetail);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Sipariş başarıyla güncellendi";

        }
    }
}
