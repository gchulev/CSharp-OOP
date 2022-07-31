using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models;
using Formula1.Models.Contracts;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> _models;

        public PilotRepository()
        {
            this._models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => this._models;

        public void Add(IPilot model)
        {
            this._models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return this._models.FirstOrDefault(p => p.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this._models.Remove(model);
        }
    }
}
