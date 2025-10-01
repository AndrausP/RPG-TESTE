using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<Character?> AddAsyncRepository(Character character);
        Task<IEnumerable<Character>> GetAllAsyncRepository();
        Task<Character?> GetByIdAsyncRepository(int id);
        Task UpdateAsyncRepository(Character character);
        Task<bool> DeleteAsyncRepository(int id);
        Task<Character?> GetByNameAsync(string name);
        Task<IEnumerable<Character>> GetClassCharacter(RpgClass rpgClass);
    }
}
