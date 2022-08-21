using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SmallestNumber());
        }

        static int SmallestNumber()
        {
            int smallestNumber = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < smallestNumber)
                {
                    smallestNumber = currentNumber;
                }
            }

            return smallestNumber;
        }
    }
}
