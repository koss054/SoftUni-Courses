using System;

namespace fundamentalsLesson6_2
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                int userInput = int.Parse(Console.ReadLine());
                numbers[i] = userInput;
            }

            Array.Sort(numbers);
            Array.Reverse(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}