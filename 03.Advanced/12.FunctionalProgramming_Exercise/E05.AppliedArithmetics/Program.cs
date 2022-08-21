using System;
using System.Linq;

namespace E05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> addOneToNumbers = numbers
                =>
            {
                int[] newArray = numbers;

                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] += 1;
                }

                return newArray;
            };

            Func<int[], int[]> multiplyNumbersByTwo = numbers
                =>
            {
                int[] newArray = numbers;

                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] *= 2;
                }

                return newArray;
            };

            Func<int[], int[]> subtractOneFromNumbers = numbers
                =>
            {
                int[] newArray = numbers;

                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] -= 1;
                }

                return newArray;
            };

            Action<int[]> printNumbers = numbers
                => Console.WriteLine(string.Join(" ", numbers));

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    return;
                }

                switch (command)
                {
                    case "add": addOneToNumbers(numbers); break;
                    case "multiply": multiplyNumbersByTwo(numbers); break;
                    case "subtract": subtractOneFromNumbers(numbers); break;
                    case "print": printNumbers(numbers); break;
                }
            }
        }
    }
}
