using Formula1.Factory.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Factory
{
    public class CarFactory : ICarFactory
    {
        public IFormulaOneCar ProduceCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == "Williams")
            {
                return new Williams(model, horsepower, engineDisplacement);
            }
            else if (type == "Ferrari")
            {
                return new Ferrari(model, horsepower, engineDisplacement);
            }

            throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
        }
    }
}
