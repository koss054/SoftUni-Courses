using System;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumbers = int.Parse(Console.ReadLine());

            int[] enteredNumbers = new int[totalNumbers];

            for (int i = 0; i < totalNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                enteredNumbers[i] = currentNumber;
            }

            for (int i = enteredNumbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{enteredNumbers[i]} ");
            }
        }
    }
}
