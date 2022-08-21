using System;

namespace fundamentalsLesson5
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());
            int enteredMultiplier = int.Parse(Console.ReadLine());
            int sum;

            if (enteredMultiplier > 10)
            {
                sum = enteredNum * enteredMultiplier;
                Console.WriteLine($"{enteredNum} X {enteredMultiplier} = {sum}");
            }

            for (int i = enteredMultiplier; i <= 10; i++)
            {
                sum = enteredNum * i;
                Console.WriteLine($"{enteredNum} X {i} = {sum}");
            }
        }
    }
}