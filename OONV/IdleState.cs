﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal class IdleState : IHeroState
    {
        public Hero Context { get; set; }  

        private Random rand = new Random();

        public IdleState(Hero context)
        {
            Context = context;
        }

        public void Explore()
        {
            Context.ConsumeEnergy(10);
            int dmgTaken = DamageTaken();
            Context.TakeDamage(dmgTaken);

            if (Context.CurrentState is DeadState)
            {
                Context.DisplayStats();
                return;
            }

            int xpGained = ExpGained();
            Context.Xp += xpGained;
            Console.WriteLine($"Taken {dmgTaken} damage and gained {xpGained} experience.");
            Context.DisplayStats();

            if (Context.Energy < 20)
            {
                Context.SetState(new ExhaustedState(Context));
            }
        }

        public void Rest()
        {
            Console.WriteLine("Gained 5 hp and 10 energy from resting");
            Context.Heal(5);
            Context.GainEnergy(10);

            Context.DisplayStats();
        }

        public void Train()
        {
            int att = rand.Next(1, 10);
            int def = rand.Next(1, 10);
            int energyCost = 15;

            Context.ConsumeEnergy(energyCost);
            Context.Attack += att;
            Context.Defense += def;

            Console.WriteLine($"Gained {att} attack and {def} defense points.");
            Console.WriteLine($"Energy cost: {energyCost}");
            Context.DisplayStats();

            if (Context.Energy < 20)
            {
                Context.SetState(new ExhaustedState(Context));
            }
        }


        private int DamageTaken()
        {
            int dmg = Context.Xp - (Context.Attack + Context.Defense);
            if (dmg < 0)
            {
                return 0;
            }
            return dmg;
        }

        private int ExpGained()
        {
            return rand.Next(12, 18);
        }
    }
}
