namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {
        [TestCaseSource("TestCaseConstructorWithValidData")]
        public void Constructor_WithValidData_ShouldCreate(
           string name,
           int damage,
           int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
        }

        [TestCaseSource("TestCaseConstructorWithInvalidData")]
        public void Constructor_WithInvalidData_ShouldThrow(
           string name,
           int damage,
           int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [TestCaseSource("TestCaseAttackWithValidData")]
        public void Attack_WithValidData_ShouldAttack(
           Warrior warrior,
           Warrior enemy,
           int expectedHPLeft)
        {
            warrior.Attack(enemy);

            Assert.AreEqual(expectedHPLeft, enemy.HP);
        }

        [TestCaseSource("TestCaseAttackWithLowHP")]
        public void Attack_WithLowHP_ShouldThrow(
           Warrior warrior,
           Warrior enemy)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
        }

        [TestCaseSource("TestCaseAttackEnemyWithLowHP")]
        public void Attack_EnemyWithLowHP_ShouldThrow(
           Warrior warrior,
           Warrior enemy)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
        }

        [TestCaseSource("TestCaseAttackStrongerEnemy")]
        public void Attack_StrongerEnemy_ShouldThrow(
           Warrior warrior,
           Warrior enemy)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
        }

        public static IEnumerable<TestCaseData> TestCaseAttackStrongerEnemy()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior("Erehh", 100, 70),
                    new Warrior("Rainah", 75, 125)
                    ),
                new TestCaseData(
                    new Warrior("Levi", 1000, 100),
                    new Warrior("Zeke", 125, 150)
                    ),
                new TestCaseData(
                    new Warrior("Armin", 35, 35),
                    new Warrior("Betrolol", 250, 2000)
                    ),
                new TestCaseData(
                    new Warrior("Mikasa", 75, 100),
                    new Warrior("Annie", 125, 100)
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAttackEnemyWithLowHP()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior("Erehh", 100, 100),
                    new Warrior("Rainah", 75, 20)
                    ),
                new TestCaseData(
                    new Warrior("Levi", 1000, 125),
                    new Warrior("Zeke", 125, 30)
                    ),
                new TestCaseData(
                    new Warrior("Armin", 35, 250),
                    new Warrior("Betrolol", 250, 10)
                    ),
                new TestCaseData(
                    new Warrior("Mikasa", 75, 130),
                    new Warrior("Annie", 125, 0)
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAttackWithLowHP()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior("Erehh", 100, 30),
                    new Warrior("Rainah", 75, 125)
                    ),
                new TestCaseData(
                    new Warrior("Levi", 1000, 20),
                    new Warrior("Zeke", 125, 150)
                    ),
                new TestCaseData(
                    new Warrior("Armin", 35, 10),
                    new Warrior("Betrolol", 250, 2000)
                    ),
                new TestCaseData(
                    new Warrior("Mikasa", 75, 0),
                    new Warrior("Annie", 125, 100)
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAttackWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior("Erehh", 100, 100),
                    new Warrior("Rainah", 75, 125),
                    25
                    ),
                new TestCaseData(
                    new Warrior("Levi", 1000, 125),
                    new Warrior("Zeke", 125, 150),
                    0
                    ),
                new TestCaseData(
                    new Warrior("Armin", 35, 250),
                    new Warrior("Betrolol", 250, 2000),
                    1965
                    ),
                new TestCaseData(
                    new Warrior("Mikasa", 75, 130),
                    new Warrior("Annie", 125, 100),
                    25
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorWithInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "",
                    100000,
                    100000
                    ),
                new TestCaseData(
                    " ",
                    1000000,
                    20000
                    ),
                new TestCaseData(
                    "Betroldo",
                    0,
                    2444
                    ),
                new TestCaseData(
                    "Rainah",
                    102034,
                    -10
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "Ereh",
                    100000,
                    100000
                    ),
                new TestCaseData(
                    "Levi",
                    1000000,
                    20000
                    ),
                new TestCaseData(
                    "Betroldo",
                    2000,
                    2444
                    ),
                new TestCaseData(
                    "Rainah",
                    102034,
                    200000
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }
    }
}