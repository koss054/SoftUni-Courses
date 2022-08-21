using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());

            if (enteredNum % 10 == 0)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (enteredNum % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if (enteredNum % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (enteredNum % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (enteredNum % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}