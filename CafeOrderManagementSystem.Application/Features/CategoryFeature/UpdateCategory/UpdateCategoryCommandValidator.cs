using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.CategoryFeature.UpdateCategory
{
    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Kategori adı en az 3 karakter olmalıdır");

        }
    }
}
