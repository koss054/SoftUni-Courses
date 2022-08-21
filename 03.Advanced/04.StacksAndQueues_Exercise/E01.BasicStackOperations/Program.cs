using System;
using System.Linq;
using System.Collections.Generic;

namespace E01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split();
            int numberOfPushes = int.Parse(firstInput[0]);
            int numberOfPops = int.Parse(firstInput[1]);
            int lookingFor = int.Parse(firstInput[2]);

            var numbersForStack = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var stackedNumbers = new Stack<int>();

            int lowestNum = int.MaxValue;
            bool isFound = false;

            for (int i = 0; i < numberOfPushes; i++)
            {
                stackedNumbers.Push(numbersForStack[i]);
            }
            for (int i = 0; i < numberOfPops; i++)
            {
                stackedNumbers.Pop();
            }
            
            if (stackedNumbers.Count == 0)
            {
                lowestNum = 0;
            }

            while (stackedNumbers.Count != 0)
            {
                int currentNumber = stackedNumbers.Pop();

                if (currentNumber < lowestNum)
                {
                    lowestNum = currentNumber;
                }

                if (currentNumber == lookingFor)
                {
                    isFound = true;
                    Console.WriteLine("true");
                    break;
                }               
            }

            if (!isFound)
            {     
                Console.WriteLine(lowestNum);
            }
        }
    }
}
