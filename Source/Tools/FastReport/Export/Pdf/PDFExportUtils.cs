using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using FastReport.Utils;

namespace FastReport.Export.Pdf
{
    /// <summary>
    /// PDF export (Adobe Acrobat)
    /// </summary>
    public partial class PDFExport : ExportBase
    {
        private float GetTop(float p)
        {
            return FMarginWoBottom - p * PDF_DIVIDER;
        }

        private float GetLeft(float p)
        {
            return FMarginLeft + p * PDF_DIVIDER;
        }

        private string FloatToString(double value)
        {
            return Convert.ToString(Math.Round(value, 2), FNumberFormatInfo);
        }

        private string FloatToString(double value, int digits)
        {
          return Convert.ToString(Math.Round(value, digits), FNumberFormatInfo);
        }

        private string StringToPdfUnicode(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length * 2);
            sb.Append((char)254).Append((char)255);
            foreach (char c in s)
                sb.Append((char)(c >> 8)).Append((char)(c & 0xFF));
            return sb.ToString();
        }

        private string PrepareString(string text, byte[] key, bool encode, long id)
        {
            StringBuilder result = new StringBuilder(text.Length * 2 + 2);
            string s = encode ? RC4CryptString(StringToPdfUnicode(text), key, id) : StringToPdfUnicode(text);
            result.Append("(").Append(EscapeSpecialChar(s)).Append(")");
            return result.ToString();
        }

        private void Write(Stream stream, string value)
        {
            stream.Write(ExportUtils.StringToByteArray(value), 0, value.Length);
        }

        private void WriteLn(Stream stream, string value)
        {
            stream.Write(ExportUtils.StringToByteArray(value), 0, value.Length);
            stream.WriteByte(0x0d);
            stream.WriteByte(0x0a);
        }

        private string StrToUTF16(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder sb = new StringBuilder(str.Length * 4 + 4);
                sb.Append("FEFF");
                foreach (char c in str)
                    sb.Append(((int)c).ToString("X4"));
                return sb.ToString();
            }
            else
                return str;
        }

        private string EscapeSpecialChar(string input)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':
                        sb.Append(@"\(");
                        break;
                    case ')':
                        sb.Append(@"\)");
                        break;
                    case '\\':
                        sb.Append(@"\\");
                        break;
                    case '\r':
                        sb.Append(@"\r");
                        break;
                    case '\n':
                        sb.Append(@"\n");
                        break;
                    default:
                        sb.Append(input[i]);
                        break;
                }
            }
            return sb.ToString();
        }

        private float GetBaseline(Font f)
        {
            float baselineOffset = f.SizeInPoints / f.FontFamily.GetEmHeight(f.Style) * f.FontFamily.GetCellAscent(f.Style);
            return DrawUtils.ScreenDpi / 72f * baselineOffset;
        }

        private string GetPDFFillColor(Color color)
        {
            StringBuilder result = new StringBuilder();
            result.Append(GetPDFFillTransparent(color));
            result.Append(GetPDFColor(color)).AppendLine(" rg");
            return result.ToString();
        }

        private string GetPDFFillTransparent(Color color)
        {
            StringBuilder result = new StringBuilder();
            string value = FloatToString((float)color.A / 255f);
            int i = FTrasparentStroke.IndexOf(value);
            if (i == -1)
            {
                FTrasparentStroke.Add(value);
                i = FTrasparentStroke.Count - 1;
            }
            result.Append("/GS").Append(i.ToString()).AppendLine("S gs");
            return result.ToString();
        }

        private string GetPDFStrokeColor(Color color)
        {
            StringBuilder result = new StringBuilder();
            result.Append(GetPDFStrokeTransparent(color));
            result.Append(GetPDFColor(color)).AppendLine(" RG");
            return result.ToString();
        }

        private string GetPDFStrokeTransparent(Color color)
        {
            StringBuilder result = new StringBuilder();
            string value = FloatToString((float)color.A / 255f);
            int i = FTrasparentFill.IndexOf(value);
            if (i == -1)
            {
                FTrasparentFill.Add(value);
                i = FTrasparentFill.Count - 1;
            }
            result.Append("/GS").Append(i.ToString()).AppendLine("F gs");
            return result.ToString();
        }

        private string GetPDFColor(Color color)
        {
            if (color == Color.Black)
                return "0 0 0";
            else if (color == Color.White)
                return "1 1 1";
            else
            {
                StringBuilder sb = new StringBuilder(32);
                sb.Append(FloatToString((float)color.R / 255f, 3)).Append(" ");
                sb.Append(FloatToString((float)color.G / 255f, 3)).Append(" ");
                sb.Append(FloatToString((float)color.B / 255f, 3));
                return sb.ToString();
            }
        }

        private bool FontEquals(Font font1, Font font2)
        {
            return (font1.Name == font2.Name) && font1.Style.Equals(font2.Style);
        }

        private string PrepXRefPos(long p)
        {
            string pos = p.ToString();
            return new string('0', 10 - pos.Length) + pos;
        }

        private string ObjNumber(long FNumber)
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append(FNumber.ToString()).Append(" 0 obj");
            return sb.ToString();
        }

        private string ObjNumberRef(long FNumber)
        {
            StringBuilder sb = new StringBuilder(8);
            sb.Append(FNumber.ToString()).Append(" 0 R");
            return sb.ToString();
        }

        private long UpdateXRef()
        {
            FXRef.Add(pdf.Position);
            return FXRef.Count;
        }
    }
}
