using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.XinFenBao
{
    public class XfbInterface:IXfbInterface
    {

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据集合</returns>
        public List<States> GetStates()
        {
            using (var context = new WSEntities())
            {
                return context.States.ToList();
            }
        }

        /// <summary>
        /// 根据省ID获取地市数据
        /// </summary>
        /// <param name="stateId">省ID</param>
        /// <returns>地市数据集合</returns>
        public List<Citys> GetCitys(Guid stateId)
        {
            using (var context = new WSEntities())
            {
                return context.Citys.Where(c => c.ParentId == stateId).ToList();
            }
        }

        /// <summary>
        /// 根据地市ID获取县市数据
        /// </summary>
        /// <param name="cityId">地市ID</param>
        /// <returns>县市数据集合</returns>
        public List<Countys> GetCountys(Guid cityId)
        {
            using (var context = new WSEntities())
            {
                return context.Countys.Where(c => c.CategoryId == cityId).ToList();
            }
        }

        /// <summary>
        /// 获取用户Session对象实体
        /// </summary>
        /// <param name="ln">登录账号</param>
        /// <param name="pw">登录密码</param>
        /// <returns>Session 用户Session对象实体</returns>
        public Session GetSession(string ln, string pw)
        {
            return OnlineManage.Sessions.Find(s => s.LoginName == ln && s.Signature == pw);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public Session UserLogin(Session obj)
        {
            return CommonDAL.UserLogin(obj);
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <param name="code">验证码</param>
        /// <returns>Session对象实体</returns>
        public Session Register(Session obj, string code)
        {
            if (obj == null) return null;

            if (!CommonDAL.CodeVerify(obj.LoginName, code, 180))
            {
                obj.LoginStatus = LoginResult.Failure;
                return obj;
            }

            // 插入主数据索引
            var md = new MasterData {Name = obj.LoginName, Alias = obj.LoginName};
            var cmds = new List<SqlCommand> {MasterDataDAL.AddMasterData(md)};

            // 插入会员主数据
            var sql = "insert MDG_Member (MID) select @MID";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            // 插入外部用户
            sql = "insert SYS_User (ID, Name, LoginName, Password, Type, CreatorUserId) select @ID, @Name, @LoginName, @Password, @Type, @CreatorUserId";
            parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Name", obj.LoginName),
                new SqlParameter("@LoginName", obj.LoginName),
                new SqlParameter("@Password", obj.Signature),
                new SqlParameter("@Type", -1),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            return SqlHelper.SqlExecute(cmds) ? CommonDAL.UserLogin(obj) : null;
        }

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">会员姓名</param>
        /// <param name="member">会员对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateMember(Session us, string name, MDG_Member member)
        {
            if (!OnlineManage.Verification(us)) return false;

            // 更新会员姓名
            var sql = string.Format("update MasterData set Name = '{0}' where ID = '{1}'", name, member.MID);
            var cmds = new List<SqlCommand> {SqlHelper.MakeCommand(sql)};

            // 更新会员信息
            sql = "update MDG_Member set IdCardNo = @IdCardNo, StateId = @StateId, CityId = @CityId, CountyId = @CountyId, Street = @Street, ZipCode = @ZipCode, Description = @Description where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@IdCardNo", member.IdCardNo),
                new SqlParameter("@StateId", SqlDbType.UniqueIdentifier) {Value = member.StateId},
                new SqlParameter("@CityId", SqlDbType.UniqueIdentifier) {Value = member.CityId},
                new SqlParameter("@CountyId", SqlDbType.UniqueIdentifier) {Value = member.CountyId},
                new SqlParameter("@Street", member.Street),
                new SqlParameter("@ZipCode", member.ZipCode),
                new SqlParameter("@Description", member.Description),
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = member.MID}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            // 更新用户名
            sql = string.Format("update SYS_User set Name = '{0}' where ID = '{1}'", name, member.MID);
            cmds.Add(SqlHelper.MakeCommand(sql));

            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 修改指定用户的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        public bool UpdataPassword(Session us, string pw)
        {
            return CommonDAL.UpdataPassword(us, pw);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <param name="code">验证码</param>
        /// <returns>Session对象实体</returns>
        public Session ResetPassword(Session obj, string code)
        {
            if (obj == null) return null;

            if (!CommonDAL.CodeVerify(obj.LoginName, code, 180))
            {
                obj.LoginStatus = LoginResult.Failure;
                return obj;
            }

            var sql = string.Format("update SYS_User set Password = '{0}' where LoginName = '{1}'", obj.Signature, obj.LoginName);
            return SqlHelper.SqlNonQuery(sql) > 0 ? CommonDAL.UserLogin(obj) : null;
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="type">验证码类型</param>
        /// <returns>string 验证码</returns>
        public string GetVerifyCode(string number, int type)
        {
            return CommonDAL.GetVerifyCode(number, type);
        }

    }
}
