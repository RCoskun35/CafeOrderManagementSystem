using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.GetAllPayment
{
    public class GetAllPaymentQueryHandler(IRepository<Payment> repository) : IRequestHandler<GetAllPaymentQuery, List<Payment>>
    {
        public async Task<List<Payment>> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
        {
            return await repository.WhereWithTracking(x => !x.IsDeleted).Include(a=>a.Order).ToListAsync(cancellationToken);
        }
    }
}
