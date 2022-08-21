using System;
using System.Collections.Generic;

namespace E04.PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> toppingModifiers =
            new Dictionary<string, double>
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };

        private string toppingType;
        private int grams;

        public Topping(string toppingType, int grams)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        public string ToppingType
        {
            get 
            { 
                return toppingType; 
            }
            private set
            { 
                if (!toppingModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value; 
            }
        }

        public int Grams
        {
            get 
            { 
                return grams; 
            }
            private set
            { 
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }

                grams = value; 
            }
        }

        public double Calories()
            => (2 * Grams) * toppingModifiers[ToppingType.ToLower()];
    }
}
