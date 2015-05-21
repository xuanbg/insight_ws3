using System;

namespace Insight.WS.Server.Common
{
    public class Session
    {

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 会话ID
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 登录部门ID
        /// </summary>
        public Guid? DeptId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录部门全称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// WCF服务基地址
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// 用户签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 用户机器码
        /// </summary>
        public string MachineId { get; set; }

        /// <summary>
        /// 上次连接时间
        /// </summary>
        public DateTime LastConnect { get; set; }

        /// <summary>
        /// 用户登录状态
        /// </summary>
        public LoginResult LoginStatus { get; set; }

    }

    public enum LoginResult
    {
        Success,
        Multiple,
        Failure,
        Online,
        Banned,
        NotExist,
        Unauthorized
    }
}
