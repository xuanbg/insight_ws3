using System;
using System.Collections.Generic;
using System.Text;
using FastReport.Utils;

namespace FastReport.Export.Pdf
{
    /// <summary>
    /// PDF export (Adobe Acrobat)
    /// </summary>
    public partial class PDFExport : ExportBase
    {
        private class PDFOutlineNode
        {
            public string Text;
            public int Page;
            public float Offset;
            public long Number;
            public int CountTree;
            public int Count;
            public PDFOutlineNode First;
            public PDFOutlineNode Last;
            public PDFOutlineNode Parent;
            public PDFOutlineNode Prev;
            public PDFOutlineNode Next;

            public PDFOutlineNode()
            {
                Text = String.Empty;
                Offset = -1;
                Number = 0;
                Count = 0;
                CountTree = 0;
            }
        }

        private PDFOutlineNode OutlineTree;

        private long BuildOutline(PDFOutlineNode node, XmlItem xml)
        {
            PDFOutlineNode prev = null;
            PDFOutlineNode current = null;
            long currNumber = node.Number;
            for (int i = 0; i < xml.Count; i++)
            {
                int page = 0;
                float offset = 0f;
                
                string s = xml[i].GetProp("Page");
                if (s != "")
                {
                    page = int.Parse(s);
                    s = xml[i].GetProp("Offset");
                    if (s != "")
                        offset = (float)Converter.FromString(typeof(float), s) * PDF_DIVIDER;
                }
                
                // add check of page range
                
                current = new PDFOutlineNode();
                current.Text = xml[i].GetProp("Text");
                current.Page = page;
                current.Offset = offset;
                current.Prev = prev;
                if (prev != null)
                    prev.Next = current;
                else
                    node.First = current;
                prev = current;
                current.Parent = node;
                current.Number = currNumber + 1;
                currNumber = BuildOutline(current, xml[i]);                
                node.Count++;
                node.CountTree += current.CountTree + 1;
            }
            node.Last = current;
            return currNumber;
        }

        private void WriteOutline(PDFOutlineNode item)
        {
            long number;
            if (item.Parent != null)
                number = UpdateXRef();
            else
                number = item.Number;
            WriteLn(pdf, ObjNumber(number));
            WriteLn(pdf, "<<");
            if (item.Text != String.Empty)
                WriteLn(pdf, "/Title " + PrepareString(item.Text, FEncKey, FEncrypted, number));
            if (item.Parent != null)
                WriteLn(pdf, "/Parent " + ObjNumberRef(item.Parent.Number));
            if (item.Count > 0)
                WriteLn(pdf, "/Count " + item.Count.ToString());
            if (item.First != null)
                WriteLn(pdf, "/First " + ObjNumberRef(item.First.Number));
            if (item.Last != null)
                WriteLn(pdf, "/Last " + ObjNumberRef(item.Last.Number));
            if (item.Prev != null)
                WriteLn(pdf, "/Prev " + ObjNumberRef(item.Prev.Number));
            if (item.Next != null)
                WriteLn(pdf, "/Next " + ObjNumberRef(item.Next.Number));

            if (item.Page < FPagesRef.Count)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("/Dest [");
                sb.Append(ObjNumberRef(FPagesRef[item.Page]));
                sb.Append(" /XYZ 0 ");
                sb.Append(Math.Round(FPagesHeights[item.Page] - item.Offset).ToString());
                sb.Append(" 0]");
                WriteLn(pdf, sb.ToString());
            }

            WriteLn(pdf, ">>");
            WriteLn(pdf, "endobj");
            if (item.First != null)
                WriteOutline(item.First);
            if (item.Next != null)
                WriteOutline(item.Next);
        }
    }
}
