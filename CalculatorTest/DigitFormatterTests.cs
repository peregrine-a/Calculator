using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace CalculatorTest
{
    [TestClass]
    public class DigitFormatterTests
    {
        [TestMethod]
        public void MyTest()
        {
            decimal value1 =  123;
            decimal value2 =  456;

            Assert.AreEqual(value1 + value2, 579);

            decimal value3 = 1000;
            decimal value4 =  234;

            Assert.AreEqual(value3 + value4, 1234);
        }

        // [TestMethod]
        // public void DigitFormatterTests()
        // {
        // }
    }
}
