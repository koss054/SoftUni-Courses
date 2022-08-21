using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int enteredNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            string numberInString = enteredNumber.ToString();

            for (int i = 0; i < numberInString.Length; i++)
            {
                char currentDigit = Convert.ToChar(numberInString[i]);
                int digit = (int)Char.GetNumericValue(currentDigit);

                sum += digit;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
