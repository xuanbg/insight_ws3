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
            this.components = new Container();
            var resources = new ComponentResourceManager(typeof(Employee));
            this.splMain = new SplitContainerControl();
            this.grpOrg = new GroupControl();
            this.treOrgList = new TreeList();
            this.grdEmployee = new GridControl();
            this.gdvEmployee = new LayoutView();
            this.colPhoto = new LayoutViewColumn();
            this.lovPhoto = new LayoutViewField();
            this.colName = new LayoutViewColumn();
            this.lovName = new LayoutViewField();
            this.colGender = new LayoutViewColumn();
            this.lovGender = new LayoutViewField();
            this.colTitle = new LayoutViewColumn();
            this.lovTitle = new LayoutViewField();
            this.colStatus = new LayoutViewColumn();
            this.lovStatus = new LayoutViewField();
            this.colLeader = new LayoutViewColumn();
            this.lovLeader = new LayoutViewField();
            this.colCode = new LayoutViewColumn();
            this.lovCode = new LayoutViewField();
            this.colWorkType = new LayoutViewColumn();
            this.lovWorkType = new LayoutViewField();
            this.colIdCardNo = new LayoutViewColumn();
            this.lovIdCardNo = new LayoutViewField();
            this.colLoginUser = new LayoutViewColumn();
            this.lovLoginUser = new LayoutViewField();
            this.colAlias = new LayoutViewColumn();
            this.lovAlias = new LayoutViewField();
            this.colEntryDate = new LayoutViewColumn();
            this.lovEntryDate = new LayoutViewField();
            this.colDimissionDate = new LayoutViewColumn();
            this.lovDimissionDate = new LayoutViewField();
            this.colTel = new LayoutViewColumn();
            this.lovTel = new LayoutViewField();
            this.colPhone = new LayoutViewColumn();
            this.lovPhone = new LayoutViewField();
            this.colMail = new LayoutViewColumn();
            this.lovMail = new LayoutViewField();
            this.colOfficeAddress = new LayoutViewColumn();
            this.lovOffice = new LayoutViewField();
            this.colHomeAddress = new LayoutViewColumn();
            this.lovHome = new LayoutViewField();
            this.colDescription = new LayoutViewColumn();
            this.lovDescription = new LayoutViewField();
            this.layoutViewCard1 = new LayoutViewCard();
            this.item4 = new SimpleSeparator();
            this.item5 = new SimpleSeparator();
            this.item6 = new LayoutControlGroup();
            this.panSplitT = new PanelControl();
            this.panSearch = new PanelControl();
            this.cmbStatus = new ComboBoxEdit();
            this.btnSearch = new SimpleButton();
            this.bteSearch = new ButtonEdit();
            this.imgCard = new ImageCollection(this.components);
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.grpOrg)).BeginInit();
            this.grpOrg.SuspendLayout();
            ((ISupportInitialize)(this.treOrgList)).BeginInit();
            ((ISupportInitialize)(this.grdEmployee)).BeginInit();
            ((ISupportInitialize)(this.gdvEmployee)).BeginInit();
            ((ISupportInitialize)(this.lovPhoto)).BeginInit();
            ((ISupportInitialize)(this.lovName)).BeginInit();
            ((ISupportInitialize)(this.lovGender)).BeginInit();
            ((ISupportInitialize)(this.lovTitle)).BeginInit();
            ((ISupportInitialize)(this.lovStatus)).BeginInit();
            ((ISupportInitialize)(this.lovLeader)).BeginInit();
            ((ISupportInitialize)(this.lovCode)).BeginInit();
            ((ISupportInitialize)(this.lovWorkType)).BeginInit();
            ((ISupportInitialize)(this.lovIdCardNo)).BeginInit();
            ((ISupportInitialize)(this.lovLoginUser)).BeginInit();
            ((ISupportInitialize)(this.lovAlias)).BeginInit();
            ((ISupportInitialize)(this.lovEntryDate)).BeginInit();
            ((ISupportInitialize)(this.lovDimissionDate)).BeginInit();
            ((ISupportInitialize)(this.lovTel)).BeginInit();
            ((ISupportInitialize)(this.lovPhone)).BeginInit();
            ((ISupportInitialize)(this.lovMail)).BeginInit();
            ((ISupportInitialize)(this.lovOffice)).BeginInit();
            ((ISupportInitialize)(this.lovHome)).BeginInit();
            ((ISupportInitialize)(this.lovDescription)).BeginInit();
            ((ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((ISupportInitialize)(this.item4)).BeginInit();
            ((ISupportInitialize)(this.item5)).BeginInit();
            ((ISupportInitialize)(this.item6)).BeginInit();
            ((ISupportInitialize)(this.panSplitT)).BeginInit();
            ((ISupportInitialize)(this.panSearch)).BeginInit();
            this.panSearch.SuspendLayout();
            ((ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((ISupportInitialize)(this.bteSearch.Properties)).BeginInit();
            ((ISupportInitialize)(this.imgCard)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Close.png");
            this.imgFolderNode.Images.SetKeyName(2, "Open.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Close.png");
            this.imgCategoryNode.Images.SetKeyName(2, "Open.png");
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
            this.splMain.Location = new Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpOrg);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.grdEmployee);
            this.splMain.Panel2.Controls.Add(this.panSplitT);
            this.splMain.Panel2.Controls.Add(this.panSearch);
            this.splMain.Panel2.MinSize = 500;
            this.splMain.Size = new Size(1070, 590);
            this.splMain.SplitterPosition = 275;
            this.splMain.TabIndex = 0;
            // 
            // grpOrg
            // 
            this.grpOrg.Controls.Add(this.treOrgList);
            this.grpOrg.Dock = DockStyle.Fill;
            this.grpOrg.Location = new Point(0, 0);
            this.grpOrg.Name = "grpOrg";
            this.grpOrg.Size = new Size(275, 590);
            this.grpOrg.TabIndex = 0;
            this.grpOrg.Text = "组织机构";
            // 
            // treOrgList
            // 
            this.treOrgList.Dock = DockStyle.Fill;
            this.treOrgList.Location = new Point(2, 22);
            this.treOrgList.Name = "treOrgList";
            this.treOrgList.OptionsView.ShowColumns = false;
            this.treOrgList.SelectImageList = this.imgOrgTreeNode;
            this.treOrgList.Size = new Size(271, 566);
            this.treOrgList.TabIndex = 0;
            this.treOrgList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            // 
            // grdEmployee
            // 
            this.grdEmployee.Dock = DockStyle.Fill;
            this.grdEmployee.Location = new Point(0, 44);
            this.grdEmployee.MainView = this.gdvEmployee;
            this.grdEmployee.Name = "grdEmployee";
            this.grdEmployee.Size = new Size(790, 546);
            this.grdEmployee.TabIndex = 3;
            this.grdEmployee.ViewCollection.AddRange(new BaseView[] {
            this.gdvEmployee});
            // 
            // gdvEmployee
            // 
            this.gdvEmployee.CardMinSize = new Size(350, 450);
            this.gdvEmployee.Columns.AddRange(new LayoutViewColumn[] {
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
            this.gdvEmployee.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown;
            this.gdvEmployee.OptionsCustomization.AllowFilter = false;
            this.gdvEmployee.OptionsCustomization.AllowSort = false;
            this.gdvEmployee.OptionsItemText.AlignMode = FieldTextAlignMode.AutoSize;
            this.gdvEmployee.OptionsView.CardsAlignment = CardsAlignment.Near;
            this.gdvEmployee.OptionsView.ShowCardExpandButton = false;
            this.gdvEmployee.OptionsView.ViewMode = LayoutViewMode.Row;
            this.gdvEmployee.TemplateCard = this.layoutViewCard1;
            this.gdvEmployee.CustomCardCaptionImage += new LayoutViewCardCaptionImageEventHandler(this.gdvEmployee_CustomCardCaptionImage);
            this.gdvEmployee.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvEmployee_FocusedRowObjectChanged);
            this.gdvEmployee.DoubleClick += new EventHandler(this.gdvEmployee_DoubleClick);
            // 
            // colPhoto
            // 
            this.colPhoto.CustomizationCaption = "Photo";
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.LayoutViewField = this.lovPhoto;
            this.colPhoto.Name = "colPhoto";
            // 
            // lovPhoto
            // 
            this.lovPhoto.EditorPreferredWidth = 112;
            this.lovPhoto.Location = new Point(0, 0);
            this.lovPhoto.MaxSize = new Size(120, 150);
            this.lovPhoto.MinSize = new Size(120, 150);
            this.lovPhoto.Name = "lovPhoto";
            this.lovPhoto.Size = new Size(120, 168);
            this.lovPhoto.SizeConstraintsType = SizeConstraintsType.Custom;
            this.lovPhoto.Spacing = new Padding(2, 2, 2, 2);
            this.lovPhoto.TextSize = new Size(0, 0);
            this.lovPhoto.TextToControlDistance = 0;
            this.lovPhoto.TextVisible = false;
            // 
            // colName
            // 
            this.colName.Caption = "姓名";
            this.colName.CustomizationCaption = "姓名";
            this.colName.FieldName = "姓名";
            this.colName.LayoutViewField = this.lovName;
            this.colName.Name = "colName";
            // 
            // lovName
            // 
            this.lovName.EditorPreferredWidth = 79;
            this.lovName.Location = new Point(126, 0);
            this.lovName.Name = "lovName";
            this.lovName.Size = new Size(120, 28);
            this.lovName.Spacing = new Padding(2, 2, 2, 2);
            this.lovName.TextSize = new Size(28, 14);
            this.lovName.TextToControlDistance = 5;
            // 
            // colGender
            // 
            this.colGender.Caption = "性别";
            this.colGender.CustomizationCaption = "性别";
            this.colGender.FieldName = "性别";
            this.colGender.LayoutViewField = this.lovGender;
            this.colGender.Name = "colGender";
            // 
            // lovGender
            // 
            this.lovGender.EditorPreferredWidth = 59;
            this.lovGender.Location = new Point(246, 0);
            this.lovGender.Name = "lovGender";
            this.lovGender.Size = new Size(100, 28);
            this.lovGender.Spacing = new Padding(2, 2, 2, 2);
            this.lovGender.TextSize = new Size(28, 14);
            this.lovGender.TextToControlDistance = 5;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "职位";
            this.colTitle.CustomizationCaption = "职位";
            this.colTitle.FieldName = "职位";
            this.colTitle.LayoutViewField = this.lovTitle;
            this.colTitle.Name = "colTitle";
            // 
            // lovTitle
            // 
            this.lovTitle.EditorPreferredWidth = 79;
            this.lovTitle.Location = new Point(126, 28);
            this.lovTitle.Name = "lovTitle";
            this.lovTitle.Size = new Size(120, 28);
            this.lovTitle.Spacing = new Padding(2, 2, 2, 2);
            this.lovTitle.TextSize = new Size(28, 14);
            this.lovTitle.TextToControlDistance = 5;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "状态";
            this.colStatus.CustomizationCaption = "状态";
            this.colStatus.FieldName = "状态";
            this.colStatus.LayoutViewField = this.lovStatus;
            this.colStatus.Name = "colStatus";
            // 
            // lovStatus
            // 
            this.lovStatus.EditorPreferredWidth = 59;
            this.lovStatus.Location = new Point(246, 28);
            this.lovStatus.Name = "lovStatus";
            this.lovStatus.Size = new Size(100, 28);
            this.lovStatus.Spacing = new Padding(2, 2, 2, 2);
            this.lovStatus.TextSize = new Size(28, 14);
            this.lovStatus.TextToControlDistance = 5;
            // 
            // colLeader
            // 
            this.colLeader.Caption = "直接领导";
            this.colLeader.CustomizationCaption = "直接领导";
            this.colLeader.FieldName = "直接领导";
            this.colLeader.LayoutViewField = this.lovLeader;
            this.colLeader.Name = "colLeader";
            // 
            // lovLeader
            // 
            this.lovLeader.EditorPreferredWidth = 155;
            this.lovLeader.Location = new Point(126, 84);
            this.lovLeader.Name = "lovLeader";
            this.lovLeader.Size = new Size(220, 28);
            this.lovLeader.Spacing = new Padding(2, 2, 2, 2);
            this.lovLeader.TextSize = new Size(52, 14);
            this.lovLeader.TextToControlDistance = 5;
            // 
            // colCode
            // 
            this.colCode.Caption = "工号";
            this.colCode.CustomizationCaption = "工号";
            this.colCode.FieldName = "工号";
            this.colCode.LayoutViewField = this.lovCode;
            this.colCode.Name = "colCode";
            // 
            // lovCode
            // 
            this.lovCode.EditorPreferredWidth = 79;
            this.lovCode.Location = new Point(126, 56);
            this.lovCode.Name = "lovCode";
            this.lovCode.Size = new Size(120, 28);
            this.lovCode.Spacing = new Padding(2, 2, 2, 2);
            this.lovCode.TextSize = new Size(28, 14);
            this.lovCode.TextToControlDistance = 5;
            // 
            // colWorkType
            // 
            this.colWorkType.Caption = "工种";
            this.colWorkType.CustomizationCaption = "工种";
            this.colWorkType.FieldName = "工种";
            this.colWorkType.LayoutViewField = this.lovWorkType;
            this.colWorkType.Name = "colWorkType";
            // 
            // lovWorkType
            // 
            this.lovWorkType.EditorPreferredWidth = 59;
            this.lovWorkType.Location = new Point(246, 56);
            this.lovWorkType.Name = "lovWorkType";
            this.lovWorkType.Size = new Size(100, 28);
            this.lovWorkType.Spacing = new Padding(2, 2, 2, 2);
            this.lovWorkType.TextSize = new Size(28, 14);
            this.lovWorkType.TextToControlDistance = 5;
            // 
            // colIdCardNo
            // 
            this.colIdCardNo.Caption = "身份证号";
            this.colIdCardNo.CustomizationCaption = "身份证号";
            this.colIdCardNo.FieldName = "身份证号";
            this.colIdCardNo.LayoutViewField = this.lovIdCardNo;
            this.colIdCardNo.Name = "colIdCardNo";
            // 
            // lovIdCardNo
            // 
            this.lovIdCardNo.EditorPreferredWidth = 155;
            this.lovIdCardNo.Location = new Point(126, 112);
            this.lovIdCardNo.Name = "lovIdCardNo";
            this.lovIdCardNo.Size = new Size(220, 28);
            this.lovIdCardNo.Spacing = new Padding(2, 2, 2, 2);
            this.lovIdCardNo.TextSize = new Size(52, 14);
            this.lovIdCardNo.TextToControlDistance = 5;
            // 
            // colLoginUser
            // 
            this.colLoginUser.Caption = "登录";
            this.colLoginUser.CustomizationCaption = "登录";
            this.colLoginUser.FieldName = "登录";
            this.colLoginUser.LayoutViewField = this.lovLoginUser;
            this.colLoginUser.Name = "colLoginUser";
            // 
            // lovLoginUser
            // 
            this.lovLoginUser.EditorPreferredWidth = 29;
            this.lovLoginUser.Location = new Point(276, 140);
            this.lovLoginUser.Name = "lovLoginUser";
            this.lovLoginUser.Size = new Size(70, 28);
            this.lovLoginUser.Spacing = new Padding(2, 2, 2, 2);
            this.lovLoginUser.TextSize = new Size(28, 14);
            this.lovLoginUser.TextToControlDistance = 5;
            // 
            // colAlias
            // 
            this.colAlias.Caption = "登录帐号";
            this.colAlias.CustomizationCaption = "登录帐号";
            this.colAlias.FieldName = "登录帐号";
            this.colAlias.LayoutViewField = this.lovAlias;
            this.colAlias.Name = "colAlias";
            // 
            // lovAlias
            // 
            this.lovAlias.EditorPreferredWidth = 85;
            this.lovAlias.Location = new Point(126, 140);
            this.lovAlias.Name = "lovAlias";
            this.lovAlias.Size = new Size(150, 28);
            this.lovAlias.Spacing = new Padding(2, 2, 2, 2);
            this.lovAlias.TextSize = new Size(52, 14);
            this.lovAlias.TextToControlDistance = 5;
            // 
            // colEntryDate
            // 
            this.colEntryDate.Caption = "入职日期";
            this.colEntryDate.CustomizationCaption = "入职日期";
            this.colEntryDate.FieldName = "入职日期";
            this.colEntryDate.LayoutViewField = this.lovEntryDate;
            this.colEntryDate.Name = "colEntryDate";
            // 
            // lovEntryDate
            // 
            this.lovEntryDate.EditorPreferredWidth = 95;
            this.lovEntryDate.Location = new Point(0, 0);
            this.lovEntryDate.Name = "lovEntryDate";
            this.lovEntryDate.Size = new Size(160, 28);
            this.lovEntryDate.Spacing = new Padding(2, 2, 2, 2);
            this.lovEntryDate.TextSize = new Size(52, 14);
            this.lovEntryDate.TextToControlDistance = 5;
            // 
            // colDimissionDate
            // 
            this.colDimissionDate.Caption = "离职日期";
            this.colDimissionDate.CustomizationCaption = "离职日期";
            this.colDimissionDate.FieldName = "离职日期";
            this.colDimissionDate.LayoutViewField = this.lovDimissionDate;
            this.colDimissionDate.Name = "colDimissionDate";
            // 
            // lovDimissionDate
            // 
            this.lovDimissionDate.EditorPreferredWidth = 96;
            this.lovDimissionDate.Location = new Point(160, 0);
            this.lovDimissionDate.Name = "lovDimissionDate";
            this.lovDimissionDate.Size = new Size(162, 28);
            this.lovDimissionDate.Spacing = new Padding(2, 2, 2, 2);
            this.lovDimissionDate.TextSize = new Size(52, 14);
            this.lovDimissionDate.TextToControlDistance = 5;
            // 
            // colTel
            // 
            this.colTel.Caption = "电话号码";
            this.colTel.CustomizationCaption = "电话号码";
            this.colTel.FieldName = "电话号码";
            this.colTel.LayoutViewField = this.lovTel;
            this.colTel.Name = "colTel";
            // 
            // lovTel
            // 
            this.lovTel.EditorPreferredWidth = 95;
            this.lovTel.Location = new Point(0, 28);
            this.lovTel.Name = "lovTel";
            this.lovTel.Size = new Size(160, 28);
            this.lovTel.Spacing = new Padding(2, 2, 2, 2);
            this.lovTel.TextSize = new Size(52, 14);
            this.lovTel.TextToControlDistance = 5;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "移动电话";
            this.colPhone.CustomizationCaption = "移动电话";
            this.colPhone.FieldName = "移动电话";
            this.colPhone.LayoutViewField = this.lovPhone;
            this.colPhone.Name = "colPhone";
            // 
            // lovPhone
            // 
            this.lovPhone.EditorPreferredWidth = 96;
            this.lovPhone.Location = new Point(160, 28);
            this.lovPhone.Name = "lovPhone";
            this.lovPhone.Size = new Size(162, 28);
            this.lovPhone.Spacing = new Padding(2, 2, 2, 2);
            this.lovPhone.TextSize = new Size(52, 14);
            this.lovPhone.TextToControlDistance = 5;
            // 
            // colMail
            // 
            this.colMail.Caption = "电子邮件";
            this.colMail.CustomizationCaption = "电子邮件";
            this.colMail.FieldName = "电子邮件";
            this.colMail.LayoutViewField = this.lovMail;
            this.colMail.Name = "colMail";
            // 
            // lovMail
            // 
            this.lovMail.EditorPreferredWidth = 256;
            this.lovMail.Location = new Point(0, 56);
            this.lovMail.Name = "lovMail";
            this.lovMail.Size = new Size(322, 28);
            this.lovMail.Spacing = new Padding(2, 2, 2, 2);
            this.lovMail.TextSize = new Size(52, 14);
            this.lovMail.TextToControlDistance = 5;
            // 
            // colOfficeAddress
            // 
            this.colOfficeAddress.Caption = "办公地点";
            this.colOfficeAddress.CustomizationCaption = "办公地点";
            this.colOfficeAddress.FieldName = "办公地点";
            this.colOfficeAddress.LayoutViewField = this.lovOffice;
            this.colOfficeAddress.Name = "colOfficeAddress";
            // 
            // lovOffice
            // 
            this.lovOffice.EditorPreferredWidth = 256;
            this.lovOffice.Location = new Point(0, 84);
            this.lovOffice.Name = "lovOffice";
            this.lovOffice.Size = new Size(322, 28);
            this.lovOffice.Spacing = new Padding(2, 2, 2, 2);
            this.lovOffice.TextSize = new Size(52, 14);
            this.lovOffice.TextToControlDistance = 5;
            // 
            // colHomeAddress
            // 
            this.colHomeAddress.Caption = "家庭住址";
            this.colHomeAddress.CustomizationCaption = "家庭住址";
            this.colHomeAddress.FieldName = "家庭住址";
            this.colHomeAddress.LayoutViewField = this.lovHome;
            this.colHomeAddress.Name = "colHomeAddress";
            // 
            // lovHome
            // 
            this.lovHome.EditorPreferredWidth = 256;
            this.lovHome.Location = new Point(0, 112);
            this.lovHome.Name = "lovHome";
            this.lovHome.Size = new Size(322, 28);
            this.lovHome.Spacing = new Padding(2, 2, 2, 2);
            this.lovHome.TextSize = new Size(52, 14);
            this.lovHome.TextToControlDistance = 5;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "备注";
            this.colDescription.CustomizationCaption = "备注";
            this.colDescription.FieldName = "备注";
            this.colDescription.LayoutViewField = this.lovDescription;
            this.colDescription.Name = "colDescription";
            // 
            // lovDescription
            // 
            this.lovDescription.EditorPreferredWidth = 313;
            this.lovDescription.Location = new Point(0, 140);
            this.lovDescription.Name = "lovDescription";
            this.lovDescription.Size = new Size(322, 66);
            this.lovDescription.Spacing = new Padding(2, 2, 2, 2);
            this.lovDescription.TextLocation = Locations.Top;
            this.lovDescription.TextSize = new Size(28, 14);
            this.lovDescription.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new BaseLayoutItem[] {
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
            this.layoutViewCard1.Padding = new Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextLocation = Locations.Default;
            // 
            // item4
            // 
            this.item4.AllowHotTrack = false;
            this.item4.CustomizationFormText = "item4";
            this.item4.Location = new Point(0, 168);
            this.item4.Name = "item4";
            this.item4.Size = new Size(346, 6);
            this.item4.Spacing = new Padding(2, 2, 2, 2);
            this.item4.Text = "item4";
            // 
            // item5
            // 
            this.item5.AllowHotTrack = false;
            this.item5.CustomizationFormText = "item5";
            this.item5.Location = new Point(120, 0);
            this.item5.Name = "item5";
            this.item5.Size = new Size(6, 168);
            this.item5.Spacing = new Padding(2, 2, 2, 2);
            this.item5.Text = "item5";
            // 
            // item6
            // 
            this.item6.CustomizationFormText = "联系方式";
            this.item6.Items.AddRange(new BaseLayoutItem[] {
            this.lovPhone,
            this.lovMail,
            this.lovOffice,
            this.lovHome,
            this.lovTel,
            this.lovEntryDate,
            this.lovDimissionDate,
            this.lovDescription});
            this.item6.Location = new Point(0, 174);
            this.item6.Name = "item6";
            this.item6.Size = new Size(346, 250);
            this.item6.Text = "详细信息";
            // 
            // panSplitT
            // 
            this.panSplitT.Appearance.BackColor = Color.Transparent;
            this.panSplitT.Appearance.Options.UseBackColor = true;
            this.panSplitT.BorderStyle = BorderStyles.NoBorder;
            this.panSplitT.Dock = DockStyle.Top;
            this.panSplitT.Location = new Point(0, 39);
            this.panSplitT.Name = "panSplitT";
            this.panSplitT.Size = new Size(790, 5);
            this.panSplitT.TabIndex = 0;
            // 
            // panSearch
            // 
            this.panSearch.Controls.Add(this.cmbStatus);
            this.panSearch.Controls.Add(this.btnSearch);
            this.panSearch.Controls.Add(this.bteSearch);
            this.panSearch.Dock = DockStyle.Top;
            this.panSearch.Location = new Point(0, 0);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new Size(790, 39);
            this.panSearch.TabIndex = 0;
            // 
            // cmbStatus
            // 
            this.cmbStatus.EditValue = "在职";
            this.cmbStatus.Location = new Point(9, 9);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbStatus.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.cmbStatus.Properties.AutoHeight = false;
            this.cmbStatus.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.cmbStatus.Properties.Items.AddRange(new object[] {
            "在职",
            "离职"});
            this.cmbStatus.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cmbStatus.Size = new Size(62, 21);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.SelectedIndexChanged += new EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnSearch.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new Point(712, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(70, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查  询";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            // 
            // bteSearch
            // 
            this.bteSearch.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.bteSearch.Location = new Point(79, 9);
            this.bteSearch.Name = "bteSearch";
            this.bteSearch.Properties.AutoHeight = false;
            this.bteSearch.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Delete)});
            this.bteSearch.Properties.NullText = "在此输入员工姓名进行查询…";
            this.bteSearch.Properties.KeyDown += new KeyEventHandler(this.bteditSearch_Properties_KeyDown);
            this.bteSearch.Size = new Size(625, 21);
            this.bteSearch.TabIndex = 1;
            this.bteSearch.ButtonClick += new ButtonPressedEventHandler(this.bteSearch_ButtonClick);
            // 
            // imgCard
            // 
            this.imgCard.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCard.ImageStream")));
            this.imgCard.InsertGalleryImage("employee_16x16.png", "images/people/employee_16x16.png", ImageResourceCache.Default.GetImage("images/people/employee_16x16.png"), 0);
            this.imgCard.Images.SetKeyName(0, "employee_16x16.png");
            this.imgCard.Images.SetKeyName(1, "Employee_G.png");
            // 
            // Employee
            // 
            this.ClientSize = new Size(1080, 629);
            this.Name = "Employee";
            this.Load += new EventHandler(this.Employee_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grpOrg)).EndInit();
            this.grpOrg.ResumeLayout(false);
            ((ISupportInitialize)(this.treOrgList)).EndInit();
            ((ISupportInitialize)(this.grdEmployee)).EndInit();
            ((ISupportInitialize)(this.gdvEmployee)).EndInit();
            ((ISupportInitialize)(this.lovPhoto)).EndInit();
            ((ISupportInitialize)(this.lovName)).EndInit();
            ((ISupportInitialize)(this.lovGender)).EndInit();
            ((ISupportInitialize)(this.lovTitle)).EndInit();
            ((ISupportInitialize)(this.lovStatus)).EndInit();
            ((ISupportInitialize)(this.lovLeader)).EndInit();
            ((ISupportInitialize)(this.lovCode)).EndInit();
            ((ISupportInitialize)(this.lovWorkType)).EndInit();
            ((ISupportInitialize)(this.lovIdCardNo)).EndInit();
            ((ISupportInitialize)(this.lovLoginUser)).EndInit();
            ((ISupportInitialize)(this.lovAlias)).EndInit();
            ((ISupportInitialize)(this.lovEntryDate)).EndInit();
            ((ISupportInitialize)(this.lovDimissionDate)).EndInit();
            ((ISupportInitialize)(this.lovTel)).EndInit();
            ((ISupportInitialize)(this.lovPhone)).EndInit();
            ((ISupportInitialize)(this.lovMail)).EndInit();
            ((ISupportInitialize)(this.lovOffice)).EndInit();
            ((ISupportInitialize)(this.lovHome)).EndInit();
            ((ISupportInitialize)(this.lovDescription)).EndInit();
            ((ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((ISupportInitialize)(this.item4)).EndInit();
            ((ISupportInitialize)(this.item5)).EndInit();
            ((ISupportInitialize)(this.item6)).EndInit();
            ((ISupportInitialize)(this.panSplitT)).EndInit();
            ((ISupportInitialize)(this.panSearch)).EndInit();
            this.panSearch.ResumeLayout(false);
            ((ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((ISupportInitialize)(this.bteSearch.Properties)).EndInit();
            ((ISupportInitialize)(this.imgCard)).EndInit();
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
