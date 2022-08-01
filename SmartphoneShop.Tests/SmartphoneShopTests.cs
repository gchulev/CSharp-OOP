using NUnit.Framework;

using System;
using System.Linq;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop _shop;

        [SetUp]
        public void Start()
        {
            this._shop = new Shop(4);
            Smartphone samsung = new Smartphone("Samsung", 2000);
            Smartphone samsung1 = new Smartphone("Samsung1", 4000);
            Smartphone samsung2 = new Smartphone("Samsung2", 3000);

            this._shop.Add(samsung);
            this._shop.Add(samsung1);
            this._shop.Add(samsung2);
        }

        [TestCase(-1000)]
        [TestCase(-2)]
        public void IfCapacityIsBelowZeroShouldThrowAnException(int capacity)
        {
            //Arrange


            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "No \"ArgumentException\" was thrown");
        }

        [Test]
        public void AddShouldThrowAnExceptionIfPhoneIsAllreadyAddedToTheShop()
        {
            // Arrange
            Shop shop = new Shop(2);
            Smartphone samsung = new Smartphone("Samsung", 1800);
            Smartphone samsung2 = new Smartphone("Samsung", 1800);

            // Act
            shop.Add(samsung);

            // Assert
            Assert.That(() =>
            {
                shop.Add(samsung);
            }, Throws.InvalidOperationException, "Exception not thrown when the phone model already exists!");
            
        }

        [Test]
        public void AddShouldThrowAnExceptionIfTheShopIsFull()
        {
            // Arrange
            Smartphone phone = new Smartphone("Test", 1000);
            Smartphone phone1 = new Smartphone("Test1", 2000);

            // Act
            _shop.Add(phone);

            // Assert
            Assert.That(() =>
            {
                _shop.Add(phone1);
            }, Throws.InvalidOperationException, "Shop is full but no exception was thrown!!!");
        }

        [Test]
        public void AddShouldAddItemsProperlyToTheShopCollection()
        {
            // Arrange
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("test", 2000);

            // Act
            shop.Add(phone);
            int actualAddedPhonesCount = shop.Count;
            int expectedPhonesCount = 1;

            // Assert
            Assert.That(actualAddedPhonesCount, Is.EqualTo(expectedPhonesCount), $"Number of added phones {actualAddedPhonesCount} is different than the expected count {expectedPhonesCount}");
        }

        [Test]
        public void RemoveMethodThrowsAnErrorIfThePhoneIsNotFoundInTheCollection()
        {
            // Arrange
            Shop shop = new Shop(3);
            Smartphone samsung = new Smartphone("Samsung", 2000);
            Smartphone samsung1 = new Smartphone("Samsung1", 4000);
            Smartphone samsung2 = new Smartphone("Samsung2", 3000);

            // Act
            shop.Add(samsung1);
            shop.Add(samsung2);

            // Assert
            Assert.That(() =>
            {
                shop.Remove(samsung.ModelName);
            }, Throws.InvalidOperationException, "Phone wasn't in the collection but no Exception was thrown!");
        }

        [Test]
        public void RemoveMethodShouldRemovePhonesProperly()
        {
            // Arrange
            Shop shop = new Shop(3);
            Smartphone phone1 = new Smartphone("Phone1", 2000);
            Smartphone phone2 = new Smartphone("Phone2", 2400);
            Smartphone phone3 = new Smartphone("Phone3", 2900);

            // Act
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);

            shop.Remove("Phone1");

            int actualPhonesCount = shop.Count;
            int expectedPhonesCount = 2;

            // Assert
            Assert.That(actualPhonesCount, Is.EqualTo(expectedPhonesCount), $"Actual phones count {actualPhonesCount} is different than expected phones count {expectedPhonesCount}");
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionIfThePhoneIsNotInTheCollection()
        {
            // Arrange
            string phoneModel = "test";
            int batteryUsage = 1200;

            // Act & Assert
            Assert.That(() =>
            {
                _shop.TestPhone(phoneModel, batteryUsage);
            }, Throws.InvalidOperationException, $"Phone {phoneModel} wasn't in the shop collection, but no Exception was thrown!");
        }

        [TestCase(4000)]
        public void TestPhoneMethodShouldThrowExceptionWhenPhoneChargeIsBelowBatteryUsage(int batteryUsage)
        {
            // Arrange
            string phoneModel = "Samsung";

            // Act & Assert
            Assert.That(() =>
            {
                _shop.TestPhone(phoneModel, batteryUsage);
            }, Throws.InvalidOperationException, $"Phone model {phoneModel} battery capacity was lower than given battery useage but no exception was thrown!");
            
        }

        [Test]
        public void TestPhoneShouldReduceBatteryChargePropertyByBatteryUsageValue()
        {
            // Arrange
            string phoneNameTotest = "testPhone";
            int batteryUsage = 1200;
            Smartphone testPhone = new Smartphone("testPhone", 4000);
            _shop.Add(testPhone);

            // Act
            _shop.TestPhone(phoneNameTotest, batteryUsage);

            int actualBatteryCharge = testPhone.CurrentBateryCharge;
            int expectedBatteryCharge = 2800;

            // Assert
            Assert.That(actualBatteryCharge, Is.EqualTo(expectedBatteryCharge), $"Expected charge is: {expectedBatteryCharge}, but the actual value is: {actualBatteryCharge}");
        }

        [Test]
        public void ChargePhoneShouldThrowExceptionIfPhoneDoesntExist()
        {
            // Arrange
            string phoneModel = "somePhone";

            // Act & Assert
            Assert.That(() =>
            {
                _shop.ChargePhone(phoneModel);
            }, Throws.InvalidOperationException, $"Phone: {phoneModel} doesn't exist, but there was no Exception thrown!!");
        }

        [Test]
        public void ChargePhoneWorkingCorrect()
        {
            // Arrange
            Smartphone phone = new Smartphone("somePhone", 2000);

            // Act
            _shop.Add(phone);
            _shop.TestPhone("somePhone", 1200);
            _shop.ChargePhone("somePhone");
            _shop.TestPhone("somePhone", 1500);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _shop.TestPhone("somePhone", 501));
        }

        [Test]
        public void CapacityReturnsCorrectValue()
        {
            // Arrange

            // Act
            int expectedCapacity = 4;
            int actualCapacity = _shop.Capacity;

            // Assert
            Assert.That(expectedCapacity, Is.EqualTo(actualCapacity), $"Expected capacity: {expectedCapacity} is different than actual capacity {actualCapacity}");
        }
    }
}