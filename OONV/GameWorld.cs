using MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            Console.Clear();

            Hero hero = new Hero("Hrdina", 100, 8, 9);
            hero.Subscribe(this);

            while (hero.CurrentState is not DeadState)
            {
                Console.WriteLine("Enter command: ");
                string? command = Console.ReadLine();
                if (command == "explore")
                    hero.Explore();

                if (command == "rest")
                    hero.Rest();

                if (command == "train")
                    hero.Train();

                Console.WriteLine("---------------------------");
            }

            ProcessRestartQuit();
        }

        public void Update(IHeroState state)
        {
            Console.WriteLine($"(Observer) Hero's state changed to: {state.GetType().Name}");

            if (state is not DeadState)
                Console.WriteLine($"Valid commands: {GetValidCommands(state)}");
        }

        private void ProcessRestartQuit()
        {
            Console.WriteLine("Do you wish to restart the game? Type y/n");
            string? restart = Console.ReadLine();
            while (restart != "y" || restart != "n")
            {
                if (restart == "y")
                    Restart();
                else
                    Quit();

                Console.WriteLine("Do you wish to restart or quit the game?");
                restart = Console.ReadLine();
            }
        }

        private string GetValidCommands(IHeroState state)
        {
            string s = "";
            if (state is IdleState)
                s += "'explore', 'rest', 'train'";
            if (state is ExhaustedState)
                s += "'rest'";
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
