namespace Robots.Tests
{
    using Robots;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Constructor_WithValidData_ShouldInitialize()
        {
            int expectedCapacity = 10;
            var robotManager = new RobotManager(expectedCapacity);

            Assert.AreEqual(
                expectedCapacity,
                robotManager.Capacity);
        }

        [Test]
        public void Capacity_WithInvalidData_ShouldThrow_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var robotManager = new RobotManager(-20);
            });
        }

        [Test]
        public void Count_WithValidData_ShouldPass()
        {
            int expectedCount = 0;
            var robotManager = new RobotManager(10);

            Assert.AreEqual(
                expectedCount,
                robotManager.Count);
        }

        [Test]
        public void Add_WithValidData_ShouldPass()
        {
            var robotManger = new RobotManager(20);
            var robot = new Robot("Brother Bruh", 20);
            var expectedCountAfterAdding = 1;

            robotManger.Add(robot);

            Assert.AreEqual(
                expectedCountAfterAdding,
                robotManger.Count);
        }

        [Test]
        public void Add_WithExistingRobotName_ShouldThrow_InvalidOperationException()
        {
            var robotManger = new RobotManager(20);
            var robotOG = new Robot("Naruto", 1000);
            var robotFake = new Robot("Naruto", 10);

            robotManger.Add(robotOG);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManger.Add(robotFake);
            });
        }

        [Test]
        public void Add_WithNotEnoughCapacity_ShouldThrow_InvalidOperationException()
        {
            var robotManager = new RobotManager(0);
            var sadRobot = new Robot("Zagreus", 1000);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(sadRobot);
            });
        }

        [Test]
        public void Remove_WithValidData_ShouldPass()
        {
            int expectedCountAfterRemoving = 1;
            var robotManager = new RobotManager(2);
            var donActDumRobot = new Robot("Houston", 200);
            var iNeedAMedicRobot = new Robot("Dallas", 20);

            robotManager.Add(donActDumRobot);
            robotManager.Add(iNeedAMedicRobot);
            robotManager.Remove("Dallas");

            Assert.AreEqual(
                expectedCountAfterRemoving,
                robotManager.Count);
        }

        [Test]
        public void Remove_WithMissingRobotName_ShouldThrow_InvalidOperationException()
        {
            var robotManager = new RobotManager(2);
            var donActDumRobot = new Robot("Houston", 200);
            var iNeedAMedicRobot = new Robot("Dallas", 20);

            robotManager.Add(donActDumRobot);
            robotManager.Add(iNeedAMedicRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Hoxton");
            });
        }

        [Test]
        public void Work_WithValidData_ShouldPass()
        {
            int expectedBatteryAfterWork = 80;
            var robotManager = new RobotManager(20);
            var builderRobot = new Robot("Builder from Clash of Clans", 100);

            robotManager.Add(builderRobot);
            robotManager.Work("Builder from Clash of Clans", "Upgrade Town Hall", 20);

            Assert.AreEqual(
                expectedBatteryAfterWork,
                builderRobot.Battery);
        }

        [Test]
        public void Work_WithMissingRobotName_ShouldThrow_InvalidOperationException()
        {
            var robotManager = new RobotManager(20);
            var builderRobot = new Robot("Builder from Clash of Clans", 100);

            robotManager.Add(builderRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Builder from Clash of Kings", "Upgrade City Hall", 25);
            });
        }

        [Test]
        public void Work_WithBatteryLowerThanUsage_ShouldThrow_InvalidOperationException()
        {
            var robotManager = new RobotManager(20);
            var builderRobot = new Robot("Builder from the Fight of Towns", 100);

            robotManager.Add(builderRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Builder from the Fight of Towns", "Upgrade Town Center", 250);
            });
        }

        [Test]
        public void Charge_WithValidData_ShouldPass()
        {
            var robotManager = new RobotManager(20);
            var builderRobot = new Robot("Builder from Clash of Clashers", 100);

            robotManager.Add(builderRobot);
            robotManager.Work("Builder from Clash of Clashers", "Upgrade Clash Hall", 50);
            robotManager.Charge("Builder from Clash of Clashers");

            Assert.AreEqual(
                builderRobot.MaximumBattery,
                builderRobot.Battery);
        }

        [Test]
        public void Charge_WithValidMissingRobotName_ShouldThrow_InvalidOperationException()
        {
            var robotManager = new RobotManager(20);
            var builderRobot = new Robot("Builder from Town of Clashers", 100);

            robotManager.Add(builderRobot);
            robotManager.Work("Builder from Town of Clashers", "Upgrade Clash Town", 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Steve");
            });
        }
    }
}
