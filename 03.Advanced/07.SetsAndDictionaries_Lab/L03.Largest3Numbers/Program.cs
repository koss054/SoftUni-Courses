using System;
using System.Linq;
using System.Collections.Generic;

namespace L03.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sorted = integers.OrderByDescending(n => n).ToArray();

            for (int i = 0; i < 3; i++)
            {
                if (i >= sorted.Length)
                {
                    break;
                }

                Console.Write($"{sorted[i]} ");
            }
        }
    }
}
