using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BisectionAlgorithm.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // I used this test to confirm the bound of the second Random.Next() parameter.
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            Random rnd = new Random();
            int compare = 0;

            // act
            int test = rnd.Next(0, 2);

            // assert
            Assert.AreEqual(compare, test);
        }
    }
}
