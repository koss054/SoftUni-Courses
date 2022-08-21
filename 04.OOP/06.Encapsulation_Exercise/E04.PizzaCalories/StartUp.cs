using System;

namespace E04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string pizzaName = pizzaInput[1];

            string[] doughInput = Console.ReadLine().Split();
            string doughType = doughInput[1];
            string bakingTechnique = doughInput[2];
            int doughWeight = int.Parse(doughInput[3]);

            try
            {
                var dough = new Dough(doughType, bakingTechnique, doughWeight);
                var pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppingInput = input.Split();
                    string toppingType = toppingInput[1];
                    int toppingWeight = int.Parse(toppingInput[2]);

                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizzaName} - {pizza.Calories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
