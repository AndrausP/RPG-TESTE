using RPG_TESTE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Domain.Entity
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass RpgClass { get; set; }      
        public bool IsAlive { get; set; } = true;


         
    }
}