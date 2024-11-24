using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.DeleteCategoryById
{
    public class DeleteCategoryByIdCommandHandler 
        (
            IRepository<Category> repository, 
            IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteCategoryByIdCommand, string>
    {
        public async Task<string> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category =await repository.GetByExpressionWithTrackingAsync(x=>x.Id == request.Id, cancellationToken);
            if (category == null)
                throw new Exception("Kategori bulunamadı");

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            repository.Update(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Kategori başarıyla silindi";
        }
    }

}
