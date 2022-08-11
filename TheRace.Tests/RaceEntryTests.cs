using System;

using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountPropertyShouldWorkCorrectly()
        {
            // Arrange
            var raceEntry = new RaceEntry();

            var car1 = new UnitCar("test1", 100, 1600);
            var car2 = new UnitCar("test2", 120, 1800);

            var driver1 = new UnitDriver("testDriver1", car1);
            var driver2 = new UnitDriver("testDriver2", car2);

            // Act
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver1);

            // Assert
            Assert.That(raceEntry.Counter, Is.EqualTo(2));
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriveIsNull()
        {
            // Arrange
            var raceEntry = new RaceEntry();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(null);
            }, "Driver cannot be null.");
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverAlreadyExist()
        {
            // Arrange
            var raceEntry = new RaceEntry();

            // Act
            var car1 = new UnitCar("test1", 100, 1600);
            var car2 = new UnitCar("test2", 120, 1800);
            var car3 = new UnitCar("test3", 180, 2000);

            var driver1 = new UnitDriver("testDriver1", car1);
            var driver2 = new UnitDriver("testDriver2", car2);
            var driver3 = new UnitDriver("testDriver2", car3);

            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(driver3);
            }, "Driver testDriver2 is already added.");
        }

        [Test]
        public void AddDriverMethodShouldWorkCorrectly()
        {
            // Arrange
            var raceEntry = new RaceEntry();

            // Act
            var car1 = new UnitCar("test1", 100, 1600);

            var driver1 = new UnitDriver("testDriver1", car1);

            string expectedResult = raceEntry.AddDriver(driver1);

            // Assert
            Assert.That(expectedResult, Is.EqualTo("Driver testDriver1 added in race."));
        }

        [Test]
        public void TestCalculateAverageHorsePowerShouldThrowExceptionIfDriversAreLessThanMinimumRequiredParticipants()
        {
            // Arrange
            var raceEntry = new RaceEntry();

            // Act
            var car1 = new UnitCar("test1", 100, 1600);
            var car2 = new UnitCar("test2", 120, 1800);

            var driver1 = new UnitDriver("testDriver1", car1);

            raceEntry.AddDriver(driver1);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            }, "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void TestCalculateAverageHorsePowerShouldWorkCorrectly()
        {
            // Arrange
            var raceEntry = new RaceEntry();

            // Act
            var car1 = new UnitCar("test1", 100, 1600);
            var car2 = new UnitCar("test2", 120, 1800);
            var car3 = new UnitCar("test3", 180, 2000);
            var car4 = new UnitCar("test4", 200, 2200);

            var driver1 = new UnitDriver("testDriver1", car1);
            var driver2 = new UnitDriver("testDriver2", car2);
            var driver3 = new UnitDriver("testDriver3", car3);
            var driver4 = new UnitDriver("testDriver4", car4);

            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);
            raceEntry.AddDriver(driver4);

            //Assert
            Assert.That(raceEntry.CalculateAverageHorsePower(), Is.EqualTo(150));
        }
    }
}