using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs.Character
{
    public record CharacterCreateDTO
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int ClassId { get; set; }
        public bool IsAlive { get; set; }

        public CharacterCreateDTO(string name, int level, int strength, int defense, int intelligence, int classId, bool isAlive)
        {
            Name = name;
            Level = level;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            ClassId = classId;
            IsAlive = isAlive;
        }
    }
}
