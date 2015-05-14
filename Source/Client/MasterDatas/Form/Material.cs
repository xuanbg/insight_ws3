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
    public partial class Material : MdiBase
    {

        #region 声明变量

        private MasterDatasClient _Client;
        private DataTable _Categorys;
        private DataTable _Materials;
        private Guid _CategoryId = Guid.Empty;
        private bool _HasCategory;
        private bool _CanEditCat;
        private bool _HasMaterial;
        private bool _CanEdit;
        private bool _CanDel;
        private bool _CanEnable;

        #endregion

        #region 构造函数

        public Material()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Material_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitCategory();
        }

        /// <summary>
        /// 分类树所选节点变化后刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treCategory_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            _CategoryId = (Guid)treCategory.FocusedNode.GetValue("ID");
            _CanEditCat = !(bool)e.Node.GetValue("BuiltIn");
            var canDel = (_CanEditCat && !e.Node.HasChildren && !_HasMaterial);
            SwitchItemStatus(new Context("EditCatalog", _CanEditCat), new Context("DeleteCatalog", canDel), new Context("NewMaterial", _HasCategory));
            InitMaterial();
        }

        /// <summary>
        /// 双击树编辑焦点所在节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treCategory_DoubleClick(object sender, EventArgs e)
        {
            if (_CanEditCat) Category(true);
        }

        /// <summary>
        /// 列表所选数据变化刷新工具栏状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvMaterial_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var row = gdvMaterial.GetFocusedDataRow();
            _CanEnable = row["状态"].ToString() != "正常";
            _CanEdit = (int)row["Permission"] == 1;
            _CanDel = _CanEdit && !_CanEnable;
            SwitchItemStatus(new Context("EditMaterial", _CanEdit), new Context("DeleteMaterial", _CanDel), new Context("Enable", _CanEnable));
        }

        /// <summary>
        /// 双击列表编辑或启用选定物资数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvMaterial_DoubleClick(object sender, EventArgs e)
        {
            if (_CanEnable)
            {
                Enable();
            }
            else if (_CanEdit)
            {
                MaterialData(true);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化分类目录
        /// </summary>
        private void InitCategory()
        {
            _Categorys = Commons.Categorys(ModuleId);

            _Client = new MasterDatasClient(Binding, Address);
            _Materials = _Client.GetMaterials(UserSession);
            _Client.Close();

            _HasCategory = _Categorys.Rows.Count > 0;

            var ids = new List<object>();
            treCategory.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => ids.Add(n.GetValue("ID")));
            var fid = treCategory.FocusedNode == null ? null : treCategory.FocusedNode.GetValue("ID");

            treCategory.DataSource = _Categorys;
            Format.TreeFormat(treCategory);
            treCategory.ExpandToLevel(0);
            treCategory.MoveFirst();

            ids.ForEach(id => { treCategory.FindNodeByKeyID(id).Expanded = true; });
            treCategory.FocusedNode = treCategory.FindNodeByKeyID(fid);

            InitMaterial();
        }

        /// <summary>
        /// 初始化物资数据
        /// </summary>
        private void InitMaterial()
        {
            var dv = _Materials.Copy().DefaultView;
            dv.RowFilter = string.Format("CategoryId = '{0}'", _CategoryId);
            _HasMaterial = dv.Count > 0;
            if (!_HasMaterial)
            {
                SwitchItemStatus(new Context("EditMaterial", false), new Context("DeleteMaterial", false), new Context("Enable", false));
            }

            grdMaterial.DataSource = dv;
            Format.GridFormat(gdvMaterial);
            gdvMaterial.Columns["名称"].Width = 160;
            gdvMaterial.Columns["型号"].Width = 80;
            gdvMaterial.Columns["备注"].Width = 215;
        }

        #endregion

        #region 菜单事件处理

        /// <summary>
        /// 重载菜单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitCategory();
                    break;

                case "NewCatalog":
                    Category(false);
                    break;

                case "EditCatalog":
                    Category(true);
                    break;

                case "DeleteCatalog":
                    DeleteCatalog(treCategory);
                    break;

                case "NewMaterial":
                    MaterialData(false);
                    break;

                case "EditMaterial":
                    MaterialData(true);
                    break;

                case "DeleteMaterial":
                    DeleteMaterial();
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
        private void Category(bool isEdit)
        {
            if (!EditCatalog(_CategoryId, isEdit)) return;

            InitCategory();
        }

        /// <summary>
        /// 添加编辑物料
        /// </summary>
        /// <param name="isEdit"></param>
        private void MaterialData(bool isEdit)
        {
            var fr = gdvMaterial.FocusedRowHandle;
            var dig = new MaterialData
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId = isEdit ? (Guid) gdvMaterial.GetFocusedDataRow()["ID"] : (Guid) treCategory.FocusedNode.GetValue("ID")
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitCategory();
                gdvMaterial.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除物料
        /// </summary>
        private void DeleteMaterial()
        {
            var row = gdvMaterial.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要删除【{0}】吗?", row["名称"])) == DialogResult.OK)
            {
                _Client = new MasterDatasClient(Binding, Address);
                var n = _Client.DelMaterial(UserSession, (Guid)row["ID"]);
                _Client.Close();

                switch (n)
                {
                    case 0:
                        General.ShowError("对不起，该物资已经被使用，且无法停用！");
                        break;

                    case 1:
                        _Materials.Rows.Find(row["ID"]).Delete();
                        _Materials.AcceptChanges();
                        InitMaterial();
                        break;

                    case 2:
                        General.ShowMessage("该物资已被使用，无法删除，已停用！");
                        _Materials.Rows.Find(row["ID"])["状态"] = "停用";
                        _Materials.AcceptChanges();
                        InitMaterial();
                        break;
                }
            }
        }

        /// <summary>
        /// 更新物料状态
        /// </summary>
        private void Enable()
        {
            var row = gdvMaterial.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要启用【{0}】吗?", row["名称"])) != DialogResult.OK) return;

            if (Commons.EnableMasterData((Guid)row["ID"], "MDG_Material"))
            {
                _Materials.Rows.Find(row["ID"])["状态"] = "正常";
                _Materials.AcceptChanges();
                InitMaterial();
            }
            else
            {
                General.ShowError(string.Format("对不起，物资【{0}】启用失败！", row["名称"]));
            }
        }

        #endregion

    }
}
