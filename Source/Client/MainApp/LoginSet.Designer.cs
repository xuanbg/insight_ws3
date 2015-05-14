using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.MainApp
{
    partial class LoginSet
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
            this.chkIsSaveUser = new System.Windows.Forms.CheckBox();
            this.labAddress = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.labPort = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.chkIsSaveUser);
            this.panel.Controls.Add(this.labAddress);
            this.panel.Controls.Add(this.txtAddress);
            this.panel.Controls.Add(this.txtPort);
            this.panel.Controls.Add(this.labPort);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            // 
            // chkIsSaveUser
            // 
            this.chkIsSaveUser.AutoSize = true;
            this.chkIsSaveUser.Location = new System.Drawing.Point(254, 93);
            this.chkIsSaveUser.Name = "chkIsSaveUser";
            this.chkIsSaveUser.Size = new System.Drawing.Size(86, 18);
            this.chkIsSaveUser.TabIndex = 8;
            this.chkIsSaveUser.Text = "保存用户名";
            this.chkIsSaveUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsSaveUser.UseVisualStyleBackColor = true;
            // 
            // labAddress
            // 
            this.labAddress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labAddress.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labAddress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labAddress.Location = new System.Drawing.Point(20, 45);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(80, 21);
            this.labAddress.TabIndex = 4;
            this.labAddress.Text = "服务器地址：";
            // 
            // txtAddress
            // 
            this.txtAddress.EnterMoveNextControl = true;
            this.txtAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtAddress.Location = new System.Drawing.Point(100, 45);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(240, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // txtPort
            // 
            this.txtPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPort.Location = new System.Drawing.Point(100, 90);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 20);
            this.txtPort.TabIndex = 7;
            // 
            // labPort
            // 
            this.labPort.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPort.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labPort.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPort.Location = new System.Drawing.Point(20, 90);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(80, 21);
            this.labPort.TabIndex = 6;
            this.labPort.Text = "端口号：";
            // 
            // LoginSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);

            this.ClientSize = new System.Drawing.Size(384, 211);
            this.ControlBox = false;
            this.Name = "LoginSet";
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox chkIsSaveUser;
        private LabelControl labAddress;
        private TextEdit txtAddress;
        private TextEdit txtPort;
        private LabelControl labPort;

    }
}