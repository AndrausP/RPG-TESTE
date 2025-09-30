using FluentValidation;
using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Validators
{
    public class UpdateCharacterFilter : FluentValidation.AbstractValidator<CharacterUpdateDTO>
    { 
        public UpdateCharacterFilter(ICharacterRepository characterRepository)
        {
            RuleLevelCascadeMode = FluentValidation.CascadeMode.Stop;
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(async (dto, name, cancellation) =>
                {
                    var existingCharacter = await characterRepository.GetByNameAsync(name);
                    return existingCharacter is null;
                })
                .WithMessage("A character with the same name already exists.");
            RuleFor(c => c.Strength)
                .GreaterThanOrEqualTo(0).WithMessage("Strength cannot be negative.");
            RuleFor(c => c.Defense)
                .GreaterThanOrEqualTo(0).WithMessage("Defense cannot be negative.");
            RuleFor(c => c.Intelligence)
                .GreaterThanOrEqualTo(0).WithMessage("Intelligence cannot be negative.");
        }
    }
}
