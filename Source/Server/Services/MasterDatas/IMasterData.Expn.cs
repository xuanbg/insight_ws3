using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial interface IMasterDatas
    {

        /// <summary>
        /// 获取全部费用项目
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部费用项目列表</returns>
        [OperationContract]
        DataTable GetExpenses(Session us);

        /// <summary>
        /// 根据ID获取收支项目对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">收支项目ID</param>
        /// <returns>MDG_Expense 收支项目对象实体</returns>
        [OperationContract]
        MDG_Expense GetExpense(Session us, Guid id);

        /// <summary>
        /// 添加费用项目
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Expense对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddExpense(Session us, MasterData m, MDG_Expense d, int i);

        /// <summary>
        /// 更新费用项目
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Expense对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateExpense(Session us, MasterData m, MDG_Expense d, int i);

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">收支项目ID</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        [OperationContract]
        int DelExpense(Session us, Guid id);

    }
}