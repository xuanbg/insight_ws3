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

namespace Insight.WS.Client.Business.CRM
{
    partial class MyCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyCustomer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCustomer = new DevExpress.XtraGrid.GridControl();
            this.gdvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splInfo = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdOther = new DevExpress.XtraGrid.GridControl();
            this.gdvOther = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ContactList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.vrdInfo = new DevExpress.XtraVerticalGrid.VGridControl();
            this.grdContact = new DevExpress.XtraGrid.GridControl();
            this.glvContact = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colOffice = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colHome = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colBirthday = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colIsMaster = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colLoginName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colIsLogin = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colView = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rbeView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.palFilter = new DevExpress.XtraEditors.PanelControl();
            this.palClass = new DevExpress.XtraEditors.PanelControl();
            this.palStatu = new DevExpress.XtraEditors.PanelControl();
            this.chkClass = new DevExpress.XtraEditors.CheckEdit();
            this.chkStatu = new DevExpress.XtraEditors.CheckEdit();
            this.bteSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.chkUnion = new DevExpress.XtraEditors.CheckEdit();
            this.chkSub = new DevExpress.XtraEditors.CheckEdit();
            this.chkMy = new DevExpress.XtraEditors.CheckEdit();
            this.palType = new DevExpress.XtraEditors.PanelControl();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_col姓名1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col任职部门1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col办公地点1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col家庭住址1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col移动电话1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col备注1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col电子邮件1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col电话号码1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col生日1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col登录帐号1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col登录1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col职务1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col查看其它信息1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_col主要联系人1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splInfo)).BeginInit();
            this.splInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vrdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glvContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palFilter)).BeginInit();
            this.palFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palStatu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSub.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palType)).BeginInit();
            this.palType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col姓名1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col任职部门1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col办公地点1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col家庭住址1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col移动电话1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col备注1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col电子邮件1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col电话号码1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col生日1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col登录帐号1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col登录1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col职务1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col查看其它信息1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col主要联系人1)).BeginInit();
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
            // xtraScrollable
            // 
            this.xtraScrollable.Controls.Add(this.palType);
            this.xtraScrollable.Controls.Add(this.palFilter);
            this.xtraScrollable.Controls.Add(this.splMain);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splMain.Horizontal = false;
            this.splMain.Location = new System.Drawing.Point(5, 110);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grdCustomer);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.splInfo);
            this.splMain.Panel2.MinSize = 260;
            this.splMain.Size = new System.Drawing.Size(1070, 485);
            this.splMain.SplitterPosition = 260;
            this.splMain.TabIndex = 0;
            // 
            // grdCustomer
            // 
            this.grdCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomer.Location = new System.Drawing.Point(0, 0);
            this.grdCustomer.MainView = this.gdvCustomer;
            this.grdCustomer.Name = "grdCustomer";
            this.grdCustomer.Size = new System.Drawing.Size(1070, 220);
            this.grdCustomer.TabIndex = 8;
            this.grdCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvCustomer});
            // 
            // gdvCustomer
            // 
            this.gdvCustomer.GridControl = this.grdCustomer;
            this.gdvCustomer.Name = "gdvCustomer";
            this.gdvCustomer.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvCustomer_FocusedRowObjectChanged);
            this.gdvCustomer.DoubleClick += new System.EventHandler(this.gdvCustomer_DoubleClick);
            // 
            // splInfo
            // 
            this.splInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splInfo.Location = new System.Drawing.Point(0, 0);
            this.splInfo.Name = "splInfo";
            this.splInfo.Panel1.Controls.Add(this.grdOther);
            this.splInfo.Panel1.Controls.Add(this.vrdInfo);
            this.splInfo.Panel1.MinSize = 320;
            this.splInfo.Panel2.Controls.Add(this.grdContact);
            this.splInfo.Panel2.MinSize = 200;
            this.splInfo.Size = new System.Drawing.Size(1070, 260);
            this.splInfo.SplitterPosition = 320;
            this.splInfo.TabIndex = 1;
            this.splInfo.Text = "splitContainerControl2";
            // 
            // grdOther
            // 
            this.grdOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOther.Location = new System.Drawing.Point(0, 0);
            this.grdOther.MainView = this.gdvOther;
            this.grdOther.Name = "grdOther";
            this.grdOther.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ContactList});
            this.grdOther.Size = new System.Drawing.Size(320, 260);
            this.grdOther.TabIndex = 0;
            this.grdOther.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvOther});
            this.grdOther.Visible = false;
            // 
            // gdvOther
            // 
            this.gdvOther.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gdvOther.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdvOther.GridControl = this.grdOther;
            this.gdvOther.Name = "gdvOther";
            this.gdvOther.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gdvOther.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gdvOther.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            // 
            // ContactList
            // 
            this.ContactList.AutoHeight = false;
            this.ContactList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ContactList.Name = "ContactList";
            this.ContactList.NullText = "";
            this.ContactList.PopupFormMinSize = new System.Drawing.Size(65, 0);
            this.ContactList.PopupWidth = 80;
            this.ContactList.ShowHeader = false;
            this.ContactList.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // vrdInfo
            // 
            this.vrdInfo.Appearance.BandBorder.Options.UseTextOptions = true;
            this.vrdInfo.Appearance.BandBorder.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.vrdInfo.Appearance.RowHeaderPanel.Options.UseTextOptions = true;
            this.vrdInfo.Appearance.RowHeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.vrdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vrdInfo.Location = new System.Drawing.Point(0, 0);
            this.vrdInfo.Name = "vrdInfo";
            this.vrdInfo.OptionsBehavior.Editable = false;
            this.vrdInfo.OptionsBehavior.ResizeHeaderPanel = false;
            this.vrdInfo.OptionsBehavior.ResizeRowHeaders = false;
            this.vrdInfo.OptionsBehavior.ResizeRowValues = false;
            this.vrdInfo.OptionsView.FixRowHeaderPanelWidth = true;
            this.vrdInfo.OptionsView.MinRowAutoHeight = 20;
            this.vrdInfo.Size = new System.Drawing.Size(320, 260);
            this.vrdInfo.TabIndex = 9;
            // 
            // grdContact
            // 
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.Location = new System.Drawing.Point(0, 0);
            this.grdContact.MainView = this.glvContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rbeView});
            this.grdContact.Size = new System.Drawing.Size(745, 260);
            this.grdContact.TabIndex = 10;
            this.grdContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.glvContact});
            this.grdContact.DoubleClick += new System.EventHandler(this.glvContact_DoubleClick);
            // 
            // glvContact
            // 
            this.glvContact.CardMinSize = new System.Drawing.Size(340, 239);
            this.glvContact.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
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
            this.glvContact.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.glvContact.OptionsCustomization.AllowFilter = false;
            this.glvContact.OptionsCustomization.AllowSort = false;
            this.glvContact.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.glvContact.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.glvContact.OptionsView.ShowCardCaption = false;
            this.glvContact.OptionsView.ShowCardExpandButton = false;
            this.glvContact.OptionsView.ShowCardFieldBorders = true;
            this.glvContact.OptionsView.ShowHeaderPanel = false;
            this.glvContact.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Row;
            this.glvContact.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colView, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.glvContact.TemplateCard = this.layoutViewCard1;
            this.glvContact.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.glvContact_FocusedRowObjectChanged);
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
            // colDepartment
            // 
            this.colDepartment.Caption = "任职部门";
            this.colDepartment.CustomizationCaption = "任职部门";
            this.colDepartment.FieldName = "任职部门";
            this.colDepartment.LayoutViewField = this.layoutViewField_col任职部门1;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowEdit = false;
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
            // colOffice
            // 
            this.colOffice.Caption = "办公地点";
            this.colOffice.CustomizationCaption = "办公地点";
            this.colOffice.FieldName = "办公地点";
            this.colOffice.LayoutViewField = this.layoutViewField_col办公地点1;
            this.colOffice.Name = "colOffice";
            this.colOffice.OptionsColumn.AllowEdit = false;
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
            // colBirthday
            // 
            this.colBirthday.Caption = "生日";
            this.colBirthday.CustomizationCaption = "生日";
            this.colBirthday.FieldName = "生日";
            this.colBirthday.LayoutViewField = this.layoutViewField_col生日1;
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.OptionsColumn.AllowEdit = false;
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
            // colIsMaster
            // 
            this.colIsMaster.Caption = "主要联系人";
            this.colIsMaster.CustomizationCaption = "主要联系人";
            this.colIsMaster.FieldName = "主要联系人";
            this.colIsMaster.LayoutViewField = this.layoutViewField_col主要联系人1;
            this.colIsMaster.Name = "colIsMaster";
            this.colIsMaster.OptionsColumn.AllowEdit = false;
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
            // colIsLogin
            // 
            this.colIsLogin.Caption = "登录";
            this.colIsLogin.CustomizationCaption = "登录";
            this.colIsLogin.FieldName = "登录";
            this.colIsLogin.LayoutViewField = this.layoutViewField_col登录1;
            this.colIsLogin.Name = "colIsLogin";
            this.colIsLogin.OptionsColumn.AllowEdit = false;
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
            // colTel
            // 
            this.colTel.Caption = "电话号码";
            this.colTel.CustomizationCaption = "电话号码";
            this.colTel.FieldName = "电话号码";
            this.colTel.LayoutViewField = this.layoutViewField_col电话号码1;
            this.colTel.Name = "colTel";
            this.colTel.OptionsColumn.AllowEdit = false;
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
            this.rbeView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("rbeView.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.rbeView.Name = "rbeView";
            this.rbeView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbeView.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbeView_ButtonClick);
            // 
            // palFilter
            // 
            this.palFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.palFilter.Controls.Add(this.palClass);
            this.palFilter.Controls.Add(this.palStatu);
            this.palFilter.Controls.Add(this.chkClass);
            this.palFilter.Controls.Add(this.chkStatu);
            this.palFilter.Controls.Add(this.bteSearch);
            this.palFilter.Controls.Add(this.btnQuery);
            this.palFilter.Location = new System.Drawing.Point(125, 5);
            this.palFilter.Name = "palFilter";
            this.palFilter.Size = new System.Drawing.Size(950, 100);
            this.palFilter.TabIndex = 0;
            // 
            // palClass
            // 
            this.palClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.palClass.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palClass.Appearance.Options.UseBackColor = true;
            this.palClass.Location = new System.Drawing.Point(75, 68);
            this.palClass.Name = "palClass";
            this.palClass.Size = new System.Drawing.Size(866, 23);
            this.palClass.TabIndex = 5;
            // 
            // palStatu
            // 
            this.palStatu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.palStatu.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.palStatu.Appearance.Options.UseBackColor = true;
            this.palStatu.Location = new System.Drawing.Point(75, 38);
            this.palStatu.Name = "palStatu";
            this.palStatu.Size = new System.Drawing.Size(866, 23);
            this.palStatu.TabIndex = 4;
            // 
            // chkClass
            // 
            this.chkClass.EditValue = true;
            this.chkClass.Location = new System.Drawing.Point(9, 69);
            this.chkClass.Name = "chkClass";
            this.chkClass.Properties.AutoHeight = false;
            this.chkClass.Properties.Caption = "类型：";
            this.chkClass.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkClass.Size = new System.Drawing.Size(55, 21);
            this.chkClass.TabIndex = 5;
            this.chkClass.Tag = "0";
            this.chkClass.CheckedChanged += new System.EventHandler(this.chkClass_CheckedChanged);
            // 
            // chkStatu
            // 
            this.chkStatu.EditValue = true;
            this.chkStatu.Location = new System.Drawing.Point(9, 39);
            this.chkStatu.Name = "chkStatu";
            this.chkStatu.Properties.AutoHeight = false;
            this.chkStatu.Properties.Caption = "状态：";
            this.chkStatu.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkStatu.Size = new System.Drawing.Size(55, 21);
            this.chkStatu.TabIndex = 4;
            this.chkStatu.Tag = "0";
            this.chkStatu.CheckedChanged += new System.EventHandler(this.chkStatu_CheckedChanged);
            // 
            // bteSearch
            // 
            this.bteSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bteSearch.Location = new System.Drawing.Point(10, 10);
            this.bteSearch.Name = "bteSearch";
            this.bteSearch.Properties.AutoHeight = false;
            this.bteSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.bteSearch.Properties.NullText = "在此输入客户名称进行查询…";
            this.bteSearch.Size = new System.Drawing.Size(853, 21);
            this.bteSearch.TabIndex = 6;
            this.bteSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteSearch_ButtonClick);
            this.bteSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteSearch_Properties_KeyDown);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(871, 9);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(70, 22);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // chkUnion
            // 
            this.chkUnion.Location = new System.Drawing.Point(12, 69);
            this.chkUnion.Name = "chkUnion";
            this.chkUnion.Properties.AutoHeight = false;
            this.chkUnion.Properties.Caption = "共享客户";
            this.chkUnion.Size = new System.Drawing.Size(100, 21);
            this.chkUnion.TabIndex = 3;
            this.chkUnion.Tag = "0";
            this.chkUnion.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkSub
            // 
            this.chkSub.Location = new System.Drawing.Point(12, 39);
            this.chkSub.Name = "chkSub";
            this.chkSub.Properties.AutoHeight = false;
            this.chkSub.Properties.Caption = "下属的客户";
            this.chkSub.Size = new System.Drawing.Size(100, 21);
            this.chkSub.TabIndex = 2;
            this.chkSub.Tag = "0";
            this.chkSub.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkMy
            // 
            this.chkMy.EditValue = true;
            this.chkMy.Location = new System.Drawing.Point(12, 9);
            this.chkMy.Name = "chkMy";
            this.chkMy.Properties.AutoHeight = false;
            this.chkMy.Properties.Caption = "我的客户";
            this.chkMy.Size = new System.Drawing.Size(100, 21);
            this.chkMy.TabIndex = 1;
            this.chkMy.Tag = "0";
            this.chkMy.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // palType
            // 
            this.palType.Controls.Add(this.chkMy);
            this.palType.Controls.Add(this.chkSub);
            this.palType.Controls.Add(this.chkUnion);
            this.palType.Location = new System.Drawing.Point(5, 5);
            this.palType.Name = "palType";
            this.palType.Size = new System.Drawing.Size(115, 100);
            this.palType.TabIndex = 0;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
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
            // layoutViewField_col姓名1
            // 
            this.layoutViewField_col姓名1.EditorPreferredWidth = 93;
            this.layoutViewField_col姓名1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_col姓名1.Name = "layoutViewField_col姓名1";
            this.layoutViewField_col姓名1.Size = new System.Drawing.Size(130, 26);
            this.layoutViewField_col姓名1.TextSize = new System.Drawing.Size(28, 14);
            // 
            // layoutViewField_col任职部门1
            // 
            this.layoutViewField_col任职部门1.EditorPreferredWidth = 149;
            this.layoutViewField_col任职部门1.Location = new System.Drawing.Point(130, 26);
            this.layoutViewField_col任职部门1.Name = "layoutViewField_col任职部门1";
            this.layoutViewField_col任职部门1.Size = new System.Drawing.Size(210, 24);
            this.layoutViewField_col任职部门1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col办公地点1
            // 
            this.layoutViewField_col办公地点1.EditorPreferredWidth = 279;
            this.layoutViewField_col办公地点1.Location = new System.Drawing.Point(0, 50);
            this.layoutViewField_col办公地点1.Name = "layoutViewField_col办公地点1";
            this.layoutViewField_col办公地点1.Size = new System.Drawing.Size(340, 24);
            this.layoutViewField_col办公地点1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col家庭住址1
            // 
            this.layoutViewField_col家庭住址1.EditorPreferredWidth = 279;
            this.layoutViewField_col家庭住址1.Location = new System.Drawing.Point(0, 74);
            this.layoutViewField_col家庭住址1.Name = "layoutViewField_col家庭住址1";
            this.layoutViewField_col家庭住址1.Size = new System.Drawing.Size(340, 24);
            this.layoutViewField_col家庭住址1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col移动电话1
            // 
            this.layoutViewField_col移动电话1.EditorPreferredWidth = 109;
            this.layoutViewField_col移动电话1.Location = new System.Drawing.Point(170, 98);
            this.layoutViewField_col移动电话1.Name = "layoutViewField_col移动电话1";
            this.layoutViewField_col移动电话1.Size = new System.Drawing.Size(170, 24);
            this.layoutViewField_col移动电话1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col备注1
            // 
            this.layoutViewField_col备注1.EditorPreferredWidth = 336;
            this.layoutViewField_col备注1.Location = new System.Drawing.Point(0, 170);
            this.layoutViewField_col备注1.Name = "layoutViewField_col备注1";
            this.layoutViewField_col备注1.Size = new System.Drawing.Size(340, 49);
            this.layoutViewField_col备注1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutViewField_col备注1.TextSize = new System.Drawing.Size(28, 14);
            // 
            // layoutViewField_col电子邮件1
            // 
            this.layoutViewField_col电子邮件1.EditorPreferredWidth = 279;
            this.layoutViewField_col电子邮件1.Location = new System.Drawing.Point(0, 122);
            this.layoutViewField_col电子邮件1.Name = "layoutViewField_col电子邮件1";
            this.layoutViewField_col电子邮件1.Size = new System.Drawing.Size(340, 24);
            this.layoutViewField_col电子邮件1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col电话号码1
            // 
            this.layoutViewField_col电话号码1.EditorPreferredWidth = 109;
            this.layoutViewField_col电话号码1.Location = new System.Drawing.Point(0, 98);
            this.layoutViewField_col电话号码1.Name = "layoutViewField_col电话号码1";
            this.layoutViewField_col电话号码1.Size = new System.Drawing.Size(170, 24);
            this.layoutViewField_col电话号码1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col生日1
            // 
            this.layoutViewField_col生日1.EditorPreferredWidth = 63;
            this.layoutViewField_col生日1.Location = new System.Drawing.Point(130, 0);
            this.layoutViewField_col生日1.Name = "layoutViewField_col生日1";
            this.layoutViewField_col生日1.Size = new System.Drawing.Size(100, 26);
            this.layoutViewField_col生日1.TextSize = new System.Drawing.Size(28, 14);
            // 
            // layoutViewField_col登录帐号1
            // 
            this.layoutViewField_col登录帐号1.EditorPreferredWidth = 109;
            this.layoutViewField_col登录帐号1.Location = new System.Drawing.Point(0, 146);
            this.layoutViewField_col登录帐号1.Name = "layoutViewField_col登录帐号1";
            this.layoutViewField_col登录帐号1.Size = new System.Drawing.Size(170, 24);
            this.layoutViewField_col登录帐号1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutViewField_col登录1
            // 
            this.layoutViewField_col登录1.EditorPreferredWidth = 23;
            this.layoutViewField_col登录1.Location = new System.Drawing.Point(170, 146);
            this.layoutViewField_col登录1.Name = "layoutViewField_col登录1";
            this.layoutViewField_col登录1.Size = new System.Drawing.Size(60, 24);
            this.layoutViewField_col登录1.TextSize = new System.Drawing.Size(28, 14);
            // 
            // layoutViewField_col职务1
            // 
            this.layoutViewField_col职务1.EditorPreferredWidth = 93;
            this.layoutViewField_col职务1.Location = new System.Drawing.Point(0, 26);
            this.layoutViewField_col职务1.Name = "layoutViewField_col职务1";
            this.layoutViewField_col职务1.Size = new System.Drawing.Size(130, 24);
            this.layoutViewField_col职务1.TextSize = new System.Drawing.Size(28, 14);
            // 
            // layoutViewField_col查看其它信息1
            // 
            this.layoutViewField_col查看其它信息1.EditorPreferredWidth = 25;
            this.layoutViewField_col查看其它信息1.Location = new System.Drawing.Point(230, 0);
            this.layoutViewField_col查看其它信息1.Name = "layoutViewField_col查看其它信息1";
            this.layoutViewField_col查看其它信息1.Size = new System.Drawing.Size(110, 26);
            this.layoutViewField_col查看其它信息1.TextSize = new System.Drawing.Size(76, 14);
            // 
            // layoutViewField_col主要联系人1
            // 
            this.layoutViewField_col主要联系人1.EditorPreferredWidth = 37;
            this.layoutViewField_col主要联系人1.Location = new System.Drawing.Point(230, 146);
            this.layoutViewField_col主要联系人1.Name = "layoutViewField_col主要联系人1";
            this.layoutViewField_col主要联系人1.Size = new System.Drawing.Size(110, 24);
            this.layoutViewField_col主要联系人1.TextSize = new System.Drawing.Size(64, 14);
            // 
            // MyCustomer
            // 
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "MyCustomer";
            this.Load += new System.EventHandler(this.MyCustomer_Load);
            this.Shown += new System.EventHandler(this.MyCustomer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splInfo)).EndInit();
            this.splInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vrdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glvContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palFilter)).EndInit();
            this.palFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palStatu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSub.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palType)).EndInit();
            this.palType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col姓名1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col任职部门1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col办公地点1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col家庭住址1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col移动电话1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col备注1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col电子邮件1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col电话号码1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col生日1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col登录帐号1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col登录1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col职务1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col查看其它信息1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col主要联系人1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private GridControl grdCustomer;
        private GridView gdvCustomer;
        private PanelControl palFilter;
        private SimpleButton btnQuery;

        private CheckEdit chkUnion;
        private CheckEdit chkMy;
        private PanelControl palStatu;
        private PanelControl palClass;
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
        private PanelControl palType;
        private CheckEdit chkClass;
        private CheckEdit chkStatu;
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
