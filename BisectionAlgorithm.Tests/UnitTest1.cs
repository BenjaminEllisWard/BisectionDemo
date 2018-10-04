using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BisectionAlgorithm.Tests
{
    [TestClass]
    public class UnitTest1
    {
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
