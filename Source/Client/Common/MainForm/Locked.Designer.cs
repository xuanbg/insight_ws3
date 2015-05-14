namespace Insight.WS.Client.Common.Dialog
{
    partial class Unlock
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
            this.txtUnlockPw = new DevExpress.XtraEditors.TextEdit();
            this.labUnlockPw = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnlockPw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Text = "解  锁";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txtUnlockPw);
            this.panel.Controls.Add(this.labUnlockPw);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Visible = false;
            // 
            // txtUnlockPw
            // 
            this.txtUnlockPw.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUnlockPw.Location = new System.Drawing.Point(145, 65);
            this.txtUnlockPw.Name = "txtUnlockPw";
            this.txtUnlockPw.Properties.PasswordChar = '○';
            this.txtUnlockPw.Size = new System.Drawing.Size(160, 20);
            this.txtUnlockPw.TabIndex = 2;
            // 
            // labUnlockPw
            // 
            this.labUnlockPw.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labUnlockPw.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labUnlockPw.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labUnlockPw.Location = new System.Drawing.Point(65, 65);
            this.labUnlockPw.Name = "labUnlockPw";
            this.labUnlockPw.Size = new System.Drawing.Size(80, 21);
            this.labUnlockPw.TabIndex = 3;
            this.labUnlockPw.Text = "输入密码：";
            // 
            // Unlock
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.ControlBox = false;
            this.Name = "Unlock";
            this.Text = "锁定";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUnlockPw.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUnlockPw;
        private DevExpress.XtraEditors.LabelControl labUnlockPw;
    }
}