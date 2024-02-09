using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Member Variables */
        private readonly CalculatorCore _core = new CalculatorCore(20);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数字系のボタンが押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Number token;

            switch (button.Name)
            {
                case "numButton0":
                    token = Number.Zero;
                    break;
                case "numButton00":
                    token = Number.DoubleZero;
                    break;
                case "numButton1":
                    token = Number.One;
                    break;
                case "numButton2":
                    token = Number.Two;
                    break;
                case "numButton3":
                    token = Number.Three;
                    break;
                case "numButton4":
                    token = Number.Four;
                    break;
                case "numButton5":
                    token = Number.Five;
                    break;
                case "numButton6":
                    token = Number.Six;
                    break;
                case "numButton7":
                    token = Number.Seven;
                    break;
                case "numButton8":
                    token = Number.Eight;
                    break;
                case "numButton9":
                    token = Number.Nine;
                    break;
                case "numButtonDot":
                    token = Number.Dot;
                    break;
                default:
                    // 通らない.
                    token = Number.None;
                    break;
            }

            _core.ProcessNumber(token);
            displayTextBox.Text = _core.Digits;

        }

        /// <summary>
        /// 演算子系のボタン(加減乗除)が押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Operator token;

            switch (button.Name)
            {
                case "plusButton":
                    token = Operator.Plus;
                    break;
                case "minusButton":
                    token = Operator.Minus;
                    break;
                case "multButton":
                    token = Operator.Mult;
                    break;
                case "divButton":
                    token = Operator.Div;
                    break;
                default:
                    token = Operator.None;
                    break;
            }

            _core.ProcessOperator(token);
            displayTextBox.Text = _core.Digits;

        }

        /// <summary>
        /// イコールボタンボタンが押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            displayTextBox.Text = "Equal";

            _core.ProcessEqual();
            displayTextBox.Text = _core.Digits;

        }
    }
}
