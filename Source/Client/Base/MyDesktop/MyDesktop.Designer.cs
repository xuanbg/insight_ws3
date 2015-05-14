using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;

namespace Insight.WS.Client.Platform.Base
{
    partial class MyDesktop
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MyDesktop));
            SerializableAppearanceObject serializableAppearanceObject1 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject2 = new SerializableAppearanceObject();
            this.splMain = new SplitContainerControl();
            this.panMain = new PanelControl();
            this.grdApply = new GridControl();
            this.gridView2 = new GridView();
            this.panSpace = new PanelControl();
            this.panTop = new PanelControl();
            this.btnSearch = new SimpleButton();
            this.datEnd = new DateEdit();
            this.datStart = new DateEdit();
            this.cmbStatus = new ComboBoxEdit();
            this.cmbType = new ComboBoxEdit();
            this.labStatus = new LabelControl();
            this.txtKey = new TextEdit();
            this.labApplyDate = new LabelControl();
            this.labTo = new LabelControl();
            this.labType = new LabelControl();
            this.navWork = new NavBarControl();
            this.nbgUnread = new NavBarGroup();
            this.nbgWork = new NavBarGroup();
            this.nbgDisposed = new NavBarGroup();
            this.nbtViewAllTask = new NavBarItem();
            this.nbgAffiche = new NavBarGroup();
            this.nbgReaded = new NavBarGroup();
            this.nbtViewAllMessage = new NavBarItem();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.panMain)).BeginInit();
            this.panMain.SuspendLayout();
            ((ISupportInitialize)(this.grdApply)).BeginInit();
            ((ISupportInitialize)(this.gridView2)).BeginInit();
            ((ISupportInitialize)(this.panSpace)).BeginInit();
            ((ISupportInitialize)(this.panTop)).BeginInit();
            this.panTop.SuspendLayout();
            ((ISupportInitialize)(this.datEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datEnd.Properties)).BeginInit();
            ((ISupportInitialize)(this.datStart.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datStart.Properties)).BeginInit();
            ((ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((ISupportInitialize)(this.navWork)).BeginInit();
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
            this.splMain.Dock = DockStyle.Fill;
            this.splMain.FixedPanel = SplitFixedPanel.None;
            this.splMain.Location = new Point(0, 0);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.panMain);
            this.splMain.Panel1.MinSize = 750;
            this.splMain.Panel2.Controls.Add(this.navWork);
            this.splMain.Panel2.MinSize = 150;
            this.splMain.Size = new Size(1080, 600);
            this.splMain.SplitterPosition = 845;
            this.splMain.TabIndex = 0;
            // 
            // panMain
            // 
            this.panMain.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.panMain.BorderStyle = BorderStyles.NoBorder;
            this.panMain.Controls.Add(this.grdApply);
            this.panMain.Controls.Add(this.panSpace);
            this.panMain.Controls.Add(this.panTop);
            this.panMain.Location = new Point(5, 5);
            this.panMain.Name = "panMain";
            this.panMain.Size = new Size(840, 590);
            this.panMain.TabIndex = 0;
            // 
            // grdApply
            // 
            this.grdApply.Dock = DockStyle.Fill;
            this.grdApply.Location = new Point(0, 44);
            this.grdApply.MainView = this.gridView2;
            this.grdApply.Name = "grdApply";
            this.grdApply.Size = new Size(840, 546);
            this.grdApply.TabIndex = 8;
            this.grdApply.ViewCollection.AddRange(new BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdApply;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // panSpace
            // 
            this.panSpace.BorderStyle = BorderStyles.NoBorder;
            this.panSpace.Dock = DockStyle.Top;
            this.panSpace.Location = new Point(0, 39);
            this.panSpace.Name = "panSpace";
            this.panSpace.Size = new Size(840, 5);
            this.panSpace.TabIndex = 4;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnSearch);
            this.panTop.Controls.Add(this.datEnd);
            this.panTop.Controls.Add(this.datStart);
            this.panTop.Controls.Add(this.cmbStatus);
            this.panTop.Controls.Add(this.cmbType);
            this.panTop.Controls.Add(this.labStatus);
            this.panTop.Controls.Add(this.txtKey);
            this.panTop.Controls.Add(this.labApplyDate);
            this.panTop.Controls.Add(this.labTo);
            this.panTop.Controls.Add(this.labType);
            this.panTop.Dock = DockStyle.Top;
            this.panTop.Location = new Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new Size(840, 39);
            this.panTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnSearch.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new Point(762, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(70, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查  询";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            // 
            // datEnd
            // 
            this.datEnd.EditValue = null;
            this.datEnd.Location = new Point(195, 9);
            this.datEnd.Name = "datEnd";
            this.datEnd.Properties.AllowNullInput = DefaultBoolean.False;
            this.datEnd.Properties.AutoHeight = false;
            this.datEnd.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datEnd.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datEnd.Size = new Size(100, 21);
            this.datEnd.TabIndex = 2;
            this.datEnd.EditValueChanged += new EventHandler(this.EndDateChanged);
            // 
            // datStart
            // 
            this.datStart.EditValue = null;
            this.datStart.Location = new Point(80, 9);
            this.datStart.Name = "datStart";
            this.datStart.Properties.AllowNullInput = DefaultBoolean.False;
            this.datStart.Properties.AutoHeight = false;
            this.datStart.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datStart.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.datStart.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datStart.Size = new Size(100, 21);
            this.datStart.TabIndex = 1;
            this.datStart.EditValueChanged += new EventHandler(this.StartDateChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.EditValue = "全部";
            this.cmbStatus.Location = new Point(495, 9);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.AutoHeight = false;
            this.cmbStatus.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.cmbStatus.Size = new Size(80, 21);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.EditValueChanged += new EventHandler(this.cmbStatus_EditValueChanged);
            // 
            // cmbType
            // 
            this.cmbType.EditValue = "全部";
            this.cmbType.Location = new Point(355, 9);
            this.cmbType.MenuManager = this.barManager;
            this.cmbType.Name = "cmbType";
            this.cmbType.Properties.AutoHeight = false;
            this.cmbType.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.cmbType.Size = new Size(80, 21);
            this.cmbType.TabIndex = 3;
            this.cmbType.EditValueChanged += new EventHandler(this.cmbType_EditValueChanged);
            // 
            // labStatus
            // 
            this.labStatus.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labStatus.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labStatus.AutoSizeMode = LabelAutoSizeMode.None;
            this.labStatus.Location = new Point(435, 9);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new Size(60, 21);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "状态：";
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.txtKey.Location = new Point(580, 9);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.AutoHeight = false;
            this.txtKey.Properties.NullText = "在此输入查询关键字";
            this.txtKey.Size = new Size(177, 21);
            this.txtKey.TabIndex = 5;
            // 
            // labApplyDate
            // 
            this.labApplyDate.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labApplyDate.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labApplyDate.AutoSizeMode = LabelAutoSizeMode.None;
            this.labApplyDate.Location = new Point(0, 9);
            this.labApplyDate.Name = "labApplyDate";
            this.labApplyDate.Size = new Size(80, 21);
            this.labApplyDate.TabIndex = 0;
            this.labApplyDate.Text = "申请日期：";
            // 
            // labTo
            // 
            this.labTo.Appearance.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.labTo.Appearance.ForeColor = Color.Black;
            this.labTo.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.labTo.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labTo.AutoSizeMode = LabelAutoSizeMode.None;
            this.labTo.Location = new Point(180, 9);
            this.labTo.Name = "labTo";
            this.labTo.Size = new Size(15, 21);
            this.labTo.TabIndex = 0;
            this.labTo.Text = "-";
            // 
            // labType
            // 
            this.labType.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labType.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labType.AutoSizeMode = LabelAutoSizeMode.None;
            this.labType.Location = new Point(295, 9);
            this.labType.Name = "labType";
            this.labType.Size = new Size(60, 21);
            this.labType.TabIndex = 0;
            this.labType.Text = "类型：";
            // 
            // navWork
            // 
            this.navWork.ActiveGroup = this.nbgUnread;
            this.navWork.Dock = DockStyle.Fill;
            this.navWork.Groups.AddRange(new NavBarGroup[] {
            this.nbgWork,
            this.nbgDisposed,
            this.nbgAffiche,
            this.nbgUnread,
            this.nbgReaded});
            this.navWork.Items.AddRange(new NavBarItem[] {
            this.nbtViewAllTask,
            this.nbtViewAllMessage});
            this.navWork.Location = new Point(0, 0);
            this.navWork.Name = "navWork";
            this.navWork.OptionsNavPane.ExpandedWidth = 230;
            this.navWork.Size = new Size(230, 600);
            this.navWork.TabIndex = 1;
            // 
            // nbgUnread
            // 
            this.nbgUnread.Caption = "未读消息";
            this.nbgUnread.Name = "nbgUnread";
            this.nbgUnread.SmallImage = ((Image)(resources.GetObject("nbgUnread.SmallImage")));
            // 
            // nbgWork
            // 
            this.nbgWork.Caption = "待办事务";
            this.nbgWork.Expanded = true;
            this.nbgWork.Name = "nbgWork";
            this.nbgWork.SmallImage = ((Image)(resources.GetObject("nbgWork.SmallImage")));
            // 
            // nbgDisposed
            // 
            this.nbgDisposed.Caption = "已办事务";
            this.nbgDisposed.ItemLinks.AddRange(new NavBarItemLink[] {
            new NavBarItemLink(this.nbtViewAllTask)});
            this.nbgDisposed.Name = "nbgDisposed";
            this.nbgDisposed.SmallImage = ((Image)(resources.GetObject("nbgDisposed.SmallImage")));
            // 
            // nbtViewAllTask
            // 
            this.nbtViewAllTask.Caption = "查看全部已办事务…";
            this.nbtViewAllTask.Name = "nbtViewAllTask";
            // 
            // nbgAffiche
            // 
            this.nbgAffiche.Caption = "公告/通知";
            this.nbgAffiche.Name = "nbgAffiche";
            this.nbgAffiche.SmallImage = ((Image)(resources.GetObject("nbgAffiche.SmallImage")));
            // 
            // nbgReaded
            // 
            this.nbgReaded.Caption = "已读消息";
            this.nbgReaded.ItemLinks.AddRange(new NavBarItemLink[] {
            new NavBarItemLink(this.nbtViewAllMessage)});
            this.nbgReaded.Name = "nbgReaded";
            this.nbgReaded.SmallImage = ((Image)(resources.GetObject("nbgReaded.SmallImage")));
            // 
            // nbtViewAllMessage
            // 
            this.nbtViewAllMessage.Caption = "查看全部已读消息…";
            this.nbtViewAllMessage.Name = "nbtViewAllMessage";
            // 
            // MyDesktop
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new Size(1080, 629);
            this.ControlBox = false;
            this.Name = "MyDesktop";
            this.Load += new EventHandler(this.MyDesktop_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.panMain)).EndInit();
            this.panMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grdApply)).EndInit();
            ((ISupportInitialize)(this.gridView2)).EndInit();
            ((ISupportInitialize)(this.panSpace)).EndInit();
            ((ISupportInitialize)(this.panTop)).EndInit();
            this.panTop.ResumeLayout(false);
            ((ISupportInitialize)(this.datEnd.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datEnd.Properties)).EndInit();
            ((ISupportInitialize)(this.datStart.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datStart.Properties)).EndInit();
            ((ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((ISupportInitialize)(this.navWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private PanelControl panMain;
        private GridControl grdApply;
        private GridView gridView2;
        private PanelControl panSpace;
        private PanelControl panTop;
        private SimpleButton btnSearch;
        private DateEdit datEnd;
        private DateEdit datStart;
        private ComboBoxEdit cmbStatus;
        private ComboBoxEdit cmbType;
        private LabelControl labStatus;
        private TextEdit txtKey;
        private LabelControl labApplyDate;
        private LabelControl labTo;
        private LabelControl labType;
        private NavBarControl navWork;
        private NavBarGroup nbgUnread;
        private NavBarGroup nbgWork;
        private NavBarGroup nbgDisposed;
        private NavBarGroup nbgAffiche;
        private NavBarGroup nbgReaded;
        private NavBarItem nbtViewAllTask;
        private NavBarItem nbtViewAllMessage;



    }
}
