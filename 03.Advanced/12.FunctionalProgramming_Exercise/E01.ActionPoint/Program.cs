using System;
using System.Linq;

namespace E01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printText = text => Console.WriteLine(text);
            string[] names = Console.ReadLine().Split();

            foreach (string name in names)
            {
                printText(name);
            }
        }
    }
}
