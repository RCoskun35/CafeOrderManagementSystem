using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email must be a valid email address")
                .MinimumLength(3)
                .WithMessage("Email information must be at least 3 characters.");
            RuleFor(p => p.Password)
                .MinimumLength(1)
                .WithMessage("Password must be at least 1 character");
        }
    }
}
