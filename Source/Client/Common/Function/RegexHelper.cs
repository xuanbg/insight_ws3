using System.Globalization;
using System.Text.RegularExpressions;

namespace Insight.WS.Client.Common
{
    public class RegexHelper
    {

        /// <summary>
        /// 清除包含'字符串
        /// </summary>
        public const string CleanString = @"[']";

        /// <summary>
        /// 验证字符串是否为字符begin-end之间
        /// </summary>
        public const string IsValidByte = @"^[A-Za-z0-9]{#0#,#1#}$";

        /// <summary>
        /// 验证字符串是否为年月日
        /// </summary>
        public const string IsValidDate = @"^2\d{3}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|[1-2]\d|3[0-1])(?:0?[1-9]|1\d|2[0-3]):(?:0?[1-9]|[1-5]\d):(?:0?[1-9]|[1-5]\d)$";

        /// <summary>
        /// 验证字符串是否为小数
        /// </summary>
        public const string IsValidDecimal = @"[0].\d{1,2}|[1]";

        /// <summary>
        /// 验证字符串是否为EMAIL
        /// </summary>
        public const string IsValidEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        /// <summary>
        /// 验证字符串是否为IP
        /// </summary>
        public const string IsValidIp = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>
        /// 验证字符串是否为后缀名
        /// </summary>
        public const string IsValidPostfix = @"\.(?i:{0})$";

        /// <summary>
        /// 验证字符串是否为电话号码
        /// </summary>
        public const string IsValidTel = @"^\+?(\d{1,3}(-| ))?0?(\d{2,3}(-| ))?\d{2,4}(-| )?\d{3,4}(-\d{1,4})?$";

        /// <summary>
        /// 验证字符串是否为手机号码
        /// </summary>
        public const string IsValidMobile = @"^\+?(\d{1,3}(-| ))?1\d{2}(-| )?\d{4}(-| )?\d{4}$";

        /// <summary>
        /// 验证字符串是否为URL
        /// </summary>
        public const string IsValidUrl = @"^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";

        #region 常用方法

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <returns>替换后字符串</returns>
        public static string ReplaceInput(string input, string regex)
        {
            return Regex.Replace(input, regex, string.Empty);
        }

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="replace">替换字符串</param>
        /// <returns>替换后字符串</returns>
        public static string ReplaceInput(string input, string regex, string replace)
        {
            return Regex.Replace(input, regex, replace);
        }

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <returns>是否验证通过</returns>
        public static bool CheckInput(string input, string regex)
        {
            return Regex.IsMatch(input, regex);
        }

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="begin">开始数字</param>
        /// <param name="end">结尾数字</param>
        /// <returns>是否验证通过</returns>
        public static bool ValidByte(string input, string regex, int begin, int end)
        {
            if (string.IsNullOrEmpty(regex)) return false;

            var rep = regex.Replace("#0#", begin.ToString(CultureInfo.InvariantCulture));
            rep = rep.Replace("#1#", end.ToString(CultureInfo.InvariantCulture));
            var ret = CheckInput(input, rep);
            return ret;
        }

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="fix">后缀名</param>
        /// <returns>是否验证通过</returns>
        public static bool ValidPostfix(string input, string regex, string fix)
        {
            var ret = string.Format(CultureInfo.InvariantCulture, regex, fix);
            return CheckInput(input, ret);
        }

        #endregion
    }
}
