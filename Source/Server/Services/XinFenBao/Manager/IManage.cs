using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.XinFenBao
{

    [ServiceContract]
    public interface IManager
    {

        #region 授信

        /// <summary>
        /// 获取审核日期列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 审核日期列表</returns>
        [OperationContract]
        DataTable GetCheckListDate(Session us);

        /// <summary>
        /// 按日期查询审核列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="date">日期</param>
        /// <returns>DataTable 审核列表</returns>
        [OperationContract]
        DataTable GetCheckListForDate(Session us, string date);

        /// <summary>
        /// 按手机号查询审核列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">手机号</param>
        /// <returns>DataTable 审核列表</returns>
        [OperationContract]
        DataTable GetCheckListForName(Session us, string name);

        /// <summary>
        /// 待审核列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 审核列表</returns>
        [OperationContract]
        DataTable GetAuditList(Session us);

        #endregion

        #region 提现

        #endregion

        #region 订单

        #endregion

        #region 意见反馈

        /// <summary>
        /// 获取意见反馈日期列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 结算记录日期列表</returns>
        [OperationContract]
        DataTable GetFeedbackDate(Session us);

        /// <summary>
        /// 按日期查询意见反馈
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="date">日期</param>
        /// <returns>DataTable 意见反馈列表</returns>
        [OperationContract]
        DataTable GetFeedBacksForDate(Session us, string date);

        /// <summary>
        /// 按手机号查询意见反馈
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">手机号</param>
        /// <returns>DataTable 意见反馈列表</returns>
        [OperationContract]
        DataTable GetFeedBacksForName(Session us, string name);

        /// <summary>
        /// 根据ID获取用户意见对象
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户意见ID</param>
        /// <returns>MDE_Member_Feedback 用户意见对象</returns>
        [OperationContract]
        MDE_Member_Feedback GetFeedback(Session us, Guid id);

        /// <summary>
        /// 保存用户意见
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户意见对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SaveReply(Session us, MDE_Member_Feedback obj);

        /// <summary>
        /// 用户意见归档
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户意见对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool Pigeonhole(Session us, MDE_Member_Feedback obj);

        #endregion

        #region 分期方案

        /// <summary>
        /// 获取分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>分期方案列表</returns>
        [OperationContract]
        List<BIZ_StagePlan> GetStagePlans(Session us);

        /// <summary>
        /// 增加分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">分期方案对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddStagePlan(Session us, BIZ_StagePlan obj);

        /// <summary>
        /// 根据ID设置为默认分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期方案ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SetDefault(Session us, Guid id);

        /// <summary>
        /// 删除分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期方案ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DeletePlan(Session us, Guid id);

        #endregion

        #region 轮播

        /// <summary>
        /// 获取广告商品列表
        /// </summary>
        /// <param name="us"></param>
        /// <returns>广告商品列表</returns>
        [OperationContract]
        List<BIZ_Advertiser> GetAdvertisers(Session us);

        /// <summary>
        /// 增加轮播图
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">轮播广告对象</param>
        /// <param name="img">轮播图</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddAdvertiser(Session us, BIZ_Advertiser obj, byte[] img);

        /// <summary>
        /// 编辑轮播图
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">轮播广告对象</param>
        /// <param name="img">轮播图</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool EditAdvertiser(Session us, BIZ_Advertiser obj, byte[] img);

        /// <summary>
        /// 根据ID删除轮播图
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">轮播图ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DelAdvertiser(Session us, Guid id);

        #endregion

    }

}
