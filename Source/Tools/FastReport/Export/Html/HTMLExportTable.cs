﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FastReport.Utils;
using System.IO;

namespace FastReport.Export.Html
{
    /// <summary>
    /// Represents the HTML export filter.
    /// </summary>
    public partial class HTMLExport : ExportBase
    {

        private void ExportPageStyles(StringBuilder styles, ExportMatrix FMatrix, int PageNumber)
        {
            if (FMatrix.StylesCount - FPrevStyleListIndex > 0)
            {
                styles.Append(HTMLGetStylesHeader(PageNumber));
                for (int i = FPrevStyleListIndex; i < FMatrix.StylesCount; i++)
                {
                    ExportIEMStyle EStyle = FMatrix.StyleById(i);
                    styles.Append(HTMLGetStyleHeader(i));
                    HTMLGetStyle(styles, EStyle.Font, EStyle.TextColor, EStyle.FillColor, EStyle.HAlign, EStyle.VAlign, EStyle.Border, EStyle.Padding, EStyle.RTL, EStyle.WordWrap);
                }
                styles.AppendLine(HTMLGetStylesFooter());
            }
        }

        private string HTMLSaveImage(ExportIEMObject obj, int PageNumber, int CurrentPage, int ImageNumber)
        {
            if (FPictures)
            {
                return HTMLGetImageTag(HTMLGetImage(PageNumber, CurrentPage, ImageNumber, obj.Hash, obj.Base, obj.Metafile, obj.PictureStream));
            }
            else
                return String.Empty;
        }

        private void SetUpMatrix(ExportMatrix FMatrix)
        {
            if (FSinglePage && FPrevStyleList != null)
                FMatrix.Styles = FPrevStyleList;
            if (FWysiwyg)
                FMatrix.Inaccuracy = 0.5f;
            else
                FMatrix.Inaccuracy = 10;

            if (FWebMode)
            {
                FSinglePage = false;
                FNavigator = false;
            }
            FMatrix.Watermarks = true;
            FMatrix.HTMLMode = true;
            FMatrix.FillAsBitmap = true;
            FMatrix.Zoom = Zoom;
            FMatrix.RotatedAsImage = true;
            FMatrix.PlainRich = true;
            FMatrix.CropAreaFill = false;
            FMatrix.AreaFill = true;
            FMatrix.Report = Report;
            FMatrix.FramesOptimization = true;
            FMatrix.ShowProgress = false;
            FMatrix.Threaded = FThreaded;
            FMatrix.FullTrust = false;
        }

        private void GetColumnSizes(StringBuilder Page, ExportMatrix FMatrix)
        {
            Page.Append("<tr style=\"height: 1px\">");
            for (int x = 0; x < FMatrix.Width - 1; x++)
                Page.Append("<td width=\"").
                    Append(SizeValue(Math.Round(FMatrix.XPosById(x + 1) - FMatrix.XPosById(x)), FMatrix.MaxWidth, FWidthUnits)).
                    Append("\"/>");
            if (FMatrix.Width < 2)
                Page.Append("<td/>");
            Page.AppendLine("</tr>");            
        }

        private int GetTableHeader(StringBuilder Page, ExportMatrix FMatrix, int PageNumber, int CurrentPage, int ImagesCount)
        {
            Page.Append("<table width=\"").
                Append(SizeValue(Math.Round(FMatrix.MaxWidth), Math.Round(FMatrix.MaxWidth), FWidthUnits)).
                Append("\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"table-layout: fixed;");
                //Append("\" align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"table-layout: fixed;");
            // add watermark
            if (FMatrix.Pages[0].WatermarkPictureStream != null)
            {
                string wName;
                if (FPrevWatermarkSize != FMatrix.Pages[0].WatermarkPictureStream.Length)
                {
                    ExportIEMObject watermark = new ExportIEMObject();
                    watermark.Width = (FMatrix.Pages[0].Width - FMatrix.Pages[0].LeftMargin - FMatrix.Pages[0].RightMargin) * Units.Millimeters;
                    watermark.Height = (FMatrix.Pages[0].Height - FMatrix.Pages[0].TopMargin - FMatrix.Pages[0].BottomMargin) * Units.Millimeters;
                    watermark.PictureStream = FMatrix.Pages[0].WatermarkPictureStream;
                    FPrevWatermarkSize = FMatrix.Pages[0].WatermarkPictureStream.Length;
                    FMatrix.CheckPicsCache(watermark);
                    FPrevWatermarkName = HTMLGetImage(PageNumber, CurrentPage, ImagesCount++, watermark.Hash, watermark.Base, watermark.Metafile, watermark.PictureStream);
                }
                wName = FPrevWatermarkName;
                Page.Append(" background: url(").Append(wName).Append(") no-repeat;");
            }

            if (FSinglePage && PageNumber > 1 && FPageBreaks)
                Page.Append("\" class=\"page_break");

            Page.AppendLine("\" >");

            return ImagesCount;
        }

        private int GetTable(StringBuilder Page, ExportMatrix FMatrix, int PageNumber, int CurrentPage, int ImagesCount)
        {
            for (int y = 0; y < FMatrix.Height - 1; y++)
            {
                int drow = (int)Math.Round((FMatrix.YPosById(y + 1) - FMatrix.YPosById(y)));
                if (drow == 0)
                    drow = 1;
                Page.Append("<tr style=\"height:").Append(SizeValue(drow, FMatrix.MaxHeight, FHeightUnits)).AppendLine("\">");
                for (int x = 0; x < FMatrix.Width - 1; x++)
                {
                    int i = FMatrix.Cell(x, y);
                    if (i != -1)
                    {
                        ExportIEMObject obj = FMatrix.ObjectById(i);
                        if (obj.Counter == 0)
                        {
                            int fx, fy, dx, dy;
                            FMatrix.ObjectPos(i, out fx, out fy, out dx, out dy);
                            obj.Counter = 1;
                            Page.Append("<td").
                                Append((dx > 1 ? " colspan=\"" + dx.ToString() + "\"" : String.Empty)).
                                Append((dy > 1 ? " rowspan=\"" + dy.ToString() + "\"" : String.Empty)).
                                Append(" class=\"").Append(FStylePrefix).Append("s").Append(obj.StyleIndex.ToString()).
                                Append("\"");
                            StringBuilder style = new StringBuilder(256);
                            if (obj.Text.Length == 0)
                                style.Append("font-size:1px;");
                            if (obj.PictureStream != null && obj.IsText)
                                style.Append("background-image: url(").
                                    Append(HTMLGetImage(PageNumber, CurrentPage, ImagesCount++, obj.Hash, obj.Base, obj.Metafile, obj.PictureStream)).
                                    Append(");");
                            if (style.Length > 0)
                                Page.Append(" style=\"").Append(style).Append("\"");
                            if (!obj.Style.WordWrap)
                                Page.Append(" nowrap ");
                            Page.Append(">");

                            // TEXT
                            if (obj.IsText)
                              if (obj.Text.Length > 0)
                              {
                                if (!String.IsNullOrEmpty(obj.URL))
                                  Page.Append("<a href=\"" + obj.URL + "\">");
                                Page.Append(ExportUtils.HtmlString(obj.Text, obj.HtmlTags));
                                if (!String.IsNullOrEmpty(obj.URL))
                                  Page.Append("</a>");
                              }
                              else
                                Page.Append(NBSP);
                            else
                                Page.Append(HTMLSaveImage(obj, PageNumber, CurrentPage, ImagesCount++));

                            Page.AppendLine("</td>");
                        }
                    }
                    else
                        Page.AppendLine("</td>");
                }
                Page.AppendLine("</tr>");
            }
            return ImagesCount;
        }

        private void GetTableFooter(StringBuilder Page)
        {
            Page.AppendLine("</table>");
        }

        private void ExportHTMLPageTabled(HTMLThreadData d)
        {
            int ImagesCount = 0;

            using (ReportPage page = GetPage(d.ReportPage))
            {
                ExportMatrix FMatrix = new ExportMatrix();

                SetUpMatrix(FMatrix);
                FMatrix.AddPage(page);
                FMatrix.Prepare();

                #region Styles

                StringBuilder Page = new StringBuilder(4096);
                
                ExportPageStyles(Page, FMatrix, d.PageNumber);

                if (FSinglePage)
                {
                    FPrevStyleListIndex = FMatrix.StylesCount;
                    FPrevStyleList = FMatrix.Styles;
                }

                #endregion

                Page = ExportHTMLPageStart(Page, d.PageNumber, d.CurrentPage);

                #region page table
               
                // Ancor
                Page.Append(HTMLGetAncor(d.PageNumber.ToString()));

                // Table header
                ImagesCount = GetTableHeader(Page, FMatrix, d.PageNumber, d.CurrentPage, ImagesCount);

                // Column sizes
                GetColumnSizes(Page, FMatrix);

                // Table
                ImagesCount = GetTable(Page, FMatrix, d.PageNumber, d.CurrentPage, ImagesCount);

                // Table footer
                GetTableFooter(Page);

                #endregion

                ExportHTMLPageFinal(null, Page, d, FMatrix.MaxWidth, FMatrix.MaxHeight);
            }
        }

    }
}
