using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Insight.WS.Server.Common
{

    public class Util
    {

        /// <summary>
        /// 读取配置项的值
        /// </summary>
        /// <param name="key">配置项</param>
        /// <returns>配置项的值</returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="msg">发送的消息</param>
        public static void SendMsg(string number, string msg)
        {
            string url;
            string cont;
            switch (GetAppSetting("Channel"))
            {
                case "1":
                    url = GetAppSetting("surl");
                    var name = GetAppSetting("sname");
                    var pwd = GetAppSetting("spwd");
                    var corpid = GetAppSetting("scorpid");
                    var prdid = GetAppSetting("sprdid");
                    cont = $"{url}?sname={name}&spwd={pwd}&scorpid={corpid}&sprdid={prdid}&sdst={number}&smsg={msg}";
                    break;

                default:
                    url = GetAppSetting("Url");
                    var uid = GetAppSetting("UId");
                    var account = GetAppSetting("Account");
                    var password = GetAppSetting("Password");
                    cont = $"{url}?action=send&userid={uid}&account={account}&password={password}&mobile={number}&content={msg}&sendTime=&extno=";
                    break;
            }
            HttpGet(cont, "");
        }

        /// <summary>
        /// 保存图片到image文件夹，通过URL访问
        /// </summary>
        /// <param name="pic">图片字节流</param>
        /// <param name="catalog">分类</param>
        /// <param name="name">文件名（可选）</param>
        /// <returns>string 图片保存路径</returns>
        public static string SaveImage(byte[] pic, string catalog, string name = null)
        {
            var path = $"{GetAppSetting("ImageLocal")}\\{catalog}\\";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (name == null)
                {
                    var img = Image.FromStream(new MemoryStream(pic));
                    name = $"{Guid.NewGuid()}.{GetImageExtension(img)}";
                }

                File.WriteAllBytes(path + name, pic);
                return $"/{catalog}/{name}";
            }
            catch (Exception ex)
            {
                LogToEvent(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取图片格式名称
        /// </summary>
        /// <param name="img">图片</param>
        /// <returns>string 图片格式</returns>
        public static string GetImageExtension(Image img)
        {
            var list = typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public);
            var name = from n in list
                let format = (ImageFormat) n.GetValue(null, null)
                where format.Guid.Equals(img.RawFormat.Guid)
                select n;
            var names = name.ToList();
            return names.Count > 0 ? names[0].Name : "unknown";
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
        /// <param name="type">Log类型（默认Error）</param>
        /// <param name="source">事件源（默认Insight Workstation 3 Service）</param>
        public static void LogToEvent(string msg, EventLogEntryType type = EventLogEntryType.Error, string source = "XinFenBao Interface Service")
        {
            EventLog.WriteEntry(source, msg, type);
        }

        /// <summary>
        /// Post数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string url, string postDataStr)
        {
            var cookie = new CookieContainer();
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookie;

            var myStreamWriter = new StreamWriter(request.GetRequestStream());
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            var response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookie.GetCookies(response.ResponseUri);
            var myResponseStream = response.GetResponseStream();
            if (myResponseStream == null) return null;

            var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            var retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// Get数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string url, string postDataStr)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            var response = (HttpWebResponse)request.GetResponse();
            var myResponseStream = response.GetResponseStream();
            if (myResponseStream == null) return null;

            var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            var retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

    }
}
