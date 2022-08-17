using System;

namespace E09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerSquareMeter = 7.61;
            double discount = 0.18;

            double greenMeters = double.Parse(Console.ReadLine());

            double wholeYardCost = greenMeters * pricePerSquareMeter;
            double discountSum = wholeYardCost * discount;
            double finalSum = wholeYardCost - discountSum;

            Console.WriteLine($"The final price is: {finalSum} lv.");
            Console.WriteLine($"The discount is: {discountSum} lv.");
        }
    }
}
