using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void Constructor_ShouldInitialize()
    {
        var heroRepo = new HeroRepository();

        Assert.IsNotNull(heroRepo.Heroes);
    }

    [Test]
    public void Create_WithValidHero_ShouldIncreaseCount()
    {
        int expectedCount = 1;
        var heroRepo = new HeroRepository();
        var hero = new Hero("Steve", 64);

        heroRepo.Create(hero);

        Assert.AreEqual(
            expectedCount,
            heroRepo.Heroes.Count);
    }

    [Test]
    public void Create_WithNullHero_ShouldThrow_ArgumentNullException()
    {
        var heroRepo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(
            () => heroRepo.Create(null));
    }

    [Test]
    public void Create_WithDuplicateHero_ShouldThrow_InvalidOperationException()
    {
        var heroRepo = new HeroRepository();
        var originalHero = new Hero("Steve", 64);
        var duplicateHero = new Hero("Steve", 128);

        heroRepo.Create(originalHero);

        Assert.Throws<InvalidOperationException>(
            () => heroRepo.Create(duplicateHero));
    }

    [Test]
    public void Remove_WithValidHero_ShouldReturn_True()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Steve", 64);

        heroRepo.Create(hero);

        Assert.IsTrue(heroRepo.Remove(hero.Name));
    }

    [Test]
    public void Remove_WithNullName_ShouldThrow_ArgumentNullException()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Steve", 64);

        heroRepo.Create(hero);

        Assert.Throws<ArgumentNullException>(
            () => heroRepo.Remove(null));
    }

    [Test]
    public void Remove_WithWhitespaceName_ShouldThrow_ArgumentNullException()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Steve", 64);

        heroRepo.Create(hero);

        Assert.Throws<ArgumentNullException>(
            () => heroRepo.Remove(" "));
    }

    [Test]
    public void GetHeroWithHighestLevel_ShouldReturn_HeroWithHighestLever()
    {
        var heroRepo = new HeroRepository();
        var underleveledHero = new Hero("Steve", 64);
        var overpoweredHero = new Hero("Pizza Steve", 128);

        heroRepo.Create(underleveledHero);
        heroRepo.Create(overpoweredHero);

        Assert.AreSame(
            overpoweredHero,
            heroRepo.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHero_WithValidName_ShouldReturnHero()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Pizza Steve", 128);

        heroRepo.Create(hero);

        Assert.AreSame(
            hero,
            heroRepo.GetHero("Pizza Steve"));
    }

    [Test]
    public void GetHero_WithInvalidName_ShouldReturnNull()
    {
        var heroRepo = new HeroRepository();
        var hero = new Hero("Pizza Steve", 128);

        heroRepo.Create(hero);

        Assert.AreSame(
            null,
            heroRepo.GetHero("Pizza Stiiv"));
    }
}