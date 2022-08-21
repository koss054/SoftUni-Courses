using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);

            return String.Format(
                OutputMessages.AstronautAdded,
                type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return String.Format(
                OutputMessages.PlanetAdded,
                planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            int deadAstronauts = 0;
            IPlanet planet = this.planets.FindByName(planetName);
            List<IAstronaut> suitableAstronauts = this.astronauts.Models
                .Where(x => x.Oxygen > 60)
                .ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();
            mission.Explore(planet, suitableAstronauts);

            foreach (var astronaut in suitableAstronauts.Where(x => x.Oxygen <= 0))
            {
                deadAstronauts++;
            }

            this.exploredPlanetsCount++;

            return String.Format(
                OutputMessages.PlanetExplored,
                planetName, deadAstronauts);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");

                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("none");
                }
                else
                {
                    sb.AppendLine(string.Join(", ", astronaut.Bag.Items));
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRetiredAstronaut,
                    astronautName));
            }

            this.astronauts.Remove(astronaut);

            return String.Format(
                OutputMessages.AstronautRetired,
                astronautName);
        }
    }
}
