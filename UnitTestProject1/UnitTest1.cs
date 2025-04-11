using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VoroninEkz;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public Discount discoun = new Discount();
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            double totalSales = 6666;
            int expectedDiscount = 0;

            // Act
            var result = discoun.FoundDiscount(totalSales);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            double totalSales = 33333;
            int expectedDiscount = 5;

            // Act
            var result = discoun.FoundDiscount(totalSales);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            double totalSales = 111111;
            int expectedDiscount = 10;

            // Act
            var result = discoun.FoundDiscount(totalSales);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }
        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            double totalSales = 333333;
            int expectedDiscount = 15;

            // Act
            var result = discoun.FoundDiscount(totalSales);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }
        [TestMethod]
        public void TestMethod5()
        {
            // Arrange
            double totalSales = 123456;
            int expectedDiscount = 10;

            // Act
            var result = discoun.FoundDiscount(totalSales);

            // Assert
            Assert.AreEqual(expectedDiscount, result);
        }
    }
}
