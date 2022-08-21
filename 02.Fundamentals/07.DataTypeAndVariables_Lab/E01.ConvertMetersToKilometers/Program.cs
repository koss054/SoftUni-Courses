using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            decimal distanceMeters = decimal.Parse(Console.ReadLine());
            decimal distanceKilometers = distanceMeters / 1000;

            Console.WriteLine($"{distanceKilometers:F2}");
        }
    }
}   