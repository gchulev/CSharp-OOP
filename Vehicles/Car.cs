using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumption;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }
        public override double FuelQuantity
        {
            get
            {
                return this._fuelQuantity;
            }
            protected set
            {
                this._fuelQuantity = value;
            }
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
