using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{
    public class Login : ILogin
    {

        private string _RootPath;

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
        /// 获取客户端文件列表
        /// </summary>
        /// <returns>FileAttribute List 文件列表</returns>
        public List<UpdateFile> GetServerList()
        {
            _RootPath = Application.StartupPath + "\\Client";
            var list = new List<UpdateFile>();
            return GetLocalList(_RootPath, list);
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
            stream.Read(file.FileBytes, 0, file.FileBytes.Length);
            stream.Close();
            return file;
        }

        /// <summary>
        /// 获取客户端文件列表
        /// </summary>
        /// <param name="dir">客户端文件路径</param>
        /// <param name="list">文件列表</param>
        /// <returns>FileAttribute List 文件列表</returns>
        private List<UpdateFile> GetLocalList(string dir, List<UpdateFile> list)
        {
            var dirInfo = new DirectoryInfo(dir);
            list.AddRange(from file in dirInfo.GetFiles()
                          where ".dll.exe.frl".IndexOf(file.Extension) >= 0
                          select new UpdateFile
                          {
                              Name = file.Name,
                              Path = file.DirectoryName.Replace(_RootPath, ""),
                              FullPath = file.FullName, 
                              Version = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion
                          });

            var dirs = Directory.GetDirectories(dir);
            foreach (var path in dirs)
            {
                GetLocalList(path, list);
            }
            return list;
        }

    }
}
