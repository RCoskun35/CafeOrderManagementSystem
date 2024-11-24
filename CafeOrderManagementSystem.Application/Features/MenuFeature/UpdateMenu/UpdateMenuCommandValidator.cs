using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.UpdateMenu
{
    public sealed class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
    {
        public UpdateMenuCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Menü adı 3 karakterden az olamaz");

        }
    }
}
