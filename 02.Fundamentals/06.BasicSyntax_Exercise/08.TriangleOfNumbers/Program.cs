using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= enteredNum; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    //if (i < 10)
                    //{
                        Console.Write($"{i} ");
                    //}
                    //else
                    //{
                    //    Console.Write($"{i}");
                    //}
                }

                Console.WriteLine();
            }
        }
    }
}