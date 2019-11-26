using System;

namespace Human
{
  class Human
  {
    // Fields for Human
    public string Name;
    protected int Strength;
    protected int Intelligence;
    protected int Dexterity;
    protected int Health;

    public int get_health
    {
        get {return Health;}
    }

    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }

    public Human(string name, int intelligence, int strength, int dexterity, int health)
    {
      Name = name;
      Strength = strength;
      Intelligence = intelligence;
      Dexterity = dexterity;
      Health = health;
    }

    public virtual int Attack(Human target, int damage=0)
    {
      target.Health -= damage;
      Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage.");
      return target.get_health;
    }
  }
  class Wizard : Human
  {
    public Wizard(string name) : base(name, 25, 3, 3, 50)
    {
      //nothing
    }
    public override int Attack(Human target, int damage=0) 
    {
      return base.Attack(target, Intelligence*5);
    }
    public int Heal(Human target)
    {
      Console.WriteLine("Healing attack");
      return base.Attack(target, -Intelligence * 10);
    }
  }
  class Ninja : Human
  {
    public Ninja(string name) : base(name, 3, 3, 175, 100)
    {
      //nothing
    }
    public override int Attack(Human target, int damage=0)
    {
      return base.Attack(target, Dexterity * 5);
    }
    public void Steal(Human target)
    {
      base.Attack(target,5);
      Health += 5;
      Console.WriteLine($"Stole 5 point of health from {target.Name} and healed by 5 points");
    }

  }
  class Samurai : Human
  {
    public Samurai(string name) : base(name, 3, 3, 3, 200)
    {
      //nothing
    }
    public override int Attack(Human target, int damage=0)
    {
      if (target.get_health < 50)
      {
        return base.Attack(target, target.get_health);
      }
      else
      {
        return base.Attack(target, Strength*10);
      }
    }
    public void Mediate()
    {
      Health = 200;
      Console.WriteLine("Mediated and healed");
    }

  }
    class Program
    {
        static void Main(string[] args)
        {
            Wizard pidr1 = new Wizard("pidrilla");
            Samurai pidr2 = new Samurai("dodik");
            Console.WriteLine($"{pidr2.Name} has left {pidr1.Attack(pidr2)}");
            pidr2.Mediate();
            Console.WriteLine($"{pidr2.Name} has {pidr2.get_health} point now");
            Console.WriteLine($"{pidr2.Name} has left {pidr2.Attack(pidr1)}");
        }
    }
}
