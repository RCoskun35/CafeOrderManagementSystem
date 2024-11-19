using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.Email)
                .MinimumLength(3)
                .WithMessage("Mail bilgisi en az 3 karakter olmalıdır");
            RuleFor(p => p.Password)
                .MinimumLength(1)
                .WithMessage("Password must be at least 1 character");
        }
    }
}
