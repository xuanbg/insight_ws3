using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.Entity;

namespace Insight.WS.Server.Common.Utils
{
    public partial class DataAccess
    {

        /// <summary>
        /// 根据ID获取主数据对象实体
        /// </summary>
        /// <param name="id">主数据ID</param>
        /// <returns>MasterData 主数据对象实体</returns>
        public static MasterData GetData(Guid id)
        {
            using (var context = new Entities())
            {
                return context.MasterData.SingleOrDefault(m => m.ID == id);
            }
        }

        /// <summary>
        /// 拼装插入主数据索引的SqlCommand
        /// </summary>
        /// <param name="obj">主数据对象实体</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand AddMasterData(MasterData obj)
        {
            var sql = "insert MasterData (ParentId, CategoryId, Code, Name, Alias, FullName) ";
            sql += "select @ParentId, @CategoryId, @Code, @Name, @Alias, @FullName ";
            sql += "select ID From MasterData where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = obj.CategoryId},
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@FullName", obj.FullName),
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 拼装更新主数据索引的SqlCommand
        /// </summary>
        /// <param name="obj">主数据对象实体</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand UpdateMasterData(MasterData obj)
        {
            const string sql = "update MasterData set ParentId = @ParentId, CategoryId = @CategoryId, Code = @Code, Name = @Name, Alias = @Alias, FullName = @FullName where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = obj.CategoryId},
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@FullName", obj.FullName),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 根据ID获取联系方式
        /// </summary>
        /// <param name="id">主数据ID</param>
        /// <returns>DataTable 联系方式列表</returns>
        public static DataTable GetContactInfo(Guid id)
        {
            var sql = $"select C.ID, C.InfoTypeId as 联系方式, M.Alias, C.Number as 号码, C.IsMaster as 主要 From MDS_Contact_Info C join MasterData M on M.ID = C.InfoTypeId where C.MasterDataId = '{id}'";
            return SqlHelper.SqlQuery(SqlHelper.MakeCommand(sql));
        }

        /// <summary>
        /// 拼装插入联系方式SqlCommand集合
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dt"></param>
        /// <returns>SqlCommand List 联系方式SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> InsertContactInfo(Guid id, DataTable dt)
        {
            const string sql = "insert MDS_Contact_Info(IsMaster, MasterDataId, InfoTypeId, Number) select @IsMaster, @MasterDataId, @InfoTypeId, @Number";
            return (from DataRow row in dt.Rows
                    select new[]
                    {
                        new SqlParameter("@MasterDataId", SqlDbType.UniqueIdentifier) {Value = id}, 
                        new SqlParameter("@InfoTypeId", SqlDbType.UniqueIdentifier) {Value = row["联系方式"]},
                        new SqlParameter("@Number", row["号码"]), new SqlParameter("@IsMaster", row["主要"]), 
                        new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
                    } into parm
                    select SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 根据ID删除主数据
        /// </summary>
        /// <param name="id">主数据ID</param>
        /// <returns>bool 是否删除成功</returns>
        public static bool DeleteMasterData(Guid id)
        {
            var sql = $"delete MasterData where ID = '{id}'";
            return SqlHelper.SqlNonQuery(SqlHelper.MakeCommand(sql)) > 0;
        }

        /// <summary>
        /// 拼装删除联系方式SqlCommand集合
        /// </summary>
        /// <param name="cdl">联系方式删除列表</param>
        /// <returns>SqlCommand List SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> DeleteContactInfo(IEnumerable<object> cdl)
        {
            return cdl.Select(id => SqlHelper.MakeCommand($"delete MDS_Contact_Info where ID = '{id}'")).ToList();
        }

        /// <summary>
        /// 拼装清除同一客户/供应商下联系人的主要联系人状态
        /// </summary>
        /// <param name="id">客户/供应商ID</param>
        /// <returns>SqlCommand 对象实体</returns>
        public static SqlCommand ClearMaster(Guid? id)
        {
            return SqlHelper.MakeCommand($"update D set IsMaster = 0 from MDG_Contact D join MasterData M on M.ID = D.MID where M.ParentId = '{id}'");
        }

        /// <summary>
        /// 查询指定客户/供应商下是否存在联系人
        /// </summary>
        /// <param name="id">客户/供应商ID</param>
        /// <returns>bool 是否存在联系人</returns>
        public static bool HasContact(Guid? id)
        {
            var sql = $"select count(*) from MDG_Contact D join MasterData M on M.ID = D.MID where M.ParentId = '{id}'";
            return (int)SqlHelper.SqlScalar(SqlHelper.MakeCommand(sql)) > 0;
        }
    }
}
