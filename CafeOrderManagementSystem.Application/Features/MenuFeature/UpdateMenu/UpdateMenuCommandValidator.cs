using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.UpdateMenu
{
    public sealed class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
    {
        public UpdateMenuCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Menu name must be at least 3 characters");

        }
    }
}
