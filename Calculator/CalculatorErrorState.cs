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
        /// 電卓のエラー状態を表すクラス
        /// </summary>
        internal class CalculatorErrorState : CalculatorState
        {
            /// <summary>
            /// 数値系トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            /// <param name="token"> 数値トークン </param>
            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                /* 何もしない. */
            }

            /// <summary>
            /// 演算子系トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            /// <param name="token"> 演算子トークン </param>
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                /* 何もしない. */
            }


            /// <summary>
            /// イコールトークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            public override void ProcessEqual(CalculatorCore core)
            {
                /* 何もしない. */
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
                Debug.WriteLine("error_state:");
            }
        }


    }

}
