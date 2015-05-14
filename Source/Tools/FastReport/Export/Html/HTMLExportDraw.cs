using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace FastReport.Export.Html
{
    /// <summary>
    /// Represents the HTML export filter.
    /// </summary>
    public partial class HTMLExport : ExportBase
    {
        private void HTMLFontStyle(StringBuilder FFontDesc, Font font)
        {
            FFontDesc.Append((((font.Style & FontStyle.Bold) > 0) ? "font-weight:bold;" : String.Empty) +
                (((font.Style & FontStyle.Italic) > 0) ? "font-style:italic;" : "font-style:normal;"));
            if ((font.Style & FontStyle.Underline) > 0 && (font.Style & FontStyle.Strikeout) > 0)
                FFontDesc.Append("text-decoration:underline|line-through;");
            else if ((font.Style & FontStyle.Underline) > 0)
                FFontDesc.Append("text-decoration:underline;");
            else if ((font.Style & FontStyle.Strikeout) > 0)
                FFontDesc.Append("text-decoration:line-through;");
            FFontDesc.Append("font-family:").Append(font.Name).Append(";");
            FFontDesc.Append("font-size:").Append(Px(Math.Round(font.Size * 96 / 72)));
        }

        private void HTMLPadding(StringBuilder PaddingDesc, Padding padding)
        {
            if (padding.Left != 0)
                PaddingDesc.Append("padding-left:").Append(Px(padding.Left));
            if (padding.Right != 0)
                PaddingDesc.Append("padding-right:").Append(Px(padding.Right));
            if (padding.Top != 0)
                PaddingDesc.Append("padding-top:").Append(Px(padding.Top));
            if (padding.Bottom != 0)
                PaddingDesc.Append("padding-bottom:").Append(Px(padding.Bottom));
        }

        private string HTMLBorderStyle(BorderLine line)
        {
            switch (line.Style)
            {
                case LineStyle.Dash:
                case LineStyle.DashDot:
                case LineStyle.DashDotDot:
                    return "dashed";
                case LineStyle.Dot:
                    return "dotted";
                case LineStyle.Double:
                    return "double";
                default:
                    return "solid";
            }
        }

        private float HTMLBorderWidth(BorderLine line)
        {
            if (line.Style == LineStyle.Double)
                return (line.Width * 3 * Zoom);
            else
                return line.Width * Zoom;
        }

        private void HTMLBorder(StringBuilder BorderDesc, Border border)
        {
            if (border.Lines > 0)
            {
                // bottom
                if ((border.Lines & BorderLines.Bottom) > 0)
                    BorderDesc.Append("border-bottom-width:").
                        Append(Px(HTMLBorderWidth(border.BottomLine))).
                        Append("border-bottom-color:").
                        Append(ExportUtils.HTMLColor(border.BottomLine.Color)).Append(";").
                        Append("border-bottom-style:").Append(HTMLBorderStyle(border.BottomLine)).Append(";");
                else
                    BorderDesc.Append("border-bottom-width:0;");
                // top
                if ((border.Lines & BorderLines.Top) > 0)
                    BorderDesc.Append("border-top-width:").
                        Append(Px(HTMLBorderWidth(border.TopLine))).
                        Append("border-top-color:").
                        Append(ExportUtils.HTMLColor(border.TopLine.Color)).Append(";").
                        Append("border-top-style:").Append(HTMLBorderStyle(border.TopLine)).Append(";");
                else
                    BorderDesc.Append("border-top-width:0;");
                // left
                if ((border.Lines & BorderLines.Left) > 0)
                    BorderDesc.Append("border-left-width:").
                        Append(Px(HTMLBorderWidth(border.LeftLine))).
                        Append("border-left-color:").
                        Append(ExportUtils.HTMLColor(border.LeftLine.Color)).Append(";").
                        Append("border-left-style:").Append(HTMLBorderStyle(border.LeftLine)).Append(";");
                else
                    BorderDesc.Append("border-left-width:0;");
                // right
                if ((border.Lines & BorderLines.Right) > 0)
                    BorderDesc.Append("border-right-width:").
                        Append(Px(HTMLBorderWidth(border.RightLine))).
                        Append("border-right-color:").
                        Append(ExportUtils.HTMLColor(border.RightLine.Color)).Append(";").
                        Append(" border-right-style:").Append(HTMLBorderStyle(border.RightLine)).Append(";");
                else
                    BorderDesc.Append("border-right-width:0;");
            }
        }

        private void HTMLAlign(StringBuilder sb, HorzAlign horzAlign, VertAlign vertAlign, bool wordWrap)
        {
            sb.Append("text-align:");
            if (horzAlign == HorzAlign.Left)
                sb.Append("Left");
            else if (horzAlign == HorzAlign.Right)
                sb.Append("Right");
            else if (horzAlign == HorzAlign.Center)
                sb.Append("Center");
            else if (horzAlign == HorzAlign.Justify)
                sb.Append("Justify");
            sb.Append(";vertical-align:");
            if (vertAlign == VertAlign.Top)
                sb.Append("Top");
            else if (vertAlign == VertAlign.Bottom)
                sb.Append("Bottom");
            else if (vertAlign == VertAlign.Center)
                sb.Append("Middle");
            if (wordWrap)
                sb.Append(";word-wrap:break-word");
            sb.Append(";overflow:hidden;");
        }

        private void HTMLRtl(StringBuilder sb, bool rtl)
        {
            if (rtl)
                sb.Append("direction:rtl;");
        }

        private string HTMLGetStylesHeader(int PageNumber)
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine("<style type=\"text/css\"><!-- ");
            if (FSinglePage && PageNumber == 1 && FPageBreaks)
                header.AppendLine(".page_break { page-break-before:always; }");
            return header.ToString();
        }

        private string HTMLGetStyleHeader(long index)
        {
            StringBuilder header = new StringBuilder();
            return header.Append(".").Append(FStylePrefix).Append("s").Append(index.ToString()).Append(" { ").ToString();
        }

        private void HTMLGetStyle(StringBuilder style, Font Font, Color TextColor, Color FillColor, HorzAlign HAlign, VertAlign VAlign,
            Border Border, System.Windows.Forms.Padding Padding, bool RTL, bool wordWrap)
        {
            HTMLFontStyle(style, Font);
            style.Append("color:").Append(ExportUtils.HTMLColor(TextColor)).Append(";");
            style.Append("background-color:");
            style.Append(FillColor == Color.Transparent ? "transparent" : ExportUtils.HTMLColor(FillColor)).Append(";");
            HTMLAlign(style, HAlign, VAlign, wordWrap);
            HTMLBorder(style, Border);
            HTMLPadding(style, Padding);
            HTMLRtl(style, RTL);
            style.AppendLine("}");
        }

        private string HTMLGetStylesFooter()
        {
            return "--></style>";
        }

        private string HTMLGetAncor(string ancorName)
        {
            StringBuilder ancor = new StringBuilder();
            return ancor.Append("<a name=\"PageN").Append(ancorName).Append("\"></a>").ToString();
        }

        private string HTMLGetImageTag(string file)
        {
            return "<img src=\"" + file + "\" alt=\"\"/>";
        }

        private string HTMLGetImage(int PageNumber, int CurrentPage, int ImageNumber, string hash, bool Base,
            System.Drawing.Image Metafile, MemoryStream PictureStream)
        {
            if (FPictures)
            {
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Bmp;
                if (FImageFormat == ImageFormat.Png)
                    format = System.Drawing.Imaging.ImageFormat.Png;
                else if (FImageFormat == ImageFormat.Jpeg)
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                else if (FImageFormat == ImageFormat.Gif)
                    format = System.Drawing.Imaging.ImageFormat.Gif;
                StringBuilder ImageFileNameBuilder = new StringBuilder(48);
                string ImageFileName = ImageFileNameBuilder.Append(Path.GetFileName(FTargetFileName)).
                    Append(".").Append(hash).
                    Append(".").Append(format.ToString().ToLower()).ToString();

                if (!FWebMode && !FPrint)
                {
                    if (Base)
                    {
                        if (Metafile != null)
                        {
                            if (FSaveStreams)
                            {
                                MemoryStream ImageFileStream = new MemoryStream();
                                Metafile.Save(ImageFileStream, format);
                                GeneratedUpdate(FTargetPath + ImageFileName, ImageFileStream);
                            }
                            else
                            {
                                using (FileStream ImageFileStream =
                                    new FileStream(FTargetPath + ImageFileName, FileMode.Create))
                                    Metafile.Save(ImageFileStream, format);
                            }
                        }
                        else if (PictureStream != null)
                        {
                            if (FFormat == HTMLExportFormat.HTML)
                            {
                                string fileName = FTargetPath + ImageFileName;
                                FileInfo info = new FileInfo(fileName);
                                if (!(info.Exists && info.Length == PictureStream.Length))
                                {
                                    if (FSaveStreams)
                                    {
                                        GeneratedUpdate(FTargetPath + ImageFileName, PictureStream);
                                    }
                                    else
                                    {
                                        using (FileStream ImageFileStream =
                                        new FileStream(fileName, FileMode.Create))
                                            PictureStream.WriteTo(ImageFileStream);
                                    }
                                }
                            }
                            else
                            {
                                PicsArchiveItem item;
                                item.FileName = ImageFileName;
                                item.Stream = PictureStream;
                                bool founded = false;
                                for (int i = 0; i < FPicsArchive.Count; i++)
                                    if (item.FileName == FPicsArchive[i].FileName)
                                    {
                                        founded = true;
                                        break;
                                    }
                                if (!founded)
                                    FPicsArchive.Add(item);
                            }
                        }
                        if (!FSaveStreams)
                            GeneratedFiles.Add(FTargetPath + ImageFileName);
                    }
                    if (FSubFolder && FSinglePage && !FNavigator)
                        return ExportUtils.HtmlURL(FSubFolderPath + ImageFileName);
                    else
                        return ExportUtils.HtmlURL(ImageFileName);
                }
                else
                {
                    if (FPrint)
                    {
                        FPrintPageData.Pictures.Add(PictureStream);
                        FPrintPageData.Guids.Add(hash);
                    }
                    else if (Base)
                    {
                        FPages[CurrentPage].Pictures.Add(PictureStream);
                        FPages[CurrentPage].Guids.Add(hash);
                    }
                    return FWebImagePrefix + "=" + hash + FWebImageSuffix;
                }
            }
            else
                return String.Empty;
        }
    }
}
