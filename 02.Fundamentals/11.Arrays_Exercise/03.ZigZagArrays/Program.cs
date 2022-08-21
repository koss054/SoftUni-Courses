using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] enteredNumbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = enteredNumbers[0];
                    secondArray[i] = enteredNumbers[1];
                }
                else
                {
                    firstArray[i] = enteredNumbers[1];
                    secondArray[i] = enteredNumbers[0];
                }
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write($"{firstArray[i]} ");
            }

            Console.WriteLine();

            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write($"{secondArray[i]} ");
            }
        }
    }
}
