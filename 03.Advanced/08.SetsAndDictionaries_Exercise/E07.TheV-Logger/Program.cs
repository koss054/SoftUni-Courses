using System;
using System.Linq;
using System.Collections.Generic;

namespace E07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLoggerStatistics = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                var currentLine = Console.ReadLine().Split();

                if (currentLine[0] == "Statistics")
                {
                    break;
                }

                string vloggerName = currentLine[0];
                string currentCommand = currentLine[1];

                switch (currentCommand)
                {
                    case "joined":
                        if (!vLoggerStatistics.ContainsKey(vloggerName))
                        {
                            vLoggerStatistics.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                            vLoggerStatistics[vloggerName].Add("followers", new HashSet<string>());
                            vLoggerStatistics[vloggerName].Add("following", new HashSet<string>());
                        }
                        break;
                    case "followed":
                        string followedVlogger = currentLine[2];

                        if (vloggerName != followedVlogger && vLoggerStatistics.ContainsKey(vloggerName)
                            && vLoggerStatistics.ContainsKey(followedVlogger))
                        {
                            vLoggerStatistics[vloggerName]["following"].Add(followedVlogger);
                            vLoggerStatistics[followedVlogger]["followers"].Add(vloggerName);
                        }
                        break;
                }
            }

            int vloggerCounter = 1;

            Console.WriteLine($"The V-Logger has a total of {vLoggerStatistics.Count} vloggers in its logs.");

            foreach (var vlogger in vLoggerStatistics.OrderByDescending(v => v.Value["followers"].Count)
                .ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{vloggerCounter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (vloggerCounter == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(name => name))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                vloggerCounter++;
            } 
        }
    }
}
