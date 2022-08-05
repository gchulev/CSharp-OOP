using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateHeroMethodThrowsExceptionWhenHeroIsNull()
    {
        // Arrange
        var hero = new Hero("test", 20);
        var heroRepo = new HeroRepository();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepo.Create(null);
        }, "Hero was null but no exception was thrown!");
    }

    [Test]
    public void CreateHeroMethodThrowsExceptionIfHeroAlreadyExistsInTheCollection()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        var hero1 = new Hero("test2",20);
        var hero2 = new Hero("test3", 30);

        // Act
        repository.Create(hero);
        repository.Create(hero1);
        repository.Create(hero2);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Create(hero);
        }, "Created the same hero twice without exception!");
    }

    [Test]
    public void CreateHeroMethodCreatedHeroCorrectly()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        var hero1 = new Hero("test2", 20);
        var hero2 = new Hero("test3", 30);

        // Act
        string returnMessage = repository.Create(hero);

        // Assert
        Assert.That(returnMessage, Is.EqualTo("Successfully added hero test1 with level 10"));
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionIfNameIsNullOrEmptyString()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        

        // Act
        repository.Create(hero);

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove(null);
        });
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove("");
        });
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove(" ");
        });
    }

    [Test]
    public void RemoeMethodShouldReturnBooleanCorrectly()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        var hero1 = new Hero("test2", 20);
        var hero2 = new Hero("test3", 30);

        // Act
        repository.Create(hero);
        repository.Create(hero1);
        repository.Create(hero2);
        bool actualReturnValue = repository.Remove(hero.Name);

        // Assert
        Assert.That(actualReturnValue, Is.EqualTo(true));
    }

    [Test]
    public void GetHeroWithHighestLevelShouldProperlyReturnTheHighestLevelHero()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        var hero1 = new Hero("test2", 20);
        var hero2 = new Hero("test3", 30);

        // Act
        repository.Create(hero);
        repository.Create(hero1);
        repository.Create(hero2);

        // Assert
        Assert.That(repository.GetHeroWithHighestLevel(), Is.EqualTo(hero2), $"Actual her returned is '{repository.GetHeroWithHighestLevel().Name}' and expected" +
            $"hero is {hero1.Name}");
    }

    [Test]
    public void GetHeroShouldReturnTheCorrectHeroByName()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        var hero1 = new Hero("test2", 20);
        var hero2 = new Hero("test3", 30);

        // Act
        repository.Create(hero);
        repository.Create(hero1);
        repository.Create(hero2);
        var returnedHero = repository.GetHero("test2");

        // Assert
        Assert.That(returnedHero.Name, Is.EqualTo("test2"), $"Expected hero name 'test2' but returned {returnedHero.Name}");
    }

    [Test]
    public void HeroesCollectionShouldReturnCorrectHeroCount()
    {
        // Arrange
        var repository = new HeroRepository();
        var hero = new Hero("test1", 10);
        var hero1 = new Hero("test2", 20);
        var hero2 = new Hero("test3", 30);

        // Act
        repository.Create(hero);
        repository.Create(hero1);
        repository.Create(hero2);

        // Assert
        Assert.That(repository.Heroes.Count, Is.EqualTo(3));

    }
}