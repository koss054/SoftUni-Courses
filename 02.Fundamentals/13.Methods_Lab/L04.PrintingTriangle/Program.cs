using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTriangles(int.Parse(Console.ReadLine()));
        }

        static void PrintTriangles(int enteredNumber)
        {
            for (int i = 1; i <= enteredNumber; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j} ");
                }

                Console.WriteLine();
            }

            for (int i = enteredNumber - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j} ");
                }

                Console.WriteLine();
            }
        }
    }
}
