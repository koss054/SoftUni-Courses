using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;

namespace P02._DrawingShape_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle();
            var rectangle = new Rectangle();

            List<IShape> shapes = new List<IShape>();
            shapes.Add(circle);
            shapes.Add(rectangle);

            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
