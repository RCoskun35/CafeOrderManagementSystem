using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Ürün adı 3 karakterden az olamazs");

        }
    }
}
