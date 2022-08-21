using System;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= enteredNumber; i++)
            {
                int digitSum = 0;
                string currentNum = i.ToString();

                for (int j = 0; j < currentNum.Length; j++)
                {
                    char conversionChar = Convert.ToChar(currentNum[j]);
                    double currentDigit = char.GetNumericValue(conversionChar);

                    digitSum += (int) currentDigit;
                }

                if (digitSum == 5 || digitSum == 7 || digitSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}