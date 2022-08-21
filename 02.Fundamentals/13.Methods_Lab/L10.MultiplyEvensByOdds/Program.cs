using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMultipleOfEvenAndOdds(Console.ReadLine());
        }

        static void GetMultipleOfEvenAndOdds(string enteredNumber)
        {
            int currentNumber = int.Parse(enteredNumber);

            if (currentNumber < 0)
            {
                currentNumber = Math.Abs(currentNumber);
                enteredNumber = currentNumber.ToString();
            }

            int[] evenNumbers = new int[enteredNumber.Length];
            int[] oddNumbers = new int[enteredNumber.Length];

            int evenCounter = 0;
            int oddCounter = 0;

            for (int i = 0; i < enteredNumber.Length; i++)
            {
                int currentDigit = (int)Char.GetNumericValue(enteredNumber[i]);

                if (currentDigit % 2 == 0)
                {
                    evenNumbers[evenCounter] = currentDigit;
                    evenCounter++;
                }
                else
                {
                    oddNumbers[oddCounter] = currentDigit;
                    oddCounter++;
                }
            }

            int finalSum = GetSumOfEvenDigits(evenNumbers) * GetSumOfOddDigits(oddNumbers);

            Console.WriteLine(finalSum);
        }

        static int GetSumOfEvenDigits(int[] evenDigits)
        {
            int evenSum = 0;

            for (int i = 0; i < evenDigits.Length; i++)
            {
                evenSum += evenDigits[i];
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int[] oddDigits)
        {
            int oddSum = 0;

            for (int i = 0; i < oddDigits.Length; i++)
            {
                oddSum += oddDigits[i];
            }

            return oddSum;
        }
    }
}
