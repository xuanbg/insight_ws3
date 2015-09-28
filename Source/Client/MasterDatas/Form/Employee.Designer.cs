using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.Events;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;
using Padding = DevExpress.XtraLayout.Utils.Padding;

namespace Insight.WS.Client.MasterDatas
{
    partial class Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpOrg = new DevExpress.XtraEditors.GroupControl();
            this.treOrgList = new DevExpress.XtraTreeList.TreeList();
            this.grdEmployee = new DevExpress.XtraGrid.GridControl();
            this.gdvEmployee = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colPhoto = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colLeader = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colWorkType = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colIdCardNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colLoginUser = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colAlias = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colEntryDate = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colDimissionDate = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colMail = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colOfficeAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colHomeAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.panSplitT = new DevExpress.XtraEditors.PanelControl();
            this.panSearch = new DevExpress.XtraEditors.PanelControl();
            this.cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.bteSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.imgCard = new DevExpress.Utils.ImageCollection();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.lovName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovLeader = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovIdCardNo = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovPhoto = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.item4 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lovTitle = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovGender = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovStatus = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovLoginUser = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.item5 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lovCode = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovWorkType = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovAlias = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.item6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lovPhone = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovMail = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovOffice = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovHome = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovTel = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovEntryDate = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovDimissionDate = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lovDescription = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOrg)).BeginInit();
            this.grpOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSplitT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSearch)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovLeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovIdCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovLoginUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovWorkType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovAlias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovDimissionDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Close.png");
            this.imgFolderNode.Images.SetKeyName(2, "Open.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Close.png");
            this.imgCategoryNode.Images.SetKeyName(2, "Open.png");
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
            this.xtraScrollable.Controls.Add(this.splMain);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpOrg);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.grdEmployee);
            this.splMain.Panel2.Controls.Add(this.panSplitT);
            this.splMain.Panel2.Controls.Add(this.panSearch);
            this.splMain.Panel2.MinSize = 500;
            this.splMain.Size = new System.Drawing.Size(1070, 590);
            this.splMain.SplitterPosition = 275;
            this.splMain.TabIndex = 0;
            // 
            // grpOrg
            // 
            this.grpOrg.Controls.Add(this.treOrgList);
            this.grpOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrg.Location = new System.Drawing.Point(0, 0);
            this.grpOrg.Name = "grpOrg";
            this.grpOrg.Size = new System.Drawing.Size(275, 590);
            this.grpOrg.TabIndex = 0;
            this.grpOrg.Text = "组织机构";
            // 
            // treOrgList
            // 
            this.treOrgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treOrgList.Location = new System.Drawing.Point(2, 21);
            this.treOrgList.Name = "treOrgList";
            this.treOrgList.OptionsView.ShowColumns = false;
            this.treOrgList.SelectImageList = this.imgOrgTreeNode;
            this.treOrgList.Size = new System.Drawing.Size(271, 567);
            this.treOrgList.TabIndex = 0;
            this.treOrgList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            // 
            // grdEmployee
            // 
            this.grdEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmployee.Location = new System.Drawing.Point(0, 44);
            this.grdEmployee.MainView = this.gdvEmployee;
            this.grdEmployee.Name = "grdEmployee";
            this.grdEmployee.Size = new System.Drawing.Size(790, 546);
            this.grdEmployee.TabIndex = 3;
            this.grdEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvEmployee});
            // 
            // gdvEmployee
            // 
            this.gdvEmployee.CardMinSize = new System.Drawing.Size(350, 450);
            this.gdvEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colPhoto,
            this.colName,
            this.colGender,
            this.colTitle,
            this.colStatus,
            this.colLeader,
            this.colCode,
            this.colWorkType,
            this.colIdCardNo,
            this.colLoginUser,
            this.colAlias,
            this.colEntryDate,
            this.colDimissionDate,
            this.colTel,
            this.colPhone,
            this.colMail,
            this.colOfficeAddress,
            this.colHomeAddress,
            this.colDescription});
            this.gdvEmployee.GridControl = this.grdEmployee;
            this.gdvEmployee.Name = "gdvEmployee";
            this.gdvEmployee.OptionsBehavior.AllowPanCards = false;
            this.gdvEmployee.OptionsBehavior.AllowRuntimeCustomization = false;
            this.gdvEmployee.OptionsBehavior.Editable = false;
            this.gdvEmployee.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gdvEmployee.OptionsCustomization.AllowFilter = false;
            this.gdvEmployee.OptionsCustomization.AllowSort = false;
            this.gdvEmployee.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.gdvEmployee.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.gdvEmployee.OptionsView.ShowCardExpandButton = false;
            this.gdvEmployee.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Row;
            this.gdvEmployee.TemplateCard = this.layoutViewCard1;
            this.gdvEmployee.CustomCardCaptionImage += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCardCaptionImageEventHandler(this.gdvEmployee_CustomCardCaptionImage);
            this.gdvEmployee.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvEmployee_FocusedRowObjectChanged);
            this.gdvEmployee.DoubleClick += new System.EventHandler(this.gdvEmployee_DoubleClick);
            // 
            // colPhoto
            // 
            this.colPhoto.CustomizationCaption = "Photo";
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.LayoutViewField = this.lovPhoto;
            this.colPhoto.Name = "colPhoto";
            // 
            // colName
            // 
            this.colName.Caption = "姓名";
            this.colName.CustomizationCaption = "姓名";
            this.colName.FieldName = "姓名";
            this.colName.LayoutViewField = this.lovName;
            this.colName.Name = "colName";
            // 
            // colGender
            // 
            this.colGender.Caption = "性别";
            this.colGender.CustomizationCaption = "性别";
            this.colGender.FieldName = "性别";
            this.colGender.LayoutViewField = this.lovGender;
            this.colGender.Name = "colGender";
            // 
            // colTitle
            // 
            this.colTitle.Caption = "职位";
            this.colTitle.CustomizationCaption = "职位";
            this.colTitle.FieldName = "职位";
            this.colTitle.LayoutViewField = this.lovTitle;
            this.colTitle.Name = "colTitle";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "状态";
            this.colStatus.CustomizationCaption = "状态";
            this.colStatus.FieldName = "状态";
            this.colStatus.LayoutViewField = this.lovStatus;
            this.colStatus.Name = "colStatus";
            // 
            // colLeader
            // 
            this.colLeader.Caption = "直接领导";
            this.colLeader.CustomizationCaption = "直接领导";
            this.colLeader.FieldName = "直接领导";
            this.colLeader.LayoutViewField = this.lovLeader;
            this.colLeader.Name = "colLeader";
            // 
            // colCode
            // 
            this.colCode.Caption = "工号";
            this.colCode.CustomizationCaption = "工号";
            this.colCode.FieldName = "工号";
            this.colCode.LayoutViewField = this.lovCode;
            this.colCode.Name = "colCode";
            // 
            // colWorkType
            // 
            this.colWorkType.Caption = "工种";
            this.colWorkType.CustomizationCaption = "工种";
            this.colWorkType.FieldName = "工种";
            this.colWorkType.LayoutViewField = this.lovWorkType;
            this.colWorkType.Name = "colWorkType";
            // 
            // colIdCardNo
            // 
            this.colIdCardNo.Caption = "身份证号";
            this.colIdCardNo.CustomizationCaption = "身份证号";
            this.colIdCardNo.FieldName = "身份证号";
            this.colIdCardNo.LayoutViewField = this.lovIdCardNo;
            this.colIdCardNo.Name = "colIdCardNo";
            // 
            // colLoginUser
            // 
            this.colLoginUser.Caption = "登录";
            this.colLoginUser.CustomizationCaption = "登录";
            this.colLoginUser.FieldName = "登录";
            this.colLoginUser.LayoutViewField = this.lovLoginUser;
            this.colLoginUser.Name = "colLoginUser";
            // 
            // colAlias
            // 
            this.colAlias.Caption = "登录帐号";
            this.colAlias.CustomizationCaption = "登录帐号";
            this.colAlias.FieldName = "登录帐号";
            this.colAlias.LayoutViewField = this.lovAlias;
            this.colAlias.Name = "colAlias";
            // 
            // colEntryDate
            // 
            this.colEntryDate.Caption = "入职日期";
            this.colEntryDate.CustomizationCaption = "入职日期";
            this.colEntryDate.FieldName = "入职日期";
            this.colEntryDate.LayoutViewField = this.lovEntryDate;
            this.colEntryDate.Name = "colEntryDate";
            // 
            // colDimissionDate
            // 
            this.colDimissionDate.Caption = "离职日期";
            this.colDimissionDate.CustomizationCaption = "离职日期";
            this.colDimissionDate.FieldName = "离职日期";
            this.colDimissionDate.LayoutViewField = this.lovDimissionDate;
            this.colDimissionDate.Name = "colDimissionDate";
            // 
            // colTel
            // 
            this.colTel.Caption = "电话号码";
            this.colTel.CustomizationCaption = "电话号码";
            this.colTel.FieldName = "电话号码";
            this.colTel.LayoutViewField = this.lovTel;
            this.colTel.Name = "colTel";
            // 
            // colPhone
            // 
            this.colPhone.Caption = "移动电话";
            this.colPhone.CustomizationCaption = "移动电话";
            this.colPhone.FieldName = "移动电话";
            this.colPhone.LayoutViewField = this.lovPhone;
            this.colPhone.Name = "colPhone";
            // 
            // colMail
            // 
            this.colMail.Caption = "电子邮件";
            this.colMail.CustomizationCaption = "电子邮件";
            this.colMail.FieldName = "电子邮件";
            this.colMail.LayoutViewField = this.lovMail;
            this.colMail.Name = "colMail";
            // 
            // colOfficeAddress
            // 
            this.colOfficeAddress.Caption = "办公地点";
            this.colOfficeAddress.CustomizationCaption = "办公地点";
            this.colOfficeAddress.FieldName = "办公地点";
            this.colOfficeAddress.LayoutViewField = this.lovOffice;
            this.colOfficeAddress.Name = "colOfficeAddress";
            // 
            // colHomeAddress
            // 
            this.colHomeAddress.Caption = "家庭住址";
            this.colHomeAddress.CustomizationCaption = "家庭住址";
            this.colHomeAddress.FieldName = "家庭住址";
            this.colHomeAddress.LayoutViewField = this.lovHome;
            this.colHomeAddress.Name = "colHomeAddress";
            // 
            // colDescription
            // 
            this.colDescription.Caption = "备注";
            this.colDescription.CustomizationCaption = "备注";
            this.colDescription.FieldName = "备注";
            this.colDescription.LayoutViewField = this.lovDescription;
            this.colDescription.Name = "colDescription";
            // 
            // panSplitT
            // 
            this.panSplitT.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panSplitT.Appearance.Options.UseBackColor = true;
            this.panSplitT.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panSplitT.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSplitT.Location = new System.Drawing.Point(0, 39);
            this.panSplitT.Name = "panSplitT";
            this.panSplitT.Size = new System.Drawing.Size(790, 5);
            this.panSplitT.TabIndex = 0;
            // 
            // panSearch
            // 
            this.panSearch.Controls.Add(this.cmbStatus);
            this.panSearch.Controls.Add(this.btnSearch);
            this.panSearch.Controls.Add(this.bteSearch);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSearch.Location = new System.Drawing.Point(0, 0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(790, 39);
            this.panSearch.TabIndex = 0;
            // 
            // cmbStatus
            // 
            this.cmbStatus.EditValue = "在职";
            this.cmbStatus.Location = new System.Drawing.Point(9, 9);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmbStatus.Properties.AutoHeight = false;
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Properties.Items.AddRange(new object[] {
            "在职",
            "离职"});
            this.cmbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbStatus.Size = new System.Drawing.Size(62, 21);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(712, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查  询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bteSearch
            // 
            this.bteSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bteSearch.Location = new System.Drawing.Point(79, 9);
            this.bteSearch.Name = "bteSearch";
            this.bteSearch.Properties.AutoHeight = false;
            this.bteSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.bteSearch.Properties.NullText = "在此输入员工姓名进行查询…";
            this.bteSearch.Properties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteditSearch_Properties_KeyDown);
            this.bteSearch.Size = new System.Drawing.Size(625, 21);
            this.bteSearch.TabIndex = 1;
            this.bteSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteSearch_ButtonClick);
            // 
            // imgCard
            // 
            this.imgCard.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCard.ImageStream")));
            this.imgCard.InsertGalleryImage("employee_16x16.png", "images/people/employee_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/employee_16x16.png"), 0);
            this.imgCard.Images.SetKeyName(0, "employee_16x16.png");
            this.imgCard.Images.SetKeyName(1, "Employee_G.png");
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lovName,
            this.lovLeader,
            this.lovIdCardNo,
            this.lovPhoto,
            this.item4,
            this.lovTitle,
            this.lovGender,
            this.lovStatus,
            this.lovLoginUser,
            this.item5,
            this.lovCode,
            this.lovWorkType,
            this.lovAlias,
            this.item6});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // lovName
            // 
            this.lovName.EditorPreferredWidth = 79;
            this.lovName.Location = new System.Drawing.Point(126, 0);
            this.lovName.Name = "lovName";
            this.lovName.Size = new System.Drawing.Size(120, 28);
            this.lovName.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovName.TextSize = new System.Drawing.Size(28, 14);
            // 
            // lovLeader
            // 
            this.lovLeader.EditorPreferredWidth = 155;
            this.lovLeader.Location = new System.Drawing.Point(126, 84);
            this.lovLeader.Name = "lovLeader";
            this.lovLeader.Size = new System.Drawing.Size(220, 28);
            this.lovLeader.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovLeader.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovIdCardNo
            // 
            this.lovIdCardNo.EditorPreferredWidth = 155;
            this.lovIdCardNo.Location = new System.Drawing.Point(126, 112);
            this.lovIdCardNo.Name = "lovIdCardNo";
            this.lovIdCardNo.Size = new System.Drawing.Size(220, 28);
            this.lovIdCardNo.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovIdCardNo.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovPhoto
            // 
            this.lovPhoto.EditorPreferredWidth = 112;
            this.lovPhoto.Location = new System.Drawing.Point(0, 0);
            this.lovPhoto.MaxSize = new System.Drawing.Size(120, 150);
            this.lovPhoto.MinSize = new System.Drawing.Size(120, 150);
            this.lovPhoto.Name = "lovPhoto";
            this.lovPhoto.Size = new System.Drawing.Size(120, 168);
            this.lovPhoto.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lovPhoto.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovPhoto.TextSize = new System.Drawing.Size(0, 0);
            this.lovPhoto.TextVisible = false;
            // 
            // item4
            // 
            this.item4.AllowHotTrack = false;
            this.item4.CustomizationFormText = "item4";
            this.item4.Location = new System.Drawing.Point(0, 168);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(346, 6);
            this.item4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            // 
            // lovTitle
            // 
            this.lovTitle.EditorPreferredWidth = 79;
            this.lovTitle.Location = new System.Drawing.Point(126, 28);
            this.lovTitle.Name = "lovTitle";
            this.lovTitle.Size = new System.Drawing.Size(120, 28);
            this.lovTitle.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovTitle.TextSize = new System.Drawing.Size(28, 14);
            // 
            // lovGender
            // 
            this.lovGender.EditorPreferredWidth = 59;
            this.lovGender.Location = new System.Drawing.Point(246, 0);
            this.lovGender.Name = "lovGender";
            this.lovGender.Size = new System.Drawing.Size(100, 28);
            this.lovGender.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovGender.TextSize = new System.Drawing.Size(28, 14);
            // 
            // lovStatus
            // 
            this.lovStatus.EditorPreferredWidth = 59;
            this.lovStatus.Location = new System.Drawing.Point(246, 28);
            this.lovStatus.Name = "lovStatus";
            this.lovStatus.Size = new System.Drawing.Size(100, 28);
            this.lovStatus.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovStatus.TextSize = new System.Drawing.Size(28, 14);
            // 
            // lovLoginUser
            // 
            this.lovLoginUser.EditorPreferredWidth = 29;
            this.lovLoginUser.Location = new System.Drawing.Point(276, 140);
            this.lovLoginUser.Name = "lovLoginUser";
            this.lovLoginUser.Size = new System.Drawing.Size(70, 28);
            this.lovLoginUser.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovLoginUser.TextSize = new System.Drawing.Size(28, 14);
            // 
            // item5
            // 
            this.item5.AllowHotTrack = false;
            this.item5.CustomizationFormText = "item5";
            this.item5.Location = new System.Drawing.Point(120, 0);
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(6, 168);
            this.item5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            // 
            // lovCode
            // 
            this.lovCode.EditorPreferredWidth = 79;
            this.lovCode.Location = new System.Drawing.Point(126, 56);
            this.lovCode.Name = "lovCode";
            this.lovCode.Size = new System.Drawing.Size(120, 28);
            this.lovCode.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovCode.TextSize = new System.Drawing.Size(28, 14);
            // 
            // lovWorkType
            // 
            this.lovWorkType.EditorPreferredWidth = 59;
            this.lovWorkType.Location = new System.Drawing.Point(246, 56);
            this.lovWorkType.Name = "lovWorkType";
            this.lovWorkType.Size = new System.Drawing.Size(100, 28);
            this.lovWorkType.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovWorkType.TextSize = new System.Drawing.Size(28, 14);
            // 
            // lovAlias
            // 
            this.lovAlias.EditorPreferredWidth = 85;
            this.lovAlias.Location = new System.Drawing.Point(126, 140);
            this.lovAlias.Name = "lovAlias";
            this.lovAlias.Size = new System.Drawing.Size(150, 28);
            this.lovAlias.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovAlias.TextSize = new System.Drawing.Size(52, 14);
            // 
            // item6
            // 
            this.item6.CustomizationFormText = "联系方式";
            this.item6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lovPhone,
            this.lovMail,
            this.lovOffice,
            this.lovHome,
            this.lovTel,
            this.lovEntryDate,
            this.lovDimissionDate,
            this.lovDescription});
            this.item6.Location = new System.Drawing.Point(0, 174);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(346, 251);
            this.item6.Text = "详细信息";
            // 
            // lovPhone
            // 
            this.lovPhone.EditorPreferredWidth = 97;
            this.lovPhone.Location = new System.Drawing.Point(160, 28);
            this.lovPhone.Name = "lovPhone";
            this.lovPhone.Size = new System.Drawing.Size(162, 28);
            this.lovPhone.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovPhone.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovMail
            // 
            this.lovMail.EditorPreferredWidth = 257;
            this.lovMail.Location = new System.Drawing.Point(0, 56);
            this.lovMail.Name = "lovMail";
            this.lovMail.Size = new System.Drawing.Size(322, 28);
            this.lovMail.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovMail.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovOffice
            // 
            this.lovOffice.EditorPreferredWidth = 257;
            this.lovOffice.Location = new System.Drawing.Point(0, 84);
            this.lovOffice.Name = "lovOffice";
            this.lovOffice.Size = new System.Drawing.Size(322, 28);
            this.lovOffice.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovOffice.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovHome
            // 
            this.lovHome.EditorPreferredWidth = 257;
            this.lovHome.Location = new System.Drawing.Point(0, 112);
            this.lovHome.Name = "lovHome";
            this.lovHome.Size = new System.Drawing.Size(322, 28);
            this.lovHome.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovHome.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovTel
            // 
            this.lovTel.EditorPreferredWidth = 95;
            this.lovTel.Location = new System.Drawing.Point(0, 28);
            this.lovTel.Name = "lovTel";
            this.lovTel.Size = new System.Drawing.Size(160, 28);
            this.lovTel.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovTel.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovEntryDate
            // 
            this.lovEntryDate.EditorPreferredWidth = 95;
            this.lovEntryDate.Location = new System.Drawing.Point(0, 0);
            this.lovEntryDate.Name = "lovEntryDate";
            this.lovEntryDate.Size = new System.Drawing.Size(160, 28);
            this.lovEntryDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovEntryDate.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovDimissionDate
            // 
            this.lovDimissionDate.EditorPreferredWidth = 97;
            this.lovDimissionDate.Location = new System.Drawing.Point(160, 0);
            this.lovDimissionDate.Name = "lovDimissionDate";
            this.lovDimissionDate.Size = new System.Drawing.Size(162, 28);
            this.lovDimissionDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovDimissionDate.TextSize = new System.Drawing.Size(52, 14);
            // 
            // lovDescription
            // 
            this.lovDescription.EditorPreferredWidth = 314;
            this.lovDescription.Location = new System.Drawing.Point(0, 140);
            this.lovDescription.Name = "lovDescription";
            this.lovDescription.Size = new System.Drawing.Size(322, 68);
            this.lovDescription.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lovDescription.TextLocation = DevExpress.Utils.Locations.Top;
            this.lovDescription.TextSize = new System.Drawing.Size(28, 14);
            // 
            // Employee
            // 
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "Employee";
            this.Load += new System.EventHandler(this.Employee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpOrg)).EndInit();
            this.grpOrg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treOrgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSplitT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSearch)).EndInit();
            this.panSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovLeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovIdCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovLoginUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovWorkType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovAlias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovDimissionDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private GroupControl grpOrg;
        private TreeList treOrgList;
        private PanelControl panSplitT;
        private ButtonEdit bteSearch;
        private SimpleButton btnSearch;
        private PanelControl panSearch;
        private GridControl grdEmployee;
        private LayoutView gdvEmployee;
        private LayoutViewColumn colPhoto;
        private LayoutViewColumn colName;
        private LayoutViewColumn colGender;
        private LayoutViewColumn colTitle;
        private LayoutViewColumn colStatus;
        private LayoutViewColumn colLeader;
        private LayoutViewColumn colCode;
        private LayoutViewColumn colWorkType;
        private LayoutViewColumn colIdCardNo;
        private LayoutViewColumn colLoginUser;
        private LayoutViewColumn colAlias;
        private LayoutViewColumn colEntryDate;
        private LayoutViewColumn colDimissionDate;
        private LayoutViewColumn colOfficeAddress;
        private LayoutViewColumn colHomeAddress;
        private ImageCollection imgCard;
        private LayoutViewColumn colTel;
        private LayoutViewColumn colPhone;
        private LayoutViewColumn colMail;
        private LayoutViewColumn colDescription;
        private ComboBoxEdit cmbStatus;
        private LayoutViewField lovPhoto;
        private LayoutViewField lovName;
        private LayoutViewField lovGender;
        private LayoutViewField lovTitle;
        private LayoutViewField lovStatus;
        private LayoutViewField lovLeader;
        private LayoutViewField lovCode;
        private LayoutViewField lovWorkType;
        private LayoutViewField lovIdCardNo;
        private LayoutViewField lovLoginUser;
        private LayoutViewField lovAlias;
        private LayoutViewField lovEntryDate;
        private LayoutViewField lovDimissionDate;
        private LayoutViewField lovTel;
        private LayoutViewField lovPhone;
        private LayoutViewField lovMail;
        private LayoutViewField lovOffice;
        private LayoutViewField lovHome;
        private LayoutViewField lovDescription;
        private LayoutViewCard layoutViewCard1;
        private SimpleSeparator item4;
        private SimpleSeparator item5;
        private LayoutControlGroup item6;
    }
}
