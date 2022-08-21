using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string currentOperator = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(MathOperations(firstNumber, currentOperator, secondNumber));
        }

        static double MathOperations(double firstNumber, string currentOperator, double secondNumber)
        {
            double operationResult = 0.0;

            switch (currentOperator)
            {
                case "/":
                    operationResult = firstNumber / secondNumber;
                    break;
                case "*":
                    operationResult = firstNumber * secondNumber;
                    break;
                case "+":
                    operationResult = firstNumber + secondNumber;
                    break;
                case "-":
                    operationResult = firstNumber - secondNumber;
                    break;
            }

            return operationResult;
        }
    }
}
