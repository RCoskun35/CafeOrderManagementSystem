using CafeOrderManagementSystem.Application.Features.UserFeature.Register;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.CreateCategory
{
    public sealed record CreateCategoryCommand(string Name) : IRequest<string>;
}
