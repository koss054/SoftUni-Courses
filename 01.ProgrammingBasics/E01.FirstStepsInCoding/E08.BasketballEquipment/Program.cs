using System;

namespace E08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearlyTax = int.Parse(Console.ReadLine());

            double shoesPrice =
                yearlyTax -
                (yearlyTax * 0.4);

            double suitPrice =
                shoesPrice -
                (shoesPrice * 0.2);

            double ballPrice =
                suitPrice * 0.25;

            double accessoriesPrice =
                ballPrice * 0.20;

            double totalPrice =
                yearlyTax +
                shoesPrice +
                suitPrice +
                ballPrice +
                accessoriesPrice;

            Console.WriteLine(totalPrice);
        }
    }
}
