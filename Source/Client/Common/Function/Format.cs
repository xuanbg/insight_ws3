using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace Insight.WS.Client.Common
{
    public class Format
    {
        private const string Ignores = "SN;Index;Type;Class;Permission;Selected;Status;CheckState;BuiltIn;IsMaster;Enable;Visible;NodeType;IsData;Action;Alias;Code;PrintTimes;Unit";
        private const string AlignCenters = "类型;状态;创建人;规格;单位;单价;数量;币种;汇率";
        private const string ColumnW40S = "类型;状态;内置;预置";
        private const string ColumnW80S = "创建人;简称;编码;规格;单位;单价;数量;币种;汇率";
        private const string Numerics = "汇率;单价;数量";

        /// <summary>
        /// 格式化GridView样式和属性
        /// </summary>
        /// <param name="view"></param>
        /// <param name="width"></param>
        /// <param name="editable"></param>
        /// <param name="rowclick"></param>
        public static void GridFormat(GridView view, int width = 36, bool editable = false, bool rowclick = true)
        {
            if (rowclick)
            {
                view.RowClick -= RowClick;
                view.RowClick += RowClick;
            }

            // 格式化列样式
            if (width > 0)
            {
                view.CustomDrawRowIndicator -= CustomDrawRowIndicator;
                view.CustomDrawRowIndicator += CustomDrawRowIndicator;
                view.IndicatorWidth = width;
            }
            else
            {
                view.OptionsView.ShowIndicator = false;
            }

            foreach (GridColumn col in view.Columns)
            {
                var name = col.FieldName;
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.Visible = Ignores.IndexOf(name) < 0 && !name.EndsWith("ID", StringComparison.CurrentCultureIgnoreCase);

                if (ColumnW40S.IndexOf(name) >= 0) col.Width = 40;
                if (ColumnW80S.IndexOf(name) >= 0) col.Width = 80;
                if (AlignCenters.IndexOf(name) >= 0) col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                if (name == "Index") col.SortOrder = ColumnSortOrder.Ascending;
                if (Numerics.IndexOf(name) >= 0)
                {
                    col.DisplayFormat.FormatType = FormatType.Numeric;
                    col.DisplayFormat.FormatString = "#,##0.######";
                }
                if (name.EndsWith("金额"))
                {
                    col.DisplayFormat.FormatType = FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n";
                    col.Width = 120;
                }
                if (name.EndsWith("时间"))
                {
                    col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    col.DisplayFormat.FormatType = FormatType.DateTime;
                    col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                    col.Width = 110;
                }
                if (name.EndsWith("日期"))
                {
                    col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    col.DisplayFormat.FormatType = FormatType.DateTime;
                    col.DisplayFormat.FormatString = "yyyy-MM-dd";
                    col.Width = 80;
                }
            }

            // 格式化GridView属性
            view.OptionsBehavior.Editable = editable;
            view.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsCustomization.AllowGroup = false;
            view.OptionsCustomization.AllowSort = false;
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.EnableAppearanceOddRow = true;
            view.RowHeight = 21;
            view.FocusRectStyle = editable ? DrawFocusRectStyle.CellFocus : DrawFocusRectStyle.RowFullFocus;
            view.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
        }

        /// <summary>
        /// 格式化TreeList样式和属性
        /// </summary>
        /// <param name="tree"></param>
        public static void TreeFormat(TreeList tree)
        {
            // 根据忽略列表隐藏列且使列标题文字居中显示
            foreach (TreeListColumn column in tree.Columns)
            {
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                var name = column.FieldName;
                column.Visible = Ignores.IndexOf(name) < 0 && name.Substring(name.Length - 2).ToUpper() != "ID";
                if (name == "Index") column.SortOrder = SortOrder.Ascending;
            }

            // 格式化TreeList属性
            tree.OptionsBehavior.Editable = false;
            tree.OptionsView.ShowIndicator = false;
            tree.OptionsView.ShowHorzLines = false;
            tree.OptionsView.ShowVertLines = false;
            tree.OptionsView.ShowColumns = false;
            tree.RowHeight = 23;
            tree.VertScrollVisibility = ScrollVisibility.Always;
            tree.BorderStyle = BorderStyles.NoBorder;
        }

        /// <summary>
        /// 初始化LookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="table"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitLookUpEdit(LookUpEdit control, DataTable table, string dm = "Name", string vm = "ID")
        {
            control.Properties.ShowHeader = false;
            control.Properties.ShowFooter = false;
            control.Properties.DataSource = table;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.Columns.Add(new LookUpColumnInfo(control.Properties.DisplayMember));
            control.Properties.PopupFormMinSize = new Size(60, 0);
        }

        /// <summary>
        /// 初始化LookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitLookUpEdit(LookUpEdit control, DataView view, string dm = "Name", string vm = "ID")
        {
            control.Properties.ShowHeader = false;
            control.Properties.ShowFooter = false;
            control.Properties.DataSource = view;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.Columns.Add(new LookUpColumnInfo(control.Properties.DisplayMember));
            control.Properties.PopupFormMinSize = new Size(60, 0);
        }

        /// <summary>
        /// 初始化RepositoryItemLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="table"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitLookUpEdit(RepositoryItemLookUpEdit control, DataTable table, string dm = "Name", string vm = "ID")
        {
            control.ShowHeader = false;
            control.ShowFooter = false;
            control.DataSource = table;
            control.DisplayMember = dm;
            control.ValueMember = vm;
            control.Columns.Add(new LookUpColumnInfo(control.DisplayMember));
            control.PopupFormMinSize = new Size(60, 0);
        }

        /// <summary>
        /// 初始化RepositoryItemLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitLookUpEdit(RepositoryItemLookUpEdit control, DataView view, string dm = "Name", string vm = "ID")
        {
            control.ShowHeader = false;
            control.ShowFooter = false;
            control.DataSource = view;
            control.DisplayMember = dm;
            control.ValueMember = vm;
            control.Columns.Add(new LookUpColumnInfo(control.DisplayMember));
            control.PopupFormMinSize = new Size(60, 0);
        }

        /// <summary>
        /// 初始化GridLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="table"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitGridLookUpEdit(GridLookUpEdit control, DataTable table, string dm = "Name", string vm = "ID")
        {
            control.Properties.DataSource = table;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.PopulateViewColumns();
            control.Properties.PopupFormMinSize = new Size(60, 0);
            GridFormat(control.Properties.View);
        }

        /// <summary>
        /// 初始化GridLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitGridLookUpEdit(GridLookUpEdit control, DataView view, string dm = "Name", string vm = "ID")
        {
            control.Properties.DataSource = view;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.PopulateViewColumns();
            control.Properties.PopupFormMinSize = new Size(60, 0);
            GridFormat(control.Properties.View);
        }

        /// <summary>
        /// 初始化SearchLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="table"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitSearchLookUpEdit(SearchLookUpEdit control, DataTable table, string dm = "Name", string vm = "ID")
        {
            control.Properties.DataSource = table;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.PopulateViewColumns();
            GridFormat(control.Properties.View);
        }

        /// <summary>
        /// 初始化SearchLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitSearchLookUpEdit(SearchLookUpEdit control, DataView view, string dm = "Name", string vm = "ID")
        {
            control.Properties.DataSource = view;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.PopulateViewColumns();
            GridFormat(control.Properties.View);
        }

        /// <summary>
        /// 初始化TreeListLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="table"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitTreeListLookUpEdit(TreeListLookUpEdit control, DataTable table, string dm = "Name", string vm = "ID")
        {
            control.Properties.DataSource = table;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.PopupFormMinSize = new Size(60, 0);
            TreeFormat(control.Properties.TreeList);
        }

        /// <summary>
        /// 初始化TreeListLookUpEdit
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <param name="dm"></param>
        /// <param name="vm"></param>
        public static void InitTreeListLookUpEdit(TreeListLookUpEdit control, DataView view, string dm = "Name", string vm = "ID")
        {
            control.Properties.DataSource = view;
            control.Properties.DisplayMember = dm;
            control.Properties.ValueMember = vm;
            control.Properties.PopupFormMinSize = new Size(60, 0);
            TreeFormat(control.Properties.TreeList);
        }

        /// <summary>
        /// 重绘组织机构节点图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawOrgTreeNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = (int)e.Node.GetValue("NodeType") - 1;
        }

        /// <summary>
        /// 重绘分类节点图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawFolderNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                e.SelectImageIndex = e.Node.Expanded ? 2 : 1;
            }
            else
            {
                e.SelectImageIndex = 0;
            }
        }

        /// <summary>
        /// 重绘分类节点图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawItemNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            if (!(bool)e.Node.GetValue("IsData"))
            {
                e.SelectImageIndex = e.Node.Expanded ? 2 : 1;
            }
            else
            {
                e.SelectImageIndex = 0;
            }
        }

        /// <summary>
        /// 按节点类型重绘图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawNodeTypeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = (int)e.Node.GetValue("Type");
        }

        /// <summary>
        /// 为GridView生成行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            if (e.Info.IsRowIndicator && e.RowHandle > -1000)
            {
                e.Info.DisplayText = e.RowHandle >= 0 ? (e.RowHandle + 1).ToString() : "G" + e.RowHandle;
            }
        }

        /// <summary>
        /// 实现行点击选中/取消选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void RowClick(object sender, RowClickEventArgs e)
        {
            var view = (GridView)sender;
            if (e.X <= view.IndicatorWidth + view.OptionsSelection.CheckBoxSelectorColumnWidth) return;

            if (view.IsRowSelected(e.RowHandle))
            {
                view.UnselectRow(e.RowHandle);
            }
            else
            {
                view.SelectRow(e.RowHandle);
            }
        }

    }
}
