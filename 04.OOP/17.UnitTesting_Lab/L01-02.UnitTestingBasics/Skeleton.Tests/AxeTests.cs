using NUnit.Framework;
using Skeleton.Models;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Axe_Should_Lose_Durability_After_Attack()
        {
            IWeapon axe = new Axe(10, 10);
            IDummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test_Axe_Should_Not_Attack_After_Breaking()
        {
            IWeapon axe = new Axe(10, 1);
            IDummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}