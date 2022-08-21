using System;
using System.Linq;
using System.Collections.Generic;

namespace E06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] enteredNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            List<int> currentNumbers = new List<int>(enteredNumbers);
            
            Predicate<int> isNotDivisible = number
                => number % n != 0;

            Func<List<int>, List<int>> reverseNumbers = numbers
                =>
            {
                List<int> reversedList = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    reversedList.Add(numbers[i]);
                }

                return reversedList;
            };

            Func<List<int>, List<int>> removeDivisibleNumbers = numbers
                =>
            {
                List<int> cleanedList = new List<int>();

                foreach (int number in numbers)
                {
                    if (isNotDivisible(number))
                    {
                        cleanedList.Add(number);
                    }
                }

                return cleanedList;
            };

            Action<List<int>> printNumbers = numbers
                => Console.WriteLine(string.Join(" ", numbers));

            currentNumbers = reverseNumbers(currentNumbers);
            currentNumbers = removeDivisibleNumbers(currentNumbers);
            printNumbers(currentNumbers);
        }
    }
}
