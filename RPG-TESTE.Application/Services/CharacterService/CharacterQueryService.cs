using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Application.Interfaces.CharacterInterfaces;
using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.Enums;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Domain.UnifiedResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Services.CharacterService
{
    public class CharacterQueryService(ICharacterRepository characterRepository) : ICharacterQueryService
    {
        public async Task<Result<IEnumerable<Character>>> GetAllCharactersAsync()
        {
            var characters = await characterRepository.GetAllAsyncRepository();
            return Result<IEnumerable<Character>>.Success(characters, 200);
        }
        public async Task<Result<IEnumerable<Character>>> GetAllClasses(RpgClass rpgClass)
        {
           if(!Enum.IsDefined(typeof(RpgClass), rpgClass))
                return Result<IEnumerable<Character>>.Failure("Invalid class type.", 400);
            var characters = await characterRepository.GetClassCharacter(rpgClass);
            return Result<IEnumerable<Character>>.Success(characters, 200);
        }
    }
}
