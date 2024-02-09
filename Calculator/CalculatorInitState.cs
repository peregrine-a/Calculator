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
        /// 電卓の初期状態を表すクラス
        /// </summary>
        internal class CalculatorInitState : CalculatorState
        {
            public override void ProcessNumber(CalculatorCore core, Number token)
            {
                core.ClearNum1();
                core.PutNum1(token);
                core.SelectNum1();
                core.ClearOp();


                core.ChangeState(num1State);
            }
            public override void ProcessOperator(CalculatorCore core, Operator token)
            {
                core.SetOp(token);

                core.ChangeState(opState);
            }
            public override void ProcessEqual(CalculatorCore core)
            {
                core.SelectNum1();
                core.ChangeState(initState);
            }


        }


    }

}
