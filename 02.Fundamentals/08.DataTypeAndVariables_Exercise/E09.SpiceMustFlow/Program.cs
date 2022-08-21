using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int consumedSpice = 26;

            int sourceYield = int.Parse(Console.ReadLine());
            decimal collectedSpice = 0;
            int daysOperated = 0;

            while (true)
            {

                if (sourceYield < 100)
                {
                    if (collectedSpice >= consumedSpice)
                    {
                        collectedSpice -= consumedSpice;
                    }
                    break;
                }

                collectedSpice += sourceYield - consumedSpice;
                sourceYield -= 10;
                daysOperated++;
            }

            Console.WriteLine($"{daysOperated}");
            Console.WriteLine($"{collectedSpice}");
        }
    }
}
