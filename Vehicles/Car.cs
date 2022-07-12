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
        
        public override void Drive(double distance)
        {
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public override void Refuel(double fuelAmmount)
        {
            this._fuelQuantity += fuelAmmount;
        }
    }
}
