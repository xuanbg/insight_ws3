using System.Data;
using System.Data.SqlClient;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service.SuperDentist
{
    public class DataAccess
    {

        /// <summary>
        /// 生成插入会员信息的SqlCommand
        /// </summary>
        /// <param name="obj">MDG_Member</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(MDG_Member obj)
        {
            var sql = "insert MDG_Member (MID, Portrait, Signature, Integral, Beans, Country, State, City, County, Street, ZipCode) ";
            sql += "select @MID, @Portrait, @Signature, @Integral, @Beans, @Country, @State, @City, @County, @Street, @ZipCode;";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = obj.MID},
                new SqlParameter("@Portrait", obj.Portrait),
                new SqlParameter("@Signature", obj.Signature),
                new SqlParameter("@Integral", obj.Integral),
                new SqlParameter("@Beans", obj.Beans),
                new SqlParameter("@Country", obj.Country),
                new SqlParameter("@State", obj.State),
                new SqlParameter("@City", obj.City),
                new SqlParameter("@County", obj.County),
                new SqlParameter("@Street", obj.Street),
                new SqlParameter("@ZipCode", obj.ZipCode),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入收藏记录的SqlCommand
        /// </summary>
        /// <param name="obj">MDE_Favorites</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(MDE_Favorites obj)
        {
            var sql = "insert MDE_Favorites (Type, ObjectId, CreatorUserId) ";
            sql += "select @Type, @ObjectId, @CreatorUserId;";
            sql += "select ID From MDE_Favorites where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@Type", obj.Type),
                new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = obj.ObjectId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入收藏记录的SqlCommand
        /// </summary>
        /// <param name="obj">MDE_Favorites</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(MDE_Message obj)
        {
            var sql = "insert MDE_Message (ReceiveUserId, Content, SendTime, CreatorUserId) ";
            sql += "select @ReceiveUserId, @Content, @SendTime, @CreatorUserId;";
            sql += "select ID From MDE_Message where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@ReceiveUserId", SqlDbType.UniqueIdentifier) {Value = obj.ReceiveUserId},
                new SqlParameter("@Content", obj.Content),
                new SqlParameter("@SendTime", obj.SendTime),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入话题记录的SqlCommand
        /// </summary>
        /// <param name="obj">SDT_Topic</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(SDT_Topic obj)
        {
            var sql = "insert SDT_Topic (Title, Description, Tags, CaseId, Private, PublishTime, CreatorUserId) ";
            sql += "select @Title, @Description, @Tags, @CaseId, @Private, @PublishTime, @CreatorUserId;";
            sql += "select ID From SDT_Topic where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@Title", obj.Title),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Tags", obj.Tags),
                new SqlParameter("@CaseId", SqlDbType.UniqueIdentifier) {Value = obj.CaseId},
                new SqlParameter("@Private", obj.Private),
                new SqlParameter("@PublishTime", obj.PublishTime),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入话题转载记录的SqlCommand
        /// </summary>
        /// <param name="obj">SDT_Forward</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(SDT_Forward obj)
        {
            var sql = "insert SDT_Forward (TopicId, GroupId, CreatorUserId) ";
            sql += "select @TopicId, @GroupId, @CreatorUserId;";
            var parm = new[]
            {
                new SqlParameter("@TopicId", SqlDbType.UniqueIdentifier) {Value = obj.TopicId},
                new SqlParameter("@GroupId", SqlDbType.UniqueIdentifier) {Value = obj.GroupId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入发言记录的SqlCommand
        /// </summary>
        /// <param name="obj">SDT_Speech</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(SDT_Speech obj)
        {
            var sql = "insert SDT_Speech (TopicId, Content, CaseId, Recommend, PublishTime, CreatorUserId) ";
            sql += "select @TopicId, @Content, @CaseId, @Recommend, @PublishTime, @CreatorUserId;";
            sql += "select ID From SDT_Speech where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@TopicId", SqlDbType.UniqueIdentifier) {Value = obj.TopicId},
                new SqlParameter("@Content", obj.Content),
                new SqlParameter("@CaseId", SqlDbType.UniqueIdentifier) {Value = obj.CaseId},
                new SqlParameter("@Recommend", obj.Recommend),
                new SqlParameter("@PublishTime", obj.PublishTime),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入发言态度记录的SqlCommand
        /// </summary>
        /// <param name="obj">SDT_Attitude</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(SDT_Attitude obj)
        {
            var sql = "insert SDT_Attitude (SpeechId, Type, Description, CreatorUserId) ";
            sql += "select @SpeechId, @Type, @Description, @CreatorUserId;";
            sql += "select ID From SDT_Attitude where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@SpeechId", SqlDbType.UniqueIdentifier) {Value = obj.SpeechId},
                new SqlParameter("@Type", obj.Type),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入评论记录的SqlCommand
        /// </summary>
        /// <param name="obj">SDT_Comment</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(SDT_Comment obj)
        {
            var sql = "insert SDT_Comment (SpeechId, Content, PublishTime, CreatorUserId) ";
            sql += "select @SpeechId, @Content, @PublishTime, @CreatorUserId;";
            sql += "select ID From SDT_Comment where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@SpeechId", SqlDbType.UniqueIdentifier) {Value = obj.SpeechId},
                new SqlParameter("@Content", obj.Content),
                new SqlParameter("@PublishTime", obj.PublishTime),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 生成插入评论态度记录的SqlCommand
        /// </summary>
        /// <param name="obj">SDT_Praise</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertData(SDT_Praise obj)
        {
            var sql = "insert SDT_Praise (CommentId, Type, Description, CreatorUserId) ";
            sql += "select @CommentId, @Type, @Description, @CreatorUserId;";
            sql += "select ID From SDT_Praise where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@CommentId", SqlDbType.UniqueIdentifier) {Value = obj.CommentId},
                new SqlParameter("@Type", obj.Type),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
            };
            return MakeCommand(sql, parm);
        }

    }
}
