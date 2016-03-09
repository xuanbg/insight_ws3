using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service
{

    public partial interface IBase
    {

        /// <summary>
        /// 获取全部编码方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 编码方案列表</returns>
        [OperationContract]
        DataTable GetSchemes(Session us);

        /// <summary>
        /// 获取全部流水码使用记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 使用记录</returns>
        [OperationContract]
        DataTable GetSerialRecord(Session us);

        /// <summary>
        /// 获取全部流水码分配记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 分配记录</returns>
        [OperationContract]
        DataTable GetAllotRecord(Session us);

        /// <summary>
        /// 根据ID获取编码方案对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">编码方案ID</param>
        /// <returns>SYS_Code_Scheme 编码方案对象实体</returns>
        [OperationContract]
        SYS_Code_Scheme GetScheme(Session us, Guid id);

        /// <summary>
        /// 根据传入参数获取编码方案预览
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">编码方案ID</param>
        /// <param name="code">编码格式</param>
        /// <param name="mark">分组规则</param>
        /// <returns>string 业务编码</returns>
        [OperationContract]
        string GetCodePreview(Session us, Guid sid, string code, string mark);

        /// <summary>
        /// 新增编码方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">编码方案对象实体</param>
        /// <returns>bool 数据是否插入成功</returns>
        [OperationContract]
        bool AddScheme(Session us, SYS_Code_Scheme obj);

        /// <summary>
        /// 更新编码方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj"></param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool UpdateScheme(Session us, SYS_Code_Scheme obj);

        /// <summary>
        /// 根据ID更新编码方案状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">编码方案ID</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool EnableScheme(Session us, Guid id);

        /// <summary>
        /// 根据ID删除编码方案或设为不可用
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">编码方案ID</param>
        /// <returns>int 0：失败；1、删除成功；2：设置为不可用</returns>
        [OperationContract]
        int DeleteScheme(Session us, Guid id);
        
    }
}
