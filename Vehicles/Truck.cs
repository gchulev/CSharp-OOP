using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double _fuelConsumption;

        public Truck(double fuelQuanity, double fuelConsumption, int tankCapacity) : base(fuelQuanity, fuelConsumption, tankCapacity)
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
                this._fuelConsumption = value + 1.6;
            }
        }

        public override void Refuel(double fuelAmmount)
        {
            if (fuelAmmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if ((this.FuelQuantity + fuelAmmount > this.TankCapacity))
            {
                throw new ArgumentException($"Cannot fit {fuelAmmount} fuel in the tank");
            }
            double fuelToAdd = fuelAmmount * 0.95;
            this.FuelQuantity += fuelToAdd;
        }
    }
}
