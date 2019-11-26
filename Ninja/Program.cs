using System;
using System.Collections.Generic;

namespace Ninja
{
  class Food
  {
    public string Name;
    public int Calories;
    // Foods can be Spicy and/or Sweet
    public bool IsSpicy;
    public bool IsSweet;
    
    public Food(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
  }

  class Buffet
  {
    public List<Food> Menu;

    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Gavno", 420, false, false),
            new Food("Lapha", 10, true, false),
            new Food("Boria", -1, false, true),
            new Food("Sopli", 69, true, true),
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        Food to_serve = Menu[rand.Next(0,3)];
        return to_serve;
    }
  }

  class Ninja
  {
    private int calorieIntake;
    public List<Food> FoodHistory;

    public Ninja()
    {
      calorieIntake = 0;
      FoodHistory = new List<Food>();
    }

    public bool isFull
    {
        get {
            if (calorieIntake >= 1200)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }

    public void Eat(Food item)
    {
        if (!isFull)
        {
         calorieIntake = calorieIntake + item.Calories;
         FoodHistory.Add(item);
         Console.WriteLine("Ate " + item.Name + " it is: " + (item.IsSpicy?"spicy":"not spicy") + " and " + (item.IsSweet?" sweet":" not sweet."));
        }
        else
        {
            Console.WriteLine("idi nah");
        }
    }
  }
    class Program
    {
        static void Main(string[] args)
        {
            Buffet gavnishe = new Buffet();
            Ninja pidr = new Ninja();
            //test
            while(!pidr.isFull)
            {
                pidr.Eat(gavnishe.Serve());
            }
        }
    }
}
