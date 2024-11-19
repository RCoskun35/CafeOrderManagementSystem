using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.GetAllCategory
{
    public class GetAllCategoryQueryHandler(IRepository<Category> repository) : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAll().ToListAsync();
        }
    }
}
