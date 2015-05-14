using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.MainApp
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.lokDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetting = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labDepartment = new DevExpress.XtraEditors.LabelControl();
            this.labPassword = new DevExpress.XtraEditors.LabelControl();
            this.labUser = new DevExpress.XtraEditors.LabelControl();
            this.pbcLogin = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lokDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcLogin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panel.Appearance.Options.UseBackColor = true;
            this.panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel.Controls.Add(this.lokDepartment);
            this.panel.Controls.Add(this.btnLogin);
            this.panel.Controls.Add(this.btnSetting);
            this.panel.Controls.Add(this.btnCancel);
            this.panel.Controls.Add(this.txtPassWord);
            this.panel.Controls.Add(this.txtUserName);
            this.panel.Controls.Add(this.labDepartment);
            this.panel.Controls.Add(this.labPassword);
            this.panel.Controls.Add(this.labUser);
            this.panel.Location = new System.Drawing.Point(130, 135);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(260, 130);
            this.panel.TabIndex = 0;
            this.panel.Visible = false;
            // 
            // lokDepartment
            // 
            this.lokDepartment.EnterMoveNextControl = true;
            this.lokDepartment.Location = new System.Drawing.Point(80, 70);
            this.lokDepartment.Name = "lokDepartment";
            this.lokDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lokDepartment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lokDepartment.Properties.NullText = "";
            this.lokDepartment.Properties.ShowFooter = false;
            this.lokDepartment.Properties.ShowHeader = false;
            this.lokDepartment.Properties.ShowLines = false;
            this.lokDepartment.Size = new System.Drawing.Size(160, 22);
            this.lokDepartment.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(180, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登  录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Appearance.Options.UseFont = true;
            this.btnSetting.Location = new System.Drawing.Point(90, 105);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(80, 23);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.Text = "设  置";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(0, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.EditValue = "";
            this.txtPassWord.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPassWord.Location = new System.Drawing.Point(80, 35);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.AutoHeight = false;
            this.txtPassWord.Properties.PasswordChar = '○';
            this.txtPassWord.Size = new System.Drawing.Size(160, 21);
            this.txtPassWord.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(80, 0);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.AutoHeight = false;
            this.txtUserName.Size = new System.Drawing.Size(160, 21);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // labDepartment
            // 
            this.labDepartment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDepartment.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDepartment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDepartment.Location = new System.Drawing.Point(0, 70);
            this.labDepartment.Name = "labDepartment";
            this.labDepartment.Size = new System.Drawing.Size(80, 21);
            this.labDepartment.TabIndex = 0;
            this.labDepartment.Text = "登录部门：";
            // 
            // labPassword
            // 
            this.labPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPassword.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPassword.CausesValidation = false;
            this.labPassword.Location = new System.Drawing.Point(0, 35);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(80, 21);
            this.labPassword.TabIndex = 0;
            this.labPassword.Text = "密 码：";
            // 
            // labUser
            // 
            this.labUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labUser.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labUser.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labUser.Location = new System.Drawing.Point(0, 0);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(80, 21);
            this.labUser.TabIndex = 0;
            this.labUser.Text = "用 户 名：";
            // 
            // pbcLogin
            // 
            this.pbcLogin.EditValue = 0;
            this.pbcLogin.Location = new System.Drawing.Point(130, 185);
            this.pbcLogin.Name = "pbcLogin";
            this.pbcLogin.Properties.ShowTitle = true;
            this.pbcLogin.Size = new System.Drawing.Size(260, 24);
            this.pbcLogin.TabIndex = 0;
            this.pbcLogin.Visible = false;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 320);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.pbcLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insight Workstation 3";
            this.Shown += new System.EventHandler(this.Login_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lokDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcLogin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panel;
        private LookUpEdit lokDepartment;
        private SimpleButton btnLogin;
        private SimpleButton btnSetting;
        private SimpleButton btnCancel;
        private TextEdit txtPassWord;
        private TextEdit txtUserName;
        private LabelControl labDepartment;
        private LabelControl labPassword;
        private LabelControl labUser;
        private MarqueeProgressBarControl pbcLogin;
    }
}