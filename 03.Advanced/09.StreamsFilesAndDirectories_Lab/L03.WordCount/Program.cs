using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace L03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<string, int>();
            string inputWords = File.ReadAllText(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L03.WordCount\Files\words.txt");
            var words = inputWords.Split();

            using var writer = new StreamWriter(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L03.WordCount\Files\output.txt");

            using (var reader = new StreamReader(@"C:\Users\skull\source\repos\advancedLesson9_10_StreamFilesAndDirectories\L03.WordCount\Files\text.txt"))
            {
                string currentSentance = reader.ReadLine();

                while (currentSentance != null)
                {
                    foreach (var word in words)
                    {
                        if (currentSentance.ToLower().Contains(word))
                        {
                            if (!dictionary.ContainsKey(word))
                            {
                                dictionary.Add(word, 0);
                                dictionary[word]++;
                            }
                            else
                            {
                                dictionary[word]++;
                            }
                        }
                    }

                    currentSentance = reader.ReadLine();
                }

                foreach (var word in dictionary.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
