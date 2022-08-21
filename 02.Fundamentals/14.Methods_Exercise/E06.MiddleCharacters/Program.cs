using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            MiddleCharacters(Console.ReadLine());
        }

        static void MiddleCharacters(string a)
        {
            decimal middleCharPosition = a.Length / 2;
            middleCharPosition = Math.Round(middleCharPosition);

            if (a.Length % 2 == 0)
            {
                Console.Write($"{a[(int)middleCharPosition - 1]}");
                Console.Write($"{a[(int)middleCharPosition]}");
            }
            else
            {
                Console.Write($"{a[(int)middleCharPosition]}");
            }
        }
    }
}
