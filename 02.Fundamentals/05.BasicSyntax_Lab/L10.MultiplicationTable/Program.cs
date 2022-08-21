using System;

namespace fundamentalsLesson5
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int sum = enteredNum * i;
                Console.WriteLine($"{enteredNum} X {i} = {sum}");
            }
        }
    }
}