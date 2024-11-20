using AutoMapper;
using CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.UpdateProduct
{
    public class UpdateProductCommandHandler(IRepository<Product> repository,IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, string>
    {
        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByExpressionAsync(x => x.Id == request.Id);
            if (product == null)
                throw new Exception("Product not found");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            product.UpdatedDate = DateTime.Now;
            repository.Update(product);
            await unitOfWork.SaveChangesAsync();
            return "Product updated successfully";
        }
    }
}
