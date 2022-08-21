using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] userArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool hasEnded = false;

            while (!hasEnded)
            {
                string userInput = Console.ReadLine();
                string chosenAction = string.Empty;

                for (int i = 0; i < 3; i++)
                {
                    char currentLetter = userInput[i];
                    chosenAction += currentLetter;
                }

                switch (chosenAction)
                {
                    case "exc":
                        ArrayExchange(userArray, userInput);
                        break;
                    case "max":
                        MaxEvenOdd(userArray, userInput);
                        break;
                    case "min":
                        MinEvenOdd(userArray, userInput);
                        break;
                    case "fir":
                        FirstEvenOdd(userArray, userInput);
                        break;
                    case "las":
                        LastEvenOdd(userArray, userInput);
                        break;
                    case "end":
                        hasEnded = true;
                        End(userArray);
                        break;
                    default:
                        break;
                }
            }
        }

        static void ArrayExchange(int[] array, string exchangeIndex)
        {
            string exchangeIndexString = string.Empty;

            for (int i = 0; i < exchangeIndex.Length; i++)
            {
                char currentSymbol = exchangeIndex[i];
                bool isNumeric = Char.IsDigit(currentSymbol);

                if (isNumeric)
                {
                    exchangeIndexString += exchangeIndex[i];
                }
            }

            int exchangeIndexInt = int.Parse(exchangeIndexString);

            if (exchangeIndexInt < array.Length)
            {
                for (int i = 0; i < exchangeIndexInt + 1; i++)
                {
                    int temp = array[0];

                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }

                    array[array.Length - 1] = temp;
                }
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        static void MaxEvenOdd(int[] array, string userInput)
        {
            int maxIndex = - 1;
            int maxNumber = int.MinValue;

            if (userInput == "max even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= maxNumber)
                    {
                        maxIndex = i;
                        maxNumber = array[i];
                    }
                }
            }
            else if (userInput == "max odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] >= maxNumber)
                    {
                        maxIndex = i;
                        maxNumber = array[i];
                    }
                }
            }

            if (maxIndex != -1)
            {
                Console.WriteLine($"{maxIndex}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void MinEvenOdd(int[] array, string userInput)
        {
            int minIndex = -1;
            int minNumber = int.MaxValue;

            if (userInput == "min even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= minNumber)
                    {
                        minIndex = i;
                        minNumber = array[i];
                    }
                }
            }
            else if (userInput == "min odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] <= minNumber)
                    {
                        minIndex = i;
                        minNumber = array[i];
                    }
                }
            }

            if (minIndex != -1)
            {
                Console.WriteLine($"{minIndex}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void FirstEvenOdd(int[] array, string userInput)
        {
            string count = string.Empty;

            for (int i = 0; i < userInput.Length; i++)
            {
                char currentSymbol = userInput[i];
                bool isNumeric = Char.IsDigit(currentSymbol);

                if (isNumeric)
                {
                    count += userInput[i];
                }
            }

            int countInt = int.Parse(count);

            string chosenAction = string.Empty;

            for (int i = userInput.Length - 4; i < userInput.Length; i++)
            {
                char currentLetter = userInput[i];
                chosenAction += currentLetter;
            }

            if (countInt > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int totalNumbers = 0;

                if (chosenAction == "even")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            totalNumbers++;
                        }
                    }

                    Console.Write("[");

                    if (totalNumbers > 1)
                    {                       
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0 && i < array.Length - 1 && totalNumbers != 1 && countInt > 1)
                            {
                                Console.Write($"{array[i]}, ");
                                countInt--;
                                totalNumbers--;
                            }
                            else if (array[i] % 2 == 0 && i < array.Length && countInt > 0)
                            {
                                Console.Write($"{array[i]}");
                                countInt--;
                            }
                        }
                    }
                    else if (totalNumbers == 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0)
                            {
                                Console.Write($"{array[i]}");
                            }
                        }
                    }
                    else
                    {
                        //No even numbers.
                    }

                    Console.Write("]");
                    Console.WriteLine();
                }
                else if (chosenAction == " odd")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0)
                        {
                            totalNumbers++;
                        }
                    }

                    Console.Write("[");

                    if (totalNumbers > 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 != 0 && i < array.Length - 1 && totalNumbers != 1 && countInt > 1)
                            {
                                Console.Write($"{array[i]}, ");
                                countInt--;
                                totalNumbers--;
                            }
                            else if (array[i] % 2 != 0 && i < array.Length && countInt > 0)
                            {
                                Console.Write($"{array[i]}");
                                countInt--;
                            }
                        }
                    }
                    else if (totalNumbers == 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 != 0)
                            {
                                Console.Write($"{array[i]}");
                            }
                        }
                    }
                    else
                    {
                        //No odd numbers.
                    }

                    Console.Write("]");
                    Console.WriteLine();
                }
            }
        }

        static void LastEvenOdd(int[] array, string userInput)
        {
            string count = string.Empty;

            for (int i = 0; i < userInput.Length; i++)
            {
                char currentSymbol = userInput[i];
                bool isNumeric = Char.IsDigit(currentSymbol);

                if (isNumeric)
                {
                    count += userInput[i];
                }
            }

            int countInt = int.Parse(count);

            string chosenAction = string.Empty;

            for (int i = userInput.Length - 4; i < userInput.Length; i++)
            {
                char currentLetter = userInput[i];
                chosenAction += currentLetter;
            }

            if (countInt > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int totalNumbers = 0;

                if (chosenAction == "even")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            totalNumbers++;
                        }
                    }

                    countInt -= totalNumbers;

                    Console.Write("[");

                    if (totalNumbers > 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0 && countInt > 0)
                            {
                                countInt--;
                                totalNumbers--;
                            }
                            else if (array[i] % 2 == 0 && i < array.Length - 1 && totalNumbers != 1 && countInt == 0)
                            {
                                Console.Write($"{array[i]}, ");
                                totalNumbers--;
                            }
                            else if (array[i] % 2 == 0 && i < array.Length && countInt == 0)
                            {
                                Console.Write($"{array[i]}");
                            }
                        }
                    }
                    else if (totalNumbers == 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 == 0)
                            {
                                Console.Write($"{array[i]}");
                            }
                        }
                    }
                    else
                    {
                        //No odd numbers.
                    }

                    Console.Write("]");
                    Console.WriteLine();
                }
                else if (chosenAction == " odd")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0)
                        {
                            totalNumbers++;
                        }
                    }

                    countInt = totalNumbers - countInt;

                    Console.Write("[");

                    if (totalNumbers > 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 != 0 && countInt > 0)
                            {
                                countInt--;
                                totalNumbers--;
                            }
                            else if (array[i] % 2 != 0 && i < array.Length - 1 && totalNumbers != 1 && countInt == 0)
                            {
                                Console.Write($"{array[i]}, ");
                                totalNumbers--;
                            }
                            else if (array[i] % 2 != 0 && i < array.Length && countInt == 0)
                            {
                                Console.Write($"{array[i]}");
                            }
                        }
                    }
                    else if (totalNumbers == 1)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] % 2 != 0)
                            {
                                Console.Write($"{array[i]}");
                            }
                        }
                    }
                    else
                    {
                        //No odd numbers.
                    }

                    Console.Write("]");
                    Console.WriteLine();
                }
            }
        }
        //Final method.
        static void End(int[] array)
        {
            Console.Write("[");

            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                {
                    Console.Write($"{array[i]}, ");
                }
                else
                {
                    Console.Write($"{array[i]}");
                }
            }

            Console.Write("]");
        }

    }
}
