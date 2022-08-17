using System;

namespace E05.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            double penPrice = 5.8;
            double markerPrice = 7.2;
            double boardCleanerPrice = 1.2;

            int numOfPens = int.Parse(Console.ReadLine());
            int numOfMarkers = int.Parse(Console.ReadLine());
            int litresOfBoardCleaner = int.Parse(Console.ReadLine());
            double discountPercentage = double.Parse(Console.ReadLine()) / 100;

            double totalPriceWithoutDiscount =
                (penPrice * numOfPens) +
                (markerPrice * numOfMarkers) +
                (boardCleanerPrice * litresOfBoardCleaner);

            double discount =
                totalPriceWithoutDiscount * 
                discountPercentage;

            double totalPriceWithDiscount =
                totalPriceWithoutDiscount -
                discount;

            Console.WriteLine(totalPriceWithDiscount);
        }
    }
}
