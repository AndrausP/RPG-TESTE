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
        public async Task<Result<List<Character>>> GetAllCharactersAsync()
        {
            var characters = await characterRepository.GetAllAsyncRepository();
            return Result<List<Character>>.Success(characters, 200);
        }
        public async Task<Result<List<Character>>> GetAllClasses(string classParam)
        {
            if (!Enum.TryParse<RpgClass>(classParam, true, out var parsedClass))
            {
                if (int.TryParse(classParam, out var classId) && Enum.IsDefined(typeof(RpgClass), classId))             
                    parsedClass = (RpgClass)classId;   
                    return Result<List<Character>>.Failure("Invalid class parameter.", 400);
            }
            return Result<List<Character>>.Success(await characterRepository.GetClassCharacter(parsedClass), 200);
        }
    }
}
