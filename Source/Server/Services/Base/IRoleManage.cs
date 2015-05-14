using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{

    public partial interface IBase
    {

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色信息结果集</returns>
        [OperationContract]
        DataTable GetAllRole(Session us);

        /// <summary>
        /// 根据ID获取角色对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>SYS_Role 角色对象实体</returns>
        [OperationContract]
        SYS_Role GetRole(Session us, Guid id);

        /// <summary>
        /// 根据ID获取角色成员信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色成员信息结果集</returns>
        [OperationContract]
        DataTable GetRoleMember(Session us);

        /// <summary>
        /// 获取角色成员用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色成员用户信息结果集</returns>
        [OperationContract]
        DataTable GetRoleUser(Session us);

        /// <summary>
        /// 获取角色模块权限授权信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色模块权限授权信息结果集</returns>
        [OperationContract]
        DataTable GetRoleModulePermit(Session us);

        /// <summary>
        /// 获取角色操作权限授权信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色操作权限授权信息结果集</returns>
        [OperationContract]
        DataTable GetRoleActionPermit(Session us);

        /// <summary>
        /// 获取角色数据权限授权信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色数据权限授权信息结果集</returns>
        [OperationContract]
        DataTable GetRoleDataPermit(Session us);

        /// <summary>
        /// 根据角色ID获取可用的组织机构列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 可用的组织机构列表</returns>
        [OperationContract]
        DataTable GetMemberOfTitle(Session us, Guid id);

        /// <summary>
        /// 根据角色ID获取可用的用户组列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 可用的用户组列表</returns>
        [OperationContract]
        DataTable GetMemberOfGroup(Session us, Guid id);

        /// <summary>
        /// 根据角色ID获取可用的用户列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 可用的用户列表</returns>
        [OperationContract]
        DataTable GetMemberOfUser(Session us, Guid id);

        /// <summary>
        /// 获取指定角色的所有功能操作和授权
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 所有功能操作和授权</returns>
        [OperationContract]
        DataTable GetRoleActions(Session us, Guid id);

        /// <summary>
        /// 获取指定角色的所有相对数据权限
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 所有相对数据权限</returns>
        [OperationContract]
        DataTable GetRoleRelData(Session us, Guid id);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">角色对象实体</param>
        /// <param name="action">功能授权表</param>
        /// <param name="data">数据授权表</param>
        /// <param name="custom">自定义数据授权表</param>
        /// <returns>bool 数据插入是否成功</returns>
        [OperationContract]
        bool AddRole(Session us, SYS_Role obj, DataTable action, DataTable data, DataTable custom);

        /// <summary>
        /// 根据参数组集合插入角色成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <param name="tids">职位ID集合</param>
        /// <param name="gids">用户组ID集合</param>
        /// <param name="uids">用户ID集合</param>
        /// <returns>bool 插入是否成功</returns>
        [OperationContract]
        bool AddRoleMember(Session us, Guid id, List<Guid> tids, List<Guid> gids, List<Guid> uids);

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">角色对象实体</param>
        /// <param name="adl">功能删除列表</param>
        /// <param name="ddl">相对数据授权删除列表</param>
        /// <param name="cdl">绝对数据授权删除列表</param>
        /// <param name="adt">功能授权表</param>
        /// <param name="ddt">相对数据授权表</param>
        /// <param name="cdt">绝对数据授权表</param>
        /// <returns>bool 数据更新是否成功</returns>
        [OperationContract]
        bool EditRole(Session us, SYS_Role obj, List<object> adl, List<object> ddl, List<object> cdl, DataTable adt, DataTable ddt, DataTable cdt);

        /// <summary>
        /// 根据ID删除角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteRole(Session us, Guid id);

        /// <summary>
        /// 根据成员类型和ID删除角色成员
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">成员类型</param>
        /// <param name="id">角色成员ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DeleteRoleMember(Session us, int type, Guid id);
        
    }
}
