using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.UpdateProduct
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Ürün adı 3 karakterden az olamaz");

        }
    }
}
