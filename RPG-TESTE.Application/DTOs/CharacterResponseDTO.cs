using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs
{
    public record CharacterResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int RpgClass { get; set; }
        public bool IsAlive { get; set; }

        public CharacterResponseDTO(int id, string name,int hp, int level, int strength, int defense, int intelligence,int classR, bool isAlive)
        {
            Id = id;
            Name = name;
            HP = hp;
            Level = level;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            RpgClass = classR;
            IsAlive = isAlive;
        }
    }
}
