using System;

namespace _05.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int endingNumber = int.Parse(Console.ReadLine());

            for (int i = startingNumber; i <= endingNumber; i++)
            {
                char currentSymbol = Convert.ToChar(i);
                Console.Write($"{currentSymbol} ");
            }
        }
    }
}
