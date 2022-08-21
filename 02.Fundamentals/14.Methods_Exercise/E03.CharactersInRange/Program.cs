using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharactersInRange(firstChar, secondChar);
        }

        static void CharactersInRange(char a, char b)
        {
            int firstCharValue = Convert.ToInt32(a);
            int secondCharValue = Convert.ToInt32(b);

            if (a > b)
            {
                int tempValue = firstCharValue;
                firstCharValue = secondCharValue;
                secondCharValue = tempValue;
            }

            for (int i = firstCharValue + 1; i < secondCharValue; i++)
            {

                Console.Write($"{(char)i} ");
            }
        }
    }
}
