using System;
using System.Linq;
using System.Collections.Generic;

namespace L05.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
            var totalCountries = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalCountries; i++)
            {
                var userInput = Console.ReadLine().Split();
                string continent = userInput[0];
                string country = userInput[1];
                string city = userInput[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent][country] = new List<string>();
                }

                dictionary[continent][country].Add(city);
            }

            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");

                    for (int i = 0; i < country.Value.Count; i++)
                    {
                        if (i == country.Value.Count - 1)
                        {
                            Console.WriteLine($"{country.Value[i]}");
                        }
                        else
                        {
                            Console.Write($"{country.Value[i]}, ");
                        }
                    }
                }
            }
        }
    }
}
