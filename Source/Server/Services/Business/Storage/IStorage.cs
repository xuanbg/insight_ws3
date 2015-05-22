using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.Business
{
    [ServiceContract]
    public interface IStorage
    {

        #region 查询

        /// <summary>
        /// 获取结算记录日期列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 结算记录日期列表</returns>
        [OperationContract]
        DataTable GetDeliveryDate(Session us);

        /// <summary>
        /// 根据日期查询出入库记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="date">收款日期</param>
        /// <returns>DataTable 收款记录</returns>
        [OperationContract]
        DataTable GetDeliveryForDate(Session us, Guid mid, string date);

        /// <summary>
        /// 根据关键字查询出入库记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataTable 收款记录</returns>
        [OperationContract]
        DataTable GetDeliveryForName(Session us, Guid mid, string str);

        /// <summary>
        /// 根据申请单号获取未履约数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="code">申请单号</param>
        /// <returns>DataTable 未履约数据</returns>
        [OperationContract]
        DataTable Get_GoodsPlan(Session us, object code);

        /// <summary>
        /// 根据ID获取出入库物资列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 收费项目列表</returns>
        [OperationContract]
        DataTable GetDeliveryItem(Session us, Guid cid);

        /// <summary>
        /// 根据ID获取附件列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="did">结算记录ID</param>
        /// <returns>DataTable 附件列表</returns>
        [OperationContract]
        DataTable GetDeliveryAttach(Session us, Guid did);

        /// <summary>
        /// 根据ID获取结算记录对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>ABS_Clearing 结算记录对象实体</returns>
        [OperationContract]
        ABS_Delivery GetDelivery(Session us, Guid cid);

        #endregion

        #region 新增

        /// <summary>
        /// 保存收款记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">ABS_Clearing对象实体</param>
        /// <param name="idt">收款项目列表</param>
        /// <returns>object 收款记录ID</returns>
        [OperationContract]
        object AddDelivery(Session us, ABS_Delivery obj, DataTable idt);

        #endregion

        #region 编辑

        /// <summary>
        /// 更新出入库单据号
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">编码方案ID</param>
        /// <param name="bid">业务数据ID</param>
        /// <param name="mid">业务模块ID</param>
        /// <param name="str">附加字符串</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        object GetDeliveryCode(Session us, Guid sid, Guid bid, Guid mid, string str);

        #endregion

        #region 删除

        /// <summary>
        /// 删除/作废出入库单据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="bid">业务数据ID</param>
        /// <returns>bool 是否更新成功</returns>
        [OperationContract]
        bool DelDelivery(Session us, Guid bid);

        #endregion

    }

}
