using RPG_TESTE.Application.DTOs.Character;
using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Mappers
{
    public static class CharacterMap
    {

        public static Character ToEntity(this CharacterCreateDTO dto)
        {
            return new Character
            {
                Name = dto.Name,
                Level = dto.Level,
                Strength = dto.Strength,
                Defense = dto.Defense,
                Intelligence = dto.Intelligence,
                Class = (RpgClass)dto.ClassId
            };
        }
        public static CharacterResponseDTO ToCharacterResponseDto(this Character entity)
        {
            return new CharacterResponseDTO(
                entity.Id, 
                entity.Name, 
                entity.Level, 
                entity.Strength, 
                entity.Defense, 
                entity.Intelligence, 
                entity.IsAlive
                );
        }

    }
}
