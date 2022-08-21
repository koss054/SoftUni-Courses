using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();

            while (userInput != "END")
            {
                int enteredNumber = int.Parse(userInput);

                Palindrome(enteredNumber);

                userInput = Console.ReadLine();
            }
        }

        static void Palindrome(int a)
        {
            string currentNumber = a.ToString();
            string reversedNumber = string.Empty;

            for (int i = currentNumber.Length - 1; i >= 0; i--)
            {
                reversedNumber += currentNumber[i];
            }

            if (currentNumber == reversedNumber)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
