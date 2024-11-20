using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.GetAllPayment
{
    public sealed record GetAllPaymentQuery() : IRequest<List<Payment>>;
}
