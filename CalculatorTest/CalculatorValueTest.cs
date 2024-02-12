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
    public class CalculatorValueTest
    {
        [TestMethod]
        public void PutTest1()
        {
            uint maxDigits = 20;
            CalculatorValue calcValue = new CalculatorValue(maxDigits);

            // 初期状態の確認
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);
            Assert.AreEqual(calcValue.Digits, "0");

            // 文字の追加("0")
            calcValue.Put("0");
            Assert.AreEqual(calcValue.Digits, "0");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);

            // 文字の追加("00")
            calcValue.Put("00");
            Assert.AreEqual(calcValue.Digits, "0");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);

            // 文字の追加("1")
            calcValue.Put("1");
            Assert.AreEqual(calcValue.Digits, "1");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 文字の追加("2")
            calcValue.Put("2");
            Assert.AreEqual(calcValue.Digits, "12");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 文字の追加("3")
            calcValue.Put("3");
            Assert.AreEqual(calcValue.Digits, "123");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 文字の追加(".")
            calcValue.Put(".");
            Assert.AreEqual(calcValue.Digits, "123.");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加(".")  この入力は無視される.
            calcValue.Put(".");
            Assert.AreEqual(calcValue.Digits, "123.");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("4")
            calcValue.Put("4");
            Assert.AreEqual(calcValue.Digits, "123.4");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("5")
            calcValue.Put("5");
            Assert.AreEqual(calcValue.Digits, "123.45");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("6")
            calcValue.Put("6");
            Assert.AreEqual(calcValue.Digits, "123.456");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加(".") この入力は無視される.
            calcValue.Put(".");
            Assert.AreEqual(calcValue.Digits, "123.456");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 状態のリセット
            calcValue.Reset();
            Assert.AreEqual(calcValue.Digits, "0");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);
        }

        [TestMethod]
        public void PutTest2()
        {
            uint maxDigits = 20;
            CalculatorValue calcValue = new CalculatorValue(maxDigits);

            // 初期状態の確認
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);
            Assert.AreEqual(calcValue.Digits, "0");

            // 文字の追加(".")
            calcValue.Put(".");
            Assert.AreEqual(calcValue.Digits, "0.");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("00")
            calcValue.Put("00");
            Assert.AreEqual(calcValue.Digits, "0.00");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("1")
            calcValue.Put("1");
            Assert.AreEqual(calcValue.Digits, "0.001");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("2")
            calcValue.Put("2");
            Assert.AreEqual(calcValue.Digits, "0.0012");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加("3")
            calcValue.Put("3");
            Assert.AreEqual(calcValue.Digits, "0.00123");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 文字の追加(".") この入力は無視される.
            calcValue.Put(".");
            Assert.AreEqual(calcValue.Digits, "0.00123");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Frac);

            // 状態のリセット
            calcValue.Reset();
            Assert.AreEqual(calcValue.Digits, "0");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);
        }

        [TestMethod]
        public void PutTest3()
        {
            uint maxDigits = 20;
            CalculatorValue calcValue = new CalculatorValue(maxDigits);

            // 初期状態の確認
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);
            Assert.AreEqual(calcValue.Digits, "0");

            // 文字の追加("1")
            calcValue.Put("1");
            Assert.AreEqual(calcValue.Digits, "1");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 文字の追加("2")
            calcValue.Put("2");
            Assert.AreEqual(calcValue.Digits, "12");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 文字の追加("3")
            calcValue.Put("3");
            Assert.AreEqual(calcValue.Digits, "123");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            calcValue.Put("4");
            calcValue.Put("5");
            calcValue.Put("6");
            calcValue.Put("7");
            calcValue.Put("8");
            calcValue.Put("9");
            calcValue.Put("0");
            calcValue.Put("1");
            calcValue.Put("2");
            calcValue.Put("3");
            calcValue.Put("4");
            calcValue.Put("5");
            calcValue.Put("6");
            calcValue.Put("7");
            calcValue.Put("8");
            calcValue.Put("9");
            calcValue.Put("0");
            Assert.AreEqual(calcValue.Digits, "12345678901234567890");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 最大桁数を超えるため, 無視される.
            calcValue.Put("1");
            Assert.AreEqual(calcValue.Digits, "12345678901234567890");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 最大桁数を超えるため, 無視される.
            calcValue.Put(".");
            Assert.AreEqual(calcValue.Digits, "12345678901234567890");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Integer);

            // 状態のリセット
            calcValue.Reset();
            Assert.AreEqual(calcValue.Digits, "0");
            Assert.AreEqual(calcValue.CurState, CalculatorValue.State.Init);
        }



    }
}
