using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs.Character
{
    public record CharacterResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public string ClassName { get; set; }
        public bool IsAlive { get; set; }

        public CharacterResponseDTO(int id, string name, int level, int strength, int defense, int intelligence, bool isAlive)
        {
            Id = id;
            Name = name;
            Level = level;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            IsAlive = isAlive;
        }
    }
}
