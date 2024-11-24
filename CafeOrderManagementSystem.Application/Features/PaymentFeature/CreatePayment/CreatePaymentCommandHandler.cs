using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.CreatePayment
{
    public class CreatePaymentCommandHandler(
            IRepository<Payment> repository,
            IUnitOfWork unitOfWork
        ) : IRequestHandler<CreatePaymentCommand, string>
    {
        public async Task<string> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            
            var payment = new Payment
            {
                OrderId = request.OrderId,
                Amount = decimal.Parse(request.Amount.Replace(".", ",")),
                PaymentMethod = request.PaymentMethod
            };
            await repository.AddAsync(payment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Ödeme başarıyla gerçekleştirildi.";
        }
    }
}
