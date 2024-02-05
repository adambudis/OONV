using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    public class GameWorld
    {
        private static GameWorld? instance;

        private GameWorld() { }

        public static GameWorld getInstance()
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
    }
}
