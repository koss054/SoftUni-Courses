using System;
using System.Linq;
using System.Collections.Generic;

namespace L01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<double, int>();
            var userInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < userInput.Length; i++)
            {
                if (dictionary.ContainsKey(userInput[i]))
                {
                    dictionary[userInput[i]]++;
                }
                else
                {
                    dictionary[userInput[i]] = 1;
                }
            }

            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
