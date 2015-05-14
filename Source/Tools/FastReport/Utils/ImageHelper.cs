using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace FastReport.Utils
{
  internal static class ImageHelper
  {
    public static Bitmap CloneBitmap(Image source)
    {
      if (source == null)
        return null;

      Bitmap image = new Bitmap(source.Width, source.Height);
      image.SetResolution(source.HorizontalResolution, source.VerticalResolution);
      using (Graphics g = Graphics.FromImage(image))
      {
        g.DrawImageUnscaled(source, 0, 0);
      }
      return image;

// this can throw OutOfMemory when creating a grayscale image from a cloned bitmap
//      return source.Clone() as Bitmap;
    }
    
    public static void Save(Image image, Stream stream)
    {
      Save(image, stream, ImageFormat.Png);
    }

    public static void Save(Image image, string fileName, ImageFormat format)
    {
      using (FileStream stream = new FileStream(fileName, FileMode.Create))
      {
        Save(image, stream, format);
      }
    }
    
    public static void Save(Image image, Stream stream, ImageFormat format)
    {
      if (image == null)
        return;
      if (image is Bitmap)
        image.Save(stream, format);
      else if (image is Metafile)
      {
        Metafile emf = null;
        using (Bitmap bmp = new Bitmap(1, 1))
        using (Graphics g = Graphics.FromImage(bmp))
        {
          IntPtr hdc = g.GetHdc();
          emf = new Metafile(stream, hdc);
          g.ReleaseHdc(hdc);
        }
        using (Graphics g = Graphics.FromImage(emf))
        {
          g.DrawImage(image, 0, 0);
        }
      }  
    }
    
    public static byte[] Load(string fileName)
    {
      if (!String.IsNullOrEmpty(fileName))
        return File.ReadAllBytes(fileName);
      return null;
    }

    public static Image Load(byte[] bytes)
    {
      if (bytes != null && bytes.Length > 0)
      {
        try
        {
          return new ImageConverter().ConvertFrom(bytes) as Image;
        }
        catch
        {
          Bitmap errorBmp = new Bitmap(10, 10);
          using (Graphics g = Graphics.FromImage(errorBmp))
          {
            g.DrawLine(Pens.Red, 0, 0, 10, 10);
            g.DrawLine(Pens.Red, 0, 10, 10, 0);
          }
          return errorBmp;
        }
      }
      return null;
    }

    public static byte[] LoadURL(string url)
    {
      if (!String.IsNullOrEmpty(url))
      {
        using (WebClient web = new WebClient())
        {
          return web.DownloadData(url);
        }  
      }
      return null;
    }

    public static Bitmap GetTransparentBitmap(Image source, float transparency)
    {
      if (source == null)
        return null;

      ColorMatrix colorMatrix = new ColorMatrix();
      colorMatrix.Matrix33 = 1 - transparency;
      ImageAttributes imageAttributes = new ImageAttributes();
      imageAttributes.SetColorMatrix(
         colorMatrix,
         ColorMatrixFlag.Default,
         ColorAdjustType.Bitmap);

      int width = source.Width;
      int height = source.Height;
      Bitmap image = new Bitmap(width, height);
      image.SetResolution(source.HorizontalResolution, source.VerticalResolution);

      using (Graphics g = Graphics.FromImage(image))
      {
        g.Clear(Color.Transparent);
        g.DrawImage(
          source,
          new Rectangle(0, 0, width, height),
          0, 0, width, height,
          GraphicsUnit.Pixel,
          imageAttributes);
      }
      return image;
    }
  }
}
