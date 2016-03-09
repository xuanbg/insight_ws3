using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{

    public partial interface IBase
    {

        /// <summary>
        /// 获取组织机构树
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 组织机构节点信息结果集</returns>
        [OperationContract]
        DataTable GetOrgs(Session us);

        /// <summary>
        /// 根据ID获取机构对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">节点ID</param>
        /// <returns>SYS_Organization 节点对象</returns>
        [OperationContract]
        SYS_Organization GetOrg(Session us, Guid id);

        /// <summary>
        /// 获取所有职位成员用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 节点成员信息结果集</returns>
        [OperationContract]
        DataTable GetOrgMembers(Session us);

        /// <summary>
        /// 获取职位成员之外的所有用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">节点ID</param>
        /// <returns>DataTable 节点可添加成员信息结果集</returns>
        [OperationContract]
        DataTable GetOrgMemberBeSides(Session us, Guid id);

        /// <summary>
        /// 根据对象实体数据新增一个组织机构节点
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点对象</param>
        /// <param name="index">原序号</param>
        /// <returns>object 插入成功返回插入的节点ID；失败返回false</returns>
        [OperationContract]
        bool AddOrg(Session us, SYS_Organization obj, int index);

        /// <summary>
        /// 根据对象实体数据新增一条组织机构节点合并记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点合并对象</param>
        /// <returns>bool 是否插入成功</returns>
        [OperationContract]
        bool AddOrgMerger(Session us, SYS_OrgMerger obj);

        /// <summary>
        /// 根据参数组集合批量插入职位成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid"></param>
        /// <param name="uids">用户ID集合</param>
        /// <returns>bool 是否插入成功</returns>
        [OperationContract]
        bool AddOrgMember(Session us, Guid oid, List<Guid> uids);

        /// <summary>
        /// 根据对象实体数据更新组织机构信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点对象</param>
        /// <param name="index">原序号</param>
        /// <returns>bool 是否插入成功</returns>
        [OperationContract]
        bool UpdateOrg(Session us, SYS_Organization obj, int index);

        /// <summary>
        /// 根据对象实体数据更新组织机构表ParentId字段
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点对象</param>
        /// <returns>int 更新成功的记录数量</returns>
        [OperationContract]
        bool UpdateOrgParentId(Session us, SYS_Organization obj);

        /// <summary>
        /// 根据ID删除组织机构节点
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid"></param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteOrg(Session us, Guid oid);

        /// <summary>
        /// 根据ID集合删除职位成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="ids">职位成员关系ID集合</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteOrgMember(Session us, List<Guid> ids);

    }
}
