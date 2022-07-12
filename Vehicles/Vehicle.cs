using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQantity;
            this.FuelConsumption = fuelConsumption;
        }

        public abstract double FuelQuantity { get; protected set; }
        public abstract double FuelConsumption { get; protected set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double fuelAmmount);

    }
}
