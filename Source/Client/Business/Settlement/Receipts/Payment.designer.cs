using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using CellValueChangedEventHandler = DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler;

namespace Insight.WS.Client.Business.Settlement
{
    partial class Payment
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
            var resources = new ComponentResourceManager(typeof(Payment));
            var serializableAppearanceObject2 = new SerializableAppearanceObject();
            this.grdItem = new GridControl();
            this.gdvItem = new GridView();
            this.grdPay = new GridControl();
            this.gdvPay = new GridView();
            this.calPayAmount = new RepositoryItemCalcEdit();
            this.lokPay = new RepositoryItemLookUpEdit();
            this.labCustomer = new LabelControl();
            this.sleCustomer = new SearchLookUpEdit();
            this.gdvCustomer = new GridView();
            this.txtName = new TextEdit();
            this.memDesc = new MemoEdit();
            this.labPay = new LabelControl();
            this.labitem = new LabelControl();
            this.btnAdd = new SimpleButton();
            this.btnEdit = new SimpleButton();
            this.labExpense = new LabelControl();
            this.palItem = new PanelControl();
            this.trlUnit = new TreeListLookUpEdit();
            this.treUnit = new TreeList();
            this.btnClose = new SimpleButton();
            this.btnItem = new SimpleButton();
            this.memSummary = new MemoEdit();
            this.calAmount = new CalcEdit();
            this.txtCount = new TextEdit();
            this.txtExpense = new TextEdit();
            this.txtPrice = new TextEdit();
            this.trlExpense = new TreeListLookUpEdit();
            this.treExpense = new TreeList();
            this.labAmount = new LabelControl();
            this.labSummary = new LabelControl();
            this.labCount = new LabelControl();
            this.labPrice = new LabelControl();
            this.labUnit = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.labApplyCode = new LabelControl();
            this.txtApplyCode = new TextEdit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.grdItem)).BeginInit();
            ((ISupportInitialize)(this.gdvItem)).BeginInit();
            ((ISupportInitialize)(this.grdPay)).BeginInit();
            ((ISupportInitialize)(this.gdvPay)).BeginInit();
            ((ISupportInitialize)(this.calPayAmount)).BeginInit();
            ((ISupportInitialize)(this.lokPay)).BeginInit();
            ((ISupportInitialize)(this.sleCustomer.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvCustomer)).BeginInit();
            ((ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((ISupportInitialize)(this.memDesc.Properties)).BeginInit();
            ((ISupportInitialize)(this.palItem)).BeginInit();
            this.palItem.SuspendLayout();
            ((ISupportInitialize)(this.trlUnit.Properties)).BeginInit();
            ((ISupportInitialize)(this.treUnit)).BeginInit();
            ((ISupportInitialize)(this.memSummary.Properties)).BeginInit();
            ((ISupportInitialize)(this.calAmount.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtCount.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtExpense.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((ISupportInitialize)(this.trlExpense.Properties)).BeginInit();
            ((ISupportInitialize)(this.treExpense)).BeginInit();
            ((ISupportInitialize)(this.txtApplyCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txtApplyCode);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.sleCustomer);
            this.panel.Controls.Add(this.labApplyCode);
            this.panel.Controls.Add(this.labCustomer);
            this.panel.Size = new Size(770, 50);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(690, 524);
            this.btnConfirm.Text = "付  款";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(600, 524);
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
            // grdItem
            // 
            this.grdItem.Location = new Point(7, 85);
            this.grdItem.MainView = this.gdvItem;
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new Size(770, 276);
            this.grdItem.TabIndex = 6;
            this.grdItem.ViewCollection.AddRange(new BaseView[] {
            this.gdvItem});
            // 
            // gdvItem
            // 
            this.gdvItem.GridControl = this.grdItem;
            this.gdvItem.Name = "gdvItem";
            this.gdvItem.OptionsMenu.EnableFooterMenu = false;
            this.gdvItem.OptionsSelection.CheckBoxSelectorColumnWidth = 32;
            this.gdvItem.OptionsSelection.MultiSelect = true;
            this.gdvItem.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            this.gdvItem.OptionsView.ShowFooter = true;
            this.gdvItem.SelectionChanged += new SelectionChangedEventHandler(this.gdvItem_SelectionChanged);
            this.gdvItem.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvItem_FocusedRowObjectChanged);
            this.gdvItem.DoubleClick += new EventHandler(this.gdvItem_DoubleClick);
            // 
            // grdPay
            // 
            this.grdPay.Location = new Point(287, 387);
            this.grdPay.MainView = this.gdvPay;
            this.grdPay.Name = "grdPay";
            this.grdPay.RepositoryItems.AddRange(new RepositoryItem[] {
            this.calPayAmount,
            this.lokPay});
            this.grdPay.Size = new Size(490, 120);
            this.grdPay.TabIndex = 20;
            this.grdPay.ViewCollection.AddRange(new BaseView[] {
            this.gdvPay});
            // 
            // gdvPay
            // 
            this.gdvPay.GridControl = this.grdPay;
            this.gdvPay.Name = "gdvPay";
            this.gdvPay.CellValueChanged += new CellValueChangedEventHandler(this.gdvPay_CellValueChanged);
            this.gdvPay.RowCountChanged += new EventHandler(this.gdvPay_RowCountChanged);
            // 
            // calPayAmount
            // 
            this.calPayAmount.AutoHeight = false;
            this.calPayAmount.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.calPayAmount.Name = "calPayAmount";
            // 
            // lokPay
            // 
            this.lokPay.AutoHeight = false;
            this.lokPay.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokPay.Name = "lokPay";
            // 
            // labCustomer
            // 
            this.labCustomer.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCustomer.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCustomer.Location = new Point(0, 15);
            this.labCustomer.Name = "labCustomer";
            this.labCustomer.Size = new Size(60, 21);
            this.labCustomer.TabIndex = 0;
            this.labCustomer.Text = "收款人：";
            // 
            // sleCustomer
            // 
            this.sleCustomer.EnterMoveNextControl = true;
            this.sleCustomer.Location = new Point(60, 15);
            this.sleCustomer.Name = "sleCustomer";
            this.sleCustomer.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.sleCustomer.Properties.NullText = "请选择收款人…";
            this.sleCustomer.Properties.PopupFormSize = new Size(240, 240);
            this.sleCustomer.Properties.ShowClearButton = false;
            this.sleCustomer.Properties.ShowFooter = false;
            this.sleCustomer.Properties.View = this.gdvCustomer;
            this.sleCustomer.Size = new Size(240, 20);
            this.sleCustomer.TabIndex = 1;
            this.sleCustomer.EditValueChanged += new EventHandler(this.sleCustomer_EditValueChanged);
            // 
            // gdvCustomer
            // 
            this.gdvCustomer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gdvCustomer.Name = "gdvCustomer";
            this.gdvCustomer.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvCustomer.OptionsView.ShowColumnHeaders = false;
            this.gdvCustomer.OptionsView.ShowGroupPanel = false;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new Point(305, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(240, 20);
            this.txtName.TabIndex = 2;
            this.txtName.EditValueChanged += new EventHandler(this.txtName_EditValueChanged);
            // 
            // memDesc
            // 
            this.memDesc.EnterMoveNextControl = true;
            this.memDesc.Location = new Point(7, 387);
            this.memDesc.Name = "memDesc";
            this.memDesc.Properties.BorderStyle = BorderStyles.Office2003;
            this.memDesc.Size = new Size(273, 120);
            this.memDesc.TabIndex = 7;
            this.memDesc.UseOptimizedRendering = true;
            // 
            // labPay
            // 
            this.labPay.AutoSizeMode = LabelAutoSizeMode.None;
            this.labPay.Location = new Point(10, 367);
            this.labPay.Name = "labPay";
            this.labPay.Size = new Size(60, 20);
            this.labPay.TabIndex = 0;
            this.labPay.Text = "备注：";
            // 
            // labitem
            // 
            this.labitem.AutoSizeMode = LabelAutoSizeMode.None;
            this.labitem.Location = new Point(10, 63);
            this.labitem.Name = "labitem";
            this.labitem.Size = new Size(60, 20);
            this.labitem.TabIndex = 0;
            this.labitem.Text = "款项明细：";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = ((Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new Point(723, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(24, 22);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.ToolTip = "新增项目";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new Point(753, 60);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(24, 22);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.ToolTip = "编辑项目";
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            // 
            // labExpense
            // 
            this.labExpense.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labExpense.AutoSizeMode = LabelAutoSizeMode.None;
            this.labExpense.Location = new Point(0, 15);
            this.labExpense.Name = "labExpense";
            this.labExpense.Size = new Size(60, 21);
            this.labExpense.TabIndex = 0;
            this.labExpense.Text = "项目：";
            // 
            // palItem
            // 
            this.palItem.Controls.Add(this.trlUnit);
            this.palItem.Controls.Add(this.btnClose);
            this.palItem.Controls.Add(this.btnItem);
            this.palItem.Controls.Add(this.memSummary);
            this.palItem.Controls.Add(this.calAmount);
            this.palItem.Controls.Add(this.txtCount);
            this.palItem.Controls.Add(this.txtExpense);
            this.palItem.Controls.Add(this.txtPrice);
            this.palItem.Controls.Add(this.trlExpense);
            this.palItem.Controls.Add(this.labAmount);
            this.palItem.Controls.Add(this.labSummary);
            this.palItem.Controls.Add(this.labCount);
            this.palItem.Controls.Add(this.labPrice);
            this.palItem.Controls.Add(this.labUnit);
            this.palItem.Controls.Add(this.labExpense);
            this.palItem.Location = new Point(220, 110);
            this.palItem.Name = "palItem";
            this.palItem.Size = new Size(360, 218);
            this.palItem.TabIndex = 0;
            this.palItem.Visible = false;
            // 
            // trlUnit
            // 
            this.trlUnit.Enabled = false;
            this.trlUnit.EnterMoveNextControl = true;
            this.trlUnit.Location = new Point(60, 50);
            this.trlUnit.Name = "trlUnit";
            this.trlUnit.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.trlUnit.Properties.NullText = "";
            this.trlUnit.Properties.PopupFormSize = new Size(140, 160);
            this.trlUnit.Properties.TreeList = this.treUnit;
            this.trlUnit.Size = new Size(100, 20);
            this.trlUnit.TabIndex = 11;
            this.trlUnit.EditValueChanged += new EventHandler(this.trlUnit_EditValueChanged);
            // 
            // treUnit
            // 
            this.treUnit.Location = new Point(-20, 9);
            this.treUnit.Name = "treUnit";
            this.treUnit.OptionsBehavior.EnableFiltering = true;
            this.treUnit.OptionsView.ShowIndentAsRowStyle = true;
            this.treUnit.SelectImageList = this.imgCategoryNode;
            this.treUnit.Size = new Size(215, 200);
            this.treUnit.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new Point(185, 180);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // btnItem
            // 
            this.btnItem.Enabled = false;
            this.btnItem.Location = new Point(270, 180);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new Size(75, 23);
            this.btnItem.TabIndex = 16;
            this.btnItem.Text = "添加项目";
            this.btnItem.Click += new EventHandler(this.btnItem_Click);
            // 
            // memSummary
            // 
            this.memSummary.Enabled = false;
            this.memSummary.EnterMoveNextControl = true;
            this.memSummary.Location = new Point(60, 115);
            this.memSummary.Name = "memSummary";
            this.memSummary.Size = new Size(285, 50);
            this.memSummary.TabIndex = 15;
            this.memSummary.UseOptimizedRendering = true;
            // 
            // calAmount
            // 
            this.calAmount.Enabled = false;
            this.calAmount.EnterMoveNextControl = true;
            this.calAmount.Location = new Point(220, 80);
            this.calAmount.Name = "calAmount";
            this.calAmount.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.calAmount.Properties.DisplayFormat.FormatString = "n";
            this.calAmount.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.calAmount.Properties.Mask.EditMask = "n";
            this.calAmount.Size = new Size(125, 20);
            this.calAmount.TabIndex = 14;
            this.calAmount.EditValueChanged += new EventHandler(this.calAmount_EditValueChanged);
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.EnterMoveNextControl = true;
            this.txtCount.Location = new Point(60, 80);
            this.txtCount.Name = "txtCount";
            this.txtCount.Properties.DisplayFormat.FormatString = "#,##0.######";
            this.txtCount.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtCount.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtCount.Size = new Size(100, 20);
            this.txtCount.TabIndex = 13;
            this.txtCount.EditValueChanged += new EventHandler(this.txtCount_EditValueChanged);
            // 
            // txtExpense
            // 
            this.txtExpense.Enabled = false;
            this.txtExpense.EnterMoveNextControl = true;
            this.txtExpense.Location = new Point(60, 15);
            this.txtExpense.Name = "txtExpense";
            this.txtExpense.Properties.AutoHeight = false;
            this.txtExpense.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtExpense.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtExpense.Size = new Size(285, 22);
            this.txtExpense.TabIndex = 10;
            this.txtExpense.Visible = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.EnterMoveNextControl = true;
            this.txtPrice.Location = new Point(220, 50);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtPrice.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtPrice.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtPrice.Size = new Size(125, 20);
            this.txtPrice.TabIndex = 12;
            this.txtPrice.EditValueChanged += new EventHandler(this.txtPrice_EditValueChanged);
            // 
            // trlExpense
            // 
            this.trlExpense.EnterMoveNextControl = true;
            this.trlExpense.Location = new Point(60, 15);
            this.trlExpense.Name = "trlExpense";
            this.trlExpense.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("trlExpense.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.trlExpense.Properties.NullText = "请选择收款项目…";
            this.trlExpense.Properties.PopupFormSize = new Size(285, 160);
            this.trlExpense.Properties.ShowFooter = false;
            this.trlExpense.Properties.TreeList = this.treExpense;
            this.trlExpense.Size = new Size(285, 22);
            this.trlExpense.TabIndex = 10;
            this.trlExpense.EditValueChanged += new EventHandler(this.trlExpense_EditValueChanged);
            // 
            // treExpense
            // 
            this.treExpense.Location = new Point(0, 0);
            this.treExpense.Name = "treExpense";
            this.treExpense.OptionsBehavior.EnableFiltering = true;
            this.treExpense.OptionsView.ShowIndentAsRowStyle = true;
            this.treExpense.SelectImageList = this.imgCategoryNode;
            this.treExpense.Size = new Size(400, 200);
            this.treExpense.TabIndex = 0;
            // 
            // labAmount
            // 
            this.labAmount.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labAmount.AutoSizeMode = LabelAutoSizeMode.None;
            this.labAmount.Location = new Point(160, 80);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new Size(60, 21);
            this.labAmount.TabIndex = 0;
            this.labAmount.Text = "金额：";
            // 
            // labSummary
            // 
            this.labSummary.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labSummary.AutoSizeMode = LabelAutoSizeMode.None;
            this.labSummary.Location = new Point(0, 115);
            this.labSummary.Name = "labSummary";
            this.labSummary.Size = new Size(60, 21);
            this.labSummary.TabIndex = 0;
            this.labSummary.Text = "摘要：";
            // 
            // labCount
            // 
            this.labCount.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCount.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCount.Location = new Point(0, 80);
            this.labCount.Name = "labCount";
            this.labCount.Size = new Size(60, 21);
            this.labCount.TabIndex = 0;
            this.labCount.Text = "数量：";
            // 
            // labPrice
            // 
            this.labPrice.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labPrice.AutoSizeMode = LabelAutoSizeMode.None;
            this.labPrice.Location = new Point(160, 50);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new Size(60, 21);
            this.labPrice.TabIndex = 0;
            this.labPrice.Text = "单价：";
            // 
            // labUnit
            // 
            this.labUnit.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labUnit.AutoSizeMode = LabelAutoSizeMode.None;
            this.labUnit.Location = new Point(0, 50);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new Size(60, 21);
            this.labUnit.TabIndex = 0;
            this.labUnit.Text = "单位：";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl1.Location = new Point(290, 367);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "结算方式：";
            // 
            // labApplyCode
            // 
            this.labApplyCode.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labApplyCode.AutoSizeMode = LabelAutoSizeMode.None;
            this.labApplyCode.Location = new Point(545, 15);
            this.labApplyCode.Name = "labApplyCode";
            this.labApplyCode.Size = new Size(60, 21);
            this.labApplyCode.TabIndex = 0;
            this.labApplyCode.Text = "单号：";
            // 
            // txtApplyCode
            // 
            this.txtApplyCode.EnterMoveNextControl = true;
            this.txtApplyCode.Location = new Point(605, 15);
            this.txtApplyCode.Name = "txtApplyCode";
            this.txtApplyCode.Size = new Size(150, 20);
            this.txtApplyCode.TabIndex = 3;
            this.txtApplyCode.EditValueChanged += new EventHandler(this.txtName_EditValueChanged);
            // 
            // Payment
            // 
            this.AcceptButton = this.btnItem;
            this.ClientSize = new Size(784, 562);
            this.Controls.Add(this.memDesc);
            this.Controls.Add(this.palItem);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labitem);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labPay);
            this.Controls.Add(this.grdPay);
            this.Controls.Add(this.grdItem);
            this.Name = "Payment";
            this.Text = "付款";
            this.Load += new EventHandler(this.Cashier_Load);
            this.Controls.SetChildIndex(this.grdItem, 0);
            this.Controls.SetChildIndex(this.grdPay, 0);
            this.Controls.SetChildIndex(this.labPay, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labitem, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.palItem, 0);
            this.Controls.SetChildIndex(this.memDesc, 0);
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.grdItem)).EndInit();
            ((ISupportInitialize)(this.gdvItem)).EndInit();
            ((ISupportInitialize)(this.grdPay)).EndInit();
            ((ISupportInitialize)(this.gdvPay)).EndInit();
            ((ISupportInitialize)(this.calPayAmount)).EndInit();
            ((ISupportInitialize)(this.lokPay)).EndInit();
            ((ISupportInitialize)(this.sleCustomer.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvCustomer)).EndInit();
            ((ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((ISupportInitialize)(this.memDesc.Properties)).EndInit();
            ((ISupportInitialize)(this.palItem)).EndInit();
            this.palItem.ResumeLayout(false);
            ((ISupportInitialize)(this.trlUnit.Properties)).EndInit();
            ((ISupportInitialize)(this.treUnit)).EndInit();
            ((ISupportInitialize)(this.memSummary.Properties)).EndInit();
            ((ISupportInitialize)(this.calAmount.Properties)).EndInit();
            ((ISupportInitialize)(this.txtCount.Properties)).EndInit();
            ((ISupportInitialize)(this.txtExpense.Properties)).EndInit();
            ((ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((ISupportInitialize)(this.trlExpense.Properties)).EndInit();
            ((ISupportInitialize)(this.treExpense)).EndInit();
            ((ISupportInitialize)(this.txtApplyCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl grdItem;
        private GridView gdvItem;
        private GridControl grdPay;
        private GridView gdvPay;
        private SearchLookUpEdit sleCustomer;
        private GridView gdvCustomer;
        private LabelControl labCustomer;
        private MemoEdit memDesc;
        private TextEdit txtName;
        private LabelControl labPay;
        private LabelControl labitem;
        private SimpleButton btnAdd;
        private SimpleButton btnEdit;
        private LabelControl labExpense;
        private PanelControl palItem;
        private CalcEdit calAmount;
        private TextEdit txtCount;
        private TextEdit txtPrice;
        private TreeListLookUpEdit trlExpense;
        private TreeList treExpense;
        private LabelControl labAmount;
        private LabelControl labCount;
        private LabelControl labPrice;
        private LabelControl labUnit;
        private MemoEdit memSummary;
        private LabelControl labSummary;
        private SimpleButton btnClose;
        private SimpleButton btnItem;
        private TreeListLookUpEdit trlUnit;
        private TreeList treUnit;
        private LabelControl labelControl1;
        private RepositoryItemCalcEdit calPayAmount;
        private RepositoryItemLookUpEdit lokPay;
        private TextEdit txtExpense;
        private TextEdit txtApplyCode;
        private LabelControl labApplyCode;
    }
}
