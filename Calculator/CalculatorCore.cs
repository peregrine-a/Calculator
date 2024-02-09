using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace Calculator
{
    public partial class CalculatorCore
    {
        /* Members */
        private static CalculatorState initState = new CalculatorInitState();  
        private static CalculatorState num1State = new CalculatorNum1State();
        private static CalculatorState num2State = new CalculatorNum2State();
        private static CalculatorState opState = new CalculatorOperatorState();

        private CalculatorState _curState = initState;

        /* Methods */

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="maxDigits">表示可能な最大の桁数</param>
        public CalculatorCore(uint maxDigits=20)
        {

        }

        public void ChangeState(CalculatorState state)
        {
            _curState = state;            
        }
    }
}
