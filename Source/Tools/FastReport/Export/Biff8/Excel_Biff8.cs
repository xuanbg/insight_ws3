using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using FastReport.Export;
using FastReport.Utils;
using FastReport.Forms;
using System.Windows.Forms;
using FastReport;
using System.Drawing;
using FastReport.Format;

namespace BIFF8
{
    internal class OLE_Property
    {
        internal UInt32 PropertyID;
        internal UInt32 PropertyOffset;
        internal UInt32 PropertyType;
        internal object PropertyData;
    }

    internal class OLE_Stream : BIFF8_Stream
    {
        private DirectoryEntry entry;

        public OLE_Stream(CompoundDocumentHeader document_header, DirectoryEntry dir)
            : base(document_header, dir)
        {
            entry = dir;
        }

        internal void Read()
        {
            UInt16 byte_order = ReadUshort();
            UInt16 Version = ReadUshort();
            UInt32 System = ReadUint();
            byte[] UID = ReadBytes(16);
            UInt32 PropetiesCount = ReadUint();

            int up_level_position = (int) this.Position;

            for (int i = 0; i < PropetiesCount; i++)
            {
                this.Position = up_level_position;
                byte[] FormatID = ReadBytes(16);
                UInt32 Offset = ReadUint();

                up_level_position = (int) this.Position;

                this.Position = (int) Offset;

                int top_border = (int) this.Position;

                UInt32 cbSection = ReadUint();    // Размер секции в байтах
                UInt32 cProreties = ReadUint();   // Колличество Свойств в наборе

                OLE_Property[] summary_properties = new OLE_Property[cProreties];

                for (int j = 0; j < cProreties; j++)
                {
                    summary_properties[j] = new OLE_Property();
                    summary_properties[j].PropertyID = ReadUint();
                    summary_properties[j].PropertyOffset = ReadUint();
                }

                for (int j = 0; j < cProreties; j++)
                {
                    this.Position = top_border + (int) summary_properties[j].PropertyOffset;

                    summary_properties[j].PropertyType = ReadUint();
                    switch (summary_properties[j].PropertyType)
                    { 
                        case 0x0002: // uInt32
                            summary_properties[j].PropertyData = ReadUint();
                            break;

                        //case 0x1e00: // draeden proprty
                        //    ReadBytes(0x10 - sizeof(UInt32));
                        //    break;

                        //case 0x4000: // // draeden proprty
                        //    ReadBytes(0x0c - sizeof(UInt32));
                        //    break;

                        //case 0x4001: // // draeden proprty
                        //    ReadBytes(0x0c - sizeof(UInt32));
                        //    break;

                        case 0x001e: // ansi string
                            UInt32 strlen = ReadUint();
                            string value = "";
                            for (int k = 0; k < strlen; k++)
                            {
                                value += (char)ReadByte();
                            }
                            break;

                        case 0x0040: // DateTime
                            UInt32 time_low = ReadUint();
                            UInt32 time_high = ReadUint();
                            break;

                        case 0x0003: // Access rights
                            summary_properties[j].PropertyData = ReadUint();
                            break;

                        case 0x000b: // Unknown property
                            summary_properties[j].PropertyData = ReadUint();
                            break;

                        case 0x101e: // Unknown property
                            ReadBytes( 0x29 - sizeof(UInt32) );
                            break;

                        case 0x100c:
                            ReadBytes(0x23 - sizeof(UInt32));
                            break;

                        default:
                            //throw new Exception("Unimplemented property type");
                            Console.WriteLine("Unimplemented property type: " + summary_properties[j].PropertyType.ToString() );
                            break;
                    }
                    
                    int prop_size;
                    if (j + 1 < cProreties)
                    {
                        prop_size = (int)(summary_properties[j + 1].PropertyOffset - summary_properties[j].PropertyOffset);
                    }
                    else
                    {
                        prop_size = (int) (cbSection - summary_properties[j].PropertyOffset);
                    }
                }
            }
        }
    }

    internal class BIFF8_Window1
    {
        UInt16 HPos;
        UInt16 VPos;
        UInt16 Width;
        UInt16 Height;
        UInt16 Flags;
        UInt16 active_worksheet;
        UInt16 first_visible_tab;
        UInt16 selected_sheet_count;
        UInt16 worksheet_tab_width;

        internal void Read(StreamHelper stream)
        {
            HPos                    = stream.ReadUshort();
            VPos                    = stream.ReadUshort();
            Width                   = stream.ReadUshort();
            Height                  = stream.ReadUshort();
            Flags                   = stream.ReadUshort();
            active_worksheet        = stream.ReadUshort();
            first_visible_tab       = stream.ReadUshort();
            selected_sheet_count    = stream.ReadUshort();
            worksheet_tab_width     = stream.ReadUshort();
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x003d); // WINDOW1
            stream.WriteUshort(0x0012); // Payload size

            stream.WriteUshort(0x0168); // Horizontal position
            stream.WriteUshort(0x0069); // Vertical position
#if true
            Width = 15600; // Width TODO: fix it
            Height = 8190; // Height TODO: fix it
#endif
            stream.WriteUshort(Width); // Width TODO: fix it
            stream.WriteUshort(Height); // Height TODO: fix it
            stream.WriteUshort(0x0038); // Window flags
            stream.WriteUshort(0x0000); // Active worksheet
            stream.WriteUshort(0x0000); // First visible tab
            stream.WriteUshort(0x0001); // Selected sheet count
            stream.WriteUshort(0x0258); // Worksheet tab width
        }
    }

    internal class BIFF8_Font
    {
        internal UInt16      FontHeight;
        internal UInt16 Options;
        internal UInt16 ColourIdx;
        internal UInt16 FontWeight;
        internal UInt16 Escapement;
        internal byte UnderlineType;
        internal byte FontFamily;
        internal byte CharacterSet;
        internal string FontName;

        internal void Read(StreamHelper stream)
        {
            FontHeight      = stream.ReadUshort();
            Options         = stream.ReadUshort();
            ColourIdx       = stream.ReadUshort();
            FontWeight      = stream.ReadUshort();
            Escapement      = stream.ReadUshort();
            UnderlineType   = (byte) stream.ReadByte();
            FontFamily      = (byte)stream.ReadByte();
            CharacterSet    = (byte)stream.ReadByte();
            
            stream.SkipBytes(1);

            FontName = stream.ReadUnicodeString(true);
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x0031);

            ushort payload_size = (ushort)(14 + 2 + FontName.Length * 2);

            stream.WriteUshort(payload_size);

            stream.WriteUshort(FontHeight);
            stream.WriteUshort(Options);
            stream.WriteUshort(ColourIdx);
            stream.WriteUshort(FontWeight);
            stream.WriteUshort(Escapement);
            stream.WriteByte(UnderlineType);
            stream.WriteByte(FontFamily);
            stream.WriteByte(CharacterSet);

            stream.SkipBytes(1);

            stream.WriteUnicodeString(FontName, true);
        }

        public BIFF8_Font(string name, UInt16 height, UInt16 weight)
        {
            this.FontName = name;
            this.FontHeight = height;
            this.FontWeight = weight;
        }

        public BIFF8_Font(ExportIEMStyle style)
        {
            Font f = style.Font;

            this.FontName = f.Name;
            this.FontHeight = (ushort) ( 10 * f.Height);
            this.FontWeight = (ushort) ( 10 * f.SizeInPoints);
            // this.FontFamily = f.FontFamily;
            // this.ColourIdx = 0;
            this.UnderlineType = (byte) (f.Underline ? 1 : 0);
        }
    }

    internal class BIFF8_Format
    {
        UInt16 format_index;
        string format_string;

        internal BIFF8_Format(UInt16 format_index, string format_string)
        {
            this.format_index = format_index;
            this.format_string = format_string;
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x041e);

            ushort payload_size = (ushort)(2 + (ushort)stream.SizeUnicodeString(format_string, false));

            stream.WriteUshort(payload_size); // Size

            stream.WriteUshort(format_index);
            stream.WriteUnicodeString(format_string, false);
        }
    }


    internal class BIFF8_ExtenedFormat
    {
        UInt16          font_index;
        UInt16          format_index;
        UInt16          xf_type;
        byte            alignment_and_break;
        byte            rotation;
        byte            identation;
        byte            flags;
        UInt32          borders;
        UInt32          attributes;
        UInt16          attrib2;

        internal void Read(StreamHelper stream)
        {
            font_index          = stream.ReadUshort();
            format_index        = stream.ReadUshort();
            xf_type             = stream.ReadUshort();
            alignment_and_break = (byte)stream.ReadByte();
            rotation            = (byte)stream.ReadByte();
            identation          = (byte)stream.ReadByte();
            flags               = (byte)stream.ReadByte();
            borders             = stream.ReadUint();
            attributes          = stream.ReadUint();
            attrib2             = stream.ReadUshort();
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x00e0); // XF extended format
            stream.WriteUshort(0x0014); // Record size

            stream.WriteUshort(font_index);
            stream.WriteUshort(format_index);
            stream.WriteUshort(xf_type);
            stream.WriteByte(alignment_and_break);
            stream.WriteByte(rotation);
            stream.WriteByte(identation);
            stream.WriteByte(flags);
            stream.WriteUint(borders);
            stream.WriteUint(attributes);
            stream.WriteUshort(attrib2);
        }

        internal BIFF8_ExtenedFormat()
        {
            this.xf_type = 0xfff5;
            this.flags = 0xf7;
            this.alignment_and_break = 0x9;
        }

        internal BIFF8_ExtenedFormat(
            ushort font_idx,
            ushort format_idx,
            ushort type, 
            byte flags, 
            byte align )
        {
            this.font_index = font_idx;
            this.format_index = format_idx;
            this.xf_type = type;
            this.flags = flags;
            this.alignment_and_break = align;
        }

        private byte GetAngle(ExportIEMStyle EStyle)
        {
            int angle = EStyle.Angle;

            if (angle != 0 && angle <= 90)
            {
                angle = 90 + angle;
            }
            else if (angle >= 270)
            {
                angle = 360 - angle;
            }
            else
            {
                angle = 0;
            }

            return (byte) angle;
        }

        private byte GetAlignment(ExportIEMStyle EStyle)
        {
            byte result = 0; ;

            switch (EStyle.HAlign)
            { 
                case HorzAlign.Center:
                    result |= 2;
                    break;
                case HorzAlign.Justify:
                    result |= 5;
                    break;
                case HorzAlign.Left:
                    result |= 1;
                    break;
                case HorzAlign.Right:
                    result |= 3;
                    break;
            }

            switch (EStyle.VAlign)
            { 
                case VertAlign.Top:
                    result |= (0<<4);
                    break;
                case VertAlign.Center:
                    result |= (1<<4);
                    break;
                case VertAlign.Bottom:
                    result |= (2<<4);
                    break;
            }

            return result;
        }

        private byte GetBorderLineStyle(BorderLine line)
        {
            switch (line.DashStyle)
            {
                case System.Drawing.Drawing2D.DashStyle.Solid: return 1;
                case System.Drawing.Drawing2D.DashStyle.Dot: return 4;
                case System.Drawing.Drawing2D.DashStyle.Dash: return 3;
                case System.Drawing.Drawing2D.DashStyle.DashDot: return 9;
                case System.Drawing.Drawing2D.DashStyle.DashDotDot: return 0x0c;
            }
            return 0;
        }

        private uint GetBorders(ExportIEMStyle EStyle)
        {
            uint result = 0;

            if ((EStyle.Border.Lines & BorderLines.Top) == BorderLines.Top)
                result |= GetBorderLineStyle(EStyle.Border.TopLine);

            if ((EStyle.Border.Lines & BorderLines.Left) == BorderLines.Left)
                result |= (uint) (GetBorderLineStyle(EStyle.Border.LeftLine) << 8);

            if ((EStyle.Border.Lines & BorderLines.Bottom) == BorderLines.Bottom)
                result |= (uint)(GetBorderLineStyle(EStyle.Border.BottomLine) << 16);

            if ((EStyle.Border.Lines & BorderLines.Right) == BorderLines.Right)
                result |= (uint)(GetBorderLineStyle(EStyle.Border.RightLine) << 24);

            return result;
        }
        
        internal BIFF8_ExtenedFormat( 
            bool style, 
            ushort index, 
            ExportIEMStyle EStyle )
        {
            this.font_index = index;

            switch (EStyle.Format.Name)
            {
                case "General": format_index = 0; break;
                case "Date": format_index = 14; break;
                case "Currency": format_index = 7; break;
                case "Number": 
                    {
                        NumberFormat fmt = EStyle.Format as NumberFormat;
                        if(fmt.DecimalDigits == 0)
                        {
                            format_index = 1;
                        }
                        else
                        {
                            format_index = 4;
                        }
                    }
                    break;
                default: format_index = 0; break;
            }

            this.alignment_and_break = this.GetAlignment(EStyle);
            this.rotation = this.GetAngle(EStyle);
            this.identation = 0;

            if (style)
            {
                this.xf_type = 0xfff7;
                this.flags = 0x00; // 0xf7;
            }
            else
            {
                this.xf_type = 0x00;
                this.flags = 0xfc;

            }
            this.borders = this.GetBorders(EStyle);
            this.attributes = 0;
            this.attrib2 = 0;
        }
    }

    internal class BIFF8_Style
    {
        UInt16 style_attrib;
        string style_str;
        byte style_id;
        byte level;

        internal void Read(StreamHelper stream)
        {
            style_attrib = stream.ReadUshort();
            if (0 == (style_attrib & 0x8000))
            {
                // User defined style
                style_str = stream.ReadUnicodeString(false);
            }
            else
            {
                // built-in style
                style_id = (byte)stream.ReadByte();
                level = (byte)stream.ReadByte();
            }
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x0293);

            
            if (0 == (style_attrib & 0x8000))
            {
                ushort payload_size = (ushort) (2 + (ushort) stream.SizeUnicodeString(style_str, false));

                stream.WriteUshort(payload_size); // Size

                stream.WriteUshort(style_attrib);
                // User defined style
                stream.WriteUnicodeString(style_str, false);
            }
            else
            {
                stream.WriteUshort(0x0004); // Size
                stream.WriteUshort(style_attrib);
                // built-in style
                stream.WriteByte(style_id);
                stream.WriteByte(level);
            }
        }

        internal BIFF8_Style()
        {
            style_attrib = 0x8000;
            style_id = 0;
            level = 0xff;
        }

        internal BIFF8_Style(ushort idx, ExportIEMStyle style)
        {
            style_attrib = (ushort) (0x8000 + idx);
            style_id = 0;  // Normal
            level = 0xff;
        }
    }

    internal class BIFF8_SharedStringTable
    {
        UInt32 total_number_strings;
        UInt32 number_following_strings;
        ArrayList shared_strings = new ArrayList();

        internal int Read(StreamHelper stream, int RecordSize)
        {
            int total_size = (int) stream.Position;
            total_number_strings        = stream.ReadUint();
            number_following_strings    = stream.ReadUint();

            long stream_position = stream.Position;
            long next_record_ptr;

            StreamHelper virtual_stream = new StreamHelper();
            
            int bytes_to_read = RecordSize - sizeof(uint) * 2;
            int iteration = 0;

            while(true)
            {
                iteration++;
                byte[] buff = stream.ReadBytes(bytes_to_read);
                virtual_stream.WriteBytes(buff);
                next_record_ptr = stream.Position;
                UInt16 RecordID = stream.ReadUshort();
                int RecSize = stream.ReadUshort();
                if(RecordID != 0x003c)
                {
                    stream.Position -= sizeof(ushort) * 2;
                    virtual_stream.Position = 0;
                    break;
                }
#if false
                byte grBit = (byte) stream.ReadByte();
                if (grBit != 0) grBit = 0;
                bytes_to_read = RecSize - 1;
#else
                bytes_to_read = RecSize;
#endif
            }

            for (int i = 0; i < number_following_strings; i++)
            {
                shared_strings.Add(virtual_stream.ReadUnicodeString(false));
                if (virtual_stream.Position >= virtual_stream.Length) break;
            }
            total_size = (int) stream.Position - total_size;
            return total_size;
        }

        internal void Write(StreamHelper stream)
        {


            ushort payload_size = 8;

            number_following_strings = (uint) shared_strings.Count;
#if true
            bool begin = true;
            long size_position;
            for (int index = 0; index < number_following_strings; )
            {
                if (begin)
                {
                    stream.WriteUshort(0x00fc);
                    size_position = stream.Position;
                    stream.WriteUshort(0);
                    stream.WriteUint(total_number_strings);
                    stream.WriteUint(number_following_strings);
                    begin = false;
                }
                else
                {
                    stream.WriteUshort(0x003c);
                    size_position = stream.Position;
                    stream.WriteUshort(0);
                }

                while (payload_size < 8224 )
                {
                    if (index >= shared_strings.Count) break;

                    ushort string_size = (ushort)stream.SizeUnicodeString((string)shared_strings[index], false);
                    if (payload_size + string_size < 8224)
                    {
                        stream.WriteUnicodeString((string)shared_strings[index], false);
                        payload_size += string_size;
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }
                long curent_position = stream.Position;
                stream.Position = size_position;
                stream.WriteUshort(payload_size);
                payload_size = 0;
                stream.Position = curent_position;
            }
#else
            for (int i = 0; i < number_following_strings; i++)
            {
                payload_size += (ushort)stream.SizeUnicodeString( (string) shared_strings[i], false);
            }

            stream.WriteUshort(0x00fc);
            stream.WriteUshort(payload_size);

            stream.WriteUint(total_number_strings);
            stream.WriteUint(number_following_strings);
            for (int i = 0; i < number_following_strings; i++)
            {
                stream.WriteUnicodeString( (string) shared_strings[i], false);
            }
#endif

































        }

        internal void Add(string str)
        {
            shared_strings.Add(str);
        }

        internal uint Count { get { return (uint) shared_strings.Count; } }
    }

    internal abstract class BIFF8_CellData
    {
        internal long stream_position;
        internal ushort cell_data_size;

        internal abstract void Read(StreamHelper stream);
        internal abstract void Write(StreamHelper stream);
    }

    internal class BIFF8_Blank : BIFF8_CellData
    {
        UInt16 label_row_idx;
        UInt16 label_col_idx;
        UInt16 label_xf_idx;

        internal override void Read(StreamHelper stream)
        {
            stream_position = stream.Position;

            label_row_idx = stream.ReadUshort();
            label_col_idx = stream.ReadUshort();
            label_xf_idx = stream.ReadUshort();

            cell_data_size = (ushort)(stream.Position - stream_position);
        }

        internal override void Write(StreamHelper stream)
        {
            stream_position = stream.Position;

            stream.WriteUshort(0x0201); // BLANK
            stream.WriteUshort(0x0006); // record size

            stream.WriteUshort(label_row_idx);
            stream.WriteUshort(label_col_idx);
            stream.WriteUshort(label_xf_idx);

            cell_data_size = (ushort) (stream.Position - stream_position);
        }

        internal BIFF8_Blank() { }

        internal BIFF8_Blank(ushort row_idx, ushort col_idx, ushort xf_idx)
        {
            this.label_row_idx = row_idx;
            this.label_col_idx = col_idx;
            this.label_xf_idx = xf_idx;
        }
    }

    internal class BIFF8_MulBlank : BIFF8_CellData
    {
        UInt16 blank_row;
        UInt16 first_blank_column;
        UInt16 last_blank_column;
        UInt16[] fx_indexes;
        UInt16 RecordSize;

        internal override void Read(StreamHelper stream)
        {
            stream_position = stream.Position;

            blank_row = stream.ReadUshort();
            first_blank_column = stream.ReadUshort();
            int count = ((RecordSize - sizeof(UInt16) * 3) >> 1);
            fx_indexes = new ushort[count];

            for (int i2fx = 0; i2fx < count; i2fx++)
            {
                fx_indexes[i2fx] = stream.ReadUshort();
            }
            last_blank_column = stream.ReadUshort();

            if (last_blank_column - first_blank_column + 1 != count)
                throw new Exception("BIFF8_MulBlank: file structue error");

            cell_data_size = (ushort)(stream.Position - stream_position);
        }

        internal override void Write(StreamHelper stream)
        {
            stream_position = stream.Position;

            ushort rec_size = (ushort)((3 * fx_indexes.Length) << 1);

            stream.WriteUshort(0x00be); // MULBLANK
            stream.WriteUshort(rec_size); // record size

            stream.WriteUshort(blank_row);
            stream.WriteUshort(first_blank_column);

            for (int i2fx = 0; i2fx < fx_indexes.Length; i2fx++)
            {
                stream.WriteUshort(fx_indexes[i2fx]);
            }

            stream.WriteUshort(last_blank_column);

            cell_data_size = (ushort)(stream.Position - stream_position);
        }

        public BIFF8_MulBlank(UInt16 RecordSize)
        {
            this.RecordSize = RecordSize;
        }
    }

    internal class BIFF8_FloatNumber : BIFF8_CellData
    {
        ushort rw;
        ushort col;
        ushort ifxe;
        double rk;
        internal override void Read(StreamHelper stream)
        {
            stream_position = stream.Position;

            rw = stream.ReadUshort();
            col = stream.ReadUshort();
            ifxe = stream.ReadUshort();
            rk = stream.ReadDouble();
        }
        internal override void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x0203);
            stream.WriteUshort(14); // record size

            stream.WriteUshort(rw);
            stream.WriteUshort(col);
            stream.WriteUshort(ifxe);
            stream.WriteDouble(rk);
        }
        internal BIFF8_FloatNumber() { }

        //internal BIFF8_FloatNumber(ushort row_idx, ushort col_idx, ushort xf_idx, ExportIEMObject obj) 
        //{
        //    this.rw = row_idx;
        //    this.col = col_idx;
        //    this.ifxe = xf_idx;

        //    NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        //    CultureInfo culture = CultureInfo.CurrentCulture;

        //    double v;
        //    double.TryParse(obj.Text, style, culture, out v);
        //    this.rk = v;
        //}
    }

    internal class BIFF8_Number : BIFF8_CellData
    {
        UInt16 rw;
        UInt16 col;
        UInt16 ifxe;
        UInt32 rk;

        internal override void Read(StreamHelper stream)
        {
            rw = stream.ReadUshort();
            col = stream.ReadUshort();
            ifxe = stream.ReadUshort();
            rk = stream.ReadUint();
        }
        internal override void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x027e);
            stream.WriteUshort(10); // record size

            stream.WriteUshort(rw);
            stream.WriteUshort(col);
            stream.WriteUshort(ifxe);
            stream.WriteUint(rk);
        }

        internal BIFF8_Number() { }

        internal BIFF8_Number(ushort row_idx, ushort col_idx, ushort xf_idx, float obj)
        {
            rw = row_idx;
            col = col_idx;
            ifxe = xf_idx;
            rk = (UInt32)obj;
            rk <<= 2;
        }

        internal BIFF8_Number(ushort row_idx, ushort col_idx, ushort xf_idx, DateTime dt)
        {
            rw = row_idx;
            col = col_idx;
            ifxe = xf_idx;

            DateTime centuryBegin = new DateTime(1899, 12, 30);
            long elapsedTicks = dt.Ticks - centuryBegin.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

            rk = (uint)((elapsedSpan.Days << 2) | 2);

        }

        internal BIFF8_Number(ushort row_idx, ushort col_idx, ushort xf_idx, Decimal value)
        {
            rw = row_idx;
            col = col_idx;
            ifxe = xf_idx;

            long date = (long) (value * 100);
            rk = (UInt32)date;
            rk <<= 2;
            rk |= 3;
        }

    }

    internal class FIFF8_CellRange : BIFF8_CellData
    {
        UInt16 first_row_idx;
        UInt16 last_row_idx;
        UInt16 first_col_idx;
        UInt16 last_col_idx;

        internal override void Read(StreamHelper stream)
        {
            first_row_idx = stream.ReadUshort();
            last_row_idx = stream.ReadUshort();
            first_col_idx = stream.ReadUshort();
            last_col_idx = stream.ReadUshort();
        }

        internal override void Write(StreamHelper stream)
        {
             stream.WriteUshort(first_row_idx);
             stream.WriteUshort(last_row_idx);
             stream.WriteUshort(first_col_idx);
             stream.WriteUshort(last_col_idx);
        }

        internal FIFF8_CellRange() { }

        internal FIFF8_CellRange(UInt16 first_row, UInt16 last_row, UInt16 first_col, UInt16 last_col)
        {
            this.first_row_idx = first_row;
            this.last_row_idx = last_row;
            this.first_col_idx = first_col;
            this.last_col_idx = last_col;
        }
    }

    internal class BIFF8_LabelSST : BIFF8_CellData
    {
        UInt16 label_row_idx;
        UInt16 label_col_idx;
        UInt16 label_xf_idx;
        UInt32 label_sst_idx;

        internal override void Read(StreamHelper stream)
        {
            stream_position = stream.Position;
            
            label_row_idx = stream.ReadUshort();
            label_col_idx = stream.ReadUshort();
            label_xf_idx = stream.ReadUshort();
            label_sst_idx = stream.ReadUint();
        }

        internal override void Write(StreamHelper stream)
        {
            stream_position = stream.Position;

            stream.WriteUshort(0x00fd); // LABELSST
            stream.WriteUshort(0x000a); // record size

            stream.WriteUshort(label_row_idx);
            stream.WriteUshort(label_col_idx);
            stream.WriteUshort(label_xf_idx);
            stream.WriteUint(label_sst_idx);

            cell_data_size = (ushort)(stream.Position - stream_position);
        }

        internal BIFF8_LabelSST() { }

        internal BIFF8_LabelSST(ushort row_idx, ushort col_idx, ushort xf_idx, uint sst_idx)
        {
            this.label_row_idx = row_idx;
            this.label_col_idx = col_idx;
            this.label_xf_idx = xf_idx;
            this.label_sst_idx = sst_idx;
        }
    }

    internal class BIFF8_Colinfo
    { 
        UInt16 first_column;
        UInt16 last_column;
        UInt16 column_width;
        UInt16 index_to_xf_recod;
        UInt16 colinfo_options;

        internal void Read(StreamHelper stream)
        {
            first_column =      stream.ReadUshort();
            last_column =       stream.ReadUshort();
            column_width =      stream.ReadUshort();
            index_to_xf_recod = stream.ReadUshort();
            colinfo_options =   stream.ReadUshort();
            stream.SkipBytes(2);
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x007d); // COLINFO
            stream.WriteUshort(0x000c); // payload size

            stream.WriteUshort(first_column);
            stream.WriteUshort(last_column);
            stream.WriteUshort(column_width);
            stream.WriteUshort(index_to_xf_recod);
            stream.WriteUshort(colinfo_options);
            stream.SkipBytes(2);
        }

        internal BIFF8_Colinfo()
        { 
        }

        internal BIFF8_Colinfo(ushort Column, ushort Width, ushort index_xf)
        {
            first_column = Column;
            last_column = Column;
            column_width = Width;
            index_to_xf_recod = index_xf;
            colinfo_options = 0;
        }
    }

    internal class RowBlock : ArrayList
    {
        internal ArrayList cells = new ArrayList();
        UInt16[] first_cell_offsets;
        Int32 relative_offset_to_first_row;

        internal void Read(StreamHelper stream)
        {
            int current_position = (int)stream.Position;
            relative_offset_to_first_row = stream.ReadInt();
//            int count_of_rows = (int)current_sheet.last_row - (int)current_sheet.first_row; // fix me
#if true
            first_cell_offsets = stream.ReadUshorts(this.Count);
#else
                        UInt16[] first_cell_offsets = ReadUshorts(count_of_row_records);
#endif
            current_position -= relative_offset_to_first_row;
            current_position += 0x14;

            int row_index = 0;

            for (row_index = 0; row_index < first_cell_offsets.Length; )
            {
                current_position += first_cell_offsets[row_index];
                BIFF8_Row curr_row = this[row_index++] as BIFF8_Row;

                int next_position;
                if (row_index < first_cell_offsets.Length)
                    next_position = current_position + first_cell_offsets[row_index];
                else
                    next_position = int.MaxValue;

                foreach (BIFF8_CellData cell in cells)
                {
                    if (cell.stream_position >= current_position && cell.stream_position < next_position)
                    {
                        curr_row.Add(cell);
                    }
                }
            }
        }

        internal void Write(StreamHelper stream)
        {
            foreach (BIFF8_Row row in this)
            {
                row.Write(stream);
            }

            foreach (BIFF8_Row row in this)
            {
                foreach (BIFF8_CellData cell in row)
                {
                    cell.Write(stream);
                }
            }

            stream.WriteUshort(0x00d7);  // DBCELL

            ushort payload_size = (ushort)(4 + 2 * this.Count);

            stream.WriteUshort(payload_size);

            BIFF8_Row first_row = this[0] as BIFF8_Row;

            uint first_row_offset = (uint)(stream.Position - first_row.last_position);

            stream.WriteUint(first_row_offset);

            ushort cell_offset = (ushort)(this.Count * 0x10);

            foreach (BIFF8_Row row in this)
            {
                if (row.Count == 0) continue;

                BIFF8_CellData first_cell = row[0] as BIFF8_CellData;

                stream.WriteUshort(cell_offset);

                cell_offset = first_cell.cell_data_size;
            }
        }

    }

    internal class BIFF8_Row : ArrayList
    { 
        UInt16 row_index;
        UInt16 first_col_index;
        UInt16 last_col_index;
        UInt16 row_height_bitfield;
        UInt32 row_options;

        internal int last_position;

        internal void Read(StreamHelper stream)
        {
            row_index           = stream.ReadUshort();
            first_col_index     = stream.ReadUshort();
            last_col_index      = stream.ReadUshort();
            row_height_bitfield = stream.ReadUshort();
            stream.SkipBytes(4);
            row_options = stream.ReadUint();
            last_position = (int) stream.Position;
        }

        internal void Write(StreamHelper stream)
        {
            stream.WriteUshort(0x0208); // ROW
            stream.WriteUshort(0x0010); // record size

            stream.WriteUshort(row_index);
            stream.WriteUshort(first_col_index);
            stream.WriteUshort(last_col_index);
            stream.WriteUshort(row_height_bitfield);
            stream.SkipBytes(4);
            stream.WriteUint(row_options);
            last_position = (int)stream.Position;
        }

        internal BIFF8_Row() { }

        internal BIFF8_Row(
            ushort          row_index,
            ushort          first_col_index,
            ushort          last_col_index,
            ushort          row_height_bitfield, 
            uint            row_options)
        {
            this.row_index = row_index;
            this.first_col_index = first_col_index;
            this.last_col_index = last_col_index;
            this.row_height_bitfield = row_height_bitfield;
            this.row_options = row_options;
        }
    }

    internal class BIFF8_Sheet : ArrayList
    {
        // Sheet definiton in global section
        UInt32 absolute_position;
        byte sheet_state;
        byte sheet_type;
        string sheet_name;

        // Sheet index
        internal UInt32 first_row;
        internal UInt32 last_row;
        UInt32 def_col_width_ptr;
        UInt32[] db_cell_pos;

        // Dimension
        UInt32 first_used_row;
        UInt32 last_used_row;
        UInt16 first_used_column;
        UInt16 last_used_column;

        // Window 2
        UInt16 window_options;
        UInt16 first_visible_row;
        UInt16 first_visible_col;
        UInt16 grid_line_color_idx;
        UInt16 page_break_magnification;
        UInt16 normal_magnification;

        // PAGESETUP
        UInt16 paper_size;
        UInt16 scaling_factor;
        UInt16 start_page_number;
        UInt16 fit_workshit_width;
        UInt16 fit_workshit_height;
        UInt16 page_options;
        UInt16 print_horizontal_dpi;
        UInt16 print_vertical_dpi;
        double header_margin;
        double footer_margin;
        UInt16 print_copies_count;

        /* +++++++++++++++++++++++++++++++++++++++++ */
        internal UInt16 hcenter;
        internal UInt16 vcenter;
        internal double lmargin;
        internal double rmargin;
        internal double umargin;
        internal double bmargin;
        /* +++++++++++++++++++++++++++++++++++++++++ */
        internal long sheet_position_index;
        /* +++++++++++++++++++++++++++++++++++++++++ */
        internal ArrayList colinfo_list = new ArrayList();
        internal ArrayList cell_ranges = new ArrayList();

        /* ++++++++++++ Picture goes here ++++++++++++ */
        internal ArrayList pictures_list = new ArrayList();

        internal void Read_Globals(StreamHelper stream)
        {
            absolute_position  = stream.ReadUint();
            sheet_state = (byte)stream.ReadByte();
            sheet_type = (byte)stream.ReadByte();
            sheet_name  = stream.ReadUnicodeString(true);
        }

        internal void Write_Globals(StreamHelper stream)
        {
            stream.WriteUshort(0x0085);     // SHEET

            ushort payload_size = (ushort) (8 + sheet_name.Length * 2);

            stream.WriteUshort(payload_size);     // Payload size

            this.sheet_position_index = stream.Position;

            stream.WriteUint(absolute_position);
            stream.WriteByte(sheet_state);
            stream.WriteByte(sheet_type);
            stream.WriteUnicodeString(sheet_name, true);
        }

        internal void Read_Index(StreamHelper stream)
        {
            stream.SkipBytes(4); // Not used in BIFF8
            first_row = stream.ReadUint();
            last_row = stream.ReadUint();
            def_col_width_ptr = stream.ReadUint();

            if (last_row == first_row)
            {
                return;
            }

            UInt32 nm = (last_row - first_row - 1) / 32 + 1;
            db_cell_pos = new UInt32[nm];
            for (int i = 0; i < nm; i++)
            {
                db_cell_pos[i] = stream.ReadUint();
            }
        }

        internal void Write_Index(StreamHelper stream)
        {
            stream.WriteUshort(0x020b);     // INDEX
            if (last_row == first_row)
            {
                stream.WriteUshort(0x0010);     // Payload size

                stream.SkipBytes(4); // Not used in BIFF8
                stream.WriteUint(first_row);
                stream.WriteUint(last_row);
                stream.WriteUint(def_col_width_ptr);
                return;
            }
            UInt32 nm = (last_row - first_row - 1) / 32 + 1;
            stream.WriteUshort( (ushort) (0x0010 + nm * sizeof(UInt32)) );     // Payload size

            stream.SkipBytes(4); // Not used in BIFF8
            stream.WriteUint(first_row);
            stream.WriteUint(last_row);
            stream.WriteUint(def_col_width_ptr);

            if (last_row == first_row)
            {
                return;
            }

            db_cell_pos = new UInt32[nm];
            for (int i = 0; i < nm; i++)
            {
                stream.WriteUint( db_cell_pos[i] );
            }
        }

        internal void Read_PageSetup(StreamHelper stream)
        {
            paper_size = stream.ReadUshort();
            scaling_factor          = stream.ReadUshort();
            start_page_number       = stream.ReadUshort();
            fit_workshit_width      = stream.ReadUshort();
            fit_workshit_height     = stream.ReadUshort();
            page_options            = stream.ReadUshort();
            print_horizontal_dpi    = stream.ReadUshort();
            print_vertical_dpi      = stream.ReadUshort();
            header_margin           = stream.ReadDouble();
            footer_margin           = stream.ReadDouble();
            print_copies_count      = stream.ReadUshort();
        }

        internal void Write_PageSetup(StreamHelper stream)
        {
            stream.WriteUshort(0x00a1);
            stream.WriteUshort(0x0022);

            stream.WriteUshort(paper_size);
            stream.WriteUshort(scaling_factor);
            stream.WriteUshort(start_page_number);
            stream.WriteUshort(fit_workshit_width);
            stream.WriteUshort(fit_workshit_height);
            stream.WriteUshort(page_options);
            stream.WriteUshort(print_horizontal_dpi);
            stream.WriteUshort(print_vertical_dpi);
            stream.WriteDouble(header_margin);
            stream.WriteDouble(footer_margin);
            stream.WriteUshort(print_copies_count);
        }

        internal void Read_Dimension(StreamHelper stream)
        {
            first_used_row      = stream.ReadUint();
            last_used_row       = stream.ReadUint();
            first_used_column   = stream.ReadUshort();
            last_used_column    = stream.ReadUshort();
            stream.SkipBytes(2);
        }

        internal void Write_Dimension(StreamHelper stream)
        {
            stream.WriteUshort(0x0200);
            stream.WriteUshort(0x000e);

            stream.WriteUint(first_used_row);

            //int val = 0;
            //// debug
            //last_used_row = (uint) val;
            //last_used_column = (ushort) val;

            stream.WriteUint(last_used_row);
            stream.WriteUshort(first_used_column);
            stream.WriteUshort(last_used_column);
            stream.SkipBytes(2);
        }

        internal void Read_Window2(StreamHelper stream)
        {
            window_options              = stream.ReadUshort();
            first_visible_row           = stream.ReadUshort();
            first_visible_col           = stream.ReadUshort();
            grid_line_color_idx         = stream.ReadUshort();
            stream.SkipBytes(2);
            page_break_magnification    = stream.ReadUshort();
            normal_magnification        = stream.ReadUshort();
            stream.SkipBytes(4);
        }

        internal void Write_Window2(StreamHelper stream)
        {
            stream.WriteUshort(0x023e);
            stream.WriteUshort(0x0012);

            stream.WriteUshort(window_options);
            stream.WriteUshort(first_visible_row);
            stream.WriteUshort(first_visible_col);
            stream.WriteUshort(grid_line_color_idx);
            stream.SkipBytes(2);
            stream.WriteUshort(page_break_magnification);
            stream.WriteUshort(normal_magnification);
            stream.SkipBytes(4);
        }

        internal void Read_Ranges(StreamHelper stream)
        {
            UInt16 range_count_follow = stream.ReadUshort();
            for (int range_idx = 0; range_idx < range_count_follow; range_idx++)
            {
                FIFF8_CellRange single_range = new FIFF8_CellRange();
                single_range.Read(stream);
                cell_ranges.Add(single_range);
            }
        }
        internal void Write_Ranges(StreamHelper stream)
        {
            if (cell_ranges.Count != 0)
            {
                ushort payload_size = (ushort) (sizeof(UInt16) * (1 + cell_ranges.Count * 4));

                stream.WriteUshort(0x00e5);
                stream.WriteUshort(payload_size);

                stream.WriteUshort( (ushort) cell_ranges.Count);
                for (int range_idx = 0; range_idx < cell_ranges.Count; range_idx++)
                {
                    FIFF8_CellRange single_range = cell_ranges[range_idx] as FIFF8_CellRange;
                    single_range.Write(stream);
                }
            }
        }
        // Write sheet into BIFF8 stream
        internal void Write(Workbook stream)
        {
            // Update BOF pointer of SHEET record
            long store_index = stream.Position;

            stream.Position = sheet_position_index;
            stream.WriteUint((uint)store_index);
            stream.Position = store_index;

            stream.Write_BOF(0x0010); // Sheet
            
            //                stream.Write_Index(this);

            this.Write_PageSetup(stream);

            // Colinfo
            foreach (BIFF8_Colinfo column in this.colinfo_list)
            {
                column.Write(stream);
            }

            this.Write_Dimension(stream);

            if (this.Count != 0)
            {
                foreach (RowBlock row_block in this)
                {
                    row_block.Write(stream);
                }
            }

            // DRAWING
            this.Write_Drawings(stream);

            this.Write_Window2(stream);
            this.Write_Ranges(stream);

            stream.Write_EOF(); // Sheet
        }

        private void Write_Drawings(StreamHelper stream)
        {
            bool is_drawing_group = true;
            uint total_size = 0;
            long current_stream_position;
            BIFF8_ExcelDrawing first_drawing = null; 

            foreach (BIFF8_ExcelDrawing drawing in this.pictures_list)
            {
                total_size += drawing.Write(stream, is_drawing_group);
                if (is_drawing_group)
                {
                    first_drawing = drawing;
                    is_drawing_group = false;
                }
                drawing.Write_GraphicsObject(stream);
            }
            if (first_drawing != null)
            {
                current_stream_position = stream.Position;
                stream.Position = first_drawing.total_spgr_size_position;
                stream.WriteUint(total_size);
                stream.Position = first_drawing.total_dg_size_position;
                stream.WriteUint(total_size + 24);
                stream.Position = current_stream_position;
            }
        }

        internal BIFF8_Sheet()
        {
        }

        internal BIFF8_Sheet(string Name)
        {
            this.sheet_name = Name;
            this.absolute_position = 0x3a7;

            scaling_factor = 0x0064;
            start_page_number = 0x0000;
            fit_workshit_width = 0x0001;
            fit_workshit_height = 0x0001;
            page_options = 0x0482;
            print_horizontal_dpi = 300;
            print_vertical_dpi = 300;
            header_margin = 0.0;
            footer_margin = 0.0;
            print_copies_count = 1;

            window_options = 0x06b6;
            first_visible_row = 0;
            first_visible_col = 0;
            grid_line_color_idx = 0x0040;
            page_break_magnification = 0;
            normal_magnification = 0;
        }

        internal RowBlock AddRow(BIFF8_Row row)
        {
            RowBlock row_block = null;

            do {
                if (this.Count != 0) 
                {
                    row_block = this[this.Count - 1] as RowBlock;
                    if (row_block.Count < 32) break;
                }
                row_block = new RowBlock();
                this.Add(row_block);
            } while (false);

            row_block.Add(row);

            return row_block;
        }
    }

    internal class Workbook : BIFF8_Stream
    {
        private ArrayList font_list = new ArrayList();
        private ArrayList format_list = new ArrayList();
        private ArrayList xf_list = new ArrayList();
        private ArrayList styles = new ArrayList();
        private ArrayList sheet_list = new ArrayList();
        private BIFF8_SharedStringTable shared_strings = new BIFF8_SharedStringTable();
        private BIFF8_Window1 window1 = new BIFF8_Window1();
        private RowBlock row_block;
        BIFF8_ExcelDrawing drawing;
#if ! DRAWING_GROUP_DEBUG
        BIFF8_MSODrawingGroup drawing_group;
#else
        byte [] drawing_group;
#endif

        internal void Write_BOF(UInt16 type)
        {
            WriteUshort( 0x0809 );    // BOF
            WriteUshort( 0x0010 );    // Recod size

            WriteUshort( 0x0600 );    // Version
            WriteUshort( type );    // Type
            WriteUshort( 0x1faa );    // Build ID
            WriteUshort( 0x07cd );    // Build year
            WriteUint( 0x000100c1 );  // History flags
            WriteUint( 0x00000406 );  // Lovest version
        }

        internal void PrintUshortOption(UInt16 RecordID, UInt16 value)
        {
            WriteUshort(RecordID);  // RecordID
            WriteUshort(0x0002);    // Payload size
            WriteUshort(value);     // Value
        }

        private void Write_1904()
        {
            WriteUshort(0x0022); // DATE mode
            WriteUshort(0x0002); // Payload size

            WriteUshort(0x0000); // False
        }

        internal void Write_EOF()
        {
            WriteUshort(0x000a); // END OF FILE
            WriteUshort(0x0000); // No payload for this command
        }

        public void Read(DirectoryEntry entry)
        {
            if (entry.type != DirectoryEntry.DirEntryType.UseStream) throw new Exception("Entry is not User stream");

            int BytesCount = (int)entry.Size;
            int debug_size;
            int count_of_row_records = 0;

            int             Sheet_Index = -1;
            BIFF8_Sheet     current_sheet = null;
            ArrayList cells = new ArrayList();

            do
            {
                UInt16 RecordID = ReadUshort();
                int RecordSize = ReadUshort();

                BytesCount -= 4;

                debug_size = (int) this.Position;

                switch (RecordID)
                {
                    case 0x0809: // BOF
                        UInt16 version = ReadUshort();
                        UInt16 type = ReadUshort();
                        UInt16 build_id = ReadUshort();
                        UInt16 build_year = ReadUshort();
                        UInt32 history_flafs = ReadUint();
                        UInt32 lovest_ver = ReadUint();

                        if (type == 0x0010)
                        {
                            Sheet_Index++;
                            current_sheet = this.sheet_list[Sheet_Index] as BIFF8_Sheet;
                        }

                        break;

                    case 0x00e1: // INTERFACE
                        UInt16 i_codepage = ReadUshort();
                        break;

                    case 0x00c1: // MMS
                        UInt16 mms = ReadUshort();
                        break;

                    case 0x00e2: // INTERFACEEND
                        break;

                    case 0x005c: // WRITEACCESS
                        SkipBytes(RecordSize);
                        break;

                    case 0x0042:
                        UInt16 codepage = ReadUshort();
                        break;

                    case 0x0161: // Double stream flag
                        UInt16 double_stream = ReadUshort();
                        break;

                    case 0x01c0: // ????
                        SkipBytes(RecordSize);
                        break;

                    case 0x13d: // RRD
                        SkipBytes(RecordSize);
                        break;

                    case 0x009c:
                        SkipBytes(RecordSize);
                        break;

                    case 0x0019: // WINDOWPOTECT
                        UInt16 protect_val = ReadUshort();
                        break;

                    case 0x0012: // PROTCT
                        UInt16 protect_modify = ReadUshort();
                        break;

                    case 0x0013: // PASSWORD
                        UInt16 pass_hash = ReadUshort();
                        break;

                    case 0x1af: // PROTREV
                        UInt16 prot_rev = ReadUshort();
                        break;

                    case 0x01bc: // PROTREVPASS
                        UInt16 prot_rev_pass = ReadUshort();
                        break;

                    case 0x003d: // WINDOW1
                        window1.Read(this);
                        break;

                    case 0x0040: // BACKUP
                        UInt16 create_backup = ReadUshort();
                        break;

                    case 0x008d: // HIDEOBJ
                        UInt16 hide_object = ReadUshort();
                        break;

                    case 0x0022: // DATAMODE
                        UInt16 data_mode = ReadUshort();
                        break;

                    case 0x000e: // PRECISION
                        UInt16 precision = ReadUshort();
                        break;

                    case 0x01b7: // REFRESHALL
                        UInt16 refreshall = ReadUshort();
                        break;

                    case 0x00da: // BOOKBOOL is "save external values?"
                        UInt16 book_bool = ReadUshort();
                        break;

                    case 0x0031: // FONT
                        BIFF8_Font font = new BIFF8_Font( "", 0, 0);
                        font.Read(this);
                        font_list.Add(font);
                        break;

                    case 0x041e: // Format
                        UInt16 format_idx = ReadUshort();
                        string format_str = ReadUnicodeString(false);
                                                
                        BIFF8_Format format = new BIFF8_Format(format_idx, format_str);
                        format_list.Add(format);
                        break;

                    case 0x00e0: // XF extended format
                        BIFF8_ExtenedFormat xf_format = new BIFF8_ExtenedFormat();
                        xf_format.Read(this);
                        this.xf_list.Add(xf_format);
                        break;

                    case 0x87c: // Something unknown
                    case 0x87d: // Something unknown
                        SkipBytes(RecordSize);
                        break;

                    case 0x0293: // STYLE
                        BIFF8_Style style = new BIFF8_Style();
                        style.Read(this);
                        this.styles.Add(style);
                        break;

                    case 0x0892: // Style payload
                        SkipBytes(RecordSize);
                        break;

                    case 0x088e: // ???????
                        SkipBytes(RecordSize);
                        break;

                    case 0x0160: // USESELFS
                        UInt16 natural_lang_formulas = ReadUshort();
                        break;

                    case 0x0085: // SHEET
                        BIFF8_Sheet sheet = new BIFF8_Sheet();
                        sheet.Read_Globals(this);
                        this.sheet_list.Add(sheet);
                        break;

                    case 0x089a:
                    case 0x08a3:
                        SkipBytes(RecordSize);
                        break;

                    case 0x008c:
                        UInt16 interface_language = ReadUshort();
                        UInt16 system_region = ReadUshort();
                        break;

                    case 0x01c1:
                        SkipBytes(RecordSize);
                        break;

                    case 0x00eb: // MSODRAWINGGROUP
#if ! DRAWING_GROUP_DEBUG
                        drawing_group = new BIFF8_MSODrawingGroup();
                        int tmp = drawing_group.Read(this, RecordSize);
                        RecordSize = tmp;
#else
                        drawing_group = this.ReadBytes(RecordSize);

            FileStream f = new FileStream(@"C:\Users\alman\Documents\MSODRAWINGGROUP.bin", FileMode.Create);
            f.Write(drawing_group, 0, drawing_group.Length);
            f.Close();

#endif

                        break;

                    case 0x00fc: // Shared string table
                        int tmp2 = shared_strings.Read(this, RecordSize);
                        RecordSize = tmp2;
                        break;

                    case 0x00ff: // Extended SST
#if true
                        ushort strings_in_bucket = ReadUshort();
                        int payload_size = RecordSize - sizeof(ushort);
                        while (payload_size > 0)
                        {
                            uint stream_pos = ReadUint();
                            ushort sst_offset = ReadUshort();
                            SkipBytes(2);
                            payload_size -= 8;
                        }
#else
                        SkipBytes(RecordSize);
#endif
                        break;

                    case 0x0863:    // Extra Book Info
                        SkipBytes(RecordSize);
                        break;

                    case 0x0896:    // Theme
                    case 0x089B:    // COMPRESSPICTURES
                    case 0x088C:    // Compatibility Checker 12
                        SkipBytes(RecordSize);
                        break;

                    case 0x000a: // EOF
                        break;

                    // Эти данные относятся к sheet
                    case 0x020b: // INDEX
                        current_sheet.Read_Index(this);
                        break;

                    case 0x000d: //CALCMODE
                        UInt16 calc_mode = ReadUshort();
                        break;

                    case 0x000c: // CALCCOUNT
                        UInt16 calc_count = ReadUshort();
                        break;

                    case 0x000f: // REFMODE
                        UInt16 ref_mode = ReadUshort();
                        break;

                    case 0x0011: // ITERATION
                        UInt16 iteration = ReadUshort();
                        break;

                    case 0x0010: // DELTA
                        SkipBytes(RecordSize);
                        break;

                    case 0x005f: // SAVERECALC
                        UInt16 save_recalc = ReadUshort();
                        break;

                    case 0x002a: // PRINTHEADERS
                        UInt16 print_headers = ReadUshort();
                        break;

                    case 0x002b: // PRINTGRIDLINES
                        UInt16 print_grid = ReadUshort();
                        break;

                    case 0x0082: // GRIDSET (?? Stupid option)
                        UInt16 grid_set = ReadUshort();
                        break;

                    case 0x0080: // GUTS
                        UInt16 outlines_width = ReadUshort();
                        UInt16 outlines_height = ReadUshort();
                        UInt16 visible_row_levels = ReadUshort();
                        UInt16 visible_column_Levels = ReadUshort();
                        break;

                    case 0x0225:  // DEFAULTROWHEIGHT
                        UInt16 def_row_options = ReadUshort();
                        UInt16 default_row_height = ReadUshort();
                        break;

                    case 0x0081: // SHEETPR (Sheet properties)
                        UInt16 sheet_flags = ReadUshort();
                        break;

                    case 0x001b:    // HORIZONTALPAGEBREAKS:
                        ushort cbrk = ReadUshort();
                        for (int j = 0; j < cbrk; j++)
                        {
                            ushort row_of_break = ReadUshort();
                            ushort beg_col = ReadUshort();
                            ushort end_col = ReadUshort();
                        }
                        break;

                    case 0x0014: // SHEET HEADER
                        string sheet_header = "";
                        if (RecordSize != 0)
                        {
                            sheet_header = ReadUnicodeString(false);
                        }
                        break;

                    case 0x0015: // SHET FOOTER
                        string sheet_footer = "";
                        if (RecordSize != 0)
                        {
                            sheet_footer = ReadUnicodeString(false);
                        }
                        break;

                    case 0x0083: // HCENTER
                        current_sheet.hcenter = ReadUshort();
                        break;

                    case 0x0084:        // VCENTER
                        current_sheet.vcenter = ReadUshort();
                        break;

                    case 0x0026: // LMARGIN
                        current_sheet.lmargin = ReadDouble();
                        break;

                    case 0x0027: // RMARGIN
                        current_sheet.rmargin = ReadDouble();
                        break;

                    case 0x0028: // UP_MARGIN
                        current_sheet.umargin = ReadDouble();
                        break;

                    case 0x0029: // BOTTOM_MARGIN
                        current_sheet.bmargin = ReadDouble();
                        break;

                    case 0x00a1: // PAGESETUP
                        current_sheet.Read_PageSetup(this);
                        break;

                    case 0x089c: // ???
                        SkipBytes(RecordSize);
                        break;

                    case 0x004d: // internal settings for current printer
                        SkipBytes(RecordSize);
                        break;

                    case 0x0055: // DEFCOLWIDTH
                        UInt16 default_column_width = ReadUshort();
                        break;

                    case 0x007d: // COLINFO
                        BIFF8_Colinfo colinfo = new BIFF8_Colinfo();
                        colinfo.Read(this);
                        current_sheet.colinfo_list.Add(colinfo);
                        break;

                    case 0x0200: // DIMENSION
                        current_sheet.Read_Dimension(this);
                        count_of_row_records=0;
                        break;

                    case 0x0208: // ROW
                        BIFF8_Row row = new BIFF8_Row();
                        row.Read(this);
                        row_block = current_sheet.AddRow(row);
                        count_of_row_records++;
                        break;

                    case 0x00fd: // LABELSST
                        BIFF8_LabelSST label = new BIFF8_LabelSST();
                        label.Read(this);
                        row_block.cells.Add(label);
                        break;

                    case 0x0203: // NUMBER: Cell Value, Floating-Point Number
                        BIFF8_FloatNumber float_cell = new BIFF8_FloatNumber();
                        float_cell.Read(this);
                        row_block.cells.Add(float_cell);
                        break;

                    case 0x0201: // BLANK
                        BIFF8_Blank blank = new BIFF8_Blank();
                        blank.Read(this);
                        row_block.cells.Add(blank);
                        break;

                    case 0x027e:    // Number
                        BIFF8_Number number = new BIFF8_Number();
                        number.Read(this);
                        row_block.cells.Add(number);
                        break;

                    case 0x00be: // MULBLANK
                        BIFF8_MulBlank mul_blank = new BIFF8_MulBlank( (ushort) RecordSize );
                        mul_blank.Read(this);
                        row_block.cells.Add(mul_blank);
                        break;

                    case 0x00d7: // DBCELL
                        row_block = current_sheet[current_sheet.Count - 1] as RowBlock;
                        row_block.Read(this);
                        break;

                    case 0x00ec: // DRAWING
                        drawing = new BIFF8_ExcelDrawing();
                        drawing.Read(this, (UInt32)RecordSize);
                        current_sheet.pictures_list.Add(drawing);
                        break;

                    case 0x005d: // OBJ: Describes a Graphic Object
                        drawing.Read_GraphicsObject(this, (UInt32)RecordSize);
                        break;

                    case 0x023e: // WINDOW2
                        current_sheet.Read_Window2(this);
                        break;

                    case 0x088B:
                    case 0x001D:
                        SkipBytes(RecordSize);
                        break;

                    case 0x00e5: // CELL RANGE
                        current_sheet.Read_Ranges(this);
                        break;

                    case 0x0867:
                        SkipBytes(RecordSize);
                        break;
                    default:
                        Console.WriteLine(
                            string.Format("Found unparsed BIFF record: {0:X04} {1} bytes",
                            new object[] { RecordID, RecordSize })
                        );
                        SkipBytes(RecordSize);
                        break;
                }

                debug_size = (int) this.Position - debug_size;

                if (debug_size != RecordSize)
                { 
                    string.Format("Catch it");
                    throw new Exception("Item size error");
                }

                BytesCount -= RecordSize;

            } while (BytesCount > 0);

        }

        internal void Prepare(ExportMatrix export_matrix)
        {
            BIFF8_ExtenedFormat biff_style_xf = new BIFF8_ExtenedFormat(true, 0, export_matrix.StyleById(0));
            xf_list.Add(biff_style_xf);
            
            ushort default_styles_count = (ushort) xf_list.Count;

            for (ushort i = 0; i < export_matrix.StylesCount; i++)
            {
                ExportIEMStyle EStyle = export_matrix.StyleById(i); ;
                BIFF8_Font biff_font = new BIFF8_Font(EStyle);
                font_list.Add(biff_font);

                ushort idx = (ushort)(i /*+ default_styles_count*/);

                BIFF8_ExtenedFormat biff_xf = new BIFF8_ExtenedFormat(false, (ushort)(idx + default_styles_count), EStyle);
                xf_list.Add(biff_xf);

                BIFF8_Style biff_style = new BIFF8_Style(idx, EStyle);
                styles.Add(biff_style);
            }

            string name = export_matrix.Report.Pages[0].Name;

            BIFF8_Sheet sh = new BIFF8_Sheet(name);
            this.sheet_list.Add(sh);

            for (ushort x = 0; x < export_matrix.Width - 1; x++)
            {
                ushort width = (ushort)(30 * (export_matrix.XPosById(x + 1) - export_matrix.XPosById(x)));
                sh.colinfo_list.Add(new BIFF8_Colinfo(x, width, 0));
            }

            for (ushort y = 0; y < export_matrix.Height - 1; y++)
            {
                ushort row_height = (ushort)(20 * (export_matrix.YPosById(y + 1) - export_matrix.YPosById(y)));

                BIFF8_Row row = new BIFF8_Row(y, 0, (ushort)export_matrix.Width, row_height, 0x00000140);
                sh.AddRow(row);

                for (ushort x = 0; x < export_matrix.Width; x++)
                {
                    string val = "$" + x.ToString() + "$" + y.ToString(); //""; // 
                    ushort StyleIndex = 0;

                    int i = export_matrix.Cell(x, y);
                    if (i != -1)
                    {
                        int fx, fy, dx, dy;

                        export_matrix.ObjectPos(i, out fx, out fy, out dx, out dy);

                        ExportIEMObject Obj = export_matrix.ObjectById(i);
                        if (Obj.Counter < dy)
                        {
                            StyleIndex = (ushort)(Obj.StyleIndex + default_styles_count);
                            if (Obj.IsText)
                            {
                                BIFF8_CellData cell;

                                if (Obj.IsDateTime)
                                {
                                    DateTime dt = (DateTime)Obj.Value;
                                    cell = new BIFF8_Number(y, x, StyleIndex, dt);
                                }
                                else if (Obj.IsNumeric)
                                {
                                    Decimal num = (Decimal) Obj.Value;
                                    cell = new BIFF8_Number(y,x, StyleIndex, num);
                                }
                                else
                                {
                                    val = ExportUtils.XmlString(Obj.Text, Obj.HtmlTags);

                                    cell = new BIFF8_LabelSST(y, x, StyleIndex, shared_strings.Count);
                                    shared_strings.Add(val);
                                }
                                row.Add(cell);
                            }
                            else
                            {
                                if (Obj.Width > 0 && Obj.Counter == 0)
                                {
                                    // Место для оптимизации картинок
                                    if (drawing_group == null) drawing_group = new BIFF8_MSODrawingGroup();
                                    BIFF8_MSODrawingRecord rec = new BIFF8_MSODrawingRecord();
                                    rec.LoadPicture(Obj, drawing_group.Count);
                                    drawing_group.Add(rec);

                                    drawing = new BIFF8_ExcelDrawing();
                                    drawing.AddPicureToSheet(Obj, sh.pictures_list.Count, fx, fy, dx, dy);
                                    sh.pictures_list.Add(drawing);
                                }
                            }
                            Obj.Counter++;
                            if ((Obj.Counter == dy) && (dx > 1 || dy > 1))
                            {
                                FIFF8_CellRange single_range = new FIFF8_CellRange((ushort)fy,(ushort)(fy+dy-1),(ushort)fx,(ushort)(fx+dx-1));
                                sh.cell_ranges.Add(single_range);
                            }
                        }
                    }
                    else
                    {
                        BIFF8_CellData cell = new BIFF8_Blank(y, x, StyleIndex);
                        row.Add(cell);
                    }
                }
            }

            base.SetLength(0);

            this.Write_BOF( 0x0005 ); // Workbook globals
            this.window1.Write(this);
            this.Write_1904();
    
            // Skip many records at this point

            // Skip many records at this point

            foreach (BIFF8_Font font in this.font_list) font.Write(this);
            foreach (BIFF8_ExtenedFormat xf in this.xf_list) xf.Write(this);

            // Skip many records at this point

            foreach (BIFF8_Style style in this.styles) style.Write(this);

            // Skip many records at this point

            foreach (BIFF8_Sheet sheet in this.sheet_list)
            {
                sheet.Write_Globals(this);
            }
    // Skip some records at this point

#if ! DRAWING_GROUP_DEBUG
            if (drawing_group != null) drawing_group.Write(this);
#else
            this.WriteUshort(0x00eb); // MSODRAWINGGROUP
            this.WriteUshort((ushort)drawing_group.Length); // 
            this.WriteBytes(drawing_group);
#endif
            //shared_strings
            shared_strings.Write(this);

    // Skip some records at this point
            Write_EOF();

            // ... А теперь пишем sheets
            foreach (BIFF8_Sheet sheet in this.sheet_list)
            {
                sheet.Write(this);
            }

            int eof = -1;
            this.StreamDirEntry.BOF = (uint)eof;
            this.StreamDirEntry.Size = (uint) this.Length;

            this.Position = 0;
        }

        public Workbook(CompoundDocumentHeader document_header, DirectoryEntry dir)
            : base(document_header, dir)
        {
        }

        internal void Write(FileStream f)
        {
            DirectoryEntry dir = base.StreamDirEntry;
        }
    }

    /// <summary>
    /// Excel 2003 export class
    /// </summary>
    public class Excel2003Document : ExportBase
    {
        ExportMatrix                FMatrix;
        //---------------------------------------------
        CompoundDocumentHeader      hdr;
        DirectoryStream             root_dir;
        Workbook                    workbook;
        OLE_Stream                  summary_info;
        OLE_Stream                  doc_summary_info;

        public void Read(string FileName)
        {
            FileStream f = File.Open(FileName, System.IO.FileMode.Open);

            hdr = new CompoundDocumentHeader(f);

            hdr.Read();

            root_dir = new DirectoryStream(hdr);
            root_dir.Read(hdr.Dir, hdr);

            Console.WriteLine(string.Format("{0,-35} {1,-12} {2,8} {3,5} {4,4} {5,4} {6,4}", new object[] { 
                        "Name", 
                        "Type", 
                        "Size", 
                        "BOF",
                        "Root", "Left", "Rght"}));
            foreach (DirectoryEntry entry in root_dir)
            {
                if (entry.type == DirectoryEntry.DirEntryType.Empty) continue;

                Console.WriteLine(string.Format("{0,-35} {1,-12} {2,8} {3,5} {4,4} {5,4} {6,4}", 
                    new object[] { 
                        entry.entry_name, 
                        entry.type, 
                        entry.Size, 
                        entry.BOF,
                        entry.RootDirID,
                        entry.LeftChildDirID,
                        entry.RightChildDirID
                    }));

                switch (entry.entry_name)
                { 
                    case "Root Entry":
                        hdr.ReadShortStreamContainer(entry);
                        break;

                    case "Workbook":
                        workbook = new Workbook(hdr, entry);
                        workbook.Read(entry);
                        break;

                    case "SummaryInformation":
                        summary_info = new OLE_Stream(hdr, entry);
                        //summary_info.Read();
                        break;

                    case "DocumentSummaryInformation":
                        doc_summary_info = new OLE_Stream(hdr, entry);
                        //doc_summary_info.Read();
                        break;

                    case "CompObj":
                        continue;

                    default:
                        throw new Exception("Unknown stream");
                }
            }
            f.Close();
        }

        private void Prepare()
        {
            hdr.Reset();
            root_dir.Reset();

            workbook.Prepare(FMatrix);

            workbook.Write();
            summary_info.Write();
            doc_summary_info.Write();


            DirectoryEntry root = root_dir.Add("Root Entry");
            root_dir.Add("Workbook", workbook, -1, -1);
            root_dir.Add("SummaryInformation", summary_info, 1, -1);
            root_dir.Add("DocumentSummaryInformation", doc_summary_info, 2, -1);
            root_dir.Write(hdr.Dir, hdr);

            hdr.Write();
        }

        internal void Write(string FileName)
        {
            this.Prepare();

            FileStream f = File.Open(FileName, System.IO.FileMode.Create, FileAccess.ReadWrite);
            hdr.FinalWriteToStream(f);
            f.Close();
        }

        public Excel2003Document()
        { 
        }

        internal void Create()
        {
            hdr = new CompoundDocumentHeader();

            root_dir = new DirectoryStream(hdr);

            DirectoryEntry workbook_entry = new DirectoryEntry("Workbook", DirectoryEntry.DirEntryType.UseStream);
            workbook = new Workbook(hdr, workbook_entry);

            DirectoryEntry summary_entry = new DirectoryEntry("SummaryInformation", DirectoryEntry.DirEntryType.UseStream);
            summary_info = new OLE_Stream(hdr, summary_entry);

            DirectoryEntry doc_summary_entry = new DirectoryEntry("DocumentSummaryInformation", DirectoryEntry.DirEntryType.UseStream);
            doc_summary_info = new OLE_Stream(hdr, doc_summary_entry);
        }

        #region Protected Methods

        /// <inheritdoc/>
        public override bool ShowDialog()
        {
            using (Excel2003ExportForm form = new Excel2003ExportForm())
            {
                form.Init(this);
                return form.ShowDialog() == DialogResult.OK;
            }
        }

        /// <inheritdoc/>
        protected override void Start()
        {
            FMatrix = new ExportMatrix();
            FMatrix.Inaccuracy = 0.5f;
            FMatrix.PlainRich = true;
            FMatrix.AreaFill = false; // true; // 
            FMatrix.CropAreaFill = true;
            FMatrix.Report = Report;
            FMatrix.Images = true;
            FMatrix.WrapText = false;
            FMatrix.FullTrust = false;
            FMatrix.MaxCellHeight = 409 * 1;
        }

        /// <inheritdoc/>
        protected override void ExportPage(int pageNo)
        {
            using (ReportPage page = GetPage(pageNo))
            {
                FMatrix.AddPage(page);
            }
        }

        /// <inheritdoc/>
        protected override void Finish()
        {
            FMatrix.Prepare();
            
            this.Create();

            this.Prepare();

            hdr.FinalWriteToStream(Stream);
        }

        /// <inheritdoc/>
        protected override string GetFileFilter()
        {
            return new MyRes("FileFilters").Get("XlsFile");
        }

        /// <inheritdoc/>
        public override void Serialize(FRWriter writer)
        {
            base.Serialize(writer);
            //writer.WriteBool("Wysiwyg", Wysiwyg);
            //writer.WriteBool("PageBreaks", PageBreaks);
        }
        #endregion

    }
}
