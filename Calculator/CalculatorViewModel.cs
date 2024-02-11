using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace Calculator
{
    internal class CalculatorViewModel : INotifyPropertyChanged
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
        public string CurOp { get; private set; }

        /// <summary>
        /// エラー状態かどうか
        /// </summary>
        public string HasError { get; private set; }


        private readonly CalculatorCore _core = new CalculatorCore(20);

        public CalculatorViewModel()
        {
        }

        /// <summary>
        /// 数字(小数点を含む)ボタンの処理
        /// </summary>
        /// <param name="token"> 数字・小数点を表すトークン </param>
        public void ProcessNumber(Number token)
        {
            _core.ProcessNumber(token);
            _Update();
        }

        /// <summary>
        /// 演算子(加減乗除)ボタンの処理
        /// </summary>
        /// <param name="token"> 演算子を表すトークン </param>
        public void ProcessOperator(Operator token)
        {
            _core.ProcessOperator(token);
            _Update();
        }

        /// <summary>
        /// イコールボタンの処理
        /// </summary>
        public void ProcessEqual()
        {
            _core.ProcessEqual();
            _Update();
        }

        /// <summary>
        /// ACボタンの処理
        /// </summary>
        public void ProcessAllClear()
        {
            _core.ProcessAllClear();
            _Update();
        }

        /// <summary>
        /// Cボタンの処理
        /// </summary>
        public void ProcessClear()
        {
            _core.ProcessClear();
            _Update();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// プロパティの更新
        /// </summary>
        private void _Update()
        {
            Result   = _core.Result;
            Digits   = _core.Digits;
            Debug.WriteLine($"Digits= '{Digits}'");
            CurOp    = _GetOperator(_core.CurOp);
            HasError = _GetErrorFlag(_core.HasError);

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


    }
}
