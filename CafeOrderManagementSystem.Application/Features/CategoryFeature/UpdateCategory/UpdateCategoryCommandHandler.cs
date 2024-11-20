using AutoMapper;
using CafeOrderManagementSystem.Application.Features.CategoryFeature.CreateCategory;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.UpdateCategory
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository,IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<UpdateCategoryCommand, string>
    {
        public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByExpressionAsync(x => x.Id == request.Id);
            if (category == null)
                throw new Exception("Category not found");

            category.Name = request.Name;
            category.UpdatedDate = DateTime.Now;
            repository.Update(category);
            await unitOfWork.SaveChangesAsync();
            return "Category updated successfully";
        }
    }
}
