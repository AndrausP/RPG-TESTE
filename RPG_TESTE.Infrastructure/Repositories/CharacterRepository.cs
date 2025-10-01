using RPG_TESTE.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using RPG_TESTE.Domain.Enums;

namespace RPG_TESTE.Infrastructure.Repositories
{
    public class CharacterRepository(AppDbContext dbContext) : ICharacterRepository
    {
        public async Task<Character?> AddAsyncRepository(Character character)
        {
            await dbContext.Characters.AddAsync(character);
            await dbContext.SaveChangesAsync();
            return character;
        }
        public async Task<IEnumerable<Character>> GetAllAsyncRepository()
        {
            return await dbContext.Characters.ToListAsync();
        }
        public async Task<Character?> GetByIdAsyncRepository(int id)
        {
            return await dbContext.Characters.FindAsync(id);
        }
        public Task UpdateAsyncRepository(Character character)
        {
            dbContext.Characters.Update(character);
            return Task.CompletedTask;
        }
        public async Task<bool> DeleteAsyncRepository(int id)
        {
            var character = await dbContext.Characters.FindAsync(id);
            if (character == null)
                return false;
            dbContext.Characters.Remove(character);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Character?> GetByNameAsync(string name)
        {
            return await dbContext.Characters.FirstOrDefaultAsync(c => c.Name == name);
        }
        public async Task<IEnumerable<Character>> GetClassCharacter(RpgClass rpgClass)
        {
            return await dbContext.Characters.Where(c => c.RpgClass == rpgClass).ToListAsync();
        }

    }
}
