using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Report.Dialog;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report
{
    public partial class ReportManage : MdiBase
    {

        #region 变量声明

        private DataTable _Categorys;
        private DataTable _Reports;
        private DataTable _Rules;
        private DataTable _Entitys;
        private DataTable _Members;
        private bool _HasReport;
        private bool _HasEntity;
        private bool _CanEdit;
        private bool _CanNew;

        #endregion

        #region 构造函数

        public ReportManage()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载时初始化分类并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitCategory();

            var entity = Commons.OrgTree();
            var templte = Commons.Templets("Report");
            _CanNew = entity.Rows.Count > 0 && templte.Rows.Count > 0;
        }

        /// <summary>
        /// 所选分类变化时右侧列表内容相应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            InitReport();
            var canDel = (!(bool)treCategory.FocusedNode.GetValue("BuiltIn") && !treCategory.FocusedNode.HasChildren && !_HasReport);
            SwitchItemStatus(new Context("DeleteCatalog", canDel));
        }

        /// <summary>
        /// 双击报表分类编辑鼠标选定报表分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treCategory_DoubleClick(object sender, EventArgs e)
        {
            if (treCategory.FocusedNode == null) return;

            Catalog(true);
        }

        /// <summary>
        /// 双击报表定义列表编辑鼠标选定报表定义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvReport_DoubleClick(object sender, EventArgs e)
        {
            if (gdvReport.GetFocusedRow() == null || !_CanEdit) return;

            EditReport(true);
        }

        /// <summary>
        /// 所选报表发生变化后刷新报表分期和统计实体列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvReport_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _CanEdit = (int)gdvReport.GetFocusedDataRow()["Permission"] == 1;
            SwitchItemStatus(new Context("NewReport", _CanNew), new Context("EditReport", _CanEdit), new Context("DeleteReport", _CanEdit));
            InitRules();
            InitEntitys();
        }

        /// <summary>
        /// 所选统计实体发生变化后刷新报送对象信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvEntity_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            InitMembers();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载【报表】分类
        /// </summary>
        private void InitCategory()
        {
            _Categorys = Commons.Categorys(ModuleId);

            using (var cli = new ReportClient(Binding, Address))
            {
                _Reports = cli.GetReports(UserSession);
                _Rules = cli.GetReportRules(UserSession);
                _Entitys = cli.GetReportEntitys(UserSession);
                _Members = cli.GetReportMembers(UserSession);
            }

            var ids = new List<object>();
            treCategory.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => { ids.Add(n.GetValue("ID")); });
            var fid = treCategory.FocusedNode?.GetValue("ID");

            treCategory.DataSource = _Categorys;
            Format.TreeFormat(treCategory);
            treCategory.ExpandAll();

            ids.ForEach(id => { treCategory.FindNodeByKeyID(id).Expanded = true; });
            treCategory.FocusedNode = treCategory.FindNodeByKeyID(fid);
        }

        /// <summary>
        /// 初始化报表信息
        /// </summary>
        private void InitReport()
        {
            var dv = _Reports.Copy().DefaultView;
            dv.RowFilter = $"CategoryId = '{treCategory.FocusedNode.GetValue("ID")}'";
            _HasReport = dv.Count > 0;
            SwitchItemStatus(new Context("EditReport", _HasReport), new Context("DeleteReport", _HasReport));

            grdReport.DataSource = dv;
            Format.GridFormat(gdvReport);
            gdvReport.Columns["模式"].Width = 40;
            gdvReport.Columns["模式"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvReport.Columns["名称"].Width = 160;
            gdvReport.Columns["模板"].Width = 200;
            gdvReport.Columns["数据源"].Width = 60;
            gdvReport.Columns["数据源"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvReport.Columns["备注"].Width = 315;

            InitRules();
            InitEntitys();
        }

        /// <summary>
        /// 初始化分期信息
        /// </summary>
        private void InitRules()
        {
            var dv = _Rules.Copy().DefaultView;
            dv.RowFilter = $"ReportId = '{(_HasReport ? gdvReport.GetFocusedDataRow()["ID"] : null)}'";
            grdRules.DataSource = _HasReport ? dv : null;
            Format.GridFormat(gdvRules);
            gdvRules.OptionsView.ShowColumnHeaders = false;
        }

        /// <summary>
        /// 初始化报送主体
        /// </summary>
        private void InitEntitys()
        {
            var dv = _Entitys.Copy().DefaultView;
            dv.RowFilter = $"ReportId = '{(_HasReport ? gdvReport.GetFocusedDataRow()["ID"] : "")}'";
            _HasEntity = dv.Count > 0;

            grdEntitys.DataSource = _HasReport ? dv : null;
            Format.GridFormat(gdvEntitys);
            gdvEntitys.OptionsView.ShowColumnHeaders = false;
            InitMembers();
        }


        /// <summary>
        /// 初始化报送人员
        /// </summary>
        private void InitMembers()
        {
            var dv = _Members.Copy().DefaultView;
            dv.RowFilter = $"EntityId = '{(_HasEntity ? gdvEntitys.GetFocusedDataRow()["ID"] : "")}'";
            grdMembers.DataSource = _HasEntity ? dv : null;

            Format.GridFormat(gdvMembers);
            gdvMembers.OptionsView.ShowColumnHeaders = false;
        }

        #endregion

        #region 为按钮注册事件

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

                case "NewReport":
                    EditReport(false);
                    break;

                case "EditReport":
                    EditReport(true);
                    break;

                case "DeleteReport":
                    DelReport();
                    break;

                case "Rules":
                    OpenRule();
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
        /// 新建/编辑报表
        /// </summary>
        private void EditReport(bool isEdit)
        {
            var fr = gdvReport.FocusedRowHandle;
            var dig = new ReportWizard
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId =
                    isEdit ? (Guid) gdvReport.GetFocusedDataRow()["ID"] : (Guid) treCategory.FocusedNode.GetValue("ID")
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitCategory();
                gdvReport.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除报表
        /// </summary>
        private void DelReport()
        {
            var row = gdvReport.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除报表【{row["名称"]}】吗?") != DialogResult.OK) return;

            using (var cli = new ReportClient(Binding, Address))
            {
                if (!cli.DelReport(UserSession, (Guid) row["ID"]))
                {
                    General.ShowError("对不起，该报表已经被使用，无法删除！");
                    return;
                }
                
                _Reports.Rows.Find(row["ID"]).Delete();
                _Reports.AcceptChanges();
                InitReport();
            }
        }

        /// <summary>
        /// 分期规则
        /// </summary>
        private void OpenRule()
        {
            var navItem = new NavBarItem
            {
                Tag = Guid.Parse("6C0C486F-E039-4C53-9F36-9FE262FB0D3C")
            };
            var link = new NavBarItemLink(navItem);
            ((MainForm)MdiParent).navItem_LinkClicked(null, new NavBarLinkEventArgs(link));
        }

        #endregion

    }
}
