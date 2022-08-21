using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] enteredNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;

            for (int i = 0; i < enteredNumbers.Length; i++)
            {
                if (enteredNumbers[i] % 2 == 0)
                {
                    evenSum += enteredNumbers[i];
                }
            }

            Console.WriteLine($"{evenSum}");
        }
    }
}
