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
        /// 获取全部用户组
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部用户组结果集</returns>
        [OperationContract]
        DataTable GetGroups(Session us);

        /// <summary>
        /// 根据ID获取用户组对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户组ID</param>
        /// <returns>SYS_UserGroup 用户组对象</returns>
        [OperationContract]
        SYS_UserGroup GetGroup(Session us, Guid id);

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部用户结果集</returns>
        [OperationContract]
        DataTable GetUsers(Session us);

        /// <summary>
        /// 根据ID获取用户对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <returns>SYS_User 用户对象</returns>
        [OperationContract]
        SYS_User GetUser(Session us, Guid id);

        /// <summary>
        /// 获取全部用户组的所有成员信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部用户组成员信息结果集</returns>
        [OperationContract]
        DataTable GetGroupMembers(Session us);

        /// <summary>
        /// 根据ID获取组成员之外的全部用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户组ID</param>
        /// <returns>DataTable 组成员之外所有用户信息结果集</returns>
        [OperationContract]
        DataTable GetGroupMemberBeSides(Session us, Guid id);

        /// <summary>
        /// 根据对象实体数据新增一个用户组
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户组对象</param>
        /// <returns>object 插入的用户组ID </returns>
        [OperationContract]
        object AddGroup(Session us, SYS_UserGroup obj);

        /// <summary>
        /// 根据对象实体数据新增一个用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户对象</param>
        /// <returns>bool 是否插入成功</returns>
        [OperationContract]
        bool AddUser(Session us, SYS_User obj);

        /// <summary>
        /// 根据参数组集合批量插入用户组成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="gid">用户组ID</param>
        /// <param name="uids">用户ID集合</param>
        /// <returns>bool 是否插入成功</returns>
        [OperationContract]
        bool AddGroupMember(Session us, Guid gid, List<Guid> uids);

        /// <summary>
        /// 根据对象实体数据更新用户组信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户组对象</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool UpdateGroup(Session us, SYS_UserGroup obj);

        /// <summary>
        /// 根据对象实体数据更新用户信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户对象</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool UpdateUser(Session us, SYS_User obj);

        /// <summary>
        /// 根据ID封禁/解封用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <param name="validity">true:解封；false:封禁</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool UpdateUserStatus(Session us, Guid id, bool validity);

        /// <summary>
        /// 根据ID删除用户组
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户组ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteGroup(Session us, Guid id);

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteUser(Session us, Guid id);

        /// <summary>
        /// 根据ID集合删除用户组成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="ids">户组成员关系ID集合</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteMember(Session us, List<Guid> ids);

    }
}
