using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Common
{
    partial class Waiting
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Waiting));
            this.pbcLogin = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbcLogin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pbcLogin
            // 
            this.pbcLogin.EditValue = "正在加载主窗体，请稍候…";
            this.pbcLogin.Location = new System.Drawing.Point(130, 185);
            this.pbcLogin.Name = "pbcLogin";
            this.pbcLogin.Properties.ShowTitle = true;
            this.pbcLogin.Size = new System.Drawing.Size(260, 24);
            this.pbcLogin.TabIndex = 1;
            // 
            // Waiting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(520, 320);
            this.Controls.Add(this.pbcLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Waiting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insight Workstation 3";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbcLogin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MarqueeProgressBarControl pbcLogin;
    }
}