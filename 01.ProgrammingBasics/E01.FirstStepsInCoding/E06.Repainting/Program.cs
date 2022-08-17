using System;

namespace E06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double nylonPrice = 1.5;
            double paintPrice = 14.5;
            double paintThinnerPrice = 5;
            double bagPrice = 0.4;

            int nylonQuantity = int.Parse(Console.ReadLine());
            int paintQuantity = int.Parse(Console.ReadLine());
            int paintThinnerQuantity = int.Parse(Console.ReadLine());
            int hoursNeeded = int.Parse(Console.ReadLine());

            double totalMaterialsPrice =
                (nylonPrice * (nylonQuantity + 2)) +
                (paintPrice * (paintQuantity + (paintQuantity * 0.1))) +
                (paintThinnerPrice * paintThinnerQuantity) +
                bagPrice;

            double workersPay =
                (totalMaterialsPrice * 0.3) *
                hoursNeeded;

            double totalSum =
                totalMaterialsPrice +
                workersPay;

            Console.WriteLine(totalSum);
        }
    }
}
