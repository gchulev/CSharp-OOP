using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.models;

        public object All { get; internal set; }

        public void Add(IBunny model)
        {
            this.models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return this.models.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IBunny model)
        {
            return this.models.Remove(model);
        }
    }
}
