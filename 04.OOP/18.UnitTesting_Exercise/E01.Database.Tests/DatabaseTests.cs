namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 4, 55, 89, 70, 555 })]
        [TestCase(new[] { int.MaxValue, int.MinValue, 2321 })]
        [TestCase(new int[0])]
        public void Test_Constructor_Should_Pass_With_Valid_Data(
            int[] paramaters)
        {
            Database database = new Database(paramaters);

            Assert.AreEqual(
                paramaters.Length,
                database.Count);
        }

        [TestCase(
            new[] { 1, 2 },
            new[] { 2, 3, 4, 5, 6 },
            7)]
        public void Test_Adding_Valid_Data_Should_Pass(
            int[] ctorParams,
            int[] paramsToAdd,
            int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(
            new[] { 1, 2 },
            new[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            7)]
        public void Test_Adding_More_Data_Than_Array_Size_Should_Fail(
            int[] ctorParams,
            int[] paramsToAdd,
            int errorParam)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(errorParam);
            });
        }

        [TestCase(
            new[] { 1, 2 },
            new[] { 3, 4, 5 },
            3,
            2)]
        public void Test_Remove_With_Valid_Data_Should_Pass(
            int[] ctorParams,
            int[] paramsToAdd,
            int removeCount,
            int excpectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(excpectedCount, database.Count);
        }

        [TestCase(
            new[] { 1, 2, 3, 4, 5 },
            5)]
        public void Test_Remove_From_Empty_Array_Should_Not_Pass(
            int[] ctorParams,
            int removeCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [TestCase(
            new int[] { 10, 10, 20 },
            new int[] { 50, 40, 1000 },
            2,
            new int[] {10, 10, 20, 50})]
        public void Test_Fetch_With_Valid_Data_Should_Pass(
            int[] ctorParams,
            int[] paramsToAdd,
            int removeCount,
            int[] expectedArray)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            int[] finalData = database.Fetch();

            Assert.AreEqual(expectedArray, finalData);
        }
    }
}
