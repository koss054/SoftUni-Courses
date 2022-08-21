using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] enteredArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isCondensed = false;
            int enteredArrayLength = enteredArray.Length;

            while (!isCondensed)
            {
                if (enteredArrayLength == 1)
                {
                    Console.WriteLine(enteredArray[0]);
                    isCondensed = true;
                }
                else
                {
                    int[] condensedArray = new int[enteredArray.Length];

                    for (int i = 0; i < enteredArrayLength - 1; i++)
                    {
                        condensedArray[i] = enteredArray[i] + enteredArray[i + 1];
                    }

                    for (int i = 0; i < enteredArrayLength - 1; i++)
                    {
                        enteredArray[i] = condensedArray[i];
                    }

                    enteredArrayLength--;
                }
            }

        }
    }
}
