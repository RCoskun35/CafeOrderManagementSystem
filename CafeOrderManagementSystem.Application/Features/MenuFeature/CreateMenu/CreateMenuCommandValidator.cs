using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.CreateMenu
{
    public sealed class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Menu name must be at least 3 characters");

        }
    }
}
