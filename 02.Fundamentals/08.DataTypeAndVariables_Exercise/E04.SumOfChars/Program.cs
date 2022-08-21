using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                char enteredNumber = char.Parse(Console.ReadLine());
                int currentNumber = Convert.ToInt32(enteredNumber);

                sum += currentNumber;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
