using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.PizzaCalories
{
    public class Pizza
    {
        private string pizzaName;
        private Dough pizzaDough;
        private List<Topping> pizzaToppings;

        public Pizza(string pizzaName, Dough pizzaDough)
        {
            PizzaName = pizzaName;
            this.pizzaDough = pizzaDough;

            pizzaToppings = new List<Topping>();
        }

        public string PizzaName
        {
            get
            { 
                return pizzaName; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length < 1 ||
                    value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                pizzaName = value;
            }
        }

        public void AddTopping(Topping pizzaTopping)
        {
            if (pizzaToppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            pizzaToppings.Add(pizzaTopping);
        }

        public double Calories()
            => pizzaDough.Calories()
            + pizzaToppings.Sum(x => x.Calories());
    }
}
