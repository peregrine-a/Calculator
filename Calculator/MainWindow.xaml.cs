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

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
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
            MessageBox.Show($"{button.Name} Clicked.");
        }

        /// <summary>
        /// 演算子系のボタン(加減乗除)が押された時に実行されるイベントハンドラ.
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show($"{button.Name} Clicked.");
        }
    }
}
