using System;
using System.Collections.Generic;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Service.SuperDentist
{
    public class Common
    {
        /// <summary>
        /// 根据关键词搜索相关话题
        /// </summary>
        /// <param name="keys">关键词集合</param>
        /// <param name="gid">群组ID（可为空）</param>
        /// <param name="type">匹配类型：tag（标签）；title（标题）</param>
        /// <param name="number">返回记录数量</param>
        /// <returns>与关键词相关的Topics集合</returns>
        public static List<Topics> SearchTopic(List<string> keys, Guid? gid = null, string type = "tag", int number = 20)
        {
            var topics = new List<SDT_Topic>();
            using (var context = new WSEntities())
            {
                foreach (var key in keys)
                {
                    var list = type == "tag"
                        ? context.SDT_Topic.Where(t => t.Tags.Contains(key))
                        : context.SDT_Topic.Where(t => t.Title.Contains(key));
                    topics.AddRange(list);
                }
                var group = topics.GroupBy(t => t.ID).Select(l => new { ID = l.Key, Count = l.Count() });
                var order = group.OrderByDescending(l => l.Count).Select(id => id.ID).Take(number);
                return order.Join(context.GetTopics(gid, true), o => o, t => t.ID, (o, t) => t).ToList();
            }
        }

        /// <summary>
        /// 根据关键词搜索相关群组
        /// </summary>
        /// <param name="keys">关键词集合</param>
        /// <param name="uid">会员ID（可为空）</param>
        /// <param name="number">返回记录数量</param>
        /// <returns>与关键词相关的Topics集合</returns>
        public static List<Group> SearchGroup(List<string> keys, Guid? uid, int number = 10)
        {
            var topics = new List<SDG_Group>();
            using (var context = new WSEntities())
            {
                foreach (var key in keys)
                {
                    var namesim = context.SDG_Group.Where(g => g.Name.Contains(key));
                    var descsim = context.SDG_Group.Where(g => g.Description.Contains(key));
                    topics.AddRange(namesim);
                    topics.AddRange(descsim);
                }
                var group = topics.GroupBy(t => t.ID).Select(l => new { ID = l.Key, Count = l.Count() });
                var order = group.OrderByDescending(l => l.Count).Select(id => id.ID).Take(number);
                return context.GetGroups(uid).Join(order, g => g.ID, o => o, (g, o) => g).ToList();
            }
        }

        /// <summary>
        /// 验证短信验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">类型</param>
        /// <param name="remove">是否验证后删除</param>
        /// <returns>JsonResult</returns>
        public static JsonResult VerifyCode(string mobile, string code, int type, bool remove = true)
        {
            var url = VerifyServer + $"smscode/compare?mobile={mobile}&code={code}&type={type}&remove={remove}";
            var auth = Base64(Hash(mobile + Secret));
            return General.HttpRequest(url, "GET", auth);
        }
    }
}
