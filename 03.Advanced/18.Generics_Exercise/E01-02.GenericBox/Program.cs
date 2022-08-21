using System;

namespace _01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            //var elements = new Box<string>();
            var elements = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                elements.AddElement(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(elements.ToString());
        }
    }
}
