using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Calculator
{
    public partial class CalculatorCore
    {
        /// <summary>
        /// 演算子(加減乗除)の入力中状態を表すクラス.
        /// </summary>
        internal class CalculatorOperatorState : CalculatorState
        {
            /// <summary>
            /// 数値系トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            /// <param name="token"> 数値トークン </param>
            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                core.ClearNum2();
                core.PutNum2(token);
                core.SelectNum2();

                core.ChangeState(num2State);
            }

            /// <summary>
            /// 演算子系トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            /// <param name="token"> 演算子トークン </param>
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                core.SetOp(token);
            }

            /// <summary>
            /// イコールトークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            public override void ProcessEqual(CalculatorCore core)
            {
                core.SelectNum1();
                core.ChangeState(initState);
            }

            /// <summary>
            /// C(Clear)トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            public override void ProcessClear(CalculatorCore core)
            {
                core.ClearNum1();
                core.ClearNum2();
                core.ClearOp();
                core.SelectNum1();

                core.ChangeState(initState);
            }

            /// <summary>
            /// AC(All Clear)トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            public override void ProcessAllClear(CalculatorCore core)
            {
                core.ClearNum1();
                core.ClearNum2();
                core.ClearOp();
                core.SelectNum1();

                core.ChangeState(initState);
            }

            public override void DebugPrint(CalculatorCore core)
            {
                Debug.WriteLine("operator_state:");
            }
        }

    }
}
