using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models => this.models;
        public void Add(T model)
        {
            this.models.Add(model);
        }
        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models;
        }

        public abstract T GetByName(string name);
        

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
