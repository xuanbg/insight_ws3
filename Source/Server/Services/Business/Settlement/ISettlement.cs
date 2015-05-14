using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service.Business
{
    [ServiceContract]
    public interface ISettlement
    {
        /// <summary>
        /// 获取结算记录日期列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 结算记录日期列表</returns>
        [OperationContract]
        DataTable GetClearingDate(Session us);

        /// <summary>
        /// 根据日期查询收款记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="date">收款日期</param>
        /// <returns>DataTable 收款记录</returns>
        [OperationContract]
        DataTable GetReceiptsForDate(Session us, Guid mid, string date);

        /// <summary>
        /// 根据付款人查询收款记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataTable 收款记录</returns>
        [OperationContract]
        DataTable GetReceiptsForName(Session us, Guid mid, string str);

        /// <summary>
        /// 根据付款人ID获取未履约数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">付款人ID</param>
        /// <param name="dirt">资金方向</param>
        /// <returns>DataTable 未履约数据</returns>
        [OperationContract]
        DataTable GetFundPlans(Session us, Guid id, int dirt);

        /// <summary>
        /// 根据付款人ID获取可用预付款对象实体集合
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">付款人ID</param>
        /// <returns>Advance List 可用预付款对象实体集合</returns>
        [OperationContract]
        List<Advance> GetAdvance(Session us, Guid id);

        /// <summary>
        /// 根据ID获取结算记录对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>ABS_Clearing 结算记录对象实体</returns>
        [OperationContract]
        ABS_Clearing GetReceipt(Session us, Guid cid);

        /// <summary>
        /// 根据ID获取收费项目列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 收费项目列表</returns>
        [OperationContract]
        DataTable GetReceiptItem(Session us, Guid cid);

        /// <summary>
        /// 根据ID获取结算方式列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 结算方式列表</returns>
        [OperationContract]
        DataTable GetReceiptPay(Session us, Guid cid);

        /// <summary>
        /// 根据ID获取附件列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 附件列表</returns>
        [OperationContract]
        DataTable GetReceiptAttach(Session us, Guid cid);

        /// <summary>
        /// 更新收据号
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">编码方案ID</param>
        /// <param name="bid">业务数据ID</param>
        /// <param name="mid">业务模块ID</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        object GetReceiptCode(Session us, Guid sid, Guid bid, Guid mid);

        /// <summary>
        /// 删除/作废收据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="bid">业务数据ID</param>
        /// <param name="type">操作类型</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool DelReceipt(Session us, Guid bid, int type);

        /// <summary>
        /// 保存结算记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">ABS_Clearing对象实体</param>
        /// <param name="idt">结算项目列表</param>
        /// <param name="pdt">结算方式列表</param>
        /// <returns>object 结算记录ID</returns>
        [OperationContract]
        object AddClearing(Session us, ABS_Clearing obj, DataTable idt, DataTable pdt);

        /// <summary>
        /// 插入结账记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="tid">模板ID</param>
        /// <param name="sid">编码方案ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddCheck(Session us, Guid tid, Guid sid);

    }
}
