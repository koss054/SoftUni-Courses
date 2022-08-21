using System;
using System.Linq;
using System.Collections.Generic;

namespace E08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var symbol in userInput)
            {
                if (stack.Any())
                {
                    char check = stack.Peek();

                    if (check == '{' && symbol == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '(' && symbol == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(symbol);
            }

            Console.WriteLine(!stack.Any() ? "YES" : "NO");
        }
    }
}
