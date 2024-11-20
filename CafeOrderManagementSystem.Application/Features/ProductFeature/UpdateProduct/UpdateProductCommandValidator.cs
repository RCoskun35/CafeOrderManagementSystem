using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.UpdateProduct
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Product name must be at least 3 characters");

        }
    }
}
