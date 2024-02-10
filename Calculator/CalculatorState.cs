using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 電卓の状態を表すベースクラス.
    /// </summary>
    public abstract class CalculatorState
    {
        /* Methods */
        /// <summary>
        /// 数値系トークンの処理.
        /// </summary>
        /// <param name="core"> CalculatorCoreオブジェクト </param>
        /// <param name="token"> 数値トークン </param>
        public virtual void ProcessNumber(CalculatorCore core, Number token) { }

        /// <summary>
        /// 演算子系トークンの処理.
        /// </summary>
        /// <param name="core"> CalculatorCoreオブジェクト </param>
        /// <param name="token"> 演算子トークン </param>
        public virtual void ProcessOperator(CalculatorCore core, Operator token) { }

        /// <summary>
        /// イコールトークンの処理.
        /// </summary>
        /// <param name="core"> CalculatorCoreオブジェクト </param>
        public virtual void ProcessEqual(CalculatorCore core) { }

        /// <summary>
        /// C(Clear)トークンの処理.
        /// </summary>
        /// <param name="core"> CalculatorCoreオブジェクト </param>
        public virtual void ProcessClear(CalculatorCore core) { }

        /// <summary>
        /// AC(All Clear)トークンの処理.
        /// </summary>
        /// <param name="core"> CalculatorCoreオブジェクト </param>
        public virtual void ProcessAllClear(CalculatorCore core) { }

        /// <summary>
        /// デバッグ表示用メソッド.
        /// </summary>
        /// <param name="core"> CalculatorCoreオブジェクト </param>
        public virtual void DebugPrint(CalculatorCore core) { }

    }
}
