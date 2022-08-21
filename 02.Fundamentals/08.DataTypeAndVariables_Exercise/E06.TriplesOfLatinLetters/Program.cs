using System;

namespace _06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int enteredNumber = int.Parse(Console.ReadLine());

            for (char a = 'a'; a < 'a' + enteredNumber; a++)
            {
                for (char b = 'a'; b < 'a' + enteredNumber; b++)
                {
                    for (char c = 'a'; c < 'a' + enteredNumber; c++)
                    {
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
