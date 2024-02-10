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
        /// 2個目の数値の入力中の状態を表すクラス.
        /// </summary>
        class CalculatorNum2State : CalculatorState
        {
            /// <summary>
            /// 数値系トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            /// <param name="token"> 数値トークン </param>

            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                core.PutNum2(token);
                core.SelectNum2();

            }

            /// <summary>
            /// 演算子系トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            /// <param name="token"> 演算子トークン </param>
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                bool status = core.Eval();
                if (status == false)
                {
                    core.NotifyError();
                    core.ChangeState(errorState);
                    return;
                }

                core.SetOp(token);
                core.ChangeState(opState);
            }

            /// <summary>
            /// イコールトークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            public override void ProcessEqual(CalculatorCore core)
            {
                bool status = core.Eval();
                if (status == false)
                {
                    core.NotifyError();
                    core.ChangeState(errorState);
                    return;
                }

                core.ChangeState(initState);
            }

            /// <summary>
            /// C(Clear)トークンの処理.
            /// </summary>
            /// <param name="core"> CalculatorCoreオブジェクト </param>
            public override void ProcessClear(CalculatorCore core)
            {
                core.ClearNum2();
                core.SelectNum2();
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
                Debug.WriteLine("num2_state:");
            }
        }



    }
}
