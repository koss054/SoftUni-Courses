using System;
using System.Linq;

namespace E03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var customStack = new Stack<int>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] currentCommand = input
                    .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (currentCommand[0] == "Push")
                {
                    int[] numbersToPush = currentCommand
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    customStack.Push(numbersToPush);
                }
                else if (currentCommand[0] == "Pop")
                {
                    customStack.Pop();
                }

                input = Console.ReadLine();
            }

            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
