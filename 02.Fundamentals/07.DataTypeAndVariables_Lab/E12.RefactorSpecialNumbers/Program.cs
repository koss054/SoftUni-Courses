using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            /*
            int kolkko = int.Parse(Console.ReadLine());
            int obshto = 0;
            int takova = 0;
            bool toe = false;
            for (int ch = 1; ch <= kolkko; ch++)
            {
                takova = ch;
                while (ch > 0)
                {
                    obshto += ch % 10;
                    ch = ch / 10;
                }
                toe = (obshto == 5) || (obshto == 7) || (obshto == 11);
                Console.WriteLine("{0} -> {1}", takova, toe);
                obshto = 0;
                ch = takova;
            }
            */

            int enteredNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            int digitOfNum = 0;

            bool isSpecial = false;

            for (int i = 1; i <= enteredNumber; i++)
            {
                digitOfNum = i;

                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }

                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);

                sum = 0;
                i = digitOfNum;

                Console.WriteLine("{0} -> {1}", digitOfNum, isSpecial);
            }
        }
    }
}