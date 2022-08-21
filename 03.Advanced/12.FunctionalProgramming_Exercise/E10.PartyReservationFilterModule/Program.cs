using System;
using System.Linq;
using System.Collections.Generic;

namespace E10.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string action = Console.ReadLine();

            Dictionary<string, Predicate<string>> allFilters
                = new Dictionary<string, Predicate<string>>();

            while (action != "Print")
            {
                string[] items = action.Split(';');

                string method = items[0];
                string operation = items[1];
                string value = items[2];

                if (method == "Add filter")
                {
                    allFilters.Add(
                        operation + value,
                        GetPredicate(operation, value));
                }
                else if (method == "Remove filter")
                {
                    allFilters.Remove(operation + value);
                }

                action = Console.ReadLine();
            }

            foreach (var filter in allFilters)
            {
                names.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", names));
        }

        private static Predicate<string> GetPredicate(
            string criteria,
            string symbol)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(symbol);
            }

            if (criteria == "Ends with")
            {
                return x => x.EndsWith(symbol);
            }

            if (criteria == "Contains")
            {
                return x => x.Contains(symbol);
            }

            int symbolAsInt = int.Parse(symbol);

            return x => x.Length == symbolAsInt;
        }
    }
}
