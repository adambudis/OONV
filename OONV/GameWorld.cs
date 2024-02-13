using MyApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OONV
{
    // TODO: lepší explore, enemy v arene (duel), další state
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
            Console.Clear();

            Hero hero = new Hero("Hrdina", 100, 5, 4);
            hero.Subscribe(this);
            Console.WriteLine("Stats");
            hero.DisplayStats();
            Console.WriteLine("---------------------------");

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


                if (command == "restart")
                    Restart();

                if (command == "quit")
                    Quit();

                Console.WriteLine("---------------------------");
            }
        }

        public void Update(IHeroState state)
        {
            Console.WriteLine($"(Observer) Hero's state changed to: {state.GetType().Name}");
            Console.WriteLine($"Valid commands: {GetValidCommands(state)}");
        }

        private string GetValidCommands(IHeroState state)
        {
            string s = "";
            if (state is IdleState)
                s += "'explore', 'rest', 'train'";
            if (state is ExhaustedState)
                s += "'rest'";
            if (state is DeadState)
                s += "'restart', 'quit'";
            return s;
        }

        private void Restart()
        {
            StartGame();
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
