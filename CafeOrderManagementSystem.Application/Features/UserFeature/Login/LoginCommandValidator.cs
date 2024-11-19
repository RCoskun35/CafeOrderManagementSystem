﻿using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.Login
{
    public sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }

}
