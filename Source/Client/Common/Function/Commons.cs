using System;
using System.Collections.Generic;
using System.Data;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public static class Commons
    {

        #region 公共方法

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="all">是否获取隐藏分类（默认否）</param>
        /// <param name="alias">是否显示别名（默认否）</param>
        /// <returns>DataTable 分类列表</returns>
        public static DataTable Categorys(Guid mid, bool all = false, bool alias = false)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetCategorys(MainForm.Session, mid, all, alias);
            }
        }

        /// <summary>
        /// 获取组织机构列表
        /// </summary>
        /// <returns>DataTable 组织机构列表</returns>
        public static DataTable OrgTree()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetOrgTree(MainForm.Session);
            }
        }

        /// <summary>
        /// 获取编码方案列表
        /// </summary>
        /// <returns>DataTable 编码方案列表</returns>
        public static DataTable CodeSchemes()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetCodeSchemes(MainForm.Session);
            }
        }

        /// <summary>
        /// 获取主数据列表
        /// </summary>
        /// <param name="type">类型码</param>
        /// <returns>DataTable 主数据列表</returns>
        public static DataTable MasterDatas(int type)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetMasterDatas(MainForm.Session, type);
            }
        }

        /// <summary>
        /// 获取收支项目
        /// </summary>
        /// <returns>DataTable 收支项目</returns>
        public static DataTable Expenses()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetExpense(MainForm.Session);
            }
        }

        /// <summary>
        /// 获取物资材料
        /// </summary>
        /// <returns>DataTable 物资材料</returns>
        public static DataTable Materials()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetMaterials(MainForm.Session);
            }
        }

        /// <summary>
        /// 删除在线用户会话
        /// </summary>
        /// <param name="us"></param>
        /// <returns>bool 是否删除成功</returns>
        public static bool DelOnlineUser(Session us)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.Logout(us);
            }
        }

        #endregion

        #region 验证公共方法

        /// <summary>
        /// 验证内容是否已存在
        /// </summary>
        /// <param name="str">验证内容</param>
        /// <param name="col">数据列名称</param>
        /// <param name="tab">数据表名称（默认MasterData）</param>
        /// <returns>bool 内容是否存在</returns>
        public static bool NameIsExist(string str, string col, string tab = "MasterData")
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.NameIsExist(MainForm.Session, tab, col, str);
            }
        }

        /// <summary>
        /// 验证指定分类下内容是否已存在
        /// </summary>
        /// <param name="pid">分类ID</param>
        /// <param name="str">验证内容</param>
        /// <param name="col">数据列名称</param>
        /// <param name="tab">数据表名称（默认MasterData）</param>
        /// <param name="isParent">是否按父级（默认否：按分类）</param>
        /// <returns>bool 内容是否存在</returns>
        public static bool NameIsExist(Guid? pid, string str, string col, string tab = "MasterData", bool isParent = false)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.NameIsExisting(MainForm.Session, pid, tab, col, str, isParent);
            }
        }

        /// <summary>
        /// 全部分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">要比对的名称</param>
        /// <returns>bool:要比对的名称是否存在</returns>
        public static bool NameIsExist(Guid mid, string col, string str)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GlobalNameIsExisting(MainForm.Session, mid, col, str);
            }
        }

        /// <summary>
        /// 父分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="pid">父节点ID</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">要比对的名称</param>
        /// <returns>bool:要比对的名称是否存在</returns>
        public static bool NameIsExist(Guid mid, Guid? pid, string col, string str)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.LocalNameIsExisting(MainForm.Session, mid, col, str, pid);
            }
        }

        /// <summary>
        /// 获取节点或分类下对象数量
        /// </summary>
        /// <param name="id">分类或节点ID</param>
        /// <param name="tab">表名称（默认MasterData）</param>
        /// <param name="type">类型（默认分类，可选节点）</param>
        /// <returns>int 对象数量</returns>
        public static int GetObjectCount(Guid? id, string type = "CategoryId", string tab = "MasterData")
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetObjectCount(MainForm.Session, id, type, tab);
            }
        }

        #endregion

        #region 报表公共方法

        /// <summary>
        /// 获取全部可用的报表模板
        /// </summary>
        /// <param name="type">模板类型</param>
        /// <param name="withOutTree">是否不带分类</param>
        /// <returns>DataTable 可用报表模板列表</returns>
        public static DataTable Templets(string type, bool withOutTree = true)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetReportTemplet(MainForm.Session, type, withOutTree);
            }
        }

        /// <summary>
        /// 获取打印或预览内容
        /// </summary>
        /// <param name="oid">数据对象ID</param>
        /// <param name="tid">模板ID</param>
        /// <param name="img">ImageData对象实体</param>
        /// <returns>ImageData对象实体</returns>
        public static ImageData BuildImageData(Guid oid, Guid tid, ImageData img = null)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.BuildImageData(MainForm.Session, oid, tid, img);
            }
        }

        #endregion

        #region 电子影像公共方法

        /// <summary>
        /// 根据ID获取电子影像对象实体
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public static ImageData ImageData(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetImageData(MainForm.Session, id);
            }
        }

        /// <summary>
        /// 单独上传附件到数据库
        /// </summary>
        /// <param name="bid">业务记录ID</param>
        /// <param name="imgs">ImageData对象集合</param>
        /// <param name="tab">业务附件表名称</param>
        /// <param name="col">>业务附件表主记录字段</param>
        /// <returns>bool 是否成功</returns>
        public static bool SaveImages(Guid bid, List<ImageData> imgs, string tab, string col)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.SaveImages(MainForm.Session, bid, imgs, tab, col);
            }
        }

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>bool 是否成功</returns>
        public static bool DelImageData(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.DelImageData(MainForm.Session, id);
            }
        }

        #endregion

        #region 选项公共方法

        /// <summary>
        /// 获取模块有效选项参数
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <returns>SYS_ModuleParam List 参数集合</returns>
        public static List<SYS_ModuleParam> ModuleParam(Guid mid)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetModuleParam(MainForm.Session, mid);
            }
        }

        /// <summary>
        /// 获取模块个人选项参数
        /// </summary>
        /// <param name="id">模块ID</param>
        /// <returns>SYS_ModuleParam List 参数集合</returns>
        // ReSharper disable once UnusedMember.Global
        public static List<SYS_ModuleParam> UserParam(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetModuleUserParam(MainForm.Session, id);
            }
        }

        /// <summary>
        /// 获取模块部门选项参数
        /// </summary>
        /// <param name="id">模块ID</param>
        /// <returns>SYS_ModuleParam List 参数集合</returns>
        public static List<SYS_ModuleParam> DeptParam(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetModuleDeptParam(MainForm.Session, id);
            }
        }

        /// <summary>
        /// 保存模块选项参数
        /// </summary>
        /// <param name="apl">新增参数集合</param>
        /// <param name="upl">更新参数集合</param>
        /// <returns></returns>
        public static bool SaveModuleParam(List<SYS_ModuleParam> apl, List<SYS_ModuleParam> upl)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.SaveModuleParam(MainForm.Session, apl, upl);
            }
        }

        #endregion

        #region 主数据公共方法

        /// <summary>
        /// 更新数据状态为可用
        /// </summary>
        /// <param name="id">数据ID</param>
        /// <param name="tab">数据表名称</param>
        /// <returns>bool 是否成功</returns>
        public static bool EnableMasterData(Guid id, string tab)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.EnableMasterData(MainForm.Session, id, tab);
            }
        }

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="id">数据ID</param>
        /// <param name="tab">数据表名称</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        public static int DelMasterData(Guid id, string tab = null)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.DelMasterData(MainForm.Session, id, tab);
            }
        }

        /// <summary>
        /// 根据ID获取主数据对象实体
        /// </summary>
        /// <param name="id">主数据ID</param>
        /// <returns>MasterData 主数据对象实体</returns>
        public static MasterData GetMasterData(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetMasterData(MainForm.Session, id);
            }
        }

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="type">字典类型，参看主数据初始化脚本说明</param>
        /// <param name="withOutTree">是否不带分类</param>
        /// <returns>DataTable</returns>
        public static DataTable Dictionary(string type, bool withOutTree = true)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetDictionary(MainForm.Session, type, withOutTree);
            }
        }

        /// <summary>
        /// 获取所有在职员工列表
        /// </summary>
        /// <returns>DataTable 在职员工列表</returns>
        public static DataTable GetAllEmployees()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetAllEmployees(MainForm.Session);
            }
        }

        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <returns>DataTable 联系人列表</returns>
        public static DataTable GetContacts()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetContacts(MainForm.Session);
            }
        }

        /// <summary>
        /// 获取所有联系方式列表
        /// </summary>
        /// <returns>DataTable 联系方式列表</returns>
        public static DataTable GetContactInfos()
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetContactInfos(MainForm.Session);
            }
        }

        /// <summary>
        /// 根据ID获取联系人对象实体
        /// </summary>
        /// <param name="id">联系人ID</param>
        /// <returns>MDG_Customer 联系人对象实体</returns>
        public static MDG_Contact GetContact(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetContact(MainForm.Session, id);
            }
        }

        /// <summary>
        /// 根据ID获取联系人联系方式
        /// </summary>
        /// <param name="id">员工ID</param>
        /// <returns>DataTable 联系方式列表</returns>
        public static DataTable GetContactInfo(Guid id)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.GetContactInfo(MainForm.Session, id);
            }
        }

        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Contact对象实体</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        public static bool AddContact(MasterData m, MDG_Contact d, DataTable cdt)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.AddContact(MainForm.Session, m, d, cdt);
            }
        }

        /// <summary>
        /// 更新联系人和联系方式
        /// </summary>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Contact对象实体</param>
        /// <param name="cdl">联系方式删除列表</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        public static bool UpdateContact(MasterData m, MDG_Contact d, List<object> cdl, DataTable cdt)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                return cli.UpdateContact(MainForm.Session, m, d, cdl, cdt);
            }
        }

        #endregion

    }
}
