using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());
            int currentSum = 0;
            string strNum = enteredNum.ToString();

            for (int i = 0; i < strNum.Length; i++)
            {
                char currentChar = strNum[i];
                int currentNum = (int)Char.GetNumericValue(currentChar);
                int factorialSum = 1;

                for (int j = 1; j <= currentNum; j++)
                {
                    factorialSum *= j;
                }

                currentSum += factorialSum;
            }

            if (currentSum == enteredNum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}