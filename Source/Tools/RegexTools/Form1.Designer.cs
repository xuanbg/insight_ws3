namespace RegexTools
{
    partial class FormRex
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtRex = new DevExpress.XtraEditors.TextEdit();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.labRex = new DevExpress.XtraEditors.LabelControl();
            this.labInput = new DevExpress.XtraEditors.LabelControl();
            this.labResult = new DevExpress.XtraEditors.LabelControl();
            this.labOutput = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtRex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRex
            // 
            this.txtRex.Location = new System.Drawing.Point(79, 47);
            this.txtRex.Name = "txtRex";
            this.txtRex.Size = new System.Drawing.Size(422, 20);
            this.txtRex.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(79, 95);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(422, 20);
            this.txtInput.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(227, 171);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "验证";
            this.btnCheck.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labRex
            // 
            this.labRex.Location = new System.Drawing.Point(37, 50);
            this.labRex.Name = "labRex";
            this.labRex.Size = new System.Drawing.Size(36, 14);
            this.labRex.TabIndex = 3;
            this.labRex.Text = "正则：";
            // 
            // labInput
            // 
            this.labInput.Location = new System.Drawing.Point(37, 98);
            this.labInput.Name = "labInput";
            this.labInput.Size = new System.Drawing.Size(36, 14);
            this.labInput.TabIndex = 4;
            this.labInput.Text = "输入：";
            // 
            // labResult
            // 
            this.labResult.Location = new System.Drawing.Point(37, 142);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(36, 14);
            this.labResult.TabIndex = 4;
            this.labResult.Text = "结果：";
            // 
            // labOutput
            // 
            this.labOutput.Location = new System.Drawing.Point(79, 143);
            this.labOutput.Name = "labOutput";
            this.labOutput.Size = new System.Drawing.Size(0, 14);
            this.labOutput.TabIndex = 4;
            // 
            // FormRex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 226);
            this.Controls.Add(this.labOutput);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.labInput);
            this.Controls.Add(this.labRex);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtRex);
            this.Name = "FormRex";
            this.Text = "正则验证工具";
            ((System.ComponentModel.ISupportInitialize)(this.txtRex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtRex;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.LabelControl labRex;
        private DevExpress.XtraEditors.LabelControl labInput;
        private DevExpress.XtraEditors.LabelControl labResult;
        private DevExpress.XtraEditors.LabelControl labOutput;
    }
}

