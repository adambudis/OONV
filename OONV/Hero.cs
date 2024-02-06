using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OONV
{
    internal class Hero : Character, IHeroObservable
    {
        public string? Name { get; set; }

        public IHeroState? CurrentState { get; set; }

        public List<IHeroObserver> Observers { get; set; }


        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public int Xp { get; set; }

        public Hero(string name, int maxHp, int attack, int defense, int maxEnergy=100) : base(maxHp, attack, defense)
        {
            Name = name;
            Energy = maxEnergy;
            MaxEnergy = maxEnergy;
            Xp = 0;
            CurrentState = new IdleState(this);
            Observers = new List<IHeroObserver>();
        }


        // State pattern
        public void SetState(IHeroState state)
        {
            CurrentState = state;
            Notify(CurrentState);
        }

        public void Rest()
        {
            CurrentState?.Rest();
        }

        public void Explore()
        {
            CurrentState?.Explore();
        }

        public void Train()
        {
            CurrentState?.Train();
        }


        // Class functions
        public void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
                SetState(new DeadState(this));
                Unsubscribe(GameWorld.GetInstance());
                Console.WriteLine("Hero has died.");
            }
        }

        public void Heal(int amount)
        {
            if (Hp + amount <= MaxHp)
            {
                Hp += amount;
            }
        }

        public void ConsumeEnergy(int amount)
        {
            Energy -= amount;
            if (Energy <= 0)
                Energy = 0;
        }

        public void GainEnergy(int amount)
        {
            if (Energy + amount <= 100)
                Energy += amount;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Hp: {Hp}/{MaxHp}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Energy: {Energy}/{MaxEnergy}");
            Console.WriteLine($"Xp: {Xp}");
        }


        // Observer 
        public void Subscribe(IHeroObserver observer)
        {
            Observers.Add(observer);
        }

        public void Unsubscribe(IHeroObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify(IHeroState state)
        {
            foreach(var observer in Observers)
            {
                observer.Update(state);
            }
        }
    }
}
