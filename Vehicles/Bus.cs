using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionIncrease = 1.4;
        private double _fuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public bool IsEmpty { get; set; } = true;
        public override double FuelConsumption
        {
            get
            {
                if (this.IsEmpty == true)
                {
                    return this._fuelConsumption;
                }
                return this._fuelConsumption + BusFuelConsumptionIncrease;
            }
            protected set
            {
                this._fuelConsumption = value;
            }
        }
    }
}
