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
        public decimal Result { get; private set; }

        /// <summary>
        /// 電卓の表示文字列
        /// </summary>
        public string Digits { get; private set; }

        /// <summary>
        /// 現在の演算子設定
        /// </summary>
        public Operator CurOp { get; private set; }

        /// <summary>
        /// エラー状態かどうか
        /// </summary>
        public bool HasError { get; private set; }


        /* Static Member Variables */
        private static readonly CalculatorState initState  = new CalculatorInitState();  
        private static readonly CalculatorState num1State  = new CalculatorNum1State();
        private static readonly CalculatorState num2State  = new CalculatorNum2State();
        private static readonly CalculatorState opState    = new CalculatorOperatorState();
        private static readonly CalculatorState errorState = new CalculatorErrorState();

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

        private uint _maxDigits;

        private CalculatorValue _value1 = null;
        private CalculatorValue _value2 = null;

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
            Digits = "0";
            CurOp =  Operator.None;
            HasError = false;

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

        /* 以下, ステートクラスから呼び出されるメソッド群. */
        /// <summary>
        /// 内部ステートの変更を行う.
        /// </summary>
        /// <param name="state"> 遷移先のステート </param>
        public void ChangeState(CalculatorState state)
        {
            // Debug.WriteLine("ChangeState!");
            _curState = state;
        }

        /// <summary>
        /// 1個目の数値に文字列トークンを追加する.
        /// </summary>
        /// <param name="state"> 数値トークン </param>
        public void PutNum1(Number token)
        {
            var str = numDict[token];
            _value1.Put(str);
        }

        /// <summary>
        /// 1個目の数値をクリアする.
        /// </summary>
        public void ClearNum1()
        {
            _value1.Reset();
        }

        /// <summary>
        /// 1個目の数値をディスプレイ表示文字列に設定する.
        /// </summary>
        public void SelectNum1()
        {
            Digits = _value1.Digits;
        }

        /// <summary>
        /// 2個目の数値に文字列トークンを追加する.
        /// </summary>
        /// <param name="state"> 数値トークン </param>
        public void PutNum2(Number token)
        {
            var str = numDict[token];
            _value2.Put(str);
        }

        /// <summary>
        /// 2個目の数値をクリアする.
        /// </summary>
        public void ClearNum2()
        {
            _value2.Reset();
        }

        /// <summary>
        /// 2個目の数値をディスプレイ表示文字列に設定する.
        /// </summary>
        public void SelectNum2()
        {
            Digits = _value2.Digits;
        }

        /// <summary>
        /// 現在の数値・演算子を用いて計算を行う.
        /// </summary>
        public bool Eval()
        {
            decimal value1 = _value1.GetValue();
            decimal value2 = _value2.GetValue();
            decimal result = 0;

            /* 演算実行. オーバーフロー, ゼロ除算は検出する. */
            try
            {
                /* 四則演算の実行 */
                switch (CurOp)
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
            }
            catch(OverflowException e)
            {
                return false;
            }
            catch(DivideByZeroException e)
            {
                return false;
            }

            bool status = _value1.SetValue(result);
            if (status == false)
                return false;

            // Debug.WriteLine($"{value1} {_curOp} {value2} = {result}");
            Digits = _value1.Digits;

            return true;
        }

        /// <summary>
        /// 演算子トークンを設定する.
        /// </summary>
        public void SetOp(Operator token)
        {
            CurOp = token;
        }

        /// <summary>
        /// 演算子トークンをクリアする.
        /// </summary>
        public void ClearOp()
        {
            CurOp = Operator.None;
        }

        /// <summary>
        /// エラー発生の通知
        /// </summary>
        public void NotifyError()
        {
            Digits = "Error.";
            HasError = true;
        }

        /// <summary>
        /// エラーのクリア
        /// </summary>
        public void ClearError()
        {
            HasError = false;
        }

    }
}
