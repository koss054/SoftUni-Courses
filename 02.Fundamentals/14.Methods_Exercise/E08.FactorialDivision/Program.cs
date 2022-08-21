using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            decimal finalSum = GetFactorialFirstNumber(firstNumber) / GetFactorialSecondNumber(secondNumber);

            Console.WriteLine($"{finalSum:F2}");
        }

        private static decimal GetFactorialFirstNumber(decimal a)
        {
            if (a == 0)
            {
                return 1;
            }

            return a * GetFactorialFirstNumber(a - 1);
        }

        private static decimal GetFactorialSecondNumber(decimal a)
        {
            if (a == 0)
            {
                return 1;
            }

            return a * GetFactorialSecondNumber(a - 1);
        }
    }
}
