using System;
using System.Linq;
using System.Collections.Generic;

namespace E08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, n).ToList();

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<Predicate<int>> predicates
                = new List<Predicate<int>>();

            foreach (int divider in dividers)
            {
                predicates.Add(x => x % divider == 0);
            }

            foreach (int number in numbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
