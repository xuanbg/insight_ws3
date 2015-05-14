using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using FastReport.Export.Csv;
using System.IO;
using FastReport.Export.Text;
using FastReport.Export.Dbf;
using FastReport.Export.Pdf;
using FastReport.Export.Html;
using FastReport.Export.RichText;
using FastReport.Export.Mht;
using FastReport.Export.Xml;
using FastReport.Export.Odf;
using FastReport.Export.OoXML;

namespace FastReport.Web
{
#if! WinForms
    public
#endif
    partial class WebReport : WebControl, INamingContainer
    {
        #region RTF format

        /// <summary>
        /// Switch visibility of RTF export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowRtfExport
        {
            get { return Properties.ShowRtfExport; }
            set { Properties.ShowRtfExport = value; }
        }

        /// <summary>
        /// Gets or sets the quality of Jpeg images in RTF file.
        /// </summary>
        /// <remarks>
        /// Default value is 90. This property will be used if you select Jpeg 
        /// in the <see cref="RtfImageFormat"/> property.
        /// </remarks>
        [DefaultValue(90)]
        [Category("Rtf Format")]
        [Browsable(true)]
        public int RtfJpegQuality
        {
            get { return Properties.RtfJpegQuality; }
            set { Properties.RtfJpegQuality = value; }
        }

        /// <summary>
        /// Gets or sets the image format that will be used to save pictures in RTF file.
        /// </summary>
        /// <remarks>
        /// Default value is <b>Metafile</b>. This format is better for exporting such objects as
        /// <b>MSChartObject</b> and <b>ShapeObject</b>.
        /// </remarks>
        [DefaultValue(RTFImageFormat.Metafile)]
        [Category("Rtf Format")]
        [Browsable(true)]
        public RTFImageFormat RtfImageFormat
        {
            get { return Properties.RtfImageFormat; }
            set { Properties.RtfImageFormat = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that pictures are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Rtf Format")]
        [Browsable(true)]
        public bool RtfPictures
        {
            get { return Properties.RtfPictures; }
            set { Properties.RtfPictures = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that page breaks are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Rtf Format")]
        [Browsable(true)]
        public bool RtfPageBreaks
        {
            get { return Properties.RtfPageBreaks; }
            set { Properties.RtfPageBreaks = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting rtf file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        [DefaultValue(true)]
        [Category("Rtf Format")]
        [Browsable(true)]
        public bool RtfWysiwyg
        {
            get { return Properties.RtfWysiwyg; }
            set { Properties.RtfWysiwyg = value; }
        }

        /// <summary>
        /// Gets or sets the creator of the document.
        /// </summary>
        [DefaultValue("FastReport")]
        [Category("Rtf Format")]
        [Browsable(true)]
        public string RtfCreator
        {
            get { return Properties.RtfCreator; }
            set { Properties.RtfCreator = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the rows in the resulting table 
        /// should calculate its height automatically.
        /// </summary>
        /// <remarks>
        /// Default value for this property is <b>false</b>. In this mode, each row in the
        /// resulting table has fixed height to get maximum wysiwyg. If you set it to <b>true</b>,
        /// the height of resulting table will be calculated automatically by the Word processor.
        /// The document will be more editable, but less wysiwyg.
        /// </remarks>
        [DefaultValue(false)]
        [Category("Rtf Format")]
        [Browsable(true)]
        public bool RtfAutoSize
        {
            get { return Properties.RtfAutoSize; }
            set { Properties.RtfAutoSize = value; }
        }

        #endregion RTF format
        #region MHT format
        /// <summary>
        /// Switch visibility of MHT (web-archive) export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowMhtExport
        {
            get { return Properties.ShowMhtExport; }
            set { Properties.ShowMhtExport = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that pictures are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Mht Format")]
        [Browsable(true)]
        public bool MhtPictures
        {
            get { return Properties.MhtPictures; }
            set { Properties.MhtPictures = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting rtf file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        [DefaultValue(true)]
        [Category("Mht Format")]
        [Browsable(true)]
        public bool MhtWysiwyg
        {
            get { return Properties.MhtWysiwyg; }
            set { Properties.MhtWysiwyg = value; }
        }
        #endregion MHT format
        #region ODS format

        /// <summary>
        /// Switch visibility of Open Office Spreadsheet (ODS) export in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowOdsExport
        {
            get { return Properties.ShowOdsExport; }
            set { Properties.ShowOdsExport = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that page breaks are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Ods Format")]
        [Browsable(true)]
        public bool OdsPageBreaks
        {
            get { return Properties.OdsPageBreaks; }
            set { Properties.OdsPageBreaks = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting rtf file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        [DefaultValue(true)]
        [Category("Ods Format")]
        [Browsable(true)]
        public bool OdsWysiwyg
        {
            get { return Properties.OdsWysiwyg; }
            set { Properties.OdsWysiwyg = value; }
        }

        /// <summary>
        /// Gets or sets the creator of the document.
        /// </summary>
        [DefaultValue("FastReport")]
        [Category("Ods Format")]
        [Browsable(true)]
        public string OdsCreator
        {
            get { return Properties.OdsCreator; }
            set { Properties.OdsCreator = value; }
        }
        #endregion ODS format
        #region ODT format

        /// <summary>
        /// Switch visibility of Open Office Text (ODT) export in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowOdtExport
        {
            get { return Properties.ShowOdtExport; }
            set { Properties.ShowOdtExport = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that page breaks are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Odt Format")]
        [Browsable(true)]
        public bool OdtPageBreaks
        {
            get { return Properties.OdtPageBreaks; }
            set { Properties.OdtPageBreaks = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting rtf file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        [DefaultValue(true)]
        [Category("Odt Format")]
        [Browsable(true)]
        public bool OdtWysiwyg
        {
            get { return Properties.OdtWysiwyg; }
            set { Properties.OdtWysiwyg = value; }
        }

        /// <summary>
        /// Gets or sets the creator of the document.
        /// </summary>
        [DefaultValue("FastReport")]
        [Category("Odt Format")]
        [Browsable(true)]
        public string OdtCreator
        {
            get { return Properties.OdtCreator; }
            set { Properties.OdtCreator = value; }
        }
        #endregion ODT format
        #region XPS format
        /// <summary>
        /// Switch visibility of XPS export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowXpsExport
        {
            get { return Properties.ShowXpsExport; }
            set { Properties.ShowXpsExport = value; }
        }
        #endregion XPS format
        #region DBF format
        /// <summary>
        /// Switch visibility of DBF export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowDbfExport
        {
            get { return Properties.ShowDbfExport; }
            set { Properties.ShowDbfExport = value; }
        }
        #endregion Dbf format
        #region Word2007 format
        /// <summary>
        /// Switch visibility of Word 2007 export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowWord2007Export
        {
            get { return Properties.ShowWord2007Export; }
            set { Properties.ShowWord2007Export = value; }
        }

        /// <summary>
        /// Enable or disable matrix view of Word 2007 document
        /// </summary>
        [DefaultValue(true)]
        [Category("Word 2007 Format")]
        [Browsable(true)]
        public bool DocxMatrixBased
        {
            get { return Properties.DocxMatrixBased; }
            set { Properties.DocxMatrixBased = value; }
        }
        #endregion
        #region Excel2007 format

        /// <summary>
        /// Switch visibility of Excel 2007 export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowExcel2007Export
        {
            get { return Properties.ShowExcel2007Export; }
            set { Properties.ShowExcel2007Export = value; }
        }

        /// <summary>
        ///  Gets or sets a value indicating that page breaks are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Excel 2007 Format")]
        [Browsable(true)]
        public bool XlsxPageBreaks
        {
            get { return Properties.XlsxPageBreaks; }
            set { Properties.XlsxPageBreaks = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting rtf file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        [DefaultValue(true)]
        [Category("Excel 2007 Format")]
        [Browsable(true)]
        public bool XlsxWysiwyg
        {
            get { return Properties.XlsxWysiwyg; }
            set { Properties.XlsxWysiwyg = value; }
        }

        /// <summary>
        /// Enable or disable of exporting data without any header/group bands.
        /// </summary>
        [DefaultValue(true)]
        [Category("Excel 2007 Format")]
        [Browsable(true)]
        public bool XlsxDataOnly
        {
          get { return Properties.XlsxDataOnly; }
          set { Properties.XlsxDataOnly = value; }
        }
        #endregion Excel2007 format
        #region PowerPoint2007 format
        /// <summary>
        /// Switch visibility of PowerPoint 2007 export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowPowerPoint2007Export
        {
            get { return Properties.ShowPowerPoint2007Export; }
            set { Properties.ShowPowerPoint2007Export = value; }
        }

        /// <summary>
        /// Gets or sets the image format that will be used to save pictures in PowerPoint file.
        /// </summary>
        [DefaultValue(PptImageFormat.Png)]
        [Category("PowerPoint 2007 Format")]
        [Browsable(true)]
        public PptImageFormat PptxImageFormat
        {
            get { return Properties.PptxImageFormat; }
            set { Properties.PptxImageFormat = value; }
        }
        #endregion PowerPoint2007 format
        #region XML format
        /// <summary>
        ///  Switch visibility of XML (Excel) export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowXmlExcelExport
        {
            get { return Properties.ShowXmlExcelExport; }
            set { Properties.ShowXmlExcelExport = value; }
        }

        /// <summary>
        ///  Gets or sets a value indicating that page breaks are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Xml Excel Format")]
        [Browsable(true)]
        public bool XmlExcelPageBreaks
        {
            get { return Properties.XmlExcelPageBreaks; }
            set { Properties.XmlExcelPageBreaks = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting rtf file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        [DefaultValue(true)]
        [Category("Xml Excel Format")]
        [Browsable(true)]
        public bool XmlExcelWysiwyg
        {
            get { return Properties.XmlExcelWysiwyg; }
            set { Properties.XmlExcelWysiwyg = value; }
        }

        /// <summary>
        /// Enable or disable of exporting data without any header/group bands.
        /// </summary>
        [DefaultValue(false)]
        [Category("Xml Excel Format")]
        [Browsable(true)]
        public bool XmlExcelDataOnly
        {
            get { return Properties.XmlExcelDataOnly; }
            set { Properties.XmlExcelDataOnly = value; }
        }
        #endregion XML format
        #region PDF format
        /// <summary>
        ///  Switch visibility of PDF (Adobe Acrobat) export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowPdfExport
        {
            get { return Properties.ShowPdfExport; }
            set { Properties.ShowPdfExport = value; }
        }

        /// <summary>
        /// Enable or disable of embedding the TrueType fonts.
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfEmbeddingFonts
        {
            get { return Properties.PdfEmbeddingFonts; }
            set { Properties.PdfEmbeddingFonts = value; }
        }

        /// <summary>
        /// Enable or disable of exporting the background.
        /// </summary>
        [DefaultValue(false)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfBackground
        {
            get { return Properties.PdfBackground; }
            set { Properties.PdfBackground = value; }
        }

        /// <summary>
        /// Enable or disable of optimization the images for printing. 
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfPrintOptimized
        {
            get { return Properties.PdfPrintOptimized; }
            set { Properties.PdfPrintOptimized = value; }
        }

        /// <summary>
        /// Enable or disable of document's Outline.
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfOutline
        {
            get { return Properties.PdfOutline; }
            set { Properties.PdfOutline = value; }
        }

        /// <summary>
        /// Enable or disable of displaying document's title.
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfDisplayDocTitle
        {
            get { return Properties.PdfDisplayDocTitle; }
            set { Properties.PdfDisplayDocTitle = value; }
        }

        /// <summary>
        /// Enable or disable hide the toolbar. 
        /// </summary>
        [DefaultValue(false)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfHideToolbar
        {
            get { return Properties.PdfHideToolbar; }
            set { Properties.PdfHideToolbar = value; }
        }

        /// <summary>
        /// Enable or disable hide the menu's bar.
        /// </summary>
        [DefaultValue(false)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfHideMenubar
        {
            get { return Properties.PdfHideMenubar; }
            set { Properties.PdfHideMenubar = value; }
        }

        /// <summary>
        /// Enable or disable hide the Windows UI. 
        /// </summary>
        [DefaultValue(false)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfHideWindowUI
        {
            get { return Properties.PdfHideWindowUI; }
            set { Properties.PdfHideWindowUI = value; }
        }

        /// <summary>
        /// Enable or disable of fitting the window. 
        /// </summary>
        [DefaultValue(false)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfFitWindow
        {
            get { return Properties.PdfFitWindow; }
            set { Properties.PdfFitWindow = value; }
        }

        /// <summary>
        ///  Enable or disable centering the window.
        /// </summary>
        [DefaultValue(false)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfCenterWindow
        {
            get { return Properties.PdfCenterWindow; }
            set { Properties.PdfCenterWindow = value; }
        }

        /// <summary>
        /// Enable or disable of scaling the page for shrink to printable area. 
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfPrintScaling
        {
            get { return Properties.PdfPrintScaling; }
            set { Properties.PdfPrintScaling = value; }
        }

        /// <summary>
        /// Title of the document. 
        /// </summary>
        [DefaultValue("")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfTitle
        {
            get { return Properties.PdfTitle; }
            set { Properties.PdfTitle = value; }
        }

        /// <summary>
        /// Author of the document. 
        /// </summary>
        [DefaultValue("")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfAuthor
        {
            get { return Properties.PdfAuthor; }
            set { Properties.PdfAuthor = value; }
        }

        /// <summary>
        ///  Subject of the document.
        /// </summary>
        [DefaultValue("")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfSubject
        {
            get { return Properties.PdfSubject; }
            set { Properties.PdfSubject = value; }
        }

        /// <summary>
        ///  Keywords of the document.
        /// </summary>
        [DefaultValue("")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfKeywords
        {
            get { return Properties.PdfKeywords; }
            set { Properties.PdfKeywords = value; }
        }

        /// <summary>
        /// Creator of the document.
        /// </summary>
        [DefaultValue("FastReport")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfCreator
        {
            get { return Properties.PdfCreator; }
            set { Properties.PdfCreator = value; }
        }

        /// <summary>
        /// Producer of the document.
        /// </summary>
        [DefaultValue("FastReport.NET")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfProducer
        {
            get { return Properties.PdfProducer; }
            set { Properties.PdfProducer = value; }
        }

        /// <summary>
        /// Sets the users password.
        /// </summary>
        [DefaultValue("")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfUserPassword
        {
            get { return Properties.PdfUserPassword; }
            set { Properties.PdfUserPassword = value; }
        }

        /// <summary>
        /// Sets the owner password. 
        /// </summary>
        [DefaultValue("")]
        [Category("Pdf Format")]
        [Browsable(true)]
        public string PdfOwnerPassword
        {
            get { return Properties.PdfOwnerPassword; }
            set { Properties.PdfOwnerPassword = value; }
        }

        /// <summary>
        /// Enable or disable printing in protected document. 
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfAllowPrint
        {
            get { return Properties.PdfAllowPrint; }
            set { Properties.PdfAllowPrint = value; }
        }

        /// <summary>
        /// Enable or disable modifying in protected document. 
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfAllowModify
        {
            get { return Properties.PdfAllowModify; }
            set { Properties.PdfAllowModify = value; }
        }

        /// <summary>
        /// Enable or disable copying in protected document. 
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfAllowCopy
        {
            get { return Properties.PdfAllowCopy; }
            set { Properties.PdfAllowCopy = value; }
        }

        /// <summary>
        /// Enable or disable annotating in protected document. 
        /// </summary>
        [DefaultValue(true)]
        [Category("Pdf Format")]
        [Browsable(true)]
        public bool PdfAllowAnnotate
        {
            get { return Properties.PdfAllowAnnotate; }
            set { Properties.PdfAllowAnnotate = value; }
        }
        #endregion PDF format
        #region CSV format
        /// <summary>
        /// Switch visibility of CSV (comma separated values) export in toolbar.
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowCsvExport
        {
            get { return Properties.ShowCsvExport; }
            set { Properties.ShowCsvExport = value; }
        }

        /// <summary>
        /// Gets or sets of cells separator. 
        /// </summary>
        [DefaultValue(";")]
        [Category("Csv Format")]
        [Browsable(true)]
        public string CsvSeparator
        {
            get { return Properties.CsvSeparator; }
            set { Properties.CsvSeparator = value; }
        }

        /// <summary>
        /// Enable or disable of exporting data without any header/group bands.
        /// </summary>
        [DefaultValue(false)]
        [Category("Csv Format")]
        [Browsable(true)]
        public bool CsvDataOnly
        {
            get { return Properties.CsvDataOnly; }
            set { Properties.CsvDataOnly = value; }
        }
        #endregion CSV format
        #region Text format
        /// <summary>
        ///  Switch visibility of text (plain text) export in toolbar
        /// </summary>
        [DefaultValue(true)]
        [Category("Toolbar")]
        [Browsable(true)]
        public bool ShowTextExport
        {
            get { return Properties.ShowTextExport; }
            set { Properties.ShowTextExport = value; }
        }

        /// <summary>
        /// Enable or disable of exporting data without any header/group bands.
        /// </summary>
        [DefaultValue(false)]
        [Category("Text Format")]
        [Browsable(true)]
        public bool TextDataOnly
        {
            get { return Properties.TextDataOnly; }
            set { Properties.TextDataOnly = value; }
        }

        /// <summary>
        ///  Gets or sets a value indicating that page breaks are enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("Text Format")]
        [Browsable(true)]
        public bool TextPageBreaks
        {
            get { return Properties.TextPageBreaks; }
            set { Properties.TextPageBreaks = value; }
        }

        /// <summary>
        /// Enable or disable frames in text file.
        /// </summary>
        [DefaultValue(true)]
        [Category("Text Format")]
        [Browsable(true)]
        public bool TextAllowFrames
        {
            get { return Properties.TextAllowFrames; }
            set { Properties.TextAllowFrames = value; }
        }

        /// <summary>
        /// Enable or disable simple (non graphic) frames in text file.
        /// </summary>
        [DefaultValue(true)]
        [Category("Text Format")]
        [Browsable(true)]
        public bool TextSimpleFrames
        {
            get { return Properties.TextSimpleFrames; }
            set { Properties.TextSimpleFrames = value; }
        }

        /// <summary>
        /// Enable or disable empty lines in text file.
        /// </summary>
        [DefaultValue(false)]
        [Category("Text Format")]
        [Browsable(true)]
        public bool TextEmptyLines
        {
            get { return Properties.TextEmptyLines; }
            set { Properties.TextEmptyLines = value; }
        }
        #endregion Text export


        #region All exports

        private string GetExportFileName(string format)
        {
            return this.Context.Server.UrlPathEncode(
                String.Concat(
                Path.GetFileNameWithoutExtension(Report.FileName.Length == 0 ? WebUtils.ReportPrefix : Report.FileName), 
                ".", 
                format));
        }

        private void ResponseExport(string guid, WebExportItem ExportItem, bool displayInline)
        {
            ExportItem.FileName = GetExportFileName(ExportItem.Format);

            PutStorage(WebUtils.EXPORT, guid, ExportItem);

            string url = string.Format("~/{0}?{1}={2}&displayinline={3}", WebUtils.HandlerFileName, WebUtils.ConstID, guid, displayInline);
            this.Context.Response.Redirect(url, true);
        }

        private void ResponseExport(string guid, WebExportItem ExportItem)
        {
            ResponseExport(guid, ExportItem, false);
        }

        /// <summary>
        /// Export in CSV format
        /// </summary>
        public void ExportCsv()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                CSVExport csvExport = new CSVExport();
                csvExport.OpenAfterExport = false;
                // set csv export properties
                csvExport.Separator = CsvSeparator;
                csvExport.DataOnly = CsvDataOnly;
                MemoryStream ms = new MemoryStream();
                csvExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "csv";
                ExportItem.ContentType = "text/x-сsv";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in Text format
        /// </summary>
        public void ExportText()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                TextExport textExport = new TextExport();
                textExport.OpenAfterExport = false;
                // set text export properties
                textExport.AvoidDataLoss = true;
                textExport.DataOnly = TextDataOnly;
                textExport.PageBreaks = TextPageBreaks;
                textExport.Frames = TextAllowFrames;
                textExport.TextFrames = TextSimpleFrames;
                textExport.EmptyLines = TextEmptyLines;
                MemoryStream ms = new MemoryStream();
                textExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "txt";
                ExportItem.ContentType = "text/plain";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in DBF format
        /// </summary>
        public void ExportDbf()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                DBFExport dbfExport = new DBFExport();
                dbfExport.OpenAfterExport = false;
                // set text export properties
                dbfExport.DataOnly = true;
                MemoryStream ms = new MemoryStream();
                dbfExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "dbf";
                ExportItem.ContentType = "application/dbf";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in PDF format
        /// </summary>
        public void ExportPdf()
        {
            ExportPdf(false);
        }

        /// <summary>
        /// Export in PDF format inline
        /// </summary>
        public void ExportPdf(bool displayInline)
        {
            if (ReportDone)
            {
                WebExportItem ExportItem = new WebExportItem();
                PDFExport pdfExport = new PDFExport();
                pdfExport.OpenAfterExport = false;
                // set pdf export properties
                pdfExport.EmbeddingFonts = PdfEmbeddingFonts;
                pdfExport.Background = PdfBackground;
                pdfExport.PrintOptimized = PdfPrintOptimized;
                pdfExport.Title = PdfTitle;
                pdfExport.Author = PdfAuthor;
                pdfExport.Subject = PdfSubject;
                pdfExport.Keywords = PdfKeywords;
                pdfExport.Creator = PdfCreator;
                pdfExport.Producer = PdfProducer;
                pdfExport.Outline = PdfOutline;
                pdfExport.DisplayDocTitle = PdfDisplayDocTitle;
                pdfExport.HideToolbar = PdfHideToolbar;
                pdfExport.HideMenubar = PdfHideMenubar;
                pdfExport.HideWindowUI = PdfHideWindowUI;
                pdfExport.FitWindow = PdfFitWindow;
                pdfExport.CenterWindow = PdfCenterWindow;
                pdfExport.PrintScaling = PdfPrintScaling;
                pdfExport.UserPassword = PdfUserPassword;
                pdfExport.OwnerPassword = PdfOwnerPassword;
                pdfExport.AllowPrint = PdfAllowPrint;
                pdfExport.AllowCopy = PdfAllowCopy;
                pdfExport.AllowModify = PdfAllowModify;
                pdfExport.AllowAnnotate = PdfAllowAnnotate;
                MemoryStream ms = new MemoryStream();
                pdfExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "pdf";
                ExportItem.ContentType = "application/pdf";
                ResponseExport(ReportGuid, ExportItem, displayInline);
            }
        }

        /// <summary>
        /// Export in HTML format inline
        /// </summary>
        public void ExportHtml(bool displayInline)
        {
            if (ReportDone)
            {
                WebExportItem ExportItem = new WebExportItem();
                HTMLExport htmlExport = new HTMLExport();
                htmlExport.OpenAfterExport = false;
                // set html export properties
                htmlExport.Navigator = false;
                htmlExport.Layers = Layers;
                htmlExport.SinglePage = true;
                htmlExport.Pictures = Pictures;
                htmlExport.Print = true;
                htmlExport.WebImagePrefix = String.Concat(WebUtils.HandlerFileName, "?", WebUtils.PicsPrefix);
                MemoryStream ms = new MemoryStream();
                htmlExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();

                // add all pictures in cache
                for (int i = 0; i < htmlExport.PrintPageData.Pictures.Count; i++)
                {
                    Stream stream = htmlExport.PrintPageData.Pictures[i];
                    byte[] image = new byte[stream.Length];
                    stream.Position = 0;
                    int n = stream.Read(image, 0, (int)stream.Length);
                    string picGuid = htmlExport.PrintPageData.Guids[i];

                    PutStorage(String.Empty, picGuid, image);
                }

                // cleanup 
                foreach (Stream stream in htmlExport.PrintPageData.Pictures)
                    stream.Dispose();
                htmlExport.PrintPageData.Pictures.Clear();
                htmlExport.PrintPageData.Guids.Clear();

                ExportItem.Format = "html";
                ExportItem.ContentType = "text/html";

                ResponseExport(ReportGuid, ExportItem, displayInline);
            }
        }

        /// <summary>
        /// Export in RTF format
        /// </summary>
        public void ExportRtf()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                RTFExport rtfExport = new RTFExport();
                rtfExport.OpenAfterExport = false;
                // set Rtf export properties
                rtfExport.JpegQuality = RtfJpegQuality;
                rtfExport.ImageFormat = RtfImageFormat;
                rtfExport.Pictures = RtfPictures;
                rtfExport.PageBreaks = RtfPageBreaks;
                rtfExport.Wysiwyg = RtfWysiwyg;
                rtfExport.Creator = RtfCreator;
                rtfExport.AutoSize = RtfAutoSize;
                MemoryStream ms = new MemoryStream();
                rtfExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "rtf";
                ExportItem.ContentType = "application/rtf";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in MHT format
        /// </summary>
        public void ExportMht()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                MHTExport mhtExport = new MHTExport();
                mhtExport.OpenAfterExport = false;
                // set MHT export properties
                mhtExport.Pictures = MhtPictures;
                mhtExport.Wysiwyg = MhtWysiwyg;
                MemoryStream ms = new MemoryStream();
                mhtExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "mht";
                ExportItem.ContentType = "message/rfc822";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in XML (Excel 2003) format
        /// </summary>
        public void ExportXmlExcel()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                XMLExport xmlExport = new XMLExport();
                xmlExport.OpenAfterExport = false;
                // set xml export properties
                xmlExport.PageBreaks = XmlExcelPageBreaks;
                xmlExport.Wysiwyg = XmlExcelWysiwyg;
                xmlExport.DataOnly = XmlExcelDataOnly;
                MemoryStream ms = new MemoryStream();
                xmlExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "xls";
                ExportItem.ContentType = "application/vnd.ms-excel";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in Open Office Spreadsheet format
        /// </summary>
        public void ExportOds()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                ODSExport odsExport = new ODSExport();
                odsExport.OpenAfterExport = false;
                // set ODS export properties
                odsExport.Creator = OdsCreator;
                odsExport.Wysiwyg = OdsWysiwyg;
                odsExport.PageBreaks = OdsPageBreaks;
                MemoryStream ms = new MemoryStream();
                odsExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "ods";
                ExportItem.ContentType = "application/x-oleobject";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in Open Office Text format
        /// </summary>
        public void ExportOdt()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                ODTExport odtExport = new ODTExport();
                odtExport.OpenAfterExport = false;
                // set ODT export properties
                odtExport.Creator = OdtCreator;
                odtExport.Wysiwyg = OdtWysiwyg;
                odtExport.PageBreaks = OdtPageBreaks;
                MemoryStream ms = new MemoryStream();
                odtExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "odt";
                ExportItem.ContentType = "application/x-oleobject";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in XPS format
        /// </summary>
        public void ExportXps()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                XPSExport xpsExport = new XPSExport();
                xpsExport.OpenAfterExport = false;
                MemoryStream ms = new MemoryStream();
                xpsExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "xps";
                ExportItem.ContentType = "application/vnd.ms xpsdocument";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in Excel 2007 format
        /// </summary>
        public void ExportExcel2007()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                Excel2007Export xlsxExport = new Excel2007Export();
                xlsxExport.OpenAfterExport = false;
                // set Excel 2007 export properties
                xlsxExport.PageBreaks = XlsxPageBreaks;
                xlsxExport.DataOnly = XlsxDataOnly;
                MemoryStream ms = new MemoryStream();
                xlsxExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "xlsx";
                ExportItem.ContentType = "application/vnd.ms-excel";
                ResponseExport(ReportGuid, ExportItem);
            }
        }


        /// <summary>
        /// Export in Word 2007 format
        /// </summary>
        public void ExportWord2007()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                Word2007Export docxExport = new Word2007Export();
                docxExport.OpenAfterExport = false;
                // set Word 2007 export properties
                docxExport.MatrixBased = DocxMatrixBased;
                MemoryStream ms = new MemoryStream();
                docxExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "docx";
                ExportItem.ContentType = "application/vnd.ms-word";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Export in PowerPoint 2007 format 
        /// </summary>
        public void ExportPowerPoint2007()
        {
            if (ReportDone && TotalPages > 0)
            {
                WebExportItem ExportItem = new WebExportItem();
                PowerPoint2007Export pptxExport = new PowerPoint2007Export();
                pptxExport.OpenAfterExport = false;
                // set Power Point 2007 properties
                pptxExport.ImageFormat = PptxImageFormat;
                MemoryStream ms = new MemoryStream();
                pptxExport.Export(Report, ms);
                ExportItem.File = ms.ToArray();
                ExportItem.Format = "pptx";
                ExportItem.ContentType = "application/vnd.ms-powerpoint ";
                ResponseExport(ReportGuid, ExportItem);
            }
        }

        /// <summary>
        /// Print in Adobe Acrobat
        /// </summary>
        public void PrintPdf()
        {
            ExportPdf(true);
        }

        /// <summary>
        /// Print in browser
        /// </summary>
        public void PrintHtml()
        {
            ExportHtml(true);
        }
        #endregion
    }
}
