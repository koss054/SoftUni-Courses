using System;
using System.Linq;

namespace L01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(",").Select(x => int.Parse(x)).ToArray();
            int[] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            int[] sortedNumbers = evenNumbers.OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
