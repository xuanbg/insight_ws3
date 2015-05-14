using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraWizard;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    partial class ReportWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportWizard));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            var serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.wizPage2 = new DevExpress.XtraWizard.WizardPage();
            this.splEntity = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpEntity = new DevExpress.XtraEditors.GroupControl();
            this.treEntity = new DevExpress.XtraTreeList.TreeList();
            this.grpMember = new DevExpress.XtraEditors.GroupControl();
            this.grdMember = new DevExpress.XtraGrid.GridControl();
            this.gdvMember = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdvRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdRules = new DevExpress.XtraGrid.GridControl();
            this.wizPage1 = new DevExpress.XtraWizard.WizardPage();
            this.splBase = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpProperty = new DevExpress.XtraEditors.GroupControl();
            this.cmbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labType = new DevExpress.XtraEditors.LabelControl();
            this.trlCategory = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treCategory = new DevExpress.XtraTreeList.TreeList();
            this.labCategory = new DevExpress.XtraEditors.LabelControl();
            this.spiTimes = new DevExpress.XtraEditors.SpinEdit();
            this.trlTemplet = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treTemplet = new DevExpress.XtraTreeList.TreeList();
            this.cmbDelay = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDataSource = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.labHours = new DevExpress.XtraEditors.LabelControl();
            this.labDataSource = new DevExpress.XtraEditors.LabelControl();
            this.labMode = new DevExpress.XtraEditors.LabelControl();
            this.labTemplet = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.grpRules = new DevExpress.XtraEditors.GroupControl();
            this.wizReport = new DevExpress.XtraWizard.WizardControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.wizPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splEntity)).BeginInit();
            this.splEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEntity)).BeginInit();
            this.grpEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).BeginInit();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            this.wizPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splBase)).BeginInit();
            this.splBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpProperty)).BeginInit();
            this.grpProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlTemplet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treTemplet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDelay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRules)).BeginInit();
            this.grpRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizReport)).BeginInit();
            this.wizReport.SuspendLayout();
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
            // wizPage2
            // 
            this.wizPage2.AllowNext = false;
            this.wizPage2.Controls.Add(this.splEntity);
            this.wizPage2.DescriptionText = "必须选择一个或多个统计主体，并选择一个或多个用户组作为对应的报送对象。";
            this.wizPage2.Name = "wizPage2";
            this.wizPage2.Size = new System.Drawing.Size(592, 297);
            this.wizPage2.Text = "统计主体和报送对象";
            // 
            // splEntity
            // 
            this.splEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splEntity.Location = new System.Drawing.Point(0, 0);
            this.splEntity.Name = "splEntity";
            this.splEntity.Panel1.Controls.Add(this.grpEntity);
            this.splEntity.Panel1.MinSize = 280;
            this.splEntity.Panel1.Text = "Panel1";
            this.splEntity.Panel2.Controls.Add(this.grpMember);
            this.splEntity.Panel2.MinSize = 307;
            this.splEntity.Panel2.Text = "Panel2";
            this.splEntity.Size = new System.Drawing.Size(592, 297);
            this.splEntity.SplitterPosition = 280;
            this.splEntity.TabIndex = 0;
            // 
            // grpEntity
            // 
            this.grpEntity.Controls.Add(this.treEntity);
            this.grpEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEntity.Location = new System.Drawing.Point(0, 0);
            this.grpEntity.Name = "grpEntity";
            this.grpEntity.Size = new System.Drawing.Size(280, 297);
            this.grpEntity.TabIndex = 0;
            this.grpEntity.Text = "主体";
            // 
            // treEntity
            // 
            this.treEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treEntity.KeyFieldName = "OrgId";
            this.treEntity.Location = new System.Drawing.Point(2, 22);
            this.treEntity.Name = "treEntity";
            this.treEntity.OptionsSelection.MultiSelect = true;
            this.treEntity.OptionsView.ShowCheckBoxes = true;
            this.treEntity.ParentFieldName = "ParentId";
            this.treEntity.Size = new System.Drawing.Size(276, 273);
            this.treEntity.TabIndex = 1;
            this.treEntity.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treEntity_AfterCheckNode);
            this.treEntity.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treEntity_FocusedNodeChanged);
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.grdMember);
            this.grpMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMember.Location = new System.Drawing.Point(0, 0);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(307, 297);
            this.grpMember.TabIndex = 0;
            this.grpMember.Text = "报送";
            // 
            // grdMember
            // 
            this.grdMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMember.Location = new System.Drawing.Point(2, 22);
            this.grdMember.MainView = this.gdvMember;
            this.grdMember.Name = "grdMember";
            this.grdMember.Size = new System.Drawing.Size(303, 273);
            this.grdMember.TabIndex = 2;
            this.grdMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvMember});
            // 
            // gdvMember
            // 
            this.gdvMember.GridControl = this.grdMember;
            this.gdvMember.Name = "gdvMember";
            this.gdvMember.OptionsSelection.MultiSelect = true;
            this.gdvMember.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gdvMember.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gdvMember_SelectionChanged);
            // 
            // gdvRules
            // 
            this.gdvRules.GridControl = this.grdRules;
            this.gdvRules.Name = "gdvRules";
            this.gdvRules.OptionsCustomization.AllowGroup = false;
            this.gdvRules.OptionsSelection.MultiSelect = true;
            this.gdvRules.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gdvRules.OptionsView.ShowGroupPanel = false;
            this.gdvRules.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gdvRules_SelectionChanged);
            this.gdvRules.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gdvRules_FocusedRowChanged);
            // 
            // grdRules
            // 
            this.grdRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRules.Location = new System.Drawing.Point(2, 22);
            this.grdRules.MainView = this.gdvRules;
            this.grdRules.Name = "grdRules";
            this.grdRules.Size = new System.Drawing.Size(303, 273);
            this.grdRules.TabIndex = 10;
            this.grdRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvRules});
            // 
            // wizPage1
            // 
            this.wizPage1.Controls.Add(this.splBase);
            this.wizPage1.DescriptionText = "必须选择一个或多个分期，如该报表不定期统计，可选择不定期。";
            this.wizPage1.Name = "wizPage1";
            this.wizPage1.Size = new System.Drawing.Size(592, 297);
            this.wizPage1.Text = "基本属性";
            // 
            // splBase
            // 
            this.splBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBase.Location = new System.Drawing.Point(0, 0);
            this.splBase.Name = "splBase";
            this.splBase.Panel1.Controls.Add(this.grpProperty);
            this.splBase.Panel1.MinSize = 280;
            this.splBase.Panel2.Controls.Add(this.grpRules);
            this.splBase.Panel2.MinSize = 307;
            this.splBase.Size = new System.Drawing.Size(592, 297);
            this.splBase.SplitterPosition = 280;
            this.splBase.TabIndex = 0;
            // 
            // grpProperty
            // 
            this.grpProperty.Controls.Add(this.cmbType);
            this.grpProperty.Controls.Add(this.labType);
            this.grpProperty.Controls.Add(this.trlCategory);
            this.grpProperty.Controls.Add(this.labCategory);
            this.grpProperty.Controls.Add(this.spiTimes);
            this.grpProperty.Controls.Add(this.trlTemplet);
            this.grpProperty.Controls.Add(this.cmbDelay);
            this.grpProperty.Controls.Add(this.cmbDataSource);
            this.grpProperty.Controls.Add(this.cmbMode);
            this.grpProperty.Controls.Add(this.labRemark);
            this.grpProperty.Controls.Add(this.labHours);
            this.grpProperty.Controls.Add(this.labDataSource);
            this.grpProperty.Controls.Add(this.labMode);
            this.grpProperty.Controls.Add(this.labTemplet);
            this.grpProperty.Controls.Add(this.labName);
            this.grpProperty.Controls.Add(this.memDescription);
            this.grpProperty.Controls.Add(this.txtName);
            this.grpProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProperty.Location = new System.Drawing.Point(0, 0);
            this.grpProperty.Name = "grpProperty";
            this.grpProperty.Size = new System.Drawing.Size(280, 297);
            this.grpProperty.TabIndex = 0;
            this.grpProperty.Text = "基本属性";
            // 
            // cmbType
            // 
            this.cmbType.EnterMoveNextControl = true;
            this.cmbType.Location = new System.Drawing.Point(65, 160);
            this.cmbType.Name = "cmbType";
            this.cmbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbType.Properties.Items.AddRange(new object[] {
            "组织机构报表",
            "个人私有报表"});
            this.cmbType.Size = new System.Drawing.Size(115, 20);
            this.cmbType.TabIndex = 8;
            // 
            // labType
            // 
            this.labType.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labType.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labType.Location = new System.Drawing.Point(5, 160);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(60, 21);
            this.labType.TabIndex = 0;
            this.labType.Text = "类型：";
            // 
            // trlCategory
            // 
            this.trlCategory.EnterMoveNextControl = true;
            this.trlCategory.Location = new System.Drawing.Point(65, 40);
            this.trlCategory.Name = "trlCategory";
            this.trlCategory.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.trlCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("trlCategory.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlCategory.Properties.NullText = "请选择报表分类…";
            this.trlCategory.Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            this.trlCategory.Properties.TreeList = this.treCategory;
            this.trlCategory.Size = new System.Drawing.Size(200, 22);
            this.trlCategory.TabIndex = 1;
            // 
            // treCategory
            // 
            this.treCategory.Location = new System.Drawing.Point(7, 48);
            this.treCategory.Name = "treCategory";
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new System.Drawing.Size(200, 200);
            this.treCategory.TabIndex = 0;
            // 
            // labCategory
            // 
            this.labCategory.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCategory.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labCategory.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCategory.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCategory.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCategory.Location = new System.Drawing.Point(5, 40);
            this.labCategory.Name = "labCategory";
            this.labCategory.Size = new System.Drawing.Size(60, 21);
            this.labCategory.TabIndex = 0;
            this.labCategory.Text = "分类：";
            // 
            // spiTimes
            // 
            this.spiTimes.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spiTimes.EnterMoveNextControl = true;
            this.spiTimes.Location = new System.Drawing.Point(185, 130);
            this.spiTimes.Name = "spiTimes";
            this.spiTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiTimes.Properties.IsFloatValue = false;
            this.spiTimes.Properties.Mask.EditMask = "N00";
            this.spiTimes.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.spiTimes.Size = new System.Drawing.Size(50, 20);
            this.spiTimes.TabIndex = 6;
            // 
            // trlTemplet
            // 
            this.trlTemplet.EnterMoveNextControl = true;
            this.trlTemplet.Location = new System.Drawing.Point(65, 100);
            this.trlTemplet.Name = "trlTemplet";
            this.trlTemplet.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.trlTemplet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("trlTemplet.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.trlTemplet.Properties.NullText = "请选择相应的报表模板…";
            this.trlTemplet.Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            this.trlTemplet.Properties.TreeList = this.treTemplet;
            this.trlTemplet.Size = new System.Drawing.Size(200, 22);
            this.trlTemplet.TabIndex = 3;
            this.trlTemplet.EditValueChanged += new System.EventHandler(this.trlTemplet_EditValueChanged);
            // 
            // treTemplet
            // 
            this.treTemplet.Location = new System.Drawing.Point(0, 60);
            this.treTemplet.Name = "treTemplet";
            this.treTemplet.SelectImageList = this.imgCategoryNode;
            this.treTemplet.Size = new System.Drawing.Size(200, 200);
            this.treTemplet.TabIndex = 0;
            // 
            // cmbDelay
            // 
            this.cmbDelay.EnterMoveNextControl = true;
            this.cmbDelay.Location = new System.Drawing.Point(125, 130);
            this.cmbDelay.Name = "cmbDelay";
            this.cmbDelay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDelay.Properties.Items.AddRange(new object[] {
            "延后",
            "提前"});
            this.cmbDelay.Size = new System.Drawing.Size(55, 20);
            this.cmbDelay.TabIndex = 5;
            // 
            // cmbDataSource
            // 
            this.cmbDataSource.Location = new System.Drawing.Point(65, 190);
            this.cmbDataSource.Name = "cmbDataSource";
            this.cmbDataSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDataSource.Properties.Items.AddRange(new object[] {
            "系统数据源",
            "模板数据源"});
            this.cmbDataSource.Size = new System.Drawing.Size(115, 20);
            this.cmbDataSource.TabIndex = 8;
            // 
            // cmbMode
            // 
            this.cmbMode.EnterMoveNextControl = true;
            this.cmbMode.Location = new System.Drawing.Point(65, 130);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMode.Properties.Items.AddRange(new object[] {
            "时段",
            "时点",
            "即时"});
            this.cmbMode.Size = new System.Drawing.Size(55, 20);
            this.cmbMode.TabIndex = 4;
            this.cmbMode.EditValueChanged += new System.EventHandler(this.cmbMode_EditValueChanged);
            // 
            // labRemark
            // 
            this.labRemark.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRemark.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labRemark.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labRemark.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labRemark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labRemark.Location = new System.Drawing.Point(5, 220);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(60, 21);
            this.labRemark.TabIndex = 0;
            this.labRemark.Text = "备注：";
            // 
            // labHours
            // 
            this.labHours.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHours.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labHours.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labHours.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labHours.Location = new System.Drawing.Point(240, 130);
            this.labHours.Name = "labHours";
            this.labHours.Size = new System.Drawing.Size(30, 21);
            this.labHours.TabIndex = 0;
            this.labHours.Text = "小时";
            // 
            // labDataSource
            // 
            this.labDataSource.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDataSource.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labDataSource.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDataSource.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDataSource.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDataSource.Location = new System.Drawing.Point(5, 190);
            this.labDataSource.Name = "labDataSource";
            this.labDataSource.Size = new System.Drawing.Size(60, 21);
            this.labDataSource.TabIndex = 0;
            this.labDataSource.Text = "数据源：";
            // 
            // labMode
            // 
            this.labMode.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMode.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labMode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMode.Location = new System.Drawing.Point(5, 130);
            this.labMode.Name = "labMode";
            this.labMode.Size = new System.Drawing.Size(60, 21);
            this.labMode.TabIndex = 0;
            this.labMode.Text = "模式：";
            // 
            // labTemplet
            // 
            this.labTemplet.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTemplet.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labTemplet.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTemplet.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTemplet.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTemplet.Location = new System.Drawing.Point(5, 100);
            this.labTemplet.Name = "labTemplet";
            this.labTemplet.Size = new System.Drawing.Size(60, 21);
            this.labTemplet.TabIndex = 0;
            this.labTemplet.Text = "模板：";
            // 
            // labName
            // 
            this.labName.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(5, 70);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // memDescription
            // 
            this.memDescription.EnterMoveNextControl = true;
            this.memDescription.Location = new System.Drawing.Point(65, 220);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入备注信息…";
            this.memDescription.Size = new System.Drawing.Size(200, 60);
            this.memDescription.TabIndex = 9;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(65, 70);
            this.txtName.Name = "txtName";
            this.txtName.Properties.NullText = "请输入报表名称…";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 2;
            this.txtName.EditValueChanged += new System.EventHandler(this.txtName_EditValueChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // grpRules
            // 
            this.grpRules.Controls.Add(this.grdRules);
            this.grpRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRules.Location = new System.Drawing.Point(0, 0);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(307, 297);
            this.grpRules.TabIndex = 0;
            this.grpRules.Text = "报表分期";
            // 
            // wizReport
            // 
            this.wizReport.Appearance.PageTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wizReport.Appearance.PageTitle.Options.UseFont = true;
            this.wizReport.CancelText = "取 消";
            this.wizReport.Controls.Add(this.wizPage1);
            this.wizReport.Controls.Add(this.wizPage2);
            this.wizReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizReport.FinishText = "完 成";
            this.wizReport.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wizReport.HeaderImage")));
            this.wizReport.HelpText = "帮 助";
            this.wizReport.Location = new System.Drawing.Point(0, 0);
            this.wizReport.Name = "wizReport";
            this.wizReport.NextText = "下一步";
            this.wizReport.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wizPage1,
            this.wizPage2});
            this.wizReport.PreviousText = "上一步";
            this.wizReport.Size = new System.Drawing.Size(624, 442);
            this.wizReport.FinishClick += new System.ComponentModel.CancelEventHandler(this.wzdReport_FinishClick);
            this.wizReport.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizard_NextClick);
            // 
            // ReportWizard
            // 
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.ControlBox = false;
            this.Controls.Add(this.wizReport);
            this.Name = "ReportWizard";
            this.Text = "报表向导";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.wizPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splEntity)).EndInit();
            this.splEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpEntity)).EndInit();
            this.grpEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).EndInit();
            this.grpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            this.wizPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBase)).EndInit();
            this.splBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpProperty)).EndInit();
            this.grpProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlTemplet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treTemplet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDelay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRules)).EndInit();
            this.grpRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizReport)).EndInit();
            this.wizReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPage wizPage2;
        private SplitContainerControl splEntity;
        private GroupControl grpEntity;
        private TreeList treEntity;
        private GroupControl grpMember;
        private GridControl grdMember;
        private GridView gdvMember;
        private GridView gdvRules;
        private GridControl grdRules;
        private WizardPage wizPage1;
        private SplitContainerControl splBase;
        private GroupControl grpProperty;
        private SpinEdit spiTimes;
        private TreeListLookUpEdit trlTemplet;
        private TreeList treTemplet;
        private ComboBoxEdit cmbDelay;
        private ComboBoxEdit cmbMode;
        private LabelControl labRemark;
        private LabelControl labHours;
        private LabelControl labDataSource;
        private LabelControl labMode;
        private LabelControl labTemplet;
        private LabelControl labName;
        private MemoEdit memDescription;
        private TextEdit txtName;
        private GroupControl grpRules;
        private WizardControl wizReport;
        private ComboBoxEdit cmbDataSource;
        private ComboBoxEdit cmbType;
        private LabelControl labType;
        private TreeListLookUpEdit trlCategory;
        private TreeList treCategory;
        private LabelControl labCategory;
    }
}