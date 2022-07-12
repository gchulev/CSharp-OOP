using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class Program
    {
        static void Main()
        {
            string[] carInput = Console.ReadLine().Split();
            string[] truckInput = Console.ReadLine().Split();
            //string[] busInput = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            var car = new Car(carFuelQuantity, carFuelConsumption);

            double truckFuelquantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            var truck = new Truck(truckFuelquantity, truckFuelConsumption);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string vehicletype = input[1];
                

                if (command.Equals("Drive"))
                {
                    double distance = double.Parse(input[2]);

                    if (vehicletype.Equals("Car"))
                    {
                        car.Drive(distance);
                    }
                    else if (vehicletype.Equals("Truck"))
                    {
                        truck.Drive(distance);
                    }
                }
                else if (command.Equals("Refuel"))
                {
                    double fuelAmmount = double.Parse(input[2]);

                    if (vehicletype.Equals("Car"))
                    {
                        car.Refuel(fuelAmmount);
                    }
                    else if (vehicletype.Equals("Truck"))
                    {
                        truck.Refuel(fuelAmmount);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }
    }
}
