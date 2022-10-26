using NUnit.Framework;

using System;
using System.Linq;
using System.Security.Cryptography;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            //[TestCase(" ")]
            [TestCase("")]
            [TestCase(null)]
            public void PlanetNameShouldThrowExceptionIfNameIsNullOrEmpty(string name)
            {
                // Arrange, Act & Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 200);
                }, "Invalid planet Name");
            }
        }

        [Test]
        public void BudgetPropertyShouldThrowExceptionIfItIsLessThanZero()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet("TestPlanet", -1);
            }, "Budget cannot drop below Zero!");
        }

        [Test]
        public void MilitaryPowerRatioReturnsCorrectValue()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);

            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            // Act
            double actualResult = planet.MilitaryPowerRatio;
            double expectedResult = 80;

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        
        [Test]
        public void ProfitShouldReturnCorrectNegativeValue()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            // Act
            planet.Profit(-20);
            double expectedResult = planet.Budget;

            // Assert
            Assert.That(expectedResult, Is.EqualTo(80));
        }

        [Test]
        public void ProfitShouldReturnCorrectPositiveValue()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            // Act
            planet.Profit(20);
            double expectedResult = planet.Budget;

            // Assert
            Assert.That(expectedResult, Is.EqualTo(120));
        }

        [Test]
        public void SpendFundsShouldThrowExceptionIfAmmountIsHigherThanBudget()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.SpendFunds(120);
            }, "Not enough funds to finalize the deal.");
        }
        [Test]
        public void SpendFundsDecreasesBudgetCorrectly()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            // Act
            planet.SpendFunds(20);

            // Assert
            Assert.That(planet.Budget, Is.EqualTo(80));
        }

        [Test]
        public void SpendFundsDecreasesBudgetWithNegativeValueCorrectly()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            // Act
            planet.SpendFunds(-20);

            // Assert
            Assert.That(planet.Budget, Is.EqualTo(120));
        }

        [Test]
        public void AddWeaponThrowsExceptionIfWeaponWithGivenNameAlreadyExists()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);
            Weapon weapon3 = new Weapon("wep2", 40, 70);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);
            
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.AddWeapon(weapon3);
            }, $"There is already a wep2 weapon.");
        }

        [Test]
        public void AddWeaponShouldAddWeaponCorrectly()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);
            Weapon weapon3 = new Weapon("wep2", 40, 70);

            // Act
            planet.AddWeapon(weapon1);
            Weapon expectedResult = planet.Weapons.FirstOrDefault(x => x.Name == "wep1");

            // Assert
            Assert.That(weapon1, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveWeaponShouldRemoveWeaponCorrectly()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            planet.RemoveWeapon(weapon1.Name);
            int actualResult = planet.Weapons.Count;

            //Assert
            Assert.AreEqual(1, actualResult);
        }

        [Test]
        public void RemoveWeaponShouldRemoveNothingIfInvalidNameIsProvided()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            planet.RemoveWeapon("wep6");

            // Assert
            Assert.AreEqual(2, planet.Weapons.Count);

        }
        [Test]
        public void UpgradeWeaponShouldThrowExceptionIfWeaponDoesNotExist()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);
            Weapon weapon3 = new Weapon("wep3", 40, 70);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.UpgradeWeapon("wep4");
            }, "wep4 does not exist in the weapon repository of planet");

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.UpgradeWeapon(null);
            }, " does not exist in the weapon repository of planet");
        }

        [Test]
        public void UpgradeWeaponShouldUpgradeCorrectly()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            planet.UpgradeWeapon("wep1");

            int actualDestructionLevel = planet.Weapons.FirstOrDefault(x => x.Name == "wep1").DestructionLevel;
            int expectedDestructionLevel = 31;

            // Assert
            Assert.That(actualDestructionLevel, Is.EqualTo(expectedDestructionLevel));
        }

        [Test]
        public void DestructOpponentShouldThrowErrorIfMilitaryPowerIsLowerOrEqualToOpponents()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);
            Planet opponent = new Planet("TestPlanet2", 200);
            Planet opponent2 = new Planet("TestPlanet3", 200);

            Weapon weapon1 = new Weapon("wep1", 20, 30);
            Weapon weapon2 = new Weapon("wep2", 30, 50);

            Weapon weapon3 = new Weapon("wep3", 30, 20);
            Weapon weapon4 = new Weapon("wep4", 30, 60);

            Weapon weapon5 = new Weapon("wep5", 30, 30);
            Weapon weapon6 = new Weapon("wep6", 30, 120);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            opponent.AddWeapon(weapon3);
            opponent.AddWeapon(weapon4);

            opponent2.AddWeapon(weapon5);
            opponent2.AddWeapon(weapon6);

            //Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.DestructOpponent(opponent);
            }, "TestPlanet2 is too strong to declare war to!");

            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.DestructOpponent(opponent2);
            }, "TestPlanet3 is too strong to declare war to!");
        }

        [Test]
        public void DestructOpponentShouldDestroyOpponentCorrectly()
        {
            // Arrange
            Planet planet = new Planet("TestPlanet", 100);
            Planet opponent = new Planet("TestPlanet2", 200);

            Weapon weapon1 = new Weapon("wep1", 20, 130);
            Weapon weapon2 = new Weapon("wep2", 30, 50);

            Weapon weapon3 = new Weapon("wep3", 30, 20);
            Weapon weapon4 = new Weapon("wep4", 30, 60);

            // Act
            planet.AddWeapon(weapon1);
            planet.AddWeapon(weapon2);

            opponent.AddWeapon(weapon3);
            opponent.AddWeapon(weapon4);

            // Assert
            Assert.That(planet.DestructOpponent(opponent), Is.EqualTo("TestPlanet2 is destructed!"));
        }

        [Test]
        public void WeapoinPriceShouldThrowExceptionIfItIsBelowZero()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var weapon = new Weapon("testwep", -10, 20);
            }, "Price cannot be negative.");
        }
    }
}
