using FluentValidation;
using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Validators
{
    public class CreateCharacterValidator : AbstractValidator<CharacterCreateDTO>
    {
        punlic CreateCharacterValidator(CharacterRepository )
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(c => c.Level)
                .GreaterThan(0).WithMessage("Level must be greater than 0.");
            RuleFor(c => c.Strength)
                .GreaterThanOrEqualTo(0).WithMessage("Strength cannot be negative.");
            RuleFor(c => c.Defense)
                .GreaterThanOrEqualTo(0).WithMessage("Defense cannot be negative.");
            RuleFor(c => c.Intelligence)
                .GreaterThanOrEqualTo(0).WithMessage("Intelligence cannot be negative.");
            RuleFor(c => c.ClassId)
                .GreaterThan(0).WithMessage("ClassId must be greater than 0.");
        }
    }
}
