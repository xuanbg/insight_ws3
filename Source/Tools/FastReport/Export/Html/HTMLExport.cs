using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using FastReport.Utils;
using FastReport.Forms;
using FastReport.Export;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Globalization;

namespace FastReport.Export.Html
{
    /// <summary>
    /// Represents the HTML export filter.
    /// </summary>
    public partial class HTMLExport : ExportBase
    {

        #region Private fields

        private struct HTMLThreadData
        {
            public int ReportPage;
            public int PageNumber;
            public int CurrentPage;
            public Stream PagesStream; 
        }

        private struct PicsArchiveItem
        {
            public string FileName;
            public MemoryStream Stream;
        }

        private bool FLayers;
        private bool FWysiwyg;
        private MyRes Res;
        private HtmlTemplates FTemplates;
        private string FTargetPath;
        private string FTargetIndexPath;
        private string FTargetFileName;
        private string FFileName;
        private string FNavFileName;
        private string FOutlineFileName;
        private int FPagesCount;
        private string FDocumentTitle;
        private ImageFormat FImageFormat;
        private ManualResetEvent FFirstPageEvent;
        private bool FSubFolder;
        private bool FNavigator;
        private bool FSinglePage;
        private bool FPictures;
        private bool FWebMode;
        private List<HTMLPageData> FPages;
        private HTMLPageData FPrintPageData;
        private int FCount;
        private string FWebImagePrefix;
        private string FWebImageSuffix;
        private string FStylePrefix;
        private bool FThreaded;
        private string FPrevWatermarkName;
        private long FPrevWatermarkSize;
        private HtmlSizeUnits FWidthUnits;
        private HtmlSizeUnits FHeightUnits;
        private string FSinglePageFileName;
        private string FSubFolderPath;
        private HTMLExportFormat FFormat;
        private MemoryStream FMimeStream;
        private String FBoundary;
        private List<PicsArchiveItem> FPicsArchive;
        private List<ExportIEMStyle> FPrevStyleList;
        private int FPrevStyleListIndex;
        private bool FPageBreaks;
        private bool FPrint;
        private List<string> FCSSStyles;
        private float FHPos;
        private NumberFormatInfo FNumberFormat;

        private List<Stream> FGeneratedStreams;
        private bool FSaveStreams;

        private const string BODY_BEGIN = "</head>\r\n<body bgcolor=\"#FFFFFF\" text=\"#000000\">";
        private const string BODY_END = "</body>";
        private const string PRINT_JS = "<script language=\"javascript\" type=\"text/javascript\"> parent.focus(); parent.print();</script>";

        private const string NBSP = "&nbsp;";
        #endregion

        #region Public properties

        /// <summary>
        /// Enable or disable layers export mode
        /// </summary>
        public bool Layers
        {
            get { return FLayers; }
            set { FLayers = value; }
        }        

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string StylePrefix
        {
            get { return FStylePrefix; }
            set { FStylePrefix = value; }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string WebImagePrefix
        {
            get { return FWebImagePrefix; }
            set { FWebImagePrefix = value; }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string WebImageSuffix
        {
            get { return FWebImageSuffix; }
            set { FWebImageSuffix = value; }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public int Count
        {
            get { return FCount; }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public List<HTMLPageData> PreparedPages
        {
            get { return FPages; }            
        }

        /// <summary>
        /// Enable or disable showing of print dialog in browser when html document is opened
        /// </summary>
        public bool Print
        {
            get { return FPrint; }
            set { FPrint = value; }
        }

        /// <summary>
        /// Enable or disable the breaks between pages in print preview when single page mode is enabled
        /// </summary>
        public bool PageBreaks
        {
            get { return FPageBreaks; }
            set { FPageBreaks = value; }
        }

        /// <summary>
        /// Specifies the output format
        /// </summary>
        public HTMLExportFormat Format
        {
            get { return FFormat; }
            set { FFormat = value; }                
        }

        /// <summary>
        /// Specifies the width units in HTML export
        /// </summary>
        public HtmlSizeUnits WidthUnits
        {
            get { return FWidthUnits; }
            set { FWidthUnits = value; }
        }

        /// <summary>
        /// Specifies the height units in HTML export
        /// </summary>
        public HtmlSizeUnits HeightUnits
        {
            get { return FHeightUnits; }
            set { FHeightUnits = value; }
        }

        /// <summary>
        /// Enable or disable the pictures in HTML export
        /// </summary>
        public bool Pictures
        {
            get { return FPictures; }
            set { FPictures = value; }
        }

        /// <summary>
        /// Enable or disable the WEB mode in HTML export
        /// </summary>
        internal bool WebMode
        {
            get { return FWebMode; }
            set { FWebMode = value; }
        }

        /// <summary>
        /// Enable or disable the single HTML page creation 
        /// </summary>
        public bool SinglePage
        {
            get { return FSinglePage; }
            set { FSinglePage = value; }
        }

        /// <summary>
        /// Enable or disable the page navigator in html export
        /// </summary>
        public bool Navigator
        {
            get { return FNavigator; }
            set { FNavigator = value; }
        }

        /// <summary>
        /// Enable or disable the sub-folder for files of export
        /// </summary>
        public bool SubFolder
        {
            get { return FSubFolder;  }
            set { FSubFolder = value; }
        }

        /// <summary>
        ///  Gets or sets the Wysiwyg quality of export
        /// </summary>
        public bool Wysiwyg
        {
            get { return FWysiwyg; }
            set { FWysiwyg = value; }
        }

        /// <summary>
        /// Gets or sets the image format.
        /// </summary>
        public ImageFormat ImageFormat
        {
            get { return FImageFormat; }
            set { FImageFormat = value; }
        }

        /// <summary>
        /// Gets print page data
        /// </summary>
        public HTMLPageData PrintPageData
        {
            get { return FPrintPageData; }
        }

        /// <summary>
        /// Gets list of generated streams
        /// </summary>
        public List<Stream> GeneratedStreams
        {
            get { return FGeneratedStreams; }
        }
    
        /// <summary>
        /// Enable or disable saving streams in GeneratedStreams collection
        /// </summary>
        public bool SaveStreams
        {
            get { return FSaveStreams; }
            set { FSaveStreams = value; }
        }

        #endregion


        #region Private methods


        private void GeneratedUpdate(string filename, Stream stream)
        {
            int i = GeneratedFiles.IndexOf(filename);
            if (i == -1)
            {
                GeneratedFiles.Add(filename);
                FGeneratedStreams.Add(stream);
            }
            else
            {
                FGeneratedStreams[i] = stream;
            }
        }

        private StringBuilder ExportHTMLPageStart(StringBuilder Page, int PageNumber, int CurrentPage)
        {
            if (FWebMode)
            {
                FPages[CurrentPage].CSSText = Page.ToString();
                FPages[CurrentPage].PageNumber = PageNumber;
                Page = new StringBuilder(4096);
            }

            if (!FWebMode && !FSinglePage)
            {
                Page.AppendLine(BODY_BEGIN);
            }

            return Page;
        }

        private void ExportHTMLPageFinal(StringBuilder CSS, StringBuilder Page, HTMLThreadData d, float MaxWidth, float MaxHeight)
        {
            if (!FWebMode)
            {
                if (!FSinglePage)
                    Page.AppendLine(BODY_END);
                if (d.PagesStream == null)
                {
                    if (FSaveStreams)
                    {
                        string FPageFileName;
                        if (FSinglePage)
                            FPageFileName = FSinglePageFileName;
                        else
                            FPageFileName = FTargetIndexPath + FTargetFileName + d.PageNumber.ToString() + ".html";
                        int i = GeneratedFiles.IndexOf(FPageFileName);
                        Stream OutStream;
                        if (i == -1)
                            OutStream = new MemoryStream();
                        else
                            OutStream = FGeneratedStreams[i];
                        if (!FSinglePage)
                            ExportUtils.Write(OutStream, String.Format(FTemplates.PageTemplateTitle, FDocumentTitle));
                        if (CSS != null)
                            ExportUtils.Write(OutStream, CSS.ToString());
                        if (Page != null)
                            ExportUtils.Write(OutStream, Page.ToString());
                        if (!FSinglePage)
                            ExportUtils.Write(OutStream, FTemplates.PageTemplateFooter);
                        GeneratedUpdate(FPageFileName, OutStream);
                    }
                    else
                    {
                        string FPageFileName = FTargetIndexPath + FTargetFileName + d.PageNumber.ToString() + ".html";
                        GeneratedFiles.Add(FPageFileName);
                        using (FileStream OutStream = new FileStream(FPageFileName, FileMode.Create))
                        using (StreamWriter Out = new StreamWriter(OutStream))
                        {
                            if (!FSinglePage)
                                Out.Write(String.Format(FTemplates.PageTemplateTitle, FDocumentTitle));
                            if (CSS != null)
                                Out.Write(CSS.ToString());
                            if (Page != null)
                                Out.Write(Page.ToString());
                            if (!FSinglePage)
                                Out.Write(FTemplates.PageTemplateFooter);
                        }
                    }
                }
                else
                {
                    if (!FSinglePage)
                        ExportUtils.Write(d.PagesStream, String.Format(FTemplates.PageTemplateTitle, FDocumentTitle));
                    if (CSS != null)
                        ExportUtils.Write(d.PagesStream, CSS.ToString());
                    if (Page != null)
                        ExportUtils.Write(d.PagesStream, Page.ToString());
                    if (!FSinglePage)
                        ExportUtils.Write(d.PagesStream, FTemplates.PageTemplateFooter);
                }
            }
            else
            {
                FPages[d.CurrentPage].Width = MaxWidth / Zoom;
                FPages[d.CurrentPage].Height = MaxHeight / Zoom;
                FPages[d.CurrentPage].PageText = Page.ToString();
                FPages[d.CurrentPage].PageEvent.Set();
            }

            if (!FSinglePage && FThreaded)
                if (d.PageNumber == 1)
                    FFirstPageEvent.Set();
        }

        private void ExportHTMLPage(object data)
        {
            HTMLThreadData d = (HTMLThreadData)data;
            if (FLayers)
                ExportHTMLPageLayered(d);
            else
                ExportHTMLPageTabled(d);

        }

        private void ExportHTMLOutline(Stream OutStream)
        {
            if (!FWebMode)
            {
                // under construction            
            }
            else
            {
                // under construction            
            }
        }

        private void ExportHTMLIndex(Stream Stream)
        {
            ExportUtils.Write(Stream, String.Format(FTemplates.IndexTemplate,
                new object[] { FDocumentTitle, ExportUtils.HtmlURL(FNavFileName), 
                        ExportUtils.HtmlURL(FTargetFileName + 
                        (FSinglePage ? ".main" : "1") + ".html") }));
        }

        private void ExportHTMLNavigator(Stream OutStream)
        {
            //  {0} - pages count {1} - name of report {2} multipage document {3} prefix of pages
            //  {4} first caption {5} previous caption {6} next caption {7} last caption
            //  {8} total caption
            ExportUtils.Write(OutStream, String.Format(FTemplates.NavigatorTemplate,
                new object[] { FPagesCount.ToString(), 
                        FDocumentTitle, (FSinglePage ? "0" : "1"), 
                        ExportUtils.HtmlURL(FFileName), Res.Get("First"), Res.Get("Prev"), 
                        Res.Get("Next"), Res.Get("Last"), Res.Get("Total") }));
        }

        #endregion

        #region Protected methods


        /// <inheritdoc/>
        public override bool ShowDialog()
        {
            if (!FWebMode)
                using (HTMLExportForm form = new HTMLExportForm())
                {
                    form.Init(this);
                    return form.ShowDialog() == DialogResult.OK;
                }
            else
                return true;
        }        

        /// <inheritdoc/>
        protected override string GetFileFilter()
        {
            if (Format == HTMLExportFormat.HTML)
                return new MyRes("FileFilters").Get("HtmlFile");
            else
                return new MyRes("FileFilters").Get("MhtFile");
        }

        /// <inheritdoc/>
        protected override void Start()
        {
            FCSSStyles = new List<string>();
            FHPos = 0;

            FCount = Report.PreparedPages.Count;
            FPagesCount = 0;
            FPrevWatermarkName = String.Empty;
            FPrevWatermarkSize = 0;
            FPrevStyleList = null;
            FPrevStyleListIndex = 0;

            if (FSaveStreams)
            {
                GeneratedUpdate("index.html", null);
                FSubFolder = false;
                FSinglePage = true;
                FNavigator = false;
            }
            
            if (!FWebMode)
            {
                if (FFormat == HTMLExportFormat.MessageHTML)
                {
                    FSubFolder = false;
                    FSinglePage = true;
                    FNavigator = false;
                    FMimeStream = new MemoryStream();
                    FBoundary = ExportUtils.GetID();
                }

                if (!FNavigator)
                    FSinglePage = true;
                if (FileName == "" && Stream != null)
                {
                    FTargetFileName = "html";
                    FSinglePage = true;  
                    FNavigator = false;
                    if (FFormat == HTMLExportFormat.HTML)
                        FPictures = false;                    
                }
                else
                {
                    FTargetFileName = Path.GetFileNameWithoutExtension(FileName);
                    FFileName = FTargetFileName;
                    FTargetIndexPath = !String.IsNullOrEmpty(FileName) ? Path.GetDirectoryName(FileName) : FileName;
                }
                if (!String.IsNullOrEmpty(FTargetIndexPath))
                    FTargetIndexPath += Path.DirectorySeparatorChar;

                if (FPrint)
                {
                    FPictures = true;
                    FPrintPageData = new HTMLPageData();
                }
                else if (FSubFolder)
                {
                    FSubFolderPath = FTargetFileName + ".files" + Path.DirectorySeparatorChar;
                    FTargetPath = FTargetIndexPath + FSubFolderPath;
                    FTargetFileName = FSubFolderPath + FTargetFileName;
                    if (!Directory.Exists(FTargetPath))
                        Directory.CreateDirectory(FTargetPath);
                }
                else
                    FTargetPath = FTargetIndexPath;

                FNavFileName = FTargetFileName + ".nav.html";
                FOutlineFileName = FTargetFileName + ".outline.html";                
                FDocumentTitle = (!String.IsNullOrEmpty(Report.ReportInfo.Name) ?
                    Report.ReportInfo.Name : Path.GetFileNameWithoutExtension(FileName));
                if (FSinglePage)
                {
                    if (FNavigator)
                    {
                        FSinglePageFileName = FTargetIndexPath + FTargetFileName + ".main.html";

                        if (FSaveStreams)
                        {
                            MemoryStream PageStream = new MemoryStream();
                            ExportUtils.Write(PageStream, String.Format(FTemplates.PageTemplateTitle, FDocumentTitle));
                            if (FPrint)
                                ExportUtils.WriteLn(PageStream, PRINT_JS);
                            ExportUtils.WriteLn(PageStream, BODY_BEGIN);
                            GeneratedUpdate(FSinglePageFileName, PageStream);
                        }
                        else
                        {
                            using (Stream PageStream = new FileStream(FSinglePageFileName,
                                FileMode.Create))
                            using (StreamWriter Out = new StreamWriter(PageStream))
                            {
                                Out.Write(String.Format(FTemplates.PageTemplateTitle, FDocumentTitle));
                                if (FPrint)
                                    Out.WriteLine(PRINT_JS);
                                Out.WriteLine(BODY_BEGIN);
                            }
                        }
                    }
                    else
                    {
                        FSinglePageFileName = String.IsNullOrEmpty(FileName) ? "index.html" : FileName;
                        Stream PagesStream;

                        if (FSaveStreams)
                        {
                            PagesStream = new MemoryStream();
                            GeneratedUpdate(FSinglePageFileName, PagesStream);
                        }
                        else
                        {
                            if (FFormat == HTMLExportFormat.HTML)
                                PagesStream = Stream;
                            else
                                PagesStream = FMimeStream;
                        }
                        ExportUtils.Write(PagesStream, String.Format(FTemplates.PageTemplateTitle, FDocumentTitle));
                        if (FPrint)
                            ExportUtils.WriteLn(PagesStream, PRINT_JS);
                        ExportUtils.WriteLn(PagesStream, BODY_BEGIN);
                    }
                }
            }
            else
            {
                FPages.Clear();
                for (int i = 0; i < FCount; i++)
                    FPages.Add(new HTMLPageData());                    
            }
            
            if (!FSinglePage && FThreaded)
                FFirstPageEvent = new ManualResetEvent(false);
        }

        /// <inheritdoc/>
        protected override void ExportPage(int pageNo)
        {
            FPagesCount++;
            if (FSinglePage)
            {
                HTMLThreadData d = new HTMLThreadData();
                d.ReportPage = pageNo;
                d.PageNumber = FPagesCount;
                if (FNavigator)
                {
                    if (FSaveStreams)
                    {
                        d.PagesStream = new MemoryStream();
                        ExportHTMLPage(d);
                        GeneratedUpdate(FSinglePageFileName, d.PagesStream);
                    }
                    else
                    {
                        GeneratedFiles.Add(FSinglePageFileName);
                        using (d.PagesStream = new FileStream(FSinglePageFileName,
                            FileMode.Append))
                        {
                            ExportHTMLPage(d);
                        }
                    }
                }
                else
                {
                    if (FFormat == HTMLExportFormat.HTML)
                        d.PagesStream = Stream;
                    else
                        d.PagesStream = FMimeStream;
                    ExportHTMLPage(d);
                }
            }
            else if (!FWebMode)
                ProcessPage(FPagesCount - 1, pageNo);
        }

        /// <summary>
        /// Process Page with number p and real page ReportPage
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ReportPage"></param>
        public void ProcessPage(int p, int ReportPage)
        {
            HTMLThreadData d = new HTMLThreadData();
            d.ReportPage = ReportPage;
            d.PageNumber = FPagesCount;
            d.PagesStream = null;
            d.CurrentPage = p;
            if (!FWebMode && FThreaded)
                ThreadPool.QueueUserWorkItem(ExportHTMLPage, d);
            else
                ExportHTMLPage(d);
        }

        /// <inheritdoc/>
        protected override void Finish()
        {
            if (!FSinglePage && !FWebMode && FThreaded)
                while (!FFirstPageEvent.WaitOne(10, true))
                    Application.DoEvents();
                
            if (!FWebMode)
            {
                if (FNavigator)
                {
                    if (FSaveStreams)
                    {
                        // do append in memory stream
                        MemoryStream strm = new MemoryStream();
                        int i = GeneratedFiles.IndexOf(FSinglePageFileName);
                        
                        ExportHTMLIndex(FGeneratedStreams[i]);
                                                
                        MemoryStream OutStream = new MemoryStream();
                        ExportHTMLNavigator(OutStream);
                        GeneratedUpdate(FTargetIndexPath + FNavFileName, OutStream);

                        //GeneratedFiles.Add(FTargetIndexPath + FOutlineFileName);
                        //OutStream = new MemoryStream();
                        //ExportHTMLOutline(OutStream);
                        //FGeneratedStreams.Add(OutStream);
                    }
                    else
                    {
                        if (FSinglePage)
                        {
                            if (FSaveStreams)
                            {
                                int i = GeneratedFiles.IndexOf(FSinglePageFileName);
                                Stream PageStream = FGeneratedStreams[i];
                                ExportUtils.WriteLn(PageStream, BODY_END);
                                ExportUtils.Write(PageStream, FTemplates.PageTemplateFooter);
                            }
                            else
                            {
                                using (Stream PageStream = new FileStream(FSinglePageFileName,
                                    FileMode.Append))
                                using (StreamWriter Out = new StreamWriter(PageStream))
                                {
                                    Out.WriteLine(BODY_END);
                                    Out.Write(FTemplates.PageTemplateFooter);
                                }
                            }
                        }
                        ExportHTMLIndex(Stream);
                        GeneratedFiles.Add(FTargetIndexPath + FNavFileName);
                        using (FileStream OutStream = new FileStream(FTargetIndexPath + FNavFileName, FileMode.Create))
                            ExportHTMLNavigator(OutStream);
                        GeneratedFiles.Add(FTargetIndexPath + FOutlineFileName);
                        using (FileStream OutStream = new FileStream(FTargetIndexPath + FOutlineFileName, FileMode.Create))
                            ExportHTMLOutline(OutStream);
                    }
                }
                else if (FFormat == HTMLExportFormat.MessageHTML)
                {

                    ExportUtils.WriteLn(FMimeStream, BODY_END);
                    ExportUtils.Write(FMimeStream, FTemplates.PageTemplateFooter);

                    WriteMHTHeader(Stream, FileName);
                    WriteMimePart(FMimeStream, "text/html", "utf-8", "index.html");

                    for (int i = 0; i < FPicsArchive.Count; i++)
                    {
                        string imagename = FPicsArchive[i].FileName;                        
                        WriteMimePart(FPicsArchive[i].Stream, "image/" + imagename.Substring(imagename.LastIndexOf('.') + 1), "utf-8", imagename);
                    }

                    string last = "--" + FBoundary + "--";
                    Stream.Write(Encoding.ASCII.GetBytes(last), 0, last.Length);
                }
                else
                {
                    if (FSaveStreams)
                    {
                        int i = GeneratedFiles.IndexOf(FSinglePageFileName);                        
                        ExportUtils.WriteLn(FGeneratedStreams[i], BODY_END);
                        ExportUtils.Write(FGeneratedStreams[i], FTemplates.PageTemplateFooter);
                    }
                }
            }
        }

        #endregion


        /// <inheritdoc/>
        public override void Serialize(FRWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBool("Layers", Layers);
            writer.WriteBool("Wysiwyg", Wysiwyg);
            writer.WriteBool("Pictures", Pictures);
            writer.WriteBool("SubFolder", SubFolder);
            writer.WriteBool("Navigator", Navigator);
            writer.WriteBool("SinglePage", SinglePage);
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public void Init_WebMode()       
        {
            FPages = new List<HTMLPageData>();
            FWebMode = true;
            OpenAfterExport = false;            
        }

        internal void Finish_WebMode()
        {
            FPages.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HTMLExport"/> class.
        /// </summary>
        public HTMLExport()
        {            
            Zoom = 1.0f;
            HasMultipleFiles = true;
            FLayers = false;
            FWysiwyg = true;
            FPictures = true;
            FWebMode = false;
            FSubFolder = true;
            FNavigator = true;
            FSinglePage = false;
            FThreaded = false;
            FWidthUnits = HtmlSizeUnits.Pixel;
            FHeightUnits = HtmlSizeUnits.Pixel;
            FImageFormat = ImageFormat.Png;
            FTemplates = new HtmlTemplates();
            FFormat = HTMLExportFormat.HTML;
            FPicsArchive = new List<PicsArchiveItem>();
            FPrevStyleList = null;
            FPrevStyleListIndex = 0;
            FPageBreaks = true;
            FPrint = false;
            FGeneratedStreams = new List<Stream>();
            FSaveStreams = false;
            FNumberFormat = new NumberFormatInfo();
            FNumberFormat.NumberGroupSeparator = String.Empty;
            FNumberFormat.NumberDecimalSeparator = ".";
            Res = new MyRes("Export,Html");
        }
    }
}
