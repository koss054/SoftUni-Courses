using System;
using System.Linq;

namespace _06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                leftSum = 0;

                for (int leftIndex = i; leftIndex > 0; leftIndex--)
                {
                    int nextNumber = leftIndex - 1;

                    if (leftIndex > 0)
                    {
                        leftSum += numbers[nextNumber];
                    }
                }

                rightSum = 0;

                for (int rightIndex = i; rightIndex < numbers.Length; rightIndex++)
                {
                    int nextNumber = rightIndex + 1;

                    if (rightIndex < numbers.Length - 1)
                    {
                        rightSum += numbers[nextNumber];
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
