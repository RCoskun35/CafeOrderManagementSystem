using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.CreateCategory
{
    public class CreateCategoryCommandHandler(
            IRepository<Category> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRequestHandler<CreateCategoryCommand, string>
    {
        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isExistCategory = await repository.GetByExpressionWithTrackingAsync(x => x.Name == request.Name);
            if (isExistCategory != null)
                throw new Exception("Category already exist");
            var category = mapper.Map<Category>(request);
            await repository.AddAsync(category,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return category.Name;
        }
    }
}
