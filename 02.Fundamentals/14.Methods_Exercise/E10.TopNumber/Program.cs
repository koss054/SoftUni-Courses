using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            TopNumber(int.Parse(Console.ReadLine()));
        }

        static void TopNumber(int a)
        {
            for (int i = 0; i <= a; i++)
            {
                bool isDivisible = false;
                bool hasOneOdd = false;
                int sumOfDigits = 0;
                string currentNumber = i.ToString();

                for (int j = 0; j < currentNumber.Length; j++)
                {
                    char currentDigitChar = currentNumber[j];
                    int currentDigitInt = (int)Char.GetNumericValue(currentDigitChar);

                    if (currentDigitInt % 2 != 0)
                    {
                        hasOneOdd = true;
                    }

                    sumOfDigits += currentDigitInt;
                }

                if (sumOfDigits % 8 == 0)
                {
                    isDivisible = true;
                }

                if (isDivisible && hasOneOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
