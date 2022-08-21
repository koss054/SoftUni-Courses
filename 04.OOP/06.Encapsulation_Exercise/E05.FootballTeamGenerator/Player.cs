using System;
using System.Collections.Generic;

namespace E05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;

            ValidateStats("Endurance", endurance);
            ValidateStats("Sprint", sprint);
            ValidateStats("Dribble", dribble);
            ValidateStats("Passing", passing);
            ValidateStats("Shooting", shooting);

            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
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

        private void ValidateStats(string statName, int statValue)
        {
            if (statValue < 0 || statValue > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }

        public double PlayerStats
            => (endurance + sprint + dribble + passing + shooting) / 5.0;
    }
}
