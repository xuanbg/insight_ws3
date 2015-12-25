using System.ServiceModel;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service.SuperDentist
{

    [ServiceContract]
    public interface IInterface
    {

        #region user

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "user", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult Register(string smsCode, string password);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/signin", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult Login(Session session);

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="id">SessionID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/signout", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult Logout(int id);

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="password">新登录密码MD5值</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/change", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult ChangePassword(string password);

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/reset", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult ResetPassword(string smsCode, string password);

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "user/getmemberinfo?id={id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetMemberInfo(string id);

        #endregion

        #region setting

        /// <summary>
        /// 获取七牛云文件上传Token
        /// </summary>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "setting/getqiniutoken", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetQiniuUploadToken();

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="id">图形验证码ID</param>
        /// <param name="type">短信验证码类型</param>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "setting/getverifycode?id={id}&type={type}&mobile={mobile}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetSmsVerifyCode(string id, int type, string mobile);

        #endregion

    }
}
