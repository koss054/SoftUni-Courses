using System;

namespace E02.RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radian = double.Parse(Console.ReadLine());
            double degree = radian * (180 / Math.PI);

            Console.WriteLine(degree);
        }
    }
}
