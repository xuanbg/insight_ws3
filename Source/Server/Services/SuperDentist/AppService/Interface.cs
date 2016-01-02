using System.ServiceModel;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service.SuperDentist
{

    [ServiceContract]
    public interface Interface
    {

        #region User 8

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
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/signout", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult Logout();

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
        /// 获取会员列表
        /// </summary>
        /// <param name="name">昵称</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "user/members?name={name}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetMembers(string name);

        /// <summary>
        /// 编辑会员信息
        /// </summary>
        /// <param name="member">会员信息数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/member", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult SetMemberInfo(MDG_Member member);

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "user/member?id={id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetMemberInfo(string id);

        #endregion

        #region Favorite 3

        /// <summary>
        /// 获取收藏列表
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <param name="type">收藏类型</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "user/favorites?id={id}&type={type}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetFavorites(string id, int type);

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="favorites">收藏数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "user/favorite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult Favorite(MDE_Favorites favorites);

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id">收藏记录ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "user/favorite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemoveFavorite(string id);

        #endregion

        #region Message 4

        /// <summary>
        /// 获取私信列表
        /// </summary>
        /// <param name="id">通信对象ID</param>
        /// <param name="mid">会员ID</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "user/messages?id={id}&mid={mid}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetMessages(string id, string mid);

        /// <summary>
        /// 写私信
        /// </summary>
        /// <param name="message">私信数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "user/message", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddMessage(MDE_Message message);

        /// <summary>
        /// 删除私信
        /// </summary>
        /// <param name="id">私信ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "user/message", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemoveMessage(string id);

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="id">私信ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/message", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult SendMessage(string id);

        #endregion

        #region Topic 8

        /// <summary>
        /// 获取话题列表
        /// </summary>
        /// <param name="gid">群组ID（可选）</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "topics?gid={gid}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetTopics(string gid);

        /// <summary>
        /// 获取相关话题列表
        /// </summary>
        /// <param name="tags">话题标签</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "reltopics?tags={tags}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetRelateTopics(string tags);

        /// <summary>
        /// 获取相似话题列表
        /// </summary>
        /// <param name="title">话题标题</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "simtopics?title={title}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetSimilarTopics(string title);

        /// <summary>
        /// 新增话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "topic", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddTopic(SDT_Topic topic);

        /// <summary>
        /// 删除话题
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "topic", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemovTopic(string id);

        /// <summary>
        /// 编辑话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "topic", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult EditTopic(SDT_Topic topic);

        /// <summary>
        /// 获取话题详情
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "topic?id={id}&mid={mid}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetTopic(string id, string mid);

        /// <summary>
        /// 转载话题
        /// </summary>
        /// <param name="forward">话题转载数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "topic/forward", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult ForwardTopic(SDT_Forward forward);

        #endregion

        #region Speech 6

        /// <summary>
        /// 获取发言列表
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "topic/speechs?id={id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetSpeechs(string id);

        /// <summary>
        /// 新增发言
        /// </summary>
        /// <param name="speech">发言数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "topic/speech", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddSpeech(SDT_Speech speech);

        /// <summary>
        /// 删除发言
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "topic/speech", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemoveSpeech(string id);

        /// <summary>
        /// 编辑发言
        /// </summary>
        /// <param name="speech">发言数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "topic/speech", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult EditSpeech(SDT_Speech speech);

        /// <summary>
        /// 获取发言详情
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "topic/speech?id={id}&mid={mid}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetSpeech(string id, string mid);

        /// <summary>
        /// 新增发言态度
        /// </summary>
        /// <param name="attitude">发言态度数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "topic/speech/attitude", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddAttitude(SDT_Attitude attitude);

        #endregion

        #region Comment 5

        /// <summary>
        /// 获取发言评论列表
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "topic/speech/comments?id={id}&mid={mid}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetComments(string id, string mid);

        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="comment">评论数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "topic/speech/comment", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddComment(SDT_Comment comment);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "topic/speech/comment", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemoveComment(string id);

        /// <summary>
        /// 编辑评论
        /// </summary>
        /// <param name="comment">评论数据对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "topic/speech/comment", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult EditComment(SDT_Comment comment);

        /// <summary>
        /// 新增评论态度
        /// </summary>
        /// <param name="praise">评论数据态度对象</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "topic/speech/comment/praise", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddPraise(SDT_Praise praise);

        #endregion

        #region Setting 3

        /// <summary>
        /// 获取话题可用标签
        /// </summary>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "setting/tags", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetTopicTags();

        /// <summary>
        /// 获取七牛云文件上传Token
        /// </summary>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "setting/qiniutoken", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetQiniuUploadToken();

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="id">图形验证码ID</param>
        /// <param name="type">短信验证码类型</param>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "setting/verifycode?id={id}&type={type}&mobile={mobile}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetSmsVerifyCode(string id, int type, string mobile);

        #endregion

    }
}
