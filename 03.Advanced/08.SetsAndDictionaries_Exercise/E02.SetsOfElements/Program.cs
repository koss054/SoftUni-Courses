using System;
using System.Linq;
using System.Collections.Generic;

namespace E02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenghts = Console.ReadLine().Split();
            int firstLenght = int.Parse(lenghts[0]);
            int secondLenght = int.Parse(lenghts[1]);

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < firstLenght; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondLenght; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
