namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CteateMethodShouldThrowErrorWhenPresentIsNull()
        {
            // Arrange
            var bag = new Bag();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            }, "null was given for present name, but no exception was thrown!");
        }

        [Test]
        public void CreateMethodShouldThrowExceptionWhenPresentAlreadyExists()
        {
            // Arrange
            var bag = new Bag();
            var present1 = new Present("test", 20.5);

            // Act
            bag.Create(present1);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present1);
            }, "The present already exists, but no exception was thrown!");
        }

        [Test]
        public void RemoveMethodShouldReturnProperValueIfPresentIsRemovedCorrectly()
        {
            // Arrange
            var bag = new Bag();
            var present1 = new Present("test", 20.5);
            var present2 = new Present("test2", 12.5);
            var present3 = new Present("test3", 90.85);

            // Act
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            // Assert
            Assert.That(bag.Remove(present3) is true, "Valid present was provided, but still 'false' was returned!");
            Assert.That(bag.Remove(present3) is false, "Present to be removed doesn't exist but still 'true' value is returned!");
        }

        [Test]
        public void GetPresentWithLeastMagicMethodShouldReturnCorrectValue()
        {
            // Arrange
            var bag = new Bag();
            var present1 = new Present("test", 20.5);
            var present2 = new Present("test2", 12.5);
            var present3 = new Present("test3", 90.85);
            var present4 = new Present("test4", 32.25);

            // Act
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            bag.Create(present4);

            var actualPresent = bag.GetPresentWithLeastMagic();

            // Assert
            Assert.That(actualPresent, Is.EqualTo(present2), $"actual present is different than expected present");
        }


        [Test]
        public void GetPresentWithLeastMagicShouldThrowExceptionIFThereAreNoPresents()
        {
            // Arrange
            var bag = new Bag();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.GetPresentWithLeastMagic();
            }, "The bag is empty but no exception thrown when looking for least magic item!");
            
        }

        [Test]
        public void GetPresentMethodShouldReturnTheCorrectPresent()
        {
            // Arrange
            var bag = new Bag();
            var present1 = new Present("test1", 20.5);

            // Act
            bag.Create(present1);
            Present actualPresentName = bag.GetPresent("test1");

            // Assert
            Assert.That(actualPresentName, Is.EqualTo(present1), $"actual present {actualPresentName} is different than the expected present test");
        }

        [Test]
        public void GetPresentMethodShouldReturnNullIfPresentNameDoesNotExist()
        {
            // Arrange
            var bag = new Bag();
            var present1 = new Present("test", 20.5);
            var present2 = new Present("test2", 12.5);
            var present3 = new Present("test3", 90.85);
            var present4 = new Present("test4", 32.25);

            // Act
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            bag.Create(present4);

            // Assert
            Assert.That(bag.GetPresent("test8"), Is.Null, "The present doesn't exists in the collectionk but no Exception was thrown!");
        }

        [Test]
        public void GetPresentsMethodShouldReturnZeroIfThereAreNoPresentsInTheBag()
        {
            // Arrange
            var bag = new Bag();

            // Act & Assert
            CollectionAssert.IsEmpty(bag.GetPresents());
        }

        [Test]
        public void GetPresentsMethodShouldReturnCollectionOfPresents()
        {
            // Arrange
            var bag = new Bag();
            var present1 = new Present("test", 20.5);
            var present2 = new Present("test2", 12.5);
            var present3 = new Present("test3", 90.85);
            var present4 = new Present("test4", 32.25);

            // Act
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            bag.Create(present4);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(bag.GetPresents(), typeof(Present), "Not all items in the collection are of type 'Present'");
        }
    }
}
