using System;
using System.Linq;

namespace E07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> isLessOrEqual = name
                => name.Length <= n;

            Action<string[]> printMatchingNames = names
                =>
            {
                foreach (string name in names)
                {
                    if(isLessOrEqual(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            printMatchingNames(names);
        }
    }
}
