using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double _fuelQuantity;
        public Vehicle(double fuelQantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
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
                if (value > this.TankCapacity)
                {
                    this._fuelQuantity = 0;
                }
                else
                {
                    this._fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption { get; protected set; }
        public int TankCapacity { get; }
        public string Drive(double distance)
        {
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }
        public virtual void Refuel(double fuelAmmount)
        {
            if (fuelAmmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuelAmmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmmount} fuel in the tank");
            }
            this.FuelQuantity += fuelAmmount;
        }

    }
}
