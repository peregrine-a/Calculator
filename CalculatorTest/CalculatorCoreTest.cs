using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorCoreTest
    {
        [TestMethod]
        public void PlusTest1()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "1 + 2 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '+'
            calcCore.ProcessOperator(Operator.Plus);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "2");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void PlusTest2()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "1 + 2 + 3 + 4 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '+'
            calcCore.ProcessOperator(Operator.Plus);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "2");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '+'
            calcCore.ProcessOperator(Operator.Plus);
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '3'
            calcCore.ProcessNumber(Number.Three);
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '+'
            calcCore.ProcessOperator(Operator.Plus);
            Assert.AreEqual(calcCore.Digits, "6");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '4'
            calcCore.ProcessNumber(Number.Four);
            Assert.AreEqual(calcCore.Digits, "4");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "10");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void PlusTest3()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "0.1 + 0.2 = 0.3", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "0.");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "0.1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '+'
            calcCore.ProcessOperator(Operator.Plus);
            Assert.AreEqual(calcCore.Digits, "0.1");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "0.");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "0.2");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "0.3");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void MinusTest1()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "5 - 3 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '5'
            calcCore.ProcessNumber(Number.Five);
            Assert.AreEqual(calcCore.Digits, "5");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '-'
            calcCore.ProcessOperator(Operator.Minus);
            Assert.AreEqual(calcCore.Digits, "5");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '3'
            calcCore.ProcessNumber(Number.Three);
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "2");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void MinusTest2()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "10 - 7 - 5 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "10");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '-'
            calcCore.ProcessOperator(Operator.Minus);
            Assert.AreEqual(calcCore.Digits, "10");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '7'
            calcCore.ProcessNumber(Number.Seven);
            Assert.AreEqual(calcCore.Digits, "7");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '-'
            calcCore.ProcessOperator(Operator.Minus);
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '5'
            calcCore.ProcessNumber(Number.Five);
            Assert.AreEqual(calcCore.Digits, "5");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "-2");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void MinusTest3()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "1.23 - 0.12 = 1.11", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "1.");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "1.2");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '3'
            calcCore.ProcessNumber(Number.Three);
            Assert.AreEqual(calcCore.Digits, "1.23");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '-'
            calcCore.ProcessOperator(Operator.Minus);
            Assert.AreEqual(calcCore.Digits, "1.23");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "0.");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "0.1");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "0.12");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "1.11");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void MultTest1()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "6 * 8 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '6'
            calcCore.ProcessNumber(Number.Six);
            Assert.AreEqual(calcCore.Digits, "6");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '*'
            calcCore.ProcessOperator(Operator.Mult);
            Assert.AreEqual(calcCore.Digits, "6");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '8'
            calcCore.ProcessNumber(Number.Eight);
            Assert.AreEqual(calcCore.Digits, "8");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "48");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void MultTest2()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "2 * 3 * 4 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "2");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '*'
            calcCore.ProcessOperator(Operator.Mult);
            Assert.AreEqual(calcCore.Digits, "2");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '3'
            calcCore.ProcessNumber(Number.Three);
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '*'
            calcCore.ProcessOperator(Operator.Mult);
            Assert.AreEqual(calcCore.Digits, "6");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '4'
            calcCore.ProcessNumber(Number.Four);
            Assert.AreEqual(calcCore.Digits, "4");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "24");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void MultTest3()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "0.123 * 4.567", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "0.");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "0.1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "0.12");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '3'
            calcCore.ProcessNumber(Number.Three);
            Assert.AreEqual(calcCore.Digits, "0.123");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '*'
            calcCore.ProcessOperator(Operator.Mult);
            Assert.AreEqual(calcCore.Digits, "0.123");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '4'
            calcCore.ProcessNumber(Number.Four);
            Assert.AreEqual(calcCore.Digits, "4");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "4.");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '5'
            calcCore.ProcessNumber(Number.Five);
            Assert.AreEqual(calcCore.Digits, "4.5");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '6'
            calcCore.ProcessNumber(Number.Six);
            Assert.AreEqual(calcCore.Digits, "4.56");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '7'
            calcCore.ProcessNumber(Number.Seven);
            Assert.AreEqual(calcCore.Digits, "4.567");
            Assert.AreEqual(calcCore.CurOp, Operator.Mult);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "0.561741");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void DivTest1()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "6 / 2 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '6'
            calcCore.ProcessNumber(Number.Six);
            Assert.AreEqual(calcCore.Digits, "6");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '/'
            calcCore.ProcessOperator(Operator.Div);
            Assert.AreEqual(calcCore.Digits, "6");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '2'
            calcCore.ProcessNumber(Number.Two);
            Assert.AreEqual(calcCore.Digits, "2");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void DivTest2()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "8 / 5 / 0.4 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '8'
            calcCore.ProcessNumber(Number.Eight);
            Assert.AreEqual(calcCore.Digits, "8");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '/'
            calcCore.ProcessOperator(Operator.Div);
            Assert.AreEqual(calcCore.Digits, "8");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '5'
            calcCore.ProcessNumber(Number.Five);
            Assert.AreEqual(calcCore.Digits, "5");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '/'
            calcCore.ProcessOperator(Operator.Div);
            Assert.AreEqual(calcCore.Digits, "1.6");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '.'
            calcCore.ProcessNumber(Number.Dot);
            Assert.AreEqual(calcCore.Digits, "0.");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '4'
            calcCore.ProcessNumber(Number.Four);
            Assert.AreEqual(calcCore.Digits, "0.4");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "4");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void DivTest3()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* 入力: "1 / 3 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '/'
            calcCore.ProcessOperator(Operator.Div);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '3'
            calcCore.ProcessNumber(Number.Three);
            Assert.AreEqual(calcCore.Digits, "3");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "0.333333333333333333" /* 20桁 */);
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void ErrorTest1()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* プラス側の桁溢れ確認 */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '9'を20回.
            for (int i = 0; i < 20; i++)
                calcCore.ProcessNumber(Number.Nine);

            Assert.AreEqual(calcCore.Digits, "99999999999999999999");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '+'
            calcCore.ProcessOperator(Operator.Plus);
            Assert.AreEqual(calcCore.Digits, "99999999999999999999");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.Plus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "Error.");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, true);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void ErrorTest2()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* マイナス側の桁溢れ確認 */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '-'
            calcCore.ProcessOperator(Operator.Minus);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '9'を19回.
            for (int i = 0; i < 19; i++)
                calcCore.ProcessNumber(Number.Nine);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "-9999999999999999999");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '-'
            calcCore.ProcessOperator(Operator.Minus);
            Assert.AreEqual(calcCore.Digits, "-9999999999999999999");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.Minus);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "Error.");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, true);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }

        [TestMethod]
        public void ErrorTest3()
        {
            // Arrange
            uint maxDigits = 20;
            CalculatorCore calcCore = new CalculatorCore(maxDigits);

            /* ゼロ除算の確認. 入力: "1 / 0 =", 最後にAC */

            // 初期状態
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '1'
            calcCore.ProcessNumber(Number.One);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);

            // '/'
            calcCore.ProcessOperator(Operator.Div);
            Assert.AreEqual(calcCore.Digits, "1");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '0'
            calcCore.ProcessNumber(Number.Zero);
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.Div);
            Assert.AreEqual(calcCore.HasError, false);

            // '='
            calcCore.ProcessEqual();
            Assert.AreEqual(calcCore.Digits, "Error.");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, true);

            // AC
            calcCore.ProcessAllClear();
            Assert.AreEqual(calcCore.Digits, "0");
            Assert.AreEqual(calcCore.CurOp, Operator.None);
            Assert.AreEqual(calcCore.HasError, false);
        }
    }
}