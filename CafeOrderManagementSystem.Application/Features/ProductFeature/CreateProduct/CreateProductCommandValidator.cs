using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Product name must be at least 3 characters");

        }
    }
}
