using System;
using System.Collections.Generic;

namespace L06.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            var totalNames = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalNames; i++)
            {
                var currentName = Console.ReadLine();
                set.Add(currentName);
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
