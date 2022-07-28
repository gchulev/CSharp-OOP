using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]
            public void GarageWithEmptyNameShouldThrowException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                    {
                        Garage garage = new Garage("", 10);
                    });
            }

            [Test]
            public void ZeroOrLessthanZeroMechanicsShouldThrowException()
            {
                Assert.That(() =>
                {
                    // Arrange & Act
                    Garage garage1 = new Garage("Test1", 0);
                    // Assert
                }, Throws.ArgumentException, "Constructor didn't throw exception when 0 or less mechanics provided!");


                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("test", -1);
                });
            }

            [Test]
            public void AddCarShouldThrowExceptionIfCarsAreEqualToAvailableMechanics()
            {
                // Arrange
                Garage garage = new Garage("testGarage", 2);
                Car carOne = new Car("test1", 3);
                Car carTwo = new Car("test2", 2);
                Car carTree = new Car("test3", 1);

                // Act
                garage.AddCar(carOne);
                garage.AddCar(carTwo);

                // Assert
                Assert.That(() =>
                {
                    garage.AddCar(carTree);

                }, Throws.Exception.TypeOf<InvalidOperationException>());
            }

            [Test]
            public void FixCarShouldThrowExceptionWhenGivenCarIsNull()
            {
                // Arrange

                Garage garage = new Garage("test", 2);
                Car ford = new Car("Ford", 20);
                Car vw = new Car("Volkswagen", 2);
                Car suzuki = new Car("Suzuki", 1);

                // Act
                garage.AddCar(ford);
                garage.AddCar(vw);

                // Assert
                Assert.That(() =>
                {
                    Car fixedCar = garage.FixCar(suzuki.CarModel);
                }, Throws.Exception.TypeOf<InvalidOperationException>(), "Method doesn't throw error when null object is returned from the result and it should!!!");
            }

            [Test]
            public void RemoveFixedCarShouldThrowExceptionWhenCarsAreLessOrEqualToZero()
            {
                // Arrange
                Garage garage = new Garage("Test", 3);
                Car ford = new Car("Ford", 20);
                Car vw = new Car("Volkswagen", 2);
                Car suzuki = new Car("Suzuki", 1);

                // Act
                garage.AddCar(ford);
                garage.AddCar(vw);
                garage.AddCar(suzuki);

                // Assert
                Assert.That(() =>
                {
                    int removedCars = garage.RemoveFixedCar();
                }, Throws.Exception.TypeOf<InvalidOperationException>(), "Returned Fixed cars are 0 or less but there is no exception from the method!!!");
            }

            [Test]
            public void ReportShouldPrintThatZeroCarsAreNotFixed()
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

                string expectedResult = "There are 0 which are not fixed: .";
                string actualResult = garage.Report();

                // Assert
                Assert.AreEqual(expectedResult, actualResult);

            }
        }
    }
}