using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{
    [ServiceContract]
    public interface ILogin
    {

        /// <summary>
        /// 根据用户登录名获取可登录部门列表
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <returns>DataTable 可登录部门列表</returns>
        [OperationContract]
        DataTable GetDeptList(string loginName);

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        [OperationContract]
        Session UserLogin(Session us);

        /// <summary>
        /// 获取客户端文件列表
        /// </summary>
        /// <returns>FileAttribute List 文件列表</returns>
        [OperationContract]
        List<UpdateFile> GetServerList();

        /// <summary>
        /// 根据更新信息获取更新文件
        /// </summary>
        /// <param name="file">更新信息对象实体</param>
        /// <returns>byte[] 更新文件</returns>
        [OperationContract]
        byte[] GetFile(UpdateFile file);

    }
}
