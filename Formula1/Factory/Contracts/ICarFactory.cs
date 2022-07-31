using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;

namespace Formula1.Factory.Contracts
{
    public interface ICarFactory
    {
        public IFormulaOneCar ProduceCar(string type, string model, int horsepower, double engineDisplacement);
    }
}
