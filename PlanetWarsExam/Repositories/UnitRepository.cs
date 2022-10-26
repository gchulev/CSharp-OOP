using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;
        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.models;

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == name));
        }
    }
}
