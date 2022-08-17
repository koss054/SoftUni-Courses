using System;

namespace E07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            double chickenMenuPrice = 10.35;
            double fishMenuPrice = 12.4;
            double vegetarianMenuPrice = 8.15;
            double dessertPercentage = 0.2; 
            double deliveryPrice = 2.5;

            int chickenMenuQuantity = int.Parse(Console.ReadLine());
            int fishMenuQuantity = int.Parse(Console.ReadLine());
            int vegetarianMenuQuantity = int.Parse(Console.ReadLine());

            double menuPrices =
                (chickenMenuPrice * chickenMenuQuantity) +
                (fishMenuPrice * fishMenuQuantity) +
                (vegetarianMenuPrice * vegetarianMenuQuantity);

            double dessertPrice =
                menuPrices * dessertPercentage;

            double totalPrice =
                menuPrices + dessertPrice + deliveryPrice;

            Console.WriteLine(totalPrice);
        }
    }
}
