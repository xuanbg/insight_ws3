namespace Insight.WS.Client.Common
{
    partial class MainForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.meuMain = new DevExpress.XtraBars.Bar();
            this.bmuUser = new DevExpress.XtraBars.BarSubItem();
            this.mubChangPassWord = new DevExpress.XtraBars.BarButtonItem();
            this.mubLock = new DevExpress.XtraBars.BarButtonItem();
            this.mubLogout = new DevExpress.XtraBars.BarButtonItem();
            this.mubExit = new DevExpress.XtraBars.BarButtonItem();
            this.bmuSet = new DevExpress.XtraBars.BarSubItem();
            this.mubPrintSet = new DevExpress.XtraBars.BarButtonItem();
            this.mubSkin = new DevExpress.XtraBars.SkinBarSubItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bmuHelp = new DevExpress.XtraBars.BarSubItem();
            this.mubHelp = new DevExpress.XtraBars.BarButtonItem();
            this.mubAbout = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.btnTime = new DevExpress.XtraBars.BarButtonItem();
            this.btnDept = new DevExpress.XtraBars.BarButtonItem();
            this.btnUser = new DevExpress.XtraBars.BarButtonItem();
            this.bprMain = new DevExpress.XtraBars.BarEditItem();
            this.mpbMain = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.btnThing = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotice = new DevExpress.XtraBars.BarButtonItem();
            this.btnMessger = new DevExpress.XtraBars.BarButtonItem();
            this.btnServer = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.navMain = new DevExpress.XtraNavBar.NavBarControl();
            this.mdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.splitterControl = new DevExpress.XtraEditors.SplitterControl();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowItemAnimatedHighlighting = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.meuMain,
            this.barStatus});
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("StatusBar", new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5")),
            new DevExpress.XtraBars.BarManagerCategory("MainMenu", new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc"))});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bmuUser,
            this.bmuSet,
            this.barMdiChildrenListItem1,
            this.bmuHelp,
            this.mubChangPassWord,
            this.mubLock,
            this.mubLogout,
            this.mubExit,
            this.mubPrintSet,
            this.mubSkin,
            this.mubHelp,
            this.mubAbout,
            this.btnTime,
            this.btnDept,
            this.btnUser,
            this.bprMain,
            this.btnNotice,
            this.btnThing,
            this.btnMessger,
            this.btnServer});
            this.barManager.MainMenu = this.meuMain;
            this.barManager.MaxItemId = 52;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.mpbMain});
            this.barManager.StatusBar = this.barStatus;
            // 
            // meuMain
            // 
            this.meuMain.BarName = "Main menu";
            this.meuMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.meuMain.DockCol = 0;
            this.meuMain.DockRow = 0;
            this.meuMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.meuMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bmuUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.bmuSet),
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.bmuHelp)});
            this.meuMain.OptionsBar.UseWholeRow = true;
            this.meuMain.Text = "Main menu";
            // 
            // bmuUser
            // 
            this.bmuUser.Caption = "用户(&U)";
            this.bmuUser.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.bmuUser.Id = 0;
            this.bmuUser.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mubChangPassWord, "", false, false, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mubLock, "", true, false, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mubLogout, "", false, false, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mubExit, "", true, false, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.bmuUser.Name = "bmuUser";
            this.bmuUser.ShortcutKeyDisplayString = "U";
            // 
            // mubChangPassWord
            // 
            this.mubChangPassWord.Caption = "更换密码";
            this.mubChangPassWord.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubChangPassWord.Glyph = ((System.Drawing.Image)(resources.GetObject("mubChangPassWord.Glyph")));
            this.mubChangPassWord.Id = 8;
            this.mubChangPassWord.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mubChangPassWord.LargeGlyph")));
            this.mubChangPassWord.Name = "mubChangPassWord";
            this.mubChangPassWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ChangPassWord);
            // 
            // mubLock
            // 
            this.mubLock.Caption = "锁定";
            this.mubLock.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubLock.Glyph = ((System.Drawing.Image)(resources.GetObject("mubLock.Glyph")));
            this.mubLock.Id = 9;
            this.mubLock.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            this.mubLock.Name = "mubLock";
            this.mubLock.ShortcutKeyDisplayString = "Ctrl+O";
            this.mubLock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Lock);
            // 
            // mubLogout
            // 
            this.mubLogout.Caption = "注销";
            this.mubLogout.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubLogout.Glyph = ((System.Drawing.Image)(resources.GetObject("mubLogout.Glyph")));
            this.mubLogout.Id = 10;
            this.mubLogout.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
            this.mubLogout.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mubLogout.LargeGlyph")));
            this.mubLogout.Name = "mubLogout";
            this.mubLogout.ShortcutKeyDisplayString = "Ctrl+L";
            this.mubLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Logout);
            // 
            // mubExit
            // 
            this.mubExit.Caption = "退出";
            this.mubExit.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubExit.Glyph = ((System.Drawing.Image)(resources.GetObject("mubExit.Glyph")));
            this.mubExit.Id = 11;
            this.mubExit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4));
            this.mubExit.Name = "mubExit";
            this.mubExit.ShortcutKeyDisplayString = "Alt+F4";
            this.mubExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Exit);
            // 
            // bmuSet
            // 
            this.bmuSet.Caption = "设置(&S)";
            this.bmuSet.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.bmuSet.Id = 3;
            this.bmuSet.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mubPrintSet),
            new DevExpress.XtraBars.LinkPersistInfo(this.mubSkin, true)});
            this.bmuSet.Name = "bmuSet";
            this.bmuSet.ShortcutKeyDisplayString = "S";
            // 
            // mubPrintSet
            // 
            this.mubPrintSet.Caption = "设置打印机";
            this.mubPrintSet.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubPrintSet.Glyph = ((System.Drawing.Image)(resources.GetObject("mubPrintSet.Glyph")));
            this.mubPrintSet.Id = 14;
            this.mubPrintSet.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mubPrintSet.LargeGlyph")));
            this.mubPrintSet.Name = "mubPrintSet";
            this.mubPrintSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PrintSet);
            // 
            // mubSkin
            // 
            this.mubSkin.Caption = "更换皮肤";
            this.mubSkin.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubSkin.Glyph = ((System.Drawing.Image)(resources.GetObject("mubSkin.Glyph")));
            this.mubSkin.Id = 37;
            this.mubSkin.Name = "mubSkin";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "窗口(&W)";
            this.barMdiChildrenListItem1.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.barMdiChildrenListItem1.Id = 34;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.ShortcutKeyDisplayString = "W";
            // 
            // bmuHelp
            // 
            this.bmuHelp.Caption = "帮助(&H)";
            this.bmuHelp.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.bmuHelp.Id = 5;
            this.bmuHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mubHelp),
            new DevExpress.XtraBars.LinkPersistInfo(this.mubAbout, true)});
            this.bmuHelp.Name = "bmuHelp";
            this.bmuHelp.ShortcutKeyDisplayString = "H";
            // 
            // mubHelp
            // 
            this.mubHelp.Caption = "查看帮助";
            this.mubHelp.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("mubHelp.Glyph")));
            this.mubHelp.Id = 12;
            this.mubHelp.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H));
            this.mubHelp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mubHelp.LargeGlyph")));
            this.mubHelp.Name = "mubHelp";
            this.mubHelp.ShortcutKeyDisplayString = "Ctrl+H";
            this.mubHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Help);
            // 
            // mubAbout
            // 
            this.mubAbout.Caption = "关于";
            this.mubAbout.CategoryGuid = new System.Guid("ba703b74-a3ae-461f-94c8-943ed9da4cdc");
            this.mubAbout.Glyph = ((System.Drawing.Image)(resources.GetObject("mubAbout.Glyph")));
            this.mubAbout.Id = 13;
            this.mubAbout.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mubAbout.LargeGlyph")));
            this.mubAbout.Name = "mubAbout";
            this.mubAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.About);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTime, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDept, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUser, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bprMain, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThing, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNotice),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMessger),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnServer, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // btnTime
            // 
            this.btnTime.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnTime.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTime.Glyph")));
            this.btnTime.Id = 42;
            this.btnTime.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTime.LargeGlyph")));
            this.btnTime.Name = "btnTime";
            this.btnTime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTime_ItemClick);
            // 
            // btnDept
            // 
            this.btnDept.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnDept.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDept.Glyph")));
            this.btnDept.Id = 43;
            this.btnDept.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDept.LargeGlyph")));
            this.btnDept.Name = "btnDept";
            // 
            // btnUser
            // 
            this.btnUser.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUser.Glyph")));
            this.btnUser.Id = 44;
            this.btnUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUser.LargeGlyph")));
            this.btnUser.Name = "btnUser";
            // 
            // bprMain
            // 
            this.bprMain.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bprMain.Caption = "进度条";
            this.bprMain.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.bprMain.Edit = this.mpbMain;
            this.bprMain.Id = 38;
            this.bprMain.Name = "bprMain";
            this.bprMain.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bprMain.Width = 160;
            // 
            // mpbMain
            // 
            this.mpbMain.Name = "mpbMain";
            // 
            // btnThing
            // 
            this.btnThing.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnThing.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnThing.Enabled = false;
            this.btnThing.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThing.Glyph")));
            this.btnThing.Id = 45;
            this.btnThing.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnThing.LargeGlyph")));
            this.btnThing.Name = "btnThing";
            // 
            // btnNotice
            // 
            this.btnNotice.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnNotice.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnNotice.Enabled = false;
            this.btnNotice.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNotice.Glyph")));
            this.btnNotice.Id = 39;
            this.btnNotice.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNotice.LargeGlyph")));
            this.btnNotice.Name = "btnNotice";
            // 
            // btnMessger
            // 
            this.btnMessger.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnMessger.Enabled = false;
            this.btnMessger.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMessger.Glyph")));
            this.btnMessger.Id = 51;
            this.btnMessger.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMessger.LargeGlyph")));
            this.btnMessger.Name = "btnMessger";
            // 
            // btnServer
            // 
            this.btnServer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnServer.CategoryGuid = new System.Guid("bb5179f7-aee9-4a1f-8fc5-39d222e973a5");
            this.btnServer.Glyph = ((System.Drawing.Image)(resources.GetObject("btnServer.Glyph")));
            this.btnServer.Id = 40;
            this.btnServer.Name = "btnServer";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1264, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 695);
            this.barDockControlBottom.Size = new System.Drawing.Size(1264, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 671);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1264, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 671);
            // 
            // navMain
            // 
            this.navMain.ActiveGroup = null;
            this.navMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.navMain.Location = new System.Drawing.Point(0, 24);
            this.navMain.Name = "navMain";
            this.navMain.OptionsNavPane.ExpandedWidth = 165;
            this.navMain.Size = new System.Drawing.Size(165, 671);
            this.navMain.StoreDefaultPaintStyleName = true;
            this.navMain.TabIndex = 1;
            // 
            // mdiManager
            // 
            this.mdiManager.MdiParent = this;
            // 
            // splitterControl
            // 
            this.splitterControl.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.splitterControl.Appearance.Options.UseBackColor = true;
            this.splitterControl.Location = new System.Drawing.Point(165, 24);
            this.splitterControl.MinExtra = 880;
            this.splitterControl.MinSize = 120;
            this.splitterControl.Name = "splitterControl";
            this.splitterControl.Size = new System.Drawing.Size(5, 671);
            this.splitterControl.TabIndex = 0;
            this.splitterControl.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1264, 722);
            this.Controls.Add(this.splitterControl);
            this.Controls.Add(this.navMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insight Workstation 3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar meuMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraNavBar.NavBarControl navMain;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiManager;
        private DevExpress.XtraBars.BarSubItem bmuUser;
        private DevExpress.XtraBars.BarSubItem bmuSet;
        private DevExpress.XtraBars.BarSubItem bmuHelp;
        private DevExpress.XtraBars.BarButtonItem mubChangPassWord;
        private DevExpress.XtraBars.BarButtonItem mubLock;
        private DevExpress.XtraBars.BarButtonItem mubLogout;
        private DevExpress.XtraBars.BarButtonItem mubExit;
        private DevExpress.XtraBars.BarButtonItem mubPrintSet;
        private DevExpress.XtraBars.BarButtonItem mubHelp;
        private DevExpress.XtraBars.BarButtonItem mubAbout;
        private DevExpress.XtraEditors.SplitterControl splitterControl;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.SkinBarSubItem mubSkin;
        private DevExpress.XtraBars.BarButtonItem btnServer;
        protected DevExpress.XtraBars.BarButtonItem btnNotice;
        private DevExpress.XtraBars.BarButtonItem btnTime;
        private DevExpress.XtraBars.BarButtonItem btnDept;
        private DevExpress.XtraBars.BarButtonItem btnUser;
        private DevExpress.XtraBars.BarButtonItem btnThing;
        private DevExpress.XtraBars.BarButtonItem btnMessger;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.BarEditItem bprMain;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar mpbMain;
    }
}

