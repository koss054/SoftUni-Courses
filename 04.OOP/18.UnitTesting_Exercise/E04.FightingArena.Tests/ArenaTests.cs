namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_ShouldCreate()
        {
            Arena arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [TestCaseSource("TestCaseEnrollWarriorWithValidData")]
        public void EnrollWarrior_WithValidData_ShouldEnrollWarrior(
           Warrior[] warriorsToAdd,
           int expectedCount)
        {
            Arena arena = new Arena();

            foreach (var warrior in warriorsToAdd)
            {
                arena.Enroll(warrior);
            }

            Assert.AreEqual(expectedCount, arena.Count);
        }

        [TestCaseSource("TestCaseEnrollWarriorWithDuplicateName")]
        public void EnrollWarrior_WithDuplicateNames_ShouldThrow(
           Warrior[] warriorsToAdd,
           Warrior duplicateWarrior)
        {
            Arena arena = new Arena();

            foreach (var warrior in warriorsToAdd)
            {
                arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(duplicateWarrior);
            });
        }

        [TestCaseSource("TestCaseFightWithExistingWarriors")]
        public void Fight_WithExistingWarrirors_ShouldStartFight(
           Warrior[] warriorsToAdd,
           Warrior defender,
           string attackerName,
           string defenderName,
           int expectedDefenderHP)
        {
            Arena arena = new Arena();

            foreach (var warrior in warriorsToAdd)
            {
                arena.Enroll(warrior);
            }

            arena.Enroll(defender);
            arena.Fight(attackerName, defenderName);

            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [TestCaseSource("TestCaseFightWithNonExistentWarrior")]
        public void Fight_WithNonExistentWarrior_ShouldThrow(
           Warrior[] warriorsToAdd,
           string attackerName,
           string deffenderName)
        {
            Arena arena = new Arena();

            foreach (var warrior in warriorsToAdd)
            {
                arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, deffenderName);
            });
        }

        public static IEnumerable<TestCaseData> TestCaseFightWithNonExistentWarrior()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Ereh", 100, 125),
                        new Warrior("Rainah", 75, 125),
                        new Warrior("Betrolol", 250, 2000)
                    },
                    "Ereh",
                    "Jojo"
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Levi", 1000, 150),
                        new Warrior("Zeke", 125, 150)
                    },
                    "Livi",
                    "Zeke"
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Armin", 35, 35),
                        new Warrior("Betrolol", 250, 2000),
                        new Warrior("Eren", 125, 100)
                    },
                    "Armein",
                    "Berthold"
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Mikasa", 75, 100),
                        new Warrior("Annie", 125, 100),
                        new Warrior("Yeren Jaegerrr", 75, 75),
                        new Warrior("Levi", 1250, 125)
                    },
                    "Mik",
                    "Asa"
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFightWithExistingWarriors()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Ereh", 100, 100),
                        new Warrior("Betrolol", 250, 2000)
                    },
                    new Warrior("Rainah", 75, 125),
                    "Ereh",
                    "Rainah",
                    25
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Levi", 1000, 125)
                    },
                    new Warrior("Zeke", 125, 150),
                    "Levi",
                    "Zeke",
                    0
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Armin", 35, 35),
                        new Warrior("Eren", 125, 125)
                    },
                    new Warrior("Betrolol", 100, 2000),
                    "Eren",
                    "Betrolol",
                    1875
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Mikasa", 75, 150),
                        new Warrior("Yeren Jaegerrr", 75, 75),
                        new Warrior("Levi", 1250, 125)
                    },
                    new Warrior("Annie", 125, 100),
                    "Mikasa",
                    "Annie",
                    25
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseEnrollWarriorWithDuplicateName()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Ereh", 100, 100),
                        new Warrior("Rainah", 75, 125),
                        new Warrior("Betrolol", 250, 2000)
                    },
                    new Warrior("Rainah", 70, 125)
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Levi", 1000, 100),
                        new Warrior("Zeke", 125, 150)
                    },
                    new Warrior("Levi", 100, 100)
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Armin", 35, 35),
                        new Warrior("Betrolol", 250, 2000),
                        new Warrior("Eren", 125, 100)
                    },
                    new Warrior("Betrolol", 20, 2000)
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Mikasa", 75, 100),
                        new Warrior("Annie", 125, 100),
                        new Warrior("Yeren Jaegerrr", 75, 75),
                        new Warrior("Levi", 1250, 125)
                    },
                    new Warrior("Mikasa", 755, 100)
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseEnrollWarriorWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior[] 
                    {
                        new Warrior("Ereh", 100, 100),
                        new Warrior("Rainah", 75, 125),
                        new Warrior("Betrolol", 250, 2000)
                    },
                    3
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Levi", 1000, 100),
                        new Warrior("Zeke", 125, 150)
                    },
                    2
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Armin", 35, 35),
                        new Warrior("Betrolol", 250, 2000),
                        new Warrior("Eren", 125, 100)
                    },
                    3
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("Mikasa", 75, 100),
                        new Warrior("Annie", 125, 100),
                        new Warrior("Yeren Jaegerrr", 75, 75),
                        new Warrior("Levi", 1250, 125)
                    },
                    4
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }
    }
}
