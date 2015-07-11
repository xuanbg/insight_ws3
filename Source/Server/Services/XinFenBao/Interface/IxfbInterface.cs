using System;
using System.Collections.Generic;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.XinFenBao
{
    [ServiceContract]
    public interface IXfbInterface
    {

        #region 查询

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据集合</returns>
        [OperationContract]
        List<States> GetStates();

        /// <summary>
        /// 根据省ID获取地市数据
        /// </summary>
        /// <param name="stateId">省ID</param>
        /// <returns>地市数据集合</returns>
        [OperationContract]
        List<Citys> GetCitys(Guid stateId);

        /// <summary>
        /// 根据地市ID获取县市数据
        /// </summary>
        /// <param name="cityId">地市ID</param>
        /// <returns>县市数据集合</returns>
        [OperationContract]
        List<Countys> GetCountys(Guid cityId);

        #endregion

        #region 新增


        #endregion

        #region 编辑


        #endregion

        #region 用户登录

        /// <summary>
        /// 获取用户Session对象实体
        /// </summary>
        /// <param name="ln">登录账号</param>
        /// <param name="pw">登录密码</param>
        /// <returns>Session 用户Session对象实体</returns>
        [OperationContract]
        Session GetSession(string ln, string pw);
        
        #endregion

    }

}
