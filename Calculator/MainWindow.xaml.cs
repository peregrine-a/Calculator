﻿using System;
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
        /// <summary>
        /// 電卓のViewModel
        /// </summary>
        private readonly CalculatorViewModel _viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            /* ViewModelを生成してDataContextに登録する. */
            _viewModel = new CalculatorViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// 数字系のボタンが押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender"> 送信元オブジェクト </param>
        /// <param name="e"> イベントパラメータ </param>
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

            _viewModel.ProcessNumber(token);
        }

        /// <summary>
        /// 演算子系のボタン(加減乗除)が押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender"> 送信元オブジェクト </param>
        /// <param name="e"> イベントパラメータ </param>
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

            _viewModel.ProcessOperator(token);
        }

        /// <summary>
        /// イコールボタンが押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender"> 送信元オブジェクト </param>
        /// <param name="e"> イベントパラメータ </param>
        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ProcessEqual();
        }

        /// <summary>
        /// ACボタンが押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender"> 送信元オブジェクト </param>
        /// <param name="e"> イベントパラメータ </param>
        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ProcessAllClear();
        }

        /// <summary>
        /// Cボタンが押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender"> 送信元オブジェクト </param>
        /// <param name="e"> イベントパラメータ </param>
        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ProcessClear();
        }
    }
}