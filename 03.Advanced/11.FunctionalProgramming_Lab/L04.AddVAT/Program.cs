using System;
using System.Linq;

namespace L04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
