using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public partial class CalculatorCore
    {
        /// <summary>
        /// 2個目の数値の入力中の状態を表すクラス.
        /// </summary>
        internal class CalculatorNum2State : CalculatorState
        {
            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                core.ChangeState(initState);
            }
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                core.ChangeState(initState);
            }
            public override void ProcessEqual(CalculatorCore core)
            {
                core.ChangeState(initState);
            }


        }



    }
}
