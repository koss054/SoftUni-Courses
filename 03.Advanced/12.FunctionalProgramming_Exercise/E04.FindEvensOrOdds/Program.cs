using System;
using System.Linq;
using System.Collections.Generic;

namespace E04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = ranges[0]; i <= ranges[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number
                => number % 2 == 0;

            Predicate<int> isOdd = number
                => number % 2 != 0;

            List<int> result = new List<int>();

            switch (command)
            {
                case "even": result = numbers.FindAll(isEven); break;
                case "odd": result = numbers.FindAll(isOdd); break;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
