using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Common;
using Insight.WS.Client.MasterDatas.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class Dictionary : MdiBase
    {

        #region 变量声明

        private DataTable _Category;
        private DataTable _Dictionary;
        private bool _CanNewCat;
        private bool _CanEditCat;
        private bool _CanEdit;
        private bool _CanDel;
        private bool _CanEnable;

        #endregion

        #region 构造方法

        public Dictionary()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 如分类为空，将编辑等按钮设置为不可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dictionary_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitCategory();
        }

        /// <summary>
        /// 选择分类刷新工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            _CanNewCat = (bool)e.Node.GetValue("Visible");
            _CanEditCat = !(bool)e.Node.GetValue("BuiltIn");
            SwitchItemStatus(new Context("NewCatalog", _CanNewCat), new Context("EditCatalog", _CanNewCat && _CanEditCat), new Context("DeleteCatalog", _CanNewCat && _CanEditCat), new Context("NewData", _CanEditCat && !e.Node.HasChildren));
            InitData();
        }

        /// <summary>
        /// 双击分类进行分类编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treCategory_DoubleClick(object sender, EventArgs e)
        {
            if (_CanNewCat) Catalog(true);
        }

        /// <summary>
        /// 根据权限设置编辑、删除、启用按钮是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvData_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _CanEnable = gdvData.GetFocusedDataRow()["状态"].ToString() != "正常";
            _CanEdit = (int)gdvData.GetFocusedDataRow()["Permission"] == 1 && !(bool)treCategory.FocusedNode.GetValue("BuiltIn");
            _CanDel = !(bool)gdvData.GetFocusedDataRow()["预置"] && (int)gdvData.GetFocusedDataRow()["Permission"] == 1 && !_CanEnable;
            SwitchItemStatus(new Context("EditData", _CanEdit), new Context("DeleteData", _CanDel), new Context("Enable", _CanEnable));
        }

        /// <summary>
        /// 双击列表编辑数据或启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvData_DoubleClick(object sender, EventArgs e)
        {
            if (_CanEnable)
            {
                Enable();
            }
            else if (_CanEdit)
            {
                EditData(true);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化分类
        /// </summary>
        private void InitCategory()
        {
            _Category = Commons.Categorys(ModuleId, true);
            using (var cli = new MasterDatasClient(Binding, Address))
            {
                _Dictionary = cli.GetDictionarys(UserSession);
            }

            var ids = new List<object>();
            treCategory.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => ids.Add(n.GetValue("ID")));
            var fid = treCategory.FocusedNode == null ? null : treCategory.FocusedNode.GetValue("ID");

            treCategory.DataSource = _Category;
            Format.TreeFormat(treCategory);
            treCategory.CollapseAll();
            treCategory.ExpandToLevel(0);

            ids.ForEach(id => { treCategory.FindNodeByKeyID(id).Expanded = true; });
            treCategory.FocusedNode = treCategory.FindNodeByKeyID(fid);
        }

        /// <summary>
        /// 初始化字典数据
        /// </summary>
        private void InitData()
        {
            var dv = _Dictionary.Copy().DefaultView;
            dv.RowFilter = string.Format("CategoryId = '{0}'", treCategory.FocusedNode.GetValue("ID"));
            grdData.DataSource = dv;

            if (dv.Count == 0)
            {
                SwitchItemStatus(new Context("EditData", false), new Context("DeleteData", false), new Context("Enable", false));
            }

            Format.GridFormat(gdvData);
            gdvData.Columns["名称"].Width = 200;
            gdvData.Columns["备注"].Width = 375;
        }

        #endregion

        #region 按钮事件

        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitCategory();
                    break;

                case "NewCatalog":
                    Catalog(false);
                    break;

                case "EditCatalog":
                    Catalog(true);
                    break;

                case "DeleteCatalog":
                    DeleteCatalog(treCategory);
                    break;

                case "NewData":
                    EditData(false);
                    break;

                case "EditData":
                    EditData(true);
                    break;

                case "DeleteData":
                    DelData();
                    break;

                case "Enable":
                    Enable();
                    break;

                case "Property":
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑分类
        /// </summary>
        private void Catalog(bool isEdit)
        {
            if (!EditCatalog((Guid) treCategory.FocusedNode.GetValue("ID"), isEdit)) return;

            InitCategory();
        }

        /// <summary>
        /// 新建/编辑选定数据
        /// </summary>
        /// <param name="isEdit"></param>
        private void EditData(bool isEdit)
        {
            var fr = gdvData.FocusedRowHandle;
            var dig = new EditData
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId = isEdit ? (Guid) gdvData.GetFocusedDataRow()["ID"] : (Guid) treCategory.FocusedNode.GetValue("ID")
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitCategory();
                gdvData.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除选定的数据，如不能删除则设置状态为停用
        /// </summary>
        private void DelData()
        {
            var row = gdvData.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要删除【{0}】吗?", row["名称"])) != DialogResult.OK) return;

            using (var cli = new MasterDatasClient(Binding, Address))
            {
                switch (cli.DelDictionary(UserSession, (Guid) row["ID"]))
                {
                    case 0:
                        General.ShowError("对不起，该数据已经被使用，且无法停用！");
                        break;

                    case 1:
                        _Dictionary.Rows.Find(row["ID"]).Delete();
                        _Dictionary.AcceptChanges();
                        InitData();
                        break;

                    case 2:
                        General.ShowMessage("该数据已被使用，无法删除，已停用！");
                        _Dictionary.Rows.Find(row["ID"])["状态"] = "停用";
                        _Dictionary.AcceptChanges();
                        InitData();
                        break;
                }
            }
        }

        /// <summary>
        /// 将停用的选定数据重新启用
        /// </summary>
        private void Enable()
        {
            var row = gdvData.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要启用【{0}】吗?", row["名称"])) != DialogResult.OK) return;

            if (!Commons.EnableMasterData((Guid) row["ID"], "MDG_Dictionary"))
            {
                General.ShowError(string.Format("对不起，数据【{0}】启用失败！", row["名称"]));
                return;
            }
            
            _Dictionary.Rows.Find(row["ID"])["状态"] = "正常";
            _Dictionary.AcceptChanges();
            InitData();
        }

        #endregion

    }
}
