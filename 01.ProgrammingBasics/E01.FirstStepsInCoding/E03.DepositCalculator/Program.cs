using System;

namespace E03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositDeadline = int.Parse(Console.ReadLine());
            double yearlyInterestRate = double.Parse(Console.ReadLine());

            double finalSum = depositSum + depositDeadline * ((depositSum * (yearlyInterestRate / 100)) / 12);

            Console.WriteLine(finalSum);
        }
    }
}
