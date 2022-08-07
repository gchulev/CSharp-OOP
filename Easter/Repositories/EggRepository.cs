using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> model;

        public EggRepository()
        {
            this.model = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.model.AsReadOnly();

        public void Add(IEgg model)
        {
            this.model.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.model.FirstOrDefault(e => e.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return this.model.Remove(model);
        }
    }
}
