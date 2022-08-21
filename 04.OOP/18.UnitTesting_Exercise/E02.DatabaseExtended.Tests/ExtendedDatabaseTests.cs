namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        public Person mordy;
        public Person rigy;

        [SetUp]
        public void TestInitialization()
        {
            mordy = new Person(1, "Mordekaiiii");
            rigy = new Person(2, "Rigby");
        }

        [TestCase(2)]
        public void Constructor_ShouldInitialize_Collection(int expectedCount)
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(3)]
        public void Add_ShouldAdd_ValidPerson(int expectedCount)
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Person newPerson = new Person(3, "Benson?");
            database.Add(newPerson);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Add_SameUsername_ShouldThrow()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Person invalidPerson = new Person(23, "Rigby");

            Assert.That(() => database.Add(invalidPerson),
                Throws.InvalidOperationException);
        }

        [Test]
        public void Add_SameId_ShouldThrow()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Person invalidPerson = new Person(1, "Muscle Man");

            Assert.That(() => database.Add(invalidPerson),
                Throws.InvalidOperationException);
        }

        [TestCase(1)]
        public void Remove_ShouldRemove_ValidPerson(int expectedCount)
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Remove_EmptyDatabase_ShouldThrow()
        {
            Person[] noPeople = new Person[] { };
            Database database = new Database(noPeople);

            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_ShouldReturn_ExistingPerson()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Person expectedPerson = mordy;
            Person foundPerson = database.FindByUsername("Mordekaiiii");

            Assert.AreEqual(expectedPerson, foundPerson);
        }

        [Test]
        public void FindByUsername_ShouldThrow_NonExistingPerson()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Assert.That(() => database.FindByUsername("High Fives"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_ShouldThrow_NullName()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Assert.That(() => database.FindByUsername(""),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsername_IsCaseSensitive()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Assert.That(() => database.FindByUsername("MoRDEkaiiii"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindById_ShouldReturnPerson_ExistingPerson()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Person expectedPerson = mordy;
            Person foundPerson = database.FindById(1);

            Assert.AreEqual(expectedPerson, foundPerson);
        }

        [Test]
        public void FindById_ShouldThrow_NonExistingPerson()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Assert.That(() => database.FindById(4201337),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindById_ShouldThrow_NegativeArgument()
        {
            Person[] peopleToAdd = new Person[] { mordy, rigy };
            Database database = new Database(peopleToAdd);

            Assert.That(() => database.FindById(-44),
                Throws.Exception);
        }

        //The code below doesn't pass with 100/100 - it gives 100/100 when combined with the tests above :/
        [TestCaseSource("TestCaseConstructorData")]
        public void Test_Database_Constructor_Should_Create(
            Person[] people,
            int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(
                expectedCount,
                database.Count);
        }

        [TestCaseSource("TestCaseAddData")]
        public void Test_Database_Should_Add_People(
            Person[] peopleCtor,
            Person[] peopleToAdd,
            int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(
                expectedCount,
                database.Count);
        }

        [TestCaseSource("TestCaseAddWithInvalidData")]
        public void Test_Database_Add_Method_With_Invalid_Data_Should_Throw_Exception(
            Person[] peopleCtor,
            Person[] peopleToAdd,
            Person invalidPerson)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(invalidPerson);
            });
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Test_Database_Should_Remove_People(
            Person[] peopleCtor,
            int expectedCount)
        {
            Database database = new Database(peopleCtor);

            database.Remove();

            Assert.AreEqual(
                expectedCount,
                database.Count);
        }

        [TestCaseSource("TestCaseRemoveWithInvalidData")]
        public void Test_Database_Remove_Method_With_Invalid_Data_Should_Throw_Exception(
            Person person)
        {
            Database database = new Database(person);

            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [TestCaseSource("TestCaseFindPersonDataByName")]
        public void Test_Database_Find_Person_By_Name(
            Person[] personCtor,
            string nameToFind)
        {
            Database database = new Database(personCtor);
            Person foundPerson = database.FindByUsername(nameToFind);

            Assert.IsNotNull(foundPerson);
        }

        [TestCaseSource("TestCaseFindMissingPersonDataByNameShouldThrow")]
        public void Test_Database_Should_Not_Find_Missing_Username(
            Person[] personCtor,
            string nameToFind)
        {
            Database database = new Database(personCtor);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(nameToFind);
            });
        }

        [TestCaseSource("TestCaseFindPersonWithNullNameShouldThrow")]
        public void Test_Database_Should_Not_Find_Person_With_Null_Name(
            Person[] personCtor,
            string nameToFind)
        {
            Database database = new Database(personCtor);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(nameToFind);
            });
        }

        [TestCaseSource("TestCaseFindPersonDataById")]
        public void Test_Database_Find_Person_By_Id(
            Person[] personCtor,
            int idToFind)
        {
            Database database = new Database(personCtor);
            Person foundPerson = database.FindById(idToFind);

            Assert.IsNotNull(foundPerson);
        }

        [TestCaseSource("TestCaseFindIdWithNegativeNumberShouldThrow")]
        public void Test_Database_Should_Not_Find_Person_With_Negative_Id(
            Person[] personCtor,
            int idToFind)
        {
            Database database = new Database(personCtor);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(idToFind);
            });
        }

        [TestCaseSource("TestCaseFindIdWithMissingIdShouldThrow")]
        public void Test_Database_Should_Not_Find_Person_With_Missing_Id(
            Person[] personCtor,
            int idToFind)
        {
            Database database = new Database(personCtor);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(idToFind);
            });
        }

        public static IEnumerable<TestCaseData> TestCaseFindIdWithMissingIdShouldThrow()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(234, "NoNameFame"),
                    new Person(22222, "WhoRU?"),
                    new Person(22, "Ivanski")
                },
                111
                );
        }

        public static IEnumerable<TestCaseData> TestCaseFindIdWithNegativeNumberShouldThrow()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(234, "NoNameFame"),
                    new Person(22222, "WhoRU?"),
                    new Person(22, "Ivanski")
                },
                -55
                );
        }

        public static IEnumerable<TestCaseData> TestCaseFindPersonDataById()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(234, "NoNameFame"),
                    new Person(22222, "WhoRU?"),
                    new Person(22, "Ivanski")
                },
                234
                );
        }

        public static IEnumerable<TestCaseData> TestCaseFindPersonWithNullNameShouldThrow()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(234, "NoNameFame"),
                    new Person(22222, "WhoRU?"),
                    new Person(22, "Ivanski")
                },
                null
                );

            yield return new TestCaseData(
                new Person[]
                {
                    new Person(2234, "aaaaaa"),
                    new Person(2342222, "bbbbbbbb?"),
                    new Person(224, "Ivcccanski")
                },
                ""
                );
        }

        public static IEnumerable<TestCaseData> TestCaseFindMissingPersonDataByNameShouldThrow()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(234, "NoNameFame"),
                    new Person(22222, "WhoRU?"),
                    new Person(22, "Ivanski")
                },
                "NoNameFarm"
                );
        }

        public static IEnumerable<TestCaseData> TestCaseFindPersonDataByName()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(234, "NoNameFame"),
                    new Person(22222, "WhoRU?"),
                    new Person(22, "Ivanski")
                },
                "NoNameFame"
                );
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveWithInvalidData()
        {
            yield return new TestCaseData(
                new Person(22, "Finn")
                );
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(1, "maniqk203"),
                    new Person(2, "maniqk2333")
                },
                1
                );

            yield return new TestCaseData(
                new Person[]
                {
                    new Person(133, "maniqk2030000")
                },
                0
                );
        }

        public static IEnumerable<TestCaseData> TestCaseAddWithInvalidData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(1, "maniqk203"),
                    new Person(2, "maniqk2333")
                },
                new Person[]
                {
                    new Person(3, "Siromassi22"),
                    new Person(4, "KolioKolevKolevi"),
                    new Person(5, "rigbny"),
                    new Person(6, "mortiocn"),
                    new Person(7, "lolipops"),
                    new Person(8, "gagdad"),
                    new Person(9, "musclemanann"),
                    new Person(10, "wattdsftttt20"),
                    new Person(11, "highfives"),
                    new Person(12, "bensont"),
                    new Person(13, "2fffff3"),
                    new Person(14, "margaritka"),
                    new Person(15, "[park"),
                    new Person(16, "watttshowttt20"),
                },
                new Person(17, "jakeTheDog22")
                );

            yield return new TestCaseData(
                new Person[]
                {
                },
                new Person[]
                {
                    new Person(1, "maniqk203"),
                    new Person(2, "maniqk2333")
                },
                new Person(2, "maniqk2333")
                );

            yield return new TestCaseData(

                new Person[]
                {
                    new Person(5, "bruh4e"),
                    new Person(22, "molqqqq"),
                    new Person(344, "brother")
                },
                new Person[]
                {
                },
                new Person(5, "finnTheHuman")
                );
        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(1, "maniqk203"),
                    new Person(2, "maniqk2333")
                },
                new Person[]
                {
                    new Person(22, "Siromassi22"),
                    new Person(33, "KolioKolevKolevi"),
                    new Person(22112, "watttttt20")
                },
                5);

            yield return new TestCaseData(
                new Person[]
                {
                },
                new Person[]
                {
                    new Person(1, "maniqk203"),
                    new Person(2, "maniqk2333")
                },
                2);

            yield return new TestCaseData(

                new Person[]
                {
                    new Person(5, "bruh4e"),
                    new Person(22, "molqqqq"),
                    new Person(344, "brother")
                },
                new Person[]
                {
                },
                3);
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(1, "maniqk203"),
                    new Person(2, "maniqk2333")
                },
                2);

            yield return new TestCaseData(
                new Person[]
                {
                },
                0);

            yield return new TestCaseData(

                new Person[]
                {
                    new Person(5, "bruh4e"),
                    new Person(22, "molqqqq"),
                    new Person(344, "brother")
                },
                3);
        }
    }
}