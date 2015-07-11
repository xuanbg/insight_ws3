namespace Insight.WS.Client.Business.Settlement
{
    partial class Entry
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Entry));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdItem = new DevExpress.XtraGrid.GridControl();
            this.gdvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labCustomer = new DevExpress.XtraEditors.LabelControl();
            this.sleCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gdvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.memDesc = new DevExpress.XtraEditors.MemoEdit();
            this.labDesc = new DevExpress.XtraEditors.LabelControl();
            this.labitem = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.labExpense = new DevExpress.XtraEditors.LabelControl();
            this.palItem = new DevExpress.XtraEditors.PanelControl();
            this.calAmount = new DevExpress.XtraEditors.CalcEdit();
            this.labAmount = new DevExpress.XtraEditors.LabelControl();
            this.trlUnit = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treUnit = new DevExpress.XtraTreeList.TreeList();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnItemAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sleMaterial = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gdvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.memSummary = new DevExpress.XtraEditors.MemoEdit();
            this.txtCodeBar = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labSummary = new DevExpress.XtraEditors.LabelControl();
            this.labCount = new DevExpress.XtraEditors.LabelControl();
            this.labPrice = new DevExpress.XtraEditors.LabelControl();
            this.labUnit = new DevExpress.XtraEditors.LabelControl();
            this.labCodeBar = new DevExpress.XtraEditors.LabelControl();
            this.txtCount = new DevExpress.XtraEditors.TextEdit();
            this.labApplyCode = new DevExpress.XtraEditors.LabelControl();
            this.txtApplyCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palItem)).BeginInit();
            this.palItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSummary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApplyCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(690, 524);
            this.btnConfirm.Text = "入  库";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(600, 524);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.memDesc);
            this.panel.Controls.Add(this.txtApplyCode);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.sleCustomer);
            this.panel.Controls.Add(this.labDesc);
            this.panel.Controls.Add(this.labApplyCode);
            this.panel.Controls.Add(this.labCustomer);
            this.panel.Size = new System.Drawing.Size(770, 100);
            // 
            // grdItem
            // 
            this.grdItem.Location = new System.Drawing.Point(7, 135);
            this.grdItem.MainView = this.gdvItem;
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(770, 372);
            this.grdItem.TabIndex = 7;
            this.grdItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvItem});
            // 
            // gdvItem
            // 
            this.gdvItem.GridControl = this.grdItem;
            this.gdvItem.Name = "gdvItem";
            this.gdvItem.OptionsMenu.EnableFooterMenu = false;
            this.gdvItem.OptionsSelection.CheckBoxSelectorColumnWidth = 32;
            this.gdvItem.OptionsSelection.MultiSelect = true;
            this.gdvItem.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gdvItem.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gdvItem_SelectionChanged);
            this.gdvItem.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvItem_FocusedRowObjectChanged);
            this.gdvItem.DoubleClick += new System.EventHandler(this.gdvItem_DoubleClick);
            // 
            // labCustomer
            // 
            this.labCustomer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCustomer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCustomer.Location = new System.Drawing.Point(0, 15);
            this.labCustomer.Name = "labCustomer";
            this.labCustomer.Size = new System.Drawing.Size(60, 21);
            this.labCustomer.TabIndex = 0;
            this.labCustomer.Text = "供应商：";
            // 
            // sleCustomer
            // 
            this.sleCustomer.EnterMoveNextControl = true;
            this.sleCustomer.Location = new System.Drawing.Point(60, 15);
            this.sleCustomer.Name = "sleCustomer";
            this.sleCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sleCustomer.Properties.NullText = "请选择供应商…";
            this.sleCustomer.Properties.PopupFormSize = new System.Drawing.Size(240, 240);
            this.sleCustomer.Properties.ShowClearButton = false;
            this.sleCustomer.Properties.ShowFooter = false;
            this.sleCustomer.Properties.View = this.gdvCustomer;
            this.sleCustomer.Size = new System.Drawing.Size(240, 20);
            this.sleCustomer.TabIndex = 1;
            this.sleCustomer.EditValueChanged += new System.EventHandler(this.sleCustomer_EditValueChanged);
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
            this.txtName.Location = new System.Drawing.Point(305, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 20);
            this.txtName.TabIndex = 2;
            this.txtName.EditValueChanged += new System.EventHandler(this.txtName_EditValueChanged);
            // 
            // memDesc
            // 
            this.memDesc.EnterMoveNextControl = true;
            this.memDesc.Location = new System.Drawing.Point(60, 45);
            this.memDesc.Name = "memDesc";
            this.memDesc.Size = new System.Drawing.Size(695, 40);
            this.memDesc.TabIndex = 4;
            this.memDesc.UseOptimizedRendering = true;
            // 
            // labDesc
            // 
            this.labDesc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDesc.Location = new System.Drawing.Point(0, 45);
            this.labDesc.Name = "labDesc";
            this.labDesc.Size = new System.Drawing.Size(60, 21);
            this.labDesc.TabIndex = 0;
            this.labDesc.Text = "备注：";
            // 
            // labitem
            // 
            this.labitem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labitem.Location = new System.Drawing.Point(10, 113);
            this.labitem.Name = "labitem";
            this.labitem.Size = new System.Drawing.Size(60, 20);
            this.labitem.TabIndex = 0;
            this.labitem.Text = "物资明细：";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(723, 110);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 22);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.ToolTip = "新增物资";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(753, 110);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 22);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.ToolTip = "编辑物资";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // labExpense
            // 
            this.labExpense.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labExpense.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labExpense.Location = new System.Drawing.Point(0, 50);
            this.labExpense.Name = "labExpense";
            this.labExpense.Size = new System.Drawing.Size(60, 21);
            this.labExpense.TabIndex = 0;
            this.labExpense.Text = "物资：";
            // 
            // palItem
            // 
            this.palItem.Controls.Add(this.calAmount);
            this.palItem.Controls.Add(this.labAmount);
            this.palItem.Controls.Add(this.trlUnit);
            this.palItem.Controls.Add(this.btnClose);
            this.palItem.Controls.Add(this.btnItemAdd);
            this.palItem.Controls.Add(this.sleMaterial);
            this.palItem.Controls.Add(this.memSummary);
            this.palItem.Controls.Add(this.txtCodeBar);
            this.palItem.Controls.Add(this.txtPrice);
            this.palItem.Controls.Add(this.labSummary);
            this.palItem.Controls.Add(this.labCount);
            this.palItem.Controls.Add(this.labPrice);
            this.palItem.Controls.Add(this.labUnit);
            this.palItem.Controls.Add(this.labCodeBar);
            this.palItem.Controls.Add(this.labExpense);
            this.palItem.Controls.Add(this.txtCount);
            this.palItem.Location = new System.Drawing.Point(220, 160);
            this.palItem.Name = "palItem";
            this.palItem.Size = new System.Drawing.Size(360, 248);
            this.palItem.TabIndex = 0;
            this.palItem.Visible = false;
            // 
            // calAmount
            // 
            this.calAmount.Enabled = false;
            this.calAmount.EnterMoveNextControl = true;
            this.calAmount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.calAmount.Location = new System.Drawing.Point(220, 110);
            this.calAmount.Name = "calAmount";
            this.calAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("calAmount.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.calAmount.Properties.DisplayFormat.FormatString = "n";
            this.calAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calAmount.Size = new System.Drawing.Size(125, 20);
            this.calAmount.TabIndex = 15;
            this.calAmount.EditValueChanged += new System.EventHandler(this.calAmount_EditValueChanged);
            // 
            // labAmount
            // 
            this.labAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labAmount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labAmount.Location = new System.Drawing.Point(160, 110);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new System.Drawing.Size(60, 21);
            this.labAmount.TabIndex = 0;
            this.labAmount.Text = "金额：";
            // 
            // trlUnit
            // 
            this.trlUnit.Enabled = false;
            this.trlUnit.EnterMoveNextControl = true;
            this.trlUnit.Location = new System.Drawing.Point(60, 80);
            this.trlUnit.Name = "trlUnit";
            this.trlUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.trlUnit.Properties.NullText = "";
            this.trlUnit.Properties.PopupFormSize = new System.Drawing.Size(140, 160);
            this.trlUnit.Properties.TreeList = this.treUnit;
            this.trlUnit.Size = new System.Drawing.Size(100, 20);
            this.trlUnit.TabIndex = 12;
            this.trlUnit.EditValueChanged += new System.EventHandler(this.trlUnit_EditValueChanged);
            // 
            // treUnit
            // 
            this.treUnit.Location = new System.Drawing.Point(-20, 9);
            this.treUnit.Name = "treUnit";
            this.treUnit.OptionsBehavior.EnableFiltering = true;
            this.treUnit.OptionsView.ShowIndentAsRowStyle = true;
            this.treUnit.SelectImageList = this.imgCategoryNode;
            this.treUnit.Size = new System.Drawing.Size(215, 200);
            this.treUnit.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(185, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Enabled = false;
            this.btnItemAdd.Location = new System.Drawing.Point(270, 210);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(75, 23);
            this.btnItemAdd.TabIndex = 17;
            this.btnItemAdd.Text = "添加项目";
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // sleMaterial
            // 
            this.sleMaterial.EnterMoveNextControl = true;
            this.sleMaterial.Location = new System.Drawing.Point(60, 50);
            this.sleMaterial.Name = "sleMaterial";
            this.sleMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sleMaterial.Properties.NullText = "请选择入库物资…";
            this.sleMaterial.Properties.PopupFormSize = new System.Drawing.Size(285, 240);
            this.sleMaterial.Properties.ShowClearButton = false;
            this.sleMaterial.Properties.ShowFooter = false;
            this.sleMaterial.Properties.View = this.gdvMaterial;
            this.sleMaterial.Size = new System.Drawing.Size(285, 20);
            this.sleMaterial.TabIndex = 11;
            this.sleMaterial.EditValueChanged += new System.EventHandler(this.sleMaterial_EditValueChanged);
            // 
            // gdvMaterial
            // 
            this.gdvMaterial.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gdvMaterial.Name = "gdvMaterial";
            this.gdvMaterial.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvMaterial.OptionsView.ShowColumnHeaders = false;
            this.gdvMaterial.OptionsView.ShowGroupPanel = false;
            // 
            // memSummary
            // 
            this.memSummary.Enabled = false;
            this.memSummary.EnterMoveNextControl = true;
            this.memSummary.Location = new System.Drawing.Point(60, 145);
            this.memSummary.Name = "memSummary";
            this.memSummary.Size = new System.Drawing.Size(285, 50);
            this.memSummary.TabIndex = 16;
            this.memSummary.UseOptimizedRendering = true;
            // 
            // txtCodeBar
            // 
            this.txtCodeBar.EnterMoveNextControl = true;
            this.txtCodeBar.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCodeBar.Location = new System.Drawing.Point(60, 15);
            this.txtCodeBar.Name = "txtCodeBar";
            this.txtCodeBar.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtCodeBar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCodeBar.Properties.NullText = "请输入条码…";
            this.txtCodeBar.Size = new System.Drawing.Size(285, 20);
            this.txtCodeBar.TabIndex = 10;
            this.txtCodeBar.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.txtCodeBar_ParseEditValue);
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.EnterMoveNextControl = true;
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPrice.Location = new System.Drawing.Point(220, 80);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(125, 20);
            this.txtPrice.TabIndex = 13;
            this.txtPrice.EditValueChanged += new System.EventHandler(this.txtPrice_EditValueChanged);
            // 
            // labSummary
            // 
            this.labSummary.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labSummary.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labSummary.Location = new System.Drawing.Point(0, 145);
            this.labSummary.Name = "labSummary";
            this.labSummary.Size = new System.Drawing.Size(60, 21);
            this.labSummary.TabIndex = 0;
            this.labSummary.Text = "摘要：";
            // 
            // labCount
            // 
            this.labCount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCount.Location = new System.Drawing.Point(0, 110);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(60, 21);
            this.labCount.TabIndex = 0;
            this.labCount.Text = "数量：";
            // 
            // labPrice
            // 
            this.labPrice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPrice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPrice.Location = new System.Drawing.Point(160, 80);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new System.Drawing.Size(60, 21);
            this.labPrice.TabIndex = 0;
            this.labPrice.Text = "单价：";
            // 
            // labUnit
            // 
            this.labUnit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labUnit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labUnit.Location = new System.Drawing.Point(0, 80);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(60, 21);
            this.labUnit.TabIndex = 0;
            this.labUnit.Text = "单位：";
            // 
            // labCodeBar
            // 
            this.labCodeBar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCodeBar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCodeBar.Location = new System.Drawing.Point(0, 15);
            this.labCodeBar.Name = "labCodeBar";
            this.labCodeBar.Size = new System.Drawing.Size(60, 21);
            this.labCodeBar.TabIndex = 0;
            this.labCodeBar.Text = "条码：";
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.EnterMoveNextControl = true;
            this.txtCount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCount.Location = new System.Drawing.Point(60, 110);
            this.txtCount.Name = "txtCount";
            this.txtCount.Properties.DisplayFormat.FormatString = "#,##0.######";
            this.txtCount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCount.Size = new System.Drawing.Size(100, 20);
            this.txtCount.TabIndex = 14;
            this.txtCount.EditValueChanged += new System.EventHandler(this.txtCount_EditValueChanged);
            // 
            // labApplyCode
            // 
            this.labApplyCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labApplyCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labApplyCode.Location = new System.Drawing.Point(545, 15);
            this.labApplyCode.Name = "labApplyCode";
            this.labApplyCode.Size = new System.Drawing.Size(60, 21);
            this.labApplyCode.TabIndex = 0;
            this.labApplyCode.Text = "单号：";
            // 
            // txtApplyCode
            // 
            this.txtApplyCode.EnterMoveNextControl = true;
            this.txtApplyCode.Location = new System.Drawing.Point(605, 15);
            this.txtApplyCode.Name = "txtApplyCode";
            this.txtApplyCode.Size = new System.Drawing.Size(150, 20);
            this.txtApplyCode.TabIndex = 3;
            this.txtApplyCode.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.txtApplyCode_ParseEditValue);
            // 
            // Entry
            // 
            this.AcceptButton = null;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.palItem);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labitem);
            this.Controls.Add(this.grdItem);
            this.Name = "Entry";
            this.Text = "入库";
            this.Load += new System.EventHandler(this.Cashier_Load);
            this.Controls.SetChildIndex(this.grdItem, 0);
            this.Controls.SetChildIndex(this.labitem, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.palItem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palItem)).EndInit();
            this.palItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSummary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApplyCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvItem;
        private DevExpress.XtraEditors.SearchLookUpEdit sleCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvCustomer;
        private DevExpress.XtraEditors.LabelControl labCustomer;
        private DevExpress.XtraEditors.MemoEdit memDesc;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labDesc;
        private DevExpress.XtraEditors.LabelControl labitem;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.LabelControl labExpense;
        private DevExpress.XtraEditors.PanelControl palItem;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labCount;
        private DevExpress.XtraEditors.LabelControl labPrice;
        private DevExpress.XtraEditors.LabelControl labUnit;
        private DevExpress.XtraEditors.MemoEdit memSummary;
        private DevExpress.XtraEditors.LabelControl labSummary;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnItemAdd;
        private DevExpress.XtraEditors.TreeListLookUpEdit trlUnit;
        private DevExpress.XtraTreeList.TreeList treUnit;
        private DevExpress.XtraEditors.TextEdit txtCount;
        private DevExpress.XtraEditors.TextEdit txtCodeBar;
        private DevExpress.XtraEditors.TextEdit txtApplyCode;
        private DevExpress.XtraEditors.LabelControl labApplyCode;
        private DevExpress.XtraEditors.SearchLookUpEdit sleMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvMaterial;
        private DevExpress.XtraEditors.CalcEdit calAmount;
        private DevExpress.XtraEditors.LabelControl labAmount;
        private DevExpress.XtraEditors.LabelControl labCodeBar;
    }
}
