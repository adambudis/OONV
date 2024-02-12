using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal class ExhaustedState : IHeroState
    {
        public Hero Context { get; set; }
        public ExhaustedState(Hero context)
        {
            Context = context;
        }

        public void Explore()
        {
            Console.WriteLine("Can't explore, hero has low energy");
        }

        public void Rest()
        {
            Console.WriteLine("Gained 5 hp and 10 energy from resting");
            Context.Heal(8);
            Context.GainEnergy(10);

            if (Context.Energy >= 20)
            {
                Context.SetState(new IdleState(Context));
            }

            Context.DisplayStats();
        }

        public void Train()
        {
            Console.WriteLine("Cant't train, hero has low energy");
        }
    }
}
