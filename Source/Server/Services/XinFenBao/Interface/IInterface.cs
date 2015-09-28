using System;
using System.Collections.Generic;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;
using Insight.WS.Server.Common.YUN;

namespace Insight.WS.Service.XinFenBao
{
    [ServiceContract]
    public interface IInterface
    {

        #region 商品

        /// <summary>
        /// 获取轮播广告列表
        /// </summary>
        /// <returns>轮播广告列表</returns>
        [OperationContract]
        List<BIZ_Advertiser> GetAdvertisers();

        /// <summary>
        /// 获取云商商品列表
        /// </summary>
        /// <param name="site"></param>
        /// <returns>云商商品列表</returns>
        [OperationContract]
        List<Products> GetProducts(string site);

        /// <summary>
        /// 获取云商推荐商品列表
        /// </summary>
        /// <param name="site"></param>
        /// <returns>云商推荐商品列表</returns>
        [OperationContract]
        List<Products> GetRecProducts(string site);

        /// <summary>
        /// 获取云商分类商品列表
        /// </summary>
        /// <param name="category">分类名称</param>
        /// <param name="site"></param>
        /// <returns>云商分类商品列表</returns>
        [OperationContract]
        List<Products> GetCatProducts(string category, string site);

        /// <summary>
        /// 根据商品名称关键字查询云商商品
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="site"></param>
        /// <returns>云商商品列表</returns>
        [OperationContract]
        List<Products> FindProduct(string key, string site);

        /// <summary>
        /// 获取云商商品
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>云商商品对象</returns>
        [OperationContract]
        Products GetProduct(int id);

        /// <summary>
        /// 根据商品ID获取商品轮播图片
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>商品图片对象列表</returns>
        [OperationContract]
        List<Product_Library_Img> GetProductImage(int id);

        /// <summary>
        /// 获取商品可选参数集合
        /// </summary>
        /// <param name="pid">商品ID</param>
        /// <returns>商品可选参数集合</returns>
        [OperationContract]
        List<string> GetProductParm(int pid);

        /// <summary>
        /// 获取商品可选参数
        /// </summary>
        /// <param name="pid">商品ID</param>
        /// <returns>string 商品可选参数</returns>
        [OperationContract]
        List<string> GetProductParms(int pid);

        /// <summary>
        /// 根据所选参数获取商品ID
        /// </summary>
        /// <param name="parms">商品参数</param>
        /// <returns>int 商品ID</returns>
        [OperationContract]
        int GetProductId(string parms);

        #endregion

        #region 订单

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>订单列表</returns>
        [OperationContract]
        List<OrderList> GetOrderList(Session us);

        /// <summary>
        /// 根据订单ID获取订单信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <returns>BIZ_Order 订单对象</returns>
        [OperationContract]
        BIZ_Order GetOrder(Session us, Guid oid);

        /// <summary>
        /// 根据订单号获取商品快照
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">标的ID</param>
        /// <returns>商品快照集合</returns>
        [OperationContract]
        BIZ_Product_Snapshot GetSnapshot(Session us, Guid sid);

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="order">订单扩展</param>
        /// <param name="pid">商品ID</param>
        /// <returns>object 订单号</returns>
        [OperationContract]
        object AddOrder(Session us, BIZ_Order order, int pid);

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="order">MDE_Member_Withdrawal对象实体</param>
        /// <param name="obj"></param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool Withdrawal(Session us, BIZ_Order order, MDE_Member_Withdrawal obj);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DeleteOrder(Session us, Guid oid);

        #endregion

        #region 账单

        /// <summary>
        /// 确认分期，生成账单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <param name="payCode">首付款支付业务号</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddBill(Session us, Guid oid, string payCode);

        /// <summary>
        /// 根据标的ID获取订单列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">标的ID</param>
        /// <returns>账单列表</returns>
        [OperationContract]
        List<BillList> GetBillList(Session us, Guid oid);

        /// <summary>
        /// 根据账单ID还款
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="objs">资金履约对象集合</param>
        /// <param name="payCode">支付业务号</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool BillPerform(Session us, List<ABS_Contract_FundPerform> objs, string payCode);

        #endregion

        #region 会员

        /// <summary>
        /// 获取用户用户会话
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pw">登录密码</param>
        /// <returns>Session 用户用户会话</returns>
        [OperationContract]
        Session GetSession(Guid id, string pw);

        /// <summary>
        /// 获取用户授信额度
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>decimal 授信额度</returns>
        [OperationContract]
        decimal GetLoans(Session us);

        /// <summary>
        /// 获取用户可用额度
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>decimal 可用额度</returns>
        [OperationContract]
        decimal GetAvailable(Session us);

        /// <summary>
        /// 会员认证状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>string 会员认证状态</returns>
        [OperationContract]
        string GetMemberStatus(Session us);

        /// <summary>
        /// 用户是否已设置支付密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否已设置支付密码</returns>
        [OperationContract]
        bool HasPayPassword(Session us);

        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否设置成功</returns>
        [OperationContract]
        string GetPortrait(Session us);

        /// <summary>
        /// 获取用户绑定银行卡列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>绑定银行卡列表</returns>
        [OperationContract]
        List<MDE_Member_Card> GetCards(Session us);

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">银行卡对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddCard(Session us, MDE_Member_Card obj);

        /// <summary>
        /// 提交意见反馈
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="msg">反馈意见</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool Feedback(Session us, string msg);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>用户会话</returns>
        [OperationContract]
        Session UserLogin(Session obj);

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="code">验证码</param>
        /// <param name="recom">推荐码</param>
        /// <param name="id">身份证号</param>
        /// <returns>用户会话</returns>
        [OperationContract]
        Session Register(Session obj, string code, string recom, string id);

        /// <summary>
        /// 修改指定用户的登录密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        [OperationContract]
        bool UpdatePassword(Session us, string pw);

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="code">验证码</param>
        /// <param name="id">身份证号</param>
        /// <returns>用户会话</returns>
        [OperationContract]
        Session ResetPassword(Session obj, string code, string id);

        /// <summary>
        /// 重置支付密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="code">验证码</param>
        /// <param name="id">身份证号</param>
        /// <param name="pw">新支付密码</param>
        /// <returns>bool 是否重置成功</returns>
        [OperationContract]
        bool ResetPayPassword(Session us, string code, string id, string pw);

        /// <summary>
        /// 设置用户头像
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="pic">头像图片</param>
        /// <returns>bool 是否设置成功</returns>
        [OperationContract]
        string SetPortrait(Session us, byte[] pic);

        #endregion

        #region 地址数据

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据列表</returns>
        [OperationContract]
        List<States> GetStates();

        /// <summary>
        /// 根据省ID获取地市数据
        /// </summary>
        /// <param name="stateId">省ID</param>
        /// <returns>地市数据列表</returns>
        [OperationContract]
        List<Citys> GetCitys(Guid stateId);

        /// <summary>
        /// 根据地市ID获取县市数据
        /// </summary>
        /// <param name="cityId">地市ID</param>
        /// <returns>县市数据列表</returns>
        [OperationContract]
        List<Countys> GetCountys(Guid cityId);

        /// <summary>
        /// 获取会员收货地址列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>收货地址列表</returns>
        [OperationContract]
        List<MDE_Member_Address> GetAddresses(Session us);

        /// <summary>
        /// 获取会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">对象ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        MDE_Member_Address GetAddress(Session us, Guid id);

        /// <summary>
        /// 设置默认收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">对象ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SetDefaultAddress(Session us, Guid id);

        /// <summary>
        /// 新增会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddDeliveryAddress(Session us, MDE_Member_Address obj);

        /// <summary>
        /// 编辑会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">收货地址对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool EditDeliveryAddress(Session us, MDE_Member_Address obj);

        /// <summary>
        /// 删除会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">对象ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DelDeliveryAddress(Session us, Guid id);

        #endregion

        #region 授信

        /// <summary>
        /// 获取学历数据
        /// </summary>
        /// <returns>学历数据</returns>
        [OperationContract]
        List<MasterData> GetEducate();

        /// <summary>
        /// 获取行业数据
        /// </summary>
        /// <returns>行业数据</returns>
        [OperationContract]
        List<MasterData> GetIndustry();

        /// <summary>
        /// 提交认证图片
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">认证图片类型</param>
        /// <param name="img">认证图片对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitImage(Session us, string type, byte[] img);

        /// <summary>
        /// 更新会员类型
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SetMemberType(Session us);

        /// <summary>
        /// 获取认证状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>认证状态集合</returns>
        [OperationContract]
        List<string> GetCreditStatus(Session us);

        /// <summary>
        /// 获取会员基本信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>t_member_info 会员基本信息对象</returns>
        [OperationContract]
        t_member_info GetMemberInfo(Session us);

        /// <summary>
        /// 提交基本信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">基本信息对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitMemberInfo(Session us, t_member_info info);

        /// <summary>
        /// 获取会员工作单位信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>t_job_info 工作单位信息对象</returns>
        [OperationContract]
        t_job_info GetJobInfo(Session us);

        /// <summary>
        /// 提交工作单位信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">工作单位信息对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitJobInfo(Session us, t_job_info info);

        /// <summary>
        /// 获取会员学生信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>t_student_info 学生信息对象</returns>
        [OperationContract]
        t_student_info GetStudentInfo(Session us);

        /// <summary>
        /// 提交学生信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">学生信息对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitStudentInfo(Session us, t_student_info info);

        /// <summary>
        /// 获取联系人信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>联系人对象集合</returns>
        [OperationContract]
        List<t_contact_info> GetContactInfos(Session us);

        /// <summary>
        /// 提交多个联系人信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="infos">联系人对象集合</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitContactInfos(Session us, List<t_contact_info> infos);

        /// <summary>
        /// 完成基本认证信息提交
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitBaseInfo(Session us);

        /// <summary>
        /// 获取银行卡信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">卡类型</param>
        /// <returns>联系人对象集合</returns>
        [OperationContract]
        t_bank_card_info GetBankCardInfo(Session us, string type);

        /// <summary>
        /// 提交银行卡信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">银行卡对象</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SubmitBankCardInfo(Session us, t_bank_card_info info);

        /// <summary>
        /// 提交驾照信息
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        [OperationContract]
        bool SubmitDrvInfo(Session us);

        #endregion

        #region 其它

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="secCode">安全码</param>
        /// <param name="number">手机号</param>
        /// <param name="type">验证码类型</param>
        /// <returns>string 验证码</returns>
        [OperationContract]
        string GetVerifyCode(string secCode, string number, int type);

        /// <summary>
        /// 获取当前有效分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>分期方案列表</returns>
        [OperationContract]
        List<BIZ_StagePlan> GetStagePlans(Session us);

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="paypw">支付密码</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool ValidityPayPW(Session us, string paypw);

        /// <summary>
        /// 保存支付记录
        /// </summary>
        /// <param name="secCode">安全码</param>
        /// <param name="obj">支付记录对象</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool SavePayRecord(string secCode, BIZ_Pay_Record obj);

        /// <summary>
        /// 根据商户订单号获取支付记录
        /// </summary>
        /// <param name="secCode">安全码</param>
        /// <param name="tradeNo">商户订单号</param>
        /// <returns>BIZ_Pay_Record 支付记录对象</returns>
        [OperationContract]
        BIZ_Pay_Record GetPayRecord(string secCode, string tradeNo);

        #endregion

    }

}
