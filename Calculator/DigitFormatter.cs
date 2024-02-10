using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Calculator
{
    internal static class DigitFormatter
    {
        /// <summary>
        /// 入力値を指定された桁数以内の文字列に変換する.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxDigits"></param>
        /// <returns></returns>
        public static string Process(decimal value, uint maxDigits)
        {
            Debug.WriteLine($"value: {value.ToString()}");
            string[] nums = value.ToString().Split('.');
            string str = String.Empty;

            /* 小数部分が存在しない場合は整数部分のみ表示する. */
            if(nums.Length == 1)
            {
                /* 整数部分の長さが最大桁数を超えていたらエラーとする. */
                if (nums[0].Length > maxDigits)
                    return null;

                return nums[0];
            }

            /* 小数部分が存在する場合. */

            // 小数部分に使用可能な残桁数を計算する.
            int numFracDigits = (int) (maxDigits - nums[0].Length - 1 /* 小数点 */);
            
            // 小数点以下を表示する桁数が残っていない場合は整数部分のみを表示する.
            // 現状は, 最後の桁が小数点になるような場合は, 小数部分自体を表示しない. 
            if(numFracDigits <= 0)
                return nums[0];

            // 小数点以下を表示できる部分まで表示する.
            if (nums[1].Length > numFracDigits)
                str = nums[0] + "." + nums[1].Substring(0, numFracDigits);
            else
                str = nums[0] + "." + nums[1];

            return str; 
        }
    }
}
