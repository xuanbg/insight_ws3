using System;
using System.Collections.Generic;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial interface ICommons
    {
        /// <summary>
        /// 获取模块有效选项参数
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid"></param>
        /// <returns>SYS_ModuleParam List 参数集合</returns>
        [OperationContract]
        List<SYS_ModuleParam> GetModuleParam(Session us, Guid mid);

        /// <summary>
        /// 获取模块个人选项参数
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <returns>SYS_ModuleParam List 参数集合</returns>
        [OperationContract]
        List<SYS_ModuleParam> GetModuleUserParam(Session us, Guid mid);

        /// <summary>
        /// 获取模块部门选项参数
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <returns>SYS_ModuleParam List 参数集合</returns>
        [OperationContract]
        List<SYS_ModuleParam> GetModuleDeptParam(Session us, Guid mid);

        /// <summary>
        /// 保存模块选项参数
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="apl">新增参数集合</param>
        /// <param name="upl">更新参数集合</param>
        /// <returns></returns>
        [OperationContract]
        bool SaveModuleParam(Session us, List<SYS_ModuleParam> apl, List<SYS_ModuleParam> upl);

    }
}
