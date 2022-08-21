using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            decimal moneyPounds = decimal.Parse(Console.ReadLine());

            decimal moneyDollars = moneyPounds * (decimal) 1.31;

            Console.WriteLine($"{moneyDollars:F3}");
        }
    }
}