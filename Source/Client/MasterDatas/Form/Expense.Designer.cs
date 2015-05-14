using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.MasterDatas
{
    partial class Expense
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof(Expense));
            this.splMain = new SplitContainerControl();
            this.grpCategory = new GroupControl();
            this.treCategory = new TreeList();
            this.grdExpense = new GridControl();
            this.gdvExpense = new GridView();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.grpCategory)).BeginInit();
            this.grpCategory.SuspendLayout();
            ((ISupportInitialize)(this.treCategory)).BeginInit();
            ((ISupportInitialize)(this.grdExpense)).BeginInit();
            ((ISupportInitialize)(this.gdvExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollable
            // 
            this.xtraScrollable.Controls.Add(this.splMain);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.splMain.FixedPanel = SplitFixedPanel.None;
            this.splMain.Location = new Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpCategory);
            this.splMain.Panel1.MinSize = 160;
            this.splMain.Panel2.Controls.Add(this.grdExpense);
            this.splMain.Panel2.MinSize = 600;
            this.splMain.Size = new Size(1070, 590);
            this.splMain.SplitterPosition = 200;
            this.splMain.TabIndex = 0;
            // 
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.treCategory);
            this.grpCategory.Dock = DockStyle.Fill;
            this.grpCategory.Location = new Point(0, 0);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new Size(200, 590);
            this.grpCategory.TabIndex = 0;
            this.grpCategory.Text = "项目分类";
            // 
            // treCategory
            // 
            this.treCategory.Dock = DockStyle.Fill;
            this.treCategory.Location = new Point(2, 22);
            this.treCategory.Name = "treCategory";
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new Size(196, 566);
            this.treCategory.TabIndex = 0;
            this.treCategory.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            this.treCategory.DoubleClick += new EventHandler(this.treCategory_DoubleClick);
            // 
            // grdExpense
            // 
            this.grdExpense.Dock = DockStyle.Fill;
            this.grdExpense.Location = new Point(0, 0);
            this.grdExpense.MainView = this.gdvExpense;
            this.grdExpense.Name = "grdExpense";
            this.grdExpense.Size = new Size(865, 590);
            this.grdExpense.TabIndex = 0;
            this.grdExpense.ViewCollection.AddRange(new BaseView[] {
            this.gdvExpense});
            this.grdExpense.DoubleClick += new EventHandler(this.grdExpense_DoubleClick);
            // 
            // gdvExpense
            // 
            this.gdvExpense.GridControl = this.grdExpense;
            this.gdvExpense.Name = "gdvExpense";
            this.gdvExpense.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvExpense_FocusedRowObjectChanged);
            // 
            // Expense
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new Size(1080, 629);
            this.Name = "Expense";
            this.Load += new EventHandler(this.Expense_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grpCategory)).EndInit();
            this.grpCategory.ResumeLayout(false);
            ((ISupportInitialize)(this.treCategory)).EndInit();
            ((ISupportInitialize)(this.grdExpense)).EndInit();
            ((ISupportInitialize)(this.gdvExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private TreeList treCategory;
        private GridControl grdExpense;
        private GridView gdvExpense;
        private GroupControl grpCategory;
    }
}
