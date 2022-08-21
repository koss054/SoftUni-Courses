namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void Constructor_WithValidData_ShouldInitialize()
        {
            string expectedAquariumName = "Ribki";
            var aquarium = new Aquarium("Ribki", 20);

            Assert.AreEqual(
                expectedAquariumName,
                aquarium.Name);
        }

        [Test]
        public void Constructor_WithNullName_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(null, 2);
            });
        }

        [Test]
        public void Constructor_WithEmptyName_ShouldThrow_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium("", 2);
            });
        }

        [Test]
        public void Constructor_WithValidCapacity_ShouldGet_CorrectCapacity()
        {
            int expectedCapacity = 2;
            var aquarium = new Aquarium("Fishies", 2);

            Assert.AreEqual(
                expectedCapacity,
                aquarium.Capacity);
        }

        [Test]
        public void Constructor_WithCapacityBelowZero_ShouldThrow_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("Fishiiiies", -20);
            });
        }

        [Test]
        public void Constructor_WithValidData_ShouldReturn_FishCount()
        {
            int expectedCount = 0;
            var aquarium = new Aquarium("Empty Means Sad", 200);

            Assert.AreEqual(
                expectedCount,
                aquarium.Count);
        }

        [Test]
        public void Add_WithFishBelowCapacity_ShouldAdd()
        {
            int expectedCount = 3;
            var aquarium = new Aquarium("Swamp Biome Update", 64);

            var fishOne = new Fish("Steve tha Fish");
            var fishTwo = new Fish("Viliger Fish");
            var fishThree = new Fish("Silverfish Fish?");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);
            aquarium.Add(fishThree);

            Assert.AreEqual(
                expectedCount,
                aquarium.Count);
        }

        [Test]
        public void Add_WithFishOverCapacity_ShouldThrow_InvalidOperationException()
        {
            var aquarium = new Aquarium("Empty Means Happy", 0);
            var fish = new Fish("Bruh Fish");

            Assert.Throws<InvalidOperationException>(
                () => aquarium.Add(fish));
        }

        [Test]
        public void Remove_WithValidFishName_ShouldRemove()
        {
            int expectedCount = 1;
            var aquarium = new Aquarium("Interesting Place", 2);
            var fishOne = new Fish("Bruh Fish");
            var fishTwo = new Fish("Brat Riba");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);
            aquarium.RemoveFish("Brat Riba");

            Assert.AreEqual(
                expectedCount,
                aquarium.Count);
        }

        [Test]
        public void Remove_WithInvalidFishName_ShouldThrow_InvalidOperationException()
        {
            var aquarium = new Aquarium("Interesting Place", 2);
            var fishOne = new Fish("Bruh Fish");
            var fishTwo = new Fish("Brat Riba");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            Assert.Throws<InvalidOperationException>(
                () => aquarium.RemoveFish("Brüder Fisch"));
        }

        [Test]
        public void SellFish_WithValidFishName_ShouldReturn_SoldFish()
        {
            string expectedFishName = "Brat Riba";
            var aquarium = new Aquarium("Interesting Place", 2);
            var fishOne = new Fish("Bruh Fish");
            var fishTwo = new Fish("Brat Riba");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            var soldFish = aquarium.SellFish("Brat Riba");

            Assert.AreEqual(
                expectedFishName,
                soldFish.Name);
        }

        [Test]
        public void SellFish_WithInvalidFishName_ShouldThrow_InvalidOperationException()
        {
            var aquarium = new Aquarium("Interesting Place", 2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var soldFish = aquarium.SellFish("Brat Riba");
            });
        }

        [Test]
        public void Report_ShouldReturn_NamesOfFish_InAquarium()
        {
            string expectedReport = "Fish available at Interesting Place: Bruh Fish, Brat Riba";
            var aquarium = new Aquarium("Interesting Place", 2);
            var fishOne = new Fish("Bruh Fish");
            var fishTwo = new Fish("Brat Riba");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            Assert.AreEqual(
                expectedReport,
                aquarium.Report());
        }
    }
}
