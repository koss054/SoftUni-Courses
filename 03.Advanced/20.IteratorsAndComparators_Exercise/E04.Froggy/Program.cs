using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> enteredNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake froggyLake = new Lake(enteredNumbers);

            Console.Write(string.Join(", ", froggyLake));
        }
    }
}
