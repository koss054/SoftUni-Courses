using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 10;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food
        { 
            get { return this.food; }
            set { this.food = value; } 
        }

        public int BuyFood(int totalfood)
        {
            return this.Food + totalfood;
        }
    }
}
