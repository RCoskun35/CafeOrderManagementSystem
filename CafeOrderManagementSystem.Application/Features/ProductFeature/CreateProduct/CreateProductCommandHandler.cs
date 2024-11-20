using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct
{
    public class CreateProductCommandHandler(
            IRepository<Product> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRequestHandler<CreateProductCommand, string>
    {
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isExistProduct = await repository.GetByExpressionWithTrackingAsync(x => x.Name == request.Name);
            if (isExistProduct != null)
                throw new Exception("Product already exist");
            var product = mapper.Map<Product>(request);
            await repository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            return product.Name;
        }
    }
}
