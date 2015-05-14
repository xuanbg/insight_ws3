using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.IO;
using FastReport;
using FastReport.Export;
using FastReport.Export.Html;
using FastReport.Export.RichText;
using FastReport.Export.OoXML;
using FastReport.Utils;
using System.Threading;
using System.Drawing;
using System.Drawing.Design;
using System.Collections;
using System.Data;
using FastReport.Data;
using System.Web.UI.Design;

namespace FastReport.Web
{
    /// <summary>
    /// Represents the Web Report.
    /// </summary>        
    [Designer("FastReport.VSDesign.WebReportComponentDesigner, FastReport.VSDesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c, processorArchitecture=MSIL")]
    [ToolboxBitmap(typeof(WebReport), "Resources.Report.bmp")]

    public
    partial class WebReport : WebControl, INamingContainer
    {
        #region Private fields

        private string fReportGuid;
        
        private WebReportProperties fProperties;
        private Report fReport;
        private HTMLExport fHTMLExport;

        private bool WebFarmMode = false;
        
        private string FileStoragePath;
        private int FileStorageTimeout;
        private int FileStorageCleanup;
      
        private ImageButton btnFirst;
        private ImageButton btnPrev;
        private ImageButton btnNext;
        private ImageButton btnLast;
        private HtmlTable tblNavigator;
        private HtmlGenericControl div;
        private HtmlInputControl hiddenID;
        private ImageButton btnExport;
        private ImageButton btnPrint;
        private DropDownList cbbExportList;
        private DropDownList cbbZoom;
        private ImageButton btnRefresh;
        private Label lblPages;
        private TextBox tbPage;

        #endregion

        #region Public properties

        #region Layout
        /// <summary>
        /// Get or sets auto width of report
        /// </summary>
        [DefaultValue(false)]
        [Category("Layout")]
        [Browsable(true)]
        public bool AutoWidth
        {
            get { return Properties.AutoWidth; }
            set { Properties.AutoWidth = value; }
        }

        /// <summary>
        /// Get or sets auto height of report
        /// </summary>
        [DefaultValue(false)]
        [Category("Layout")]
        [Browsable(true)]
        public bool AutoHeight
        {
            get { return Properties.AutoHeight; }
            set { Properties.AutoHeight = value; }
        }

        /// <summary>
        /// Enable or disable layers mode visualisation
        /// </summary>
        [DefaultValue(false)]
        [Category("Layout")]
        [Browsable(true)]
        public bool Layers
        {
            get { return Properties.Layers; }
            set { Properties.Layers = value; }
        }

        /// <summary>
        /// Gets or sets Padding of Report section
        /// </summary>
        [Category("Layout")]
        [Browsable(true)]
        public System.Windows.Forms.Padding Padding
        {
            get { return Properties.Padding; }
            set { Properties.Padding = value; }
        }
        #endregion

        #region Network
        /// <summary>
        /// Delay in cache in minutes
        /// </summary>
        [Category("Network")]
        [DefaultValue(15)]
        [Browsable(true)]
        public int CacheDelay
        {
            get { return Properties.CacheDelay; }
            set { Properties.CacheDelay = value; }
        }

        /// <summary>
        /// Priority of items in cache
        /// </summary>
        [Category("Network")]
        [DefaultValue(CacheItemPriority.Normal)]
        [Browsable(true)]
        public CacheItemPriority CachePriority
        {
            get { return Properties.CachePriority; }
            set { Properties.CachePriority = value; }
        }

        #endregion

        #region Report
        /// <summary>
        /// Report Resource String
        /// </summary>
        [DefaultValue("")]
        [Category("Report")]
        [Browsable(true)]
        public string ReportResourceString
        {
            get { return Properties.ReportResourceString; }
            set { Properties.ReportResourceString = value; }
        }

        /// <summary>
        /// Gets or sets report data source(s).
        /// </summary>
        /// <remarks>
        /// To pass several datasources, use ';' delimiter, for example: 
        /// "sqlDataSource1;sqlDataSource2"
        /// </remarks>
        [DefaultValue("")]
        [Category("Report")]
        [Browsable(true)]
        public string ReportDataSources
        {
            get { return Properties.ReportDataSources; }
            set { Properties.ReportDataSources = value; }
        }
        /// <summary>
        /// Switch the pictures visibility in report
        /// </summary>
        [DefaultValue(true)]
        [Category("Report")]
        [Browsable(true)]
        public bool Pictures
        {
            get { return Properties.Pictures; }
            set { Properties.Pictures = value; }
        }

        /// <summary>
        /// Gets or sets the name of report file.
        /// </summary>
        [DefaultValue("")]
        [Category("Report")]
        [Browsable(true)]
        [Editor("FastReport.VSDesign.ReportFileEditor, FastReport.VSDesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c, processorArchitecture=MSIL", typeof(UITypeEditor))]
        public string ReportFile
        {
            get { return Properties.ReportFile; }
            set { Properties.ReportFile = value; }
        }

        /// <summary>
        /// Gets or sets the name of localization file.
        /// </summary>
        [DefaultValue("")]
        [Category("Report")]
        [Browsable(true)]
        [Editor("FastReport.VSDesign.LocalizationFileEditor, FastReport.VSDesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c, processorArchitecture=MSIL", typeof(UITypeEditor))]
        public string LocalizationFile
        {
            get { return Properties.LocalizationFile; }
            set { Properties.LocalizationFile = value; }
        }

        /// <summary>
        /// Set the zoom factor of previewed page between 0..1
        /// </summary>
        [DefaultValue(1f)]
        [Category("Report")]
        [Browsable(true)]
        public float Zoom
        {
            get { return Properties.Zoom; }
            set { Properties.Zoom = value; }
        }
        #endregion

        #region Toolbar
        /// <summary>
        ///  Switch toolbar visibility
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowToolbar
        {
            get { return Properties.ShowToolbar; }
            set { Properties.ShowToolbar = value; }
        }

        /// <summary>
        /// Sets the path to custom buttons on site. 
        /// </summary>
        /// <remarks>
        /// Pictures should be named:
        /// Export.gif, First.gif, First_disabled.gif, Last.gif, Last_disabled.gif, Next.gif, 
        /// Next_disabled.gif, Prev.gif, Prev_disabled.gif, Print.gif, Refresh.gif, Zoom.gif
        /// </remarks>
        [DefaultValue("")]
        [Category("Toolbar")]
        [Browsable(true)]
        //[UrlProperty]
        //[Editor("FastReport.VSDesign.ReportFileEditor, FastReport.VSDesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c, processorArchitecture=MSIL", typeof(UITypeEditor))]
        public string ButtonsPath
        {
            get { return Properties.ButtonsPath; }
            set { Properties.ButtonsPath = value; }
        }

        /// <summary>
        ///  Switch visibility of Exports in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowExports
        {
            get { return Properties.ShowExports; }
            set { Properties.ShowExports = value; }
        }

        /// <summary>
        ///  Switch visibility of Print button in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowPrint
        {
            get { return Properties.ShowPrint; }
            set { Properties.ShowPrint = value; }
        }

        /// <summary>
        ///  Switch visibility of First Button in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowFirstButton
        {
            get { return Properties.ShowFirstButton; }
            set { Properties.ShowFirstButton = value; }
        }

        /// <summary>
        ///  Switch visibility of Previous Button in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowPrevButton
        {
            get { return Properties.ShowPrevButton; }
            set { Properties.ShowPrevButton = value; }
        }

        /// <summary>
        ///  Switch visibility of Next Button in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowNextButton
        {
            get { return Properties.ShowNextButton; }
            set { Properties.ShowNextButton = value; }
        }

        /// <summary>
        ///  Switch visibility of Last Button in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowLastButton
        {
            get { return Properties.ShowLastButton; }
            set { Properties.ShowLastButton = value; }
        }

        /// <summary>
        /// Switch visibility of Zoom in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowZoomButton
        {
            get { return Properties.ShowZoomButton; }
            set { Properties.ShowZoomButton = value; }
        }

        /// <summary>
        /// Switch visibility of Refresh in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowRefreshButton
        {
            get { return Properties.ShowRefreshButton; }
            set { Properties.ShowRefreshButton = value; }
        }

        /// <summary>
        /// Switch visibility of Page Number in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowPageNumber
        {
            get { return Properties.ShowPageNumber; }
            set { Properties.ShowPageNumber = value; }
        }

        /// <summary>
        /// Set the Toolbar color.
        /// </summary>
        [DefaultValue(0xECE9D8)]
        [Category("Toolbar")]
        [Browsable(true)]
        public System.Drawing.Color ToolbarColor
        {
            get { return Properties.ToolbarColor; }
            set { Properties.ToolbarColor = value; }
        }
        #endregion

        #region Print

        /// <summary>
        /// Enable or disable print in PDF
        /// </summary>
        [DefaultValue(true)]
        [Category("Print")]
        [Browsable(true)]
        public bool PrintInPdf
        {
            get { return Properties.PrintInPdf; }
            set { Properties.PrintInPdf = value; }
        }

        /// <summary>
        /// Sets the width of print window
        /// </summary>
        [DefaultValue("700px")]
        [Category("Print")]
        [Browsable(true)]
        public string PrintWindowWidth
        {
            get { return Properties.PrintWindowWidth; }
            set { Properties.PrintWindowWidth = value; }
        }

        /// <summary>
        /// Sets the height of print window
        /// </summary>
        [DefaultValue("500px")]
        [Category("Print")]
        [Browsable(true)]
        public string PrintWindowHeight
        {
            get { return Properties.PrintWindowHeight; }
            set { Properties.PrintWindowWidth = value; }
        }

        #endregion

        #region Hidden Properties
        
        [Browsable(false)]
        internal string StoragePath
        {
            get { return FileStoragePath; }
            set { FileStoragePath = value; }
        }

        [Browsable(false)]
        internal bool WebFarm
        {
            get { return WebFarmMode; }
            set { WebFarmMode = value; }
        } 

        /// <summary>
        /// Direct access to Properties of report object
        /// </summary>
        [Browsable(false)]
        public WebReportProperties Properties
        {
            get
            {
                if (fProperties == null)
                    fProperties = new WebReportProperties();
                return fProperties;
            }
            set
            {
                fProperties = value;
            }
        }

        /// <summary>
        /// Direct access to Report object
        /// </summary>
        [Browsable(false)]
        public Report Report
        {
            get
            {
                if (fReport == null)
                    fReport = new Report();
                return fReport;
            }
            set
            {
                fReport = value;
            }
        }

        /// <summary>
        /// Direct access to HTML export engine
        /// </summary>
        [Browsable(false)]
        public HTMLExport HTMLExport
        {
            get { return fHTMLExport; }
            set { fHTMLExport = value; }
        }

        /// <summary>
        /// Gets total pages of current report
        /// </summary>
        [Browsable(false)]
        public int TotalPages
        {
            get
            {
                return Report.PreparedPages.Count;
            }
        }

        /// <summary>
        /// Return true if report done
        /// </summary>
        [Browsable(false)]
        public bool ReportDone
        {
            get { return Properties.ReportDone; }
            set { Properties.ReportDone = value; }
        }

        /// <summary>
        /// Gets or sets number of current page
        /// </summary>
        [Browsable(false)]
        public int CurrentPage
        {
            get { return Properties.CurrentPage; }
            set 
            {
                if (Properties.CurrentPage != value)
                    DoHtmlPages();
                Properties.CurrentPage = value; 
            }
        }

        /// <summary>
        /// Return true if HTML export done
        /// </summary>
        [Browsable(false)]
        public bool HTMLDone
        {
            get { return Properties.HTMLDone; }
            set { Properties.HTMLDone = value; }
        }

        /// <summary>
        /// Gets or sets guid of report
        /// </summary>
        [Browsable(false)]
        public string ReportGuid
        {
            get { return fReportGuid; }
            set { fReportGuid = value; }
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Occurs when report execution is started.
        /// </summary>
        [Browsable(true)]
        public event EventHandler StartReport;
        #endregion

        private object GetStorage(string prefix, string suffix)
        {
            string uid = String.Concat(prefix, suffix);
            object obj;

            if (WebFarmMode)
            {
                obj = WebReportCache.GetFileStorage(prefix, suffix, FileStoragePath);
            }
            else
            {
                obj = WebReportCache.CacheGet(uid);
            }            
            return obj;
        }

        private void PutStorage(string prefix, string suffix, object value)
        {
            if (value != null)
            {
                if (WebFarmMode)
                {
                    WebReportCache.PutFileStorage(prefix, suffix, value, FileStoragePath);
                }
                else
                {
                    //WebReportCache.CacheAdd(String.Concat(prefix, suffix), value, null,
                    //    CacheDelay, CachePriority);
                    WebReportCache.CacheAdd(String.Concat(prefix, suffix), value, //null,
                        new CacheItemRemovedCallback(this.RemovedCallback),
                        CacheDelay, CachePriority);
                }
            }
        }

        private string GetPopUpScriptString(string PrintWindowWidth, string PrintWindowHeight)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type=text/javascript>");
            sb.AppendLine("function frxOpenPrint(url) {");
            sb.Append("window.open(url, '_blank','resizable,scrollbars,width=").
                Append(PrintWindowWidth).Append(",height=").Append(PrintWindowHeight).AppendLine("'); };");
            sb.AppendLine("</script>");
            return sb.ToString();
        }

        /// <summary>
        /// Runs on report start
        /// </summary>
        /// <param name="e"></param>
        public void OnStartReport(EventArgs e)
        {
            if (StartReport != null)
                StartReport(this, e);
        }

        #region Navigation

        /// <summary>
        /// Force go to next report page
        /// </summary>
        public void NextPage()
        {
            if (CurrentPage < TotalPages - 1)
                CurrentPage++;
        }

        /// <summary>
        /// Force go to previous report page
        /// </summary>
        public void PrevPage()
        {
            if (CurrentPage > 0)
                CurrentPage--;
        }

        /// <summary>
        /// Force go to first report page
        /// </summary>
        public void FirstPage()
        {
            CurrentPage = 0;
        }

        /// <summary>
        /// Force go to last report page
        /// </summary>
        public void LastPage()
        {
            CurrentPage = TotalPages - 1;
        }

        /// <summary>
        /// Force go to "value" report page
        /// </summary>
        public void SetPage(int value)
        {
            if (value >= 0 && value < TotalPages)
                CurrentPage = value;
        }

        #endregion

        /// <summary>
        /// Prepare the report
        /// </summary>
        public void Prepare()
        {
            Refresh();
        }

        /// <summary>
        /// Force refresh of report
        /// </summary>
        public void Refresh()
        {
            CurrentPage = 0;
            ReportDone = false;
            PrepareReport();
        }        

        #region Protected methods

        private void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            if (v is Report)
            {
                try
                {
                    if (((Report)v).PreparedPages != null)
                        ((Report)v).PreparedPages.Clear();
                    ((Report)v).Dispose();
                }
                catch
                {
                    // nothing
                }
            }
        }

        private Control FindControlRecursive(Control root, string id)
        {
          if (root.ID == id)
            return root;

          foreach (Control ctl in root.Controls)
          {
            Control foundCtl = FindControlRecursive(ctl, id);
            if (foundCtl != null)
              return foundCtl;
          }

          return null;
        }
        
        internal void RegisterData(Report report)
        {
          string[] dataSources = ReportDataSources.Split(new char[] { ';' });
          foreach (string dataSource in dataSources)
          {
            IDataSource ds = FindControlRecursive(Page, dataSource) as IDataSource;
            if (ds == null)
              continue;
            string dataName = (ds as Control).ID;
            RegisterDataAsp(report, ds, dataName);
          }
        }

        /// <summary>
        /// Registers the ASP.NET application data to use it in the report.
        /// </summary>
        /// <param name="report">The <b>Report</b> object.</param>
        /// <param name="data">The application data.</param>
        /// <param name="name">The name of the data.</param>
        public void RegisterDataAsp(Report report, IDataSource data, string name)
        {
          FAspDataName = name;
          FReport = report;
          DataSourceView view = data.GetView("");
          if (view != null)
            view.Select(DataSourceSelectArguments.Empty, new DataSourceViewSelectCallback(RegisterDataAsp));
        }

        private string FAspDataName;
        private Report FReport;
        private void RegisterDataAsp(IEnumerable data)
        {
          if (data != null)
            RegisterDataAsp(FReport, data, FAspDataName);
        }

        /// <summary>
        /// Registers the ASP.NET application data to use it in the report.
        /// </summary>
        /// <param name="report">The <b>Report</b> object.</param>
        /// <param name="data">The application data.</param>
        /// <param name="name">The name of the data.</param>
        public void RegisterDataAsp(Report report, IEnumerable data, string name)
        {
          DataComponentBase existingDs = report.Dictionary.FindDataComponent(name);
          if (existingDs is ViewDataSource && data is DataView)
          {
            // compatibility with old FR versions (earlier than 1.1.45)
            report.Dictionary.RegisterDataView(data as DataView, name, true);
          }
          else
          {
            // in a new versions, always register the business object
            report.Dictionary.RegisterBusinessObject(data, name, 1, true);
          }
        }

        private void PrepareReport()
        {
            if (!ReportDone)
            {
                if (Config.FullTrust)
                    WebUtils.CheckHandlersRuntime();
                if (!DesignMode)
                    Config.WebMode = true;
                else
                    Report.Clear();

                if (!String.IsNullOrEmpty(ReportFile))
                {
                    string fileName = ReportFile;
                    if (!WebUtils.IsAbsolutePhysicalPath(fileName))
                        fileName = this.Context.Request.MapPath(fileName, base.AppRelativeTemplateSourceDirectory, true);
                    Report.Load(fileName);
                }
                else if (!String.IsNullOrEmpty(ReportResourceString))
                    Report.ReportResourceString = ReportResourceString;

                RegisterData(Report);
                OnStartReport(EventArgs.Empty);
                Config.ReportSettings.ShowProgress = false;
                
                if (!ReportDone)
                  ReportDone = Report.Prepare(false);              
                HTMLDone = false;
            }
            DoHtmlPages();
        }

        private void DoHtmlPages()
        {
            if (ReportDone)
            {
                HTMLExport = new HTMLExport();
                HTMLExport.StylePrefix = this.ID;
                HTMLExport.Init_WebMode();
                HTMLExport.Pictures = Pictures;
                HTMLExport.Zoom = Zoom;
                HTMLExport.Layers = false; // layers not work in page
                HTMLExport.PageNumbers = (CurrentPage + 1).ToString();

                if (AutoWidth)
                    HTMLExport.WidthUnits = HtmlSizeUnits.Percent;
                if (AutoHeight)
                    HTMLExport.HeightUnits = HtmlSizeUnits.Percent;

                HTMLExport.WebImagePrefix = String.Concat(WebUtils.HandlerFileName, "?", WebUtils.PicsPrefix);
                HTMLExport.Export(Report, (Stream)null);
                HTMLDone = true;
            }
        }

        private void SendReportPage()
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(WebUtils.StartupScriptName))
            {
                string scriptString = GetPopUpScriptString(PrintWindowWidth, PrintWindowHeight);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), WebUtils.StartupScriptName, scriptString);
            }

            if (ShowToolbar)
            {
                string zoomvalue = Math.Round(Zoom * 100).ToString();
                for (int i = 0; i < cbbZoom.Items.Count; i++)
                    if (cbbZoom.Items[i].Value == zoomvalue)
                    {
                        cbbZoom.SelectedIndex = i;
                        break;
                    }
                tbPage.Text = (CurrentPage + 1).ToString();
                lblPages.Text = String.Format(Res.Get("Misc,ofM"), TotalPages.ToString());
            }

            if ((HTMLExport != null) && (HTMLExport.Count > 0))
            {
                if (HTMLExport.PreparedPages[0].PageText == null)
                {
                    HTMLExport.ProcessPage(0, CurrentPage);
                    Properties.CurrentWidth = HTMLExport.PreparedPages[0].Width;
                    Properties.CurrentHeight = HTMLExport.PreparedPages[0].Height;
                    SaveControlState();
                }

                if (HTMLExport.PreparedPages[0].CSSText != null
                    && HTMLExport.PreparedPages[0].PageText != null)
                {
                    div.InnerHtml = String.Concat(HTMLExport.PreparedPages[0].CSSText, HTMLExport.PreparedPages[0].PageText);

                    for (int i = 0; i < HTMLExport.PreparedPages[0].Pictures.Count; i++)
                    {
                        Stream stream = HTMLExport.PreparedPages[0].Pictures[i];
                        byte[] image = new byte[stream.Length];
                        stream.Position = 0;
                        int n = stream.Read(image, 0, (int)stream.Length);

                        PutStorage(String.Empty, HTMLExport.PreparedPages[0].Guids[i], image);
                    }
                }
            }                        
        }

        /// <inheritdoc/>
        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            bool result = true;            
            if (args is CommandEventArgs)
            {
                CommandEventArgs c = (CommandEventArgs)args;
                if (c.CommandName == btnNext.CommandName)
                    NextPage();
                else if (c.CommandName == btnFirst.CommandName)
                    FirstPage();
                else if (c.CommandName == btnPrev.CommandName)
                    PrevPage();
                else if (c.CommandName == btnLast.CommandName)
                    LastPage();
                else
                    result = false;
            }
            else
                result = false;
            return result;
        }

        /// <inheritdoc/>
        protected override void OnLoad(EventArgs e)        
        {
            this.EnsureChildControls();
            base.OnLoad(e);

            if (HttpContext.Current != null)
            {
                if (!this.Page.IsPostBack)
                    PrepareReport();
                else
                    DoHtmlPages();
            }
        }

        /// <inheritdoc/>
        protected override void OnUnload(EventArgs e)
        {
            // save all objects
            PutStorage(WebUtils.PROPERTIES, ReportGuid, fProperties);
            PutStorage(WebUtils.REPORT, ReportGuid, fReport);            

            if (WebFarmMode)
                WebReportCache.CleanStorage(FileStoragePath, FileStorageTimeout, FileStorageCleanup);

            base.OnUnload(e);
        }

        /// <inheritdoc/>
        protected override void OnInit(EventArgs e)
        {
            FileStoragePath = WebReportCache.GetStoragePath(HttpContext.Current);
            WebFarmMode = !String.IsNullOrEmpty(FileStoragePath);

            if (WebFarmMode)
            {
                FileStorageTimeout = WebReportCache.GetStorageTimeout();
                FileStorageCleanup = WebReportCache.GetStorageCleanup();
            }

            ReportGuid = WebUtils.GetGUID(HttpContext.Current, this.UniqueID);
            
            // load report
            WebReportProperties storedProp = (WebReportProperties)GetStorage(WebUtils.PROPERTIES, ReportGuid);
            if (storedProp != null)
                fProperties = storedProp;

            fReport = (Report)GetStorage(WebUtils.REPORT, ReportGuid);

            base.OnInit(e);
            if (!DesignMode)
              Config.WebMode = true;

            if (!String.IsNullOrEmpty(LocalizationFile))
            {
              string fileName = LocalizationFile;
              if (!WebUtils.IsAbsolutePhysicalPath(fileName))
                fileName = this.Context.Request.MapPath(fileName, base.AppRelativeTemplateSourceDirectory, true);
              Res.LoadLocale(fileName);
            }
        }

        /// <inheritdoc/>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            CreateNavigatorControls();
            base.CreateChildControls();
        }

        /// <inheritdoc/>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (HttpContext.Current == null)            
                RenderDesignModeNavigatorControls(writer);
            else
            {
                SetEnableButtons(); 
                SendReportPage();
                base.RenderContents(writer);
            }            
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WebReport"/> class.
        /// </summary>
        public WebReport()
        {
            this.Width = Unit.Pixel(550);
            this.Height = Unit.Pixel(500);
            this.ForeColor = Color.Black;
            this.BackColor = Color.White;            
        }
    }
}
