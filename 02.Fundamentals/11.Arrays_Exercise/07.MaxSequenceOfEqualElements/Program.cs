using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int longestSequence = 1;
            int longestSequenceNum = 0;
            int currentSequence = 1;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i > 0)
                {
                    int previousNumber = inputArray[i - 1];


                    if (previousNumber == inputArray[i])
                    {
                        currentSequence++;

                        if (currentSequence > longestSequence)
                        {
                            longestSequence = currentSequence;
                            longestSequenceNum = inputArray[i];
                        }
                    }

                    if (previousNumber != inputArray[i])
                    {
                        currentSequence = 1;
                    }
                }
            }

            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write($"{longestSequenceNum} ");
            }
        }
    }
}
