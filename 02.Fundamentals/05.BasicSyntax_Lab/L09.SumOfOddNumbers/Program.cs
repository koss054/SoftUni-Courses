using System;

namespace fundamentalsLesson5
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());
            int oddNum = 1;
            int oddSum = oddNum;

            Console.WriteLine(oddNum);

            for (int i = 1; i < enteredNum; i++)
            {
                oddNum += 2;
                Console.WriteLine(oddNum);
                oddSum += oddNum;
            }

            Console.WriteLine($"Sum: {oddSum}");
        }
    }
}