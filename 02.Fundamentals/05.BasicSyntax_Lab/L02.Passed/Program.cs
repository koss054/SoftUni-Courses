using System;

namespace fundamentalsLesson5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double enteredGrade = double.Parse(Console.ReadLine());

            if (enteredGrade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}