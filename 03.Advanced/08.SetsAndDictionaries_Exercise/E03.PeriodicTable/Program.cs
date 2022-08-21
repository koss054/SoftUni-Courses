using System;
using System.Linq;
using System.Collections.Generic;

namespace E03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            var uniqueElements = new SortedSet<string>();

            for (int i = 0; i < inputLines; i++)
            {
                var currentElements = Console.ReadLine().Split();

                foreach (string element in currentElements)
                {
                    uniqueElements.Add(element);
                }
            }
        
            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}
