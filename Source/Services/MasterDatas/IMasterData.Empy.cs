using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service
{
    public partial interface IMasterDatas
    {

        /// <summary>
        /// 根据部门ID获取部门员工列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">部门ID</param>
        /// <returns>DataTable 部门员工列表</returns>
        [OperationContract]
        DataTable GetEmployees(Session us, Guid oid);

        /// <summary>
        /// 根据员工姓名获取员工列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">员工姓名</param>
        /// <returns>DataTable 部门员工列表</returns>
        [OperationContract]
        DataTable GetEmployeesForName(Session us, string name);

        /// <summary>
        /// 根据ID获取员工对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">员工ID</param>
        /// <returns>MDG_Employee 员工对象实体</returns>
        [OperationContract]
        MDG_Employee GetEmployee(Session us, Guid id);

        /// <summary>
        /// 获取员工职位关系对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">员工ID</param>
        /// <returns>MDR_ET 职位关系对象实体</returns>
        [OperationContract]
        MDR_ET GetEmployeeTitle(Session us, Guid id);

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Employee对象实体</param>
        /// <param name="r">MDR_ET对象实体</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddEmployee(Session us, MasterData m, MDG_Employee d, MDR_ET r, DataTable cdt);

        /// <summary>
        /// 更新员工和联系方式
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Employee对象实体</param>
        /// <param name="r">MDR_ET对象实体</param>
        /// <param name="cdl">联系方式删除列表</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateEmployee(Session us, MasterData m, MDG_Employee d, MDR_ET r, List<object> cdl, DataTable cdt);

        /// <summary>
        /// 更新员工状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">员工ID</param>
        /// <param name="stu">状态</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool UpdateStatus(Session us, Guid id, int stu);

    }
}
