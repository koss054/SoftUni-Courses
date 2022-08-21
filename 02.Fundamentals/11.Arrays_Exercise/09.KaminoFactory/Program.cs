using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            string userInput = Console.ReadLine();

            int[] arrayDNA = new int[sequenceLength];
            int sumDNA = 0;
            int countDNA = -1;
            int indexStartDNA = -1;
            int samplesDNA = 0;
            int sample = 0;

            while (userInput != "Clone them!")
            {
                sample++;

                int[] currentDNA = userInput
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentCount = 0;
                int currentStartIndex = 0;
                int currentEndIndex = 0;
                int currentDNASum = 0;
                int count = 0;
                bool isCurrentDNABetter = false;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;

                    if (count > currentCount)
                    {
                        currentCount = count;
                        currentEndIndex = i;
                    }
                }

                currentStartIndex = currentEndIndex - currentCount + 1;
                currentDNASum = currentDNA.Sum();

                if (currentCount > countDNA)
                {
                    isCurrentDNABetter = true;
                }
                else if (currentCount == countDNA)
                {
                    if (currentStartIndex < indexStartDNA)
                    {
                        isCurrentDNABetter = true;
                    }
                    else if (currentStartIndex == indexStartDNA)
                    {
                        if (currentDNASum > sumDNA)
                        {
                            isCurrentDNABetter = true;
                        }
                    }
                }

                if (isCurrentDNABetter)
                {
                    arrayDNA = currentDNA;
                    countDNA = currentCount;
                    indexStartDNA = currentStartIndex;
                    sumDNA = currentDNASum;
                    samplesDNA = sample;
                }

                userInput = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {samplesDNA} with sum: {sumDNA}.");
            Console.WriteLine(string.Join(" ", arrayDNA));
        }
    }
}
