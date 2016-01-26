using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;
using static Insight.WS.Server.Common.Util;
using static Insight.WS.Service.SuperDentist.DataAccess;

namespace Insight.WS.Service.SuperDentist
{
    public partial class AppService
    {

        #region Topic

        /// <summary>
        /// 获取话题列表
        /// </summary>
        /// <param name="gid"></param>
        /// <returns>JsonResult</returns>
        public JsonResult GetTopics(string gid)
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            var gp = new GuidParse(gid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topics = context.GetTopics(gp.Guid, false).ToList();
                return result.Success(Serialize(topics.OrderByDescending(t => t.PublishTime)));
            }
        }

        /// <summary>
        /// 获取相关话题列表
        /// </summary>
        /// <param name="tags">话题标签</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetRelateTopics(string tags)
        {
            var result = Verify(tags + Secret);
            if (!result.Successful) return result;

            var taglist = tags.Split(Convert.ToChar(",")).ToList();
            var rel = Common.SearchTopic(taglist);
            return result.Success(Serialize(rel));
        }

        /// <summary>
        /// 获取相似话题列表
        /// </summary>
        /// <param name="title">话题标题</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSimilarTopics(string title)
        {
            var result = Verify(title + Secret);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var cate = context.BASE_Category.Single(c => c.Alias == "Tags");
                var tags = context.MasterData.Where(m => m.CategoryId == cate.ID && title.Contains(m.Name)).Select(m => m.Name).ToList();
                var sim = Common.SearchTopic(tags);
                return result.Success(Serialize(sim));
            }
        }

        /// <summary>
        /// 搜索话题
        /// </summary>
        /// <param name="keys">关键词</param>
        /// <param name="gid">群组ID（可为空）</param>
        /// <returns>JsonResult</returns>
        public JsonResult SearchTopics(string keys, string gid)
        {
            var result = Verify(keys + Secret);
            if (!result.Successful) return result;

            var gp = new GuidParse(gid);
            if (!gp.Successful) return result.InvalidGuid();

            var tags = keys.Split(Convert.ToChar(",")).ToList();
            var rel = Common.SearchTopic(tags, gp.Guid);
            var sim = Common.SearchTopic(tags, gp.Guid, "title", 10);
            return result.Success(Serialize(rel.Union(sim).OrderByDescending(t => t.Agrees)));
        }

        /// <summary>
        /// 新增话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <param name="gid">群组ID（可为空）</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddTopic(SDT_Topic topic, string gid)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            var gp = new GuidParse(gid);
            if (!gp.Successful) return result.InvalidGuid();

            object id;
            topic.CreatorUserId = us.UserId;
            if (gp.Guid.HasValue)
            {
                var forward = new SDT_Forward
                {
                    GroupId = (Guid) gp.Guid,
                    CreatorUserId = topic.CreatorUserId
                };
                var cmds = new List<SqlCommand> {InsertData(topic), InsertData(forward)};
                id = SqlExecute(cmds, 0);
            }
            else
            {
                var cmd = InsertData(topic);
                id = SqlScalar(cmd);
            }
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除话题
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemovTopic(string id)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topic = context.SDT_Topic.SingleOrDefault(t => t.ID == tid);
                if (topic == null) return result.NotFound();

                if (us.UserId != topic.CreatorUserId) result.Forbidden();

                topic.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditTopic(SDT_Topic topic)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Topic.SingleOrDefault(t => t.ID == topic.ID);
                if (data == null) return result.NotFound();

                if (us.UserId != data.CreatorUserId) result.Forbidden();

                data.Title = topic.Title;
                data.Description = topic.Description;
                data.Tags = topic.Tags;
                data.CaseId = topic.CaseId;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取话题详情
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetTopic(string id, string mid)
        {
            var result = Verify(id + Secret);
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topic = context.GetTopic(tid, gp.Guid).FirstOrDefault();
                return GetJson(topic);
            }
        }

        /// <summary>
        /// 转载话题
        /// </summary>
        /// <param name="forward">话题转载数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult ForwardTopic(SDT_Forward forward)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            forward.CreatorUserId = us.UserId;
            var cmd = InsertData(forward);
            return SqlNonQuery(cmd) > 0 ? result : result.DataBaseError();
        }

        #endregion

        #region Speech

        /// <summary>
        /// 获取发言列表
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSpeechs(string id)
        {
            var result = Verify(id + Secret);
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speechs = context.Speechs.Where(s => s.TopicId == tid).OrderByDescending(s => s.Agrees).ToList();
                return result.Success(Serialize(speechs));
            }
        }

        /// <summary>
        /// 新增发言
        /// </summary>
        /// <param name="speech">发言数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddSpeech(SDT_Speech speech)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            speech.CreatorUserId = us.UserId;
            var cmd = InsertData(speech);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除发言
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveSpeech(string id)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speech = context.SDT_Speech.SingleOrDefault(s => s.ID == sid);
                if (speech == null) return result.NotFound();

                if (us.UserId != speech.CreatorUserId) result.Forbidden();

                speech.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑发言
        /// </summary>
        /// <param name="speech">发言数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditSpeech(SDT_Speech speech)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Speech.SingleOrDefault(t => t.ID == speech.ID);
                if (data == null) return result.NotFound();

                if (us.UserId != data.CreatorUserId) result.Forbidden();

                data.Content = speech.Content;
                data.CaseId = speech.CaseId;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取发言详情
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSpeech(string id, string mid)
        {
            var result = Verify(id + Secret);
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speech = context.GetSpeech(sid, gp.Guid).FirstOrDefault();
                return GetJson(speech);
            }
        }

        /// <summary>
        /// 新增发言态度
        /// </summary>
        /// <param name="attitude">发言态度数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddAttitude(SDT_Attitude attitude)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            attitude.CreatorUserId = us.UserId;
            if (attitude.Type < 3)
            {
                var t = 3 - attitude.Type;
                using (var context = new WSEntities())
                {
                    var att = context.SDT_Attitude.SingleOrDefault(a => a.Type == t && a.CreatorUserId == attitude.CreatorUserId);
                    if (att != null)
                    {
                        att.Type = attitude.Type;
                        return context.SaveChanges() > 0 ? result : result.DataBaseError();
                    }
                }
            }

            var cmd = InsertData(attitude);
            return SqlNonQuery(cmd) > 0 ? result : result.DataBaseError();
        }

        #endregion

        #region Comment

        /// <summary>
        /// 获取发言评论列表
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetComments(string id, string mid)
        {
            var result = Verify(id + Secret);
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var comments = context.GetComments(sid, gp.Guid).OrderBy(c => c.PublishTime).ToList();
                return result.Success(Serialize(comments));
            }
        }

        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="comment">评论数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddComment(SDT_Comment comment)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            comment.CreatorUserId = us.UserId;
            var cmd = InsertData(comment);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveComment(string id)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid cid;
            if (!Guid.TryParse(id, out cid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var comment = context.SDT_Comment.SingleOrDefault(s => s.ID == cid);
                if (comment == null) return result.NotFound();

                if (us.UserId != comment.CreatorUserId) result.Forbidden();

                comment.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑评论
        /// </summary>
        /// <param name="comment">评论数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditComment(SDT_Comment comment)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Comment.SingleOrDefault(s => s.ID == comment.ID);
                if (data == null) return result.NotFound();

                if (us.UserId != data.CreatorUserId) result.Forbidden();

                data.Content = comment.Content;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 新增评论态度
        /// </summary>
        /// <param name="praise">评论数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddPraise(SDT_Praise praise)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            praise.CreatorUserId = us.UserId;
            var cmd = InsertData(praise);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        #endregion

    }
}
