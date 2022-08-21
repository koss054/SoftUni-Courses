using System;
using System.IO;

namespace L02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L02.LineNumbers\Files\input.txt"))
            {
                string line = reader.ReadLine();
                int counter = 1;

                using (var writer = new StreamWriter(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L02.LineNumbers\Files\output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
