using System;

namespace fundamentalsLesson6_2
{
    public class Progam
    {
        public static void Main(string[] args)
        {
           int totalNumbers = int.Parse(Console.ReadLine());
            string finalWord = string.Empty;
            int i = 0;

            while (i < totalNumbers)
            {
                int enteredNum = int.Parse(Console.ReadLine());
                switch (enteredNum)
                {
                    case 2:
                        finalWord += "a";

                        break;
                    case 22:
                        finalWord += "b";
                        break;
                    case 222:
                        finalWord += "c";
                        break;
                    case 3:
                        finalWord += "d";
                        break;
                    case 33:
                        finalWord += "e";
                        break;
                    case 333:
                        finalWord += "f";
                        break;
                    case 4:
                        finalWord += "g";
                        break;
                    case 44:
                        finalWord += "h";
                        break;
                    case 444:
                        finalWord += "i";
                        break;
                    case 5:
                        finalWord += "j";
                        break;
                    case 55:
                        finalWord += "k";
                        break;
                    case 555:
                        finalWord += "l";
                        break;
                    case 6:
                        finalWord += "m";
                        break;
                    case 66:
                        finalWord += "n";
                        break;
                    case 666:
                        finalWord += "o";
                        break;
                    case 7:
                        finalWord += "p";
                        break;
                    case 77:
                        finalWord += "q";
                        break;
                    case 777:
                        finalWord += "r";
                        break;
                    case 7777:
                        finalWord += "s";
                        break;
                    case 8:
                        finalWord += "t";
                        break;
                    case 88:
                        finalWord += "u";
                        break;
                    case 888:
                        finalWord += "v";
                        break;
                    case 9:
                        finalWord += "w";
                        break;
                    case 99:
                        finalWord += "x";
                        break;
                    case 999:
                        finalWord += "y";
                        break;
                    case 9999:
                        finalWord += "z";
                        break;
                    case 0:
                        finalWord += " ";
                        break;
                }

                i++;
            }

            Console.WriteLine(finalWord);
        }
    }
}