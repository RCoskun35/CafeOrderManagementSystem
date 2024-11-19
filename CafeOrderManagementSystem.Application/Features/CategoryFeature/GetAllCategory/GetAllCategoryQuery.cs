using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.GetAllCategory
{
    public sealed record GetAllCategoryQuery() : IRequest<List<Category>>;
}
