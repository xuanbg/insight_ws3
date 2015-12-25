﻿using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Insight.WS.Verify
{
    [ServiceContract]
    interface Interface
    {

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="type">验证类型</param>
        /// <param name="mobile">手机号</param>
        /// <param name="time">过期时间（分钟）</param>
        /// <returns>string 验证码</returns>
        [OperationContract]
        string GetCode(int type, string mobile, int time = 30);

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="remove">是否验证成功后删除记录</param>
        /// <returns>bool 是否正确</returns>
        [OperationContract]
        bool VerifyCode(string mobile, string code, int type, bool remove = true);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session</returns>
        [OperationContract]
        Session UserLogin(Session obj);

        /// <summary>
        /// 获取当前在线状态的全部内部用户的Session
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>全部内部用户的Session</returns>
        [OperationContract]
        List<Session> GetSessions(Session obj);

        /// <summary>
        /// 更新指定用户Session的签名
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="signature"></param>
        [OperationContract]
        void UpdateSignature(Session obj, string signature);

        /// <summary>
        /// 重置指定用户Session的登录状态
        /// </summary>
        /// <param name="obj">用户会话</param>
        [OperationContract]
        void SetOnlineStatus(Session obj);

        /// <summary>
        /// 根据用户ID设置用户状态
        /// </summary>
        /// <param name="obj">操作员的Session</param>
        /// <param name="uid">用户ID</param>
        /// <param name="validity">可用状态</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SetUserStatus(Session obj, Guid uid, bool validity);

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        Session Verification(Session obj);

        /// <summary>
        /// 简单会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SimpleVerifty(Session obj);

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool Authorization(Session obj, string action);

    }
}
