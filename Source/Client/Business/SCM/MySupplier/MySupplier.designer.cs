using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraLayout;
using DevExpress.XtraVerticalGrid;
using ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility;

namespace Insight.WS.Client.Business.SCM
{
    partial class MySupplier
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
            var resources = new ComponentResourceManager(typeof(MySupplier));
            var serializableAppearanceObject1 = new SerializableAppearanceObject();
            this.splMain = new SplitContainerControl();
            this.grdSupplier = new GridControl();
            this.gdvSupplier = new GridView();
            this.splInfo = new SplitContainerControl();
            this.grdOther = new GridControl();
            this.gdvOther = new GridView();
            this.ContactList = new RepositoryItemLookUpEdit();
            this.vrdInfo = new VGridControl();
            this.grdContact = new GridControl();
            this.glvContact = new LayoutView();
            this.colName = new LayoutViewColumn();
            this.layoutViewField_col姓名1 = new LayoutViewField();
            this.colDepartment = new LayoutViewColumn();
            this.layoutViewField_col任职部门1 = new LayoutViewField();
            this.colTitle = new LayoutViewColumn();
            this.layoutViewField_col职务1 = new LayoutViewField();
            this.colOffice = new LayoutViewColumn();
            this.layoutViewField_col办公地点1 = new LayoutViewField();
            this.colHome = new LayoutViewColumn();
            this.layoutViewField_col家庭住址1 = new LayoutViewField();
            this.colBirthday = new LayoutViewColumn();
            this.layoutViewField_col生日1 = new LayoutViewField();
            this.colDescription = new LayoutViewColumn();
            this.layoutViewField_col备注1 = new LayoutViewField();
            this.colIsMaster = new LayoutViewColumn();
            this.layoutViewField_col主要联系人1 = new LayoutViewField();
            this.colLoginName = new LayoutViewColumn();
            this.layoutViewField_col登录帐号1 = new LayoutViewField();
            this.colIsLogin = new LayoutViewColumn();
            this.layoutViewField_col登录1 = new LayoutViewField();
            this.colPhone = new LayoutViewColumn();
            this.layoutViewField_col移动电话1 = new LayoutViewField();
            this.colTel = new LayoutViewColumn();
            this.layoutViewField_col电话号码1 = new LayoutViewField();
            this.colEmail = new LayoutViewColumn();
            this.layoutViewField_col电子邮件1 = new LayoutViewField();
            this.colView = new LayoutViewColumn();
            this.rbeView = new RepositoryItemButtonEdit();
            this.layoutViewField_col查看其它信息1 = new LayoutViewField();
            this.layoutViewCard1 = new LayoutViewCard();
            this.palFilter = new PanelControl();
            this.bteSearch = new ButtonEdit();
            this.btnQuery = new SimpleButton();
            this.chkUnion = new CheckEdit();
            this.chkSub = new CheckEdit();
            this.chkMy = new CheckEdit();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.grdSupplier)).BeginInit();
            ((ISupportInitialize)(this.gdvSupplier)).BeginInit();
            ((ISupportInitialize)(this.splInfo)).BeginInit();
            this.splInfo.SuspendLayout();
            ((ISupportInitialize)(this.grdOther)).BeginInit();
            ((ISupportInitialize)(this.gdvOther)).BeginInit();
            ((ISupportInitialize)(this.ContactList)).BeginInit();
            ((ISupportInitialize)(this.vrdInfo)).BeginInit();
            ((ISupportInitialize)(this.grdContact)).BeginInit();
            ((ISupportInitialize)(this.glvContact)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col姓名1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col任职部门1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col职务1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col办公地点1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col家庭住址1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col生日1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col备注1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col主要联系人1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col登录帐号1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col登录1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col移动电话1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col电话号码1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col电子邮件1)).BeginInit();
            ((ISupportInitialize)(this.rbeView)).BeginInit();
            ((ISupportInitialize)(this.layoutViewField_col查看其它信息1)).BeginInit();
            ((ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((ISupportInitialize)(this.palFilter)).BeginInit();
            this.palFilter.SuspendLayout();
            ((ISupportInitialize)(this.bteSearch.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkUnion.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkSub.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkMy.Properties)).BeginInit();
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
            this.xtraScrollable.Controls.Add(this.palFilter);
            this.xtraScrollable.Controls.Add(this.splMain);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.splMain.FixedPanel = SplitFixedPanel.Panel2;
            this.splMain.Horizontal = false;
            this.splMain.Location = new Point(5, 50);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grdSupplier);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.splInfo);
            this.splMain.Panel2.MinSize = 260;
            this.splMain.Size = new Size(1070, 545);
            this.splMain.SplitterPosition = 260;
            this.splMain.TabIndex = 0;
            // 
            // grdSupplier
            // 
            this.grdSupplier.Dock = DockStyle.Fill;
            this.grdSupplier.Location = new Point(0, 0);
            this.grdSupplier.MainView = this.gdvSupplier;
            this.grdSupplier.Name = "grdSupplier";
            this.grdSupplier.Size = new Size(1070, 280);
            this.grdSupplier.TabIndex = 8;
            this.grdSupplier.ViewCollection.AddRange(new BaseView[] {
            this.gdvSupplier});
            // 
            // gdvSupplier
            // 
            this.gdvSupplier.GridControl = this.grdSupplier;
            this.gdvSupplier.Name = "gdvSupplier";
            this.gdvSupplier.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvSupplier_FocusedRowObjectChanged);
            this.gdvSupplier.DoubleClick += new EventHandler(this.gdvSupplier_DoubleClick);
            // 
            // splInfo
            // 
            this.splInfo.Dock = DockStyle.Fill;
            this.splInfo.Location = new Point(0, 0);
            this.splInfo.Name = "splInfo";
            this.splInfo.Panel1.Controls.Add(this.grdOther);
            this.splInfo.Panel1.Controls.Add(this.vrdInfo);
            this.splInfo.Panel1.MinSize = 320;
            this.splInfo.Panel2.Controls.Add(this.grdContact);
            this.splInfo.Panel2.MinSize = 200;
            this.splInfo.Size = new Size(1070, 260);
            this.splInfo.SplitterPosition = 320;
            this.splInfo.TabIndex = 1;
            this.splInfo.Text = "splitContainerControl2";
            // 
            // grdOther
            // 
            this.grdOther.Dock = DockStyle.Fill;
            this.grdOther.Location = new Point(0, 0);
            this.grdOther.MainView = this.gdvOther;
            this.grdOther.Name = "grdOther";
            this.grdOther.RepositoryItems.AddRange(new RepositoryItem[] {
            this.ContactList});
            this.grdOther.Size = new Size(320, 260);
            this.grdOther.TabIndex = 0;
            this.grdOther.ViewCollection.AddRange(new BaseView[] {
            this.gdvOther});
            this.grdOther.Visible = false;
            // 
            // gdvOther
            // 
            this.gdvOther.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gdvOther.Appearance.ViewCaption.TextOptions.HAlignment = HorzAlignment.Center;
            this.gdvOther.GridControl = this.grdOther;
            this.gdvOther.Name = "gdvOther";
            this.gdvOther.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
            this.gdvOther.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True;
            this.gdvOther.OptionsBehavior.EditingMode = GridEditingMode.Inplace;
            // 
            // ContactList
            // 
            this.ContactList.AutoHeight = false;
            this.ContactList.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.ContactList.Name = "ContactList";
            this.ContactList.NullText = "";
            this.ContactList.PopupFormMinSize = new Size(65, 0);
            this.ContactList.PopupWidth = 80;
            this.ContactList.ShowHeader = false;
            this.ContactList.TextEditStyle = TextEditStyles.Standard;
            // 
            // vrdInfo
            // 
            this.vrdInfo.Appearance.BandBorder.Options.UseTextOptions = true;
            this.vrdInfo.Appearance.BandBorder.TextOptions.HAlignment = HorzAlignment.Near;
            this.vrdInfo.Appearance.RowHeaderPanel.Options.UseTextOptions = true;
            this.vrdInfo.Appearance.RowHeaderPanel.TextOptions.HAlignment = HorzAlignment.Far;
            this.vrdInfo.Dock = DockStyle.Fill;
            this.vrdInfo.Location = new Point(0, 0);
            this.vrdInfo.Name = "vrdInfo";
            this.vrdInfo.OptionsBehavior.Editable = false;
            this.vrdInfo.OptionsBehavior.ResizeHeaderPanel = false;
            this.vrdInfo.OptionsBehavior.ResizeRowHeaders = false;
            this.vrdInfo.OptionsBehavior.ResizeRowValues = false;
            this.vrdInfo.OptionsView.FixRowHeaderPanelWidth = true;
            this.vrdInfo.OptionsView.MinRowAutoHeight = 20;
            this.vrdInfo.Size = new Size(320, 260);
            this.vrdInfo.TabIndex = 9;
            // 
            // grdContact
            // 
            this.grdContact.Dock = DockStyle.Fill;
            this.grdContact.Location = new Point(0, 0);
            this.grdContact.MainView = this.glvContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.RepositoryItems.AddRange(new RepositoryItem[] {
            this.rbeView});
            this.grdContact.Size = new Size(745, 260);
            this.grdContact.TabIndex = 10;
            this.grdContact.ViewCollection.AddRange(new BaseView[] {
            this.glvContact});
            this.grdContact.DoubleClick += new EventHandler(this.glvContact_DoubleClick);
            // 
            // glvContact
            // 
            this.glvContact.CardMinSize = new Size(340, 239);
            this.glvContact.Columns.AddRange(new LayoutViewColumn[] {
            this.colName,
            this.colDepartment,
            this.colTitle,
            this.colOffice,
            this.colHome,
            this.colBirthday,
            this.colDescription,
            this.colIsMaster,
            this.colLoginName,
            this.colIsLogin,
            this.colPhone,
            this.colTel,
            this.colEmail,
            this.colView});
            this.glvContact.GridControl = this.grdContact;
            this.glvContact.Name = "glvContact";
            this.glvContact.OptionsBehavior.ScrollVisibility = ScrollVisibility.Auto;
            this.glvContact.OptionsCustomization.AllowFilter = false;
            this.glvContact.OptionsCustomization.AllowSort = false;
            this.glvContact.OptionsItemText.AlignMode = FieldTextAlignMode.AutoSize;
            this.glvContact.OptionsView.CardsAlignment = CardsAlignment.Near;
            this.glvContact.OptionsView.ShowCardCaption = false;
            this.glvContact.OptionsView.ShowCardExpandButton = false;
            this.glvContact.OptionsView.ShowCardFieldBorders = true;
            this.glvContact.OptionsView.ShowHeaderPanel = false;
            this.glvContact.OptionsView.ViewMode = LayoutViewMode.Row;
            this.glvContact.SortInfo.AddRange(new GridColumnSortInfo[] {
            new GridColumnSortInfo(this.colView, ColumnSortOrder.Ascending)});
            this.glvContact.TemplateCard = this.layoutViewCard1;
            this.glvContact.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.glvContact_FocusedRowObjectChanged);
            // 
            // colName
            // 
            this.colName.Caption = "姓名";
            this.colName.CustomizationCaption = "姓名";
            this.colName.FieldName = "姓名";
            this.colName.LayoutViewField = this.layoutViewField_col姓名1;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col姓名1
            // 
            this.layoutViewField_col姓名1.EditorPreferredWidth = 93;
            this.layoutViewField_col姓名1.Location = new Point(0, 0);
            this.layoutViewField_col姓名1.Name = "layoutViewField_col姓名1";
            this.layoutViewField_col姓名1.Size = new Size(130, 26);
            this.layoutViewField_col姓名1.TextSize = new Size(28, 14);
            this.layoutViewField_col姓名1.TextToControlDistance = 5;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "任职部门";
            this.colDepartment.CustomizationCaption = "任职部门";
            this.colDepartment.FieldName = "任职部门";
            this.colDepartment.LayoutViewField = this.layoutViewField_col任职部门1;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col任职部门1
            // 
            this.layoutViewField_col任职部门1.EditorPreferredWidth = 149;
            this.layoutViewField_col任职部门1.Location = new Point(130, 26);
            this.layoutViewField_col任职部门1.Name = "layoutViewField_col任职部门1";
            this.layoutViewField_col任职部门1.Size = new Size(210, 24);
            this.layoutViewField_col任职部门1.TextSize = new Size(52, 14);
            this.layoutViewField_col任职部门1.TextToControlDistance = 5;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "职务";
            this.colTitle.CustomizationCaption = "职务";
            this.colTitle.FieldName = "职务";
            this.colTitle.LayoutViewField = this.layoutViewField_col职务1;
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col职务1
            // 
            this.layoutViewField_col职务1.EditorPreferredWidth = 93;
            this.layoutViewField_col职务1.Location = new Point(0, 26);
            this.layoutViewField_col职务1.Name = "layoutViewField_col职务1";
            this.layoutViewField_col职务1.Size = new Size(130, 24);
            this.layoutViewField_col职务1.TextSize = new Size(28, 14);
            this.layoutViewField_col职务1.TextToControlDistance = 5;
            // 
            // colOffice
            // 
            this.colOffice.Caption = "办公地点";
            this.colOffice.CustomizationCaption = "办公地点";
            this.colOffice.FieldName = "办公地点";
            this.colOffice.LayoutViewField = this.layoutViewField_col办公地点1;
            this.colOffice.Name = "colOffice";
            this.colOffice.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col办公地点1
            // 
            this.layoutViewField_col办公地点1.EditorPreferredWidth = 279;
            this.layoutViewField_col办公地点1.Location = new Point(0, 50);
            this.layoutViewField_col办公地点1.Name = "layoutViewField_col办公地点1";
            this.layoutViewField_col办公地点1.Size = new Size(340, 24);
            this.layoutViewField_col办公地点1.TextSize = new Size(52, 14);
            this.layoutViewField_col办公地点1.TextToControlDistance = 5;
            // 
            // colHome
            // 
            this.colHome.Caption = "家庭住址";
            this.colHome.CustomizationCaption = "家庭住址";
            this.colHome.FieldName = "家庭住址";
            this.colHome.LayoutViewField = this.layoutViewField_col家庭住址1;
            this.colHome.Name = "colHome";
            this.colHome.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col家庭住址1
            // 
            this.layoutViewField_col家庭住址1.EditorPreferredWidth = 279;
            this.layoutViewField_col家庭住址1.Location = new Point(0, 74);
            this.layoutViewField_col家庭住址1.Name = "layoutViewField_col家庭住址1";
            this.layoutViewField_col家庭住址1.Size = new Size(340, 24);
            this.layoutViewField_col家庭住址1.TextSize = new Size(52, 14);
            this.layoutViewField_col家庭住址1.TextToControlDistance = 5;
            // 
            // colBirthday
            // 
            this.colBirthday.Caption = "生日";
            this.colBirthday.CustomizationCaption = "生日";
            this.colBirthday.FieldName = "生日";
            this.colBirthday.LayoutViewField = this.layoutViewField_col生日1;
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col生日1
            // 
            this.layoutViewField_col生日1.EditorPreferredWidth = 63;
            this.layoutViewField_col生日1.Location = new Point(130, 0);
            this.layoutViewField_col生日1.Name = "layoutViewField_col生日1";
            this.layoutViewField_col生日1.Size = new Size(100, 26);
            this.layoutViewField_col生日1.TextSize = new Size(28, 14);
            this.layoutViewField_col生日1.TextToControlDistance = 5;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "备注";
            this.colDescription.CustomizationCaption = "备注";
            this.colDescription.FieldName = "备注";
            this.colDescription.LayoutViewField = this.layoutViewField_col备注1;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col备注1
            // 
            this.layoutViewField_col备注1.EditorPreferredWidth = 336;
            this.layoutViewField_col备注1.Location = new Point(0, 170);
            this.layoutViewField_col备注1.Name = "layoutViewField_col备注1";
            this.layoutViewField_col备注1.Size = new Size(340, 50);
            this.layoutViewField_col备注1.TextLocation = Locations.Top;
            this.layoutViewField_col备注1.TextSize = new Size(28, 14);
            this.layoutViewField_col备注1.TextToControlDistance = 5;
            // 
            // colIsMaster
            // 
            this.colIsMaster.Caption = "主要联系人";
            this.colIsMaster.CustomizationCaption = "主要联系人";
            this.colIsMaster.FieldName = "主要联系人";
            this.colIsMaster.LayoutViewField = this.layoutViewField_col主要联系人1;
            this.colIsMaster.Name = "colIsMaster";
            this.colIsMaster.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col主要联系人1
            // 
            this.layoutViewField_col主要联系人1.EditorPreferredWidth = 37;
            this.layoutViewField_col主要联系人1.Location = new Point(230, 146);
            this.layoutViewField_col主要联系人1.Name = "layoutViewField_col主要联系人1";
            this.layoutViewField_col主要联系人1.Size = new Size(110, 24);
            this.layoutViewField_col主要联系人1.TextLocation = Locations.Default;
            this.layoutViewField_col主要联系人1.TextSize = new Size(64, 14);
            this.layoutViewField_col主要联系人1.TextToControlDistance = 5;
            // 
            // colLoginName
            // 
            this.colLoginName.Caption = "登录帐号";
            this.colLoginName.CustomizationCaption = "登录帐号";
            this.colLoginName.FieldName = "登录帐号";
            this.colLoginName.LayoutViewField = this.layoutViewField_col登录帐号1;
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col登录帐号1
            // 
            this.layoutViewField_col登录帐号1.EditorPreferredWidth = 109;
            this.layoutViewField_col登录帐号1.Location = new Point(0, 146);
            this.layoutViewField_col登录帐号1.Name = "layoutViewField_col登录帐号1";
            this.layoutViewField_col登录帐号1.Size = new Size(170, 24);
            this.layoutViewField_col登录帐号1.TextSize = new Size(52, 14);
            this.layoutViewField_col登录帐号1.TextToControlDistance = 5;
            // 
            // colIsLogin
            // 
            this.colIsLogin.Caption = "登录";
            this.colIsLogin.CustomizationCaption = "登录";
            this.colIsLogin.FieldName = "登录";
            this.colIsLogin.LayoutViewField = this.layoutViewField_col登录1;
            this.colIsLogin.Name = "colIsLogin";
            this.colIsLogin.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col登录1
            // 
            this.layoutViewField_col登录1.EditorPreferredWidth = 23;
            this.layoutViewField_col登录1.Location = new Point(170, 146);
            this.layoutViewField_col登录1.Name = "layoutViewField_col登录1";
            this.layoutViewField_col登录1.Size = new Size(60, 24);
            this.layoutViewField_col登录1.TextLocation = Locations.Default;
            this.layoutViewField_col登录1.TextSize = new Size(28, 14);
            this.layoutViewField_col登录1.TextToControlDistance = 5;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "移动电话";
            this.colPhone.CustomizationCaption = "移动电话";
            this.colPhone.FieldName = "移动电话";
            this.colPhone.LayoutViewField = this.layoutViewField_col移动电话1;
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col移动电话1
            // 
            this.layoutViewField_col移动电话1.EditorPreferredWidth = 109;
            this.layoutViewField_col移动电话1.Location = new Point(170, 98);
            this.layoutViewField_col移动电话1.Name = "layoutViewField_col移动电话1";
            this.layoutViewField_col移动电话1.Size = new Size(170, 24);
            this.layoutViewField_col移动电话1.TextSize = new Size(52, 14);
            this.layoutViewField_col移动电话1.TextToControlDistance = 5;
            // 
            // colTel
            // 
            this.colTel.Caption = "电话号码";
            this.colTel.CustomizationCaption = "电话号码";
            this.colTel.FieldName = "电话号码";
            this.colTel.LayoutViewField = this.layoutViewField_col电话号码1;
            this.colTel.Name = "colTel";
            this.colTel.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col电话号码1
            // 
            this.layoutViewField_col电话号码1.EditorPreferredWidth = 109;
            this.layoutViewField_col电话号码1.Location = new Point(0, 98);
            this.layoutViewField_col电话号码1.Name = "layoutViewField_col电话号码1";
            this.layoutViewField_col电话号码1.Size = new Size(170, 24);
            this.layoutViewField_col电话号码1.TextSize = new Size(52, 14);
            this.layoutViewField_col电话号码1.TextToControlDistance = 5;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "电子邮件";
            this.colEmail.CustomizationCaption = "电子邮件";
            this.colEmail.FieldName = "电子邮件";
            this.colEmail.LayoutViewField = this.layoutViewField_col电子邮件1;
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            // 
            // layoutViewField_col电子邮件1
            // 
            this.layoutViewField_col电子邮件1.EditorPreferredWidth = 279;
            this.layoutViewField_col电子邮件1.Location = new Point(0, 122);
            this.layoutViewField_col电子邮件1.Name = "layoutViewField_col电子邮件1";
            this.layoutViewField_col电子邮件1.Size = new Size(340, 24);
            this.layoutViewField_col电子邮件1.TextSize = new Size(52, 14);
            this.layoutViewField_col电子邮件1.TextToControlDistance = 5;
            // 
            // colView
            // 
            this.colView.Caption = "查看其它信息";
            this.colView.ColumnEdit = this.rbeView;
            this.colView.CustomizationCaption = "查看其它信息";
            this.colView.FieldName = "查看其它信息";
            this.colView.LayoutViewField = this.layoutViewField_col查看其它信息1;
            this.colView.Name = "colView";
            // 
            // rbeView
            // 
            this.rbeView.AutoHeight = false;
            this.rbeView.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("rbeView.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.rbeView.Name = "rbeView";
            this.rbeView.TextEditStyle = TextEditStyles.HideTextEditor;
            this.rbeView.ButtonClick += new ButtonPressedEventHandler(this.rbeView_ButtonClick);
            // 
            // layoutViewField_col查看其它信息1
            // 
            this.layoutViewField_col查看其它信息1.EditorPreferredWidth = 25;
            this.layoutViewField_col查看其它信息1.Location = new Point(230, 0);
            this.layoutViewField_col查看其它信息1.Name = "layoutViewField_col查看其它信息1";
            this.layoutViewField_col查看其它信息1.Size = new Size(110, 26);
            this.layoutViewField_col查看其它信息1.TextSize = new Size(76, 14);
            this.layoutViewField_col查看其它信息1.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new BaseLayoutItem[] {
            this.layoutViewField_col姓名1,
            this.layoutViewField_col任职部门1,
            this.layoutViewField_col办公地点1,
            this.layoutViewField_col家庭住址1,
            this.layoutViewField_col移动电话1,
            this.layoutViewField_col备注1,
            this.layoutViewField_col电子邮件1,
            this.layoutViewField_col电话号码1,
            this.layoutViewField_col生日1,
            this.layoutViewField_col登录帐号1,
            this.layoutViewField_col登录1,
            this.layoutViewField_col职务1,
            this.layoutViewField_col查看其它信息1,
            this.layoutViewField_col主要联系人1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // palFilter
            // 
            this.palFilter.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.palFilter.Controls.Add(this.chkMy);
            this.palFilter.Controls.Add(this.chkSub);
            this.palFilter.Controls.Add(this.bteSearch);
            this.palFilter.Controls.Add(this.btnQuery);
            this.palFilter.Controls.Add(this.chkUnion);
            this.palFilter.Location = new Point(5, 5);
            this.palFilter.Name = "palFilter";
            this.palFilter.Size = new Size(1070, 40);
            this.palFilter.TabIndex = 0;
            // 
            // bteSearch
            // 
            this.bteSearch.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.bteSearch.Location = new Point(325, 10);
            this.bteSearch.Name = "bteSearch";
            this.bteSearch.Properties.AutoHeight = false;
            this.bteSearch.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Delete)});
            this.bteSearch.Properties.NullText = "在此输入供应商名称进行查询…";
            this.bteSearch.Size = new Size(658, 21);
            this.bteSearch.TabIndex = 6;
            this.bteSearch.ButtonClick += new ButtonPressedEventHandler(this.bteSearch_ButtonClick);
            this.bteSearch.KeyDown += new KeyEventHandler(this.bteSearch_Properties_KeyDown);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnQuery.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Image = ((Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new Point(991, 9);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new Size(70, 22);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Click += new EventHandler(this.btnQuery_Click);
            // 
            // chkUnion
            // 
            this.chkUnion.Location = new Point(210, 10);
            this.chkUnion.Name = "chkUnion";
            this.chkUnion.Properties.AutoHeight = false;
            this.chkUnion.Properties.Caption = "共享供应商";
            this.chkUnion.Size = new Size(100, 21);
            this.chkUnion.TabIndex = 3;
            this.chkUnion.Tag = "0";
            this.chkUnion.CheckedChanged += new EventHandler(this.Filter_CheckedChanged);
            // 
            // chkSub
            // 
            this.chkSub.Location = new Point(110, 9);
            this.chkSub.Name = "chkSub";
            this.chkSub.Properties.AutoHeight = false;
            this.chkSub.Properties.Caption = "下属的供应商";
            this.chkSub.Size = new Size(100, 21);
            this.chkSub.TabIndex = 2;
            this.chkSub.Tag = "0";
            this.chkSub.CheckedChanged += new EventHandler(this.Filter_CheckedChanged);
            // 
            // chkMy
            // 
            this.chkMy.EditValue = true;
            this.chkMy.Location = new Point(10, 9);
            this.chkMy.Name = "chkMy";
            this.chkMy.Properties.AutoHeight = false;
            this.chkMy.Properties.Caption = "我的供应商";
            this.chkMy.Size = new Size(100, 21);
            this.chkMy.TabIndex = 1;
            this.chkMy.Tag = "0";
            this.chkMy.CheckedChanged += new EventHandler(this.Filter_CheckedChanged);
            // 
            // MySupplier
            // 
            this.ClientSize = new Size(1080, 629);
            this.Name = "MySupplier";
            this.Load += new EventHandler(this.MySupplier_Load);
            this.Shown += new EventHandler(this.MySupplier_Shown);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grdSupplier)).EndInit();
            ((ISupportInitialize)(this.gdvSupplier)).EndInit();
            ((ISupportInitialize)(this.splInfo)).EndInit();
            this.splInfo.ResumeLayout(false);
            ((ISupportInitialize)(this.grdOther)).EndInit();
            ((ISupportInitialize)(this.gdvOther)).EndInit();
            ((ISupportInitialize)(this.ContactList)).EndInit();
            ((ISupportInitialize)(this.vrdInfo)).EndInit();
            ((ISupportInitialize)(this.grdContact)).EndInit();
            ((ISupportInitialize)(this.glvContact)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col姓名1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col任职部门1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col职务1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col办公地点1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col家庭住址1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col生日1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col备注1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col主要联系人1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col登录帐号1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col登录1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col移动电话1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col电话号码1)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col电子邮件1)).EndInit();
            ((ISupportInitialize)(this.rbeView)).EndInit();
            ((ISupportInitialize)(this.layoutViewField_col查看其它信息1)).EndInit();
            ((ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((ISupportInitialize)(this.palFilter)).EndInit();
            this.palFilter.ResumeLayout(false);
            ((ISupportInitialize)(this.bteSearch.Properties)).EndInit();
            ((ISupportInitialize)(this.chkUnion.Properties)).EndInit();
            ((ISupportInitialize)(this.chkSub.Properties)).EndInit();
            ((ISupportInitialize)(this.chkMy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private GridControl grdSupplier;
        private GridView gdvSupplier;
        private PanelControl palFilter;
        private SimpleButton btnQuery;

        private CheckEdit chkUnion;
        private CheckEdit chkMy;
        private CheckEdit chkSub;
        private ButtonEdit bteSearch;
        private SplitContainerControl splInfo;
        private GridControl grdOther;
        private GridView gdvOther;
        private RepositoryItemLookUpEdit ContactList;
        private GridControl grdContact;
        private LayoutView glvContact;
        private LayoutViewColumn colName;
        private LayoutViewColumn colDepartment;
        private LayoutViewColumn colTitle;
        private LayoutViewColumn colOffice;
        private LayoutViewColumn colHome;
        private LayoutViewColumn colBirthday;
        private LayoutViewColumn colDescription;
        private LayoutViewColumn colIsMaster;
        private LayoutViewColumn colLoginName;
        private LayoutViewColumn colIsLogin;
        private LayoutViewColumn colPhone;
        private LayoutViewColumn colTel;
        private LayoutViewColumn colEmail;
        private LayoutViewColumn colView;
        private RepositoryItemButtonEdit rbeView;
        private VGridControl vrdInfo;
        private LayoutViewField layoutViewField_col姓名1;
        private LayoutViewField layoutViewField_col任职部门1;
        private LayoutViewField layoutViewField_col职务1;
        private LayoutViewField layoutViewField_col办公地点1;
        private LayoutViewField layoutViewField_col家庭住址1;
        private LayoutViewField layoutViewField_col生日1;
        private LayoutViewField layoutViewField_col备注1;
        private LayoutViewField layoutViewField_col主要联系人1;
        private LayoutViewField layoutViewField_col登录帐号1;
        private LayoutViewField layoutViewField_col登录1;
        private LayoutViewField layoutViewField_col移动电话1;
        private LayoutViewField layoutViewField_col电话号码1;
        private LayoutViewField layoutViewField_col电子邮件1;
        private LayoutViewField layoutViewField_col查看其它信息1;
        private LayoutViewCard layoutViewCard1;
    }
}
