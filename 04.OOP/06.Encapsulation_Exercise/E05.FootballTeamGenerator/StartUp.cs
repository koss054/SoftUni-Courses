using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();

            string[] input = Console.ReadLine().Split(";");

            while (input[0] != "END")
            {
                string command = input[0];
                string teamName = input[1];

                try
                {
                    if (command == "Team")
                    {
                        var team = new Team(teamName);
                        teams.Add(teamName, team);
                        input = Console.ReadLine().Split(";");
                        continue;
                    }

                    if (!teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        input = Console.ReadLine().Split(";");
                        continue;
                    }


                    if (command == "Add")
                    {
                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[teamName].AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string playerName = input[2];
                        bool isExistingPlayer = teams[teamName].RemovePlayer(playerName);

                        if (!isExistingPlayer)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                    }
                    else if (command == "Rating")
                    {
                        Console.WriteLine($"{teamName} - {teams[teamName].TeamRating}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine().Split(";");
            }
        }
    }
}
