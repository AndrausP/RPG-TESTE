using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.UnifiedResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Interfaces.CharacterInterfaces
{
    public interface ICharacterQueryService
    {
        Task<Result<List<Character>>> GetAllCharactersAsync();
        Task<Result<List<Character>>> GetAllClasses(string classParam);
    }
}
