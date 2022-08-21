using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            /*
            double dul, sh, V = 0;
            Console.WriteLine("Length: ");
            dul = double.Parse(Console.ReadLine());
            Console.WriteLine("Width: ");
            sh = double.Parse(Console.ReadLine());
            Console.WriteLine("Heigth: ");
            V = double.Parse(Console.ReadLine());
            V = (dul + sh + V) / 3;
            Console.WriteLine($"Pyramid Volume: {V:f2}");
            */

            Console.Write("Length: ");
            double pyramidLength = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            double pyramidWidth = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double pyramidHeight = double.Parse(Console.ReadLine());

            double pyramidVolume = (pyramidLength * pyramidWidth * pyramidHeight) / 3;

            Console.WriteLine($"Pyramid Volume: {pyramidVolume:F2}");
        }
    }
}