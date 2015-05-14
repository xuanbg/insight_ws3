using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Platform.Base
{
    partial class CodingScheme
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CodingScheme));
            this.splMain = new SplitContainerControl();
            this.grdScheme = new GridControl();
            this.gdvScheme = new GridView();
            this.splInfo = new SplitContainerControl();
            this.grdCode = new GridControl();
            this.gdvCode = new GridView();
            this.grdAllot = new GridControl();
            this.gdvAllot = new GridView();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.grdScheme)).BeginInit();
            ((ISupportInitialize)(this.gdvScheme)).BeginInit();
            ((ISupportInitialize)(this.splInfo)).BeginInit();
            this.splInfo.SuspendLayout();
            ((ISupportInitialize)(this.grdCode)).BeginInit();
            ((ISupportInitialize)(this.gdvCode)).BeginInit();
            ((ISupportInitialize)(this.grdAllot)).BeginInit();
            ((ISupportInitialize)(this.gdvAllot)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
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
            this.splMain.Horizontal = false;
            this.splMain.Location = new Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grdScheme);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.splInfo);
            this.splMain.Panel2.MinSize = 200;
            this.splMain.Size = new Size(1070, 590);
            this.splMain.SplitterPosition = 360;
            this.splMain.TabIndex = 0;
            // 
            // grdScheme
            // 
            this.grdScheme.Dock = DockStyle.Fill;
            this.grdScheme.Location = new Point(0, 0);
            this.grdScheme.MainView = this.gdvScheme;
            this.grdScheme.Name = "grdScheme";
            this.grdScheme.Size = new Size(1070, 360);
            this.grdScheme.TabIndex = 1;
            this.grdScheme.ViewCollection.AddRange(new BaseView[] {
            this.gdvScheme});
            // 
            // gdvScheme
            // 
            this.gdvScheme.GridControl = this.grdScheme;
            this.gdvScheme.Name = "gdvScheme";
            this.gdvScheme.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvScheme_FocusedRowObjectChanged);
            this.gdvScheme.DoubleClick += new EventHandler(this.gdvScheme_DoubleClick);
            // 
            // splInfo
            // 
            this.splInfo.Dock = DockStyle.Fill;
            this.splInfo.FixedPanel = SplitFixedPanel.None;
            this.splInfo.Location = new Point(0, 0);
            this.splInfo.Name = "splInfo";
            this.splInfo.Panel1.Controls.Add(this.grdCode);
            this.splInfo.Panel1.MinSize = 400;
            this.splInfo.Panel2.Controls.Add(this.grdAllot);
            this.splInfo.Panel2.MinSize = 400;
            this.splInfo.Size = new Size(1070, 225);
            this.splInfo.SplitterPosition = 520;
            this.splInfo.TabIndex = 0;
            // 
            // grdCode
            // 
            this.grdCode.Dock = DockStyle.Fill;
            this.grdCode.Location = new Point(0, 0);
            this.grdCode.MainView = this.gdvCode;
            this.grdCode.Name = "grdCode";
            this.grdCode.Size = new Size(520, 225);
            this.grdCode.TabIndex = 2;
            this.grdCode.ViewCollection.AddRange(new BaseView[] {
            this.gdvCode});
            // 
            // gdvCode
            // 
            this.gdvCode.GridControl = this.grdCode;
            this.gdvCode.Name = "gdvCode";
            this.gdvCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvCode.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvCode_FocusedRowObjectChanged);
            // 
            // grdAllot
            // 
            this.grdAllot.Dock = DockStyle.Fill;
            this.grdAllot.Location = new Point(0, 0);
            this.grdAllot.MainView = this.gdvAllot;
            this.grdAllot.Name = "grdAllot";
            this.grdAllot.Size = new Size(545, 225);
            this.grdAllot.TabIndex = 3;
            this.grdAllot.ViewCollection.AddRange(new BaseView[] {
            this.gdvAllot});
            // 
            // gdvAllot
            // 
            this.gdvAllot.GridControl = this.grdAllot;
            this.gdvAllot.Name = "gdvAllot";
            this.gdvAllot.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvAllot_FocusedRowObjectChanged);
            // 
            // CodingScheme
            // 
            this.ClientSize = new Size(1080, 629);
            this.Name = "CodingScheme";
            this.Load += new EventHandler(this.CodingScheme_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grdScheme)).EndInit();
            ((ISupportInitialize)(this.gdvScheme)).EndInit();
            ((ISupportInitialize)(this.splInfo)).EndInit();
            this.splInfo.ResumeLayout(false);
            ((ISupportInitialize)(this.grdCode)).EndInit();
            ((ISupportInitialize)(this.gdvCode)).EndInit();
            ((ISupportInitialize)(this.grdAllot)).EndInit();
            ((ISupportInitialize)(this.gdvAllot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private GridControl grdScheme;
        private GridView gdvScheme;
        private GridControl grdCode;
        private GridView gdvCode;
        private SplitContainerControl splInfo;
        private GridControl grdAllot;
        private GridView gdvAllot;
    }
}
