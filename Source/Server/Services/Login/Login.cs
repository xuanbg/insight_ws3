using System.Data;
using System.Net;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{
    public class Login : ILogin
    {

        /// <summary>
        /// 根据用户登录名获取可登录部门列表
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <returns>DataTable 可登录部门列表</returns>
        public DataTable GetDeptList(string loginName)
        {
            var sql = $"select * from dbo.Get_LoginDept('{loginName}')";
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public Session UserLogin(Session obj)
        {
            return CommonDAL.UserLogin(obj);
        }

        /// <summary>
        /// 根据更新信息获取更新文件
        /// </summary>
        /// <param name="file">更新信息对象实体</param>
        /// <returns>UpdateFile 更新信息对象实体</returns>
        public UpdateFile GetFile(UpdateFile file)
        {
            var webRes = WebRequest.Create(file.FullPath).GetResponse();
            var stream = webRes.GetResponseStream();
            file.FileBytes = new byte[webRes.ContentLength];
            stream?.Read(file.FileBytes, 0, file.FileBytes.Length);
            stream?.Close();
            return file;
        }

    }
}
