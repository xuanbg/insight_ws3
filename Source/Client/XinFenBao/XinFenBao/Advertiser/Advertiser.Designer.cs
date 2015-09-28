namespace Insight.WS.Client.XinFenBao
{
    partial class Advertiser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Advertiser));
            this.grdAdvertiser = new DevExpress.XtraGrid.GridControl();
            this.gdvAdvertiser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImageURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTargetURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvertiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAdvertiser)).BeginInit();
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
            this.xtraScrollable.Controls.Add(this.grdAdvertiser);
            // 
            // grdAdvertiser
            // 
            this.grdAdvertiser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAdvertiser.Location = new System.Drawing.Point(5, 5);
            this.grdAdvertiser.MainView = this.gdvAdvertiser;
            this.grdAdvertiser.Name = "grdAdvertiser";
            this.grdAdvertiser.ShowOnlyPredefinedDetails = true;
            this.grdAdvertiser.Size = new System.Drawing.Size(1070, 590);
            this.grdAdvertiser.TabIndex = 0;
            this.grdAdvertiser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvAdvertiser});
            // 
            // gdvAdvertiser
            // 
            this.gdvAdvertiser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSort,
            this.colName,
            this.colImageURL,
            this.colTargetURL,
            this.colProductCode,
            this.colCreateTime});
            this.gdvAdvertiser.GridControl = this.grdAdvertiser;
            this.gdvAdvertiser.Name = "gdvAdvertiser";
            this.gdvAdvertiser.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvAdvertiser_FocusedRowObjectChanged);
            this.gdvAdvertiser.DoubleClick += new System.EventHandler(this.gdvAdvertiser_DoubleClick);
            // 
            // colSort
            // 
            this.colSort.AppearanceCell.Options.UseTextOptions = true;
            this.colSort.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSort.Caption = "排序";
            this.colSort.FieldName = "Sort";
            this.colSort.Name = "colSort";
            this.colSort.Visible = true;
            this.colSort.VisibleIndex = 0;
            this.colSort.Width = 60;
            // 
            // colName
            // 
            this.colName.Caption = "轮播图名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 160;
            // 
            // colImageURL
            // 
            this.colImageURL.Caption = "轮播图";
            this.colImageURL.FieldName = "ImageURL";
            this.colImageURL.Name = "colImageURL";
            this.colImageURL.Visible = true;
            this.colImageURL.VisibleIndex = 2;
            this.colImageURL.Width = 200;
            // 
            // colTargetURL
            // 
            this.colTargetURL.Caption = "跳转地址";
            this.colTargetURL.FieldName = "TargetURL";
            this.colTargetURL.Name = "colTargetURL";
            this.colTargetURL.Visible = true;
            this.colTargetURL.VisibleIndex = 3;
            this.colTargetURL.Width = 320;
            // 
            // colProductCode
            // 
            this.colProductCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProductCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductCode.Caption = "商品编号";
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 4;
            this.colProductCode.Width = 196;
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
            this.colCreateTime.VisibleIndex = 5;
            this.colCreateTime.Width = 80;
            // 
            // Advertiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "Advertiser";
            this.Text = "Advertiser";
            this.Load += new System.EventHandler(this.Advertiser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvertiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAdvertiser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAdvertiser;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvAdvertiser;
        private DevExpress.XtraGrid.Columns.GridColumn colSort;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colImageURL;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetURL;
    }
}