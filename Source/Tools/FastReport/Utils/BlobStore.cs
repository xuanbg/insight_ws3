using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace FastReport.Utils
{
  internal class BlobStore : IDisposable
  {
    private List<BlobItem> FList;
    private FileStream FTempFile;
    private string FTempFileName;
    
    public int Count
    {
      get { return FList.Count; }
    }

    internal FileStream TempFile
    {
      get { return FTempFile; }
    }

    public int Add(byte[] stream)
    {
      BlobItem item = new BlobItem(stream, this);
      FList.Add(item);
      return FList.Count - 1;
    }

    public byte[] Get(int index)
    {
      byte[] stream = FList[index].Stream;
      return stream;
    }

    public void Clear()
    {
      foreach (BlobItem b in FList)
      {
        b.Dispose();
      }
      FList.Clear();
    }

    public void LoadDestructive(XmlItem rootItem)
    {
      Clear();
      // avoid memory fragmentation when loading large amount of big blobs
      for (int i = 0; i < rootItem.Count; i++)
      {
        rootItem[i].Text = rootItem[i].GetProp("Stream", false);
      }
      for (int i = 0; i < rootItem.Count; i++)
      {
        Add(Convert.FromBase64String(rootItem[i].Text));
        rootItem[i].Text = "";
      }
    }

    public void Save(XmlItem rootItem)
    {
      foreach (BlobItem item in FList)
      {
        XmlItem xi = rootItem.Add();
        xi.Name = "item";
        xi.SetProp("Stream", Converter.ToXml(item.Stream));
        if (TempFile != null)
          item.Dispose();
      }
    }
    
    public void Dispose()
    {
      Clear();
      if (FTempFile != null)
      {
        FTempFile.Dispose();
        FTempFile = null;
        File.Delete(FTempFileName);
      }
    }
    
    public BlobStore(bool useFileCache)
    {
      FList = new List<BlobItem>();
      if (useFileCache)
      {
        FTempFileName = Config.CreateTempFile("");
        FTempFile = new FileStream(FTempFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
      }
    }


    private class BlobItem : IDisposable
    {
      private byte[] FStream;
      private BlobStore FStore;
      private long FTempFilePosition;
      private long FTempFileSize;

      public byte[] Stream
      {
        get
        {
          if (TempFile != null)
          {
            lock (TempFile)
            {
              TempFile.Seek(FTempFilePosition, SeekOrigin.Begin);
              FStream = new byte[FTempFileSize];
              TempFile.Read(FStream, 0, (int)FTempFileSize);
            }
          }
          return FStream;
        }
      }

      public Stream TempFile
      {
        get { return FStore.TempFile; }
      }

      private void ClearStream()
      {
        FStream = null;
      }

      public void Dispose()
      {
        ClearStream();
      }

      public BlobItem(byte[] stream, BlobStore store)
      {
        FStore = store;
        FStream = stream;
        
        if (TempFile != null)
        {
          TempFile.Seek(0, SeekOrigin.End);
          FTempFilePosition = TempFile.Position;
          FTempFileSize = stream.Length;
          TempFile.Write(stream, 0, (int)FTempFileSize);
          TempFile.Flush();
          ClearStream();
        }
      }
    }

  }
}
