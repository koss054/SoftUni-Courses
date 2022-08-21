using System;
using System.Linq;
using System.Collections.Generic;

namespace E09.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            

            while (true)
            {
                string[] userInput = Console.ReadLine().Split();

                if (userInput[0] == "Party!")
                {
                    if (names.Count == 0)
                    {
                        Console.Write("Nobody is going to the party!");
                    }
                    else
                    {
                        Console.Write(string.Join(", ", names));
                        Console.Write(" are going to the party!");
                    }

                    return;
                }

                string command = userInput[0];
                string criteria = userInput[1];
                string symbol = userInput[2];

                if (command == "Double")
                {
                    List<string> doubleNames = names.FindAll(GetPredicate(criteria, symbol));
                    int index = names.FindIndex(GetPredicate(criteria, symbol));

                    if (index >= 0)
                    {
                        names.InsertRange(index, doubleNames);
                    }
                }
                else if (command == "Remove")
                {
                    names.RemoveAll(GetPredicate(criteria, symbol));
                }
            }
        }

        private static Predicate<string> GetPredicate(string criteria, string symbol)
        {
            switch (criteria)
            {
                case "StartsWith": return x => x.StartsWith(symbol);
                case "EndsWith": return x => x.EndsWith(symbol);
                case "Length": return x => x.Length == int.Parse(symbol);
                default: return null;
            }
        }
    }
}
