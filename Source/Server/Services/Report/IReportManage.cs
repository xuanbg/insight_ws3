using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{

    public partial interface IReport
    {

        /// <summary>
        /// 获取全部报表信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 报表信息列表</returns>
        [OperationContract]
        DataTable GetReports(Session us);

        /// <summary>
        /// 获取全部报表的分期信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 分期信息列表</returns>
        [OperationContract]
        DataTable GetReportRules(Session us);

        /// <summary>
        /// 获取全部报表的统计实体信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 统计实体信息列表</returns>
        [OperationContract]
        DataTable GetReportEntitys(Session us);

        /// <summary>
        /// 获取全部统计实体的报送对象信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 报送对象信息列表</returns>
        [OperationContract]
        DataTable GetReportMembers(Session us);

        /// <summary>
        /// 获取全部分期规则，当前报表所用规则对应Selected为1
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>DataTable 分期规则列表</returns>
        [OperationContract]
        DataTable GetReportRule(Session us, Guid id);

        /// <summary>
        /// 获取全部可选的机构/部门
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>DataTable 组织机构列表</returns>
        [OperationContract]
        DataTable GetReportEntity(Session us, Guid id);

        /// <summary>
        /// 获取全部成员列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>DataTable 成员列表</returns>
        [OperationContract]
        DataTable GetReportMember(Session us, Guid id);

        /// <summary>
        /// 新增报表定义
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="def">报表定义对象实体</param>
        /// <param name="rule">分期子表</param>
        /// <param name="entity">实体子表</param>
        /// <param name="member">报送子表</param>
        /// <returns>bool 数据是否插入成功</returns>
        [OperationContract]
        bool AddDefinition(Session us, SYS_Report_Definition def, DataTable rule, DataTable entity, DataTable member);

        /// <summary>
        /// 更新报表定义
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="def">报表定义对象实体</param>
        /// <param name="rdl">分期规则删除列表</param>
        /// <param name="edl">会计主体删除列表</param>
        /// <param name="mdl">报送成员删除列表</param>
        /// <param name="rdt">分期子表</param>
        /// <param name="edt">实体子表</param>
        /// <param name="mdt">报送子表</param>
        /// <returns>bool 数据是否更新成功</returns>
        [OperationContract]
        bool EditDefinition(Session us, SYS_Report_Definition def, List<object> rdl, List<object> edl, List<object> mdl, DataTable rdt, DataTable edt, DataTable mdt);

        /// <summary>
        /// 根据ID删除报表定义记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表定义ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DelReport(Session us, Guid id);

    }
}
