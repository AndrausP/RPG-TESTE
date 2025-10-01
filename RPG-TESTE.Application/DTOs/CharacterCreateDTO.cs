using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs
{
    public record CharacterCreateDTO
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int RpgClass { get; set; }
        public bool IsAlive { get; set; }

        public CharacterCreateDTO(string name,int hp, int level, int strength, int defense, int intelligence, int rpgClass, bool isAlive)
        {
            Name = name;
            HP = hp;
            Level = level;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            RpgClass = rpgClass;
            IsAlive = isAlive;
        }
    }
}
