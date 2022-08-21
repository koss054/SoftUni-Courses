using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            char enteredChar = char.Parse(Console.ReadLine());

            char charUp = Char.ToUpper(enteredChar);

            if (enteredChar == charUp)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}