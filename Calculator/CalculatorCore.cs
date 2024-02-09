using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class CalculatorCore
    {
        /* Properties */
        /// <summary>
        /// 電卓の計算結果値
        /// </summary>
        public double Result { get; private set; }

        /// <summary>
        /// 電卓の表示文字列
        /// </summary>
        public string Digits { get; private set; }

        /* Member Variables */
        private static readonly CalculatorState initState = new CalculatorInitState();  
        private static readonly CalculatorState num1State = new CalculatorNum1State();
        private static readonly CalculatorState num2State = new CalculatorNum2State();
        private static readonly CalculatorState opState   = new CalculatorOperatorState();

        private static readonly Dictionary<Number, string> numDict = new Dictionary<Number, string>()
        {
            { Number.None      , ""   },
            { Number.Zero      , "0"  },
            { Number.One       , "1"  },
            { Number.Two       , "2"  },
            { Number.Three     , "3"  },
            { Number.Four      , "4"  },
            { Number.Five      , "5"  },
            { Number.Six       , "6"  },
            { Number.Seven     , "7"  },
            { Number.Eight     , "8"  },
            { Number.Nine      , "9"  },
            { Number.DoubleZero, "00" },
            { Number.Dot       , "."  },
        };



        private CalculatorState _curState = initState;

        private uint _maxDigits = 20 /* default */;

        private Operator _curOp = Operator.None;

        private CalculatorValue _value1 = null;
        private CalculatorValue _value2 = null;
        private CalculatorValue _result = null;

        /* Methods */

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="maxDigits">表示可能な最大の桁数</param>
        public CalculatorCore(uint maxDigits=20)
        {
            _maxDigits = maxDigits;
            _value1 = new CalculatorValue(maxDigits);
            _value2 = new CalculatorValue(maxDigits);
            _result = new CalculatorValue(maxDigits);
        }

        /// <summary>
        /// 数字(小数点を含む)ボタンの処理
        /// </summary>
        /// <param name="token"> 数字・小数点を表すトークン </param>
        public void ProcessNumber(Number token)
        {
            // Debug.WriteLine($"ProcessNumber! {token}");
            _curState.ProcessNumber(this, token);
            _curState.DebugPrint(this);
        }

        /// <summary>
        /// 演算子(加減乗除)ボタンの処理
        /// </summary>
        /// <param name="token"> 演算子を表すトークン </param>
        public void ProcessOperator(Operator token)
        {
            // Debug.WriteLine($"ProcessOperator! {token}");
            _curState.ProcessOperator(this, token);
            _curState.DebugPrint(this);
        }

        /// <summary>
        /// イコールボタンの処理
        /// </summary>
        public void ProcessEqual()
        {
            // Debug.WriteLine("ProcessEqual!");
            _curState.ProcessEqual(this);
            _curState.DebugPrint(this);
        }

        /// <summary>
        /// ACボタンの処理
        /// </summary>
        public void ProcessAllClear()
        {
            // Debug.WriteLine("ProcessEqual!");
            _curState.ProcessAllClear(this);
            _curState.DebugPrint(this);
        }

        /// <summary>
        /// Cボタンの処理
        /// </summary>
        public void ProcessClear()
        {
            // Debug.WriteLine("ProcessEqual!");
            _curState.ProcessClear(this);
            _curState.DebugPrint(this);
        }

        /// <summary>
        /// 内部ステートの変更を行う.
        /// </summary>
        /// <param name="state"> 遷移先のステート </param>
        public void ChangeState(CalculatorState state)
        {
            // Debug.WriteLine("ChangeState!");
            _curState = state;
        }

        public void PutNum1(Number token)
        {
            var str = numDict[token];
            _value1.Put(str);
        }

        public void ClearNum1()
        {
            _value1.Reset();
        }

        public void SelectNum1()
        {
            Digits = _value1.Digits;
        }

        public void PutNum2(Number token)
        {
            var str = numDict[token];
            _value2.Put(str);
        }

        public void ClearNum2()
        {
            _value2.Reset();
        }
        public void SelectNum2()
        {
            Digits = _value2.Digits;
        }
        public void Eval()
        {
            double value1 = _value1.GetValue();
            double value2 = _value2.GetValue();
            double result = 0;

            /* 四則演算の実行 */
            switch (_curOp)
            {
                case Operator.Plus:
                    result = value1 + value2;
                    break;
                case Operator.Minus:
                    result = value1 - value2;
                    break;
                case Operator.Mult:
                    result = value1 * value2;
                    break;
                case Operator.Div:
                    result = value1 / value2;
                    break;
                default:
                    result = value1;
                    break;
            }

            Debug.WriteLine($"1: {value1} {_curOp} {value2} = {result}");

            _result.SetValue(result);
            _value1.SetValue(result);
            Debug.WriteLine($"2: {value1} {_curOp} {value2} = {result}");
            Digits = _result.Digits;
        }

        public void SetOp(Operator token)
        {
            _curOp = token;
        }
        public void ClearOp()
        {
            _curOp = Operator.None;
        }


    }
}
