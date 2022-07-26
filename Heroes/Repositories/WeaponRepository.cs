using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> _weapons;

        public WeaponRepository()
        {
            this._weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this._weapons;

        public void Add(IWeapon model)
        {
            this._weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this._weapons.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return this._weapons.Remove(model);
        }
    }
}
