using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int numGamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int brokenHeadsets = 0;
            int brokenMice = 0;
            int brokenKeyboards = 0;
            int brokenDisplays = 0;

            int counter = 0;

            for (int i = 1; i <= numGamesLost; i++)
            {
                if (i % 2 == 0)
                {
                    brokenHeadsets++;
                }

                if (i % 3 == 0)
                {
                    brokenMice++;
                }

                if (i % 6 == 0)
                {
                    brokenKeyboards++;
                    counter++;

                    if (counter == 2)
                    {
                        brokenDisplays++;
                        counter = 0;
                    }
                }
            }

            double totalCost = (headsetPrice * brokenHeadsets) + (mousePrice * brokenMice) + (keyboardPrice * brokenKeyboards) + (displayPrice * brokenDisplays);

            Console.WriteLine($"Rage expenses: {totalCost:F2} lv.");
        }
    }
}