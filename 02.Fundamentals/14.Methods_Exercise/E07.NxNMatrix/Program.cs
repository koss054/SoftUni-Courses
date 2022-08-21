using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix(int.Parse(Console.ReadLine()));
        }

        static void Matrix(int a)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write($"{a} ");
                }

                Console.WriteLine();
            }
        }
    }
}
