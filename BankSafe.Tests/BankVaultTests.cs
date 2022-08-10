using NUnit.Framework;

using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddItemMethodThrowsErrorIfGivenCellDoesNotExist()
        {
            // Arrange
            var vault = new BankVault();
            Item item = new Item("test", "1");

            // Act
            string cell = "test1";

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem(cell, item);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemMethodThrowsExceptionWhenCellIsTaken()
        {
            // Arrange
            var vault = new BankVault();
            Item item = new Item("test", "1");
            Item item2 = new Item("test2", "2");

            // Act
            string cell = "A1";
            vault.AddItem("A1", item);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem(cell, item2);
            }, "Cell is already taken!");
        }

        [Test]
        public void AddItemShouldThrowExceptionIfItemIsAlreadyAddedInTheDictionary()
        {
            // Arrange
            var vault = new BankVault();
            Item item = new Item("test", "1");
            Item item2 = new Item("test2", "2");

            // Act
            vault.AddItem("A4", item);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("C2", item);
            }, "Item is already in cell!");
        }

        [Test]
        public void AddItemMethodCorrectlyAddsItem()
        {
            // Arrange
            var vault = new BankVault();
            Item item2 = new Item("test2", "2");

            // Act
            string expectedResult = vault.AddItem("B3", item2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo($"Item:2 saved successfully!"));
        }

        [Test]
        public void RemoveItemThrowsExceptionIfTheCellDoesNotExist()
        {
            // Arrange
            var vault = new BankVault();
            Item item = new Item("test", "1");
            Item item2 = new Item("test2", "2");

            // Act
            vault.AddItem("A1", item);
            vault.AddItem("A3", item2);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("B1", item);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptioIfTheItemDoesNotExistInTheCell()
        {
            // Arrange
            var vault = new BankVault();
            Item item = new Item("test", "1");
            Item item2 = new Item("test2", "2");
            Item item3 = new Item("test3", "3");

            // Act
            vault.AddItem("A1", item);
            vault.AddItem("A3", item2);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A3", item3);
            }, $"Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemMethodShouldWorkProperly()
        {
            // Arrange
            var vault = new BankVault();
            Item item = new Item("test", "1");
            Item item2 = new Item("test2", "2");

            // Act
            vault.AddItem("A1", item);
            vault.AddItem("A3", item2);
            string expectedResult = vault.RemoveItem("A1", item);

            // Assert
            Assert.That(expectedResult, Is.EqualTo($"Remove item:1 successfully!"));
        }
    }
}