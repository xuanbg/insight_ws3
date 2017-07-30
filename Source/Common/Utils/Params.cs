using System;
using System.Collections.Generic;
using System.IO;
using Insight.Utils.Common;
using Insight.Utils.Server;
using Insight.WS.Server.Common.Entity;
using StackExchange.Redis;

namespace Insight.WS.Server.Common.Utils
{
    public static class Params
    {
        private static List<Insight.Utils.Entity.FileInfo> _FileList;
        private static DateTime _ReadTime;
        private static readonly string _RedisConn = Util.GetAppSetting("Redis");

        // 当前连接基础应用服务器
        public static string BaseServer = Util.GetAppSetting("BaseServer");

        // 验证接口URL
        public static string VerifyUrl = $"{BaseServer}/securityapi/v1.0/tokens/verify";

        // 数据库连接字符串
        public static string Database = new Entities().Database.Connection.ConnectionString;

        // Redis链接对象
        public static readonly ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect(_RedisConn);

        // 访问管理
        public static CallManage CallManage = new CallManage(Redis);

        /// <summary>
        /// 客户端文件列表
        /// </summary>
        public static List<Insight.Utils.Entity.FileInfo> FileList
        {
            get
            {
                var span = DateTime.Now - _ReadTime;
                if (span.TotalMinutes < 30 && _FileList != null) return _FileList;

                _ReadTime = DateTime.Now;
                _FileList = new List<Insight.Utils.Entity.FileInfo>();
                var dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                Util.GetLocalFiles(_FileList, $"{dirInfo.FullName}Client", ".dll|.exe|.frl");

                return _FileList;
            }
        }
    }
}