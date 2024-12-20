﻿using FluentValidation;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.CreateTable
{
    public sealed class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(p => p.TableNumber)
                .MinimumLength(1)
                .WithMessage("Masa numarası zorunlu");

        }
    }
}
