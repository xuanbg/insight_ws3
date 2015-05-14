using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FastReport.Export.TTF;

namespace FastReport.Export.Pdf
{
    /// <summary>
    /// PDF export (Adobe Acrobat)
    /// </summary>
    public partial class PDFExport : ExportBase
    {
        const float KAPPA1 = 1.5522847498f;
        const float KAPPA2 = 2 - KAPPA1;

        private string DrawPDFUnderline(int fontNumber, Font font, float x, float y, float width, float offsX, Color color, bool transformNeeded)
        {
            ExportTTFFont pdfFont = FPageFonts[fontNumber];
            x = (transformNeeded ? x * PDF_DIVIDER : GetLeft(x)) + offsX;
            y = transformNeeded ? -y * PDF_DIVIDER : GetTop(y);
            float factor = PDF_TTF_DIVIDER * font.Size * FDpiFX * PDF_DIVIDER;
            float uh = GetBaseline(font) * PDF_DIVIDER - pdfFont.TextMetric.otmsUnderscorePosition * factor;
            return DrawPDFLine(x, y - uh, x + width * PDF_DIVIDER, y - uh, color, pdfFont.TextMetric.otmsUnderscoreSize * factor, LineStyle.Solid, null, null);
        }

        private string DrawPDFStrikeout(int fontNumber, Font font, float x, float y, float width, float offsX, Color color, bool transformNeeded)
        {
            ExportTTFFont pdfFont = FPageFonts[fontNumber];
            x = (transformNeeded ? x * PDF_DIVIDER : GetLeft(x)) + offsX;
            y = transformNeeded ? -y * PDF_DIVIDER : GetTop(y);
            float factor = PDF_TTF_DIVIDER * font.Size * FDpiFX * PDF_DIVIDER;
            float uh = GetBaseline(font) * PDF_DIVIDER - pdfFont.TextMetric.otmsStrikeoutPosition * factor;
            return DrawPDFLine(x, y - uh, x + width * PDF_DIVIDER, y - uh, color, pdfFont.TextMetric.otmsStrikeoutSize * factor, LineStyle.Solid, null, null);
        }

        private string DrawPDFRect(float left, float top, float right, float bottom, Color color, float borderWidth, LineStyle lineStyle)
        {
            StringBuilder result = new StringBuilder(64);
            result.Append(GetPDFStrokeColor(color));
            result.Append(FloatToString(borderWidth * PDF_DIVIDER)).AppendLine(" w").AppendLine("2 J");
            result.AppendLine(DrawPDFDash(lineStyle, borderWidth));
            result.Append(FloatToString(left)).Append(" ").
                AppendLine(FloatToString(top)).
                Append(FloatToString(right - left)).Append(" ").
                Append(FloatToString(bottom - top)).AppendLine(" re").AppendLine("S");
            return result.ToString();
        }

        private string DrawPDFFillRect(float Left, float Top, float Width, float Height, FillBase fill)
        {
            StringBuilder Result = new StringBuilder(128);
            if (fill is SolidFill && (fill as SolidFill).Color != Color.Transparent)
            {
                Result.Append(GetPDFFillColor((fill as SolidFill).Color));
                Result.Append(FloatToString(Left)).Append(" ").
                    Append(FloatToString(Top - Height)).Append(" ").
                    Append(FloatToString(Width)).Append(" ").
                    Append(FloatToString(Height)).AppendLine(" re");
                Result.AppendLine("f");
            }
            else if (fill is GlassFill)
            {
                Result.Append(GetPDFFillColor((fill as GlassFill).Color));
                Result.Append(FloatToString(Left)).Append(" ").
                    Append(FloatToString(Top - Height)).Append(" ").
                    Append(FloatToString(Width)).Append(" ").
                    Append(FloatToString(Height / 2)).AppendLine(" re");
                Result.AppendLine("f");
                Color c = (fill as GlassFill).Color;
                c = Color.FromArgb(255, (int)Math.Round(c.R + (255 - c.R) * (fill as GlassFill).Blend),
                    (int)Math.Round(c.G + (255 - c.G) * (fill as GlassFill).Blend),
                    (int)Math.Round(c.B + (255 - c.B) * (fill as GlassFill).Blend));
                Result.Append(GetPDFFillColor(c));
                Result.Append(FloatToString(Left)).Append(" ").
                    Append(FloatToString(Top - Height / 2)).Append(" ").
                    Append(FloatToString(Width)).Append(" ").
                    Append(FloatToString(Height / 2)).AppendLine(" re");
                Result.AppendLine("f");
            }
            return Result.ToString();
        }

        private string DrawPDFTriangle(float left, float top, float width, float height, Color fillColor, Color borderColor, float borderWidth, LineStyle lineStyle)
        {
            StringBuilder Result = new StringBuilder(128);
            if (fillColor != Color.Transparent)
                Result.Append(GetPDFFillColor(fillColor));
            if (borderColor != Color.Transparent)
                Result.Append(GetPDFStrokeColor(borderColor));
            Result.Append(FloatToString(borderWidth * PDF_DIVIDER)).AppendLine(" w").AppendLine("1 J");
            Result.AppendLine(DrawPDFDash(lineStyle, borderWidth));
            Result.Append(FloatToString(left + width / 2)).Append(" ").Append(FloatToString(top)).Append(" m ").
                Append(FloatToString(left + width)).Append(" ").Append(FloatToString(top - height)).Append(" l ").
                Append(FloatToString(left)).Append(" ").Append(FloatToString(top - height)).Append(" l ").
                Append(FloatToString(left + width / 2)).Append(" ").Append(FloatToString(top)).AppendLine(" l");
            if (fillColor == Color.Transparent)
                Result.AppendLine("S");
            else
                Result.AppendLine("B");
            return Result.ToString();
        }

        private string DrawPDFDiamond(float left, float top, float width, float height, Color fillColor, Color borderColor, float borderWidth, LineStyle lineStyle)
        {
            StringBuilder Result = new StringBuilder(128);
            if (fillColor != Color.Transparent)
                Result.Append(GetPDFFillColor(fillColor));
            if (borderColor != Color.Transparent)
                Result.Append(GetPDFStrokeColor(borderColor));
            Result.Append(FloatToString(borderWidth * PDF_DIVIDER)).AppendLine(" w").AppendLine("1 J");
            Result.AppendLine(DrawPDFDash(lineStyle, borderWidth));
            Result.Append(FloatToString(left + width / 2)).Append(" ").Append(FloatToString(top)).Append(" m ").
                Append(FloatToString(left + width)).Append(" ").Append(FloatToString(top - height / 2)).Append(" l ").
                Append(FloatToString(left + width / 2)).Append(" ").Append(FloatToString(top - height)).Append(" l ").
                Append(FloatToString(left)).Append(" ").Append(FloatToString(top - height / 2)).Append(" l ").
                Append(FloatToString(left + width / 2)).Append(" ").Append(FloatToString(top)).AppendLine(" l");
            if (fillColor == Color.Transparent)
                Result.AppendLine("S");
            else
                Result.AppendLine("B");
            return Result.ToString();
        }

        private string DrawPDFEllipse(float left, float top, float width, float height, Color fillColor, Color borderColor, float borderWidth, LineStyle lineStyle)
        {
            StringBuilder Result = new StringBuilder(128);
            if (fillColor != Color.Transparent)
                Result.Append(GetPDFFillColor(fillColor));
            if (borderColor != Color.Transparent)
                Result.Append(GetPDFStrokeColor(borderColor));
            Result.Append(FloatToString(borderWidth * PDF_DIVIDER)).AppendLine(" w");
            Result.AppendLine(DrawPDFDash(lineStyle, borderWidth));
            float rx = width / 2;
            float ry = height / 2;
            Result.Append(FloatToString(left + width)).Append(" ").Append(FloatToString(top - ry)).AppendLine(" m");
            Result.Append(FloatToString(left + width)).Append(" ").Append(FloatToString(top - ry * KAPPA1)).Append(" ").
                Append(FloatToString(left + rx * KAPPA1)).Append(" ").Append(FloatToString(top - height)).Append(" ").
                Append(FloatToString(left + rx)).Append(" ").Append(FloatToString(top - height)).AppendLine(" c");
            Result.Append(FloatToString(left + rx * KAPPA2)).Append(" ").Append(FloatToString(top - height)).Append(" ").
                Append(FloatToString(left)).Append(" ").Append(FloatToString(top - ry * KAPPA1)).Append(" ").
                Append(FloatToString(left)).Append(" ").Append(FloatToString(top - ry)).AppendLine(" c");
            Result.Append(FloatToString(left)).Append(" ").Append(FloatToString(top - ry * KAPPA2)).Append(" ").
                Append(FloatToString(left + rx * KAPPA2)).Append(" ").Append(FloatToString(top)).Append(" ").
                Append(FloatToString(left + rx)).Append(" ").Append(FloatToString(top)).AppendLine(" c");
            Result.Append(FloatToString(left + rx * KAPPA1)).Append(" ").Append(FloatToString(top)).Append(" ").
                Append(FloatToString(left + width)).Append(" ").Append(FloatToString(top - ry * KAPPA2)).Append(" ").
                Append(FloatToString(left + width)).Append(" ").Append(FloatToString(top - ry)).AppendLine(" c");
            if (fillColor == Color.Transparent)
                Result.AppendLine("S");
            else
                Result.AppendLine("B");
            return Result.ToString();
        }

        private string DrawPDFLine(float left, float top, float right, float bottom, Color color, float width,
            LineStyle lineStyle, CapSettings startCap, CapSettings endCap)
        {
            if (width == 0.0f && (lineStyle == LineStyle.Dash || lineStyle == LineStyle.Dot))
            {
                return "";
            }
            else
            {
                StringBuilder Result = new StringBuilder(64);
                Result.Append(GetPDFStrokeColor(color));
                Result.Append(FloatToString(width)).AppendLine(" w").AppendLine("2 J");
                Result.AppendLine(DrawPDFDash(lineStyle, width));
                Result.Append(FloatToString(left)).Append(" ").
                    Append(FloatToString(top)).AppendLine(" m").
                    Append(FloatToString(right)).Append(" ").
                    Append(FloatToString(bottom)).AppendLine(" l").
                    AppendLine("S");
                if (startCap != null && startCap.Style == CapStyle.Arrow)
                    Result.Append(DrawArrow(startCap, width, right, bottom, left, top));
                if (endCap != null && endCap.Style == CapStyle.Arrow)
                    Result.Append(DrawArrow(endCap, width, left, top, right, bottom));
                return Result.ToString();
            }
        }

        private string DrawArrow(CapSettings Arrow, float lineWidth, float x1, float y1, float x2, float y2)
        {
            float k1, a, b, c, d;
            float xp, yp, x3, y3, x4, y4;
            float wd = Arrow.Width * lineWidth * PDF_DIVIDER;
            float ld = Arrow.Height * lineWidth * PDF_DIVIDER;
            if (Math.Abs(x2 - x1) > 0)
            {
                k1 = (y2 - y1) / (x2 - x1);
                a = (float)Math.Pow(k1, 2) + 1;
                b = 2 * (k1 * ((x2 * y1 - x1 * y2) / (x2 - x1) - y2) - x2);
                c = (float)Math.Pow(x2, 2) + (float)Math.Pow(y2, 2) - (float)Math.Pow(ld, 2) +
                    (float)Math.Pow((x2 * y1 - x1 * y2) / (x2 - x1), 2) -
                    2 * y2 * (x2 * y1 - x1 * y2) / (x2 - x1);
                d = (float)Math.Pow(b, 2) - 4 * a * c;
                xp = (-b + (float)Math.Sqrt(d)) / (2 * a);
                if ((xp > x1) && (xp > x2) || (xp < x1) && (xp < x2))
                    xp = (-b - (float)Math.Sqrt(d)) / (2 * a);
                yp = xp * k1 + (x2 * y1 - x1 * y2) / (x2 - x1);
                if (y2 != y1)
                {
                    x3 = xp + wd * (float)Math.Sin(Math.Atan(k1));
                    y3 = yp - wd * (float)Math.Cos(Math.Atan(k1));
                    x4 = xp - wd * (float)Math.Sin(Math.Atan(k1));
                    y4 = yp + wd * (float)Math.Cos(Math.Atan(k1));
                }
                else
                {
                    x3 = xp; y3 = yp - wd;
                    x4 = xp; y4 = yp + wd;
                }
            }
            else
            {
                xp = x2; yp = y2 - ld;
                if ((yp > y1) && (yp > y2) || (yp < y1) && (yp < y2))
                    yp = y2 + ld;
                x3 = xp - wd; y3 = yp;
                x4 = xp + wd; y4 = yp;
            }
            StringBuilder result = new StringBuilder(64);
            result.AppendLine("2 J").AppendLine("[] 0 d").Append(FloatToString(x3)).Append(" ").Append(FloatToString(y3)).AppendLine(" m").
                Append(FloatToString(x2)).Append(" ").Append(FloatToString(y2)).AppendLine(" l").
                Append(FloatToString(x4)).Append(" ").Append(FloatToString(y4)).AppendLine(" l").AppendLine("S");
            return result.ToString();
        }

        private string DrawPDFDash(LineStyle lineStyle, float lineWidth)
        {
            if (lineStyle == LineStyle.Solid)
                return "[] 0 d";
            else
            {
                string dash = FloatToString(lineWidth * 2.0f) + " ";
                string dot = FloatToString(lineWidth * 0.05f) + " ";
                StringBuilder result = new StringBuilder(64);
                if (lineStyle == LineStyle.Dash)
                    result.Append("[").Append(dash).Append("] 0 d");
                else if (lineStyle == LineStyle.DashDot)
                    result.Append("[").Append(dash).Append(dash).Append(dot).Append(dash).Append("] 0 d");
                else if (lineStyle == LineStyle.DashDotDot)
                    result.Append("[").Append(dash).Append(dash).Append(dot).Append(dash).Append(dot).Append(dash).Append("] 0 d");
                else if (lineStyle == LineStyle.Dot)
                    result.Append("[").Append(dot).Append(dash).Append("] 0 d");
                else
                    result.Append("[] 0 d");
                return result.ToString();
            }
        }

        private string DrawPDFBorder(Border Border, float left, float top, float width, float height)
        {
            StringBuilder Result = new StringBuilder(256);
            if (Border.Shadow)
            {
                Result.Append(DrawPDFFillRect(GetLeft(left + width),
                    GetTop(top + Border.ShadowWidth),
                    Border.ShadowWidth * PDF_DIVIDER,
                    height * PDF_DIVIDER,
                    new SolidFill(Border.ShadowColor)));
                Result.Append(DrawPDFFillRect(GetLeft(left + Border.ShadowWidth),
                    GetTop(top + height),
                    (width - Border.ShadowWidth) * PDF_DIVIDER,
                    Border.ShadowWidth * PDF_DIVIDER,
                    new SolidFill(Border.ShadowColor)));
            }
            if (Border.Lines != BorderLines.None)
            {
                if (Border.Lines == BorderLines.All &&
                    Border.LeftLine.Equals(Border.RightLine) &&
                    Border.TopLine.Equals(Border.BottomLine) &&
                    Border.LeftLine.Equals(Border.TopLine))

                    Result.Append(DrawPDFRect(GetLeft(left), GetTop(top),
                        GetLeft(left + width), GetTop(top + height),
                        Border.Color, Border.Width * PDF_DIVIDER,
                        Border.Style));
                else
                {
                    float Left = GetLeft(left);
                    float Top = GetTop(top);
                    float Right = GetLeft(left + width);
                    float Bottom = GetTop(top + height);
                    if ((Border.Lines & BorderLines.Left) > 0)
                        Result.Append(DrawPDFLine(Left, Top, Left, Bottom, Border.LeftLine.Color,
                            Border.LeftLine.Width * PDF_DIVIDER, Border.LeftLine.Style, null, null));
                    if ((Border.Lines & BorderLines.Right) > 0)
                        Result.Append(DrawPDFLine(Right, Top, Right, Bottom, Border.RightLine.Color,
                            Border.RightLine.Width * PDF_DIVIDER, Border.RightLine.Style, null, null));
                    if ((Border.Lines & BorderLines.Top) > 0)
                        Result.Append(DrawPDFLine(Left, Top, Right, Top, Border.TopLine.Color,
                            Border.TopLine.Width * PDF_DIVIDER, Border.TopLine.Style, null, null));
                    if ((Border.Lines & BorderLines.Bottom) > 0)
                        Result.Append(DrawPDFLine(Left, Bottom, Right, Bottom, Border.BottomLine.Color,
                            Border.BottomLine.Width * PDF_DIVIDER, Border.BottomLine.Style, null, null));
                }
            }
            return Result.ToString();
        }
    }
}
