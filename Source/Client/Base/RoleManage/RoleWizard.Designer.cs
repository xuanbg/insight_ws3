using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraWizard;
using WizardPage = DevExpress.XtraWizard.WizardPage;

namespace Insight.WS.Client.Platform.Base
{
    partial class RoleWizard
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
            this.components = new Container();
            var resources = new ComponentResourceManager(typeof(RoleWizard));
            this.wizRole = new WizardControl();
            this.wizPage1 = new WizardPage();
            this.labRemark = new LabelControl();
            this.labName = new LabelControl();
            this.memDescription = new MemoEdit();
            this.txtName = new TextEdit();
            this.wizPage2 = new WizardPage();
            this.splModule = new SplitContainerControl();
            this.grpModule = new GroupControl();
            this.treModule = new TreeList();
            this.imgPermission = new ImageCollection(this.components);
            this.grpAction = new GroupControl();
            this.treAction = new TreeList();
            this.wizPage3 = new WizardPage();
            this.splData = new SplitContainerControl();
            this.grpDataModule = new GroupControl();
            this.treDataModule = new TreeList();
            this.grpDataPerm = new GroupControl();
            this.treDataPerm = new TreeList();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.wizRole)).BeginInit();
            this.wizRole.SuspendLayout();
            this.wizPage1.SuspendLayout();
            ((ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.wizPage2.SuspendLayout();
            ((ISupportInitialize)(this.splModule)).BeginInit();
            this.splModule.SuspendLayout();
            ((ISupportInitialize)(this.grpModule)).BeginInit();
            this.grpModule.SuspendLayout();
            ((ISupportInitialize)(this.treModule)).BeginInit();
            ((ISupportInitialize)(this.imgPermission)).BeginInit();
            ((ISupportInitialize)(this.grpAction)).BeginInit();
            this.grpAction.SuspendLayout();
            ((ISupportInitialize)(this.treAction)).BeginInit();
            this.wizPage3.SuspendLayout();
            ((ISupportInitialize)(this.splData)).BeginInit();
            this.splData.SuspendLayout();
            ((ISupportInitialize)(this.grpDataModule)).BeginInit();
            this.grpDataModule.SuspendLayout();
            ((ISupportInitialize)(this.treDataModule)).BeginInit();
            ((ISupportInitialize)(this.grpDataPerm)).BeginInit();
            this.grpDataPerm.SuspendLayout();
            ((ISupportInitialize)(this.treDataPerm)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
            // 
            // wizRole
            // 
            this.wizRole.Appearance.PageTitle.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.wizRole.Appearance.PageTitle.Options.UseFont = true;
            this.wizRole.CancelText = "取 消";
            this.wizRole.Controls.Add(this.wizPage1);
            this.wizRole.Controls.Add(this.wizPage2);
            this.wizRole.Controls.Add(this.wizPage3);
            this.wizRole.Dock = DockStyle.Fill;
            this.wizRole.FinishText = "完 成";
            this.wizRole.HeaderImage = ((Image)(resources.GetObject("wizRole.HeaderImage")));
            this.wizRole.HelpText = "帮 助";
            this.wizRole.Location = new Point(0, 0);
            this.wizRole.Name = "wizRole";
            this.wizRole.NextText = "下一步";
            this.wizRole.Pages.AddRange(new BaseWizardPage[] {
            this.wizPage1,
            this.wizPage2,
            this.wizPage3});
            this.wizRole.PreviousText = "上一步";
            this.wizRole.Size = new Size(624, 442);
            this.wizRole.FinishClick += new CancelEventHandler(this.wizRole_FinishClick);
            // 
            // wizPage1
            // 
            this.wizPage1.Controls.Add(this.labRemark);
            this.wizPage1.Controls.Add(this.labName);
            this.wizPage1.Controls.Add(this.memDescription);
            this.wizPage1.Controls.Add(this.txtName);
            this.wizPage1.DescriptionText = "欢迎使用角色设置向导。在输入必要的基础信息后，请点击下一步设置该角色的功能权限。";
            this.wizPage1.Name = "wizPage1";
            this.wizPage1.Size = new Size(592, 297);
            this.wizPage1.Text = "基本信息";
            // 
            // labRemark
            // 
            this.labRemark.Appearance.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.labRemark.Appearance.ForeColor = Color.Black;
            this.labRemark.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labRemark.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labRemark.AutoSizeMode = LabelAutoSizeMode.None;
            this.labRemark.Location = new Point(30, 80);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new Size(60, 21);
            this.labRemark.TabIndex = 10;
            this.labRemark.Text = "备注：";
            // 
            // labName
            // 
            this.labName.Appearance.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.labName.Appearance.ForeColor = Color.Black;
            this.labName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labName.Location = new Point(30, 40);
            this.labName.Name = "labName";
            this.labName.Size = new Size(60, 21);
            this.labName.TabIndex = 11;
            this.labName.Text = "角色名称：";
            // 
            // memDescription
            // 
            this.memDescription.EnterMoveNextControl = true;
            this.memDescription.Location = new Point(90, 80);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入备注信息…";
            this.memDescription.Size = new Size(450, 180);
            this.memDescription.TabIndex = 2;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // txtName
            // 
            this.txtName.Location = new Point(90, 40);
            this.txtName.Name = "txtName";
            this.txtName.Properties.NullText = "请输入角色名称…";
            this.txtName.Size = new Size(450, 20);
            this.txtName.TabIndex = 1;
            this.txtName.EditValueChanged += new EventHandler(this.txtName_EditValueChanged);
            this.txtName.Leave += new EventHandler(this.txtName_Leave);
            // 
            // wizPage2
            // 
            this.wizPage2.Controls.Add(this.splModule);
            this.wizPage2.DescriptionText = "请先勾选需要授权的功能所属模块，然后设置功能权限。点击下一步进行数据权限设置。";
            this.wizPage2.Name = "wizPage2";
            this.wizPage2.Size = new Size(592, 297);
            this.wizPage2.Text = "设置功能权限";
            // 
            // splModule
            // 
            this.splModule.Dock = DockStyle.Fill;
            this.splModule.Location = new Point(0, 0);
            this.splModule.Name = "splModule";
            this.splModule.Panel1.Controls.Add(this.grpModule);
            this.splModule.Panel1.MinSize = 275;
            this.splModule.Panel2.Controls.Add(this.grpAction);
            this.splModule.Panel2.MinSize = 312;
            this.splModule.Size = new Size(592, 297);
            this.splModule.SplitterPosition = 275;
            this.splModule.TabIndex = 0;
            // 
            // grpModule
            // 
            this.grpModule.Controls.Add(this.treModule);
            this.grpModule.Dock = DockStyle.Fill;
            this.grpModule.Location = new Point(0, 0);
            this.grpModule.Name = "grpModule";
            this.grpModule.Size = new Size(275, 297);
            this.grpModule.TabIndex = 0;
            this.grpModule.Text = "业务模块";
            // 
            // treModule
            // 
            this.treModule.Dock = DockStyle.Fill;
            this.treModule.Location = new Point(2, 22);
            this.treModule.Name = "treModule";
            this.treModule.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treModule.OptionsSelection.MultiSelect = true;
            this.treModule.OptionsView.ShowCheckBoxes = true;
            this.treModule.SelectImageList = this.imgPermission;
            this.treModule.Size = new Size(271, 273);
            this.treModule.TabIndex = 0;
            this.treModule.AfterCheckNode += new NodeEventHandler(this.treModule_AfterCheckNode);
            // 
            // imgPermission
            // 
            this.imgPermission.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgPermission.ImageStream")));
            this.imgPermission.Images.SetKeyName(0, "Navigation.png");
            this.imgPermission.Images.SetKeyName(1, "Module.png");
            this.imgPermission.Images.SetKeyName(2, "Action.png");
            this.imgPermission.InsertGalleryImage("database_16x16.png", "images/data/database_16x16.png", ImageResourceCache.Default.GetImage("images/data/database_16x16.png"), 3);
            this.imgPermission.Images.SetKeyName(3, "database_16x16.png");
            this.imgPermission.Images.SetKeyName(4, "Item.png");
            this.imgPermission.InsertGalleryImage("customer_16x16.png", "images/people/customer_16x16.png", ImageResourceCache.Default.GetImage("images/people/customer_16x16.png"), 5);
            this.imgPermission.Images.SetKeyName(5, "customer_16x16.png");
            this.imgPermission.Images.SetKeyName(6, "NodeDept.png");
            this.imgPermission.InsertGalleryImage("home_16x16.png", "images/navigation/home_16x16.png", ImageResourceCache.Default.GetImage("images/navigation/home_16x16.png"), 7);
            this.imgPermission.Images.SetKeyName(7, "home_16x16.png");
            this.imgPermission.Images.SetKeyName(8, "NodeOrg.png");
            this.imgPermission.InsertGalleryImage("documentmap_16x16.png", "images/navigation/documentmap_16x16.png", ImageResourceCache.Default.GetImage("images/navigation/documentmap_16x16.png"), 9);
            this.imgPermission.Images.SetKeyName(9, "documentmap_16x16.png");
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.treAction);
            this.grpAction.Dock = DockStyle.Fill;
            this.grpAction.Location = new Point(0, 0);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new Size(312, 297);
            this.grpAction.TabIndex = 0;
            this.grpAction.Text = "功能操作";
            // 
            // treAction
            // 
            this.treAction.Dock = DockStyle.Fill;
            this.treAction.Location = new Point(2, 22);
            this.treAction.Name = "treAction";
            this.treAction.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.treAction.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treAction.OptionsSelection.MultiSelect = true;
            this.treAction.OptionsView.ShowCheckBoxes = true;
            this.treAction.SelectImageList = this.imgPermission;
            this.treAction.Size = new Size(308, 273);
            this.treAction.TabIndex = 0;
            this.treAction.AfterCheckNode += new NodeEventHandler(this.treAction_AfterCheckNode);
            // 
            // wizPage3
            // 
            this.wizPage3.Controls.Add(this.splData);
            this.wizPage3.DescriptionText = "请为该角色设置相应的数据权限，如权限重叠，以高权限（读写）为优先。";
            this.wizPage3.Name = "wizPage3";
            this.wizPage3.Size = new Size(592, 297);
            this.wizPage3.Text = "设置数据权限（相对模式）";
            // 
            // splData
            // 
            this.splData.Dock = DockStyle.Fill;
            this.splData.Location = new Point(0, 0);
            this.splData.Name = "splData";
            this.splData.Panel1.Controls.Add(this.grpDataModule);
            this.splData.Panel1.MinSize = 275;
            this.splData.Panel2.Controls.Add(this.grpDataPerm);
            this.splData.Panel2.MinSize = 312;
            this.splData.Size = new Size(592, 297);
            this.splData.SplitterPosition = 275;
            this.splData.TabIndex = 0;
            // 
            // grpDataModule
            // 
            this.grpDataModule.Controls.Add(this.treDataModule);
            this.grpDataModule.Dock = DockStyle.Fill;
            this.grpDataModule.Location = new Point(0, 0);
            this.grpDataModule.Name = "grpDataModule";
            this.grpDataModule.Size = new Size(275, 297);
            this.grpDataModule.TabIndex = 0;
            this.grpDataModule.Text = "业务模块";
            // 
            // treDataModule
            // 
            this.treDataModule.Dock = DockStyle.Fill;
            this.treDataModule.Location = new Point(2, 22);
            this.treDataModule.Name = "treDataModule";
            this.treDataModule.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treDataModule.OptionsSelection.MultiSelect = true;
            this.treDataModule.OptionsView.ShowCheckBoxes = true;
            this.treDataModule.SelectImageList = this.imgPermission;
            this.treDataModule.Size = new Size(271, 273);
            this.treDataModule.TabIndex = 1;
            this.treDataModule.AfterCheckNode += new NodeEventHandler(this.treDataModule_AfterCheckNode);
            // 
            // grpDataPerm
            // 
            this.grpDataPerm.Controls.Add(this.treDataPerm);
            this.grpDataPerm.Dock = DockStyle.Fill;
            this.grpDataPerm.Location = new Point(0, 0);
            this.grpDataPerm.Name = "grpDataPerm";
            this.grpDataPerm.Size = new Size(312, 297);
            this.grpDataPerm.TabIndex = 1;
            this.grpDataPerm.Text = "数据权限";
            // 
            // treDataPerm
            // 
            this.treDataPerm.Dock = DockStyle.Fill;
            this.treDataPerm.Location = new Point(2, 22);
            this.treDataPerm.Name = "treDataPerm";
            this.treDataPerm.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.treDataPerm.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treDataPerm.OptionsSelection.MultiSelect = true;
            this.treDataPerm.OptionsView.ShowCheckBoxes = true;
            this.treDataPerm.SelectImageList = this.imgPermission;
            this.treDataPerm.Size = new Size(308, 273);
            this.treDataPerm.TabIndex = 1;
            this.treDataPerm.AfterCheckNode += new NodeEventHandler(this.treDataPerm_AfterCheckNode);
            // 
            // RoleWizard
            // 
            this.ClientSize = new Size(624, 442);
            this.Controls.Add(this.wizRole);
            this.Name = "RoleWizard";
            this.Load += new EventHandler(this.RoleWizard_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.wizRole)).EndInit();
            this.wizRole.ResumeLayout(false);
            this.wizPage1.ResumeLayout(false);
            ((ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.wizPage2.ResumeLayout(false);
            ((ISupportInitialize)(this.splModule)).EndInit();
            this.splModule.ResumeLayout(false);
            ((ISupportInitialize)(this.grpModule)).EndInit();
            this.grpModule.ResumeLayout(false);
            ((ISupportInitialize)(this.treModule)).EndInit();
            ((ISupportInitialize)(this.imgPermission)).EndInit();
            ((ISupportInitialize)(this.grpAction)).EndInit();
            this.grpAction.ResumeLayout(false);
            ((ISupportInitialize)(this.treAction)).EndInit();
            this.wizPage3.ResumeLayout(false);
            ((ISupportInitialize)(this.splData)).EndInit();
            this.splData.ResumeLayout(false);
            ((ISupportInitialize)(this.grpDataModule)).EndInit();
            this.grpDataModule.ResumeLayout(false);
            ((ISupportInitialize)(this.treDataModule)).EndInit();
            ((ISupportInitialize)(this.grpDataPerm)).EndInit();
            this.grpDataPerm.ResumeLayout(false);
            ((ISupportInitialize)(this.treDataPerm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardControl wizRole;
        private WizardPage wizPage1;
        private WizardPage wizPage2;
        private WizardPage wizPage3;
        private LabelControl labRemark;
        private LabelControl labName;
        private MemoEdit memDescription;
        private TextEdit txtName;
        private SplitContainerControl splModule;
        private TreeList treModule;
        private TreeList treAction;
        private SplitContainerControl splData;
        private TreeList treDataModule;
        private ImageCollection imgPermission;
        private GroupControl grpModule;
        private GroupControl grpAction;
        private GroupControl grpDataModule;
        private GroupControl grpDataPerm;
        private TreeList treDataPerm;
    }
}
