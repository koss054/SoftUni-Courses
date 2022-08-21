using NUnit.Framework;
using Skeleton.Models;
using System;

namespace Skeleton
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_Dummy_Should_Lose_Health_When_Attacked()
        {
            IWeapon axe = new Axe(5, 5);
            IDummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void Test_Dead_Dummy_Should_Throw_Exception_When_Dead()
        {
            IWeapon axe = new Axe(5, 5);
            IDummy deadDummy = new Dummy(0, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(deadDummy);
            });
        }

        [Test]
        public void Test_Dead_Dummy_Should_Give_Experience()
        {
            IWeapon axe = new Axe(1000, 100);
            IDummy dummy = new Dummy(10, 20);
            int gainedExperience = 0;

            axe.Attack(dummy);
            gainedExperience = dummy.GiveExperience();

            Assert.AreEqual(20, gainedExperience);
        }

        [Test]
        public void Test_Alive_Dummy_Should_Not_Give_Experience()
        {
            IWeapon axe = new Axe(1, 10);
            IDummy dummy = new Dummy(1000, 20);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}