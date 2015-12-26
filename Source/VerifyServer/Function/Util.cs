using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Insight.WS.Verify
{
    public static class Util
    {

        #region 静态字段

        /// <summary>
        /// 在线用户列表
        /// </summary>
        public static List<Session> Sessions = new List<Session>();

        /// <summary>
        /// 运行中的服务主机
        /// </summary>
        public static ServiceHost Host;

        /// <summary>
        /// 系统连结字符串字典
        /// </summary>
        public static Dictionary<string, string> ConStr;

        /// <summary>
        /// 短信验证码的缓存列表
        /// </summary>
        public static readonly List<VerifyRecord> SmsCodes = new List<VerifyRecord>();

        /// <summary>
        /// 用于生成短信验证码的随机数发生器
        /// </summary>
        public static readonly Random Random = new Random(Environment.TickCount);

        #endregion

        #region 静态构造方法

        /// <summary>
        /// 静态构造函数，初始化系统连结字符串字典
        /// </summary>
        static Util()
        {
            var list = ConfigurationManager.ConnectionStrings;
            ConStr = new Dictionary<string, string> { { "Template", null } };
            for (var i = 0; i < list.Count; i++)
            {
                var name = list[i].Name;
                if (name.Contains("Local")) continue;

                ConStr.Add(name, new Entities(name).ConnectionString);
            }
        }

        #endregion

        #region 静态公共方法

        public static void CreateHost()
        {
            var address = new Uri(GetAppSetting("Address"));
            var binding = new NetTcpBinding();
            Host = new ServiceHost(typeof(OnlineManage), address);
            Host.AddServiceEndpoint(typeof(Interface), binding, "VerifyServer");
            if (GetAppSetting("Mode") != "debug") return;

            // 添加元数据服务
            var behavior = new ServiceMetadataBehavior();
            var ExchangeBindings = MetadataExchangeBindings.CreateMexTcpBinding();
            Host.Description.Behaviors.Add(behavior);
            Host.AddServiceEndpoint(typeof(IMetadataExchange), ExchangeBindings, "VerifyServer/mex");
        }

        /// <summary>
        /// 根据用户登录名获取用户对象实体
        /// </summary>
        /// <param name="str">用户登录名</param>
        /// <returns>SYS_User 用户对象实体</returns>
        public static SYS_User GetUser(string str)
        {
            using (var context = new WSEntities())
            {
                return context.SYS_User.SingleOrDefault(s => s.LoginName == str);
            }
        }

        /// <summary>
        /// 根据用户登录名获取用户对象实体
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>SYS_User 用户对象实体</returns>
        public static SYS_User GetUser(Guid id)
        {
            using (var context = new WSEntities())
            {
                return context.SYS_User.SingleOrDefault(u => u.ID == id);
            }
        }

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
        /// 计算字符串的Hash值
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>String Hash值</returns>
        public static string Hash(string str)
        {
            var md5 = MD5.Create();
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(str.Trim()));
            return s.Aggregate("", (current, c) => current + c.ToString("X2"));
        }

        /// <summary>
        /// 将事件消息写入系统日志
        /// </summary>
        /// <param name="msg">Log消息</param>
        /// <param name="type">Log类型（默认Error）</param>
        /// <param name="source">事件源（默认Insight Workstation 3 Service）</param>
        public static void LogToEvent(string msg, EventLogEntryType type = EventLogEntryType.Error, string source = "Insight VerifyServer Service")
        {
            EventLog.WriteEntry(source, msg, type);
        }

        /// <summary>
        /// 返回第一行第一列内容的方法
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="dataSouc">数据源名称</param>
        /// <returns>执行SQL语句后的第一行第一列内容</returns>
        public static object SqlScalar(SqlCommand cmd, string dataSouc = "WSEntities")
        {
            using (var conn = new SqlConnection(ConStr[dataSouc]))
            {
                conn.Open();
                cmd.Connection = conn;
                try
                {
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    LogToEvent(cmd.CommandText);
                    LogToEvent(ex.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// 组装SqlCommand对象
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <param name="parameters">可变长参数组</param>
        /// <returns>SqlCommand 组装完成的SqlCommand对象</returns>
        public static SqlCommand MakeCommand(string sql, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(sql);
            foreach (var p in parameters)
            {
                if (p.Value == null || p.Value.ToString() == "")
                {
                    p.Value = DBNull.Value;
                }
                cmd.Parameters.Add(p);
            }
            return cmd;
        }

    }

    #endregion

}
