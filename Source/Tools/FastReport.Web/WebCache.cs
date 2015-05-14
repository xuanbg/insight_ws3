using System;
using System.Web.Caching;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

namespace FastReport.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebReportCache 
    {
        internal const string StoragePrefix = "FRS-";
        internal const string touchFilename = StoragePrefix + "touch";
        internal const string maskStorage = StoragePrefix + "*";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Obj"></param>
        /// <param name="DisposeCallBack"></param>
        /// <param name="CacheDelay"></param>
        /// <param name="Priority"></param>
        public static void CacheAdd(string Name, Object Obj, CacheItemRemovedCallback DisposeCallBack, int CacheDelay, CacheItemPriority Priority)
        {
            if (!String.IsNullOrEmpty(Name) && Obj != null)
                HttpRuntime.Cache.Add(Name, Obj, null,
                    Cache.NoAbsoluteExpiration, new TimeSpan(0, CacheDelay, 0),
                    Priority, DisposeCallBack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static object CacheGet(string Name)
        {
            if (!String.IsNullOrEmpty(Name))
                return HttpRuntime.Cache[Name];
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static object CacheRemove(string Name)
        {
            if (!String.IsNullOrEmpty(Name))
                return HttpRuntime.Cache.Remove(Name);
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetStoragePath(HttpContext context)
        {
            string path = ConfigurationManager.AppSettings["FastReportStoragePath"];
            if (!String.IsNullOrEmpty(path))
            {
                path += Path.DirectorySeparatorChar;
                if (!(path.StartsWith(@"\\") || path.StartsWith(@"//")))
                    path = context.Request.MapPath(path);
            }
            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetStorageTimeout()
        {
            string valueS = ConfigurationManager.AppSettings["FastReportStorageTimeout"];
            int value = 15;
            if (!String.IsNullOrEmpty(valueS))
                value = Convert.ToInt16(valueS);
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetStorageCleanup()
        {
            string valueS = ConfigurationManager.AppSettings["FastReportStorageCleanup"];
            int value = 1;
            if (!String.IsNullOrEmpty(valueS))
                value = Convert.ToInt16(valueS);
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileStoragePath"></param>
        /// <param name="FileStorageTimeout"></param>
        /// <param name="FileStorageCleanup"></param>
        public static int CleanStorage(string FileStoragePath, int FileStorageTimeout, int FileStorageCleanup)
        {
            string touch = Path.Combine(FileStoragePath, touchFilename);

            if (!String.IsNullOrEmpty(FileStoragePath) && Directory.Exists(FileStoragePath))
            {
                if (!File.Exists(touch))
                {
                    using (FileStream file = File.Create(touch)) { };
                }
                else
                {
                    DateTime created = File.GetLastWriteTime(touch);
                    if (DateTime.Now > created.AddMinutes(FileStorageCleanup))
                    {
                        File.SetLastWriteTime(touch, DateTime.Now);

                        string[] dir = Directory.GetFiles(FileStoragePath, maskStorage);
                        foreach (string file in dir)
                        {
                            try
                            {
                                if (DateTime.Now > File.GetLastWriteTime(file).AddMinutes(FileStorageTimeout))
                                    File.Delete(file);
                            }
                            catch
                            {
                                //nothing
                            }
                        }
                    }
                }
            }
            return Directory.GetFiles(FileStoragePath, maskStorage).Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object GetFileStorage(string prefix, string suffix, string path)
        {
            string fileName = String.Concat(path, StoragePrefix, prefix, suffix);
            object obj = null;
            if (File.Exists(fileName))
            {
                File.SetLastWriteTime(fileName, DateTime.Now);
                if (prefix == WebUtils.REPORT)
                {
                    obj = new Report();
                    (obj as Report).Load(fileName);
                    (obj as Report).LoadPrepared(String.Concat(fileName, "prep"));
                }
                else
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        obj = bf.Deserialize(fs);
                    }
                }
            }            
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <param name="value"></param>
        /// <param name="path"></param>
        public static void PutFileStorage(string prefix, string suffix, object value, string path)
        {
            string fileName = String.Concat(path, StoragePrefix, prefix, suffix);

            //!!! need to improve

            if (value is Report)
            {
                (value as Report).Save(fileName);
                (value as Report).SavePrepared(String.Concat(fileName, "prep"));
            }
            else
            {
                if (File.Exists(fileName))
                {
                    if (value is byte[])
                    {
                        try
                        {
                            File.SetLastWriteTime(fileName, DateTime.Now);
                        }
                        catch
                        {
                            // nothing to do
                        }
                    }
                    else
                        try
                        {
                            File.Delete(fileName);
                        }
                        catch
                        {
                           // nothing to do
                        }
                }

                if (!File.Exists(fileName))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, value);
                    }
                }
            }
        }
    }
}