using System;
using System.IO;

namespace L01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L01.OddLines\Files\input.txt");
            
            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L01.OddLines\Files\output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
