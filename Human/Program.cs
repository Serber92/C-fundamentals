using System;

namespace Human
{
  class Human
  {
    // Fields for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int Health;

    int get_health
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

    public int Attack(Human target)
    {
        target.Health = target.Health - Strength*5;
        return target.get_health;
    }
  }
    class Program
    {
        static void Main(string[] args)
        {
            Human pidr1 = new Human("pidrilla");
            Human pidr2 = new Human("dodik");
            Console.WriteLine(pidr1.Attack(pidr2));
        }
    }
}
