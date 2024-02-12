using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 電卓の数字・小数点ボタンに対応するトークンの定義.
    /// </summary>
    public enum Number
    {
        None,
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        DoubleZero,
        Dot,    
    };

    /// <summary>
    /// 演算子に対応するトークンの定義.
    /// </summary>
    public enum Operator
    {
        None,
        Plus,
        Minus,
        Mult,
        Div,
    };

    /// <summary>
    /// その他制御系ボタンに対応するトークンの定義.
    /// </summary>
    public enum Control
    {
        Equal,
        C,
        AC,
    };

}
