using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VowelCount(Console.ReadLine()));
        }

        static int VowelCount(string a)
        {
            int vowelCounter = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 'a' 
                    || a[i] == 'e'
                    || a[i] == 'i'
                    || a[i] == 'o'
                    || a[i] == 'u'
                    || a[i] == 'A'
                    || a[i] == 'E'
                    || a[i] == 'I'
                    || a[i] == 'O'
                    || a[i] == 'U')
                {
                    vowelCounter++;
                }
            }

            return vowelCounter;
        }
    }
}
