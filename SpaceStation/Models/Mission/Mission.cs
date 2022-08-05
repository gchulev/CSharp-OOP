using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            var viableAstronauts = astronauts.Where(a => a.CanBreath);
            List<string> planetItems = planet.Items as List<string>; 

            foreach (IAstronaut astronaut in viableAstronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {

                    for (int i = 0; i < planetItems.Count; i++)
                    {
                        astronaut.Bag.Items.Add(planetItems[i]);
                        planet.Items.Remove(planetItems[i]);
                        i--;

                        astronaut.Breath();
                        if (!astronaut.CanBreath)
                        {
                            break;
                        }

                    }
                }
            }
        }
    }
}
