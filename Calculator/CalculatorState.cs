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
        public virtual void ProcessNumber(CalculatorCore core, Number token) { }

        public virtual void ProcessOperator(CalculatorCore core, Operator token) { }

        public virtual void ProcessEqual(CalculatorCore core) { }

        public virtual void ProcessClear(CalculatorCore core) { }

        public virtual void ProcessAllClear(CalculatorCore core) { }

        public virtual void DebugPrint(CalculatorCore core) { }


    }
}
