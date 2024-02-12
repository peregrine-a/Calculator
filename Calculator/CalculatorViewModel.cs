using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Input;

namespace Calculator
{
    internal class CalculatorViewModel : INotifyPropertyChanged
    {
        /* Properties */

        /// <summary>
        /// ViewModelに対するコマンドオブジェクト
        /// </summary>
        public ICommand CalcCommand { get; private set; }

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
        public string CurOp { get; private set; }

        /// <summary>
        /// エラー状態かどうか
        /// </summary>
        public string HasError { get; private set; }


        /* Member Variables */

        /// <summary>
        /// 電卓コアオブジェクト
        /// </summary>
        private readonly CalculatorCore _core = new CalculatorCore(20);

        /* Methods */

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CalculatorViewModel()
        {
            CalcCommand = new CalculatorCommand(this);
        }

        /// <summary>
        /// ボタンの処理
        /// </summary>
        /// <param name="parameter"> ボタンの種別を表す文字列. </param>
        public void Process(string parameter)
        {
            /* 数値系 */
            Number numToken = _GetNumberToken(parameter);
            if (numToken != Number.None)
            {
                _core.ProcessNumber(numToken);
                _Update();
                return;
            }

            /* 演算子系 */
            Operator opToken = _GetOperatorToken(parameter);
            if (opToken != Operator.None)
            {
                _core.ProcessOperator(opToken);
                _Update();
                return;
            }

            /* イコール */
            if (parameter == "=")
            {
                _core.ProcessEqual();
                _Update();
                return;
            }

            /* Clear */
            if (parameter == "c")
            {
                _core.ProcessClear();
                _Update();
                return;
            }

            /* All Clear */
            if (parameter == "ac")
            {
                _core.ProcessAllClear();
                _Update();
                return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティの更新
        /// </summary>
        private void _Update()
        {
            Result   = _core.Result;
            Digits   = _core.Digits;
            CurOp    = _GetOperator(_core.CurOp);
            HasError = _GetErrorFlag(_core.HasError);

            /* View側に値の変更を通知する */
            PropertyChanged(this, new PropertyChangedEventArgs("Digits"));
            PropertyChanged(this, new PropertyChangedEventArgs("CurOp"));
            PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
        }


        /// <summary>
        /// 現在の演算子設定に対応する文字列の取得
        /// </summary>
        /// <returns>現在の演算子設定に対応する文字列</returns>
        private static string _GetOperator(Operator token)
        {
            switch (token)
            {
                case Operator.Plus:
                    return "＋";

                case Operator.Minus:
                    return "－";

                case Operator.Mult:
                    return "×";

                case Operator.Div:
                    return "÷";

                case Operator.None:
                    return "";

                default:
                    // 通常通らない.
                    return "？";
            }
        }

        /// <summary>
        /// エラーステータスに対応する文字列の取得.
        /// </summary>
        /// <returns> エラーステータス文字列 </returns>
        private static string _GetErrorFlag(bool hasError)
        {
            if (hasError)
                return "E";
            else
                return "";
        }

        /// <summary>
        /// パラメータ文字列から数値トークンを取得する.
        /// </summary>
        /// <param name="parameter"> パラメータ文字列 </param>
        /// <returns> 数値トークン </returns>
        private static Number _GetNumberToken(string parameter)
        {
            switch (parameter)
            {
                case "0":
                    return Number.Zero;
                case "00":
                    return Number.DoubleZero;
                case "1":
                    return Number.One;
                case "2":
                    return Number.Two;
                case "3":
                    return Number.Three;
                case "4":
                    return Number.Four;
                case "5":
                    return Number.Five;
                case "6":
                    return Number.Six;
                case "7":
                    return Number.Seven;
                case "8":
                    return Number.Eight;
                case "9":
                    return Number.Nine;
                case ".":
                    return Number.Dot;
                default:
                    return Number.None;
            }
        }

        /// <summary>
        /// パラメータ文字列から演算子トークンを取得する.
        /// </summary>
        /// <param name="parameter"> パラメータ文字列 </param>
        /// <returns> 演算子トークン </returns>
        private static Operator _GetOperatorToken(string parameter)
        {
            switch (parameter)
            {
                case "+":
                    return Operator.Plus;
                case "-":
                    return Operator.Minus;
                case "*":
                    return Operator.Mult;
                case "/":
                    return Operator.Div;
                default:
                    return Operator.None;
            }
        }
    }
}
