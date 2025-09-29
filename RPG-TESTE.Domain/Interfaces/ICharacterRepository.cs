using RPG_TESTE.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task AddAsyncRepository(CharacterCreateDTO dTO);
    }
}
