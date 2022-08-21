// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;

    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
        [Test]
        public void Constructor_ShouldInitialize()
        {
            var stage = new Stage();

            Assert.IsNotNull(stage.Performers);
        }

        [TestCaseSource("AddPerformerWithValidData")]
        public void AddPerformer_WithValidData_ShouldAdd(
            Stage stage,
            Performer[] performers,
            int excpectedCount)
        {
            foreach (var performer in performers)
            {
                stage.AddPerformer(performer);
            }

            Assert.AreEqual(excpectedCount, stage.Performers.Count);
        }

        [TestCaseSource("AddPerformerWithNullValue")]
        public void AddPerformer_WithNullValue_ShouldThrowArgumentNullException(
            Stage stage,
            Performer[] performers,
            Performer nullPerformer)
        {
            foreach (var performer in performers)
            {
                stage.AddPerformer(performer);
            }

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(nullPerformer);
            });
        }

        [TestCaseSource("AddPerformerWithAgeUnderLimit")]
        public void AddPerformer_WithAgeUnderLimit_ShouldThrowArgumentException(
            Stage stage,
            Performer[] performers,
            Performer youngPerformer)
        {
            foreach (var performer in performers)
            {
                stage.AddPerformer(performer);
            }

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(youngPerformer);
            });
        }

        [Test]
        public void AddSong_WithValidData_ShouldAdd()
        {
            Stage stage = new Stage();

            Assert.DoesNotThrow(() =>
            {
                stage.AddSong(new Song("Nineteen", new TimeSpan(0, 2, 57)));
            });
        }

        [Test]
        public void AddSong_WithNullValue_ShouldThrowArgumentNullException()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(null);
            });
        }

        [Test]
        public void AddSong_WithDurationLessThanAMinute_ShouldThrowArgumentException()
        {
            Stage stage = new Stage();
            Song shortSong = new Song("Ghost Boy", new TimeSpan(0, 0, 11));

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(shortSong);
            });
        }

        [Test]
        public void AddSongToPerformer_WithValidData_ShouldAdd()
        {
            var stage = new Stage();
            var performer = new Performer("Juice", "WRLD", 21);
            var song = new Song("Wasted", new TimeSpan(0, 4, 17));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            string expectedResult = $"{song} will be performed by {performer}";

            Assert.AreEqual(expectedResult, stage.AddSongToPerformer(song.Name, performer.FullName));
        }

        [Test]
        public void AddSongToPerformer_WithNullSong_ShouldThrowArgumentNullException()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer(null, "test");
            });
        }

        [Test]
        public void AddSongToPerformer_WithNullPerformer_ShouldThrowArgumentNullException()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer("test", null);
            });
        }

        [Test]
        public void AddSongToPerformer_WithMissingSongName_ShouldThrowArgumentException()
        {
            var stage = new Stage();
            var performer = new Performer("Lil", "Peep", 21);

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("missing name brother", performer.FullName);
            });
        }

        [Test]
        public void AddSongToPerformer_WithMissingPerformerName_ShouldThrowArgumentException()
        {
            var stage = new Stage();
            var song = new Song("Benz Truck", new TimeSpan(0, 2, 40));

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer(song.Name, "missing name brother");
            });
        }

        [Test]
        public void Play_WithValidData_ShouldPlay()
        {
            var stage = new Stage();
            var performer = new Performer("Lil", "Peep", 21);
            var song1 = new Song("Nineteen", new TimeSpan(0, 2, 57));
            var song2 = new Song("Gym Class", new TimeSpan(0, 3, 36));

            stage.AddPerformer(performer);

            stage.AddSong(song1);
            stage.AddSong(song2);

            stage.AddSongToPerformer(song1.Name, performer.FullName);
            stage.AddSongToPerformer(song2.Name, performer.FullName);

            string expectedResult = $"{stage.Performers.Count} performers played 2 songs";

            Assert.AreEqual(expectedResult, stage.Play());
        }

        [Test]
        public void GetPerformer_WithExistingName_ShouldGet()
        {
            var stage = new Stage();
            var performer = new Performer("XXX", "Tentacion", 21);

            string expectedName = "XXX Tentacion";

            stage.AddPerformer(performer);

        }

        // I stopped using this way of testing because the tests stayed with the Blue Exclamation mark, when trying to run them... D:
        public static IEnumerable<TestCaseData> AddSongWithDuritonLessThanAMinute()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Stage(),
                    new Song[]
                    {
                    new Song("Don't Go Outside", new TimeSpan(0, 2, 24))
                    },
                    new Song("Nerves", new TimeSpan(0, 0, 9))
                    ),
                new TestCaseData(
                    new Stage(),
                    new Song[]
                    {
                        new Song("Benz Truck", new TimeSpan(0, 2, 40)),
                        new Song("Nineteen", new TimeSpan(0, 2, 57)),
                        new Song("Gym Class", new TimeSpan(0, 3, 36))
                    },
                    new Song("Ghost Boy", new TimeSpan(0, 0, 11))
                    ),
                new TestCaseData(
                    new Stage(),
                    new Song[]
                    {
                        new Song("Wasted", new TimeSpan(0, 4, 17)),
                        new Song("Feel Alone", new TimeSpan(0, 3, 51))
                    },
                    new Song("Righteous", new TimeSpan(0, 0, 2))
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> AddPerformerWithAgeUnderLimit()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                    new Performer("Brat", "Mi", 20)
                    },
                    new Performer("Forreal", "Mi", 11)
                    ),
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                        new Performer("Rigby", "Bratoto", 21),
                        new Performer("Mordecai", "Bird", 22),
                        new Performer("Benson", "DaBoss", 44)
                    },
                    new Performer("Gum", "Ball", 13)
                    ),
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                        new Performer("Koi", "Fish", 221),
                        new Performer("Check", "Bio", 22)
                    },
                    new Performer("Finn", "Chovechito", 12)
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> AddPerformerWithNullValue()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                    new Performer("Brat", "Mi", 20)
                    },
                    null
                    ),
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                        new Performer("Rigby", "Bratoto", 21),
                        new Performer("Mordecai", "Bird", 22),
                        new Performer("Benson", "DaBoss", 44)
                    },
                    null
                    ),
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                        new Performer("Koi", "Fish", 221),
                        new Performer("Check", "Bio", 22)
                    },
                    null
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> AddPerformerWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                    new Performer("Brat", "Mi", 20)
                    },
                    1
                    ),
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                        new Performer("Rigby", "Bratoto", 21),
                        new Performer("Mordecai", "Bird", 22),
                        new Performer("Benson", "DaBoss", 44)
                    },
                    3
                    ),
                new TestCaseData(
                    new Stage(),
                    new Performer[]
                    {
                        new Performer("Koi", "Fish", 221),
                        new Performer("Check", "Bio", 22)
                    },
                    2
                    ),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }
    }
}