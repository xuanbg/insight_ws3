using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;

namespace Insight.WS.Client.Business.Settlement.Receipt
{
    partial class Setting
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
            var resources = new ComponentResourceManager(typeof(Setting));
            this.tabSetting = new XtraTabControl();
            this.pagGeneral = new XtraTabPage();
            this.grlCheckWF = new GridLookUpEdit();
            this.gdvCheckWF = new GridView();
            this.labCheckWF = new LabelControl();
            this.cmbWipeLevel = new ComboBoxEdit();
            this.cmbWipeType = new ComboBoxEdit();
            this.labDefault = new LabelControl();
            this.labSecrecy = new LabelControl();
            this.labWipe = new LabelControl();
            this.lokDefault = new LookUpEdit();
            this.lokSecrecy = new LookUpEdit();
            this.pagTemplet = new XtraTabPage();
            this.grlCheckT = new GridLookUpEdit();
            this.gdvCheckT = new GridView();
            this.labCheckT = new LabelControl();
            this.grlPaymentT = new GridLookUpEdit();
            this.gdvPaymentT = new GridView();
            this.labPaymentT = new LabelControl();
            this.grlReceiptT = new GridLookUpEdit();
            this.gdvReceiptT = new GridView();
            this.labReceiptT = new LabelControl();
            this.pagScheme = new XtraTabPage();
            this.labCheckS = new LabelControl();
            this.labPaymentS = new LabelControl();
            this.labReceiptS = new LabelControl();
            this.grlCheckS = new GridLookUpEdit();
            this.gdvCheckS = new GridView();
            this.grlPaymentS = new GridLookUpEdit();
            this.gdvPaymentS = new GridView();
            this.grlReceiptS = new GridLookUpEdit();
            this.gdvReceiptS = new GridView();
            ((ISupportInitialize)(this.panel)).BeginInit();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.tabSetting)).BeginInit();
            this.tabSetting.SuspendLayout();
            this.pagGeneral.SuspendLayout();
            ((ISupportInitialize)(this.grlCheckWF.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvCheckWF)).BeginInit();
            ((ISupportInitialize)(this.cmbWipeLevel.Properties)).BeginInit();
            ((ISupportInitialize)(this.cmbWipeType.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokDefault.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokSecrecy.Properties)).BeginInit();
            this.pagTemplet.SuspendLayout();
            ((ISupportInitialize)(this.grlCheckT.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvCheckT)).BeginInit();
            ((ISupportInitialize)(this.grlPaymentT.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvPaymentT)).BeginInit();
            ((ISupportInitialize)(this.grlReceiptT.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvReceiptT)).BeginInit();
            this.pagScheme.SuspendLayout();
            ((ISupportInitialize)(this.grlCheckS.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvCheckS)).BeginInit();
            ((ISupportInitialize)(this.grlPaymentS.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvPaymentS)).BeginInit();
            ((ISupportInitialize)(this.grlReceiptS.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvReceiptS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Size = new Size(370, 175);
            this.panel.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(290, 199);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(200, 199);
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
            // tabSetting
            // 
            this.tabSetting.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.tabSetting.Location = new Point(7, 7);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedTabPage = this.pagGeneral;
            this.tabSetting.Size = new Size(374, 179);
            this.tabSetting.TabIndex = 0;
            this.tabSetting.TabPages.AddRange(new XtraTabPage[] {
            this.pagGeneral,
            this.pagTemplet,
            this.pagScheme});
            // 
            // pagGeneral
            // 
            this.pagGeneral.Controls.Add(this.grlCheckWF);
            this.pagGeneral.Controls.Add(this.labCheckWF);
            this.pagGeneral.Controls.Add(this.cmbWipeLevel);
            this.pagGeneral.Controls.Add(this.cmbWipeType);
            this.pagGeneral.Controls.Add(this.labDefault);
            this.pagGeneral.Controls.Add(this.labSecrecy);
            this.pagGeneral.Controls.Add(this.labWipe);
            this.pagGeneral.Controls.Add(this.lokDefault);
            this.pagGeneral.Controls.Add(this.lokSecrecy);
            this.pagGeneral.Name = "pagGeneral";
            this.pagGeneral.Size = new Size(368, 150);
            this.pagGeneral.Text = "一般选项";
            // 
            // grlCheckWF
            // 
            this.grlCheckWF.Location = new Point(80, 110);
            this.grlCheckWF.Name = "grlCheckWF";
            this.grlCheckWF.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlCheckWF.Properties.NullText = "请选择结账流程…";
            this.grlCheckWF.Properties.PopupFormSize = new Size(275, 120);
            this.grlCheckWF.Properties.View = this.gdvCheckWF;
            this.grlCheckWF.Size = new Size(275, 20);
            this.grlCheckWF.TabIndex = 5;
            // 
            // gdvCheckWF
            // 
            this.gdvCheckWF.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvCheckWF.Name = "gdvCheckWF";
            this.gdvCheckWF.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvCheckWF.OptionsView.ShowColumnHeaders = false;
            this.gdvCheckWF.OptionsView.ShowGroupPanel = false;
            // 
            // labCheckWF
            // 
            this.labCheckWF.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCheckWF.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCheckWF.Location = new Point(0, 110);
            this.labCheckWF.Name = "labCheckWF";
            this.labCheckWF.Size = new Size(80, 21);
            this.labCheckWF.TabIndex = 0;
            this.labCheckWF.Text = "结账流程：";
            // 
            // cmbWipeLevel
            // 
            this.cmbWipeLevel.Location = new Point(80, 20);
            this.cmbWipeLevel.Name = "cmbWipeLevel";
            this.cmbWipeLevel.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.cmbWipeLevel.Properties.Items.AddRange(new object[] {
            "不抹",
            "抹分",
            "抹角",
            "抹元"});
            this.cmbWipeLevel.Size = new Size(50, 20);
            this.cmbWipeLevel.TabIndex = 1;
            this.cmbWipeLevel.SelectedIndexChanged += new EventHandler(this.cmbWipeLevel_SelectedIndexChanged);
            // 
            // cmbWipeType
            // 
            this.cmbWipeType.Location = new Point(135, 20);
            this.cmbWipeType.Name = "cmbWipeType";
            this.cmbWipeType.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.cmbWipeType.Properties.Items.AddRange(new object[] {
            "舍去零头",
            "四舍五入",
            "补齐零头"});
            this.cmbWipeType.Size = new Size(75, 20);
            this.cmbWipeType.TabIndex = 2;
            // 
            // labDefault
            // 
            this.labDefault.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labDefault.AutoSizeMode = LabelAutoSizeMode.None;
            this.labDefault.Location = new Point(0, 80);
            this.labDefault.Name = "labDefault";
            this.labDefault.Size = new Size(80, 21);
            this.labDefault.TabIndex = 0;
            this.labDefault.Text = "结算方式：";
            // 
            // labSecrecy
            // 
            this.labSecrecy.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labSecrecy.AutoSizeMode = LabelAutoSizeMode.None;
            this.labSecrecy.Location = new Point(0, 50);
            this.labSecrecy.Name = "labSecrecy";
            this.labSecrecy.Size = new Size(80, 21);
            this.labSecrecy.TabIndex = 0;
            this.labSecrecy.Text = "涉密等级：";
            // 
            // labWipe
            // 
            this.labWipe.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labWipe.AutoSizeMode = LabelAutoSizeMode.None;
            this.labWipe.Location = new Point(0, 20);
            this.labWipe.Name = "labWipe";
            this.labWipe.Size = new Size(80, 21);
            this.labWipe.TabIndex = 0;
            this.labWipe.Text = "抹零方式：";
            // 
            // lokDefault
            // 
            this.lokDefault.Location = new Point(80, 80);
            this.lokDefault.Name = "lokDefault";
            this.lokDefault.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokDefault.Properties.NullText = "请选择…";
            this.lokDefault.Properties.PopupFormMinSize = new Size(50, 120);
            this.lokDefault.Properties.PopupWidth = 55;
            this.lokDefault.Properties.ShowFooter = false;
            this.lokDefault.Properties.ShowHeader = false;
            this.lokDefault.Size = new Size(130, 20);
            this.lokDefault.TabIndex = 4;
            // 
            // lokSecrecy
            // 
            this.lokSecrecy.Location = new Point(80, 50);
            this.lokSecrecy.Name = "lokSecrecy";
            this.lokSecrecy.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokSecrecy.Properties.NullText = "请选择…";
            this.lokSecrecy.Properties.PopupFormMinSize = new Size(50, 120);
            this.lokSecrecy.Properties.PopupWidth = 55;
            this.lokSecrecy.Properties.ShowFooter = false;
            this.lokSecrecy.Properties.ShowHeader = false;
            this.lokSecrecy.Size = new Size(130, 20);
            this.lokSecrecy.TabIndex = 3;
            // 
            // pagTemplet
            // 
            this.pagTemplet.Controls.Add(this.grlCheckT);
            this.pagTemplet.Controls.Add(this.labCheckT);
            this.pagTemplet.Controls.Add(this.grlPaymentT);
            this.pagTemplet.Controls.Add(this.labPaymentT);
            this.pagTemplet.Controls.Add(this.grlReceiptT);
            this.pagTemplet.Controls.Add(this.labReceiptT);
            this.pagTemplet.Name = "pagTemplet";
            this.pagTemplet.Size = new Size(368, 150);
            this.pagTemplet.Text = "打印模板";
            // 
            // grlCheckT
            // 
            this.grlCheckT.Location = new Point(80, 100);
            this.grlCheckT.Name = "grlCheckT";
            this.grlCheckT.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlCheckT.Properties.NullText = "请选择结账单打印模板…";
            this.grlCheckT.Properties.PopupFormSize = new Size(275, 120);
            this.grlCheckT.Properties.View = this.gdvCheckT;
            this.grlCheckT.Size = new Size(275, 20);
            this.grlCheckT.TabIndex = 1;
            // 
            // gdvCheckT
            // 
            this.gdvCheckT.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvCheckT.Name = "gdvCheckT";
            this.gdvCheckT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvCheckT.OptionsView.ShowColumnHeaders = false;
            this.gdvCheckT.OptionsView.ShowGroupPanel = false;
            // 
            // labCheckT
            // 
            this.labCheckT.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCheckT.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCheckT.Location = new Point(0, 100);
            this.labCheckT.Name = "labCheckT";
            this.labCheckT.Size = new Size(80, 21);
            this.labCheckT.TabIndex = 0;
            this.labCheckT.Text = "结账单：";
            // 
            // grlPaymentT
            // 
            this.grlPaymentT.Location = new Point(80, 65);
            this.grlPaymentT.Name = "grlPaymentT";
            this.grlPaymentT.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlPaymentT.Properties.NullText = "请选择付款单打印模板…";
            this.grlPaymentT.Properties.PopupFormSize = new Size(275, 120);
            this.grlPaymentT.Properties.View = this.gdvPaymentT;
            this.grlPaymentT.Size = new Size(275, 20);
            this.grlPaymentT.TabIndex = 2;
            // 
            // gdvPaymentT
            // 
            this.gdvPaymentT.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvPaymentT.Name = "gdvPaymentT";
            this.gdvPaymentT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvPaymentT.OptionsView.ShowColumnHeaders = false;
            this.gdvPaymentT.OptionsView.ShowGroupPanel = false;
            // 
            // labPaymentT
            // 
            this.labPaymentT.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labPaymentT.AutoSizeMode = LabelAutoSizeMode.None;
            this.labPaymentT.Location = new Point(0, 65);
            this.labPaymentT.Name = "labPaymentT";
            this.labPaymentT.Size = new Size(80, 21);
            this.labPaymentT.TabIndex = 0;
            this.labPaymentT.Text = "付款单：";
            // 
            // grlReceiptT
            // 
            this.grlReceiptT.Location = new Point(80, 30);
            this.grlReceiptT.Name = "grlReceiptT";
            this.grlReceiptT.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlReceiptT.Properties.NullText = "请选择收据打印模板…";
            this.grlReceiptT.Properties.PopupFormSize = new Size(275, 120);
            this.grlReceiptT.Properties.View = this.gdvReceiptT;
            this.grlReceiptT.Size = new Size(275, 20);
            this.grlReceiptT.TabIndex = 1;
            // 
            // gdvReceiptT
            // 
            this.gdvReceiptT.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvReceiptT.Name = "gdvReceiptT";
            this.gdvReceiptT.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvReceiptT.OptionsView.ShowColumnHeaders = false;
            this.gdvReceiptT.OptionsView.ShowGroupPanel = false;
            // 
            // labReceiptT
            // 
            this.labReceiptT.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labReceiptT.AutoSizeMode = LabelAutoSizeMode.None;
            this.labReceiptT.Location = new Point(0, 30);
            this.labReceiptT.Name = "labReceiptT";
            this.labReceiptT.Size = new Size(80, 21);
            this.labReceiptT.TabIndex = 0;
            this.labReceiptT.Text = "收据：";
            // 
            // pagScheme
            // 
            this.pagScheme.Controls.Add(this.labCheckS);
            this.pagScheme.Controls.Add(this.labPaymentS);
            this.pagScheme.Controls.Add(this.labReceiptS);
            this.pagScheme.Controls.Add(this.grlCheckS);
            this.pagScheme.Controls.Add(this.grlPaymentS);
            this.pagScheme.Controls.Add(this.grlReceiptS);
            this.pagScheme.Name = "pagScheme";
            this.pagScheme.Size = new Size(368, 150);
            this.pagScheme.Text = "编码方案";
            // 
            // labCheckS
            // 
            this.labCheckS.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCheckS.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCheckS.Location = new Point(0, 100);
            this.labCheckS.Name = "labCheckS";
            this.labCheckS.Size = new Size(80, 21);
            this.labCheckS.TabIndex = 9;
            this.labCheckS.Text = "结账单：";
            // 
            // labPaymentS
            // 
            this.labPaymentS.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labPaymentS.AutoSizeMode = LabelAutoSizeMode.None;
            this.labPaymentS.Location = new Point(0, 65);
            this.labPaymentS.Name = "labPaymentS";
            this.labPaymentS.Size = new Size(80, 21);
            this.labPaymentS.TabIndex = 10;
            this.labPaymentS.Text = "付款单：";
            // 
            // labReceiptS
            // 
            this.labReceiptS.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labReceiptS.AutoSizeMode = LabelAutoSizeMode.None;
            this.labReceiptS.Location = new Point(0, 30);
            this.labReceiptS.Name = "labReceiptS";
            this.labReceiptS.Size = new Size(80, 21);
            this.labReceiptS.TabIndex = 11;
            this.labReceiptS.Text = "收据：";
            // 
            // grlCheckS
            // 
            this.grlCheckS.Location = new Point(80, 100);
            this.grlCheckS.Name = "grlCheckS";
            this.grlCheckS.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlCheckS.Properties.NullText = "请选择结账单编码方案…";
            this.grlCheckS.Properties.PopupFormSize = new Size(275, 120);
            this.grlCheckS.Properties.View = this.gdvCheckS;
            this.grlCheckS.Size = new Size(275, 20);
            this.grlCheckS.TabIndex = 3;
            // 
            // gdvCheckS
            // 
            this.gdvCheckS.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvCheckS.Name = "gdvCheckS";
            this.gdvCheckS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvCheckS.OptionsView.ShowColumnHeaders = false;
            this.gdvCheckS.OptionsView.ShowGroupPanel = false;
            // 
            // grlPaymentS
            // 
            this.grlPaymentS.Location = new Point(80, 65);
            this.grlPaymentS.Name = "grlPaymentS";
            this.grlPaymentS.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlPaymentS.Properties.NullText = "请选择付款单编码方案…";
            this.grlPaymentS.Properties.PopupFormSize = new Size(275, 120);
            this.grlPaymentS.Properties.View = this.gdvPaymentS;
            this.grlPaymentS.Size = new Size(275, 20);
            this.grlPaymentS.TabIndex = 2;
            // 
            // gdvPaymentS
            // 
            this.gdvPaymentS.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvPaymentS.Name = "gdvPaymentS";
            this.gdvPaymentS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvPaymentS.OptionsView.ShowColumnHeaders = false;
            this.gdvPaymentS.OptionsView.ShowGroupPanel = false;
            // 
            // grlReceiptS
            // 
            this.grlReceiptS.Location = new Point(80, 30);
            this.grlReceiptS.Name = "grlReceiptS";
            this.grlReceiptS.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlReceiptS.Properties.NullText = "请选择收据编码方案…";
            this.grlReceiptS.Properties.PopupFormSize = new Size(275, 120);
            this.grlReceiptS.Properties.View = this.gdvReceiptS;
            this.grlReceiptS.Size = new Size(275, 20);
            this.grlReceiptS.TabIndex = 1;
            // 
            // gdvReceiptS
            // 
            this.gdvReceiptS.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvReceiptS.Name = "gdvReceiptS";
            this.gdvReceiptS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvReceiptS.OptionsView.ShowColumnHeaders = false;
            this.gdvReceiptS.OptionsView.ShowGroupPanel = false;
            // 
            // Setting
            // 
            this.ClientSize = new Size(384, 237);
            this.Controls.Add(this.tabSetting);
            this.Name = "Setting";
            this.Text = "设置";
            this.Load += new EventHandler(this.Setting_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.tabSetting, 0);
            ((ISupportInitialize)(this.panel)).EndInit();
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.tabSetting)).EndInit();
            this.tabSetting.ResumeLayout(false);
            this.pagGeneral.ResumeLayout(false);
            ((ISupportInitialize)(this.grlCheckWF.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvCheckWF)).EndInit();
            ((ISupportInitialize)(this.cmbWipeLevel.Properties)).EndInit();
            ((ISupportInitialize)(this.cmbWipeType.Properties)).EndInit();
            ((ISupportInitialize)(this.lokDefault.Properties)).EndInit();
            ((ISupportInitialize)(this.lokSecrecy.Properties)).EndInit();
            this.pagTemplet.ResumeLayout(false);
            ((ISupportInitialize)(this.grlCheckT.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvCheckT)).EndInit();
            ((ISupportInitialize)(this.grlPaymentT.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvPaymentT)).EndInit();
            ((ISupportInitialize)(this.grlReceiptT.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvReceiptT)).EndInit();
            this.pagScheme.ResumeLayout(false);
            ((ISupportInitialize)(this.grlCheckS.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvCheckS)).EndInit();
            ((ISupportInitialize)(this.grlPaymentS.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvPaymentS)).EndInit();
            ((ISupportInitialize)(this.grlReceiptS.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvReceiptS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraTabControl tabSetting;
        private XtraTabPage pagGeneral;
        private ComboBoxEdit cmbWipeLevel;
        private ComboBoxEdit cmbWipeType;
        private LabelControl labDefault;
        private LabelControl labSecrecy;
        private LabelControl labWipe;
        private LookUpEdit lokDefault;
        private LookUpEdit lokSecrecy;
        private XtraTabPage pagTemplet;
        private GridLookUpEdit grlReceiptT;
        private GridView gdvReceiptT;
        private LabelControl labReceiptT;
        private XtraTabPage pagScheme;
        private GridLookUpEdit grlReceiptS;
        private GridView gdvReceiptS;
        private GridLookUpEdit grlCheckWF;
        private GridView gdvCheckWF;
        private LabelControl labCheckWF;
        private GridLookUpEdit grlCheckT;
        private GridView gdvCheckT;
        private LabelControl labCheckT;
        private GridLookUpEdit grlPaymentT;
        private GridView gdvPaymentT;
        private LabelControl labPaymentT;
        private LabelControl labCheckS;
        private LabelControl labPaymentS;
        private LabelControl labReceiptS;
        private GridLookUpEdit grlCheckS;
        private GridView gdvCheckS;
        private GridLookUpEdit grlPaymentS;
        private GridView gdvPaymentS;

    }
}
