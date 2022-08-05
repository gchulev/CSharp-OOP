using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models;

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }
        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model); // check if this works properly with Astronaut object
        }

        public IAstronaut FindByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }

    }
}
