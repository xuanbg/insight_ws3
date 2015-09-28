using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Insight.WS.Server.Common
{

    public class Util
    {

        /// <summary>
        /// 保存图片到image文件夹，通过URL访问
        /// </summary>
        /// <param name="pic">图片字节流</param>
        /// <param name="catalog">分类</param>
        /// <param name="name">文件名</param>
        /// <returns>string 图片保存路径</returns>
        public static string SaveImage(byte[] pic, string catalog, string name)
        {
            var local = ConfigurationManager.AppSettings["ImageLocal"];
            var path = string.Format("{0}/{1}/", local, catalog);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllBytes(path + name, pic);
            return string.Format("/Image/{0}/{1}", catalog, name);
        }

        /// <summary>
        /// 保存图片到个人文件夹
        /// </summary>
        /// <param name="pic">图片字节流</param>
        /// <param name="catalog">分类</param>
        /// <param name="link">可否通过URL访问</param>
        /// <returns>string 图片保存路径</returns>
        public static string SaveImage(byte[] pic, string catalog, bool link = false)
        {
            var local = ConfigurationManager.AppSettings["ImageLocal"];
            var path = string.Format("{0}/{1}/", local, catalog);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var img = Image.FromStream(new MemoryStream(pic));
            var name = string.Format("{0}.{1}", Guid.NewGuid(), GetImageExtension(img));
            File.WriteAllBytes(path + name, pic);
            return string.Format("{0}/{1}/{2}", link ? "/Image" : "", catalog, name);
        }

        /// <summary>
        /// 获取图片格式名称
        /// </summary>
        /// <param name="img">图片</param>
        /// <returns>string 图片格式</returns>
        public static string GetImageExtension(Image img)
        {
            var list = typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var n in from n in list let format = (ImageFormat) n.GetValue(null, null) where format.Guid.Equals(img.RawFormat.Guid) select n)
            {
                return n.Name;
            }
            return "unknown";
        }

        /// <summary>
        /// 计算输入日期后的特定日期
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="n">特定日期（0-9）</param>
        /// <returns>DateTime 特定日期</returns>
        public static DateTime FormatDate(DateTime date, int n)
        {
            var day = date.Day;
            var mod = day % 10;
            day = (day - mod + n + (mod > n ? 10 : 0)) % 30;

            return DateTime.Parse(date.ToString("yyyy-MM-dd").Substring(0, 8) + day.ToString("00")).AddMonths(date.Day > 20 + n ? 1 : 0);
        }

        /// <summary>
        /// 将事件消息写入系统日志
        /// </summary>
        /// <param name="msg">Log消息</param>
        /// <param name="type">Log类型</param>
        public static void LogToEvent(string msg, EventLogEntryType type = EventLogEntryType.Error)
        {
            EventLog.WriteEntry("Insight Workstation 3 Service", msg, type);
        }

    }
}
