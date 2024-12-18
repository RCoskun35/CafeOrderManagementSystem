﻿using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.OrderFeature.CloseOrder
{
    public class CloseOrderCommandHandler(
           IRepository<Order> repository,
           IUnitOfWork unitOfWork
       ) : IRequestHandler<CloseOrderCommand, string>
    {
        public async Task<string> Handle(CloseOrderCommand request, CancellationToken cancellationToken)
        {
            var order= await repository.WhereWithTracking(x=>x.Id==request.Id).Include(a=>a.Table).FirstOrDefaultAsync(cancellationToken);
            
            if (order == null)
                throw new Exception("Sipariş bulunamadı");

            order.CompletionDate = DateTime.Now;
            order.Status = true;
            order.Table.State = 0;
            repository.Update(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Sipariş başarıyla kapatıldı";

        }
    }
}
