using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

namespace BIFF8
{
    public /*abstract*/ class StreamHelper : MemoryStream
    {
        internal void SkipBytes(int count)
        {
            base.Position = base.Position + count;
        }

        public ushort ReadUshort()
        {
            byte hi, low;
            low = (byte) ReadByte();
            hi = (byte) ReadByte();
            return (ushort)((int)low + (int)(hi << 8));
        }
        public uint ReadUint()
        {
            uint b0 = (uint)ReadByte();
            uint b1 = (uint)ReadByte();
            uint b2 = (uint)ReadByte();
            uint b3 = (uint)ReadByte();

            uint result = (b3 << 24) + (b2 << 16) + (b1 << 8) +  b0;

            return result;
        }
        public int ReadInt()
        {
            int b0 = ReadByte();
            int b1 = ReadByte();
            int b2 = ReadByte();
            int b3 = ReadByte();

            int result = (b3 << 24) + (b2 << 16) + (b1 << 8) + b0;


            return result;
                
        }
        public double ReadDouble()
        {
            double [] result = new double[1];
            byte[] bytes = new byte[8];
            for (int i = 0; i < 8; i++) bytes[i] = (byte)ReadByte();

            IntPtr ptr = Marshal.AllocHGlobal( 8 );
            Marshal.Copy(bytes, 0, ptr, 8);
            Marshal.Copy(ptr, result, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return result[0];
        }
        public string ReadUnicodeString(bool short_len)
        {
            string str = "";

            UInt16 Char_Count = short_len ? (UInt16) ReadByte() : ReadUshort();
            byte options = (byte) ReadByte();
            if ((options & 0x1) != 0)
            {
                for (int i = 0; i < Char_Count; i++)
                {
                    char ch = (char)ReadUshort();
                    str += ch;
                }
            }
            else
            {
                for (int i = 0; i < Char_Count; i++)
                {
                    char ch = (char)ReadByte();
                    str += ch;
                }
            }
            return str;
        }
        internal void WriteUnicodeString(string FontName, bool short_len)
        {
            int str_len = FontName.Length;
            if (short_len)
            {
                WriteByte( (byte) str_len );
            }
            else
            {
                WriteUshort((ushort)str_len);
            }

            WriteByte( (byte) 0x001 ); // Uncompressed
            for( int i=0; i<str_len; i++)
            {
                char ch = FontName[i];
                WriteUshort( (ushort) ch );
            }
        }

        internal int SizeUnicodeString(string FontName, bool short_len)
        { 
            int str_len = FontName.Length;

            str_len *= 2; // uncompressed

            return str_len + (short_len ? 2 : 3);
        }

        public byte[] ReadBytes(int count)
        {
            byte[] result = new byte[count];
            for (int i = 0; i < count; i++) result[i] = (byte) ReadByte();
            return result;
        }
        public ushort[] ReadUshorts(int count)
        {
            ushort[] result = new ushort[count];
            for (int i = 0; i < count; i++) result[i] = ReadUshort();
            return result;
        }
        public int[] ReadInts(int count)
        {
            int[] result = new int[count];
            for (int i = 0; i < count; i++) result[i] = ReadInt();
            return result;
        }
        public void WriteUshort(ushort value)
        {
            byte lo = (byte)(value);
            WriteByte(lo);
            byte hi = (byte)(value >> 8);
            WriteByte(hi);
        }
        public void WriteUint(uint value)
        {
            byte b0 = (byte)value;
            byte b1 = (byte)(value >> 8);
            byte b2 = (byte)(value >> 16);
            byte b3 = (byte)(value >> 24);

            WriteByte(b0);
            WriteByte(b1);
            WriteByte(b2);
            WriteByte(b3);
        }
        public void WriteInt(int value)
        {
            byte b0 = (byte)value;
            byte b1 = (byte)(value >> 8);
            byte b2 = (byte)(value >> 16);
            byte b3 = (byte)(value >> 24);

            WriteByte(b0);
            WriteByte(b1);
            WriteByte(b2);
            WriteByte(b3);
        }
        public void WriteDouble(double value) 
        { 
            double[] source = new double[1];
            source[0] = value;
            byte[] bytes = new byte[8];

            IntPtr ptr = Marshal.AllocHGlobal(8);
            Marshal.Copy(source, 0, ptr, 1);
            Marshal.Copy(ptr, bytes, 0, bytes.Length);
            Marshal.FreeHGlobal(ptr);

            for (int i = 0; i < 8; i++) WriteByte( bytes[i] );


        }
        public void WriteBytes(byte[] values)
        {
            for (int i = 0; i < values.Length; i++) WriteByte(values[i]);
        }
        public void WriteBytes(byte[] values, int start_index, int count)
        {
            for (int i = 0; i < count; i++) WriteByte(values[start_index+i]);
        }

        public void WriteInts(int[] values)
        {
            for (int i = 0; i < values.Length; i++) WriteInt(values[i]);
        }

        public override void WriteByte(byte value)
        {
//            if (Position == 0x1040) base.WriteByte(value); else

            base.WriteByte(value);
        }
    }


    internal class DirectoryEntry
    {
        internal enum DirEntryType
        {
            // Type of the entry: 
            Empty = 0x00, // 00H = Empty 
            UserStorage = 0x01, // 01H = User storage 
            UseStream = 0x02, // 02H = User stream 
            LockBytes = 0x03, // 03H = LockBytes (unknown)
            Property = 0x04, // 04H = Property (unknown)
            RootStorage = 0x05  // 05H = Root storage
        }


#if false
        // 0 64
        // Character array of the name of the entry, always 16-bit Unicode characters, with trailing
        //zero character (results in a maximum name length of 31 characters)
        byte[] name = new byte[64];

        //64 2 
        //Size of the used area of the character buffer of the name (not character count), including
        //the trailing zero character (e.g. 12 for a name with 5 characters: (5+1)∙2 = 12)
        ushort name_size;
#else
        public string entry_name;
#endif
        //  66 1 
        // Type of the entry: 00H = Empty 03H = LockBytes (unknown)
        // 01H = User storage 04H = Property (unknown)
        // 02H = User stream 05H = Root storage
        internal DirEntryType type;

        // 67 1 Node colour of the entry: 00H = Red 01H = Black
        internal byte Colour;

        // 68 4 DirID of the left child node inside the red-black tree of all direct members of the parent
        // storage (if this entry is a user storage or stream, ➜7.1), –1 if there is no left child
        internal int LeftChildDirID;

        //72 4 DirID of the right child node inside the red-black tree of all direct members of the parent
        //storage (if this entry is a user storage or stream, ➜7.1), –1 if there is no right child
        internal int RightChildDirID;

        // 76 4 DirID of the root node entry of the red-black tree of all storage members (if this entry is a
        //storage, ➜7.1), –1 otherwise
        internal int RootDirID;

        // 80 16 Unique identifier, if this is a storage (not of interest in the following, may be all 0)
        byte[] UID = new byte[16];

        // 96 4 User flags (not of interest in the following, may be all 0)
        uint UserFlags;

        // 100 8 Time stamp of creation of this entry (➜7.2.3). Most implementations do not write a valid
        // time stamp, but fill up this space with zero bytes.
        byte [] CreationTime = new byte[8];

        // 108 8 Time stamp of last modification of this entry (➜7.2.3). Most implementations do not write
        // a valid time stamp, but fill up this space with zero bytes.
        byte [] ModificationTime = new byte[8];

        // 116 4 SecID of first sector or short-sector, if this entry refers to a stream (➜7.2.2), SecID of first
        // sector of the short-stream container stream (➜6.1), if this is the root storage entry, 0
        // otherwise
        public UInt32 BOF;

        //120 4 Total stream size in bytes, if this entry refers to a stream (➜7.2.2), total size of the shortstream
        //container stream (➜6.1), if this is the root storage entry, 0 otherwise
        public UInt32 Size;

        // 124 4 Not used
        public void Read(StreamHelper File)
        {
            entry_name = "";
            ushort name_size;

            for (int i = 0; i < 32; i++)
            {
                char ch = (char) File.ReadUshort();
                if(ch != '\0') entry_name += ch;
            }
            name_size = File.ReadUshort();

            type = (DirEntryType)File.ReadByte();
            Colour = (byte) File.ReadByte();
            LeftChildDirID = File.ReadInt();
            RightChildDirID = File.ReadInt();
            RootDirID = File.ReadInt();
            UID = File.ReadBytes(UID.Length);
            UserFlags = File.ReadUint();
            CreationTime = File.ReadBytes(CreationTime.Length);
            ModificationTime = File.ReadBytes(ModificationTime.Length);
            BOF = File.ReadUint();
            Size = File.ReadUint();
            File.SkipBytes(sizeof(UInt32));
        }

        public DirectoryEntry()
        {
            Colour = 0x00; // Black
            LeftChildDirID = -1;
            RightChildDirID = -1;
            RootDirID = -1;
            UID = new byte[16];
            // 96 4 User flags (not of interest in the following, may be all 0)
            UserFlags = 0;
            // 100 8 Time stamp of creation of this entry (➜7.2.3). Most implementations do not write a valid
            // time stamp, but fill up this space with zero bytes.
            CreationTime = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            // 108 8 Time stamp of last modification of this entry (➜7.2.3). Most implementations do not write
            // a valid time stamp, but fill up this space with zero bytes.
            ModificationTime = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            // Fixed empry values
            this.BOF = 0;
            this.Size = 0;
            this.type = DirEntryType.Empty;
            this.entry_name = "";
        }

        public DirectoryEntry(string name, DirEntryType type) : this()
        {
            

            this.type = type;
            this.entry_name = name;
        }

        internal void Write(StreamHelper File)
        {
            int name_len = entry_name.Length;
            if (name_len > 32) name_len = 32;
            for (int i = 0; i < name_len; i++)
            {
                char ch = entry_name[i];
                File.WriteUshort( ch );
            }
            for (int i = name_len; i < 32; i++)
            {
                File.WriteUshort( 0 );
            }
            File.WriteUshort((ushort)  ( 2 + name_len * 2) );

            File.WriteByte( (byte) type);
            File.WriteByte(Colour);
            File.WriteInt(LeftChildDirID);
            File.WriteInt(RightChildDirID);
            File.WriteInt(RootDirID);
            File.WriteBytes(UID);
            File.WriteUint(UserFlags);
            File.WriteBytes(CreationTime);
            File.WriteBytes(ModificationTime);
            File.WriteUint(BOF);
            File.WriteUint(Size);
            File.SkipBytes(sizeof(UInt32));
        }
    }
    
    public class CompoundDocumentHeader : StreamHelper
    {
        byte []             ID = new byte[8];			// Must be: D0 CF 11 E0 A1 B1 1A E1
        byte []             UID = new byte[16];
        ushort              Revision;			        // Might be: 3E
        ushort              Version;			        // Might be: 03
        ushort              ByteOrder;			        // Little-Endian: FE FF; Big-Endian: FF FE
        ushort              SecSize;			        // Sector size is 2**SecSize bytes
        ushort              ShortSecSize;		        // Short sector size is 2**ShortSecSize bytes
//        fixed byte NotUsed1[10];
        uint                SATCount;			        // Count of sectors used for the SAT
        public int          Dir;				        // First sector of the directory stream
//        fixed byte NotUsed2[4];
        public UInt32       MinStreamSize;		        // Streams that have sizes less than this value are stored in the short stream
        int                 SSAT;				        // First sector of the SSAT
        uint                SSATCount;			        // Count of sectors used for the SSAT	
        int                 MSAT;				        // First sector of the MSAT	
        uint                MSATCount;			        // Count of sectors used for the MSAT
        int []              MSATSectors = new int[109];	// First 109 SecID values in the MSAT

        ArrayList SAT = new ArrayList();
        ArrayList ShortSAT = new ArrayList();
        
        uint TotalAllocatedSectors;
        uint TotalAllocatedShortSectors;

      
        internal BIFF8_Container ShortStreamContainer;

        public int SectorSize       { get { return 1 << SecSize; } }
        public int ShortSectorSize  { get { return 1 << ShortSecSize; } }

        public int SectorOffset(int index) 
        { 
            int a =  512 + index * SectorSize;
            return a;
        }

        public int ShortSectorOffset(int index)
        {
            int a = index * ShortSectorSize;
            return a;
        }

        public int NextSector(int index) { return (int) SAT[index]; }
        public int NextShortSector(int index) { return (int)ShortSAT[index];  }

        public void Read()
        {
            ID = ReadBytes(ID.Length);
            UID = ReadBytes(UID.Length);
            Revision = ReadUshort();
            Version = ReadUshort();
            ByteOrder = ReadUshort();
            SecSize = ReadUshort();
            ShortSecSize = ReadUshort();
            SkipBytes(10);
            SATCount = ReadUint();
            Dir = ReadInt();
            SkipBytes(4);
            MinStreamSize = ReadUint();
            SSAT = ReadInt();
            SSATCount = ReadUint();
            MSAT = ReadInt();
            MSATCount = ReadUint();
            MSATSectors = ReadInts(MSATSectors.Length);

            // Read SAT into memory
            for (int i = 0; i < SATCount; i++)
            {
                if (i >= 190) throw new Exception("Huge SAT not implemented");
                int SAT_Sector = MSATSectors[i];
                int Position = SectorOffset(SAT_Sector); 
                this.Position = Position;
                SAT.AddRange( new ArrayList(ReadInts(this.SectorSize / sizeof(UInt32))) );
            }

            // Read SSAT into memory
            int SSAT_Sector = SSAT;
            for (int i = 0; i < SSATCount; i++)
            {
                int Position = SectorOffset(SSAT_Sector);
                this.Position = Position;
                ShortSAT.AddRange(new ArrayList(ReadInts(this.SectorSize / sizeof(UInt32))));
                SSAT_Sector = NextSector(SSAT_Sector);
            }
        }

        public void Write()
        {
            this.Position = 0;

            WriteBytes(ID);
            WriteBytes(UID);
            WriteUshort(Revision);
            WriteUshort(Version);
            WriteUshort(ByteOrder);
            WriteUshort(SecSize);
            WriteUshort(ShortSecSize);
            SkipBytes(10);
            WriteUint(SATCount);
            WriteInt(Dir);
            SkipBytes(4);
            WriteUint(MinStreamSize);
            WriteInt(SSAT);
            WriteUint(SSATCount);
            WriteInt(MSAT);
            WriteUint(MSATCount);
            WriteInts(MSATSectors);


            // Write SAT from memory
            for (int i = 0; i < SATCount; i++)
            {
                if (i >= 190) throw new Exception("Huge SAT not implemented");

                int         SAT_Sector  = this.MSATSectors[i];

                this.Position = SectorOffset(SAT_Sector);

                for (int j = 0; j < this.SectorSize / sizeof(UInt32); j++)
                {
                    int value = (int)SAT[i * this.SectorSize / sizeof(UInt32) + j];
                    this.WriteInt( value );
                }
            }

            // Write SSAT from memory

            int SSATEntriesPerSector = this.SectorSize / sizeof(UInt32);
            int SSAT_Sector = SSAT;
            for (int i = 0; i < SSATCount; )
            {
                this.Position = SectorOffset(SSAT_Sector);

                for (int j = 0; j < SSATEntriesPerSector; j++)
                {
                    int value = (int)ShortSAT[i * this.SectorSize + j];
                    this.WriteInt(value);
                }

                i++;

                if (i == SSATCount) continue;

                SSAT_Sector = this.AllocateSector(SSAT_Sector);
            }
        }

        public void Reset()
        {
            ID = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 };
            Revision = 0x003e;
            Version = 0x0003;
            ByteOrder = 0xfffe;
            SecSize = 0x0009;
            ShortSecSize = 0x0006;
            SATCount = 0;
            MinStreamSize = 0x00001000;
            SATCount = 0;
            MSAT = -2;
            MSATCount = 0;

            // Reset SAT table
            this.SAT.Clear();

            // Reset SSAT table
            SSATCount = 0;
            this.ShortSAT.Clear();

            // Reset MSAT table
            for (int i = 0; i < MSATSectors.Length; i++)
            {
                MSATSectors[i] = -1;
            }

            this.TotalAllocatedSectors = 0;
            this.TotalAllocatedShortSectors = 0;

            this.ShortStreamContainer.SetLength(0);

#if true
            Dir = AllocateSector();
            SSAT = AllocateSector();
#else
            SSAT = -1;
            Dir = -1;
#endif
        }

        public CompoundDocumentHeader(FileStream f)
            : base()
        { 
            byte [] temporary_array = new byte[f.Length];
            f.Read(temporary_array, 0, (int) f.Length);
            this.Write(temporary_array, 0, (int) f.Length);
            this.Position = 0;
        }

        public CompoundDocumentHeader()
            : base()
        {

            ShortStreamContainer = new BIFF8_Container();
            Reset();
            this.Position = 0;
        }

        internal void FinalWriteToStream(Stream f)
        {
            this.Position = 0;
            byte[] temporary_array = new byte[this.Length];
            this.Read(temporary_array, 0, (int) this.Length);
            f.Write(temporary_array, 0, temporary_array.Length);
        }

        internal void SetCurentSector(int Dir)
        {
            base.Position = SectorOffset(Dir);
        }

        internal void ReadShortStreamContainer(DirectoryEntry entry)
        {
            int StorePosition = (int) this.Position;

            int SectorOfContainer;
            
            ShortStreamContainer = new BIFF8_Container();

            int idx = 0;

            for
                (
                SectorOfContainer = (int)entry.BOF;
                SectorOfContainer >= 0;
                SectorOfContainer = this.NextSector(SectorOfContainer)
                )
            {
                this.SetCurentSector(SectorOfContainer);

                for (int i = 0; i < this.SectorSize && idx < entry.Size; i++)
                {
                    ShortStreamContainer.WriteByte( (byte) ReadByte() );
                }
            }

            this.Position = StorePosition;
        }

        internal int WriteShortStreamContainer()
        {
            int StorePosition = (int)this.Position;

            int FirstSectorOfContainer = this.AllocateSector();

            int ContainerSize = (int) ShortStreamContainer.Length;
            ShortStreamContainer.Position = 0;

            for (
                int SectorOfContainer = (int)FirstSectorOfContainer;
                ContainerSize > 0;
                SectorOfContainer = this.AllocateSector(SectorOfContainer)
                )
            {
                this.SetCurentSector(SectorOfContainer);
                for (int i = 0; i < this.SectorSize; i++)
                {
                    byte value = 0xff;
                    if (ShortStreamContainer.Position < ShortStreamContainer.Length)
                    {
                        value = (byte) ShortStreamContainer.ReadByte();
                    }
                    this.WriteByte(value);
                }
                ContainerSize -= this.SectorSize;
                if (ContainerSize <= 0) break;
            }

            this.Position = StorePosition;

            return FirstSectorOfContainer;
        }

        internal int AllocateSector()
        {
            int new_sector;

            new_sector = SAT.IndexOf(-1);
            if (new_sector == -1)
            {
                AllocateSATSector();
                new_sector = SAT.IndexOf(-1);
                if (new_sector == -1)
                {
                    throw new Exception("Unable allocate SAT sector");
                }
                SAT[new_sector] = -2;
                int self = SAT.IndexOf(-1);
                SAT[self] = -3;
                MSATSectors[SATCount] = self;
                SATCount++;
            }

            TotalAllocatedSectors++;

            SAT[new_sector] = -2;
            return new_sector;
        }

        internal int AllocateSector(int PrevSector)
        {
            int Sector = AllocateSector();
            SAT[PrevSector] = Sector;
            return Sector;
        }

        internal int AllocateShortSector()
        {
            int new_sector;

            new_sector = ShortSAT.IndexOf(-1);
            if (new_sector == -1)
            {
                AllocateSSATSector();
                new_sector = ShortSAT.IndexOf(-1);
                if (new_sector == -1)
                {
                    throw new Exception("Unable allocte SSAT sector");
                }
            }

            TotalAllocatedShortSectors++;

            ShortSAT[new_sector] = -2;
            return new_sector;
        }

        internal int AllocateShortSector(int PrevSector)
        {
            int Sector = AllocateShortSector();
            ShortSAT[PrevSector] = Sector;
            return Sector;
        }

        private void AllocateSATSector()
        {
            if (SATCount > 109)
            {
                throw new Exception("Large MSAT does not implemented yet");
            }

            int SATEntriesPerSector = this.SectorSize / sizeof(UInt32);

            ArrayList sat_new_sectors = new ArrayList();
#if false // BIG DEAL
            sat_new_sectors.Add(-3); // Sector is used by SAT itself
            for (int i = 1; i < SATEntriesPerSector; i++)
#else
            for (int i = 0; i < SATEntriesPerSector; i++)
#endif
            {
                sat_new_sectors.Add(-1);
            }

            SAT.AddRange( sat_new_sectors );

            int local = SAT.Count / SATEntriesPerSector;

//            MSATSectors[SATCount] = (int) 
            TotalAllocatedSectors++;

        }

        private void AllocateSSATSector()
        {
            int SSATEntriesPerSector = this.SectorSize / sizeof(UInt32);

            ArrayList ssat_new_sectors = new ArrayList();
//            ssat_new_sectors.Add(-3); // Sector is used by SAT itself
            for (int i = 0; i < SSATEntriesPerSector; i++)
            {
                ssat_new_sectors.Add(-1);
            }

            this.
            ShortSAT.AddRange(ssat_new_sectors);

            int local = ShortSAT.Count / SSATEntriesPerSector;

            SSATCount++;
        }

//        internal int AllocateStream(int WriteQueueLength, bool non_packing_stream)
//        {
//            int BOF;
//            int Sector;
////            int WriteQueueLength = Container.Length;

//            if (WriteQueueLength == 0) return -1;

//            if ( WriteQueueLength >= this.MinStreamSize || non_packing_stream )
//            {
//                BOF = Sector = this.AllocateSector();

//                //            int SourceCopyIndex = 0;

//                do
//                {

//                    int CopyCount = (WriteQueueLength < this.SectorSize) ? WriteQueueLength : this.SectorSize;

//                    //                this.SetCurentSector(Sector);
//                    //                this.WriteBytes(Container, SourceCopyIndex, CopyCount);

//                    WriteQueueLength -= CopyCount;

//                    if (WriteQueueLength == 0) break;

//                    Sector = this.AllocateSector(Sector);

//                } while (true);
//            }
//            else
//            {
//                BOF = Sector = AllocateShortSector();

//                //            int SourceCopyIndex = 0;

//                do
//                {

//                    int CopyCount = (WriteQueueLength < this.ShortSectorSize) ? WriteQueueLength : this.ShortSectorSize;

//                    //                this.SetCurentSector(Sector);
//                    //                this.WriteBytes(Container, SourceCopyIndex, CopyCount);

//                    WriteQueueLength -= CopyCount;

//                    if (WriteQueueLength == 0) break;

//                    Sector = this.AllocateShortSector(Sector);

//                } while (true);
//            }

//            return BOF;
//        }
    }

    public class DirectoryStream : ArrayList
    {
        CompoundDocumentHeader DocumentHeader;

        internal new DirectoryEntry this[int index]
        {
            get
            {
                return base[index] as DirectoryEntry;
            }
        }
        
        internal void Reset()
        {
            for(int i=0; i<this.Count; i++)
            {
                base[i] = 0;
            }
            base.Clear();
        }
        
        internal void Read(int Dir, StreamHelper file)
        {
            do {

                DocumentHeader.SetCurentSector(Dir);

                for (int i = 0; i < DocumentHeader.SectorSize / 128; i++)
                {
                    DirectoryEntry entry = new DirectoryEntry();
                    entry.Read(file);
                    Add(entry);
                }

                Dir = DocumentHeader.NextSector(Dir);

            } while( Dir != -2 );
        }

        internal void Write(int Dir, StreamHelper file)
        {
            int local_directory_index = 0;
            DirectoryEntry entry;

            DocumentHeader.SetCurentSector(Dir);

            for (int i = 0; i < DocumentHeader.SectorSize / 128; i++)
            {
                if (local_directory_index < this.Count)
                {
                    entry = this[local_directory_index] as DirectoryEntry;
                }
                else
                {
                    entry = new DirectoryEntry();
                }
                entry.Write(file);
                local_directory_index++;
            }
        }

        public DirectoryStream(CompoundDocumentHeader header)
        {
            DocumentHeader = header;
        }


        internal DirectoryEntry Add(
            string FileName, 
            BIFF8_Stream  stream, 
            int left, int right)
        {
            DirectoryEntry entry = stream.StreamDirEntry;
            entry.entry_name = FileName;
            entry.type = DirectoryEntry.DirEntryType.UseStream;
            entry.Size = (uint)stream.Length;

            entry.LeftChildDirID = left;
            entry.RightChildDirID = right;
            entry.Colour = 0x01;

            stream.Position = 0;
            
//            byte[] payload = stream.ReadBytes((int) entry.Size);
//            entry.BOF = (uint)DocumentHeader.AllocateStream( payload.Length, false );
            
            stream.StreamDirEntry = entry;

            this.Add(entry);

            return entry;
        }

        internal DirectoryEntry Add( string FileName )
        {
            BIFF8_Container Container = DocumentHeader.ShortStreamContainer;
            DirectoryEntry entry = new DirectoryEntry();
            entry.entry_name = FileName;
            entry.type = DirectoryEntry.DirEntryType.RootStorage;
            entry.Size = (uint) Container.Length;

            entry.BOF = (uint) DocumentHeader.WriteShortStreamContainer();

            entry.RootDirID = 3;
            entry.Colour = 0x01;

            this.Add(entry);

            return entry;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class BIFF8_Container : StreamHelper
    { 
    }

    internal class BIFF8_Stream : StreamHelper
    {
        internal DirectoryEntry                 StreamDirEntry;
        internal CompoundDocumentHeader         DocumentHeader;

        private int ShortSectorSize { get { return DocumentHeader.ShortSectorSize; } }

        internal void Write()
        {
            this.Position = 0;

            int BytesCount = (int)this.Length;

            if (BytesCount < DocumentHeader.MinStreamSize)
            {
                this.StreamDirEntry.BOF = (uint) this.DocumentHeader.AllocateShortSector();
                int Sector = (int) this.StreamDirEntry.BOF;
                while (BytesCount > 0)
                {
                    int chunk_size = (BytesCount >= ShortSectorSize) ? ShortSectorSize : BytesCount;
                    byte[] sector = this.ReadBytes(DocumentHeader.ShortSectorSize);
                    DocumentHeader.ShortStreamContainer.Position = DocumentHeader.ShortSectorOffset(Sector);
                    DocumentHeader.ShortStreamContainer.Write(sector, 0, chunk_size);
                    BytesCount -= chunk_size;
                    if (BytesCount <= 0) break;
                    Sector = DocumentHeader.AllocateShortSector(Sector);
                }
            }
            else
            {
                this.StreamDirEntry.BOF = (uint) this.DocumentHeader.AllocateSector();
                int Sector = (int) this.StreamDirEntry.BOF;
                while (BytesCount > 0)
                {
                    DocumentHeader.SetCurentSector(Sector);
                    byte[] sector = this.ReadBytes(DocumentHeader.SectorSize);
                    DocumentHeader.Write(sector, 0, DocumentHeader.SectorSize);
                    BytesCount -= DocumentHeader.SectorSize;
                    if (BytesCount <= 0) break;
                    Sector = DocumentHeader.AllocateSector(Sector);
                }
            }

        }

        public BIFF8_Stream( CompoundDocumentHeader document_header, DirectoryEntry entry )
        {
            this.StreamDirEntry = entry;
            this.DocumentHeader = document_header;

            int Sector =        (int) entry.BOF;
            int BytesCount =    (int) entry.Size;

            if ( BytesCount < DocumentHeader.MinStreamSize )
            {
                while (BytesCount > 0)
                {
                    int chunk_size = (BytesCount >= ShortSectorSize) ? ShortSectorSize : BytesCount;
                    DocumentHeader.ShortStreamContainer.Position = DocumentHeader.ShortSectorOffset(Sector);
                    byte[] sector_data = DocumentHeader.ShortStreamContainer.ReadBytes(chunk_size);
                    this.Write(sector_data, 0, chunk_size);
                    Sector = DocumentHeader.NextShortSector(Sector);
                    BytesCount -= chunk_size;
                }
            }
            else
            {
                while (Sector > 0)
                {
                    DocumentHeader.SetCurentSector(Sector);
                    if (BytesCount >= DocumentHeader.SectorSize)
                    {
                        byte[] sector = DocumentHeader.ReadBytes(DocumentHeader.SectorSize);
                        base.Write(sector, 0, DocumentHeader.SectorSize);
                        BytesCount -= DocumentHeader.SectorSize;
                    }
                    else
                    {
                        byte[] sector = DocumentHeader.ReadBytes(BytesCount);
                        base.Write(sector, 0, BytesCount);
                        BytesCount -= DocumentHeader.SectorSize;
                    }

                    Sector = DocumentHeader.NextSector(Sector);
                }
            }

            base.Position = 0;
        }
    }

}
