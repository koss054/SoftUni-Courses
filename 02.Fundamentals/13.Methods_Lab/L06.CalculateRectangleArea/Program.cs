using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(RectangleArea(firstNumber, secondNumber));
        }

        static int RectangleArea(int sideWidth, int sideLength)
        {
            int rectangleArea = sideWidth * sideLength;

            return rectangleArea;
        }
    }
}
