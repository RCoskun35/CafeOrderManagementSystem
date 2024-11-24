using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.GetAllPayment
{
    public sealed record GetAllPaymentByDailyQuery() : IRequest<List<Payment>>;
}
