using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.PaymentFeature.GetPaymentById
{
    public class GetPaymentByIdQueryHandler(IRepository<Payment> repository) : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        public async Task<Payment> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.WhereWithTracking(x => x.Id == request.Id).Include(a=>a.Order).FirstOrDefaultAsync(cancellationToken);
        }
    }


}
