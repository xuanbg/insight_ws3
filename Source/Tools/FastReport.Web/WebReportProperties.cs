using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FastReport.Export.RichText;
using FastReport.Export.OoXML;
using FastReport.Export.Html;
using System.Web.Caching;

namespace FastReport.Web
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WebReportProperties
    {
        #region Private

        #region Layout
        private bool fAutoWidth = false;
        private bool fAutoHeight = false;
        private bool fLayers = false;
        private System.Windows.Forms.Padding fPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
        #endregion Layout

        #region Report
        private string fReportResourceString = String.Empty;
        private string fReportDataSources = String.Empty;
        private bool fPictures = true;
        private string fReportFile = String.Empty;
        private string fLocalizationFile = String.Empty;
        private float fZoom = 1f;
        private int fCacheDelay = 15;
        private CacheItemPriority fCachePriority = CacheItemPriority.Normal;
        #endregion Report

        #region Toolbar
        private bool fShowToolbar = true;
        private string fButtonsPath;
        private bool fShowExports = true;
        private bool fShowPrint = true;
        private bool fShowFirstButton = true;
        private bool fShowPrevButton = true;
        private bool fShowNextButton = true;
        private bool fShowLastButton = true;
        private bool fShowZoomButton = true;
        private bool fShowRefreshButton = true;
        private bool fShowPageNumber = true;
        private System.Drawing.Color fToolbarColor = Color.FromArgb(0xECE9D8);
        #endregion Toolbar

        #region RTF
        private bool fShowRtfExport = true;
        private int fRtfJpegQuality = 90;
        private RTFImageFormat fRtfImageFormat = RTFImageFormat.Metafile;
        private bool fRtfPictures = true;
        private bool fRtfPageBreaks = true;
        private bool fRtfWysiwyg = true;
        private string fRtfCreator = WebUtils.DefaultCreator;
        private bool fRtfAutoSize = false;
        #endregion RTF

        #region MHT
        private bool fShowMhtExport = true;
        private bool fMhtPictures = true;
        private bool fMhtWysiwyg = true;
        #endregion MHT

        #region ODS
        private bool fShowOdsExport = true;
        private bool fOdsPageBreaks = true;
        private bool fOdsWysiwyg = true;
        private string fOdsCreator = WebUtils.DefaultCreator;
        #endregion ODS

        #region ODT
        private bool fShowOdtExport = true;
        private bool fOdtPageBreaks = true;
        private bool fOdtWysiwyg = true;
        private string fOdtCreator = WebUtils.DefaultCreator;
        #endregion ODT

        #region XPS
        private bool fShowXpsExport = true;
        #endregion XPS

        #region DBF
        private bool fShowDbfExport = true;
        #endregion Dbf

        #region Word2007
        private bool fShowWord2007Export = true;
        private bool fDocxMatrixBased = true;
        #endregion

        #region Excel2007 format
        private bool fShowExcel2007Export = true;
        private bool fXlsxPageBreaks = true;
        private bool fXlsxWysiwyg = true;
        private bool fXlsxDataOnly = false;
        #endregion Excel2007 format

        #region PowerPoint2007 format
        private bool fShowPowerPoint2007Export = true;
        private PptImageFormat fPptxImageFormat = PptImageFormat.Png;
        #endregion PowerPoint2007 format

        #region XML format
        private bool fShowXmlExcelExport = true;
        private bool fXmlExcelPageBreaks = true;
        private bool fXmlExcelWysiwyg = true;
        private bool fXmlExcelDataOnly = false;
        #endregion XML format

        #region PDF format
        private bool fShowPdfExport = true;
        private bool fPdfEmbeddingFonts = true;
        private bool fPdfBackground = false;
        private bool fPdfPrintOptimized = true;
        private bool fPdfOutline = true;
        private bool fPdfDisplayDocTitle = true;
        private bool fPdfHideToolbar = false;
        private bool fPdfHideMenubar = false;
        private bool fPdfHideWindowUI = false;
        private bool fPdfFitWindow = false;
        private bool fPdfCenterWindow = false;
        private bool fPdfPrintScaling = true;
        private string fPdfTitle = String.Empty;
        private string fPdfAuthor = String.Empty;
        private string fPdfSubject = String.Empty;
        private string fPdfKeywords = String.Empty;
        private string fPdfCreator = WebUtils.DefaultCreator;
        private string fPdfProducer = WebUtils.DefaultProducer;
        private string fPdfUserPassword = String.Empty;
        private string fPdfOwnerPassword = String.Empty;
        private bool fPdfAllowPrint = true;
        private bool fPdfAllowModify = true;
        private bool fPdfAllowCopy = true;
        private bool fPdfAllowAnnotate = true;
        #endregion PDF format

        #region CSV format
        private bool fShowCsvExport = true;
        private string fCsvSeparator = ";";
        private bool fCsvDataOnly = false;
        #endregion CSV format

        #region Text format
        private bool fShowTextExport = true;
        private bool fTextDataOnly = false;
        private bool fTextPageBreaks = true;
        private bool fTextAllowFrames = true;
        private bool fTextSimpleFrames = true;
        private bool fTextEmptyLines = false;
        #endregion Text export

        #region Print
        private bool fPrintInPdf = true;
        private string fPrintWindowWidth = "700px";
        private string fPrintWindowHeight = "500px";
        #endregion

        #region Hidden Properties       
        private int fCurrentPage = 0;
        private bool fReportDone = false;
        private bool fHTMLDone = false;
        private float fCurrentWidth = 0;
        private float fCurrentHeight = 0;
        #endregion

        #endregion Private

        #region Public properties

        #region Layout
        /// <summary>
        /// 
        /// </summary>
        public bool AutoWidth
        {
            get { return fAutoWidth; }
            set { fAutoWidth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoHeight
        {
            get { return fAutoHeight; }
            set { fAutoHeight = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Layers
        {
            get { return fLayers; }
            set { fLayers = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Padding Padding
        {
            get { return fPadding; }
            set { fPadding = value; }
        }
        #endregion Layout

        #region Report

        /// <summary>
        /// 
        /// </summary>
        public string ReportResourceString
        {
            get { return fReportResourceString; }
            set { fReportResourceString = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ReportDataSources
        {
            get { return fReportDataSources; }
            set { fReportDataSources = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool Pictures
        {
            get { return fPictures; }
            set { fPictures = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ReportFile
        {
            get { return fReportFile; }
            set { fReportFile = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LocalizationFile
        {
            get { return fLocalizationFile; }
            set { fLocalizationFile = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Zoom
        {
            get { return fZoom; }
            set { fZoom = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CacheDelay
        {
            get { return fCacheDelay; }
            set { fCacheDelay = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public CacheItemPriority CachePriority
        {
            get { return fCachePriority; }
            set { fCachePriority = value; }
        }

        #endregion Report

        #region Toolbar
        /// <summary>
        /// 
        /// </summary>
        public bool ShowToolbar
        {
            get { return fShowToolbar; }
            set { fShowToolbar = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ButtonsPath
        {
            get { return fButtonsPath; }
            set { fButtonsPath = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowExports
        {
            get { return fShowExports; }
            set { fShowExports = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowPrint
        {
            get { return fShowPrint; }
            set { fShowPrint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowFirstButton
        {
            get { return fShowFirstButton; }
            set { fShowFirstButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowPrevButton
        {
            get { return fShowPrevButton; }
            set { fShowPrevButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowNextButton
        {
            get { return fShowNextButton; }
            set { fShowNextButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowLastButton
        {
            get { return fShowLastButton; }
            set { fShowLastButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowZoomButton
        {
            get { return fShowZoomButton; }
            set { fShowZoomButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowRefreshButton
        {
            get { return fShowRefreshButton; }
            set { fShowRefreshButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowPageNumber
        {
            get { return fShowPageNumber; }
            set { fShowPageNumber = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Drawing.Color ToolbarColor
        {
            get { return fToolbarColor; }
            set { fToolbarColor = value; }
        }
        #endregion Tolbar
        
        #region RTF
        /// <summary>
        /// 
        /// </summary>
        public bool ShowRtfExport
        {
            get { return fShowRtfExport; }
            set { fShowRtfExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int RtfJpegQuality
        {
            get { return fRtfJpegQuality; }
            set { fRtfJpegQuality = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public RTFImageFormat RtfImageFormat
        {
            get { return fRtfImageFormat; }
            set { fRtfImageFormat = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RtfPictures
        {
            get { return fRtfPictures; }
            set { fRtfPictures = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RtfPageBreaks
        {
            get { return fRtfPageBreaks; }
            set { fRtfPageBreaks = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RtfWysiwyg
        {
            get { return fRtfWysiwyg; }
            set { fRtfWysiwyg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RtfCreator
        {
            get { return fRtfCreator; }
            set { fRtfCreator = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RtfAutoSize
        {
            get { return fRtfAutoSize; }
            set { fRtfAutoSize = value; }
        }
        #endregion RTF

        #region MHT
        /// <summary>
        /// 
        /// </summary>
        public bool ShowMhtExport
        {
            get { return fShowMhtExport; }
            set { fShowMhtExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MhtPictures
        {
            get { return fMhtPictures; }
            set { fMhtPictures = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MhtWysiwyg
        {
            get { return fMhtWysiwyg; }
            set { fMhtWysiwyg = value; }
        }
        #endregion MHT

        #region ODS
        /// <summary>
        /// 
        /// </summary>
        public bool ShowOdsExport
        {
            get { return fShowOdsExport; }
            set { fShowOdsExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool OdsPageBreaks
        {
            get { return fOdsPageBreaks; }
            set { fOdsPageBreaks = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool OdsWysiwyg
        {
            get { return fOdsWysiwyg; }
            set { fOdsWysiwyg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OdsCreator
        {
            get { return fOdsCreator; }
            set { fOdsCreator = value; }
        }
        #endregion ODS

        #region ODT
        /// <summary>
        /// 
        /// </summary>
        public bool ShowOdtExport
        {
            get { return fShowOdtExport; }
            set { fShowOdtExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool OdtPageBreaks
        {
            get { return fOdtPageBreaks; }
            set { fOdtPageBreaks = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool OdtWysiwyg
        {
            get { return fOdtWysiwyg; }
            set { fOdtWysiwyg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OdtCreator
        {
            get { return fOdtCreator; }
            set { fOdtCreator = value; }
        }
        #endregion ODT

        #region XPS format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowXpsExport
        {
            get { return fShowXpsExport; }
            set { fShowXpsExport = value; }
        }
        #endregion XPS format

        #region DBF format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowDbfExport
        {
            get { return fShowDbfExport; }
            set { fShowDbfExport = value; }
        }
        #endregion Dbf format

        #region Word2007 format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowWord2007Export
        {
            get { return fShowWord2007Export; }
            set { fShowWord2007Export = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DocxMatrixBased
        {
            get { return fDocxMatrixBased; }
            set { fDocxMatrixBased = value; }
        }
        #endregion

        #region Excel2007 format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowExcel2007Export
        {
            get { return fShowExcel2007Export; }
            set { fShowExcel2007Export = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool XlsxPageBreaks
        {
            get { return fXlsxPageBreaks; }
            set { fXlsxPageBreaks = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool XlsxWysiwyg
        {
            get { return fXlsxWysiwyg; }
            set { fXlsxWysiwyg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool XlsxDataOnly
        {
          get { return fXlsxDataOnly; }
          set { fXlsxDataOnly = value; }
        }
        #endregion Excel2007 format

        #region PowerPoint2007 format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowPowerPoint2007Export
        {
            get { return fShowPowerPoint2007Export; }
            set { fShowPowerPoint2007Export = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PptImageFormat PptxImageFormat
        {
            get { return fPptxImageFormat; }
            set { fPptxImageFormat = value; }
        }
        #endregion PowerPoint2007 format

        #region XML format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowXmlExcelExport
        {
            get { return fShowXmlExcelExport; }
            set { fShowXmlExcelExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool XmlExcelPageBreaks
        {
            get { return fXmlExcelPageBreaks; }
            set { fXmlExcelPageBreaks = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool XmlExcelWysiwyg
        {
            get { return fXmlExcelWysiwyg; }
            set { fXmlExcelWysiwyg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool XmlExcelDataOnly
        {
            get { return fXmlExcelDataOnly; }
            set { fXmlExcelDataOnly = value; }
        }

        #endregion XML format

        #region PDF format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowPdfExport
        {
            get { return fShowPdfExport; }
            set { fShowPdfExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfEmbeddingFonts
        {
            get { return fPdfEmbeddingFonts; }
            set { fPdfEmbeddingFonts = false; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfBackground
        {
            get { return fPdfBackground; }
            set { fPdfBackground = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfPrintOptimized
        {
            get { return fPdfPrintOptimized; }
            set { fPdfPrintOptimized = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfOutline
        {
            get { return fPdfOutline; }
            set { fPdfOutline = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfDisplayDocTitle
        {
            get { return fPdfDisplayDocTitle; }
            set { fPdfDisplayDocTitle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfHideToolbar
        {
            get { return fPdfHideToolbar; }
            set { fPdfHideToolbar = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfHideMenubar
        {
            get { return fPdfHideMenubar; }
            set { fPdfHideMenubar = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfHideWindowUI
        {
            get { return fPdfHideWindowUI; }
            set { fPdfHideWindowUI = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfFitWindow
        {
            get { return fPdfFitWindow; }
            set { fPdfFitWindow = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfCenterWindow
        {
            get { return fPdfCenterWindow; }
            set { fPdfCenterWindow = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfPrintScaling
        {
            get { return fPdfPrintScaling; }
            set { fPdfPrintScaling = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfTitle
        {
            get { return fPdfTitle; }
            set { fPdfTitle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfAuthor
        {
            get { return fPdfAuthor; }
            set { fPdfAuthor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfSubject
        {
            get { return fPdfSubject; }
            set { fPdfSubject = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfKeywords
        {
            get { return fPdfKeywords; }
            set { fPdfKeywords = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfCreator
        {
            get { return fPdfCreator; }
            set { fPdfCreator = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfProducer
        {
            get { return fPdfProducer; }
            set { fPdfProducer = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfUserPassword
        {
            get { return fPdfUserPassword; }
            set { fPdfUserPassword = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PdfOwnerPassword
        {
            get { return fPdfOwnerPassword; }
            set { fPdfOwnerPassword = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfAllowPrint
        {
            get { return fPdfAllowPrint; }
            set { fPdfAllowPrint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfAllowModify
        {
            get { return fPdfAllowModify; }
            set { fPdfAllowModify = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfAllowCopy
        {
            get { return fPdfAllowCopy; }
            set { fPdfAllowCopy = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PdfAllowAnnotate
        {
            get { return fPdfAllowAnnotate; }
            set { fPdfAllowAnnotate = value; }
        }
        #endregion PDF format

        #region CSV format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowCsvExport
        {
            get { return fShowCsvExport; }
            set { fShowCsvExport = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CsvSeparator
        {
            get { return fCsvSeparator; }
            set { fCsvSeparator = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CsvDataOnly
        {
            get { return fCsvDataOnly; }
            set { fCsvDataOnly = value; }
        }
        #endregion CSV format

        #region Text format
        /// <summary>
        /// 
        /// </summary>
        public bool ShowTextExport
        {
            get { return fShowTextExport; }
            set { fShowTextExport = false; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool TextDataOnly
        {
            get { return fTextDataOnly; }
            set { fTextDataOnly = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool TextPageBreaks
        {
            get { return fTextPageBreaks; }
            set { fTextPageBreaks = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool TextAllowFrames
        {
            get { return fTextAllowFrames; }
            set { fTextAllowFrames = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool TextSimpleFrames
        {
            get { return fTextSimpleFrames; }
            set { fTextSimpleFrames = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool TextEmptyLines
        {
            get { return fTextEmptyLines; }
            set { fTextEmptyLines = value; }
        }
        #endregion Text export

        #region Print
        /// <summary>
        /// 
        /// </summary>
        public bool PrintInPdf
        {
            get { return fPrintInPdf; }
            set { fPrintInPdf = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PrintWindowWidth
        {
            get { return fPrintWindowWidth; }
            set { fPrintWindowWidth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PrintWindowHeight
        {
            get { return fPrintWindowHeight; }
            set { fPrintWindowHeight = value; }
        }

        #endregion

        #region Hidden Properties

        /// <summary>
        /// 
        /// </summary>
        public bool ReportDone
        {
            get { return fReportDone; }
            set { fReportDone = value; }
        }
         
        /// <summary>
        /// 
        /// </summary>
        public int CurrentPage
        {
            get { return fCurrentPage; }
            set { fCurrentPage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HTMLDone
        {
            get { return fHTMLDone; }
            set { fHTMLDone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float CurrentWidth
        {
            get { return fCurrentWidth; }
            set { fCurrentWidth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float CurrentHeight
        {
            get { return fCurrentHeight; }
            set { fCurrentHeight = value; }            
        }

        #endregion Hidden Properties

        #endregion

    }
}
