using System;
using System.Text;
using System.Collections.Generic;

namespace E09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalOperations = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            var stack = new Stack<string>();
            stack.Push(builder.ToString());

            for (int i = 0; i < totalOperations; i++)
            {
                var userInput = Console.ReadLine().Split();
                int command = int.Parse(userInput[0]);
                
                switch (command)
                {
                    case 1:
                        builder.Append(userInput[1]);
                        stack.Push(builder.ToString());
                        break;
                    case 2:
                        int countToDelete = int.Parse(userInput[1]);
                        builder.Remove(builder.Length - countToDelete, countToDelete);
                        stack.Push(builder.ToString());
                        break;
                    case 3:
                        int index = int.Parse(userInput[1]);
                        Console.WriteLine(builder[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        builder = new StringBuilder();
                        builder.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}
