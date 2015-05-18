using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Common
{
    partial class Contact
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Contact));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.datBirthday = new DevExpress.XtraEditors.DateEdit();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.labTitle = new DevExpress.XtraEditors.LabelControl();
            this.labMiddleName = new DevExpress.XtraEditors.LabelControl();
            this.labFirstName = new DevExpress.XtraEditors.LabelControl();
            this.labLastName = new DevExpress.XtraEditors.LabelControl();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtMiddleName = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtLoginName = new DevExpress.XtraEditors.TextEdit();
            this.labLoginName = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labOffice = new DevExpress.XtraEditors.LabelControl();
            this.labDescription = new DevExpress.XtraEditors.LabelControl();
            this.labHome = new DevExpress.XtraEditors.LabelControl();
            this.txtHome = new DevExpress.XtraEditors.TextEdit();
            this.txtOffice = new DevExpress.XtraEditors.TextEdit();
            this.grpContactInfo = new DevExpress.XtraEditors.GroupControl();
            this.grdContact = new DevExpress.XtraGrid.GridControl();
            this.gdvContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lokContact = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.labBirthday = new DevExpress.XtraEditors.LabelControl();
            this.labDepartment = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.chkIsLogin = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsMaster = new DevExpress.XtraEditors.CheckEdit();
            this.labGender = new DevExpress.XtraEditors.LabelControl();
            this.cmbGender = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBirthday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBirthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiddleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpContactInfo)).BeginInit();
            this.grpContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGender.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cmbGender);
            this.panel.Controls.Add(this.labDepartment);
            this.panel.Controls.Add(this.txtDepartment);
            this.panel.Controls.Add(this.chkIsLogin);
            this.panel.Controls.Add(this.chkIsMaster);
            this.panel.Controls.Add(this.grpContactInfo);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.labOffice);
            this.panel.Controls.Add(this.labDescription);
            this.panel.Controls.Add(this.labHome);
            this.panel.Controls.Add(this.txtHome);
            this.panel.Controls.Add(this.txtOffice);
            this.panel.Controls.Add(this.labGender);
            this.panel.Controls.Add(this.labBirthday);
            this.panel.Controls.Add(this.labMiddleName);
            this.panel.Controls.Add(this.labFirstName);
            this.panel.Controls.Add(this.labLastName);
            this.panel.Controls.Add(this.txtLoginName);
            this.panel.Controls.Add(this.txtFirstName);
            this.panel.Controls.Add(this.txtMiddleName);
            this.panel.Controls.Add(this.txtLastName);
            this.panel.Controls.Add(this.labLoginName);
            this.panel.Controls.Add(this.labTitle);
            this.panel.Controls.Add(this.txtTitle);
            this.panel.Controls.Add(this.datBirthday);
            this.panel.Size = new System.Drawing.Size(470, 380);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(390, 404);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(300, 404);
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
            // datBirthday
            // 
            this.datBirthday.EditValue = null;
            this.datBirthday.EnterMoveNextControl = true;
            this.datBirthday.Location = new System.Drawing.Point(180, 45);
            this.datBirthday.Name = "datBirthday";
            this.datBirthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("datBirthday.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datBirthday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datBirthday.Properties.NullDate = "";
            this.datBirthday.Size = new System.Drawing.Size(100, 22);
            this.datBirthday.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.EnterMoveNextControl = true;
            this.txtTitle.Location = new System.Drawing.Point(360, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.AutoHeight = false;
            this.txtTitle.Size = new System.Drawing.Size(100, 21);
            this.txtTitle.TabIndex = 7;
            // 
            // labTitle
            // 
            this.labTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTitle.Location = new System.Drawing.Point(300, 45);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(60, 21);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "职务：";
            // 
            // labMiddleName
            // 
            this.labMiddleName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMiddleName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMiddleName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMiddleName.Location = new System.Drawing.Point(0, 75);
            this.labMiddleName.Name = "labMiddleName";
            this.labMiddleName.Size = new System.Drawing.Size(40, 21);
            this.labMiddleName.TabIndex = 178;
            this.labMiddleName.Text = "字：";
            // 
            // labFirstName
            // 
            this.labFirstName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labFirstName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labFirstName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labFirstName.Location = new System.Drawing.Point(0, 45);
            this.labFirstName.Name = "labFirstName";
            this.labFirstName.Size = new System.Drawing.Size(40, 21);
            this.labFirstName.TabIndex = 0;
            this.labFirstName.Text = "名：";
            // 
            // labLastName
            // 
            this.labLastName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labLastName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labLastName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labLastName.Location = new System.Drawing.Point(0, 15);
            this.labLastName.Name = "labLastName";
            this.labLastName.Size = new System.Drawing.Size(40, 21);
            this.labLastName.TabIndex = 0;
            this.labLastName.Text = "姓：";
            // 
            // txtFirstName
            // 
            this.txtFirstName.EnterMoveNextControl = true;
            this.txtFirstName.Location = new System.Drawing.Point(40, 45);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.AutoHeight = false;
            this.txtFirstName.Size = new System.Drawing.Size(80, 21);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.EnterMoveNextControl = true;
            this.txtMiddleName.Location = new System.Drawing.Point(40, 75);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Properties.AutoHeight = false;
            this.txtMiddleName.Properties.MaxLength = 18;
            this.txtMiddleName.Size = new System.Drawing.Size(80, 21);
            this.txtMiddleName.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.EnterMoveNextControl = true;
            this.txtLastName.Location = new System.Drawing.Point(40, 15);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.AutoHeight = false;
            this.txtLastName.Size = new System.Drawing.Size(80, 21);
            this.txtLastName.TabIndex = 1;
            // 
            // txtLoginName
            // 
            this.txtLoginName.EnterMoveNextControl = true;
            this.txtLoginName.Location = new System.Drawing.Point(180, 75);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Properties.AutoHeight = false;
            this.txtLoginName.Size = new System.Drawing.Size(100, 21);
            this.txtLoginName.TabIndex = 8;
            this.txtLoginName.EditValueChanged += new System.EventHandler(this.txtLoginName_EditValueChanged);
            // 
            // labLoginName
            // 
            this.labLoginName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labLoginName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labLoginName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labLoginName.Location = new System.Drawing.Point(120, 75);
            this.labLoginName.Name = "labLoginName";
            this.labLoginName.Size = new System.Drawing.Size(60, 21);
            this.labLoginName.TabIndex = 0;
            this.labLoginName.Text = "账号：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(80, 170);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new System.Drawing.Size(380, 40);
            this.memDescription.TabIndex = 13;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // labOffice
            // 
            this.labOffice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labOffice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labOffice.Location = new System.Drawing.Point(0, 110);
            this.labOffice.Name = "labOffice";
            this.labOffice.Size = new System.Drawing.Size(80, 21);
            this.labOffice.TabIndex = 179;
            this.labOffice.Text = "办公地点：";
            // 
            // labDescription
            // 
            this.labDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDescription.Location = new System.Drawing.Point(0, 170);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(80, 21);
            this.labDescription.TabIndex = 180;
            this.labDescription.Text = "备注：";
            // 
            // labHome
            // 
            this.labHome.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labHome.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labHome.Location = new System.Drawing.Point(0, 140);
            this.labHome.Name = "labHome";
            this.labHome.Size = new System.Drawing.Size(80, 21);
            this.labHome.TabIndex = 181;
            this.labHome.Text = "家庭住址：";
            // 
            // txtHome
            // 
            this.txtHome.EnterMoveNextControl = true;
            this.txtHome.Location = new System.Drawing.Point(80, 140);
            this.txtHome.Name = "txtHome";
            this.txtHome.Size = new System.Drawing.Size(380, 20);
            this.txtHome.TabIndex = 12;
            // 
            // txtOffice
            // 
            this.txtOffice.EnterMoveNextControl = true;
            this.txtOffice.Location = new System.Drawing.Point(80, 110);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(380, 20);
            this.txtOffice.TabIndex = 11;
            // 
            // grpContactInfo
            // 
            this.grpContactInfo.Controls.Add(this.grdContact);
            this.grpContactInfo.Location = new System.Drawing.Point(10, 220);
            this.grpContactInfo.Name = "grpContactInfo";
            this.grpContactInfo.Size = new System.Drawing.Size(450, 150);
            this.grpContactInfo.TabIndex = 14;
            this.grpContactInfo.Text = "联系方式";
            // 
            // grdContact
            // 
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.Location = new System.Drawing.Point(2, 22);
            this.grdContact.MainView = this.gdvContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lokContact});
            this.grdContact.Size = new System.Drawing.Size(446, 126);
            this.grdContact.TabIndex = 1;
            this.grdContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvContact});
            // 
            // gdvContact
            // 
            this.gdvContact.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gdvContact.GridControl = this.grdContact;
            this.gdvContact.Name = "gdvContact";
            this.gdvContact.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gdvContact.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gdvContact_RowCellClick);
            this.gdvContact.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gdvContact_CellValueChanged);
            this.gdvContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvContact_KeyDown);
            // 
            // lokContact
            // 
            this.lokContact.AutoHeight = false;
            this.lokContact.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokContact.Name = "lokContact";
            this.lokContact.NullText = "";
            this.lokContact.PopupFormMinSize = new System.Drawing.Size(100, 100);
            this.lokContact.PopupWidth = 120;
            this.lokContact.ShowHeader = false;
            this.lokContact.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // labBirthday
            // 
            this.labBirthday.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labBirthday.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labBirthday.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labBirthday.Location = new System.Drawing.Point(120, 45);
            this.labBirthday.Name = "labBirthday";
            this.labBirthday.Size = new System.Drawing.Size(60, 21);
            this.labBirthday.TabIndex = 0;
            this.labBirthday.Text = "生日：";
            // 
            // labDepartment
            // 
            this.labDepartment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDepartment.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDepartment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDepartment.Location = new System.Drawing.Point(280, 15);
            this.labDepartment.Name = "labDepartment";
            this.labDepartment.Size = new System.Drawing.Size(80, 21);
            this.labDepartment.TabIndex = 0;
            this.labDepartment.Text = "任职部门：";
            // 
            // txtDepartment
            // 
            this.txtDepartment.EnterMoveNextControl = true;
            this.txtDepartment.Location = new System.Drawing.Point(360, 15);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Properties.AutoHeight = false;
            this.txtDepartment.Size = new System.Drawing.Size(100, 21);
            this.txtDepartment.TabIndex = 6;
            // 
            // chkIsLogin
            // 
            this.chkIsLogin.Enabled = false;
            this.chkIsLogin.Location = new System.Drawing.Point(285, 75);
            this.chkIsLogin.Name = "chkIsLogin";
            this.chkIsLogin.Properties.AutoHeight = false;
            this.chkIsLogin.Properties.Caption = "登录用户";
            this.chkIsLogin.Size = new System.Drawing.Size(75, 21);
            this.chkIsLogin.TabIndex = 9;
            this.chkIsLogin.CheckedChanged += new System.EventHandler(this.chkIsLogin_CheckedChanged);
            // 
            // chkIsMaster
            // 
            this.chkIsMaster.Location = new System.Drawing.Point(360, 75);
            this.chkIsMaster.Name = "chkIsMaster";
            this.chkIsMaster.Properties.AutoHeight = false;
            this.chkIsMaster.Properties.Caption = "主要联系人";
            this.chkIsMaster.Size = new System.Drawing.Size(80, 21);
            this.chkIsMaster.TabIndex = 10;
            // 
            // labGender
            // 
            this.labGender.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labGender.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labGender.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labGender.Location = new System.Drawing.Point(120, 15);
            this.labGender.Name = "labGender";
            this.labGender.Size = new System.Drawing.Size(60, 21);
            this.labGender.TabIndex = 0;
            this.labGender.Text = "性别：";
            // 
            // cmbGender
            // 
            this.cmbGender.EnterMoveNextControl = true;
            this.cmbGender.Location = new System.Drawing.Point(180, 15);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGender.Properties.Items.AddRange(new object[] {
            "女",
            "男"});
            this.cmbGender.Properties.NullText = "请选择…";
            this.cmbGender.Size = new System.Drawing.Size(100, 20);
            this.cmbGender.TabIndex = 4;
            // 
            // Contact
            // 
            this.ClientSize = new System.Drawing.Size(484, 442);
            this.Name = "Contact";
            this.Text = "联系人";
            this.Load += new System.EventHandler(this.Contact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBirthday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBirthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiddleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpContactInfo)).EndInit();
            this.grpContactInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGender.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateEdit datBirthday;
        private TextEdit txtTitle;
        private LabelControl labTitle;
        private LabelControl labMiddleName;
        private LabelControl labFirstName;
        private LabelControl labLastName;
        private TextEdit txtFirstName;
        private TextEdit txtMiddleName;
        private TextEdit txtLastName;
        private TextEdit txtLoginName;
        private LabelControl labLoginName;
        private MemoEdit memDescription;
        private LabelControl labOffice;
        private LabelControl labDescription;
        private LabelControl labHome;
        private TextEdit txtHome;
        private TextEdit txtOffice;
        private GroupControl grpContactInfo;
        private GridControl grdContact;
        private GridView gdvContact;
        private RepositoryItemLookUpEdit lokContact;
        private LabelControl labBirthday;
        private LabelControl labDepartment;
        private TextEdit txtDepartment;
        private CheckEdit chkIsLogin;
        private CheckEdit chkIsMaster;
        private LabelControl labGender;
        private ComboBoxEdit cmbGender;

    }
}
