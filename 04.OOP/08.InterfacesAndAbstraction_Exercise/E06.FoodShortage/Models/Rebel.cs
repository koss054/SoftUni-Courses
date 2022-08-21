using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 5;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food 
        { 
            get { return this.food; }
            set { this.food = value; }
        }

        public int BuyFood(int totalFood)
        {
            return this.Food + totalFood;
        }
    }
}
