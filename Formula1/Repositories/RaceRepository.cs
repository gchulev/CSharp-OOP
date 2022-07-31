using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> _models;

        public RaceRepository()
        {
            this._models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this._models;

        public void Add(IRace model)
        {
            this._models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this._models.FirstOrDefault(r => r.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return this._models.Remove(model);
        }
    }
}
