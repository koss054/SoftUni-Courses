using System;
using System.Linq;
using System.Collections.Generic;

namespace E05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<char, int>();
            string enteredText = Console.ReadLine();

            foreach (char character in enteredText)
            {
                if (dictionary.ContainsKey(character))
                {
                    dictionary[character]++;
                }
                else
                {
                    dictionary[character] = 1;
                }
            }

            var sortedDictionary = dictionary.OrderBy(ch => ch.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var character in sortedDictionary)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
