using System;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            signOfNum(int.Parse(Console.ReadLine()));
        }

        static void signOfNum (int enteredNumber)
        {
            Console.Write($"The number {enteredNumber} ");

            if (enteredNumber > 0)
            {
                Console.WriteLine("is positive.");
            }
            else if (enteredNumber == 0)
            {
                Console.WriteLine("is zero.");
            }
            else
            {
                Console.WriteLine("is negative.");
            }
        }
    }
}
