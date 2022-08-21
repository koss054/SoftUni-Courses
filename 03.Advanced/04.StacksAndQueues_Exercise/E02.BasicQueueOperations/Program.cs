using System;
using System.Linq;
using System.Collections.Generic;

namespace E02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split();
            int numbersToAdd = int.Parse(firstInput[0]);
            int numbersToRemove = int.Parse(firstInput[1]);
            int lookingFor = int.Parse(firstInput[2]);

            var enteredNumbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var queueOfNumbers = new Queue<int>();

            int lowestNum = int.MaxValue;
            bool isFound = false;

            for (int i = 0; i < numbersToAdd; i++)
            {
                queueOfNumbers.Enqueue(enteredNumbers[i]);
            }

            for (int i = 0; i < numbersToRemove; i++)
            {
                queueOfNumbers.Dequeue();
            }

            if (queueOfNumbers.Count == 0)
            {
                lowestNum = 0;
            }
            else
            {
                while (queueOfNumbers.Count != 0)
                {
                    int currentNumber = queueOfNumbers.Dequeue();

                    if (currentNumber == lookingFor)
                    {
                        isFound = true;
                        Console.WriteLine("true");
                        return;
                    }

                    if (currentNumber < lowestNum)
                    {
                        lowestNum = currentNumber;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine(lowestNum);
            }
        }
    }
}
