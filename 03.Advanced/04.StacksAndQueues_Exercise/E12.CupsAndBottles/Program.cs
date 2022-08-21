using System;
using System.Collections.Generic;
using System.Linq;

namespace E12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. last entered bottle (stack) - first entered cup (queue)
            // 2. cups get removed only when its value is 0
            // 3. bottles get removed, even if they have water - account wasted water in end
            // 4. if all cups are filled - print the remaining water bottles, from last to first
            // 5. if some cups aren't filled - print the remaining cups, from first to last

            int[] cupsAndCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] filledBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // 1.
            var cups = new Queue<int>(cupsAndCapacity);
            var bottles = new Stack<int>(filledBottles);

            int wastedLitres = 0;
            int currentCup = cups.Dequeue();
            bool isCupFilled = false;

            while (cups.Count != 0 && bottles.Count != 0)
            {
                if (isCupFilled)
                {
                    currentCup = cups.Dequeue();
                }

                isCupFilled = false;
                int currentBottle = bottles.Pop();

                if (currentCup - currentBottle > 0)
                {
                    currentCup -= currentBottle;
                }
                else
                {
                    // 3.
                    wastedLitres += (currentBottle - currentCup);
                    isCupFilled = true;
                }
            }

            if (cups.Count > 0)
            {
                // 5.
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                // 4.
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitres}");
        }
    }
}
