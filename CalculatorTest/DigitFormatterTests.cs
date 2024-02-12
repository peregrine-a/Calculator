using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using System.Diagnostics;

namespace CalculatorTest
{
    [TestClass]
    public class DigitFormatterTests
    {
        /// <summary>
        /// 標準的な値のテスト
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            decimal value = 0;
            string digits = null;
            uint maxDigits = 20;

            /* 0 -> "0" */
            value = 0;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "0");

            /* 1 -> "1" */
            value = 1;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "1");

            /* 0.1 -> "0.1" */
            value = (decimal)0.1;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "0.1");

            /* 123.456 -> "123.456" */
            value = (decimal)123.456;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "123.456");

            /* 4/5 0> "0.8" */
            value = (decimal)4 / (decimal)5;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "0.8");

            /* -1 -> "-1" */
            value = (decimal) -1;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-1");

        }

        /// <summary>
        /// 最大桁数のテスト
        /// </summary>
        [TestMethod]
        public void MaxValueTest()
        {
            decimal value = 0;
            string digits = null;
            uint maxDigits = 20;

            /* 99999999999999999999 (max) -> "99999999999999999999" */
            value = Decimal.Parse("99999999999999999999");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "99999999999999999999");

            /* 100000000000000000000 -> null */
            value = Decimal.Parse("100000000000000000000") + (decimal) 1;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, null);

            /* 99999999999999999999.000 (max) -> 99999999999999999999 */
            value = Decimal.Parse("99999999999999999999.000");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "99999999999999999999");

            /* 99999999999999999999.1 -> 99999999999999999999 */
            value = Decimal.Parse("99999999999999999999.1");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "99999999999999999999");

            /* 99999999999999999999.999999 -> 99999999999999999999 */
            value = Decimal.Parse("99999999999999999999.999999");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "99999999999999999999");

        }

        /// <summary>
        /// 最小桁数のテスト
        /// </summary>
        [TestMethod]
        public void MinValueTest()
        {
            decimal value = 0;
            string digits = null;
            uint maxDigits = 20;

            /* -9999999999999999999 (min) -> "-9999999999999999999" */
            value = Decimal.Parse("-9999999999999999999");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-9999999999999999999");

            /* -10000000000000000000 -> null */
            value = Decimal.Parse("-10000000000000000000");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, null);

            /* -9999999999999999999.1 -> "-9999999999999999999" */
            value = Decimal.Parse("-9999999999999999999.1");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-9999999999999999999");

            /* -9999999999999999999.999999 -> "-9999999999999999999" */
            value = Decimal.Parse("-9999999999999999999.999999");
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-9999999999999999999");
        }


        /// <summary>
        /// 小数点以下の打ち切りテスト
        /// </summary>
        [TestMethod]
        public void TruncateFracTest()
        {
            decimal value = 0;
            string digits = null;
            uint maxDigits = 20;

            /* 10000000000000000000 / 3 -> 3333333333333333333 */
            value = Decimal.Parse("10000000000000000000") / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "3333333333333333333");
               
            /* 1000000000000000000 / 3 -> 3333333333333333333.3 */
            value = Decimal.Parse("1000000000000000000") / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "333333333333333333.3");

            /* 100000000000000000 / 3 -> 333333333333333333.33 */
            value = Decimal.Parse("100000000000000000") / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "33333333333333333.33");

            /* 10000000000000000 / 3 -> 33333333333333333.333 */
            value = Decimal.Parse("10000000000000000") / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "3333333333333333.333");

            // ...

            /* 10/3 -> "3.333333333333333333" */
            value = (decimal) 10 / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "3.333333333333333333");

            /* 1/3 -> "0.333333333333333333" */
            value = (decimal)1 / (decimal)3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "0.333333333333333333");

            /* -1000000000000000000 / 3 -> -333333333333333333 */
            value = Decimal.Parse("-1000000000000000000") / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-333333333333333333");

            /* -100000000000000000 / 3 -> -33333333333333333.3 */
            value = Decimal.Parse("-100000000000000000") / (decimal) 3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-33333333333333333.3");

            /* -10000000000000000 / 3 -> -3333333333333333.3 */
            value = Decimal.Parse("-10000000000000000") / (decimal)3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-3333333333333333.33");

            // ... 

            /* -10/3 -> "-3.33333333333333333" */
            value = (decimal) -10 / (decimal)3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-3.33333333333333333");

            /* -1/3 -> "-0.33333333333333333" */
            value = (decimal)-1 / (decimal)3;
            digits = DigitFormatter.Process(value, maxDigits);
            Assert.AreEqual(digits, "-0.33333333333333333");

        }
    }
}
