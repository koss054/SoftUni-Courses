using System;
using System.Linq;
using System.Collections.Generic;

namespace L05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] userInput = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var queuedNumbers = new Queue<int>(userInput);
            var evenNumbers = new Queue<int>();

            while (queuedNumbers.Count != 0)
            {
                int currentNumber = queuedNumbers.Dequeue();

                if (currentNumber % 2 == 0)
                {
                    evenNumbers.Enqueue(currentNumber);
                }
            }

            while (evenNumbers.Count != 0)
            {
                if (evenNumbers.Count > 1)
                {
                    Console.Write($"{evenNumbers.Dequeue()}, ");
                }
                else
                {
                    Console.Write($"{evenNumbers.Dequeue()}");
                }
            }
        }
    }
}
