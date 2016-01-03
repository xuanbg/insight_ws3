using System;
using System.Collections.Generic;
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
                var topics = gp.Guid.HasValue
                    ? context.Topics.Where(m => m.GroupId == gp.Guid).ToList()
                    : context.Topics.Where(m => !m.Private).ToList();
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

            var taglist = tags.Split(Convert.ToChar(","));
            var topics = new List<SDT_Topic>();
            using (var context = new WSEntities())
            {
                foreach (var tag in taglist)
                {
                    var list = context.SDT_Topic.Where(t => t.Tags.Contains(tag));
                    topics.AddRange(list);
                }
                var group = topics.GroupBy(t => t.ID).Select(l => new { ID = l.Key, Count = l.Count() });
                var order = group.OrderByDescending(l => l.Count).Select(id => id.ID).Take(20);
                var simtopics = context.Topics.Join(order, t => t.TopicId, o => o, (t, o) => t).ToList();
                return result.Success(Serialize(simtopics));
            }
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

            var topics = new List<SDT_Topic>();
            using (var context = new WSEntities())
            {
                var cate = context.BASE_Category.Single(c => c.Alias == "Tags");
                var tags = context.MasterData.Where(m => m.CategoryId == cate.ID).Select(m => m.Name);
                foreach (var tag in tags)
                {
                    if (!title.Contains(tag)) continue;

                    var list = context.SDT_Topic.Where(t => t.Tags.Contains(tag));
                    topics.AddRange(list);
                }
                var group = topics.GroupBy(t => t.ID).Select(l => new { ID = l.Key, Count = l.Count() });
                var order = group.OrderByDescending(l => l.Count).Select(id => id.ID).Take(20);
                var simtopics = context.Topics.Join(order, t => t.TopicId, o => o, (t, o) => t).ToList();
                return result.Success(Serialize(simtopics));
            }
        }

        /// <summary>
        /// 搜素话题
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns>JsonResult</returns>
        public JsonResult SearchTopics(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddTopic(SDT_Topic topic)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(topic);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除话题
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemovTopic(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topic = context.SDT_Topic.SingleOrDefault(t => t.ID == tid);
                if (topic == null) return result.NotFound();

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
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Topic.SingleOrDefault(t => t.ID == topic.ID);
                if (data == null) return result.NotFound();

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
            var result = Verify();
            if (!result.Successful) return result;

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
            var result = Verify();
            if (!result.Successful) return result;

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
            var result = Verify();
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speech = context.SDT_Speech.SingleOrDefault(s => s.ID == sid);
                if (speech == null) return result.NotFound();

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
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Speech.SingleOrDefault(t => t.ID == speech.ID);
                if (data == null) return result.NotFound();

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
            var result = Verify();
            if (!result.Successful) return result;

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
            var result = Verify();
            if (!result.Successful) return result;

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
            var result = Verify();
            if (!result.Successful) return result;

            Guid cid;
            if (!Guid.TryParse(id, out cid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var comment = context.SDT_Comment.SingleOrDefault(s => s.ID == cid);
                if (comment == null) return result.NotFound();

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
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Comment.SingleOrDefault(s => s.ID == comment.ID);
                if (data == null) return result.NotFound();

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
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(praise);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 获取话题可用标签
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetTopicTags()
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var cate = context.BASE_Category.Single(c => c.Alias == "Tags");
                var data = context.MasterData.Where(m => m.CategoryId == cate.ID).ToList();
                return result.Success(Serialize(data));
            }
        }

        #endregion

    }
}
