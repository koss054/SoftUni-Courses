using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredAge = int.Parse(Console.ReadLine());

            if (enteredAge >= 0 && enteredAge <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (enteredAge >= 3 && enteredAge <= 13)
            {
                Console.WriteLine("child");
            }
            else if (enteredAge >= 14 && enteredAge <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (enteredAge >= 20 && enteredAge <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (enteredAge >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}