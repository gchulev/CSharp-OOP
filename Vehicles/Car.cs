using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private double _fuelConsumption;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption
        {
            get
            {
                return this._fuelConsumption;
            }
            protected set
            {
                this._fuelConsumption = value + 0.9;
            }
        }
    }
}
