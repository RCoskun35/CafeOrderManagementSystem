using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.GetCategoryById
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository) : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id);
        }
    }


}
