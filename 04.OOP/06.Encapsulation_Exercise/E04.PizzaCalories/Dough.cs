using System;
using System.Collections.Generic;

namespace E04.PizzaCalories
{
    public class Dough
    {
        private readonly Dictionary<string, double> doughModifiers =
            new Dictionary<string, double>()
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 },
                { "crispy", 0.9 },
                { "chewy", 1.1 },
                { "homemade", 1.0 }
            };

        private int grams;
        private string doughType;
        private string bakingTechnique;

        public Dough(string doughType, string bakingTechnique, int grams)
        {
            DoughType = doughType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public int Grams
        {
            get 
            { 
                return grams; 
            }
            private set 
            { 
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value; 
            }
        }

        public string DoughType
        {
            get 
            { 
                return doughType; 
            }
            private set 
            { 
                if (!doughModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                doughType = value; 
            }
        }


        public string BakingTechnique
        {
            get 
            { 
                return bakingTechnique; 
            }
            private set 
            { 
                if (!doughModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value; 
            }
        }


        public double Calories()
            => (2 * Grams) * doughModifiers[DoughType.ToLower()] * doughModifiers[BakingTechnique.ToLower()];
    }
}
