using System;
using System.Collections.Generic;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.XinFenBao
{
    [ServiceContract]
    public interface IXfbInterface
    {

        #region 地址数据

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据集合</returns>
        [OperationContract]
        List<States> GetStates();

        /// <summary>
        /// 根据省ID获取地市数据
        /// </summary>
        /// <param name="stateId">省ID</param>
        /// <returns>地市数据集合</returns>
        [OperationContract]
        List<Citys> GetCitys(Guid stateId);

        /// <summary>
        /// 根据地市ID获取县市数据
        /// </summary>
        /// <param name="cityId">地市ID</param>
        /// <returns>县市数据集合</returns>
        [OperationContract]
        List<Countys> GetCountys(Guid cityId);

        /// <summary>
        /// 获取会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>收货地址列表</returns>
        [OperationContract]
        List<BIZ_Delivery_Address> GetAddresses(Session us);

        /// <summary>
        /// 新增会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddDeliveryAddress(Session us, BIZ_Delivery_Address obj);

        #endregion

        #region 新增


        #endregion

        #region 编辑


        #endregion

        #region 会员

        /// <summary>
        /// 获取用户Session对象实体
        /// </summary>
        /// <param name="ln">登录账号</param>
        /// <param name="pw">登录密码</param>
        /// <returns>Session 用户Session对象实体</returns>
        [OperationContract]
        Session GetSession(string ln, string pw);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        [OperationContract]
        Session UserLogin(Session obj);

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <param name="code">验证码</param>
        /// <returns>Session对象实体</returns>
        [OperationContract]
        Session Register(Session obj, string code);

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">会员姓名</param>
        /// <param name="member">会员对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateMember(Session us, string name, MDG_Member member);

        /// <summary>
        /// 修改指定用户的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        [OperationContract]
        bool UpdataPassword(Session us, string pw);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <param name="code">验证码</param>
        /// <returns>Session对象实体</returns>
        [OperationContract]
        Session ResetPassword(Session obj, string code);

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="type">验证码类型</param>
        /// <returns>string 验证码</returns>
        [OperationContract]
        string GetVerifyCode(string number, int type);

        #endregion

    }

}
