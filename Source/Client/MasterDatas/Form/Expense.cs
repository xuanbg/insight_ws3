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
    public partial class Expense : MdiBase
    {

        #region 变量声明

        private DataTable _Category;
        private DataTable _Expenses;
        private bool _HasExpense;
        private bool _CanEdit;
        private bool _CanDel;
        private bool _CanEnable;

        #endregion

        #region 构造函数

        public Expense()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        private void Expense_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitCategory();
        }

        /// <summary>
        /// 点击分类刷新列表内容
        /// </summary>
        /// <param name="sender">引用</param>
        /// <param name="e">分类事件</param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            InitExpense();
            var canDel = (!(bool)e.Node.GetValue("BuiltIn") && !e.Node.HasChildren && !_HasExpense);
            SwitchItemStatus(new Context("DeleteCatalog", canDel));
        }

        /// <summary>
        /// 双击分类进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treCategory_DoubleClick(object sender, EventArgs e)
        {
            Catalog(true);
        }

        /// <summary>
        /// 选择项目切换工具栏图标状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvExpense_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var row = gdvExpense.GetFocusedDataRow();
            _CanEnable = row["状态"].ToString() != "正常";
            _CanEdit = !(bool)row["预置"] && (int)row["Permission"] == 1;
            _CanDel = _CanEdit && !_CanEnable;
            SwitchItemStatus(new Context("EditExpense", _CanEdit), new Context("DeleteExpense", _CanDel), new Context("Enable", _CanEnable));
        }

        /// <summary>
        /// 双击项目进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdExpense_DoubleClick(object sender, EventArgs e)
        {
            if (_CanEnable)
            {
                Enable();
            }
            else if (_CanEdit)
            {
                EditExpense(true);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化分类目录
        /// </summary>
        private void InitCategory()
        {
            _Category = Commons.Categorys(ModuleId);

            using (var cli = new MasterDatasClient(Binding, Address))
            {
                _Expenses = cli.GetExpenses(UserSession);
            }

            var ids = new List<object>();
            treCategory.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => ids.Add(n.GetValue("ID")));
            var fid = treCategory.FocusedNode?.GetValue("ID");

            treCategory.DataSource = _Category;
            Format.TreeFormat(treCategory);
            treCategory.ExpandToLevel(0);

            ids.ForEach(id => { treCategory.FindNodeByKeyID(id).Expanded = true; });
            treCategory.FocusedNode = treCategory.FindNodeByKeyID(fid);

            InitExpense();
        }

        /// <summary>
        /// 初始化费用数据
        /// </summary>
        private void InitExpense()
        {
            var dv = _Expenses.Copy().DefaultView;
            dv.RowFilter = $"CategoryId = '{treCategory.FocusedNode.GetValue("ID")}'";
            _HasExpense = dv.Count > 0;
            if (!_HasExpense)
            {
                SwitchItemStatus(new Context("EditExpense", false), new Context("DeleteExpense", false), new Context("Enable", false));
            }

            grdExpense.DataSource = dv;
            Format.GridFormat(gdvExpense);
            gdvExpense.Columns["名称"].Width = 160;
            gdvExpense.Columns["备注"].Width = 255;
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 点击工具条中的按钮
        /// </summary>
        /// <param name="sender">引用</param>
        /// <param name="e">工具条事件</param>
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

                case "NewExpense":
                    EditExpense(false);
                    break;

                case "EditExpense":
                    EditExpense(true);
                    break;

                case "DeleteExpense": 
                    DeleteExpense();
                    break;

                case "Enable": 
                    Enable();
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
        /// 新建/编辑项目
        /// </summary>
        /// <param name="isEdit"></param>
        private void EditExpense(bool isEdit)
        {
            var fr = gdvExpense.FocusedRowHandle;
            var dig = new EditExpense
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId =
                    isEdit ? (Guid) gdvExpense.GetFocusedDataRow()["ID"] : (Guid) treCategory.FocusedNode.GetValue("ID")
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitCategory();
                gdvExpense.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除选定的数据，如不能删除则设置状态为停用
        /// </summary>
        private void DeleteExpense()
        {
            var row = gdvExpense.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除【{row["名称"]}】吗?") != DialogResult.OK) return;

            using (var cli = new MasterDatasClient(Binding, Address))
            {
                switch (cli.DelExpense(UserSession, (Guid) row["ID"]))
                {
                    case 0:
                        General.ShowError("对不起，该项目已经被使用，且无法停用！");
                        break;

                    case 1:
                        _Expenses.Rows.Find(row["ID"]).Delete();
                        _Expenses.AcceptChanges();
                        InitExpense();
                        break;

                    case 2:
                        General.ShowMessage("该项目已被使用，无法删除，已停用！");
                        _Expenses.Rows.Find(row["ID"])["状态"] = "停用";
                        _Expenses.AcceptChanges();
                        InitExpense();
                        break;
                }
            }
        }

        /// <summary>
        /// 将停用的选定数据重新启用
        /// </summary>
        private void Enable()
        {
            var row = gdvExpense.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要启用【{row["名称"]}】吗?") != DialogResult.OK) return;

            if (!Commons.EnableMasterData((Guid) row["ID"], "MDG_Expense"))
            {
                General.ShowError($"对不起，项目【{row["名称"]}】启用失败！");
                return;
            }
            
            _Expenses.Rows.Find(row["ID"])["状态"] = "正常";
            _Expenses.AcceptChanges();
            InitExpense();
        }

        #endregion

    }
}
