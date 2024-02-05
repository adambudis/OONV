using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal abstract class Character
    {
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Character(int maxHp, int attack, int defense)
        {
            Hp = maxHp;
            MaxHp = maxHp;
            Attack = attack;
            Defense = defense;
        }

        public virtual void DisplayStats() { }
    }
}
