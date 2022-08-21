using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> enteredArray = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            for (int i = 0; i < enteredArray.Count; i++)
            {
                List<string> sortedArray = enteredArray[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int j = 0; j < sortedArray.Count; j++)
                {
                    Console.Write($"{sortedArray[j]} ");
                }
            }
        }
    }
}
