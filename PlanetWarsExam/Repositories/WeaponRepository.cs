using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.Models.FirstOrDefault(w => w.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.Models.FirstOrDefault(w => w.GetType().Name == name));
        }
    }
}
