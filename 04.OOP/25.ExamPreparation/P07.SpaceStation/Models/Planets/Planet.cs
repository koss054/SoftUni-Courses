using System;
using System.Collections.Generic;

using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Items = new List<string>();
            this.Name = name;
        }

        public ICollection<string> Items { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }
    }
}
