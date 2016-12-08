using System.Collections.Generic;
using Insight.Utils.Entity;
using Insight.WS.Server.Common.Entity;

namespace Insight.WS.Server.Common.Utils
{
    public static class Parameters
    {
        // 当前连接基础应用服务器
        public static string BaseServer;

        // 验证接口URL
        public static string VerifyUrl;

        // 数据库连接字符串
        public static string Database = new Entities().Database.Connection.ConnectionString;

        // 客户端文件列表
        public static List<FileInfo> FileList;
    }
}
