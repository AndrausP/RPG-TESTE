using RPG_TESTE.Domain.DTOs;
using RPG_TESTE.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_TESTE.Domain.Interfaces;

namespace RPG_TESTE.Infrastructure.Repositories
{
    public class CharacterRepository(AppDbContext dbContext) : ICharacterRepository
    {
        public async Task AddAsyncRepository(CharacterCreateDTO dTO)
        {

            await dbContext.SaveChangesAsync();
        }
    }
}
