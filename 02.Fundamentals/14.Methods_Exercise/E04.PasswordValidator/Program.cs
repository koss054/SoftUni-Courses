using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordValidator(Console.ReadLine());
        }

        static void PasswordValidator(string pass)
        {
            if (PasswordLength(pass) && PasswordSymbols(pass) && PasswordDigits(pass))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!PasswordLength(pass))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }

                if (!PasswordSymbols(pass))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }

                if (!PasswordDigits(pass))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        static bool PasswordLength(string pass)
        {
            bool isCorrectLength = false;

            if (pass.Length >= 6 && pass.Length <= 10)
            {
                isCorrectLength = true;
            }

            return isCorrectLength;
        }

        static bool PasswordSymbols(string pass)
        {
            bool isWithAllowedSymbols = true;

            for (int i = 0; i < pass.Length; i++)
            {
                int currentSymbolASCIIValue = Convert.ToInt32(pass[i]);

                if (!((currentSymbolASCIIValue >= 65 && currentSymbolASCIIValue <= 90)
                    || (currentSymbolASCIIValue >= 97 && currentSymbolASCIIValue <= 122)
                    || (currentSymbolASCIIValue >= 48 && currentSymbolASCIIValue <= 57)))
                {
                    isWithAllowedSymbols = false;
                }
            }

            return isWithAllowedSymbols;
        }

        static bool PasswordDigits(string pass)
        {
            bool hasTwoOrMoreDigits = true;

            int digitCount = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                int currentSymbolASCIIValue = Convert.ToInt32(pass[i]);

                if (currentSymbolASCIIValue >= 48 && currentSymbolASCIIValue <= 57)
                {
                    digitCount++;
                }
            }

            if (digitCount < 2)
            {
                hasTwoOrMoreDigits = false;
            }

            return hasTwoOrMoreDigits;
        }
    }
}
