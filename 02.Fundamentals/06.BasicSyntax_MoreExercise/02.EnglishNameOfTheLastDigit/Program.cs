using System;

namespace fundamentalsLesson6_2
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            string enteredNum = Console.ReadLine();
            int lastNum = 0;

            for (int i = 0; i <= enteredNum.Length - 1; i++)
            {
                if (i == enteredNum.Length - 1)
                {
                    char lastChar = enteredNum[i];
                    lastNum = (int)Char.GetNumericValue(lastChar);
                }
            }
            
            switch (lastNum)
            {
                case 0: Console.WriteLine("zero"); break;
                case 1: Console.WriteLine("one"); break;
                case 2: Console.WriteLine("two"); break;
                case 3: Console.WriteLine("three"); break;
                case 4: Console.WriteLine("four"); break;
                case 5: Console.WriteLine("five"); break;
                case 6: Console.WriteLine("six"); break;
                case 7: Console.WriteLine("seven"); break;
                case 8: Console.WriteLine("eight"); break;
                case 9: Console.WriteLine("nine"); break;
            }
        }
    }
}