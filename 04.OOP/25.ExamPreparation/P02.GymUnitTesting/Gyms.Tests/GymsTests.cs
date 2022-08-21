using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [TestCaseSource("ConstructorWithValidData")]
        public void Constructor_WithValidData_ShouldInitialize(
            string name,
            int size)
        {
            Gym gym = new Gym(name, size);

            Assert.AreEqual(name, gym.Name);
        }

        [TestCaseSource("ConstructorWithInvalidName")]
        public void Constructor_WithInvalidName_ShouldThrowArgumentNullException(
            string name,
            int size)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, size);
            });
        }

        [TestCaseSource("ConstructorWithValidData")]
        public void Constructor_WithValidSize_ShouldInitialize(
            string name,
            int size)
        {
            Gym gym = new Gym(name, size);

            Assert.AreEqual(size, gym.Capacity);
        }

        [TestCaseSource("ConstructorWithInvalidCapacity")]
        public void Constructor_WithInvalidCapacity_ShouldThrowArgumentException(
            string name,
            int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym(name, size);
            });
        }

        [TestCaseSource("CountWithCorrectExpectedCount")]
        public void Count_WithAddedAthletes_AndCorrectExpectedCount_ShouldPass(
            Gym gym,
            Athlete[] athletes,
            int expectedCount)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Assert.AreEqual(expectedCount, gym.Count);
        }

        [TestCaseSource("CountWithIncorrectExpectedCount")]
        public void Count_WithAddedAthletes_AndIncorrectExpectedCount_ShouldFail(
            Gym gym,
            Athlete[] athletes,
            int expectedCount)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Assert.IsFalse(expectedCount == gym.Count);
        }

        [TestCaseSource("AddAthleteWithoutPassingGymCapacity")]
        public void AddAthlete_WithoutPassingGymCapacity_ShouldAdd(
            Gym gym,
            Athlete[] athletes,
            Athlete additionalAthlete,
            int expectedCount)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            gym.AddAthlete(additionalAthlete);

            Assert.AreEqual(expectedCount, gym.Count);
        }

        [TestCaseSource("AddAthletePassingGymCapacity")]
        public void AddAthlete_PassingCapacity_ShouldThrowInvalidOperationException(
            Gym gym,
            Athlete[] athletes,
            Athlete extraAthlete)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(extraAthlete);
            });
        }

        [TestCaseSource("RemoveAthleteWithValidName")]
        public void RemoveAthlete_WithValidName_ShouldRemove(
            Gym gym,
            Athlete[] athletes,
            string removedAthleteName,
            int expectedCount)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            gym.RemoveAthlete(removedAthleteName);

            Assert.AreEqual(expectedCount, gym.Count);
        }

        [TestCaseSource("RemoveAthleteWithInvalidName")]
        public void RemoveAthlete_WithInvalidName_ShouldThrowInvalidOperationException(
            Gym gym,
            Athlete[] athletes,
            string removedAthleteName)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(removedAthleteName);
            });
        }

        [TestCaseSource("InjureAthleteWithValidName")]
        public void InjureAthlete_WithValidName_ShouldInjureAthlete(
            Gym gym,
            Athlete[] athletes,
            Athlete expectedAthlete,
            string injuredAthleteName)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Athlete injuredAthlete = gym.InjureAthlete(injuredAthleteName);

            Assert.AreSame(expectedAthlete.FullName, injuredAthlete.FullName);
        }

        [TestCaseSource("InjureAthleteWithInvalidName")]
        public void InjureAthlete_WithInvalidName_ShouldThrowInvalidOperationException(
            Gym gym,
            Athlete[] athletes,
            string injuredAthleteName)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(injuredAthleteName);
            });
        }

        [TestCaseSource("Report")]
        public void Report_ShouldPass(
            Gym gym,
            Athlete[] athletes,
            string expectedReport)
        {
            foreach (var athlete in athletes)
            {
                gym.AddAthlete(athlete);
            }

            Assert.AreEqual(expectedReport, gym.Report());
        }

        public static IEnumerable<TestCaseData> Report()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 4),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                    },
                    "Active athletes at Stomanenata Bicaga: Ivanskiq, Brata na Ivanskiq"
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 5),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    "Active athletes at Kvadratniq Spongj Gym: Sponj Bop, Patrice, Squidwart, Mistar Krab, Plankerton"
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 2),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    "Active athletes at Bubblegum Gym: Finn the Human, Jake the Dog"
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }


        public static IEnumerable<TestCaseData> InjureAthleteWithInvalidName()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 4),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    "Poznat na kogo?"
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 5),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    "Squidward"
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 2),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    "Jake the Human"
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> InjureAthleteWithValidName()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 4),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    new Athlete("Poznat na Ivanskiq"),
                    "Poznat na Ivanskiq"
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 5),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    new Athlete("Squidwart"),
                    "Squidwart"
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 2),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    new Athlete("Jake the Dog"),
                    "Jake the Dog"
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> RemoveAthleteWithInvalidName()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 4),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    "Brata na Ivanskiq li?"
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 5),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    "Mistar Krabs"
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 2),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    "Finn the Dog"
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> RemoveAthleteWithValidName()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 4),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    "Brata na Ivanskiq",
                    3
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 5),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    "Mistar Krab",
                    4
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 2),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    "Finn the Human",
                    1
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> AddAthletePassingGymCapacity()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 4),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    new Athlete("Joro")
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 5),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    new Athlete("Sendi Katerica")
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 2),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    new Athlete("Ice King")
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> AddAthleteWithoutPassingGymCapacity()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 5),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    new Athlete("Bratanskiq"),
                    5
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 50),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    new Athlete("Sestrenskiq"),
                    6
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 3),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    new Athlete("Bruh"),
                    3
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> CountWithIncorrectExpectedCount()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 5),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    52
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 50),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    51
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 3),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    25
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> CountWithCorrectExpectedCount()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Gym("Stomanenata Bicaga", 5),
                    new Athlete[]
                    {
                        new Athlete("Ivanskiq"),
                        new Athlete("Brata na Ivanskiq"),
                        new Athlete("Poznat na Ivanskiq"),
                        new Athlete("Ivanski na Ivanskiq")
                    },
                    4
                    ),
                new TestCaseData(
                    new Gym("Kvadratniq Spongj Gym", 50),
                    new Athlete[]
                    {
                        new Athlete("Sponj Bop"),
                        new Athlete("Patrice"),
                        new Athlete("Squidwart"),
                        new Athlete("Mistar Krab"),
                        new Athlete("Plankerton")
                    },
                    5
                    ),
                new TestCaseData(
                    new Gym("Bubblegum Gym", 3),
                    new Athlete[]
                    {
                        new Athlete("Finn the Human"),
                        new Athlete("Jake the Dog")
                    },
                    2
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> ConstructorWithInvalidCapacity()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "Iron Gym",
                    -2
                    ),
                new TestCaseData(
                    "Incredible Power Brat",
                    -100
                    ),
                new TestCaseData(
                    "Desparate Gains Make Desparate Pains?",
                    -1
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> ConstructorWithInvalidName()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    null,
                    25
                    ),
                new TestCaseData(
                    "",
                    100
                    ),
                new TestCaseData(
                    "",
                    1
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> ConstructorWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "Iron Gym",
                    25
                    ),
                new TestCaseData(
                    "Incredible Power Brat",
                    100
                    ),
                new TestCaseData(
                    "Desparate Gains Make Desparate Pains?",
                    1
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }
    }
}
