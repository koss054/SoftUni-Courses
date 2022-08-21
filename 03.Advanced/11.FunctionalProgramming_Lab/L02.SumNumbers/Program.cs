using System;
using System.Linq;

namespace L02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] numbers = input.Split(", ").Select(parser).ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
