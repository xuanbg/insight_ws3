using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{
    public partial interface ICommons
    {

        #region 获取数据

        /// <summary>
        /// 获取用户获得授权的所有模块的组信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 模块组列表</returns>
        [OperationContract]
        DataTable GetModuleGroup(Session us);

        /// <summary>
        /// 获取用户获得授权的所有模块信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 模块列表</returns>
        [OperationContract]
        DataTable GetUserModule(Session us);

        /// <summary>
        /// 根据ID获取模块对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">模块ID</param>
        /// <returns>SYS_Module 模块对象实体</returns>
        [OperationContract]
        SYS_Module GetModuleInfo(Session us, Guid id);

        /// <summary>
        /// 获取用户启动模块的工具栏操作信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">模块ID</param>
        /// <returns>DataTable 工具栏功能列表</returns>
        [OperationContract]
        DataTable GetAction(Session us, Guid id);

        #endregion

        #region 更新数据

        /// <summary>
        /// 修改指定登录名的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        [OperationContract]
        bool UpdataPassWord(Session us, string pw);

        #endregion

    }
}
