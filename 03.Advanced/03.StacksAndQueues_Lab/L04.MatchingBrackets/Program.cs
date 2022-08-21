using System;
using System.Collections.Generic;

namespace L04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine();
            var expressionStack = new Stack<int>();

            for (int i = 0; i < userInput.Length; i++)
            {
                char ch = userInput[i];

                if (ch == '(')
                {
                    expressionStack.Push(i);
                }
                else if (ch == ')')
                {
                    int startIndex = expressionStack.Pop();
                    string contents = userInput.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(contents);
                }

            }
        }
    }
}
