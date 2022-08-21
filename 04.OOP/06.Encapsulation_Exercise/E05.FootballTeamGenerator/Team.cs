using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;

            players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public bool RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);
            return players.Remove(player);
        }

        public int TeamRating
            => players.Any()
            ? (int)Math.Round(players.Average(x => x.PlayerStats))
            : 0;
    }
}
