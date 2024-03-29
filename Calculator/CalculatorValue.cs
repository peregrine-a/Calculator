﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Documents;
using System.Diagnostics;


namespace Calculator
{
    internal class CalculatorValue
    {
        /* Enums */
        /// <summary>
        /// 内部ステートの定義
        /// </summary>
        public enum State
        {
            Init,    // 初期状態
            Integer, // 整数部分の解析中
            Frac,    // 小数部分の解析中
        };

        /* Properties */

        /// <summary>
        /// 現在の桁表示.
        /// </summary>
        public string Digits
        {
            get
            {
                return (_digits.Length == 0) ? "0" : _digits;
            }
        }

        public State CurState { get; private set; } = State.Init;

        /// <summary>
        /// 現在の桁表示文字列
        /// </summary>
        private string _digits = String.Empty;

        /// <summary> 最大桁数 </summary>
        uint _maxDigits;


        /* Methods */

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="maxDigits"> 処理可能な最大の桁数 </param>
        public CalculatorValue(uint maxDigits)
        {
            _maxDigits = maxDigits;
        }

        /// <summary>
        /// 文字列を追加する.
        /// 最大の桁数を超えてしまう場合は, 追加できる長さだけ追加する.
        /// </summary>
        /// <param name="c"> 追加する文字. </param>
        public void Put(string s)
        {
            foreach (char c in s)
            {
                _PutChar(c);
                // DebugPrint();
            }
        }

        /// <summary>
        /// 値を設定する.
        /// </summary>
        /// <param name="value"> 値 </param>
        public bool SetValue(decimal value)
        {
            string tmp = DigitFormatter.Process(value, _maxDigits);
            if (tmp == null)
                return false;

            _digits = tmp;
            return true;
        }

        /// <summary>
        /// 現在の整数値の取得.
        /// </summary>
        /// <returns> 整数値 </returns>
        public decimal GetValue()
        {
            return Decimal.Parse(Digits);
        }

        /// <summary>
        /// 状態のリセット.
        /// </summary>
        public void Reset()
        {
            _digits = String.Empty;
            CurState = State.Init;
        }

        /// <summary>
        /// デバッグ表示.
        /// </summary>
        public void DebugPrint()
        {
            Debug.WriteLine($"state= {CurState} _digits= '{_digits}'");
        }

        /// <summary>
        /// 1文字追加する. 最大の桁数を超えている場合は何もしない.
        /// </summary>
        /// <param name="c"> 追加する文字. </param>
        private void _PutChar(char c)
        {
            if (CurState == State.Init)
            {
                if (c == '0')
                    return;

                if (('1' <= c) && (c <= '9'))
                {
                    if (_CanAppend(1) == false)
                        return;

                    _AppendChar(c);
                    CurState = State.Integer;
                }
                else if (c == '.')
                {
                    if (_CanAppend(2) == false)
                        return;

                    _AppendChar('0');
                    _AppendChar(c);
                    CurState = State.Frac;
                }
            }
            else if (CurState == State.Integer)
            {
                if (('0' <= c) && (c <= '9'))
                {
                    if (_CanAppend(1) == false)
                        return;

                    _AppendChar(c);
                }
                else if (c == '.')
                {
                    if (_CanAppend(1) == false)
                        return;

                    _AppendChar(c);
                    CurState = State.Frac;
                }
            }
            else if (CurState == State.Frac)
            {
                if (('0' <= c) && (c <= '9'))
                {
                    if (_CanAppend(1) == false)
                        return;

                    _AppendChar(c);
                }
            }
        }

        /// <summary>
        /// 整数桁文字列に1文字追加する. 長さが最大数を超える場合は何もしない.
        /// </summary>
        /// <param name="c"> 追加する文字 </param>
        private void _AppendChar(char c)
        {
            if(_digits.Length < _maxDigits)
                _digits += c;
        }

        /// <summary>
        /// 整数桁文字列に指定された文字数を追加できるかどうか確認する.
        /// </summary>
        /// <param name="numChars">追加する文字数</param>
        /// <returns> 追加できるかどうかのフラグ </returns>
        private bool _CanAppend(uint numChars)
        {
            return ((_digits.Length + numChars) <= _maxDigits);
        }

    }
}
