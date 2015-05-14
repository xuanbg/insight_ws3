using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using FastReport.Utils;
using FastReport.Forms;
using FastReport.Export;
using System.Globalization;
using FastReport.Table;
using FastReport.Export.TTF;

namespace FastReport.Export.Pdf
{
    /// <summary>
    /// PDF export (Adobe Acrobat)
    /// </summary>
    public partial class PDFExport : ExportBase
    {        
        #region Constants
        const string PDF_VER = "1.5"; // minimum Acrobat Reader version 6.0
        const float PDF_DIVIDER = 0.75f;
        const float PDF_PAGE_DIVIDER = 2.8357f;
        const int PDF_PRINTOPT = 3;
        float PDF_TTF_DIVIDER = 1 / (750 * 96f / DrawUtils.ScreenDpi);

        #endregion

        #region Private fields
        private string FTitle;
        private string FAuthor;
        private string FSubject;
        private string FKeywords;
        private string FCreator;
        private string FProducer;

        private bool FOutline;
        private bool FDisplayDocTitle;
        private bool FHideToolbar;
        private bool FHideMenubar;
        private bool FHideWindowUI;
        private bool FFitWindow;
        private bool FCenterWindow;
        private bool FPrintScaling;
        private string FUserPassword;
        private string FOwnerPassword;
        private bool FAllowPrint;
        private bool FAllowModify;
        private bool FAllowCopy;
        private bool FAllowAnnotate;

        private bool FEncrypted;

        private bool FEmbeddingFonts;
        private bool FCompressed;
        private bool FBackground;
        private bool FPrintOptimized;

        private string FFileID;

        private long FRootNumber;
        private long FPagesNumber;
        private long FOutlineNumber;
        private long FInfoNumber;
        private long FStartXRef;
        
        private List<long> FXRef;
        private List<long> FPagesRef;

        private List<string> FTrasparentStroke;
        private List<string> FTrasparentFill;
        private List<float> FPagesHeights;

        private float FMarginLeft;
        private float FMarginWoBottom;

        private float FDpiFX;

        private Stream pdf;

        private bool FBuffered;
        private int FRichTextQuality;
        private int FJpegQuality;

        private NumberFormatInfo FNumberFormatInfo;

        #endregion

        #region Properties

        /// <summary>
        /// Sets the quality of images in the PDF
        /// </summary>
        public int JpegQuality
        {
            get { return FJpegQuality; }
            set { FJpegQuality = value; }
        }

        /// <summary>
        /// Sets the quality of RichText objects in the PDF
        /// </summary>
        public int RichTextQuality
        {
            get { return FRichTextQuality; }
            set { FRichTextQuality = value; }
        }

        /// <summary>
        /// Enable or disable the compression in PDF document.
        /// </summary>
        public bool Compressed
        {
            get { return FCompressed; }
            set { FCompressed = value; }
        }

        /// <summary>
        /// Enable or disable of embedding the TrueType fonts.
        /// </summary>
        public bool EmbeddingFonts
        {
            get { return FEmbeddingFonts; }
            set { FEmbeddingFonts = value; }
        }

        /// <summary>
        /// Enable or disable of exporting the background.
        /// </summary>
        public bool Background
        {
            get { return FBackground; }
            set { FBackground = value; }
        }

        /// <summary>
        /// Enable or disable of optimization the images for printing.
        /// </summary>
        public bool PrintOptimized
        {
            get { return FPrintOptimized; }
            set { FPrintOptimized = value; }
        }

        /// <summary>
        /// Title of the document.
        /// </summary>
        public string Title
        {
            get { return FTitle; }
            set { FTitle = value; }
        }

        /// <summary>
        /// Author of the document.
        /// </summary>
        public string Author
        {
            get { return FAuthor; }
            set { FAuthor = value; }
        }

        /// <summary>
        /// Subject of the document.
        /// </summary>
        public string Subject
        {
            get { return FSubject; }
            set { FSubject = value; }
        }

        /// <summary>
        /// Keywords of the document.
        /// </summary>
        public string Keywords
        {
            get { return FKeywords; }
            set { FKeywords = value; }
        }

        /// <summary>
        /// Creator of the document.
        /// </summary>
        public string Creator
        {
            get { return FCreator; }
            set { FCreator = value; }
        }

        /// <summary>
        /// Producer of the document.
        /// </summary>
        public string Producer
        {
            get { return FProducer; }
            set { FProducer = value; }
        }

        /// <summary>
        /// Enable or disable of document's Outline.
        /// </summary>
        public bool Outline
        {
            get { return FOutline; }
            set { FOutline = value; }
        }
        /// <summary>
        /// Enable or disable of displaying document's title.
        /// </summary>
        public bool DisplayDocTitle
        {
            get { return FDisplayDocTitle; }
            set { FDisplayDocTitle = value; }
        }
        /// <summary>
        /// Enable or disable hide the toolbar.
        /// </summary>
        public bool HideToolbar
        {
            get { return FHideToolbar; }
            set { FHideToolbar = value; }
        }
        /// <summary>
        /// Enable or disable hide the menu's bar.
        /// </summary>
        public bool HideMenubar
        {
            get { return FHideMenubar; }
            set { FHideMenubar = value; }
        }
        /// <summary>
        /// Enable or disable hide the Windows UI.
        /// </summary>
        public bool HideWindowUI
        {
            get { return FHideWindowUI; }
            set { FHideWindowUI = value; }
        }
        /// <summary>
        /// Enable or disable of fitting the window
        /// </summary>
        public bool FitWindow
        {
            get { return FFitWindow; }
            set { FFitWindow = value; }
        }
        /// <summary>
        /// Enable or disable of centering the window.
        /// </summary>
        public bool CenterWindow
        {
            get { return FCenterWindow; }
            set { FCenterWindow = value; }
        }
        /// <summary>
        /// Enable or disable of scaling the page for shrink to printable area.
        /// </summary>
        public bool PrintScaling
        {
            get { return FPrintScaling; }
            set { FPrintScaling = value; }
        }
        /// <summary>
        /// Sets the user password.
        /// </summary>
        public string UserPassword
        {
            get { return FUserPassword; }
            set { FUserPassword = value; }
        }
        /// <summary>
        /// Sets the owner password.
        /// </summary>
        public string OwnerPassword
        {
            get { return FOwnerPassword; }
            set { FOwnerPassword = value; }
        }
        /// <summary>
        /// Enable or disable printing in protected document.
        /// </summary>
        public bool AllowPrint
        {
            get { return FAllowPrint; }
            set { FAllowPrint = value; }
        }
        /// <summary>
        /// Enable or disable modifying in protected document.
        /// </summary>
        public bool AllowModify
        {
            get { return FAllowModify; }
            set { FAllowModify = value; }
        }
        /// <summary>
        /// Enable or disable copying in protected document.
        /// </summary>
        public bool AllowCopy
        {
            get { return FAllowCopy; }
            set { FAllowCopy = value; }
        }
        /// <summary>
        /// Enable or disable annotating in protected document.
        /// </summary>
        public bool AllowAnnotate
        {
            get { return FAllowAnnotate; }
            set { FAllowAnnotate = value; }
        }
        #endregion

        #region Private Methods

        private void AddPDFHeader()
        {
            FXRef.Clear();
            FPagesRef.Clear();
            FPagesHeights.Clear();
            FFonts.Clear();
            WriteLn(pdf, "%PDF-" + PDF_VER);
            // reserve object for pages
            UpdateXRef();
        }

        private void AddPage(ReportPage page)
        {            
            FPageFonts.Clear();            
            FTrasparentStroke.Clear();
            FTrasparentFill.Clear();
            PicResList.Clear();

            FMarginWoBottom = (page.PaperHeight - page.TopMargin) * PDF_PAGE_DIVIDER;
            FMarginLeft = page.LeftMargin * PDF_PAGE_DIVIDER;

            FPagesHeights.Add(FMarginWoBottom);

            long FContentsPos = 0;
            using (MemoryStream FContentBuilder = new MemoryStream(65536))
            {
                // page fill   
                if (FBackground)
                    using (TextObject pageFill = new TextObject())
                    {
                        pageFill.Fill = page.Fill;
                        pageFill.Left = -FMarginLeft / PDF_DIVIDER;
                        pageFill.Top = -page.TopMargin * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                        pageFill.Width = page.PaperWidth * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                        pageFill.Height = page.PaperHeight * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                        AddTextObject(FContentBuilder, pageFill, false);
                    }

                // bitmap watermark on bottom
                if (page.Watermark.Enabled && !page.Watermark.ShowImageOnTop)
                    AddBitmapWatermark(FContentBuilder, page);

                // text watermark on bottom
                if (page.Watermark.Enabled && !page.Watermark.ShowTextOnTop)
                    AddTextWatermark(FContentBuilder, page);

                // page borders
                if (page.Border.Lines != BorderLines.None)
                {
                    using (TextObject pageBorder = new TextObject())
                    {
                        pageBorder.Border = page.Border;
                        pageBorder.Left = 0;
                        pageBorder.Top = 0;
                        pageBorder.Width = (page.PaperWidth - page.LeftMargin - page.RightMargin) * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                        pageBorder.Height = (page.PaperHeight - page.TopMargin - page.BottomMargin) * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                        AddTextObject(FContentBuilder, pageBorder, true);
                    }
                }

                foreach (Base c in page.AllObjects)
                {
                    if (c is ReportComponentBase)
                    {
                        ReportComponentBase obj = c as ReportComponentBase;
                        if (obj is CellularTextObject)
                            obj = (obj as CellularTextObject).GetTable();
                        if (obj is TableCell)
                            continue;
                        else
                            if (obj is TableBase)
                            {
                                TableBase table = obj as TableBase;
                                if (table.ColumnCount > 0 && table.RowCount > 0)
                                {
                                    string tableBorder;
                                    using (TextObject tableback = new TextObject())
                                    {
                                        tableback.Border = table.Border;
                                        tableback.Fill = table.Fill;
                                        tableback.FillColor = table.FillColor;
                                        tableback.Left = table.AbsLeft;
                                        tableback.Top = table.AbsTop;
                                        float tableWidth = 0;
                                        float tableHeight = 0;
                                        for (int i = 0; i < table.ColumnCount; i++)
                                          tableWidth += table[i, 0].Width;
                                        for (int i = 0; i < table.RowCount; i++)
                                          tableHeight += table.Rows[i].Height;
                                        tableback.Width = (tableWidth < table.Width) ? tableWidth : table.Width;
                                        tableback.Height = tableHeight;
                                        AddTextObject(FContentBuilder, tableback, false);
                                        tableBorder = DrawPDFBorder(tableback.Border, tableback.AbsLeft, tableback.AbsTop, tableback.Width, tableback.Height);
                                    }
                                    // draw cells
                                    AddTable(FContentBuilder, table, true);
                                    // draw cells border
                                    AddTable(FContentBuilder, table, false);
                                    // draw table border
                                    Write(FContentBuilder, tableBorder);
                                }
                            }
                            else if (obj is TextObject)
                                AddTextObject(FContentBuilder, obj as TextObject, true);
                            else if (obj is BandBase)
                                AddBandObject(FContentBuilder, obj as BandBase);
                            else if (obj is LineObject)
                                AddLine(FContentBuilder, obj as LineObject);
                            else if (obj is ShapeObject)
                                AddShape(FContentBuilder, obj as ShapeObject);
                            else if (obj is RichObject)
                                AddPictureObject(FContentBuilder, obj as ReportComponentBase, true, FRichTextQuality);
                            else
                                AddPictureObject(FContentBuilder, obj as ReportComponentBase, true, FJpegQuality);
                    }
                }

                // bitmap watermark on top
                if (page.Watermark.Enabled && page.Watermark.ShowImageOnTop)
                    AddBitmapWatermark(FContentBuilder, page);

                // text watermark on top
                if (page.Watermark.Enabled && page.Watermark.ShowTextOnTop)
                    AddTextWatermark(FContentBuilder, page);

                FContentsPos = UpdateXRef();
                WriteLn(pdf, ObjNumber(FContentsPos));
                if (FCompressed)
                {
                    using (MemoryStream memstream = new MemoryStream())
                    {
                        ExportUtils.ZLibDeflate(FContentBuilder, memstream);
                        StringBuilder sb1 = new StringBuilder(80);
                        sb1.Append("<< /Filter /FlateDecode /Length ").Append((memstream.Length).ToString());
                        sb1.Append(" /Length1 ").Append(FContentBuilder.Length.ToString()).AppendLine(" >>");
                        sb1.AppendLine("stream");                        
                        Write(pdf, sb1.ToString());
                        if (FEncrypted)
                            RC4CryptStream(memstream, pdf, FEncKey, FContentsPos);
                        else
                            memstream.WriteTo(pdf);
                    }
                }
                else
                {
                    StringBuilder sb1 = new StringBuilder(80);
                    sb1.Append("<< /Length ").Append(FContentBuilder.Length.ToString()).AppendLine(" >>");
                    sb1.AppendLine("stream");
                    Write(pdf, sb1.ToString());
                    if (FEncrypted)
                        RC4CryptStream(FContentBuilder, pdf, FEncKey, FContentsPos);
                    else
                        FContentBuilder.WriteTo(pdf);                    
                }
                WriteLn(pdf, String.Empty);
                WriteLn(pdf, "endstream");
                WriteLn(pdf, "endobj");
            }
            if (FPageFonts.Count > 0)
                for (int i = 0; i < FPageFonts.Count; i++)
                    if (!FPageFonts[i].Saved)
                    {
                        FPageFonts[i].Reference = UpdateXRef();
                        FPageFonts[i].Saved = true;
                    }                        
            long PageNumber = UpdateXRef();
            FPagesRef.Add(PageNumber);
            WriteLn(pdf, ObjNumber(PageNumber));
            StringBuilder sb = new StringBuilder(512);
            sb.AppendLine("<<").AppendLine("/Type /Page");
            sb.Append("/MediaBox [0 0 ").Append(FloatToString(page.PaperWidth * PDF_PAGE_DIVIDER)).Append(" ");
            sb.Append(FloatToString(page.PaperHeight * PDF_PAGE_DIVIDER)).AppendLine(" ]");            
            sb.AppendLine("/Parent 1 0 R").AppendLine("/Resources << ");
            if (FPageFonts.Count > 0)
            {
                sb.Append("/Font << ");
                foreach (ExportTTFFont font in FPageFonts)
                    sb.Append(font.Name).Append(" ").Append(ObjNumberRef(font.Reference)).Append(" ");
                sb.AppendLine(" >>");
            }
            sb.AppendLine("/ExtGState <<");
            for (int i = 0; i < FTrasparentStroke.Count; i++)
                sb.Append("/GS").Append(i.ToString()).Append("S << /Type /ExtGState /ca ").Append(FTrasparentStroke[i]).AppendLine(" >>");
            for (int i = 0; i < FTrasparentFill.Count; i++)
                sb.Append("/GS").Append(i.ToString()).Append("F << /Type /ExtGState /CA ").Append(FTrasparentFill[i]).AppendLine(" >>");

            sb.AppendLine(">>");
            sb.Append("/XObject << ");
            foreach(int resIndex in PicResList)
                sb.Append("/Im").Append(resIndex.ToString()).Append(" ").Append(ObjNumberRef(PicturesList[resIndex].Id)).Append(" ");

            sb.AppendLine(" >>");
            sb.AppendLine("/ProcSet [/PDF /Text /ImageC ]");
            sb.AppendLine(">>");
            sb.Append("/Contents ").AppendLine(ObjNumberRef(FContentsPos));
            sb.AppendLine(">>");
            sb.AppendLine("endobj");
            Write(pdf, sb.ToString());
        }

        private void AddBitmapWatermark(Stream outstream, ReportPage page)
        {
            if (page.Watermark.Image != null)
            {
                using (PictureObject pictureWatermark = new PictureObject())
                {
                    pictureWatermark.Left = -FMarginLeft / PDF_DIVIDER;
                    pictureWatermark.Top = -page.TopMargin * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                    pictureWatermark.Width = page.PaperWidth * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                    pictureWatermark.Height = page.PaperHeight * PDF_PAGE_DIVIDER / PDF_DIVIDER;

                    pictureWatermark.SizeMode = PictureBoxSizeMode.Normal;
                    pictureWatermark.Image = new Bitmap((int)pictureWatermark.Width, (int)pictureWatermark.Height);
                    using (Graphics g = Graphics.FromImage(pictureWatermark.Image))
                    {
                        g.Clear(Color.Transparent);
                        page.Watermark.DrawImage(new FRPaintEventArgs(g, 1, 1, Report.GraphicCache),
                            new RectangleF(0, 0, pictureWatermark.Width, pictureWatermark.Height), Report, true);
                    }
                    pictureWatermark.Transparency = page.Watermark.ImageTransparency;
                    pictureWatermark.Fill = new SolidFill(Color.Transparent);
                    pictureWatermark.FillColor = Color.Transparent;
                    AddPictureObject(outstream, pictureWatermark, false, FJpegQuality);
                }
            }
        }

        private void AddTextWatermark(Stream outstream, ReportPage page)
        {
            if (!String.IsNullOrEmpty(page.Watermark.Text))
                using (TextObject textWatermark = new TextObject())
                {
                    textWatermark.HorzAlign = HorzAlign.Center;
                    textWatermark.VertAlign = VertAlign.Center;
                    textWatermark.Left = -FMarginLeft / PDF_DIVIDER;
                    textWatermark.Top = -page.TopMargin * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                    textWatermark.Width = page.PaperWidth * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                    textWatermark.Height = page.PaperHeight * PDF_PAGE_DIVIDER / PDF_DIVIDER;
                    textWatermark.Text = page.Watermark.Text;
                    textWatermark.TextFill = page.Watermark.TextFill;
                    if (page.Watermark.TextRotation == WatermarkTextRotation.Vertical)
                        textWatermark.Angle = 270;
                    else if (page.Watermark.TextRotation == WatermarkTextRotation.ForwardDiagonal)
                        textWatermark.Angle = 360 - (int)(Math.Atan(textWatermark.Height / textWatermark.Width) * (180 / Math.PI));
                    else if (page.Watermark.TextRotation == WatermarkTextRotation.BackwardDiagonal)
                        textWatermark.Angle = (int)(Math.Atan(textWatermark.Height / textWatermark.Width) * (180 / Math.PI));
                    textWatermark.Font = page.Watermark.Font;
                    if (page.Watermark.TextFill is SolidFill)
                        textWatermark.TextColor = (page.Watermark.TextFill as SolidFill).Color;
                    textWatermark.Fill = new SolidFill(Color.Transparent);
                    textWatermark.FillColor = Color.Transparent;
                    AddTextObject(outstream, textWatermark, false);
                }
        }

        private void AddTable(Stream outstream, TableBase table, bool drawCells)
        {
            float y = 0;
            for (int i = 0; i < table.RowCount; i++)
            {
                float x = 0;
                for (int j = 0; j < table.ColumnCount; j++)
                {
                    if (!table.IsInsideSpan(table[j, i]))
                    {
                        TableCell textcell = table[j, i];
                        textcell.Left = x;
                        textcell.Top = y;
                        if (drawCells)
                        {
                            Border oldBorder = textcell.Border.Clone();
                            textcell.Border.Lines = BorderLines.None;
                            if ((textcell as TextObject) is TextObject)
                                AddTextObject(outstream, textcell as TextObject, false);
                            else
                                AddPictureObject(outstream, textcell as ReportComponentBase, false, FJpegQuality);
                            textcell.Border = oldBorder;
                        }
                        else
                            Write(outstream, DrawPDFBorder(textcell.Border, textcell.AbsLeft, textcell.AbsTop, textcell.Width, textcell.Height));
                    }
                    x += (table.Columns[j]).Width;
                }
                y += (table.Rows[i]).Height;
            }
        }

        private void AddShape(Stream outstream, ShapeObject shapeObject)
        {
            if (shapeObject.Shape == ShapeKind.Rectangle && shapeObject.Fill is SolidFill)
            {
                Write(outstream, DrawPDFFillRect(
                    GetLeft(shapeObject.AbsLeft), GetTop(shapeObject.AbsTop),
                    shapeObject.Width * PDF_DIVIDER, shapeObject.Height * PDF_DIVIDER, 
                    shapeObject.Fill));
                Write(outstream, DrawPDFRect(
                    GetLeft(shapeObject.AbsLeft),
                    GetTop(shapeObject.AbsTop),
                    GetLeft(shapeObject.AbsLeft + shapeObject.Width),
                    GetTop(shapeObject.AbsTop + shapeObject.Height),
                    shapeObject.Border.Color, shapeObject.Border.Width * PDF_DIVIDER, shapeObject.Border.Style));
            }
            else if (shapeObject.Shape == ShapeKind.Triangle && shapeObject.Fill is SolidFill)
                Write(outstream, DrawPDFTriangle(GetLeft(shapeObject.AbsLeft), GetTop(shapeObject.AbsTop),
                    shapeObject.Width * PDF_DIVIDER, shapeObject.Height * PDF_DIVIDER, 
                    shapeObject.FillColor, shapeObject.Border.Color, shapeObject.Border.Width * PDF_DIVIDER, shapeObject.Border.Style));
            else if (shapeObject.Shape == ShapeKind.Diamond && shapeObject.Fill is SolidFill)
                Write(outstream, DrawPDFDiamond(GetLeft(shapeObject.AbsLeft), GetTop(shapeObject.AbsTop),
                    shapeObject.Width * PDF_DIVIDER, shapeObject.Height * PDF_DIVIDER,
                    shapeObject.FillColor, shapeObject.Border.Color, shapeObject.Border.Width * PDF_DIVIDER, shapeObject.Border.Style));
            else if (shapeObject.Shape == ShapeKind.Ellipse && shapeObject.Fill is SolidFill)
                Write(outstream, DrawPDFEllipse(GetLeft(shapeObject.AbsLeft), GetTop(shapeObject.AbsTop),
                    shapeObject.Width * PDF_DIVIDER, shapeObject.Height * PDF_DIVIDER,
                    shapeObject.FillColor, shapeObject.Border.Color, shapeObject.Border.Width * PDF_DIVIDER, shapeObject.Border.Style));
            else
                AddPictureObject(outstream, shapeObject, true, FJpegQuality);
        }

        private void AddLine(Stream outstream, LineObject l)
        {
            Write(outstream, DrawPDFLine(GetLeft(l.AbsLeft),
                GetTop(l.AbsTop), GetLeft(l.AbsLeft + l.Width), GetTop(l.AbsTop + l.Height), 
                l.Border.Color, l.Border.Width * PDF_DIVIDER, l.Border.Style, l.StartCap, l.EndCap));
        }

        private void AddBandObject(Stream outstream, BandBase band)
        {
            using (TextObject newObj = new TextObject())
            {
                newObj.Left = band.AbsLeft;
                newObj.Top = band.AbsTop;
                newObj.Width = band.Width;
                newObj.Height = band.Height;
                newObj.Fill = band.Fill;
                newObj.Border = band.Border;
                AddTextObject(outstream, newObj, true);
            }
        }

        private void AddTextObject(Stream outstream, TextObject obj, bool drawBorder)
        {
            string Left = FloatToString(GetLeft(obj.AbsLeft));
            string Top = FloatToString(GetTop(obj.AbsTop));
            string Right = FloatToString(GetLeft(obj.AbsLeft + obj.Width));
            string Bottom = FloatToString(GetTop(obj.AbsTop + obj.Height));
            string Width = FloatToString(obj.Width * PDF_DIVIDER);
            string Height = FloatToString(obj.Height * PDF_DIVIDER);

            StringBuilder Result = new StringBuilder(256);

            Result.AppendLine("q");
            Result.Append(FloatToString(GetLeft(obj.AbsLeft))).Append(" ");
            Result.Append(FloatToString(GetTop(obj.AbsTop + obj.Height))).Append(" ");
            Result.Append(FloatToString((obj.Width) * PDF_DIVIDER)).Append(" ");
            Result.Append(FloatToString((obj.Height) * PDF_DIVIDER)).AppendLine(" re");
            Result.AppendLine("W").AppendLine("n");

            // draw background
            if (obj.Fill is SolidFill || (obj.Fill is GlassFill && !(obj.Fill as GlassFill).Hatch))
                Result.Append(DrawPDFFillRect(GetLeft(obj.AbsLeft), GetTop(obj.AbsTop),
                    obj.Width * PDF_DIVIDER, obj.Height * PDF_DIVIDER, obj.Fill));
            else if (obj.Width > 0 && obj.Height > 0)
            {
                using (PictureObject backgroundPicture = new PictureObject())
                {
                    backgroundPicture.Left = obj.AbsLeft;
                    backgroundPicture.Top = obj.AbsTop;
                    backgroundPicture.Width = obj.Width;
                    backgroundPicture.Height = obj.Height;
                    backgroundPicture.Image = new Bitmap((int)backgroundPicture.Width, (int)backgroundPicture.Height);
                    using (Graphics g = Graphics.FromImage(backgroundPicture.Image))
                    {
                        g.Clear(Color.Transparent);
                        g.TranslateTransform(-obj.AbsLeft, -obj.AbsTop);
                        BorderLines oldLines = obj.Border.Lines;
                        obj.Border.Lines = BorderLines.None;
                        string oldText = obj.Text;
                        obj.Text = String.Empty;
                        obj.Draw(new FRPaintEventArgs(g, 1, 1, Report.GraphicCache));
                        obj.Text = oldText;
                        obj.Border.Lines = oldLines;
                    }
                    AddPictureObject(outstream, backgroundPicture, false, FJpegQuality);
                }
            }

            if (obj.Underlines)
                AppendUnderlines(Result, obj);

            if (!String.IsNullOrEmpty(obj.Text))
            {
                int ObjectFontNumber = GetObjFontNumber(obj.Font);
                // obj with HtmlTags uses own font/color for each word/run
                if (!obj.HtmlTags)
                    AppendFont(Result, ObjectFontNumber, obj.Font.Size, obj.TextColor);
                
                using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
                using (Font f = new Font(obj.Font.Name, obj.Font.Size * FDpiFX, obj.Font.Style))
                //using (GraphicCache cache = new GraphicCache())
                {
                    RectangleF textRect = new RectangleF(
                      obj.AbsLeft + obj.Padding.Left,
                      obj.AbsTop + obj.Padding.Top,
                      obj.Width - obj.Padding.Horizontal,
                      obj.Height - obj.Padding.Vertical);

                    bool transformNeeded = obj.Angle != 0 || obj.FontWidthRatio != 1;

                    // transform, rotate and scale pdf coordinates if needed
                    if (transformNeeded)
                    {
                        textRect.X = -textRect.Width / 2;
                        textRect.Y = -textRect.Height / 2;

                        float angle = (float)((360 - obj.Angle) * Math.PI / 180);
                        float sin = (float)Math.Sin(angle);
                        float cos = (float)Math.Cos(angle);
                        float x = GetLeft(obj.AbsLeft + obj.Width / 2);
                        float y = GetTop(obj.AbsTop + obj.Height / 2);
                        // offset the origin to the middle of bounding rectangle, then rotate
                        Result.Append(FloatToString(cos)).Append(" ").
                            Append(FloatToString(sin)).Append(" ").
                            Append(FloatToString(-sin)).Append(" ").
                            Append(FloatToString(cos)).Append(" ").
                            Append(FloatToString(x)).Append(" ").
                            Append(FloatToString(y)).AppendLine(" cm");

                        // apply additional matrix to scale x coordinate
                        if (obj.FontWidthRatio != 1)
                            Result.Append(FloatToString(obj.FontWidthRatio)).AppendLine(" 0 0 1 0 0 cm");
                    }

                    // break the text to paragraphs, lines, words and runs
                    StringFormat format = obj.GetStringFormat(Report.GraphicCache /*cache*/, 0);
                    Brush textBrush = Report.GraphicCache.GetBrush(obj.TextColor);
                    AdvancedTextRenderer renderer = new AdvancedTextRenderer(obj.Text, g, f, textBrush,
                        textRect, format, obj.HorzAlign, obj.VertAlign, obj.LineHeight, obj.Angle, obj.FontWidthRatio,
                        obj.ForceJustify, obj.Wysiwyg, obj.HtmlTags, true);
                    float w = f.Height * 0.1f; // to match .net char X offset
                    // invert offset in case of rtl
                    if (obj.RightToLeft)
                      w = -w;
                    // we don't need this offset if text is centered
                    if (obj.HorzAlign == HorzAlign.Center)
                      w = 0;  

                    // render
                    foreach (AdvancedTextRenderer.Paragraph paragraph in renderer.Paragraphs)
                        foreach (AdvancedTextRenderer.Line line in paragraph.Lines)
                        {                            
                            foreach (RectangleF rect in line.Underlines)
                              Result.Append(DrawPDFUnderline(ObjectFontNumber, f, rect.Left, rect.Top, rect.Width, w, obj.TextColor, transformNeeded));
                            foreach (RectangleF rect in line.Strikeouts)
                              Result.Append(DrawPDFStrikeout(ObjectFontNumber, f, rect.Left, rect.Top, rect.Width, w, obj.TextColor, transformNeeded));
                            
                            foreach (AdvancedTextRenderer.Word word in line.Words)
                                if (renderer.HtmlTags)
                                    foreach (AdvancedTextRenderer.Run run in word.Runs)
                                        using (Font fnt = run.GetFont())
                                        {
                                            ObjectFontNumber = GetObjFontNumber(fnt);
                                            AppendFont(Result, ObjectFontNumber, fnt.Size / FDpiFX, run.Style.Color);
                                            AppendText(Result, ObjectFontNumber, fnt, run.Left, run.Top, w, run.Text, obj.RightToLeft, transformNeeded);
                                        }
                                else
                                    AppendText(Result, ObjectFontNumber, f, word.Left, word.Top, w, word.Text, obj.RightToLeft, transformNeeded);
                        }
                }
            }
            Result.AppendLine("Q");
            if (drawBorder)
                Result.Append(DrawPDFBorder(obj.Border, obj.AbsLeft, obj.AbsTop, obj.Width, obj.Height));
            Write(outstream, Result.ToString());
        }

        private void AppendUnderlines(StringBuilder Result, TextObject obj)
        {
            float lineHeight = obj.LineHeight == 0 ? obj.Font.GetHeight() : obj.LineHeight;
            lineHeight *= FDpiFX * PDF_DIVIDER;
            float curY = GetTop(obj.AbsTop) - lineHeight;
            float bottom = GetTop(obj.AbsBottom);
            float left = GetLeft(obj.AbsLeft);
            float right = GetLeft(obj.AbsRight);
            float width = obj.Border.Width * PDF_DIVIDER;
            while (curY > bottom)
            {
                Result.Append(DrawPDFLine(left, curY, right, curY, obj.Border.Color, width, LineStyle.Solid, null, null));
                curY -= lineHeight;
            }
        }

        private void AppendText(StringBuilder Result, int fontNumber, Font font, float x, float y, float offsX, string text, bool rtl, bool transformNeeded)
        {
            ExportTTFFont pdffont = FPageFonts[fontNumber];
            x = (transformNeeded ? x * PDF_DIVIDER : GetLeft(x)) + offsX;
            y = transformNeeded ? -y * PDF_DIVIDER : GetTop(y);
            y -= GetBaseline(font) * PDF_DIVIDER;
          
            string s = pdffont.RemapString(text, rtl);
            Result.AppendLine("BT");
            Result.Append(FloatToString(x)).Append(" ").Append(FloatToString(y)).AppendLine(" Td");
            Result.Append("<").Append(ExportUtils.StrToHex2(s)).AppendLine("> Tj");
            Result.AppendLine("ET");
        }
        
        private void AddPDFFooter()
        {
            foreach (ExportTTFFont font in FFonts)
                WriteFont(font);

            FPagesNumber = 1;            
            FXRef[0] = pdf.Position;
            WriteLn(pdf, ObjNumber(FPagesNumber));
            WriteLn(pdf, "<<");
            WriteLn(pdf, "/Type /Pages");
            Write(pdf, "/Kids [");
            foreach (long page in FPagesRef)
                Write(pdf, ObjNumberRef(page) + " ");
            WriteLn(pdf, "]");
            WriteLn(pdf, "/Count " + FPagesRef.Count.ToString());
            WriteLn(pdf, ">>");
            WriteLn(pdf, "endobj");

            if (FOutline)
            {
                FastReport.Preview.Outline outline = Report.PreparedPages.Outline;
                FOutlineNumber = UpdateXRef();
                OutlineTree = new PDFOutlineNode();
                OutlineTree.Number = FOutlineNumber;
                BuildOutline(OutlineTree, outline.Xml);
                WriteOutline(OutlineTree);
            }
            
            FInfoNumber = UpdateXRef();
            WriteLn(pdf, ObjNumber(FInfoNumber));
            WriteLn(pdf, "<<");
            WriteLn(pdf, "/Title " + PrepareString(FTitle, FEncKey, FEncrypted, FInfoNumber));
            WriteLn(pdf, "/Author " + PrepareString(FAuthor, FEncKey, FEncrypted, FInfoNumber));
            WriteLn(pdf, "/Subject " + PrepareString(FSubject, FEncKey, FEncrypted, FInfoNumber));
            WriteLn(pdf, "/Keywords " + PrepareString(FKeywords, FEncKey, FEncrypted, FInfoNumber));
            WriteLn(pdf, "/Creator " + PrepareString(FCreator, FEncKey, FEncrypted, FInfoNumber));
            WriteLn(pdf, "/Producer " + PrepareString(FProducer, FEncKey, FEncrypted, FInfoNumber));
            string s = "D:" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (FEncrypted)
            {
                WriteLn(pdf, "/CreationDate " + PrepareString(s, FEncKey, FEncrypted, FInfoNumber));
                WriteLn(pdf, "/ModDate " + PrepareString(s, FEncKey, FEncrypted, FInfoNumber));
            }
            else
            {
                WriteLn(pdf, "/CreationDate (" + s + ")");
                WriteLn(pdf, "/ModDate (" + s + ")");
            }
            WriteLn(pdf, ">>");
            WriteLn(pdf, "endobj");
            FRootNumber = UpdateXRef();
            WriteLn(pdf, ObjNumber(FRootNumber));
            WriteLn(pdf, "<<");
            WriteLn(pdf, "/Type /Catalog");
            WriteLn(pdf, "/Pages " + ObjNumberRef(FPagesNumber));
            Write(pdf, "/PageMode ");
            if (FOutline)
            {
                WriteLn(pdf, "/UseOutlines");
                WriteLn(pdf, "/Outlines " + ObjNumberRef(FOutlineNumber));
            }
            else
                WriteLn(pdf, "/UseNone");
            WriteLn(pdf, "/ViewerPreferences <<");

            if (FDisplayDocTitle && !String.IsNullOrEmpty(FTitle))
                WriteLn(pdf, "/DisplayDocTitle true");
            if (FHideToolbar)
                WriteLn(pdf, "/HideToolbar true");
            if (FHideMenubar)
                WriteLn(pdf, "/HideMenubar true");
            if (FHideWindowUI)
                WriteLn(pdf, "/HideWindowUI true");
            if (FFitWindow)
                WriteLn(pdf, "/FitWindow true");
            if (FCenterWindow)
                WriteLn(pdf, "/CenterWindow true");
            if (!FPrintScaling)
                WriteLn(pdf, "/PrintScaling /None");

            WriteLn(pdf, ">>");
            WriteLn(pdf, ">>");
            WriteLn(pdf, "endobj");            
            FStartXRef = pdf.Position;
            WriteLn(pdf, "xref");
            WriteLn(pdf, "0 " + (FXRef.Count + 1).ToString());
            WriteLn(pdf, "0000000000 65535 f");
            foreach (long xref in FXRef)
                WriteLn(pdf, PrepXRefPos(xref) + " 00000 n");
            WriteLn(pdf, "trailer");
            WriteLn(pdf, "<<");
            WriteLn(pdf, "/Size " + (FXRef.Count + 1).ToString());
            WriteLn(pdf, "/Root " + ObjNumberRef(FRootNumber));
            WriteLn(pdf, "/Info " + ObjNumberRef(FInfoNumber));
            WriteLn(pdf, "/ID [<" + FFileID + "><" + FFileID + ">]");
            if (FEncrypted)
                WriteLn(pdf, GetEncryptionDescriptor());
            WriteLn(pdf, ">>");
            WriteLn(pdf, "startxref");
            WriteLn(pdf, FStartXRef.ToString());
            WriteLn(pdf, "%%EOF");
        }

        #endregion

        #region Protected Methods
        /// <inheritdoc/>
        protected override string GetFileFilter()
        {
            return new MyRes("FileFilters").Get("PdfFile");
        }

        /// <inheritdoc/>
        public override bool ShowDialog()
        {
            using (PDFExportForm form = new PDFExportForm())
            {
                form.Init(this);
                return form.ShowDialog() == DialogResult.OK;
            }
        }

        /// <inheritdoc/>
        protected override void Start()
        {
            FFileID = ExportUtils.MD5(ExportUtils.GetID());
            if (!String.IsNullOrEmpty(FOwnerPassword) || !String.IsNullOrEmpty(FUserPassword))
            {
                FEncrypted = true;
                FEmbeddingFonts = true;
                PrepareKeys();
            }
            if (FBuffered)
                pdf = new MemoryStream();
            else
                pdf = Stream;

            if (Report.PreparedPages.Outline.Xml.Count == 0)
                FOutline = false;

            AddPDFHeader();
        }

        /// <inheritdoc/>
        protected override void ExportPage(int pageNo)
        {
            using (ReportPage page = GetPage(pageNo))
                AddPage(page);
        }

        /// <inheritdoc/>
        protected override void Finish()
        {
            AddPDFFooter();
            foreach (ExportTTFFont fnt in FFonts)
                fnt.Dispose();
            if (FBuffered)
                ((MemoryStream)pdf).WriteTo(Stream);            
        }
        #endregion

        /// <inheritdoc/>
        public override void Serialize(FRWriter writer)
        {
          base.Serialize(writer);
          writer.WriteBool("Compressed", Compressed);
          writer.WriteBool("Background", Background);
          writer.WriteBool("EmbeddingFonts", EmbeddingFonts);
          writer.WriteBool("PrintOptimized", PrintOptimized);

          writer.WriteStr("Title", Title);
          writer.WriteStr("Author", Author);
          writer.WriteStr("Subject", Subject);
          writer.WriteStr("Keywords", Keywords);
          writer.WriteStr("Creator", Creator);
          writer.WriteStr("Producer", Producer);

          writer.WriteBool("AllowPrint", AllowPrint);
          writer.WriteBool("AllowModify", AllowModify);
          writer.WriteBool("AllowCopy", AllowCopy);
          writer.WriteBool("AllowAnnotate", AllowAnnotate);

          writer.WriteBool("HideToolbar", HideToolbar);
          writer.WriteBool("HideMenubar", HideMenubar);
          writer.WriteBool("HideWindowUI", HideWindowUI);
          writer.WriteBool("FitWindow", FitWindow);
          writer.WriteBool("CenterWindow", CenterWindow);
          writer.WriteBool("PrintScaling", PrintScaling);
          writer.WriteBool("Outline", Outline);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PDFExport"/> class.
        /// </summary>
        public PDFExport()
        {
            FTitle = String.Empty;
            FAuthor = String.Empty;
            FSubject = String.Empty;
            FKeywords = String.Empty;
            FCreator = "FastReport";
            FProducer = "FastReport.NET";
            FOutline = true;
            FDisplayDocTitle = true;
            FHideToolbar = false;
            FHideMenubar = false;
            FHideWindowUI = false;
            FFitWindow = false;
            FCenterWindow = true;
            FPrintScaling = false;
            FUserPassword = String.Empty;
            FOwnerPassword = String.Empty;
            FAllowPrint = true;
            FAllowModify = true;
            FAllowCopy = true;
            FAllowAnnotate = true;
            FXRef = new List<long>();
            FPagesRef = new List<long>();
            FPagesHeights = new List<float>();
            FFonts = new List<ExportTTFFont>();
            FPageFonts = new List<ExportTTFFont>();
            FTrasparentStroke = new List<string>();
            FTrasparentFill = new List<string>();
            FDpiFX = 96f / DrawUtils.ScreenDpi;
            FEmbeddingFonts = false;
            FCompressed = true;
            FBuffered = false;
            FBackground = true;
            FPrintOptimized = true;
            FEncrypted = false;
            FRichTextQuality = 90;
            FJpegQuality = 90;
            FNumberFormatInfo = new NumberFormatInfo();
            FNumberFormatInfo.NumberGroupSeparator = String.Empty;
            FNumberFormatInfo.NumberDecimalSeparator = ".";
            PicturesList = new List<PDFImageObject>();
            PicResList = new List<int>();
        }
    }
}
