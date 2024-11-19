using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.CreateCategory
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Category name must be at least 3 characters");

        }
    }
}
