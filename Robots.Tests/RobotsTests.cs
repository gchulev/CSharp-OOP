namespace Robots.Tests
{
    using System;

    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        public void CapacityShouldThrowExceptionIfValueBelowZero()
        {
            // Arrange Act & Assert

            Assert.Throws<ArgumentException>(() =>
            {
                var robotManager = new RobotManager(-1);
            }, "Invalid capacity!");
        }

        [Test]
        public void CapacityShouldReturnThecorrectCapacity()
        {
            // Arrange
            var robotManager = new RobotManager(1);

            // Act
            int expectedCapacity = 1;
            int actualCapacity = robotManager.Capacity;

            // Assert
            Assert.That(robotManager.Capacity, Is.EqualTo(expectedCapacity), $"Espected capacity {expectedCapacity} is different than actual capacity {actualCapacity}");
        }

        [Test]
        public void CountShouldReturnTheCorrectNumber()
        {
            // Arrange
            var robotManager = new RobotManager(3);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            // Assert
            Assert.That(robotManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfRobotWithTheSameNameExsists()
        {
            // Arrange
            var robotManager = new RobotManager(3);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);
            var robot3 = new Robot("robot1", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            // Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);
            }, "The same robt was added twice without exception!");
        }

        [Test]

        public void AddMethodShouldThrowExceptionWhenTheCapacityIsFull()
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);
            var robot3 = new Robot("robot3", 4600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);
            }, "Capacity is full but no exception thrown!");
        }

        [Test]
        public void AddMethodShouldAddRobotsCorrectly()
        {
            // Arrange
            var robotManager = new RobotManager(3);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);
            var robot3 = new Robot("robot3", 4600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);

            // Assert
            Assert.That(robotManager.Count, Is.EqualTo(3));
        }

        [TestCase("robot4")]
        [TestCase("")]
        [TestCase(null)]
        public void RemoveMethodThrowsExceptionIfRobotDoesNotExist(string name)
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            // & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(name);
            }, "Remove method was called with non existant robot name but no exception was thrown!");
        }

        [Test]
        public void RemoveMethodRemovesRobotCorrectly()
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Remove("robot1");

            // Assert
            Assert.That(robotManager.Count, Is.EqualTo(1), "Robot Count wasn't as expected!");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("robot1")]
        public void WorkMethodThrowsExceptionWhenRobotIsNull(string name)
        {
            // Arrange
            var robotManager = new RobotManager(2);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(name, "job", 1200);
            }, "Incorrect robot name but no exception was thrown!");
        }

        [TestCase(1000)]
        [TestCase(1300)]
        [TestCase(int.MaxValue)]
        public void WorkMethodThrowsExceptionWhenRobotIsLowOnBattery(int batteryCharge)
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Work("robot1", "someJob", 400);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("robot1", "someJob", batteryCharge);
            }, "Robot had not enough battery but error wasn't thrown!");
        }
        [Test]
        public void WorkMethodShouldCorrectlyLowerBatteryCharge()
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Work(robot1.Name, "randomjob", 800);
            int expectedValue = 400;
            int actualValue = robot1.Battery;

            // Assert
            Assert.That(expectedValue, Is.EqualTo(actualValue));

        }

        [Test]
        public void ChargeMethodthrowsExcpetionIfRobotNameDoesNotExist()
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            // Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("");
            }, "Null was provided in robot's name but no Exception was thrown!");
        }

        [Test]
        public void ChargeMethodShouldCorrectlyChargeRobotBattery()
        {
            // Arrange
            var robotManager = new RobotManager(2);
            var robot1 = new Robot("robot1", 1200);
            var robot2 = new Robot("robot2", 1600);

            // Act
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            robotManager.Work(robot1.Name, "randomjob", 800);
            robotManager.Charge(robot1.Name);
            int actualCharge = robot1.Battery;

            // Assert
            Assert.That(actualCharge, Is.EqualTo(robot1.MaximumBattery));
        }
    }
}
