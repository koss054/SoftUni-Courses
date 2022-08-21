using System;

namespace L04.SumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int currentNumber = int.Parse(input[i]);
                    sum += currentNumber;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
