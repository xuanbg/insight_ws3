using System.Configuration;

namespace Insight.WS.Client.Common
{
    public class Config
    {

        #region 读取配置项

        /// <summary>
        /// 获取保存的默认样式主题
        /// </summary>
        /// <returns></returns>
        public static string LookAndFeel()
        {
            return ConfigurationManager.AppSettings["DefaultLookAndFeel"];
        }

        /// <summary>
        /// 获取保存的默认打印机
        /// </summary>
        /// <param name="print"></param>
        /// <returns></returns>
        public static string Printer(string print)
        {
            return ConfigurationManager.AppSettings[print];
        }

        /// <summary>
        /// 获取合并打印选项
        /// </summary>
        /// <returns></returns>
        public static bool IsMergerPrint()
        {
            return bool.Parse(ConfigurationManager.AppSettings["IsMergerPrint"]);
        }

        /// <summary>
        /// 获取是否保存用户名选项设置
        /// </summary>
        /// <returns></returns>
        public static bool IsSaveUserInfo()
        {
            return bool.Parse(ConfigurationManager.AppSettings["IsSaveUserInfo"]);
        }

        /// <summary>
        /// 获取保存的用户名
        /// </summary>
        /// <returns></returns>
        public static string UserName()
        {
            return ConfigurationManager.AppSettings["UserName"];
        }

        /// <summary>
        /// 获取WCF服务基地址
        /// </summary>
        /// <returns></returns>
        public static string BaseAddress()
        {
            return ConfigurationManager.AppSettings["Address"];
        }

        /// <summary>
        /// 获取WCF服务端口
        /// </summary>
        /// <returns></returns>
        public static string Port()
        {
            return ConfigurationManager.AppSettings["Port"];
        }

        /// <summary>
        /// 获取数据库的地址
        /// </summary>
        /// <returns></returns>
        public static bool IsCompres()
        {
            return bool.Parse(ConfigurationManager.AppSettings["IsCompres"]);
        }

        #endregion

        #region 保存配置项

        /// <summary>
        /// 保存默认样式
        /// </summary>
        /// <param name="defaultLookAndFeel"></param>
        public static void SaveLookAndFeel(string defaultLookAndFeel)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["DefaultLookAndFeel"].Value = defaultLookAndFeel;

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 保存默认打印机
        /// </summary>
        /// <param name="print"></param>
        /// <param name="printName"></param>
        public static void SavePrinter(string print, string printName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings[print].Value = printName;

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 保存用户信息保存选项
        /// </summary>
        /// <param name="isMerger"></param>
        public static void SaveIsMergerPrint(bool isMerger)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["IsMergerPrint"].Value = isMerger.ToString();

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 保存用户信息保存选项
        /// </summary>
        /// <param name="isSave"></param>
        public static void SaveIsSaveUserInfo(bool isSave)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["IsSaveUserInfo"].Value = isSave.ToString();

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 保存用户名
        /// </summary>
        /// <param name="userName"></param>
        public static void SaveUserName(string userName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["UserName"].Value = userName;

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 保存WCF服务地址和端口
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public static void SaveAddress(string address, string port)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["Address"].Value = address;
            config.AppSettings.Settings["Port"].Value = port;

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        #endregion

    }
}
