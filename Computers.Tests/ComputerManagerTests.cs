using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountPropertyShouldReturnCorrectComputerCount()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            Assert.That(computerManager.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddComputerMethodShouldThrowExceptionIfComputerAlreadyExists()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);
            var computer4 = new Computer("Intel", "Celeron", 50);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer4);
            }, "This computer already exists.");
        }
        [Test]
        public void AddComputerMethodThrowsExceptionIfComputerIsNull()
        {
            // Arrange
            var computerManager = new ComputerManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(null);
            }, "Can not be null!");
        }

        [Test]
        public void RemoveComputerRemovesCorrectly()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Computer actualOutput = computerManager.RemoveComputer("Intel", "Celeron");

            // Assert
            Assert.That(actualOutput, Is.EqualTo(computer2));
            Assert.That(computerManager.Count, Is.EqualTo(2));

        }

        [Test]
        public void RemoveComputerThrowsExceptionIfManufacturerOrModelDoNotExist()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("AMD", "test");
            }, "There is no computer with this manufacturer and model.");

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("Test", "Ryzen");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerThrowsExceptionIfThereIsNoSuchComputerManufacturerOrModel()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("Intel", "Test");
            }, "There is no computer with this manufacturer and model.");

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("Test", "Xeon");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerThrowsExceptionWhenManufacturerOrModelAreNull()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer(null, "Xeon");
            }, "Can not be null!");

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer("Intel", null);
            }, "Can not be null!");
        }

        [Test]
        public void GetComputerMethodShouldReturnCorrectValue()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Computer expectedOutput = computerManager.GetComputer("AMD", "Ryzen");

            // Assert
            Assert.AreEqual(computer3, expectedOutput);
        }

        [Test]
        public void GetComputersByManufacturerShouldThrowExceptionIfComputerNameIsNull()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputersByManufacturer(null);
            }, "Can not be null!");
        }

        [Test]
        public void ComputersPropertyReturnsCorrectCollection()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(computerManager.Computers, typeof(Computer));
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnCorrectCollectionOfComputers()
        {
            // Arrange
            var computerManager = new ComputerManager();

            var computer1 = new Computer("Intel", "Xeon", 200);
            var computer2 = new Computer("Intel", "Celeron", 150);
            var computer3 = new Computer("AMD", "Ryzen", 250);

            // Act
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            ICollection<Computer> actualResult = computerManager.GetComputersByManufacturer("Intel");
            ICollection<Computer> expectedResult = new List<Computer>() { computer1, computer2};


            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }


    }
}