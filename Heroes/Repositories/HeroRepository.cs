using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero> 
    {
        private readonly List<IHero> _models;

        public HeroRepository()
        {
            this._models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this._models;
        
        public void Add(IHero model)
        {
            this._models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return _models.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            return this._models.Remove(model);
        }
    }
}
