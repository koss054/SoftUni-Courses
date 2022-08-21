using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numberStack = new Stack<int>(userInput);
            var userCommand = Console.ReadLine().ToLower();
            var finalSum = 0;

            while (userCommand != "end")
            {
                var tokens = userCommand.Split();
                var currentCommand = tokens[0];

                switch (currentCommand)
                {
                    case "add":
                        var firstNum = int.Parse(tokens[1]);
                        var secondNum = int.Parse(tokens[2]);

                        numberStack.Push(firstNum);
                        numberStack.Push(secondNum);
                        break;
                    case "remove":
                        var enteredNum = int.Parse(tokens[1]);

                        if (enteredNum > numberStack.Count)
                        {
                            //Ignoring command.
                        }
                        else
                        {
                            for (int i = 0; i < enteredNum; i++)
                            {
                                numberStack.Pop();
                            }
                        }
                        break;
                }

                userCommand = Console.ReadLine().ToLower();
            }

            foreach (var number in numberStack)
            {
                finalSum += number;
            }

            Console.WriteLine($"Sum: {finalSum}");
        }
    }
}
