using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMax();
        }

        static void GetMax()
        {
            string chosenValueType = Console.ReadLine();

            switch (chosenValueType)
            {
                case "int":

                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine(IntegerValue(firstNumber, secondNumber));

                    break;

                case "char":

                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());

                    Console.WriteLine(CharValue(firstChar, secondChar));

                    break;

                case "string":

                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();

                    Console.WriteLine(StringValue(firstString, secondString));

                    break;
            }
        }

        static int IntegerValue(int firstInteger, int secondInteger)
        {
            if (firstInteger > secondInteger)
            {
                return firstInteger;
            }
            else
            {
                return secondInteger;
            }
        }

        static char CharValue(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
            else
            {
                return secondChar;
            }
        }

        static string StringValue(string firstString, string secondString)
        {
            int comparedStrings = string.Compare(firstString, secondString);

            if (comparedStrings > 0)
            {
                return firstString;
            }
            else
            {
                return secondString;
            }
        }
    }
}
