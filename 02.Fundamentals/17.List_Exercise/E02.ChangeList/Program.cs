using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] userInput = Console.ReadLine()
                .Split()
                .ToArray();

            while (userInput[0] != "end")
            {
                int currentElement = int.Parse(userInput[1]);


                switch(userInput[0])
                {
                    case "Delete": 
                        numbers.RemoveAll(x => x == currentElement); 
                        break;
                    case "Insert":
                        int currentPosition = int.Parse(userInput[2]);
                        numbers.Insert(currentPosition, currentElement); 
                        break;
                }

                userInput = Console.ReadLine()
                    .Split()
                    .ToArray();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> DeleteNumberFromList(string[] deletedNumber, List<int> currentList)
        {
            List<int> tempList = new List<int>();
            int numberToBeDeleted = int.Parse(deletedNumber[1]);
            
            for (int i = 0; i < currentList.Count; i++)
            {
                tempList.Add(currentList[i]);
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i] == numberToBeDeleted)
                {
                    tempList.RemoveAt(i);
                    i = -1;
                }
            }

            return tempList;
        }

        static List<int> InsertNumberAtIndexToList(string[] numberAndIndex, List<int> currentList)
        {
            List<int> tempList = new List<int>();
            int numberToBeAdded = int.Parse(numberAndIndex[1]);
            int indexOfAddedNumber = int.Parse(numberAndIndex[2]);

            for (int i = 0; i < currentList.Count; i++)
            {
                if (i == indexOfAddedNumber)
                {
                    tempList.Add(numberToBeAdded);
                }

                tempList.Add(currentList[i]);
            }

            return tempList;
        }
    }
}
