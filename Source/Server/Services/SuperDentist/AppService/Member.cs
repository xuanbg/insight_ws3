using System;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;
using static Insight.WS.Server.Common.Util;
using static Insight.WS.Service.SuperDentist.DataAccess;

namespace Insight.WS.Service.SuperDentist
{
    public partial class AppService
    {

        #region Member 3

        /// <summary>
        /// 获取会员列表
        /// </summary>
        /// <param name="name">昵称</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMembers(string name)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var members = context.MemberInfo.Where(m => m.Name.Contains(name)).OrderByDescending(m => m.Integral).ToList();
                return result.Success(Serialize(members));
            }
        }

        /// <summary>
        /// 编辑会员信息
        /// </summary>
        /// <param name="member">会员信息数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult SetMemberInfo(MDG_Member member)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.MDG_Member.SingleOrDefault(m => m.MID == member.MID);
                if (data == null) return result.NotFound();

                data.Portrait = member.Portrait;
                data.Signature = member.Signature;
                data.Country = member.Country;
                data.State = member.State;
                data.City = member.City;
                data.County = member.County;
                data.Street = member.Street;
                data.ZipCode = member.ZipCode;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMemberInfo(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid uid;
            if (!Guid.TryParse(id, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var member = context.MemberInfo.SingleOrDefault(m => m.ID == uid);
                return GetJson(member);
            }
        }

        #endregion

        #region Favorite

        /// <summary>
        /// 获取收藏列表
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <param name="type">收藏类型</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetFavorites(string id, int type)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid uid;
            if (!Guid.TryParse(id, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var favorites = context.MDE_Favorites.Where(f => f.CreatorUserId == uid && f.Type == type).ToList();
                return result.Success(Serialize(favorites));
            }
        }

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="favorites">收藏数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult Favorite(MDE_Favorites favorites)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(favorites);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id">收藏记录ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveFavorite(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid fid;
            if (!Guid.TryParse(id, out fid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var favorite = context.MDE_Favorites.SingleOrDefault(f => f.ID == fid);
                if (favorite == null) return result.NotFound();

                context.MDE_Favorites.Remove(favorite);
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        #endregion

        #region Message

        /// <summary>
        /// 获取私信列表
        /// </summary>
        /// <param name="id">通信对象ID</param>
        /// <param name="mid">会员ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMessages(string id, string mid)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid rid;
            if (!Guid.TryParse(id, out rid)) return result.InvalidGuid();

            Guid uid;
            if (!Guid.TryParse(mid, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var messages = context.MDE_Message.Where(m => m.CreatorUserId == uid && m.ReceiveUserId == rid).OrderByDescending(m => m.SendTime).ToList();
                foreach (var message in messages)
                {
                    message.HaveRead = true;
                }

                return context.SaveChanges() > 0 ? result.Success(Serialize(messages)) : result.DataBaseError();
            }
        }

        /// <summary>
        /// 写私信
        /// </summary>
        /// <param name="message">私信数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddMessage(MDE_Message message)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(message);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除私信
        /// </summary>
        /// <param name="id">私信ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveMessage(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid mid;
            if (!Guid.TryParse(id, out mid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var message = context.MDE_Message.SingleOrDefault(f => f.ID == mid);
                if (message == null) return result.NotFound();

                context.MDE_Message.Remove(message);
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="id">私信ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult SendMessage(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid mid;
            if (!Guid.TryParse(id, out mid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var message = context.MDE_Message.SingleOrDefault(t => t.ID == mid);
                if (message == null) return result.NotFound();

                message.SendTime = DateTime.Now;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        #endregion

    }
}
