using System;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //var elements = new Box<string>();
            var elements = new Box<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                elements.AddElement(double.Parse(Console.ReadLine()));
            }

            //string compareElement = Console.ReadLine();
            double compareElement = double.Parse(Console.ReadLine());

            Console.WriteLine(elements.Count(compareElement));
        }
    }
}
