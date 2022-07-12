using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumption;

        public Truck(double fuelQuanity, double fuelConsumption) : base(fuelQuanity, fuelConsumption)
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
                this._fuelConsumption = value + 1.6;
            }
        }

        public override void Drive(double distance)
        {
            if (distance * this._fuelConsumption <= this._fuelQuantity)
            {
                this._fuelQuantity -= distance * this._fuelConsumption;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
            }
        }

        public override void Refuel(double fuelAmmount)
        {
            double fuelToAdd = fuelAmmount * 0.95;
            this._fuelQuantity += fuelToAdd;
        }
    }
}
