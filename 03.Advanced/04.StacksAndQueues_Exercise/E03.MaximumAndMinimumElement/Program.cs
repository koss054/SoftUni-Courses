using System;
using System.Collections.Generic;

namespace E03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            var numberStack = new Stack<int>();

            int lowestNumber = int.MaxValue;
            int highestNumber = int.MinValue;

            for (int i = 0; i < numberOfQueries; i++)
            {
                var userInput = Console.ReadLine().Split();

                switch (userInput[0])
                {
                    case "1":
                        int numberToPush = int.Parse(userInput[1]);
                        numberStack.Push(numberToPush);
                        break;
                    case "2":
                        if (numberStack.Count > 0)
                        {
                            numberStack.Pop();
                        }
                        break;
                    case "3":
                        if (numberStack.Count != 0)
                        {
                            var tempStack = new Stack<int>(numberStack);

                            while (tempStack.Count != 0)
                            {
                                int currentNumber = tempStack.Pop();

                                if (currentNumber > highestNumber)
                                {
                                    highestNumber = currentNumber;
                                }
                            }

                            Console.WriteLine(highestNumber);
                        }
                        break;
                    case "4":
                        if (numberStack.Count != 0)
                        {
                            var tempStack = new Stack<int>(numberStack);

                            while (tempStack.Count != 0)
                            {
                                int currentNumber = tempStack.Pop();

                                if (currentNumber < lowestNumber)
                                {
                                    lowestNumber = currentNumber;
                                }
                            }

                            Console.WriteLine(lowestNumber);
                        }
                        break;
                }
            }

            while (numberStack.Count != 0)
            {
                if (numberStack.Count > 1)
                {
                    Console.Write($"{numberStack.Pop()}, ");
                }
                else
                {
                    Console.WriteLine($"{numberStack.Pop()}");
                }
            }
        }
    }
}
