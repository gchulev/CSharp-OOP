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
            string[] busInput = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            int tankCapcityCar = int.Parse(carInput[3]);
            var car = new Car(carFuelQuantity, carFuelConsumption, tankCapcityCar);

            double truckFuelquantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            int tankCapcityTruck = int.Parse(truckInput[3]);
            var truck = new Truck(truckFuelquantity, truckFuelConsumption, tankCapcityTruck);

            double busFuelQuantity = double.Parse(busInput[1]);
            double busFuelConsumption = double.Parse(busInput[2]);
            int tankCapacityBus = int.Parse(busInput[3]);
            var bus = new Bus(busFuelQuantity, busFuelConsumption, tankCapacityBus);

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
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicletype.Equals("Truck"))
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (vehicletype.Equals("Bus"))
                    {
                        bus.IsEmpty = false;
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (command.Equals("DriveEmpty"))
                {
                    double distance = double.Parse(input[2]);
                    bus.IsEmpty = true;
                    Console.WriteLine(bus.Drive(distance));
                }
                else if (command.Equals("Refuel"))
                {
                    try
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
                        else if (vehicletype.Equals("Bus"))
                        {
                            bus.Refuel(fuelAmmount);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }
    }
}
