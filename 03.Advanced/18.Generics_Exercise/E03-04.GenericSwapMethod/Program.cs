using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            //var elements = new Box<string>();
            var elements = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                elements.AddElement(int.Parse(Console.ReadLine()));
            }

            int[] swapIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            elements.Swap(swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(elements.ToString());
        }
    }
}
