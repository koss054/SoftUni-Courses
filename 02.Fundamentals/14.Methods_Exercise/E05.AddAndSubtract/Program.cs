using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int finalSum = SumOfTwoNumbers(firstNumber, secondNumber) - ThirdNumber(thirdNumber);

            Console.WriteLine(finalSum);
        }

        static int SumOfTwoNumbers(int a, int b)
        {
            return a + b;
        }

        static int ThirdNumber(int a)
        {
            return a;
        }
    }
}
