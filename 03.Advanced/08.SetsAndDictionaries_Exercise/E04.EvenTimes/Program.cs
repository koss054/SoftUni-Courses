using System;
using System.Collections.Generic;

namespace E04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < numCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                
                if (dictionary.ContainsKey(currentNumber))
                {
                    dictionary[currentNumber]++;
                }
                else
                {
                    dictionary[currentNumber] = 1;
                }
            }

            foreach (var number in dictionary)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    return;
                }
            }
        }
    }
}
