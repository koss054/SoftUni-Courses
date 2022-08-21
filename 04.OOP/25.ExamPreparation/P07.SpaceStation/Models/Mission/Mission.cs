using System.Collections.Generic;
using System.Linq;

using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    continue;
                }

                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    foreach (var item in planet.Items.ToList())
                    {
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        astronaut.Breath();

                        if (planet.Items.Count == 0 ||
                            !astronaut.CanBreath)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
