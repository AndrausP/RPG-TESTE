using FluentValidation;
using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Application.Interfaces.CharacterInterfaces;
using RPG_TESTE.Application.Mappers;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Domain.UnifiedResponse;

namespace RPG_TESTE.Application.Services.CharacterService
{
    public class CharacterService(ICharacterRepository characterRepository, IValidator<CharacterCreateDTO> validator, IValidator<CharacterUpdateDTO> validatorUp) : ICharacterService
    {
        public async Task<Result<CharacterResponseDTO>> CreateCharacterAsync(CharacterCreateDTO characterCreateDTO)
        {
            var validation = await validator.ValidateAsync(characterCreateDTO);
            if (validation.IsValid == false)
            {
                var errors = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                return Result<CharacterResponseDTO>.Failure(errors, 400);
            }
            var entity = characterCreateDTO.ToEntity();
            var entityCreated = await characterRepository.AddAsyncRepository(entity);
            var responseDto = entityCreated.ToCharacterResponseDto();
            return Result<CharacterResponseDTO>.Success(responseDto, 201);

        }
        public async Task<Result<CharacterUpdateDTO>> UpdateCharacterAsync(int id, CharacterUpdateDTO characterUpdateDTO)
        {
            var entity = await characterRepository.GetByIdAsyncRepository(id);
            if (entity is null)
                return Result<CharacterUpdateDTO>.Failure("Character not found.", 404);
            var validation = await validatorUp.ValidateAsync(characterUpdateDTO);
            if (!validation.IsValid)
            {
                var errors = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                return Result<CharacterUpdateDTO>.Failure(errors, 400);
            }
            var newName = characterUpdateDTO.Name ?? entity.Name;
            entity.Name = newName;
            entity.Strength = characterUpdateDTO.Strength;
            entity.Defense = characterUpdateDTO.Defense;
            entity.Intelligence = characterUpdateDTO.Intelligence;
            entity.IsAlive = characterUpdateDTO.IsAlive;
            await characterRepository.UpdateAsyncRepository(entity);
            return Result<CharacterUpdateDTO>.Success(characterUpdateDTO, 200);
        }
        public async Task<Result<bool>> DeleteCharacterAsync(int id)
        {
            var resultDelete = await characterRepository.DeleteAsyncRepository(id);
            if (resultDelete is false)
                return Result<bool>.Failure("Character not found.", 404);
           return Result<bool>.Success(true, 204);
        }
    }
}
