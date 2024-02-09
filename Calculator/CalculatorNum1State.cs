using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    public partial class CalculatorCore
    {
        /// <summary>
        /// 1個目の数値の入力中の状態を表すクラス.
        /// </summary>
        internal class CalculatorNum1State : CalculatorState
        {
            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                core.PutNum1(token);
                core.SelectNum1();
            }
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                core.SetOp(token);
                core.ChangeState(opState);
            }
            public override void ProcessEqual(CalculatorCore core)
            {
                core.ChangeState(initState);
            }
        }

    }
}
