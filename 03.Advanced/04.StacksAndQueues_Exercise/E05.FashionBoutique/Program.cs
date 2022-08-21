using System;
using System.Linq;
using System.Collections.Generic;

namespace E05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesInBox = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var clothesStack = new Stack<int>(clothesInBox);
            int rackCapacity = int.Parse(Console.ReadLine());

            int currentSum = 0;
            int totalRacks = 1;

            while (clothesStack.Count > 0)
            {
                int currentValue = clothesStack.Peek();

                if (currentSum + currentValue <= rackCapacity)
                {
                    currentSum += currentValue;                  
                    clothesStack.Pop();
                }
                else
                {
                    currentSum = 0;
                    totalRacks++;
                }
            }

            Console.WriteLine(totalRacks);
        }
    }
}
