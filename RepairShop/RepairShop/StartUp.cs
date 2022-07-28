using System;

namespace RepairShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Arrange
            Garage garage = new Garage("Test", 3);
            Car ford = new Car("Ford", 0);
            Car vw = new Car("Volkswagen", 0);
            Car suzuki = new Car("Suzuki", 0);

            // Act
            garage.AddCar(ford);
            garage.AddCar(vw);
            garage.AddCar(suzuki);

            string result = garage.Report();
        }
    }
}
