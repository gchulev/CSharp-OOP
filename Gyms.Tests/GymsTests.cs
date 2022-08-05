using System;

using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void PropertyNameShouldThrowExceptionWhenGymNameIsInvalid()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym = new Gym(null, 10);
            }, "Property Name was null but no exception was thrown"
            );
            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym = new Gym("", 10);
            }, "Property Name was empty string but no exception was thrown"
            );
        }

        [Test]
        public void PropertyNameIsAssignedCorrectly()
        {
            // Arrange
            string name = "test";

            // Act
            var gym = new Gym(name, 20);
            string expectedResult = name;
            string actualResult = gym.Name;

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void CpacityShouldThrowExceptionIfValueIsBelowZero()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var gym = new Gym("test", -5);
            }, "Property Capacity was below 0 and didn't throw an exception!"
            );
        }

        [Test]
        public void CapacityPropertyIsAssignedCorrectly()
        {
            // Arrange
            var gym = new Gym("test", 0);

            // Act
            int expectedResult = 0;
            int actualResult = gym.Capacity;

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void CountPropertyPovidesCorrectAthletesCount()
        {
            // Arrange
            var athlete1 = new Athlete("test1");
            var athlete2 = new Athlete("test2");

            var gym = new Gym("test", 10);

            // Act
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            int expectedResult = 2;
            int actualResult = gym.Count;

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void AddAthleteShouldThrowExceptionIfTheGymIsFull()
        {
            // Arrange
            var athlete1 = new Athlete("test1");
            var athlete2 = new Athlete("test2");
            var athlete3 = new Athlete("test3");
            var athlete4 = new Athlete("test4");

            var gym = new Gym("test", 3);

            // Act
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete4);
            }, "Gym had no capacity but no exception was thrown by 'AddAthlete' Method");
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionIfAthleteIsNull()
        {
            // Arrange
            var gym = new Gym("test", 3);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(null);
            }, "Athlete name wasn't in the collection but no error thrown!");
        }

        [Test]
        public void RemoveAthleteShouldDecreaseCountProperly()
        {
            // Arrange
            var athlete1 = new Athlete("test1");
            var athlete2 = new Athlete("test2");
            var athlete3 = new Athlete("test3");

            var gym = new Gym("test", 3);

            // Act
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.RemoveAthlete("test2");

            // Assert
            Assert.That(gym.Count, Is.EqualTo(2));
        }

        [Test]
        public void InjureAthleteThrowsExceptionIfAthleteIsNull()
        {
            // Arrange
            var gym = new Gym("test", 3);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(null);
            }, "Athlete name wasn't in the collection but no error thrown!");
        }

        [Test]
        public void InjureAthleteMethodSetsIsInjuredPropertyCorrectly()
        {
            // Arrange
            var athlete1 = new Athlete("test1");
            var athlete2 = new Athlete("test2");
            var athlete3 = new Athlete("test3");

            var gym = new Gym("test", 3);

            // Act
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            var injuredAthlete = gym.InjureAthlete("test2");

            // Assert
            Assert.That(injuredAthlete.IsInjured, Is.EqualTo(true));
        }

        [Test]
        public void GymReportShouldWorkcorrectly()
        {
            // Arrange
            var gym = new Gym("test", 3);

            var athlete1 = new Athlete("test1");
            var athlete2 = new Athlete("test2");
            var athlete3 = new Athlete("test3");

            // Act
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.InjureAthlete(athlete2.FullName);

            // Assert
            Assert.That(gym.Report, Is.EqualTo($"Active athletes at test: test1, test3"));
        }
    }
}
