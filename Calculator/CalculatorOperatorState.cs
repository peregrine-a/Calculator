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
        /// 演算子(加減乗除)の入力中状態を表すクラス.
        /// </summary>
        internal class CalculatorOperatorState : CalculatorState
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
