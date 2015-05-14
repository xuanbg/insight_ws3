using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;

namespace Insight.WS.Client.Business.CRM
{
    partial class Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtAlias = new DevExpress.XtraEditors.TextEdit();
            this.datRegisterDate = new DevExpress.XtraEditors.DateEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lokDistrict = new DevExpress.XtraEditors.LookUpEdit();
            this.lokProvince = new DevExpress.XtraEditors.LookUpEdit();
            this.lokCity = new DevExpress.XtraEditors.LookUpEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtBusiness = new DevExpress.XtraEditors.TextEdit();
            this.txtWebsite = new DevExpress.XtraEditors.TextEdit();
            this.txtZipCode = new DevExpress.XtraEditors.TextEdit();
            this.lokIndustry = new DevExpress.XtraEditors.LookUpEdit();
            this.lokEnterprise = new DevExpress.XtraEditors.LookUpEdit();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.labAlias = new DevExpress.XtraEditors.LabelControl();
            this.labAddress = new DevExpress.XtraEditors.LabelControl();
            this.txtTax = new DevExpress.XtraEditors.TextEdit();
            this.txtRegister = new DevExpress.XtraEditors.TextEdit();
            this.labZipCode = new DevExpress.XtraEditors.LabelControl();
            this.labWebsite = new DevExpress.XtraEditors.LabelControl();
            this.labDescription = new DevExpress.XtraEditors.LabelControl();
            this.labCorporation = new DevExpress.XtraEditors.LabelControl();
            this.txtCorporation = new DevExpress.XtraEditors.TextEdit();
            this.lokClass = new DevExpress.XtraEditors.LookUpEdit();
            this.labPhone = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labIndustry = new DevExpress.XtraEditors.LabelControl();
            this.labClass = new DevExpress.XtraEditors.LabelControl();
            this.labStatu = new DevExpress.XtraEditors.LabelControl();
            this.lokStatu = new DevExpress.XtraEditors.LookUpEdit();
            this.labEnterprise = new DevExpress.XtraEditors.LabelControl();
            this.labBusiness = new DevExpress.XtraEditors.LabelControl();
            this.labRegister = new DevExpress.XtraEditors.LabelControl();
            this.labTax = new DevExpress.XtraEditors.LabelControl();
            this.labRegisterDate = new DevExpress.XtraEditors.LabelControl();
            this.labScale = new DevExpress.XtraEditors.LabelControl();
            this.labStaffs = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.speStaffs = new DevExpress.XtraEditors.SpinEdit();
            this.txtScale = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRegisterDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRegisterDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokDistrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusiness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokIndustry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokEnterprise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegister.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokStatu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speStaffs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScale.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.labStaffs);
            this.panel.Controls.Add(this.labScale);
            this.panel.Controls.Add(this.labRegisterDate);
            this.panel.Controls.Add(this.txtPhone);
            this.panel.Controls.Add(this.labTax);
            this.panel.Controls.Add(this.labPhone);
            this.panel.Controls.Add(this.txtZipCode);
            this.panel.Controls.Add(this.labBusiness);
            this.panel.Controls.Add(this.labZipCode);
            this.panel.Controls.Add(this.datRegisterDate);
            this.panel.Controls.Add(this.labRegister);
            this.panel.Controls.Add(this.labEnterprise);
            this.panel.Controls.Add(this.labIndustry);
            this.panel.Controls.Add(this.labelControl7);
            this.panel.Controls.Add(this.labelControl6);
            this.panel.Controls.Add(this.labCorporation);
            this.panel.Controls.Add(this.txtCorporation);
            this.panel.Controls.Add(this.labDescription);
            this.panel.Controls.Add(this.labWebsite);
            this.panel.Controls.Add(this.txtTax);
            this.panel.Controls.Add(this.txtRegister);
            this.panel.Controls.Add(this.labAddress);
            this.panel.Controls.Add(this.labStatu);
            this.panel.Controls.Add(this.labClass);
            this.panel.Controls.Add(this.labAlias);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.txtAddress);
            this.panel.Controls.Add(this.lokDistrict);
            this.panel.Controls.Add(this.lokProvince);
            this.panel.Controls.Add(this.lokCity);
            this.panel.Controls.Add(this.lokEnterprise);
            this.panel.Controls.Add(this.lokStatu);
            this.panel.Controls.Add(this.lokClass);
            this.panel.Controls.Add(this.txtBusiness);
            this.panel.Controls.Add(this.txtWebsite);
            this.panel.Controls.Add(this.lokIndustry);
            this.panel.Controls.Add(this.txtAlias);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.speStaffs);
            this.panel.Controls.Add(this.txtScale);
            this.panel.Size = new System.Drawing.Size(570, 300);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(490, 324);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(400, 324);
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
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new System.Drawing.Point(315, 15);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(60, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // datRegisterDate
            // 
            this.datRegisterDate.EditValue = null;
            this.datRegisterDate.Location = new System.Drawing.Point(435, 200);
            this.datRegisterDate.Name = "datRegisterDate";
            this.datRegisterDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("datRegisterDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datRegisterDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datRegisterDate.Properties.NullDate = "";
            this.datRegisterDate.Size = new System.Drawing.Size(120, 22);
            this.datRegisterDate.TabIndex = 20;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(60, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            // 
            // lokDistrict
            // 
            this.lokDistrict.EnterMoveNextControl = true;
            this.lokDistrict.Location = new System.Drawing.Point(265, 45);
            this.lokDistrict.Name = "lokDistrict";
            this.lokDistrict.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokDistrict.Properties.NullText = "请选择…";
            this.lokDistrict.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokDistrict.Properties.PopupWidth = 100;
            this.lokDistrict.Size = new System.Drawing.Size(110, 20);
            this.lokDistrict.TabIndex = 6;
            // 
            // lokProvince
            // 
            this.lokProvince.EnterMoveNextControl = true;
            this.lokProvince.Location = new System.Drawing.Point(60, 45);
            this.lokProvince.Name = "lokProvince";
            this.lokProvince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokProvince.Properties.NullText = "请选择…";
            this.lokProvince.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokProvince.Properties.PopupWidth = 100;
            this.lokProvince.Size = new System.Drawing.Size(100, 20);
            this.lokProvince.TabIndex = 4;
            this.lokProvince.EditValueChanged += new System.EventHandler(this.Province_EditValueChanged);
            // 
            // lokCity
            // 
            this.lokCity.EnterMoveNextControl = true;
            this.lokCity.Location = new System.Drawing.Point(165, 45);
            this.lokCity.Name = "lokCity";
            this.lokCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokCity.Properties.NullText = "请选择…";
            this.lokCity.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokCity.Properties.PopupWidth = 100;
            this.lokCity.Size = new System.Drawing.Size(95, 20);
            this.lokCity.TabIndex = 5;
            this.lokCity.EditValueChanged += new System.EventHandler(this.City_EditValueChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.EnterMoveNextControl = true;
            this.txtAddress.Location = new System.Drawing.Point(60, 75);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(80, 235);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new System.Drawing.Size(475, 50);
            this.memDescription.TabIndex = 21;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // txtBusiness
            // 
            this.txtBusiness.Location = new System.Drawing.Point(80, 200);
            this.txtBusiness.Name = "txtBusiness";
            this.txtBusiness.Size = new System.Drawing.Size(135, 20);
            this.txtBusiness.TabIndex = 14;
            // 
            // txtWebsite
            // 
            this.txtWebsite.EnterMoveNextControl = true;
            this.txtWebsite.Location = new System.Drawing.Point(60, 105);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(200, 20);
            this.txtWebsite.TabIndex = 9;
            // 
            // txtZipCode
            // 
            this.txtZipCode.EnterMoveNextControl = true;
            this.txtZipCode.Location = new System.Drawing.Point(315, 75);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Properties.Mask.EditMask = "d6";
            this.txtZipCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtZipCode.Size = new System.Drawing.Size(60, 20);
            this.txtZipCode.TabIndex = 8;
            // 
            // lokIndustry
            // 
            this.lokIndustry.Location = new System.Drawing.Point(80, 140);
            this.lokIndustry.Name = "lokIndustry";
            this.lokIndustry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokIndustry.Properties.NullText = "请选择…";
            this.lokIndustry.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokIndustry.Properties.PopupWidth = 135;
            this.lokIndustry.Size = new System.Drawing.Size(135, 20);
            this.lokIndustry.TabIndex = 12;
            // 
            // lokEnterprise
            // 
            this.lokEnterprise.Location = new System.Drawing.Point(80, 170);
            this.lokEnterprise.Name = "lokEnterprise";
            this.lokEnterprise.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokEnterprise.Properties.NullText = "请选择…";
            this.lokEnterprise.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokEnterprise.Properties.PopupWidth = 135;
            this.lokEnterprise.Size = new System.Drawing.Size(135, 20);
            this.lokEnterprise.TabIndex = 13;
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(0, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // labAlias
            // 
            this.labAlias.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labAlias.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labAlias.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labAlias.Location = new System.Drawing.Point(260, 15);
            this.labAlias.Name = "labAlias";
            this.labAlias.Size = new System.Drawing.Size(55, 21);
            this.labAlias.TabIndex = 0;
            this.labAlias.Text = "简称：";
            // 
            // labAddress
            // 
            this.labAddress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labAddress.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labAddress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labAddress.Location = new System.Drawing.Point(0, 45);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(60, 21);
            this.labAddress.TabIndex = 0;
            this.labAddress.Text = "地址：";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(435, 170);
            this.txtTax.Name = "txtTax";
            this.txtTax.Properties.MaxLength = 15;
            this.txtTax.Size = new System.Drawing.Size(120, 20);
            this.txtTax.TabIndex = 19;
            // 
            // txtRegister
            // 
            this.txtRegister.Location = new System.Drawing.Point(435, 140);
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.Properties.MaxLength = 15;
            this.txtRegister.Size = new System.Drawing.Size(120, 20);
            this.txtRegister.TabIndex = 18;
            // 
            // labZipCode
            // 
            this.labZipCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labZipCode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labZipCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labZipCode.Location = new System.Drawing.Point(260, 75);
            this.labZipCode.Name = "labZipCode";
            this.labZipCode.Size = new System.Drawing.Size(55, 21);
            this.labZipCode.TabIndex = 0;
            this.labZipCode.Text = "邮编：";
            // 
            // labWebsite
            // 
            this.labWebsite.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labWebsite.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labWebsite.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labWebsite.Location = new System.Drawing.Point(0, 105);
            this.labWebsite.Name = "labWebsite";
            this.labWebsite.Size = new System.Drawing.Size(60, 21);
            this.labWebsite.TabIndex = 0;
            this.labWebsite.Text = "网站：";
            // 
            // labDescription
            // 
            this.labDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDescription.Location = new System.Drawing.Point(0, 235);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(80, 21);
            this.labDescription.TabIndex = 0;
            this.labDescription.Text = "备注：";
            // 
            // labCorporation
            // 
            this.labCorporation.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCorporation.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCorporation.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCorporation.Location = new System.Drawing.Point(215, 140);
            this.labCorporation.Name = "labCorporation";
            this.labCorporation.Size = new System.Drawing.Size(60, 21);
            this.labCorporation.TabIndex = 0;
            this.labCorporation.Text = "法人：";
            // 
            // txtCorporation
            // 
            this.txtCorporation.Location = new System.Drawing.Point(275, 140);
            this.txtCorporation.Name = "txtCorporation";
            this.txtCorporation.Size = new System.Drawing.Size(60, 20);
            this.txtCorporation.TabIndex = 15;
            // 
            // lokClass
            // 
            this.lokClass.Location = new System.Drawing.Point(435, 75);
            this.lokClass.Name = "lokClass";
            this.lokClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokClass.Properties.NullText = "请选择…";
            this.lokClass.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokClass.Properties.PopupWidth = 120;
            this.lokClass.Size = new System.Drawing.Size(120, 20);
            this.lokClass.TabIndex = 11;
            // 
            // labPhone
            // 
            this.labPhone.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPhone.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labPhone.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPhone.Location = new System.Drawing.Point(375, 15);
            this.labPhone.Name = "labPhone";
            this.labPhone.Size = new System.Drawing.Size(60, 21);
            this.labPhone.TabIndex = 0;
            this.labPhone.Text = "电话：";
            // 
            // txtPhone
            // 
            this.txtPhone.EnterMoveNextControl = true;
            this.txtPhone.Location = new System.Drawing.Point(435, 15);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Mask.EditMask = "\\d{3,4}?-?\\d{3,5}-?\\d{3,4}?";
            this.txtPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPhone.Size = new System.Drawing.Size(120, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // labIndustry
            // 
            this.labIndustry.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labIndustry.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labIndustry.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labIndustry.Location = new System.Drawing.Point(0, 140);
            this.labIndustry.Name = "labIndustry";
            this.labIndustry.Size = new System.Drawing.Size(80, 21);
            this.labIndustry.TabIndex = 0;
            this.labIndustry.Text = "行业类型：";
            // 
            // labClass
            // 
            this.labClass.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labClass.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labClass.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labClass.Location = new System.Drawing.Point(375, 75);
            this.labClass.Name = "labClass";
            this.labClass.Size = new System.Drawing.Size(60, 21);
            this.labClass.TabIndex = 0;
            this.labClass.Text = "类型：";
            // 
            // labStatu
            // 
            this.labStatu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labStatu.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labStatu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labStatu.Location = new System.Drawing.Point(375, 45);
            this.labStatu.Name = "labStatu";
            this.labStatu.Size = new System.Drawing.Size(60, 21);
            this.labStatu.TabIndex = 0;
            this.labStatu.Text = "状态：";
            // 
            // lokStatu
            // 
            this.lokStatu.EnterMoveNextControl = true;
            this.lokStatu.Location = new System.Drawing.Point(435, 45);
            this.lokStatu.Name = "lokStatu";
            this.lokStatu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokStatu.Properties.NullText = "请选择…";
            this.lokStatu.Properties.PopupFormMinSize = new System.Drawing.Size(80, 160);
            this.lokStatu.Properties.PopupWidth = 120;
            this.lokStatu.Size = new System.Drawing.Size(120, 20);
            this.lokStatu.TabIndex = 10;
            // 
            // labEnterprise
            // 
            this.labEnterprise.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labEnterprise.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labEnterprise.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labEnterprise.Location = new System.Drawing.Point(0, 170);
            this.labEnterprise.Name = "labEnterprise";
            this.labEnterprise.Size = new System.Drawing.Size(80, 21);
            this.labEnterprise.TabIndex = 0;
            this.labEnterprise.Text = "企业类型：";
            // 
            // labBusiness
            // 
            this.labBusiness.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labBusiness.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labBusiness.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labBusiness.Location = new System.Drawing.Point(0, 200);
            this.labBusiness.Name = "labBusiness";
            this.labBusiness.Size = new System.Drawing.Size(80, 21);
            this.labBusiness.TabIndex = 0;
            this.labBusiness.Text = "经营范围：";
            // 
            // labRegister
            // 
            this.labRegister.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labRegister.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labRegister.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labRegister.Location = new System.Drawing.Point(355, 140);
            this.labRegister.Name = "labRegister";
            this.labRegister.Size = new System.Drawing.Size(80, 21);
            this.labRegister.TabIndex = 0;
            this.labRegister.Text = "注册号：";
            // 
            // labTax
            // 
            this.labTax.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTax.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTax.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTax.Location = new System.Drawing.Point(355, 170);
            this.labTax.Name = "labTax";
            this.labTax.Size = new System.Drawing.Size(80, 21);
            this.labTax.TabIndex = 0;
            this.labTax.Text = "税号：";
            // 
            // labRegisterDate
            // 
            this.labRegisterDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labRegisterDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labRegisterDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labRegisterDate.Location = new System.Drawing.Point(355, 200);
            this.labRegisterDate.Name = "labRegisterDate";
            this.labRegisterDate.Size = new System.Drawing.Size(80, 21);
            this.labRegisterDate.TabIndex = 0;
            this.labRegisterDate.Text = "开业日期：";
            // 
            // labScale
            // 
            this.labScale.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labScale.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labScale.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labScale.Location = new System.Drawing.Point(215, 170);
            this.labScale.Name = "labScale";
            this.labScale.Size = new System.Drawing.Size(60, 21);
            this.labScale.TabIndex = 0;
            this.labScale.Text = "资产：";
            // 
            // labStaffs
            // 
            this.labStaffs.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labStaffs.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labStaffs.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labStaffs.Location = new System.Drawing.Point(215, 200);
            this.labStaffs.Name = "labStaffs";
            this.labStaffs.Size = new System.Drawing.Size(60, 21);
            this.labStaffs.TabIndex = 0;
            this.labStaffs.Text = "员工：";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(335, 170);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(20, 21);
            this.labelControl6.TabIndex = 165;
            this.labelControl6.Text = "万";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl7.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(335, 200);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(20, 21);
            this.labelControl7.TabIndex = 165;
            this.labelControl7.Text = "人";
            // 
            // speStaffs
            // 
            this.speStaffs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speStaffs.Location = new System.Drawing.Point(275, 200);
            this.speStaffs.Name = "speStaffs";
            this.speStaffs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speStaffs.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.speStaffs.Properties.Mask.EditMask = "d";
            this.speStaffs.Size = new System.Drawing.Size(60, 20);
            this.speStaffs.TabIndex = 17;
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(275, 170);
            this.txtScale.Name = "txtScale";
            this.txtScale.Properties.Mask.EditMask = "d";
            this.txtScale.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtScale.Size = new System.Drawing.Size(60, 20);
            this.txtScale.TabIndex = 16;
            // 
            // Customer
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Name = "Customer";
            this.Load += new System.EventHandler(this.Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRegisterDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datRegisterDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokDistrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusiness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokIndustry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokEnterprise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegister.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokStatu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speStaffs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScale.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextEdit txtAlias;
        private DateEdit datRegisterDate;
        private TextEdit txtName;
        private LookUpEdit lokDistrict;
        private LookUpEdit lokProvince;
        private LookUpEdit lokCity;
        private TextEdit txtAddress;
        private TextEdit txtZipCode;
        private LookUpEdit lokEnterprise;
        private TextEdit txtBusiness;
        private TextEdit txtWebsite;
        private LookUpEdit lokIndustry;
        private MemoEdit memDescription;
        private TextEdit txtTax;
        private TextEdit txtRegister;
        private LabelControl labAddress;
        private LabelControl labAlias;
        private LabelControl labName;
        private LabelControl labDescription;
        private LabelControl labWebsite;
        private LabelControl labZipCode;
        private LabelControl labCorporation;
        private TextEdit txtCorporation;
        private LookUpEdit lokClass;
        private LabelControl labPhone;
        private TextEdit txtPhone;
        private LabelControl labStaffs;
        private LabelControl labScale;
        private LabelControl labRegisterDate;
        private LabelControl labTax;
        private LabelControl labBusiness;
        private LabelControl labRegister;
        private LabelControl labEnterprise;
        private LabelControl labIndustry;
        private LabelControl labStatu;
        private LabelControl labClass;
        private LookUpEdit lokStatu;
        private LabelControl labelControl7;
        private LabelControl labelControl6;
        private SpinEdit speStaffs;
        private TextEdit txtScale;

    }
}
