using System;

namespace RPG
{
    
    abstract class Somebody
    {
        protected int Health;
        protected int Damage;
        public void Take_damage(int damage)
        {
            Health -= damage;
        }
        public abstract void Attack(Somebody somebody);
    }
    class Zombie : Somebody
    {
        public override void Attack(Somebody somebody)
        {
            Console.WriteLine($"Zombie tattacked with {Damage} points");
            somebody.Take_damage(Damage);
        }
    }
    class Pidr : Somebody
    {
        public override void Attack(Somebody somebody)
        {
            Console.WriteLine($"Pidr tattacked with {Damage} points");
            somebody.Take_damage(Damage);
        }
    }
    class Hero : Somebody
    {
        public override void Attack(Somebody somebody)
        {
            Console.WriteLine($"Hero tattacked with {Damage} points");
            somebody.Take_damage(Damage);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
