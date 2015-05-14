using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FastReport.Export;
using System.Drawing;
using FastReport.Utils;
using System.Drawing.Imaging;

namespace FastReport.Export.Pdf
{
    /// <summary>
    /// PDF export (Adobe Acrobat)
    /// </summary>
    public partial class PDFExport : ExportBase
    {
        private List<PDFImageObject> PicturesList;
        private List<int> PicResList;

        private class PDFImageObject
        {
            public Stream Stream;
            public int Width;
            public int Height;
            public string Hash;
            public long Id;

            public bool CompareTo(PDFImageObject image)
            {
                if (Stream != null && image.Stream != null)
                    return Hash == image.Hash;
                else
                    return false;
            }

            /// <summary>
            /// Constructor of PDFImageObject
            /// </summary>
            /// <param name="stream"></param>
            /// <param name="width"></param>
            /// <param name="height"></param>
            public PDFImageObject(Stream stream, int width, int height)
            {
                Stream = stream;
                Width = width;
                Height = height;
                Hash = ExportUtils.MD5Stream(stream);
            }
        }

        private int IndexOfPicture(PDFImageObject image)
        {
            int result = -1;
            for (int i = 0; i < PicturesList.Count; i++)
            {
                if (image.CompareTo(PicturesList[i]))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        private int AddPicture(MemoryStream stream, int width, int height)
        {
            PDFImageObject img = new PDFImageObject(stream, width, height);
            int i = IndexOfPicture(img);
            if (i == -1)
            {
                PicturesList.Add(img);
                i = PicturesList.Count - 1;

                // save image
                PicturesList[i].Id = UpdateXRef();
                WriteLn(pdf, ObjNumber(PicturesList[i].Id));
                WriteLn(pdf, "<< /Type /XObject");
                WriteLn(pdf, "/Subtype /Image");
                WriteLn(pdf, "/Width " + width.ToString());
                WriteLn(pdf, "/Height " + height.ToString());
                WriteLn(pdf, "/ColorSpace /DeviceRGB");
                WriteLn(pdf, "/BitsPerComponent 8");
                WriteLn(pdf, "/Filter /DCTDecode");
                WriteLn(pdf, "/Interpolate true");
                WriteLn(pdf, "/Length " + stream.Length.ToString());
                WriteLn(pdf, ">>");
                WriteLn(pdf, "stream");

                if (FEncrypted)
                    RC4CryptStream(stream, pdf, FEncKey, PicturesList[i].Id);
                else
                    stream.WriteTo(pdf);

                WriteLn(pdf, String.Empty);
                WriteLn(pdf, "endstream");
                WriteLn(pdf, "endobj");

                PicturesList[i].Stream.Dispose();

            }
            PicResList.Add(i);
            return i;
        }

        private void AddPictureObject(Stream outstream, ReportComponentBase obj, bool drawBorder, int quality)
        {
            if (obj.Width < 0.5f || obj.Height < 0.5f)
                return;

            int imageIndex = -1;
            float printZoom = FPrintOptimized ? 4 : 1;
            Border oldBorder = obj.Border.Clone();
            obj.Border.Lines = BorderLines.None;
            float bWidth = obj.Width == 0 ? 1 : obj.Width * PDF_DIVIDER;
            float bHeight = obj.Height == 0 ? 1 : obj.Height * PDF_DIVIDER;
            using (Bitmap image = new Bitmap((int)Math.Round(obj.Width * printZoom), (int)Math.Round(obj.Height * printZoom)))
            using (Graphics g = Graphics.FromImage(image))
            {
                g.TranslateTransform(-obj.AbsLeft * printZoom, -obj.AbsTop * printZoom);
                g.Clear(Color.White);
                obj.Draw(new FRPaintEventArgs(g, printZoom, printZoom, Report.GraphicCache));

                MemoryStream buff = new MemoryStream();
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.MimeType == "image/jpeg")
                    {
                        ici = codec;
                        break;
                    }
                }
                EncoderParameters ep = new EncoderParameters();
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                image.Save(buff, ici, ep);
                buff.Position = 0;
                imageIndex = AddPicture(buff, image.Width, image.Height);
            }

            StringBuilder sb = new StringBuilder(256);
            sb.AppendLine("q");

            if (obj is PictureObject)
                sb.Append(GetPDFFillTransparent(
                    Color.FromArgb((byte)((1 - (obj as PictureObject).Transparency) * 255f), Color.Black)));

            sb.Append(FloatToString(bWidth)).Append(" 0 0 ");
            sb.Append(FloatToString(bHeight)).Append(" ");
            sb.Append(FloatToString(GetLeft(obj.AbsLeft))).Append(" ");
            sb.Append(FloatToString(GetTop(obj.AbsTop + obj.Height)));
            sb.AppendLine(" cm");
            sb.Append("/Im").Append(imageIndex.ToString()).AppendLine(" Do");
            sb.AppendLine("Q");
            Write(outstream, sb.ToString());
            obj.Border = oldBorder;
            if (drawBorder)
                Write(outstream, DrawPDFBorder(obj.Border, obj.AbsLeft, obj.AbsTop, obj.Width, obj.Height));
        }
    }
}
