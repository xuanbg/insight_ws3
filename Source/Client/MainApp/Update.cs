using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.MainApp
{
    public class Update
    {

        #region 属性

        /// <summary>
        /// 更新文件列表
        /// </summary>
        public List<UpdateFile> UpdateFiles { get; }

        #endregion

        #region 变量声明

        private readonly List<UpdateFile> _LocalFiles = new List<UpdateFile>();
        private readonly string _RootPath = Application.StartupPath;

        #endregion

        #region 构造函数

        /// <summary>
        /// 比较本地和远程文件版本差异
        /// </summary>
        /// <param name="files"></param>
        public Update(IEnumerable<UpdateFile> files)
        {
            GetLocalFiles(_RootPath);
            UpdateFiles = new List<UpdateFile>();
            UpdateFiles.AddRange(from sf in files
                                 let cf = _LocalFiles.Find(file => file.Name == sf.Name && file.Path == sf.Path)
                                 where cf == null || (cf.Version != null && string.Compare(cf.Version, sf.Version, StringComparison.Ordinal) < 0)
                                 select sf);
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool UpdateFile(UpdateFile file)
        {
            var path = _RootPath + file.Path + "\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var restart = false;
            path += file.Name;
            try
            {
                File.Delete(path);
            }
            catch
            {
                File.Move(path, path + ".bak");
                restart = true;
            }

            var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            fs.Write(file.FileBytes, 0, file.FileBytes.Length);
            return restart;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取本地文件列表
        /// </summary>
        /// <param name="dir"></param>
        private void GetLocalFiles(string dir)
        {
            // 删除上次更新产生的bak文件
            foreach (var file in Directory.GetFiles(dir, "*.bak"))
            {
                File.Delete(file);
            }

            // 读取目录下文件信息
            var dirInfo = new DirectoryInfo(dir);
            _LocalFiles.AddRange(from file in dirInfo.GetFiles()
                                 where ".dll.exe.frl".IndexOf(file.Extension, StringComparison.Ordinal) >= 0
                                 let directoryName = file.DirectoryName
                                 where directoryName != null
                                 select new UpdateFile
                                 {
                                     Name = file.Name,
                                     Path = directoryName.Replace(_RootPath, ""),
                                     FullPath = file.FullName,
                                     Version = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion
                                 });

            // 递归子目录
            var dirs = Directory.GetDirectories(dir);
            foreach (var path in dirs)
            {
                GetLocalFiles(path);
            }
        }

        #endregion

    }
}
