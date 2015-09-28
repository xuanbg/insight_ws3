namespace Insight.WS.Client.XinFenBao
{
    partial class PlanManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanManage));
            this.grdPlan = new DevExpress.XtraGrid.GridControl();
            this.gdvPlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rleUserType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStageNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvalidDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rleUserType)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
            // 
            // xtraScrollable
            // 
            this.xtraScrollable.Controls.Add(this.grdPlan);
            // 
            // grdPlan
            // 
            this.grdPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPlan.Location = new System.Drawing.Point(5, 5);
            this.grdPlan.MainView = this.gdvPlan;
            this.grdPlan.Name = "grdPlan";
            this.grdPlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rleUserType});
            this.grdPlan.ShowOnlyPredefinedDetails = true;
            this.grdPlan.Size = new System.Drawing.Size(1070, 590);
            this.grdPlan.TabIndex = 1;
            this.grdPlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvPlan});
            // 
            // gdvPlan
            // 
            this.gdvPlan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDefault,
            this.colUserType,
            this.colStageNum,
            this.colRate,
            this.colDescription,
            this.colEffectiveDate,
            this.colInvalidDate,
            this.colCreateTime,
            this.colValidity});
            this.gdvPlan.GridControl = this.grdPlan;
            this.gdvPlan.Name = "gdvPlan";
            this.gdvPlan.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvPlan_FocusedRowObjectChanged);
            // 
            // colDefault
            // 
            this.colDefault.Caption = "默认";
            this.colDefault.FieldName = "Default";
            this.colDefault.Name = "colDefault";
            this.colDefault.Visible = true;
            this.colDefault.VisibleIndex = 0;
            this.colDefault.Width = 40;
            // 
            // colUserType
            // 
            this.colUserType.Caption = "用户类型";
            this.colUserType.ColumnEdit = this.rleUserType;
            this.colUserType.FieldName = "UserType";
            this.colUserType.Name = "colUserType";
            this.colUserType.Visible = true;
            this.colUserType.VisibleIndex = 1;
            this.colUserType.Width = 120;
            // 
            // rleUserType
            // 
            this.rleUserType.AutoHeight = false;
            this.rleUserType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rleUserType.Name = "rleUserType";
            // 
            // colStageNum
            // 
            this.colStageNum.AppearanceCell.Options.UseTextOptions = true;
            this.colStageNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStageNum.Caption = "分期数";
            this.colStageNum.FieldName = "StageNum";
            this.colStageNum.Name = "colStageNum";
            this.colStageNum.Visible = true;
            this.colStageNum.VisibleIndex = 2;
            this.colStageNum.Width = 80;
            // 
            // colRate
            // 
            this.colRate.AppearanceCell.Options.UseTextOptions = true;
            this.colRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRate.Caption = "费率";
            this.colRate.DisplayFormat.FormatString = "p";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 3;
            this.colRate.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "描述";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 416;
            // 
            // colEffectiveDate
            // 
            this.colEffectiveDate.AppearanceCell.Options.UseTextOptions = true;
            this.colEffectiveDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEffectiveDate.Caption = "生效日期";
            this.colEffectiveDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colEffectiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEffectiveDate.FieldName = "EffectiveDate";
            this.colEffectiveDate.Name = "colEffectiveDate";
            this.colEffectiveDate.Visible = true;
            this.colEffectiveDate.VisibleIndex = 5;
            this.colEffectiveDate.Width = 80;
            // 
            // colInvalidDate
            // 
            this.colInvalidDate.AppearanceCell.Options.UseTextOptions = true;
            this.colInvalidDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInvalidDate.Caption = "失效日期";
            this.colInvalidDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colInvalidDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInvalidDate.FieldName = "InvalidDate";
            this.colInvalidDate.Name = "colInvalidDate";
            this.colInvalidDate.Visible = true;
            this.colInvalidDate.VisibleIndex = 6;
            this.colInvalidDate.Width = 80;
            // 
            // colCreateTime
            // 
            this.colCreateTime.AppearanceCell.Options.UseTextOptions = true;
            this.colCreateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreateTime.Caption = "创建日期";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 7;
            this.colCreateTime.Width = 80;
            // 
            // colValidity
            // 
            this.colValidity.Caption = "有效";
            this.colValidity.FieldName = "Validity";
            this.colValidity.Name = "colValidity";
            this.colValidity.Visible = true;
            this.colValidity.VisibleIndex = 8;
            this.colValidity.Width = 40;
            // 
            // PlanManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "PlanManage";
            this.Text = "PlanManage";
            this.Load += new System.EventHandler(this.PlanManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rleUserType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colStageNum;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvalidDate;
        private DevExpress.XtraGrid.Columns.GridColumn colValidity;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUserType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rleUserType;
    }
}