using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using FastReport.Utils;
using FastReport.Forms;
using FastReport.Export;
using FastReport.Format;

using System.Globalization;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Collections;

namespace FastReport.Export.OoXML
{
    /// <summary>
    /// Drawing class
    /// </summary>
    internal class OoXMLDrawing : OoXMLBase
    {
        #region Private properties
        private int FPicCount;
        private StringBuilder drawing_string;
        private StringBuilder picture_rels;
        private Excel2007Export FOoXML;
        #endregion

        public int PicCount { get { return FPicCount; } }

        #region Class overrides
        public override string RelationType { get { return "http://schemas.openxmlformats.org/officeDocument/2006/relationships/drawing"; } }
        public override string ContentType { get { return "application/vnd.openxmlformats-officedocument.drawing+xml"; } }
        public override string FileName { get { return "xl/drawings/drawing1.xml"; } }
        #endregion

        private void ExportBorder(ExportIEMStyle style)
        {
            if(style.Border.Lines == BorderLines.All)
            {
                drawing_string.AppendFormat("<a:ln w=\"{0}\">", style.Border.LeftLine.Width );
                drawing_string.Append("<a:solidFill>");
                drawing_string.AppendFormat("<a:srgbClr val=\"{0:X2}{1:X2}{2:X2}\"/>", 
                    style.Border.LeftLine.Color.R,
                    style.Border.LeftLine.Color.G,
                    style.Border.LeftLine.Color.B);
                drawing_string.Append("</a:solidFill>");

                drawing_string.Append( GetDashStyle( style.Border.LeftLine.DashStyle ) );

                drawing_string.Append("</a:ln>");
            }
        }

        public void Append(ExportIEMObject Obj, int x, int y, int dx, int dy)
        {
            FPicCount++;
            string rid = "\"rId" + FPicCount.ToString() + "\"";

            using (FileStream pngFile = new FileStream(FOoXML.TempFolder + "/xl/media/image" + FPicCount.ToString() + ".png", FileMode.Create))
            {
                pngFile.Write(Obj.PictureStream.ToArray(), 0, (int)Obj.PictureStream.Length);
            }

            picture_rels.Append("<Relationship Id=" + rid + 
                " Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/image\" "+
                "Target=\"../media/image" + FPicCount.ToString() + ".png\" />");

                drawing_string.Append("<xdr:twoCellAnchor editAs=\"oneCell\">");

                drawing_string.Append("<xdr:from>");
                drawing_string.Append("<xdr:col>"+x+"</xdr:col>");
                drawing_string.Append("<xdr:colOff>"+0+"</xdr:colOff>");   
                drawing_string.Append("<xdr:row>"+y+"</xdr:row>");
                drawing_string.Append("<xdr:rowOff>"+0+"</xdr:rowOff>");   
                drawing_string.Append("</xdr:from>");

                drawing_string.Append("<xdr:to>");
                drawing_string.Append("<xdr:col>"+(x+dx)+"</xdr:col>");
                drawing_string.Append("<xdr:colOff>"+ 0 +"</xdr:colOff>");
                drawing_string.Append("<xdr:row>"+(y+dy)+"</xdr:row>");
                drawing_string.Append("<xdr:rowOff>" + 0 +"</xdr:rowOff>");
                drawing_string.Append("</xdr:to>");

                drawing_string.Append("<xdr:pic>");

                drawing_string.Append("<xdr:nvPicPr>");

                drawing_string.Append("<xdr:cNvPr id=\"" + 2 + "\" name=" + "\"" + Obj.Text + "\"" + " descr=\"image" + FPicCount.ToString() + ".png\" /> ");

                drawing_string.Append("<xdr:cNvPicPr>");
                drawing_string.Append("<a:picLocks noChangeAspect=\"1\" />");
                drawing_string.Append("</xdr:cNvPicPr>");
                drawing_string.Append("</xdr:nvPicPr>");
            
                drawing_string.Append("<xdr:blipFill>");
                drawing_string.Append("<a:blip xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" r:embed="+rid+" />");
                drawing_string.Append("<a:stretch><a:fillRect /></a:stretch>");
                drawing_string.Append("</xdr:blipFill>");

                drawing_string.Append("<xdr:spPr>");
                drawing_string.Append("<a:prstGeom prst=\"rect\"><a:avLst /></a:prstGeom>");
                ExportBorder(Obj.Style);
                drawing_string.Append("</xdr:spPr>");

                drawing_string.Append("</xdr:pic>");
                drawing_string.Append("<xdr:clientData />");
                drawing_string.Append("</xdr:twoCellAnchor>");
        }

        public void Start()
        {
            drawing_string.Append(xml_header);
            drawing_string.Append("<xdr:wsDr xmlns:xdr=\"http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing\" xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\">");
            picture_rels.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>");
            picture_rels.Append("<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">");
        }

        public void Stop()
        {
            drawing_string.Append("</xdr:wsDr>");
            picture_rels.Append("</Relationships>");

            if (FPicCount != 0)
            {
                Directory.CreateDirectory(FOoXML.TempFolder + "/xl");
                Directory.CreateDirectory(FOoXML.TempFolder + "/xl/drawings");
                Directory.CreateDirectory(FOoXML.TempFolder + "/xl/drawings/_rels");

                using (FileStream file = new FileStream(FOoXML.TempFolder + "/xl/drawings/_rels/drawing1.xml.rels", FileMode.Create))
                using (StreamWriter Out = new StreamWriter(file))
                {
                    Out.WriteLine(picture_rels);
                }

                using (FileStream file = new FileStream(FOoXML.TempFolder + "/" +FileName, FileMode.Create))
                using (StreamWriter Out = new StreamWriter(file))
                {
                    Out.WriteLine(drawing_string);
                }
            }
        }

        public OoXMLDrawing(Excel2007Export OoXML)
        {
            FOoXML = OoXML;
            FPicCount = 0;
            drawing_string = new StringBuilder();
            picture_rels = new StringBuilder();
        }
    }
    
    /// <summary>
    /// Share all strings in document
    /// </summary>
    class OoXMLSharedStringTable : OoXMLBase
    {
        #region Private properties
        private List<string> FSharedStringList;
        #endregion

        #region Class overrides
        public override string RelationType { get { return "http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings"; } }
        public override string ContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml"; } }
        public override string FileName { get { return "sharedStrings.xml"; } }
        #endregion

        struct CurrentStyle
        {
            public int Size;
            public bool Bold;
            public bool Italic;
            public bool Underline;
            public bool Strike;
            public bool Sub;
            public bool Sup;
            public Color Colour;
            public string LastTag;
        }
        
        private string ConvertHtmlItem( CurrentStyle style )
        {
            StringBuilder   str = new StringBuilder();

            str.Append("<rPr>");
            
            if (style.Bold)      str.Append("<b />");
            if (style.Italic)    str.Append("<i />");
            if (style.Underline) str.Append("<u />");

            str.Append( string.Format(CultureInfo.InvariantCulture, "<sz val=\"{0}\" />", style.Size ) );
            str.Append(string.Format(CultureInfo.InvariantCulture, "<color rgb=\"{0:X2}{1:X2}{2:X2}{3:X2}\" /> ", style.Colour.A, style.Colour.R, style.Colour.G, style.Colour.B));
            str.Append("<rFont val=\"Calibri\" /> ");

            str.Append("<family val=\"2\" /> ");
            str.Append("<charset val=\"204\" /> ");
            str.Append("<scheme val=\"minor\" /> ");
            str.Append("</rPr>");
            str.AppendLine();

            return str.ToString();
        }

        private void ParseFont(string s, CurrentStyle style, out CurrentStyle result_style)
        {
            result_style = style;

            string[] font_items = s.Split('=');
            string Tag = font_items[0].ToUpper();
            switch (Tag)
            { 
                case "COLOR":
                    string[] val = font_items[1].Split('\"');
                    result_style.Colour = Color.FromName(val[1]);
                    break;
                default:
                    throw new Exception("Unsupported font item: " + Tag);
            }
        }

        private string ParseHtmlTags(string s)
        {
            int             Index = 0;
            int             Begin = 0;
            int             End   = 0;
            string          Tag;
            string          Text;
            string          result;
            CurrentStyle    current_style = new CurrentStyle();
            CurrentStyle    previos_style;

            current_style.Size = 10;
            current_style.Bold = false;
            current_style.Italic = false;
            current_style.Underline = false;
            current_style.Colour = Color.FromName("Black");
            current_style.Strike = false;
            current_style.Sub = false;
            current_style.Sup = false;

            result = "";

            Stack<CurrentStyle> style_stack = new Stack<CurrentStyle>();

            Begin = s.IndexOfAny(new char[1] { '<' }, Index);

            while( Begin != -1 )
            {
                if ( Begin != 0 && Index == 0)
                {
                    if (Index == 0)
                    {
                        result += "<r>" + "<t>" + s.Substring( Index, Begin ) + "</t>" + "</r>";
                    }
                }

                End = s.IndexOfAny(new char[1] { '>' }, Begin + 1);
                if (End == -1) break;

                Tag = s.Substring(Begin + 1, End - Begin - 1);

                bool CloseTag = Tag.StartsWith("/");

                if (CloseTag) Tag = Tag.Remove(0, 1);

                string[] items = Tag.Split(' ');

                Tag = items[0].ToUpper();

                if ( ! CloseTag )
                {
                    current_style.LastTag = Tag;
                    style_stack.Push(current_style);

                    switch (Tag)
                    {
                        case "B":       current_style.Bold = true;      break;
                        case "I":       current_style.Italic = true;    break;
                        case "U":       current_style.Underline = true; break;
                        case "STRIKE":  current_style.Strike = true;     break;
                        case "SUB":     current_style.Sub = true;       break;
                        case "SUP":     current_style.Sup = true;       break;
                        case "FONT":    
                            /*current_style.Font = items[1];*/
                            ParseFont(items[1], current_style, out current_style);
                            break;
                        default: 
                            throw new Exception("Unsupported HTML TAG");
                    }
                }
                else 
                {
                    previos_style = style_stack.Pop();
                    if ( previos_style.LastTag != Tag )
                    {
                        throw new Exception("Unaligned HTML TAGS");
                    }
                    current_style = previos_style;
                }

                Index = End + 1;
                Begin = s.IndexOfAny(new char[1] { '<' }, Index);

                if (Begin == -1)
                {
                    Text = s.Substring(Index);
                }
                else
                {
                    Text = s.Substring(Index, Begin - Index);
                }
                string string_item = "<r>" + ConvertHtmlItem(current_style) + "<t xml:space=\"preserve\">" + Text + "</t>" + "</r>";
                
                result += string_item;

            }

            return result;
        }

        public int Add(string s, bool HtmlTags)
        {
            int idx;
            string parsed_tags = "";

            if (HtmlTags)
            {
                parsed_tags = ParseHtmlTags(s);
            }

            if (parsed_tags != "")
                s = parsed_tags;
            else
                s = "<t>" + s + "</t>";

            if (!FSharedStringList.Contains(s))
            {
                FSharedStringList.Add(s);
            }
            idx = FSharedStringList.IndexOf(s);
            return idx;
        }

        public void Export(Excel2007Export OoXML)
        {
            using (FileStream file = new FileStream(OoXML.TempFolder + "/xl/" + FileName, FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                Out.WriteLine(xml_header);
                Out.WriteLine("<sst xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" count=\"" +
                FSharedStringList.Count + "\" uniqueCount=\"" + FSharedStringList.Count + "\">");

                foreach (string item in FSharedStringList)
                    Out.WriteLine("<si>" + item + "</si>");
                Out.WriteLine("</sst>");
            }
        }

        public OoXMLSharedStringTable()
        { 
            FSharedStringList = new List<string>();
        }
    }


    /// <summary>
    /// Share all URL in document
    /// </summary>
    class OoXMLSharedURLTable : OoXMLBase
    {
        private struct Item 
        {
            internal int id;
            internal int x;
            internal int y;
            internal string url;

            internal Item(int id, int x, int y, string url)
            {
                this.id = id;
                this.x = x;
                this.y = y;
                this.url = url;
            }
        }

        #region Private properties
        private List<Item> FURL = new List<Item>();
        #endregion

        #region Class overrides
        public override string RelationType { get { throw new Exception("Not decalred"); /* "http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings"; */ } }
        public override string ContentType { get { throw new Exception("Not decalred"); /* "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml";  */} }
        public override string FileName { get { throw new Exception("Not decalred"); /* return "sharedStrings.xml"; */ } }
        #endregion

        internal void Add( int x, int y, string url )
        {
            int id = FURL.Count + 2;
            FURL.Add( new Item(id, x, y, url ) );
        }

        internal int Count { get { return FURL.Count; } }

        internal StringBuilder ExportBody(Excel2007Export OoXML)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<hyperlinks>");
            foreach( Item i in FURL )
            {
                builder.AppendFormat("<hyperlink ref={0} r:id={1}/>", 
                    OoXML.GetQuotedCellReference( i.x, i.y+1 ),   // Quoted("A2")
                    Quoted( "rId" + i.id.ToString() )           // Quoted("rId1")
                    );
            }
            builder.Append("</hyperlinks>\n");

            return builder;
        }

        internal StringBuilder ExportRelationship()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Item i in FURL)
            {
                builder.AppendFormat("<Relationship TargetMode=\"External\" Target={0} Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink\" Id={1}/>",
                    Quoted(i.url),
                    Quoted("rId" + i.id.ToString())
                );
            }
            return builder;
        }
    }

    /// <summary>
    /// Document styles
    /// </summary>
    class OoXMLDocumentStyles : OoXMLBase
    {
        #region Private properties
        private List<ExportIEMStyle> FStyles;
        private int FFormatIndex;
        #endregion

        #region Class overrides
        public override string RelationType { get { return "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"; } }
        public override string ContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml"; } }
        public override string FileName { get { return "styles.xml"; } }
        #endregion

        #region Helpers
        private string GetRGBString(Color c)
        {
            return "\"" + ExportUtils.ByteToHex(c.A) + ExportUtils.ByteToHex(c.R) + ExportUtils.ByteToHex(c.G) + ExportUtils.ByteToHex(c.B) + "\"";
        }

        private string HAlign2String(HorzAlign ha)
        {
            switch (ha)
            {
                case HorzAlign.Center: return "center";
                case HorzAlign.Left: return "left";
                case HorzAlign.Right: return "right";
                case HorzAlign.Justify: return "justify";
            }
            return "";
        }

        private string VAlign2String(VertAlign va)
        {
            switch (va)
            {
                case VertAlign.Bottom: return "bottom";
                case VertAlign.Center: return "center";
                case VertAlign.Top: return "top";
            }
            return "";
        }

        private string Styles2String(LineStyle style, float Width)
        {
            if(Width < 2) switch (style)
            {
                case LineStyle.Solid: return "\"thin\"";
                case LineStyle.Double: return "\"double\"";
                case LineStyle.Dot: return "\"dotted\"";
                case LineStyle.DashDotDot: return "\"dashDotDot\"";
                case LineStyle.DashDot: return "\"dashDot\"";
                case LineStyle.Dash: return "\"dashed\"";
            }
            else if(Width < 3.5) switch (style)
            {
                case LineStyle.Solid: return "\"medium\"";
                case LineStyle.Double: return "\"double\"";
                case LineStyle.Dot: return "\"mediumDashed\""; // return "\"dotted\"";  // Due no "mediumDotted" do not exist in spec
                case LineStyle.DashDotDot: return "\"mediumDashDotDot\"";
                case LineStyle.DashDot: return "\"mediumDashDot\"";
                case LineStyle.Dash: return "\"mediumDashed\"";
            }
            else switch (style)
            {
                case LineStyle.Solid: return "\"thick\"";
                case LineStyle.Double: return "\"double\"";
                case LineStyle.Dot: return "\"mediumDashed\""; // return "\"dotted\""; // Due no "mediumDotted" do not exist in spec
                case LineStyle.DashDotDot: return "\"mediumDashDotDot\"";
                case LineStyle.DashDot: return "\"slantDashDot\"";
                case LineStyle.Dash: return "\"mediumDashed\"";
            }
            return "";
        }

        private string ConvertRotationAngle(int Angle)
        {
            if (Angle != 0 && Angle <= 90)
            {
                Angle = 90 + Angle;
            }
            else if (Angle >= 270)
            {
                Angle = 360 - Angle;
            }
            else
            {
                Angle = 0;
            }
            return Angle.ToString();
        }
        #endregion

        private void ExportFormats(StreamWriter Out)
        {
            string result = "";
            int res_count = 0;

            for (int i = 0; i < FStyles.Count; i++)
            {
                ExportIEMStyle EStyle = FStyles[i];
                FormatBase format_base = EStyle.Format;

                if (format_base is CurrencyFormat || format_base is NumberFormat)
                {
                  ++res_count;
                  result += string.Format(CultureInfo.InvariantCulture, "<numFmt numFmtId=\"{0}\" formatCode=\"{1}\" />",
                      FFormatIndex + res_count,
                      ExportUtils.GetExcelFormatSpecifier(format_base));
                }
            }
            Out.WriteLine("<numFmts count=\"" + res_count + "\">");
            Out.WriteLine(result);
            Out.WriteLine("</numFmts>");
        }

        private int GetFormatCode(ExportIEMStyle LookingForStyle)
        {
            int res_count = 0;
            for (int i = 0; i < FStyles.Count; i++)
            {

                ExportIEMStyle EStyle = FStyles[i];
                FormatBase format_base = EStyle.Format;


                if (format_base is CurrencyFormat || format_base is NumberFormat)
                {
                    ++res_count;
                    if (LookingForStyle == FStyles[i]) return FFormatIndex + res_count;
                }
            }
            return 0;
        }

        private void ExportFonts(StreamWriter Out)
        {
            int i;
            ExportIEMStyle EStyle;

            Out.WriteLine("<fonts count=\"" + FStyles.Count + "\">");
            for (i = 0; i < FStyles.Count; i++)
            {
                EStyle = FStyles[i];

                Font font = EStyle.Font;
                Out.WriteLine("<font>");
                if (font.Bold) Out.Write("<b/>");
                if (font.Italic) Out.Write("<i/>");
                if (font.Underline) Out.Write("<u/>");
                Out.WriteLine("<sz val=\"" + font.Size.ToString(CultureInfo.InvariantCulture.NumberFormat) + "\" />");
                Out.WriteLine("<color rgb=" + GetRGBString(EStyle.TextColor) + " />");
                Out.WriteLine("<name val=\"" + font.Name + "\" />");
#if false  // These properties breaks font export
//                Out.WriteLine("<family val=\"2\" />");
//                Out.WriteLine("<charset val=\"204\" />");
//                Out.WriteLine("<scheme val=\"minor\" />");
#endif
                Out.WriteLine("</font>");
            }
            Out.WriteLine("</fonts>");

        }

        private void ExportFills(StreamWriter Out)
        {
            int i;
            ExportIEMStyle EStyle;

            Out.WriteLine("<fills count=\"" + (FStyles.Count + 2) + "\">");
            Out.WriteLine("<fill><patternFill patternType=\"none\"/></fill>");
            Out.WriteLine("<fill><patternFill patternType=\"gray125\"/></fill>");
            for (i = 0; i < FStyles.Count; i++)
            {
                EStyle = FStyles[i];

                Out.WriteLine("<fill>");
                if( EStyle.Fill is LinearGradientFill )
                {
                    LinearGradientFill linear = EStyle.Fill as LinearGradientFill;
                    Out.WriteLine("<gradientFill degree=\"" +  linear.Angle + "\">");
                    Out.WriteLine("<stop position=\"" + 0 + "\">");
                    Out.WriteLine("<color rgb=" + GetRGBString(linear.StartColor) + " /> ");
                    Out.WriteLine("</stop>");
                    Out.WriteLine("<stop position=\"" + 1 +"\">");
                    Out.WriteLine("<color rgb=" + GetRGBString(linear.EndColor) +" /> ");
                    Out.WriteLine("</stop>");
                    Out.WriteLine("</gradientFill>");
                }
                else if (EStyle.Fill is HatchFill)
                {
                    bool swap_color = false;
                    string PatternType = "none";
                    HatchFill hatch = EStyle.Fill as HatchFill;
                    switch (hatch.Style)
                    {
                        case System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal:
                            PatternType = "lightUp";
                            swap_color = true;
                            break;
                        case System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal:
                            PatternType = "lightUp";
                            break;

                            //  case System.Drawing.Drawing2D.HatchStyle.Cross:
                            //  case System.Drawing.Drawing2D.HatchStyle.Max:
                        case System.Drawing.Drawing2D.HatchStyle.LargeGrid:
                        case System.Drawing.Drawing2D.HatchStyle.SmallGrid:
                            PatternType = "lightGrid";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal:
                            swap_color = true;
                            PatternType = "darkDown";
                            break;
                        case System.Drawing.Drawing2D.HatchStyle.DarkDownwardDiagonal:
                            PatternType = "darkDown";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.DarkHorizontal:
                            PatternType = "darkHorizontal";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.LightHorizontal:
                            PatternType = "lightHorizontal";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.LightVertical:
                            PatternType = "lightVertical";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.DarkVertical:
                            PatternType = "darkVertical";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.Trellis:
                            PatternType = "darkTrellis";
                            break;

                        case System.Drawing.Drawing2D.HatchStyle.Percent05:
                            PatternType = "gray0625";
                            break;

                        //case System.Drawing.Drawing2D.HatchStyle.Min:
                        case System.Drawing.Drawing2D.HatchStyle.Horizontal:
                        case System.Drawing.Drawing2D.HatchStyle.Vertical:
                        case System.Drawing.Drawing2D.HatchStyle.DiagonalCross:
                        case System.Drawing.Drawing2D.HatchStyle.Percent10:
                        case System.Drawing.Drawing2D.HatchStyle.Percent20:
                        case System.Drawing.Drawing2D.HatchStyle.Percent25:
                        case System.Drawing.Drawing2D.HatchStyle.Percent30:
                        case System.Drawing.Drawing2D.HatchStyle.Percent40:
                        case System.Drawing.Drawing2D.HatchStyle.Percent50:
                        case System.Drawing.Drawing2D.HatchStyle.Percent60:
                        case System.Drawing.Drawing2D.HatchStyle.Percent70:
                        case System.Drawing.Drawing2D.HatchStyle.Percent75:
                        case System.Drawing.Drawing2D.HatchStyle.Percent80:
                        case System.Drawing.Drawing2D.HatchStyle.Percent90:
                        case System.Drawing.Drawing2D.HatchStyle.LightDownwardDiagonal:
                        case System.Drawing.Drawing2D.HatchStyle.LightUpwardDiagonal:
                        case System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal:
                        case System.Drawing.Drawing2D.HatchStyle.WideUpwardDiagonal:
                        case System.Drawing.Drawing2D.HatchStyle.NarrowVertical:
                        case System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal:
                        case System.Drawing.Drawing2D.HatchStyle.DashedDownwardDiagonal:
                        case System.Drawing.Drawing2D.HatchStyle.DashedUpwardDiagonal:
                        case System.Drawing.Drawing2D.HatchStyle.DashedHorizontal:
                        case System.Drawing.Drawing2D.HatchStyle.DashedVertical:
                        case System.Drawing.Drawing2D.HatchStyle.SmallConfetti:
                        case System.Drawing.Drawing2D.HatchStyle.LargeConfetti:
                        case System.Drawing.Drawing2D.HatchStyle.ZigZag:
                        case System.Drawing.Drawing2D.HatchStyle.Wave:
                        case System.Drawing.Drawing2D.HatchStyle.DiagonalBrick:
                        case System.Drawing.Drawing2D.HatchStyle.HorizontalBrick:
                        case System.Drawing.Drawing2D.HatchStyle.Weave:
                        case System.Drawing.Drawing2D.HatchStyle.Plaid:
                        case System.Drawing.Drawing2D.HatchStyle.Divot:
                        case System.Drawing.Drawing2D.HatchStyle.DottedGrid:
                        case System.Drawing.Drawing2D.HatchStyle.DottedDiamond:
                        case System.Drawing.Drawing2D.HatchStyle.Shingle:
                        case System.Drawing.Drawing2D.HatchStyle.Sphere:
                        case System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard:
                        case System.Drawing.Drawing2D.HatchStyle.LargeCheckerBoard:
                        case System.Drawing.Drawing2D.HatchStyle.OutlinedDiamond:
                        case System.Drawing.Drawing2D.HatchStyle.SolidDiamond:
                            break;
                    }
                    Out.WriteLine("<patternFill patternType=" + Quoted(PatternType) + " >");
                    if (!swap_color)
                    {
                        Out.WriteLine("<fgColor rgb=" + GetRGBString(hatch.ForeColor) + "/>");
                        Out.WriteLine("<bgColor rgb=" + GetRGBString(hatch.BackColor) + "/>");
                    }
                    else
                    {
                        Out.WriteLine("<fgColor rgb=" + GetRGBString(hatch.BackColor) + "/>");
                        Out.WriteLine("<bgColor rgb=" + GetRGBString(hatch.ForeColor) + "/>");
                    }
                    Out.WriteLine("</patternFill>");
                }
                else 
                {
                    Out.WriteLine("<patternFill patternType=\"solid\">");
                    Out.WriteLine("<fgColor rgb=" + GetRGBString(EStyle.FillColor) + "/>");
                    Out.WriteLine("</patternFill>");
                }
                Out.WriteLine("</fill>");
            }
            Out.WriteLine("</fills>");
        }

        private void ExportBorders(StreamWriter Out)
        {
            Out.WriteLine("<borders count=\"" + FStyles.Count + "\">");
            for (int i = 0; i < FStyles.Count; i++)
            {
                Border border = FStyles[i].Border;

                Out.WriteLine("<border>");

                if ((border.Lines & BorderLines.Left) != 0)
                    Out.WriteLine("<left style=" + Styles2String(border.LeftLine.Style, border.LeftLine.Width) + "><color rgb=" + GetRGBString(border.LeftLine.Color) + " /></left>");
                else
                    Out.WriteLine("<left />");

                if ((border.Lines & BorderLines.Right) != 0)
                    Out.WriteLine("<right style=" + Styles2String(border.RightLine.Style, border.RightLine.Width) + "><color rgb=" + GetRGBString(border.RightLine.Color) + " /></right>");
                else
                    Out.WriteLine("<right />");

                if ((border.Lines & BorderLines.Top) != 0)
                    Out.WriteLine("<top style=" + Styles2String(border.TopLine.Style, border.TopLine.Width) + "><color rgb=" + GetRGBString(border.TopLine.Color) + " /></top>");
                else
                    Out.WriteLine("<top />");

                if ((border.Lines & BorderLines.Bottom) != 0)
                    Out.WriteLine("<bottom style=" + Styles2String(border.BottomLine.Style, border.BottomLine.Width) + "><color rgb=" + GetRGBString(border.BottomLine.Color) + " /></bottom>");
                else
                    Out.WriteLine("<bottom />");

                Out.WriteLine("<diagonal />");
                Out.WriteLine("</border>");
            }
            Out.WriteLine("</borders>");
        }

        private VertAlign TranslateVAligment270(HorzAlign ha)
        {
            switch (ha)
            { 
                case HorzAlign.Left:
                    return VertAlign.Bottom;
                case HorzAlign.Right:
                    return VertAlign.Top;
            }
            return VertAlign.Center;
        }

        private HorzAlign TranslateHAligment270(VertAlign va)
        {
            switch (va)
            {
                case VertAlign.Top: return HorzAlign.Left;
                case VertAlign.Bottom: return HorzAlign.Right;
            }
            return HorzAlign.Center;
        }

        private VertAlign TranslateVAligment90(HorzAlign ha)
        {
            switch (ha)
            {
                case HorzAlign.Left:
                    return VertAlign.Top;
                case HorzAlign.Right:
                    return VertAlign.Bottom;
            }
            return VertAlign.Center;
        }

        private HorzAlign TranslateHAligment90(VertAlign va)
        {
            switch (va)
            {
                case VertAlign.Top: return HorzAlign.Right;
                case VertAlign.Bottom: return HorzAlign.Left;
            }
            return HorzAlign.Center;
        }

        private VertAlign TranslateVAligment180(VertAlign va)
        {
            switch (va)
            {
                case VertAlign.Top: return VertAlign.Bottom;
                case VertAlign.Bottom: return VertAlign.Top;
            }
            return VertAlign.Center;
        }

        private HorzAlign TranslateHAligment180(HorzAlign ha)
        {
            switch (ha)
            {
                case HorzAlign.Left:    return HorzAlign.Right;
                case HorzAlign.Right:   return HorzAlign.Left;
            }
            return HorzAlign.Center;
        }

        private void ExportAlgnment(StreamWriter Out, ExportIEMStyle EStyle)
        {
            HorzAlign halign = EStyle.HAlign;
            VertAlign valign = EStyle.VAlign;

            if (EStyle.Angle != 0)
            {
                if (EStyle.Angle == 90)
                {
                    valign = TranslateVAligment90(EStyle.HAlign);
                    halign = TranslateHAligment90(EStyle.VAlign);
                }
                else if (EStyle.Angle == 180)
                {
                    valign = TranslateVAligment180(EStyle.VAlign);
                    halign = TranslateHAligment180(EStyle.HAlign);
                }
                else if (EStyle.Angle == 270)
                {
                    valign = TranslateVAligment270(EStyle.HAlign); // VertAlign.Bottom;
                    halign = TranslateHAligment270(EStyle.VAlign); // HorzAlign.Right;
                }
                else if (EStyle.Angle < 90)
                {
                    halign = HorzAlign.Center;
                    valign = VertAlign.Center;

                }
                else if (EStyle.Angle > 270)
                {
                    halign = HorzAlign.Center;
                    valign = VertAlign.Center;
                }
            }
            
            Out.WriteLine(
                "<alignment horizontal=\"" + HAlign2String(halign) +
                "\" vertical=\"" + VAlign2String(valign) +
                "\" textRotation=\"" + ConvertRotationAngle(EStyle.Angle) + 
                "\" wrapText=\"1\" />");
        }

        private void ExportCellStyles(StreamWriter Out)
        {
            StringBuilder styles = new StringBuilder();

            Out.WriteLine("<cellXfs count=\"" + FStyles.Count + "\">");
            for (int i = 0; i < FStyles.Count; i++)
            {
                ExportIEMStyle EStyle = FStyles[i];

                Out.WriteLine("<xf numFmtId=\"" + GetFormatCode(EStyle) + "\"");
                Out.WriteLine("fontId=\"" + i + "\" ");
                Out.WriteLine("fillId=\"" + (i + 2) + "\" ");
                Out.WriteLine("borderId=\"" + i + "\" ");
                Out.WriteLine("xfId=\"0\" ");
                Out.WriteLine("applyAlignment=\"1\">");
                ExportAlgnment(Out, EStyle);
                Out.WriteLine("</xf>");
            }
            Out.WriteLine("</cellXfs>");
        }

        public void Export(Excel2007Export OoXML)
        {
            using (FileStream file = new FileStream(OoXML.TempFolder + "/xl/" + FileName, FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                Out.WriteLine(xml_header);
                Out.WriteLine("<styleSheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">");

                ExportFormats(Out);
                ExportFonts(Out);
                ExportFills(Out);
                ExportBorders(Out);
                // 
                Out.WriteLine("<cellStyleXfs count=\"1\">");
                Out.WriteLine("<xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\" />");
                Out.WriteLine("</cellStyleXfs>");
                // Cell styles
                ExportCellStyles(Out);
                //
                Out.WriteLine("<cellStyles count=\"1\">");
                Out.WriteLine("<cellStyle name=\"Normal\" xfId=\"0\" builtinId=\"0\" />");
                Out.WriteLine("</cellStyles>");
                //
                Out.WriteLine("<dxfs count=\"0\" />");
                Out.WriteLine("<tableStyles count=\"0\" defaultTableStyle=\"TableStyleMedium9\" defaultPivotStyle=\"PivotStyleLight16\" />");
                Out.WriteLine("</styleSheet>");
            }
        }

        public OoXMLDocumentStyles()
        { 
            FStyles = new List<ExportIEMStyle>();
            FFormatIndex = 164;
        }

        internal int Add(OoXMLSheet sh)
        {
            FStyles.AddRange(sh.Matrix.Styles);
            return FStyles.Count;
        }
    }

    /// <summary>
    /// Workbook
    /// </summary>
    class OoXMLWorkbook : OoXMLBase
    {
        #region Class overrides
        public override string RelationType { get { return "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"; } }
        public override string ContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"; } }
        public override string FileName { get { return "xl/workbook.xml"; } }
        #endregion

        #region Private properties
        private List<OoXMLSheet> FSheetList = new List<OoXMLSheet>();
        #endregion

        #region Internal properties
        internal OoXMLSheet[] SheetList { get { return FSheetList.ToArray(); } }
        #endregion

        internal void Export(Excel2007Export OoXML/*, ExportMatrix FMatrix*/)
        {
            using (FileStream file = new FileStream(OoXML.TempFolder + "/" + FileName, FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                Out.WriteLine(xml_header);
                Out.WriteLine("<workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">");
                Out.WriteLine("<fileVersion appName=\"xl\" lastEdited=\"4\" lowestEdited=\"4\" rupBuild=\"4505\" />");
                Out.WriteLine("<workbookPr defaultThemeVersion=\"124226\" />");
                Out.WriteLine("<bookViews>");
                Out.WriteLine("<workbookView xWindow=\"0\" yWindow=\"0\" windowWidth=\"8610\" windowHeight=\"6225\" />");
                Out.WriteLine("</bookViews>");
                Out.WriteLine("<sheets>");
                foreach (OoXMLSheet sh in this.FSheetList)
                {
                    Out.WriteLine("<sheet name=" + Quoted(sh.Name) + " sheetId="+Quoted(sh.SheetID)+" r:id="+Quoted(sh.rId)+" />");
                }
                Out.WriteLine("</sheets>");
                Out.WriteLine("<calcPr calcId=\"124519\" />");
                Out.WriteLine("</workbook>");
            } 
        }

        internal void AddSheet(OoXMLSheet sh)
        {
            FSheetList.Add(sh);
            this.AddRelation(FSheetList.Count + 20, sh);
        }
    }

    /// <summary>
    /// OoXMLSheet class
    /// </summary>
    class OoXMLSheet : OoXMLBase
    {
        #region Private properties
        const float MargDiv = 25.4F;
        
        private NumberFormatInfo formatInfo;
        private ExportMatrix FMatrix;
        private string FName;
        private int internal_index;
        #endregion

        private string FloatToString(double value)
        {
            return Convert.ToString(Math.Round(value, 2), formatInfo);
        }

        #region Internal properties
        internal ExportMatrix Matrix { get { return FMatrix; } }
        internal string Name { get { return FName; } }
        internal string SheetID { get { return internal_index.ToString(); } }
        internal int ID { set { internal_index = value; } }
        #endregion

        #region Class overrides
        public override string RelationType { get { return "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"; } }
        public override string ContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"; } }
        public override string FileName { get { return "worksheets/sheet"+ internal_index.ToString()+ ".xml"; } }
        #endregion

        private string ExportCell( Excel2007Export OoXML, ExportIEMObject Obj, int x, int y  )
        {
            string Result;
            decimal value;

            bool isNumeric = ExportUtils.ParseTextToDecimal(Obj.Text, Obj.Style.Format, out value); 
            if (isNumeric)
            {
                Result = "<c r=" + OoXML.GetQuotedCellReference(x, y + 1) +
                    " s=\"" + Obj.StyleIndex +
                    "\"><v>" + Convert.ToString(value, CultureInfo.InvariantCulture.NumberFormat) +
                    "</v></c>";
            }
            else
            {
                String s = ExportUtils.XmlString(Obj.Text, Obj.HtmlTags);
                int idx = OoXML.StringTable.Add( s, Obj.HtmlTags );
                if (Obj.URL != null && Obj.URL != "")
                {
                    OoXML.URLTable.Add(x, y, Obj.URL);
                }
                Result = "<c r=" + OoXML.GetQuotedCellReference(x, y + 1) +
                    " s=\"" + Obj.StyleIndex +
                    "\" t=\"s\"><v>" + idx +
                    "</v></c>";
            }

            Result += "\r\n";
            return Result;
        }

        internal string GetCellReference(int x, int y)
        {
            string xx;
            const int max_chars = 'Z' - 'A' + 1;

            if (x < max_chars)
            {
                char ch = 'A';
                ch += (char)x;
                xx = ch.ToString();
            }
            else
            {
                x -= max_chars;
                char c1 = (char)((char)'A' + (char)(x / max_chars));
                char c2 = (char)((char)'A' + (char)(x % max_chars));
                xx = c1.ToString() + c2.ToString();
            }
            return xx + y;
        }

        internal string GetRangeReference(int i)
        {
            string res;
            int fx, fy, dx, dy;
            FMatrix.ObjectPos(i, out fx, out fy, out dx, out dy);
            res = "\"" + GetCellReference(fx, fy + 1) + ":" + GetCellReference(fx + dx - 1, fy + dy) + "\"";
            return res;
        }

        internal void Export(Excel2007Export OoXML, int FirstStyleIndex, bool PageBreaks)
        {
            int fx, fy, dx, dy;
            int meged_cells_count = 0;

            using (FileStream file = new FileStream(OoXML.TempFolder + "/xl/worksheets/sheet" + SheetID + ".xml", FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                StringBuilder builder = new StringBuilder();
                StringBuilder merged = new StringBuilder();

                builder.Append(xml_header);
                builder.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">");

                builder.Append(OoXML.GetMatrxDimension(FMatrix));

                builder.Append("<sheetViews>");
                builder.Append("<sheetView tabSelected=\"1\" workbookViewId=\"0\" />");
                builder.Append("</sheetViews>");
                builder.Append("<sheetFormatPr defaultRowHeight=\"15\" />");

                // sheet columns
                builder.Append("<cols>");

                for (int x = 1; x < FMatrix.Width; x++)
                {
                    builder.Append("<col min=\"" + x + "\" max=\"" + x + "\" width=\"" +
                        ExportUtils.FloatToString((FMatrix.XPosById(x) - FMatrix.XPosById(x - 1)) / OoXML.XDivider) +
                        "\" customWidth=\"1\" />");
                }
                builder.Append("</cols>");

                builder.Append("<sheetData>");

                for (int y = 0; y < FMatrix.Height - 1; y++)
                {
                    float ht = (FMatrix.YPosById(y + 1) - FMatrix.YPosById(y)) / OoXML.YDivider;
                    builder.Append("<row r=\"" + (y + 1) + "\" ht=\"" + ExportUtils.FloatToString(ht) +
                         "\" customHeight=\"1\">");

                    for (int x = 0; x < FMatrix.Width; x++)
                    {
                        int i = FMatrix.Cell(x, y);
                        if (i != -1)
                        {
                            FMatrix.ObjectPos(i, out fx, out fy, out dx, out dy);
                            ExportIEMObject Obj = FMatrix.ObjectById(i);

                            // Multisheet report hack
                            Obj.StyleIndex += FirstStyleIndex;

                            if (Obj.Counter < dy)
                            {
                                if (Obj.IsText)
                                {
                                    builder.Append(ExportCell(OoXML, Obj, x, y));

                                    for (int j = 1; j < dx; j++)
                                    {
                                        x++;
                                        builder.Append("<c r=" + OoXML.GetQuotedCellReference(x, y + 1) + " s=\"" + Obj.StyleIndex + "\" />");
                                    }

                                }
                                else
                                {
                                    if (Obj.Width > 0 && Obj.Counter == 0)
                                    {
                                        OoXML.Drawing.Append(Obj, fx, fy, dx, dy);
                                    }
                                }
                                Obj.Counter++;
                                if ((Obj.Counter == dy) && (dx > 1 || dy > 1))
                                {
                                    meged_cells_count++;
                                    merged.Append("<mergeCell ref=" + /*OoXML.*/ GetRangeReference(i) + "/>");
                                }
                            }
                        }
                    }
                    builder.Append("</row>");
                }
                builder.Append("</sheetData>\n");

                // merge cells
                if (meged_cells_count != 0)
                {
                    builder.Append("<mergeCells count=\"" + meged_cells_count + "\">");
                    builder.Append(merged);
                    builder.Append("</mergeCells>");
                }

                // url list
                if (OoXML.URLTable.Count != 0)
                {
                    builder.Append(OoXML.URLTable.ExportBody(OoXML));
                }

                builder.AppendLine(string.Format(CultureInfo.InvariantCulture, "<pageMargins " +
                                                  " left=\"{1:F2}\"" +
                                                  " right=\"{2:F2}\"" +
                                                  " top=\"{3:F2}\"" +
                                                  " bottom=\"{0:F2}\"" +
                                                  " header=\"0\"" +
                                                  " footer=\"0\" />",
                                                  FMatrix.PageLMargin(0) / MargDiv,
                                                  FMatrix.PageRMargin(0) / MargDiv,
                                                  FMatrix.PageTMargin(0) / MargDiv,
                                                  FMatrix.PageBMargin(0) / MargDiv));
                /* page setup */
                builder.AppendLine(string.Format(CultureInfo.InvariantCulture, "<pageSetup " +
                    " paperSize=" + Quoted( /*OoXML.*/FMatrix.RawPaperSize(0)) +
                    " orientation=" + Quoted( /*OoXML.*/FMatrix.Landscape(0) ? "landscape" : "portrait") +
                    " horizontalDpi=" + Quoted(300) +
                    " verticalDpi=" + Quoted(300) + " />"));

                /* row breaks */
                if (PageBreaks)
                {
                    merged = null;
                    merged = new StringBuilder();
                    int pages = 0;

                    for (int i = 0; i <= FMatrix.Height - 1; i++)
                    {
                        if (FMatrix.YPosById(i) >= FMatrix.PageBreak(pages))
                        {
                            merged.AppendLine(string.Format("<brk id=\"{0}\" max=\"16383\" man=\"1\" />", i));
                            pages++;
                        }
                    }

                    builder.AppendFormat("<rowBreaks count=\"{0}\" manualBreakCount=\"{0}\">", pages, pages);
                    builder.Append(merged);
                    builder.AppendLine("</rowBreaks>");
                }

                /* drawing */
                if (OoXML.Drawing.PicCount != 0)
                {
                    builder.Append("<drawing r:id=\"rId1\" />");
                }

                /* Relations present in documents */
                if (OoXML.URLTable.Count != 0 || OoXML.Drawing.PicCount != 0)
                {
                    using (FileStream rel_file = new FileStream(OoXML.TempFolder + "/xl/worksheets/_rels/sheet" + SheetID + ".xml.rels", FileMode.Create))
                    using (StreamWriter rel_out = new StreamWriter(rel_file))
                    {
                        rel_out.WriteLine(xml_header);
                        rel_out.WriteLine("<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">");
                        if (OoXML.Drawing.PicCount != 0)
                        {
                            rel_out.WriteLine("<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/drawing\" Target=\"../drawings/drawing1.xml\"/>");
                        }
                        if (OoXML.URLTable.Count != 0)
                        {
                            rel_out.WriteLine(OoXML.URLTable.ExportRelationship());
                        }

                        rel_out.WriteLine("</Relationships>");
                    }

                }
                builder.Append("</worksheet>");
                Out.WriteLine(builder);
            }
        }

        public OoXMLSheet( ExportMatrix matrix, string Name, int Index )
        {
            formatInfo = new NumberFormatInfo();
            formatInfo.NumberGroupSeparator = String.Empty;
            formatInfo.NumberDecimalSeparator = ".";

            FMatrix = matrix;
            FName = Name;
            internal_index = Index; 
        }

    }
    
    /// <summary>
    /// Excel 2007 export class
    /// </summary>
    public class Excel2007Export : OOExportBase
    {
        #region Constants
        const float oxmlXDivider = 6.3f; //7.428f;
        const float oxmlYDivider = 1.376f;
        #endregion

        #region Private fields
        private MyRes Res;
        private bool FWysiwyg;
        private bool FPageBreaks;
        private bool FDataOnly;

        private OoXMLSharedStringTable      FStringTable;
        private OoXMLSharedURLTable         FURLTable;
        internal OoXMLDrawing               FDrawing;
        private OoXMLCoreDocumentProperties FCoreDocProp;
        private OoXMLApplicationProperties  FAppProp;
        private OoXMLDocumentStyles         FDocStyles;
        private OoXMLWorkbook               FWorkBook;
        private Hashtable                   sheets = new Hashtable();
        #endregion

        #region Properties
        internal OoXMLDrawing Drawing { get { return FDrawing;  } }
        internal OoXMLSharedStringTable StringTable { get { return FStringTable; } }
        internal OoXMLSharedURLTable URLTable { get { return FURLTable; } }

        internal float YDivider { get { return oxmlYDivider; } }
        internal float XDivider { get { return oxmlXDivider; } }

        /// <summary>
        /// Gets or sets a value that determines whether the wysiwyg mode should be used 
        /// for better results.
        /// </summary>
        /// <remarks>
        /// Default value is <b>true</b>. In wysiwyg mode, the resulting Excel file will look
        /// as close as possible to the prepared report. On the other side, it may have a lot 
        /// of small rows/columns, which will make it less editable. If you set this property
        /// to <b>false</b>, the number of rows/columns in the resulting file will be decreased.
        /// You will get less wysiwyg, but more editable file.
        /// </remarks>
        public bool Wysiwyg
        {
          get { return FWysiwyg; }
          set { FWysiwyg = value; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether to insert page breaks in the output file or not.
        /// </summary>
        public bool PageBreaks
        { 
          get { return FPageBreaks; } 
          set { FPageBreaks = value; } 
        }

        /// <summary>
        /// Gets or sets a value that determines whether to export the databand rows only.
        /// </summary>
        public bool DataOnly
        {
          get { return FDataOnly; }
          set { FDataOnly = value; }
        }
        #endregion

        #region Private Methods
        private void CreateThemes(string ThemeString)
        {
            //ResourceSet set = new ResourceSet();

            // get a reference to the current assembly
            Assembly a = Assembly.GetExecutingAssembly();

            // get a list of resource names from the manifest
            string[] resNames = a.GetManifestResourceNames();

            Stream o = a.GetManifestResourceStream("FastReport.Resources.theme1.xml");

            int length = 4096;
            int bytesRead = 0;
            Byte[] buffer = new Byte[length];

            // write the required bytes
            using (FileStream fs = new FileStream(FTempFolder + "/xl/theme/theme1.xml", FileMode.OpenOrCreate))
            {
                do
                {
                    bytesRead = o.Read(buffer, 0, length);
                    fs.Write(buffer, 0, bytesRead);
                }
                while (bytesRead == length);
            }

            o.Dispose();
        }

        private void CreateContentTypes()
        { 
            using (FileStream file = new FileStream(FTempFolder + "/[Content_Types].xml", FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                Out.WriteLine(xml_header);
                Out.Write("<Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">");


                //CreateThemes();
                Out.Write("<Override PartName=\"/xl/theme/theme1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.theme+xml\" />");

                Out.Write("<Override PartName=" + QuotedRoot("xl/" + FDocStyles.FileName) + " ContentType=" + Quoted(FDocStyles.ContentType) + "/>");


                Out.Write("<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\" />");
                Out.Write("<Default Extension=\"xml\" ContentType=\"application/xml\" />");
                Out.Write("<Default Extension=\"png\" ContentType=\"image/png\"/>");

                Out.Write("<Override PartName=" + QuotedRoot(FWorkBook.FileName) + " ContentType=" + Quoted(FWorkBook.ContentType) + "/>");
                Out.Write("<Override PartName=" + QuotedRoot(FAppProp.FileName) + " ContentType=" + Quoted(FAppProp.ContentType) + "/>");
                Out.Write("<Override PartName=" + QuotedRoot(FDrawing.FileName) + " ContentType=" + Quoted(FDrawing.ContentType) + "/>");

                CreateWorkbookRelations();

                foreach (OoXMLSheet sh in FWorkBook.SheetList)
                {
                    Out.Write("<Override PartName=" + QuotedRoot("xl/" + sh.FileName) + " ContentType=" + Quoted(sh.ContentType) + " />");
                }


                Out.Write("<Override PartName=" + QuotedRoot("xl/" + FStringTable.FileName) + " ContentType=" + Quoted(FStringTable.ContentType) + "/>");
                Out.Write("<Override PartName=" + QuotedRoot(FCoreDocProp.FileName) + " ContentType=" + Quoted(FCoreDocProp.ContentType) + "/>");

                Out.Write("</Types>");
            }
        }

        private void CreateRelations()
        {
            using (FileStream file = new FileStream(FTempFolder + "/_rels/.rels", FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                Out.WriteLine(xml_header);
                Out.WriteLine("<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">");

                Out.WriteLine("<Relationship Id=\"rId3\" Type=" + Quoted(FAppProp.RelationType) + " Target=" + Quoted(FAppProp.FileName) + " />");
                Out.WriteLine("<Relationship Id=\"rId2\" Type=" + Quoted(FCoreDocProp.RelationType) + " Target=" + Quoted(FCoreDocProp.FileName) + " />");
                Out.WriteLine("<Relationship Id=\"rId1\" Type=" + Quoted(FWorkBook.RelationType) + " Target=" + Quoted(FWorkBook.FileName) + " />");

                Out.WriteLine("</Relationships>");
            }
        }

        private void CreateWorkbookRelations()
        {
            using (FileStream file = new FileStream(FTempFolder + "/xl/_rels/workbook.xml.rels", FileMode.Create))
            using (StreamWriter Out = new StreamWriter(file))
            {
                Out.WriteLine(xml_header);
                Out.WriteLine("<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">");
                Out.WriteLine("<Relationship Id=\"rId3\" Type=" + Quoted(FDocStyles.RelationType) + " Target=" + Quoted(FDocStyles.FileName) + " />");
                Out.WriteLine("<Relationship Id=\"rId2\" Type=" + Quoted("http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme") + " Target=" + Quoted("theme/theme1.xml") + " />");
                foreach (OoXMLSheet sh in FWorkBook.SheetList)
                {
                    Out.WriteLine("<Relationship Id="+ Quoted(sh.rId) +" Type=" + Quoted(sh.RelationType) + " Target=" + Quoted(sh.FileName) + " />");
                }
                Out.WriteLine("<Relationship Id=\"rId6\" Type=" + Quoted(FStringTable.RelationType) + " Target=" + Quoted(FStringTable.FileName) + " />");

                Out.WriteLine("</Relationships>");
            }
        }

        internal string GetCellReference(int x, int y)
        {
            string xx;
            const int max_chars = 'Z' - 'A' + 1;

            if (x < max_chars)
            {
                char ch = 'A';
                ch += (char)x;
                xx = ch.ToString();
            }
            else
            {
                x -= max_chars;
                char c1 = (char)((char)'A' + (char)(x / max_chars));
                char c2 = (char)((char)'A' + (char)(x % max_chars));
                xx = c1.ToString() + c2.ToString();
            }
            return xx + y;
        }

        internal string GetQuotedCellReference(int x, int y)
        {
            return "\"" + GetCellReference(x,y) + "\"";
        }

        internal string GetMatrxDimension(ExportMatrix Matrix)
        {
            string xx;
            int x = Matrix.Width - 2;
            const int max_chars = 'Z' - 'A' + 1;

            if (x < max_chars)
            {
                char ch = 'A';
                ch += (char)x;
                xx = ch.ToString();
            }
            else
            {
                x -= max_chars;
                char c1 = (char)((char)'A' + (char)(x / max_chars));
                char c2 = (char)((char)'A' + (char)(x % max_chars));
                xx = c1.ToString() + c2.ToString();
            }

            return "<dimension ref=\"A1:" + xx + Matrix.Height + "\" />";
        }

        private void ExportOOXML(Stream Stream)
        {
            CreateRelations();
            CreateContentTypes();

            int current_style_set = 0;

            Drawing.Start();
            foreach (OoXMLSheet sh in FWorkBook.SheetList)
            {
                int styles_count = FDocStyles.Add(sh);
                sh.Export(this, current_style_set, FPageBreaks);
                current_style_set += styles_count;
            }
            Drawing.Stop();
            
            FDocStyles.Export(this);
            FAppProp.Export(this);
            FStringTable.Export(this);
            FCoreDocProp.Export(this);
            FWorkBook.Export(this);
            
            ZipArchive zip = new ZipArchive();
            zip.AddDir(FTempFolder);
            zip.SaveToStream(Stream);
            Directory.Delete(FTempFolder, true);
        }
        #endregion
    
        #region Protected Methods

        /// <inheritdoc/>
        public override bool ShowDialog()
        {
            using (Excel2007ExportForm form = new Excel2007ExportForm())
            {
                form.Init(this);
                return form.ShowDialog() == DialogResult.OK;
            }
        }

        /// <inheritdoc/>
        protected override void Start()
        {
            Directory.CreateDirectory(FTempFolder);
            Directory.CreateDirectory(FTempFolder + "/_rels");
            Directory.CreateDirectory(FTempFolder + "/docProps");
            Directory.CreateDirectory(FTempFolder + "/xl");
            Directory.CreateDirectory(FTempFolder + "/xl/_rels");
            Directory.CreateDirectory(FTempFolder + "/xl/theme");
            Directory.CreateDirectory(FTempFolder + "/xl/worksheets");
            Directory.CreateDirectory(FTempFolder + "/xl/worksheets/_rels");
            Directory.CreateDirectory(FTempFolder + "/xl/media");
        }

        /// <inheritdoc/>
        protected override void ExportPage(int pageNo)
        {
            OoXMLSheet sh;

            using (ReportPage page = GetPage(pageNo))
            {
                if (sheets.ContainsKey(page.Name))
                {
                    sh = sheets[page.Name] as OoXMLSheet;
                }
                else
                {
                    ExportMatrix matrix = new ExportMatrix();
                    if (FWysiwyg)
                      matrix.Inaccuracy = 0.5f;
                    else
                      matrix.Inaccuracy = 10;
                    matrix.PlainRich = true;
                    matrix.AreaFill = false; // true; // 
                    matrix.CropAreaFill = true;
                    matrix.Report = Report;
                    matrix.Images = true;
                    matrix.WrapText = false;
                    matrix.FullTrust = false;
                    matrix.DataOnly = DataOnly;
                    matrix.MaxCellHeight = 409 * oxmlYDivider;

                    sh = new OoXMLSheet( matrix, page.Name, sheets.Count + 1);
                    sheets[page.Name] = sh;
                    FWorkBook.AddSheet(sh);
                }

                sh.Matrix.AddPage(page);

            }
        }

        /// <inheritdoc/>
        protected override void Finish()
        {
            foreach (OoXMLSheet sh in FWorkBook.SheetList)
            {
                sh.Matrix.Prepare();
            }

            ExportOOXML(Stream);
        }

        /// <inheritdoc/>
        protected override string GetFileFilter()
        {
            return new MyRes("FileFilters").Get("XlsxFile");
        }
        #endregion

        /// <inheritdoc/>
        public override void Serialize(FRWriter writer)
        {
          base.Serialize(writer);
          writer.WriteBool("Wysiwyg", Wysiwyg);
          writer.WriteBool("PageBreaks", PageBreaks);
          writer.WriteBool("DataOnly", DataOnly);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>       
        public Excel2007Export()
        {
            FTempFolder = Config.GetTempFolder() + Path.GetRandomFileName();
            Res = new MyRes("Export,Misc");

            FStringTable = new OoXMLSharedStringTable();
            FURLTable = new OoXMLSharedURLTable();
            FDrawing = new OoXMLDrawing(this);
            FCoreDocProp = new OoXMLCoreDocumentProperties();
            FAppProp = new OoXMLApplicationProperties();
            FDocStyles = new OoXMLDocumentStyles();
            FWorkBook = new OoXMLWorkbook();
            FPageBreaks = true;            
        }
    }
}
