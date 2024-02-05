using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal class DeadState : IHeroState
    {
        public Hero Context { get; set; }
        public DeadState(Hero context)
        {
            Context = context;
        }

        public void Explore()
        {
            Console.WriteLine("Can't explore, hero is dead.");
        }

        public void Rest()
        {
            Console.WriteLine("Can't rest, hero is dead.");
        }

        public void Train()
        {
            Console.WriteLine("Can't train, hero is dead.");
        }
    }
}
