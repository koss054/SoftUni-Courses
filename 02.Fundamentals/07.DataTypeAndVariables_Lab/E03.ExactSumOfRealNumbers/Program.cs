using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int totalNumbers = int.Parse(Console.ReadLine());
            decimal totalSum = 0;

            for (int i = 0; i < totalNumbers; i++)
            {
                decimal enteredNumber = decimal.Parse(Console.ReadLine());
                totalSum += enteredNumber;
            }

            Console.WriteLine($"{totalSum}");
        }
    }
}