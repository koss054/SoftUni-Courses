using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int waterTankCapacity = 255;

            int enteredNumber = int.Parse(Console.ReadLine());
            int litresInWaterTank = 0;

            for (int i = 0; i < enteredNumber; i++)
            {
                int addedLitres = int.Parse(Console.ReadLine());

                if (addedLitres + litresInWaterTank > waterTankCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    litresInWaterTank += addedLitres;
                }
            }

            Console.WriteLine($"{litresInWaterTank}");
        }
    }
}
