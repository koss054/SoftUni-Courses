using System;
using System.Linq;

namespace E02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> makeKnight = text => Console.WriteLine($"Sir {text}");
            string[] names = Console.ReadLine().Split();

            foreach (string name in names)
            {
                makeKnight(name);
            }
        }
    }
}
