using System;

namespace FastReport.Web
{
    /// <summary>
    /// Class for export item description
    /// </summary>
    [Serializable]
    public class WebExportItem
    {
        private byte[] FFile;
        private string FFileName;
        private string FFormat;
        private string FContentType;

        /// <summary>
        /// Binary data of exported files
        /// </summary>
        public byte[] File
        {
            get { return FFile; }
            set { FFile = value; }
        }

        /// <summary>
        /// Name of exported file
        /// </summary>
        public string FileName
        {
            get { return FFileName; }
            set { FFileName = value; }
        }

        /// <summary>
        /// Format of exported file
        /// </summary>
        public string Format
        {
            get { return FFormat; }
            set { FFormat = value; }
        }

        /// <summary>
        /// MIME type of exported file
        /// </summary>
        public string ContentType
        {
            get { return FContentType; }
            set { FContentType = value; }
        }
    }
}