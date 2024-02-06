using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal class GameWorld : IHeroObserver
    {
        private static GameWorld? instance;

        private GameWorld() { }

        public static GameWorld GetInstance()
        {
            if (instance == null)
            {
                instance = new GameWorld();
            }
            return instance;
        }

        public void StartGame()
        {
            Hero hero = new Hero("Hrdina", 100, 8, 9);
            hero.Subscribe(this);

            while (true)
            {
                Console.WriteLine("Enter command: ");
                string? command = Console.ReadLine();
                if (command == "explore")
                    hero.Explore();

                if (command == "rest")
                    hero.Rest();

                if (command == "train")
                    hero.Train();
            }
        }

        public void Update(IHeroState state)
        {
            Console.WriteLine($"(Observer) Hero's state changed to: {state.GetType()}");
        }

    }
}
