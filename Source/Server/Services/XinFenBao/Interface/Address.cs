using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.XinFenBao
{
    public partial class Interface
    {

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据列表</returns>
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
        /// <returns>地市数据列表</returns>
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
        /// <returns>县市数据列表</returns>
        public List<Countys> GetCountys(Guid cityId)
        {
            using (var context = new WSEntities())
            {
                return context.Countys.Where(c => c.CategoryId == cityId).ToList();
            }
        }

        /// <summary>
        /// 获取会员收货地址列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>收货地址列表</returns>
        public List<MDE_Member_Address> GetAddresses(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDE_Member_Address.Where(a => a.MemberId == us.UserId).ToList();
            }
        }

        /// <summary>
        /// 获取会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">对象ID</param>
        /// <returns>bool 是否成功</returns>
        public MDE_Member_Address GetAddress(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDE_Member_Address.FirstOrDefault(a => a.ID == id);
            }
        }

        /// <summary>
        /// 设置默认收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">对象ID</param>
        /// <returns>bool 是否成功</returns>
        public bool SetDefaultAddress(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var list = context.MDE_Member_Address.Where(a => a.MemberId == us.UserId).ToList();
                list.ForEach(a => a.Default = a.ID == id);
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 新增会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">收货地址对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool AddDeliveryAddress(Session us, MDE_Member_Address obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "insert MDE_Member_Address (MemberId, Name, Mobile, StateId, CityId, CountyId, Street, ZipCode, Description) select @MemberId, @Name, @Mobile, @StateId, @CityId, @CountyId, @Street, @ZipCode, @Description";
            var parm = new[]
            {
                new SqlParameter("@MemberId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Mobile", obj.Mobile),
                new SqlParameter("@StateId", SqlDbType.UniqueIdentifier) {Value = obj.StateId},
                new SqlParameter("@CityId", SqlDbType.UniqueIdentifier) {Value = obj.CityId},
                new SqlParameter("@CountyId", SqlDbType.UniqueIdentifier) {Value = obj.CountyId},
                new SqlParameter("@Street", obj.Street),
                new SqlParameter("@ZipCode", obj.ZipCode),
                new SqlParameter("@Description", obj.Description),
            };
            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 编辑会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">收货地址对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool EditDeliveryAddress(Session us, MDE_Member_Address obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var address = context.MDE_Member_Address.Single(a => a.ID == obj.ID);
                address.Name = obj.Name;
                address.Mobile = obj.Mobile;
                address.StateId = obj.StateId;
                address.CityId = obj.CityId;
                address.CountyId = obj.CountyId;
                address.Street = obj.Street;
                address.Description = obj.Description;
                address.ZipCode = obj.ZipCode;
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除会员收货地址
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">对象ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DelDeliveryAddress(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var address = context.MDE_Member_Address.Single(a => a.ID == id);
                try
                {
                    context.MDE_Member_Address.Remove(address);
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.Message);
                    return false;
                }
            }
        }

    }
}
