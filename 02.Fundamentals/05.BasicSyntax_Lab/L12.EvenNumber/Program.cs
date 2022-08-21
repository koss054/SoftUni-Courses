using System;

namespace fundamentalsLesson5
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());
            bool isEven = false;

            while (!isEven)
            {
                if (!(enteredNum % 2 == 0))
                {
                    Console.WriteLine("Please write an even number.");
                    enteredNum = int.Parse(Console.ReadLine());
                }
                else
                {
                    isEven = true;
                    Console.WriteLine($"The number is: {Math.Abs(enteredNum)}");
                }
            }
        }
    }
}