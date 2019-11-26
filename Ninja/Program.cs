using System;
using System.Collections.Generic;

namespace Ninja
{
  interface IConsumable
  {
    string Name { get; set; }
    int Calories { get; set; }
    bool IsSpicy { get; set; }
    bool IsSweet { get; set; }
    string GetInfo();
  }
  class Food : IConsumable
  {
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }
    public string GetInfo()
    {
      return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    public Food(string name, int calories, bool spicy, bool sweet)
    {
      Name = name;
      Calories = calories;
      IsSpicy = spicy;
      IsSweet = sweet;
    }
  }
  class Drink : IConsumable
  {
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }
    public string GetInfo()
    {
      return $"{Name} (Drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    public Drink(string name, int calories)
    {
      Name = name;
      Calories = calories;
      IsSpicy = false;
      IsSweet = true;
    }
    
  }

  class Buffet
  {
    public List<IConsumable> Menu;

    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("Gavno", 420, false, false),
            new Food("Lapha", 10, true, false),
            new Food("Boria", -1, false, true),
            new Food("Sopli", 69, true, true),
            new Drink("Pomoi", 200),
            new Drink("Scanina", -100),
            new Drink("Koncha", 420),
        };
    }

    public IConsumable Serve()
    {
        Random rand = new Random();
        IConsumable to_serve = Menu[rand.Next(0,6)];
        return to_serve;
    }
  }

  abstract class Ninja
  {
    protected int calorieIntake;
    public List<IConsumable> ConsumptionHistory;

    public Ninja()
    {
      calorieIntake = 0;
      ConsumptionHistory = new List<IConsumable>();
    }

    public abstract bool isFull{get;}

    public abstract void Consume(IConsumable item);
  }
  class SweetTooth : Ninja
  {
      public override bool isFull
      {
          get
          {
              if (calorieIntake > 1500)
                  return true;
              else
                  return false;
          }
      }
      public override void Consume(IConsumable item)
      {
            calorieIntake += item.Calories;
            if (item.IsSweet)
                calorieIntake += 10;
            if (!isFull)
                Console.WriteLine($"Ate {item.Name} and now has {calorieIntake}");
            else
                Console.WriteLine($"Ate {item.Name} and now is full...");
          }
    }
    class SpiceHound : Ninja
    {
        public override bool isFull
        {
        get
        {
            if (calorieIntake > 1200)
            return true;
            else
            return false;
        }
        }
        public override void Consume(IConsumable item)
        {
        calorieIntake += item.Calories;
        if (item.IsSpicy)
            calorieIntake += -100;
        if (!isFull)
            Console.WriteLine($"Ate {item.Name} and now has {calorieIntake}");
        else
            Console.WriteLine($"Ate {item.Name} and now is full...");
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
           Buffet gavnishe = new Buffet();
           SweetTooth loshara = new SweetTooth();
           SpiceHound pidr = new SpiceHound();

           while (!pidr.isFull && !loshara.isFull)
           {
                pidr.Consume(gavnishe.Serve());
                loshara.Consume(gavnishe.Serve());
           }
        }
    }
}

