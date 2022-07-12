using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumption;
        public Vehicle(double fuelQantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
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
        public virtual double FuelConsumption { get; protected set; }

        public void Drive(double distance)
        {
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public virtual void Refuel(double fuelAmmount)
        {
            this.FuelQuantity += fuelAmmount;
        }

    }
}
