using System;

namespace E07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectFigureType = Console.ReadLine();

            if (selectFigureType == "square")
            {
                double squareA = double.Parse(Console.ReadLine());
                double squareArea = squareA * squareA;

                Console.WriteLine($"{squareArea:F3}");
            }
            else if (selectFigureType == "rectangle")
            {
                double rectangleA = double.Parse(Console.ReadLine());
                double rectangleB = double.Parse(Console.ReadLine());
                double rectangleArea = rectangleA * rectangleB;

                Console.WriteLine($"{rectangleArea:F3}");
            }
            else if (selectFigureType == "circle")
            {
                double circleA = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * (circleA * circleA);

                Console.WriteLine($"{circleArea:F3}");
            }
            else if (selectFigureType == "triangle")
            {
                double triangleA = double.Parse(Console.ReadLine());
                double triangleB = double.Parse(Console.ReadLine());
                double triangleArea = (triangleA * triangleB) / 2;

                Console.WriteLine($"{triangleArea:F3}");
            }
        }
    }
}
