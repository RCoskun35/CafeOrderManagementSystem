using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.DeleteProductById
{
    public class DeleteProductByIdCommandHandler 
        (
            IRepository<Product> repository, 
            IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteProductByIdCommand, string>
    {
        public async Task<string> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product =await repository.GetByExpressionWithTrackingAsync(x=>x.Id == request.Id);
            if (product == null)
                throw new Exception("Ürün bulunamadı");

            product.IsDeleted = true;
            product.DeletedDate = DateTime.Now;
            repository.Update(product);
            await unitOfWork.SaveChangesAsync();
            return "Ürün silme başarılı";
        }
    }

}

