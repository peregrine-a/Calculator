using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    internal class CalculatorCommand : ICommand
    {
        CalculatorViewModel _viewModel = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="viewModel"> 電卓用のViewModel </param>
        public CalculatorCommand(CalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            /* 常に実行可能 */
            return true;
        }

        public void Execute(object parameter)
        {
            string str = parameter as string;
            _viewModel.Process(str);
        }



    }
}
