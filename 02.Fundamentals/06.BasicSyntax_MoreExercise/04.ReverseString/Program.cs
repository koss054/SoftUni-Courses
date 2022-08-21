using System;

namespace fundamentalsLesson6_2
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            string enteredString = Console.ReadLine();

            for (int i = enteredString.Length - 1; i >= 0; i--)
            {
                Console.Write(enteredString[i]);
            }
        }
    }
}