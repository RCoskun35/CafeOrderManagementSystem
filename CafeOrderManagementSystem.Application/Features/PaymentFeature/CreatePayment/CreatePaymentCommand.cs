using MediatR;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.CreatePayment
{
    public sealed record CreatePaymentCommand(int OrderId,decimal Amount,string PaymentMethod) : IRequest<string>;
}
