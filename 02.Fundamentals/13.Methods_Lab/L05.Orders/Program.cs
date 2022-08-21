using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string productBought = Console.ReadLine();
            int timesBought = int.Parse(Console.ReadLine());

            TotalProductPrice(productBought, timesBought);
        }

        static void TotalProductPrice(string productBought, int timesBought)
        {
            double currentProductPrice = 0.0;
            decimal totalPrice = 0;

            switch (productBought)
            {
                case "coffee":
                    currentProductPrice = 1.50;
                    break;
                case "water":
                    currentProductPrice = 1.00;
                    break;
                case "coke":
                    currentProductPrice = 1.40;
                    break;
                case "snacks":
                    currentProductPrice = 2.00;
                    break;
            }

            totalPrice = timesBought * (decimal) currentProductPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
