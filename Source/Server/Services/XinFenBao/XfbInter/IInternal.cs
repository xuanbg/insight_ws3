using System.ServiceModel;

namespace Insight.WS.Service.XinFenBao
{

    [ServiceContract]
    public interface IInternal
    {
        /// <summary>
        /// 信分宝会员注册
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="pw">密码Hash值</param>
        /// <param name="name">用户姓名</param>
        /// <param name="id">身份证号</param>
        /// <returns>boll 是否成功</returns>
        [OperationContract]
        bool Register(string code, string ln, string pw, string name, string id);

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="type">会员类型</param>
        /// <returns>boll 是否成功</returns>
        [OperationContract]
        bool SetMemberType(string code, string ln, int type);

        /// <summary>
        /// 设置用户登录密码
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>boll 是否成功</returns>
        [OperationContract]
        bool SetPassword(string code, string ln, string pw);

        /// <summary>
        /// 根据ID封禁/解封用户
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="validity">true:解封；false:封禁</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SetUserStatus(string code, string ln, bool validity);

        /// <summary>
        /// 插入绑定银行卡
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="name">持卡人姓名</param>
        /// <param name="type">卡类型</param>
        /// <param name="bank">发卡银行</param>
        /// <param name="number">卡号</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddBankCard(string code, string ln, string name, string type, string bank, string number);

        /// <summary>
        /// 设置账单状态
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="id">账单ID</param>
        /// <param name="status">账单状态</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SetBillStatus(string code, string id, int status);

    }
}
