using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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

namespace Insight.WS.Client.MasterDatas
{
    partial class EmployeeData
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
            var resources = new ComponentResourceManager(typeof(EmployeeData));
            var serializableAppearanceObject2 = new SerializableAppearanceObject();
            this.picPhoto = new PictureEdit();
            this.grdContact = new GridControl();
            this.gdvContact = new GridView();
            this.lokContact = new RepositoryItemLookUpEdit();
            this.trlTitle = new TreeListLookUpEdit();
            this.treTitle = new TreeList();
            this.txtLoginName = new TextEdit();
            this.chkIsLogin = new CheckEdit();
            this.txtIDCardNo = new TextEdit();
            this.cmbGender = new ComboBoxEdit();
            this.txtCode = new TextEdit();
            this.txtName = new TextEdit();
            this.labName = new LabelControl();
            this.labGender = new LabelControl();
            this.labTitle = new LabelControl();
            this.labCode = new LabelControl();
            this.labWorkType = new LabelControl();
            this.labIDCardNo = new LabelControl();
            this.labLeader = new LabelControl();
            this.labEntry = new LabelControl();
            this.datEntry = new DateEdit();
            this.labLoginName = new LabelControl();
            this.grpContactInfo = new GroupControl();
            this.labHome = new LabelControl();
            this.labOffice = new LabelControl();
            this.txtOffice = new TextEdit();
            this.txtHome = new TextEdit();
            this.grlWorkType = new GridLookUpEdit();
            this.gdvWorkType = new GridView();
            this.sleLeader = new SearchLookUpEdit();
            this.gdvLeader = new GridView();
            this.labDescription = new LabelControl();
            this.memDescription = new MemoEdit();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.picPhoto.Properties)).BeginInit();
            ((ISupportInitialize)(this.grdContact)).BeginInit();
            ((ISupportInitialize)(this.gdvContact)).BeginInit();
            ((ISupportInitialize)(this.lokContact)).BeginInit();
            ((ISupportInitialize)(this.trlTitle.Properties)).BeginInit();
            ((ISupportInitialize)(this.treTitle)).BeginInit();
            ((ISupportInitialize)(this.txtLoginName.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkIsLogin.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtIDCardNo.Properties)).BeginInit();
            ((ISupportInitialize)(this.cmbGender.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((ISupportInitialize)(this.datEntry.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datEntry.Properties)).BeginInit();
            ((ISupportInitialize)(this.grpContactInfo)).BeginInit();
            this.grpContactInfo.SuspendLayout();
            ((ISupportInitialize)(this.txtOffice.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtHome.Properties)).BeginInit();
            ((ISupportInitialize)(this.grlWorkType.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvWorkType)).BeginInit();
            ((ISupportInitialize)(this.sleLeader.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvLeader)).BeginInit();
            ((ISupportInitialize)(this.memDescription.Properties)).BeginInit();
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
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(390, 464);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(300, 464);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.grpContactInfo);
            this.panel.Controls.Add(this.txtLoginName);
            this.panel.Controls.Add(this.trlTitle);
            this.panel.Controls.Add(this.chkIsLogin);
            this.panel.Controls.Add(this.datEntry);
            this.panel.Controls.Add(this.txtIDCardNo);
            this.panel.Controls.Add(this.picPhoto);
            this.panel.Controls.Add(this.labLoginName);
            this.panel.Controls.Add(this.labWorkType);
            this.panel.Controls.Add(this.labGender);
            this.panel.Controls.Add(this.labOffice);
            this.panel.Controls.Add(this.labDescription);
            this.panel.Controls.Add(this.labHome);
            this.panel.Controls.Add(this.labEntry);
            this.panel.Controls.Add(this.labIDCardNo);
            this.panel.Controls.Add(this.labLeader);
            this.panel.Controls.Add(this.labTitle);
            this.panel.Controls.Add(this.labCode);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.txtHome);
            this.panel.Controls.Add(this.txtOffice);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.txtCode);
            this.panel.Controls.Add(this.cmbGender);
            this.panel.Controls.Add(this.grlWorkType);
            this.panel.Controls.Add(this.sleLeader);
            this.panel.Size = new Size(470, 440);
            // 
            // picPhoto
            // 
            this.picPhoto.EnterMoveNextControl = true;
            this.picPhoto.Location = new Point(10, 10);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Properties.NullText = "请单击右键修改…";
            this.picPhoto.Properties.SizeMode = PictureSizeMode.Squeeze;
            this.picPhoto.Size = new Size(120, 150);
            this.picPhoto.TabIndex = 10;
            // 
            // grdContact
            // 
            this.grdContact.Dock = DockStyle.Fill;
            this.grdContact.Location = new Point(2, 22);
            this.grdContact.MainView = this.gdvContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.RepositoryItems.AddRange(new RepositoryItem[] {
            this.lokContact});
            this.grdContact.Size = new Size(446, 126);
            this.grdContact.TabIndex = 14;
            this.grdContact.ViewCollection.AddRange(new BaseView[] {
            this.gdvContact});
            // 
            // gdvContact
            // 
            this.gdvContact.BorderStyle = BorderStyles.NoBorder;
            this.gdvContact.GridControl = this.grdContact;
            this.gdvContact.Name = "gdvContact";
            this.gdvContact.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.gdvContact.RowCellClick += new RowCellClickEventHandler(this.gdvContact_RowCellClick);
            this.gdvContact.CellValueChanged += new CellValueChangedEventHandler(this.gdvContact_CellValueChanged);
            this.gdvContact.KeyDown += new KeyEventHandler(this.gdvContact_KeyDown);
            // 
            // lokContact
            // 
            this.lokContact.AutoHeight = false;
            this.lokContact.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokContact.Name = "lokContact";
            this.lokContact.NullText = "";
            this.lokContact.PopupFormMinSize = new Size(100, 100);
            this.lokContact.PopupWidth = 120;
            this.lokContact.ShowHeader = false;
            this.lokContact.TextEditStyle = TextEditStyles.Standard;
            // 
            // trlTitle
            // 
            this.trlTitle.EnterMoveNextControl = true;
            this.trlTitle.Location = new Point(200, 50);
            this.trlTitle.Name = "trlTitle";
            this.trlTitle.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.trlTitle.Properties.NullText = "请选择…";
            this.trlTitle.Properties.PopupFormSize = new Size(240, 200);
            this.trlTitle.Properties.TreeList = this.treTitle;
            this.trlTitle.Size = new Size(100, 20);
            this.trlTitle.TabIndex = 3;
            this.trlTitle.EditValueChanged += new EventHandler(this.trlTitle_EditValueChanged);
            // 
            // treTitle
            // 
            this.treTitle.Location = new Point(-22, 17);
            this.treTitle.Name = "treTitle";
            this.treTitle.OptionsBehavior.EnableFiltering = true;
            this.treTitle.OptionsView.ShowIndentAsRowStyle = true;
            this.treTitle.SelectImageList = this.imgOrgTreeNode;
            this.treTitle.Size = new Size(253, 200);
            this.treTitle.TabIndex = 0;
            // 
            // txtLoginName
            // 
            this.txtLoginName.EnterMoveNextControl = true;
            this.txtLoginName.Location = new Point(360, 110);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Properties.Mask.EditMask = "[a-zA-Z0-9]+";
            this.txtLoginName.Properties.Mask.MaskType = MaskType.RegEx;
            this.txtLoginName.Size = new Size(100, 20);
            this.txtLoginName.TabIndex = 8;
            this.txtLoginName.EditValueChanged += new EventHandler(this.txtLoginName_EditValueChanged);
            // 
            // chkIsLogin
            // 
            this.chkIsLogin.EnterMoveNextControl = true;
            this.chkIsLogin.Location = new Point(368, 142);
            this.chkIsLogin.Name = "chkIsLogin";
            this.chkIsLogin.Properties.Caption = "是否登录用户";
            this.chkIsLogin.Size = new Size(92, 15);
            this.chkIsLogin.TabIndex = 11;
            this.chkIsLogin.CheckedChanged += new EventHandler(this.chkIsLogin_CheckedChanged);
            // 
            // txtIDCardNo
            // 
            this.txtIDCardNo.EnterMoveNextControl = true;
            this.txtIDCardNo.Location = new Point(200, 140);
            this.txtIDCardNo.Name = "txtIDCardNo";
            this.txtIDCardNo.Properties.Mask.EditMask = "[0-9X]+";
            this.txtIDCardNo.Properties.Mask.MaskType = MaskType.RegEx;
            this.txtIDCardNo.Properties.MaxLength = 18;
            this.txtIDCardNo.Size = new Size(160, 20);
            this.txtIDCardNo.TabIndex = 9;
            // 
            // cmbGender
            // 
            this.cmbGender.EnterMoveNextControl = true;
            this.cmbGender.Location = new Point(360, 20);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.cmbGender.Properties.Items.AddRange(new object[] {
            "女",
            "男"});
            this.cmbGender.Properties.NullText = "请选择…";
            this.cmbGender.Size = new Size(100, 20);
            this.cmbGender.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new Point(200, 80);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Mask.EditMask = "[a-zA-Z0-9]+";
            this.txtCode.Properties.Mask.MaskType = MaskType.RegEx;
            this.txtCode.Size = new Size(100, 20);
            this.txtCode.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new Point(200, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labName.Location = new Point(130, 20);
            this.labName.Name = "labName";
            this.labName.Size = new Size(70, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "姓名：";
            // 
            // labGender
            // 
            this.labGender.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labGender.AutoSizeMode = LabelAutoSizeMode.None;
            this.labGender.Location = new Point(300, 20);
            this.labGender.Name = "labGender";
            this.labGender.Size = new Size(60, 21);
            this.labGender.TabIndex = 0;
            this.labGender.Text = "性别：";
            // 
            // labTitle
            // 
            this.labTitle.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labTitle.AutoSizeMode = LabelAutoSizeMode.None;
            this.labTitle.Location = new Point(130, 50);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new Size(70, 21);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "职位：";
            // 
            // labCode
            // 
            this.labCode.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCode.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCode.Location = new Point(130, 80);
            this.labCode.Name = "labCode";
            this.labCode.Size = new Size(70, 21);
            this.labCode.TabIndex = 0;
            this.labCode.Text = "工号：";
            // 
            // labWorkType
            // 
            this.labWorkType.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labWorkType.AutoSizeMode = LabelAutoSizeMode.None;
            this.labWorkType.Location = new Point(300, 80);
            this.labWorkType.Name = "labWorkType";
            this.labWorkType.Size = new Size(60, 21);
            this.labWorkType.TabIndex = 0;
            this.labWorkType.Text = "工种：";
            // 
            // labIDCardNo
            // 
            this.labIDCardNo.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labIDCardNo.AutoSizeMode = LabelAutoSizeMode.None;
            this.labIDCardNo.Location = new Point(130, 140);
            this.labIDCardNo.Name = "labIDCardNo";
            this.labIDCardNo.Size = new Size(70, 21);
            this.labIDCardNo.TabIndex = 0;
            this.labIDCardNo.Text = "身份证号：";
            // 
            // labLeader
            // 
            this.labLeader.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labLeader.AutoSizeMode = LabelAutoSizeMode.None;
            this.labLeader.Location = new Point(300, 50);
            this.labLeader.Name = "labLeader";
            this.labLeader.Size = new Size(60, 21);
            this.labLeader.TabIndex = 0;
            this.labLeader.Text = "上级：";
            // 
            // labEntry
            // 
            this.labEntry.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labEntry.AutoSizeMode = LabelAutoSizeMode.None;
            this.labEntry.Location = new Point(130, 110);
            this.labEntry.Name = "labEntry";
            this.labEntry.Size = new Size(70, 21);
            this.labEntry.TabIndex = 0;
            this.labEntry.Text = "入职日期：";
            // 
            // datEntry
            // 
            this.datEntry.EditValue = null;
            this.datEntry.EnterMoveNextControl = true;
            this.datEntry.Location = new Point(200, 110);
            this.datEntry.Name = "datEntry";
            this.datEntry.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datEntry.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.datEntry.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datEntry.Properties.NullDate = "";
            this.datEntry.Size = new Size(100, 22);
            this.datEntry.TabIndex = 7;
            // 
            // labLoginName
            // 
            this.labLoginName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labLoginName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labLoginName.Location = new Point(300, 110);
            this.labLoginName.Name = "labLoginName";
            this.labLoginName.Size = new Size(60, 21);
            this.labLoginName.TabIndex = 0;
            this.labLoginName.Text = "账号：";
            // 
            // grpContactInfo
            // 
            this.grpContactInfo.Controls.Add(this.grdContact);
            this.grpContactInfo.Location = new Point(10, 280);
            this.grpContactInfo.Name = "grpContactInfo";
            this.grpContactInfo.Size = new Size(450, 150);
            this.grpContactInfo.TabIndex = 15;
            this.grpContactInfo.Text = "联系方式";
            // 
            // labHome
            // 
            this.labHome.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labHome.AutoSizeMode = LabelAutoSizeMode.None;
            this.labHome.Location = new Point(0, 200);
            this.labHome.Name = "labHome";
            this.labHome.Size = new Size(80, 21);
            this.labHome.TabIndex = 0;
            this.labHome.Text = "家庭住址：";
            // 
            // labOffice
            // 
            this.labOffice.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labOffice.AutoSizeMode = LabelAutoSizeMode.None;
            this.labOffice.Location = new Point(0, 170);
            this.labOffice.Name = "labOffice";
            this.labOffice.Size = new Size(80, 21);
            this.labOffice.TabIndex = 0;
            this.labOffice.Text = "办公地点：";
            // 
            // txtOffice
            // 
            this.txtOffice.EnterMoveNextControl = true;
            this.txtOffice.Location = new Point(80, 170);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new Size(380, 20);
            this.txtOffice.TabIndex = 12;
            // 
            // txtHome
            // 
            this.txtHome.EnterMoveNextControl = true;
            this.txtHome.Location = new Point(80, 200);
            this.txtHome.Name = "txtHome";
            this.txtHome.Size = new Size(380, 20);
            this.txtHome.TabIndex = 13;
            // 
            // grlWorkType
            // 
            this.grlWorkType.EnterMoveNextControl = true;
            this.grlWorkType.Location = new Point(360, 80);
            this.grlWorkType.Name = "grlWorkType";
            this.grlWorkType.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlWorkType.Properties.NullText = "请选择…";
            this.grlWorkType.Properties.PopupFormMinSize = new Size(100, 200);
            this.grlWorkType.Properties.PopupFormSize = new Size(120, 200);
            this.grlWorkType.Properties.View = this.gdvWorkType;
            this.grlWorkType.Size = new Size(100, 20);
            this.grlWorkType.TabIndex = 6;
            // 
            // gdvWorkType
            // 
            this.gdvWorkType.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvWorkType.Name = "gdvWorkType";
            this.gdvWorkType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvWorkType.OptionsView.ShowColumnHeaders = false;
            this.gdvWorkType.OptionsView.ShowGroupPanel = false;
            // 
            // sleLeader
            // 
            this.sleLeader.EnterMoveNextControl = true;
            this.sleLeader.Location = new Point(360, 50);
            this.sleLeader.Name = "sleLeader";
            this.sleLeader.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.sleLeader.Properties.NullText = "请选择…";
            this.sleLeader.Properties.PopupFormSize = new Size(240, 200);
            this.sleLeader.Properties.View = this.gdvLeader;
            this.sleLeader.Size = new Size(100, 20);
            this.sleLeader.TabIndex = 4;
            // 
            // gdvLeader
            // 
            this.gdvLeader.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvLeader.Name = "gdvLeader";
            this.gdvLeader.OptionsFind.AlwaysVisible = true;
            this.gdvLeader.OptionsFind.FindNullPrompt = "输入关键字进行查询…";
            this.gdvLeader.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvLeader.OptionsView.ShowGroupPanel = false;
            // 
            // labDescription
            // 
            this.labDescription.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.labDescription.Location = new Point(0, 230);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new Size(80, 21);
            this.labDescription.TabIndex = 0;
            this.labDescription.Text = "备注：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new Point(80, 230);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new Size(380, 40);
            this.memDescription.TabIndex = 14;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // EmployeeData
            // 
            this.ClientSize = new Size(484, 502);
            this.Name = "EmployeeData";
            this.Load += new EventHandler(this.EmployeeData_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.picPhoto.Properties)).EndInit();
            ((ISupportInitialize)(this.grdContact)).EndInit();
            ((ISupportInitialize)(this.gdvContact)).EndInit();
            ((ISupportInitialize)(this.lokContact)).EndInit();
            ((ISupportInitialize)(this.trlTitle.Properties)).EndInit();
            ((ISupportInitialize)(this.treTitle)).EndInit();
            ((ISupportInitialize)(this.txtLoginName.Properties)).EndInit();
            ((ISupportInitialize)(this.chkIsLogin.Properties)).EndInit();
            ((ISupportInitialize)(this.txtIDCardNo.Properties)).EndInit();
            ((ISupportInitialize)(this.cmbGender.Properties)).EndInit();
            ((ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((ISupportInitialize)(this.datEntry.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datEntry.Properties)).EndInit();
            ((ISupportInitialize)(this.grpContactInfo)).EndInit();
            this.grpContactInfo.ResumeLayout(false);
            ((ISupportInitialize)(this.txtOffice.Properties)).EndInit();
            ((ISupportInitialize)(this.txtHome.Properties)).EndInit();
            ((ISupportInitialize)(this.grlWorkType.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvWorkType)).EndInit();
            ((ISupportInitialize)(this.sleLeader.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvLeader)).EndInit();
            ((ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl grdContact;
        private GridView gdvContact;
        private PictureEdit picPhoto;
        private RepositoryItemLookUpEdit lokContact;
        private TreeListLookUpEdit trlTitle;
        private TreeList treTitle;
        private TextEdit txtLoginName;
        private CheckEdit chkIsLogin;
        private TextEdit txtIDCardNo;
        private ComboBoxEdit cmbGender;
        private TextEdit txtCode;
        private TextEdit txtName;
        private LabelControl labName;
        private LabelControl labGender;
        private GroupControl grpContactInfo;
        private DateEdit datEntry;
        private LabelControl labLoginName;
        private LabelControl labWorkType;
        private LabelControl labOffice;
        private LabelControl labHome;
        private LabelControl labEntry;
        private LabelControl labIDCardNo;
        private LabelControl labLeader;
        private LabelControl labTitle;
        private LabelControl labCode;
        private TextEdit txtHome;
        private TextEdit txtOffice;
        private GridLookUpEdit grlWorkType;
        private GridView gdvWorkType;
        private SearchLookUpEdit sleLeader;
        private GridView gdvLeader;
        private MemoEdit memDescription;
        private LabelControl labDescription;
    }
}
