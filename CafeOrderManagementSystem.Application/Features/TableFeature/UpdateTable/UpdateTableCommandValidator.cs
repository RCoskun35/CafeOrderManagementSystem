﻿using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.UpdateTable
{
    public sealed class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableCommandValidator()
        {
            RuleFor(p => p.TableNumber)
                .MinimumLength(1)
                .WithMessage("Table number must be at least 1 characters");

        }
    }
}