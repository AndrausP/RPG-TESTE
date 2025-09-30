using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Domain.UnifiedResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Interfaces.CharacterInterfaces
{
    public interface ICharacterService
    {
        Task<Result<bool>> DeleteCharacterAsync(int id);
        Task<Result<CharacterResponseDTO>> CreateCharacterAsync(CharacterCreateDTO characterCreateDTO);
        Task<Result<CharacterUpdateDTO>> UpdateCharacterAsync(int id, CharacterUpdateDTO characterUpdateDTO);
    }
}
