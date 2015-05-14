namespace Insight.WS.Client.Common.Dialog
{
    partial class ChangePw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtConfirmPw = new DevExpress.XtraEditors.TextEdit();
            this.labConfirmPw = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPw = new DevExpress.XtraEditors.TextEdit();
            this.labOldPw = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPw = new DevExpress.XtraEditors.TextEdit();
            this.labNewPw = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txtConfirmPw);
            this.panel.Controls.Add(this.labConfirmPw);
            this.panel.Controls.Add(this.txtOldPw);
            this.panel.Controls.Add(this.labOldPw);
            this.panel.Controls.Add(this.txtNewPw);
            this.panel.Controls.Add(this.labNewPw);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            // 
            // txtConfirmPw
            // 
            this.txtConfirmPw.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtConfirmPw.Location = new System.Drawing.Point(145, 100);
            this.txtConfirmPw.Name = "txtConfirmPw";
            this.txtConfirmPw.Properties.PasswordChar = '○';
            this.txtConfirmPw.Size = new System.Drawing.Size(160, 20);
            this.txtConfirmPw.TabIndex = 3;
            // 
            // labConfirmPw
            // 
            this.labConfirmPw.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labConfirmPw.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labConfirmPw.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labConfirmPw.Location = new System.Drawing.Point(65, 100);
            this.labConfirmPw.Name = "labConfirmPw";
            this.labConfirmPw.Size = new System.Drawing.Size(80, 21);
            this.labConfirmPw.TabIndex = 9;
            this.labConfirmPw.Text = "确认密码：";
            // 
            // txtOldPw
            // 
            this.txtOldPw.EnterMoveNextControl = true;
            this.txtOldPw.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOldPw.Location = new System.Drawing.Point(145, 30);
            this.txtOldPw.Name = "txtOldPw";
            this.txtOldPw.Size = new System.Drawing.Size(160, 20);
            this.txtOldPw.TabIndex = 1;
            // 
            // labOldPw
            // 
            this.labOldPw.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labOldPw.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labOldPw.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labOldPw.Location = new System.Drawing.Point(65, 30);
            this.labOldPw.Name = "labOldPw";
            this.labOldPw.Size = new System.Drawing.Size(80, 21);
            this.labOldPw.TabIndex = 5;
            this.labOldPw.Text = "原 密 码：";
            // 
            // txtNewPw
            // 
            this.txtNewPw.EnterMoveNextControl = true;
            this.txtNewPw.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNewPw.Location = new System.Drawing.Point(145, 65);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.Properties.PasswordChar = '○';
            this.txtNewPw.Size = new System.Drawing.Size(160, 20);
            this.txtNewPw.TabIndex = 2;
            // 
            // labNewPw
            // 
            this.labNewPw.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labNewPw.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labNewPw.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labNewPw.Location = new System.Drawing.Point(65, 65);
            this.labNewPw.Name = "labNewPw";
            this.labNewPw.Size = new System.Drawing.Size(80, 21);
            this.labNewPw.TabIndex = 7;
            this.labNewPw.Text = "新 密 码：";
            // 
            // ChangePw
            // 
            this.Name = "ChangePw";
            this.Text = "更换密码";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPw.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtConfirmPw;
        private DevExpress.XtraEditors.LabelControl labConfirmPw;
        private DevExpress.XtraEditors.TextEdit txtOldPw;
        private DevExpress.XtraEditors.LabelControl labOldPw;
        private DevExpress.XtraEditors.TextEdit txtNewPw;
        private DevExpress.XtraEditors.LabelControl labNewPw;

    }
}