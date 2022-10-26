using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    internal class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models;

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.Models.FirstOrDefault(p => p.Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(p => p.Name == name)); ;
        }
    }
}
