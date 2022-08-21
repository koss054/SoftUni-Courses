using System;
using System.Collections.Generic;

namespace L02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    string currentInput = Console.ReadLine();

                    int n;
                    bool isNumeric = int.TryParse(currentInput.ToString(), out n);

                    if (!isNumeric)
                    {
                        i--;
                        throw new FormatException();
                    }

                    int currentNumber = int.Parse(currentInput);

                    if (currentNumber <= start || currentNumber >= end)
                    {
                        i--;
                        throw new ArgumentOutOfRangeException();
                    }

                    start = currentNumber;
                    numbers.Add(currentNumber);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - {end}!");
                }
            }

            if (numbers.Count != 0)
            {
                Console.WriteLine(string.Join(", ", numbers));
            }
        }
    }
}
