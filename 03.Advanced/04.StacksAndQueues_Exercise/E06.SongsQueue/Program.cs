using System;
using System.Linq;
using System.Collections.Generic;

namespace E06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var addedSongs = Console.ReadLine().Split(", ");
            var queuedSongs = new Queue<string>(addedSongs);

            while (queuedSongs.Count > 0)
            {
                string userInput = Console.ReadLine();
                var separatedInput = userInput.Split();

                switch(separatedInput[0])
                {
                    case "Play":
                        queuedSongs.Dequeue();
                        break;
                    case "Add":
                        string songToAdd = userInput.Substring(4, userInput.Length - 4);
                        bool isContained = false;
                        var tempQueue = new Queue<string>(queuedSongs);

                        while (tempQueue.Count > 0)
                        {
                            string currentSong = tempQueue.Dequeue();

                            if (songToAdd == currentSong)
                            {
                                isContained = true;

                                Console.WriteLine($"{songToAdd} is already contained!");
                                break;
                            }
                        }

                        if (!isContained)
                        {
                            queuedSongs.Enqueue(songToAdd);
                        }
                        break;
                    case "Show":
                        var listOfSongs = queuedSongs.ToArray();

                        Console.WriteLine(string.Join(", ", listOfSongs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
