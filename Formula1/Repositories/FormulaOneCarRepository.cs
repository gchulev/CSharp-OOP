using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Repositories;
using Formula1.Models.Contracts;
using Formula1.Models;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> _models;

        public FormulaOneCarRepository()
        {
            this._models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => this._models;

        public void Add(IFormulaOneCar model)
        {
            this._models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this._models.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this._models.Remove(model);
        }
    }
}
