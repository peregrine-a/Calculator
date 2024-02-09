using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public partial class CalculatorCore
    {
        /// <summary> 現在の演算子種別 </summary>
        Operator op;

        /// <summary> 1個目の数値 </summary>
        double number1;

        /// <summary> 2個目の数値 </summary>
        double number2;



        /// <summary>
        /// 演算子(加減乗除)の入力中状態を表すクラス.
        /// </summary>
        internal class CalculatorOperatorState : CalculatorState
        {
            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                core.ClearNum2();
                core.PutNum2(token);
                core.SelectNum2();

                core.ChangeState(num2State);
            }
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                core.SetOp(token);
            }
            public override void ProcessEqual(CalculatorCore core)
            {
                core.SelectNum1();
                core.ChangeState(initState);
            }
        }

    }
}
