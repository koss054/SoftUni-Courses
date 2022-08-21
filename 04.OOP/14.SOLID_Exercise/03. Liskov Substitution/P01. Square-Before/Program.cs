using System;
using System.Collections.Generic;

namespace P01._Square_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(20);
            var rectangle = new Rectangle(10, 5);
            var triangle = new Triangle(10, 20);

            List<Shape> shapes = new List<Shape>();
            shapes.Add(square);
            shapes.Add(rectangle);
            shapes.Add(triangle);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Area);
            }
        }
    }
}
