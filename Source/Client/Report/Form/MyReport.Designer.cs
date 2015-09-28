using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Report
{
    partial class MyReport
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
            var resources = new ComponentResourceManager(typeof(MyReport));
            var serializableAppearanceObject1 = new SerializableAppearanceObject();
            var serializableAppearanceObject2 = new SerializableAppearanceObject();
            var serializableAppearanceObject3 = new SerializableAppearanceObject();
            var serializableAppearanceObject4 = new SerializableAppearanceObject();
            this.panTop = new PanelControl();
            this.trlReports = new TreeListLookUpEdit();
            this.treReports = new TreeList();
            this.btnOpen = new SimpleButton();
            this.datEnd = new DateEdit();
            this.datStart = new DateEdit();
            this.labApplyDate = new LabelControl();
            this.labTo = new LabelControl();
            this.grlInstances = new GridLookUpEdit();
            this.gdvInstances = new GridView();
            this.tabControl = new XtraTabControl();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.panTop)).BeginInit();
            this.panTop.SuspendLayout();
            ((ISupportInitialize)(this.trlReports.Properties)).BeginInit();
            ((ISupportInitialize)(this.treReports)).BeginInit();
            ((ISupportInitialize)(this.datEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datEnd.Properties)).BeginInit();
            ((ISupportInitialize)(this.datStart.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datStart.Properties)).BeginInit();
            ((ISupportInitialize)(this.grlInstances.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvInstances)).BeginInit();
            ((ISupportInitialize)(this.tabControl)).BeginInit();
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
            this.xtraScrollable.Controls.Add(this.tabControl);
            this.xtraScrollable.Controls.Add(this.panTop);
            // 
            // panTop
            // 
            this.panTop.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.panTop.Controls.Add(this.trlReports);
            this.panTop.Controls.Add(this.btnOpen);
            this.panTop.Controls.Add(this.datEnd);
            this.panTop.Controls.Add(this.datStart);
            this.panTop.Controls.Add(this.labApplyDate);
            this.panTop.Controls.Add(this.labTo);
            this.panTop.Controls.Add(this.grlInstances);
            this.panTop.Location = new Point(5, 5);
            this.panTop.Name = "panTop";
            this.panTop.Size = new Size(1070, 39);
            this.panTop.TabIndex = 0;
            // 
            // trlReports
            // 
            this.trlReports.Location = new Point(9, 9);
            this.trlReports.Name = "trlReports";
            this.trlReports.Properties.AutoHeight = false;
            this.trlReports.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("trlReports.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlReports.Properties.NullText = "请选择要查阅的报表类型…";
            this.trlReports.Properties.PopupFormSize = new Size(270, 320);
            this.trlReports.Properties.TreeList = this.treReports;
            this.trlReports.Size = new Size(270, 22);
            this.trlReports.TabIndex = 1;
            this.trlReports.EditValueChanged += new EventHandler(this.trlReports_EditValueChanged);
            // 
            // treReports
            // 
            this.treReports.Location = new Point(0, 0);
            this.treReports.Name = "treReports";
            this.treReports.OptionsBehavior.EnableFiltering = true;
            this.treReports.OptionsView.ShowIndentAsRowStyle = true;
            this.treReports.SelectImageList = this.imgCategoryNode;
            this.treReports.Size = new Size(400, 200);
            this.treReports.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnOpen.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.Appearance.Options.UseFont = true;
            this.btnOpen.Image = ((Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new Point(985, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new Size(77, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "预览";
            this.btnOpen.Click += new EventHandler(this.btnOpen_Click);
            // 
            // datEnd
            // 
            this.datEnd.EditValue = null;
            this.datEnd.EnterMoveNextControl = true;
            this.datEnd.Location = new Point(475, 9);
            this.datEnd.Name = "datEnd";
            this.datEnd.Properties.AllowNullInput = DefaultBoolean.False;
            this.datEnd.Properties.AutoHeight = false;
            this.datEnd.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datEnd.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.datEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datEnd.Size = new Size(100, 21);
            this.datEnd.TabIndex = 3;
            this.datEnd.EditValueChanged += new EventHandler(this.EndDateChanged);
            // 
            // datStart
            // 
            this.datStart.EditValue = null;
            this.datStart.EnterMoveNextControl = true;
            this.datStart.Location = new Point(360, 9);
            this.datStart.Name = "datStart";
            this.datStart.Properties.AllowNullInput = DefaultBoolean.False;
            this.datStart.Properties.AutoHeight = false;
            this.datStart.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datStart.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.datStart.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datStart.Size = new Size(100, 21);
            this.datStart.TabIndex = 2;
            this.datStart.EditValueChanged += new EventHandler(this.StartDateChanged);
            // 
            // labApplyDate
            // 
            this.labApplyDate.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labApplyDate.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labApplyDate.AutoSizeMode = LabelAutoSizeMode.None;
            this.labApplyDate.Location = new Point(280, 9);
            this.labApplyDate.Name = "labApplyDate";
            this.labApplyDate.Size = new Size(80, 21);
            this.labApplyDate.TabIndex = 0;
            this.labApplyDate.Text = "生成日期：";
            // 
            // labTo
            // 
            this.labTo.Appearance.ForeColor = Color.Black;
            this.labTo.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.labTo.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labTo.AutoSizeMode = LabelAutoSizeMode.None;
            this.labTo.Location = new Point(460, 9);
            this.labTo.Name = "labTo";
            this.labTo.Size = new Size(15, 21);
            this.labTo.TabIndex = 0;
            this.labTo.Text = "-";
            // 
            // grlInstances
            // 
            this.grlInstances.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.grlInstances.Location = new Point(580, 9);
            this.grlInstances.Name = "grlInstances";
            this.grlInstances.Properties.AutoHeight = false;
            this.grlInstances.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("grlInstances.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.grlInstances.Properties.NullText = "请选择要查阅的期次…";
            this.grlInstances.Properties.PopupFormSize = new Size(400, 320);
            this.grlInstances.Properties.View = this.gdvInstances;
            this.grlInstances.Size = new Size(400, 21);
            this.grlInstances.TabIndex = 4;
            // 
            // gdvInstances
            // 
            this.gdvInstances.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gdvInstances.Name = "gdvInstances";
            this.gdvInstances.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvInstances.OptionsView.ShowColumnHeaders = false;
            this.gdvInstances.OptionsView.ShowGroupPanel = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.tabControl.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.tabControl.Enabled = false;
            this.tabControl.HeaderAutoFill = DefaultBoolean.False;
            this.tabControl.HeaderButtons = ((TabButtons)(((TabButtons.Prev | TabButtons.Next) 
            | TabButtons.Close)));
            this.tabControl.HeaderButtonsShowMode = TabButtonShowMode.Always;
            this.tabControl.HeaderLocation = TabHeaderLocation.Bottom;
            this.tabControl.Location = new Point(5, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new Size(1074, 550);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedPageChanged += new TabPageChangedEventHandler(this.tabControl_SelectedPageChanged);
            this.tabControl.CloseButtonClick += new EventHandler(this.tabControl_CloseButtonClick);
            // 
            // MyReport
            // 
            this.AcceptButton = this.btnOpen;
            this.ClientSize = new Size(1080, 629);
            this.Name = "MyReport";
            this.Load += new EventHandler(this.MyReport_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.panTop)).EndInit();
            this.panTop.ResumeLayout(false);
            ((ISupportInitialize)(this.trlReports.Properties)).EndInit();
            ((ISupportInitialize)(this.treReports)).EndInit();
            ((ISupportInitialize)(this.datEnd.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datEnd.Properties)).EndInit();
            ((ISupportInitialize)(this.datStart.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datStart.Properties)).EndInit();
            ((ISupportInitialize)(this.grlInstances.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvInstances)).EndInit();
            ((ISupportInitialize)(this.tabControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panTop;
        private SimpleButton btnOpen;
        private DateEdit datEnd;
        private DateEdit datStart;
        private LabelControl labApplyDate;
        private LabelControl labTo;
        private XtraTabControl tabControl;
        private TreeListLookUpEdit trlReports;
        private TreeList treReports;
        private GridLookUpEdit grlInstances;
        private GridView gdvInstances;

    }
}
