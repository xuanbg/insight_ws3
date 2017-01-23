using System;
using System.Collections.Generic;
using Insight.Utils.Common;
using Insight.Utils.Entity;
using Insight.WS.Server.Common.Entity;

namespace Insight.WS.Server.Common.Utils
{
    public static class Parameters
    {
        private static readonly List<FileInfo> _FileList = new List<FileInfo>();
        private static DateTime _ReadTime;

        // 当前连接基础应用服务器
        public static string BaseServer = Util.GetAppSetting("BaseServer");

        // 验证接口URL
        public static string VerifyUrl = $"{BaseServer}/securityapi/v1.0/tokens/verify";

        // 数据库连接字符串
        public static string Database = new Entities().Database.Connection.ConnectionString;

        /// <summary>
        /// 客户端文件列表
        /// </summary>
        public static List<FileInfo> FileList
        {
            get
            {
                var span = DateTime.Now - _ReadTime;
                if (span.TotalMinutes < 30 && _FileList != null) return _FileList;

                _ReadTime = DateTime.Now;
                Util.GetLocalFiles(_FileList, $"{Environment.CurrentDirectory}\\Client", ".dll|.exe|.frl");
                return _FileList;
            }
        }
    }
}