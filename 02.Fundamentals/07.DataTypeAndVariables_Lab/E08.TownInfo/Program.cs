using System;
using System.Numerics;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            BigInteger townPopulation = BigInteger.Parse(Console.ReadLine());
            int townArea = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {townPopulation} and area {townArea} square km.");
        }
    }
}