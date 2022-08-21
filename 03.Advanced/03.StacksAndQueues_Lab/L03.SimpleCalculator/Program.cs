using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expressionInput = Console.ReadLine().Split();
            Stack<string> expression = new Stack<string>(expressionInput);
            Stack<string> reversedExpression = new Stack<string>();

            string currentExpression = "+";
            int finalSum = 0;
            
            while (expression.Count != 0)
            {
                reversedExpression.Push(expression.Pop());
            }

            while (reversedExpression.Count != 0)
            {
                string currentElement = reversedExpression.Pop();

                switch (currentElement)
                {
                    case "+":
                        currentExpression = "+";
                        break;
                    case "-":
                        currentExpression = "-";
                        break;
                    default:
                        int currentNumber = int.Parse(currentElement);

                        if (currentExpression == "+")
                        {
                            finalSum += currentNumber;
                        }
                        else if (currentExpression == "-")
                        {
                            finalSum -= currentNumber;
                        }

                        break;
                }
            }
            
            Console.WriteLine(finalSum);
        }
    }
}
