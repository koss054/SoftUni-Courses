using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string chosenCalculation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int finalSum = 0;

            userChoice(chosenCalculation, firstNumber, secondNumber, finalSum);
        }

        static void userChoice(string chosenCalculation, int firstNumber, int secondNumber, int finalSum)
        {
            switch (chosenCalculation)
            {
                case "add":
                    addCalculation(firstNumber, secondNumber, finalSum = firstNumber + secondNumber);
                    break;
                case "multiply":
                    multiplyCalculation(firstNumber, secondNumber, finalSum = firstNumber * secondNumber);
                    break;
                case "subtract":
                    subtractCalculation(firstNumber, secondNumber, finalSum = firstNumber - secondNumber);
                    break;
                case "divide":
                    divideCalculation(firstNumber, secondNumber, finalSum = firstNumber / secondNumber);
                    break;
                default:
                    break;
            }

            Console.WriteLine(finalSum);
        }

        static void addCalculation(int firstNumber, int secondNumber, int finalSum)
        {
;
        }

        static void multiplyCalculation(int firstNumber, int secondNumber, int finalSum)
        {

        }

        static void subtractCalculation(int firstNumber, int secondNumber, int finalSum)
        {

        }

        static void divideCalculation(int firstNumber, int secondNumber, int finalSum)
        {

        }
    }
}
