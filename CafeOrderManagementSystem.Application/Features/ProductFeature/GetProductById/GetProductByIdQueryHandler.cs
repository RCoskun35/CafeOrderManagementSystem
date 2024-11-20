using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.GetProductById
{
    public class GetProductByIdQueryHandler(IRepository<Product> repository) : IRequestHandler<GetProductByIdQuery, Product>
    {
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id);
        }
    }


}
