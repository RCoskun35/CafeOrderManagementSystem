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
            var category =await repository.GetByExpressionWithTrackingAsync(x=>x.Id == request.Id);
            if (category == null)
                throw new Exception("Category not found");

            repository.Delete(category);
            await unitOfWork.SaveChangesAsync();
            return "Category deleted successfully";
        }
    }

}
