using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Insight.WS.Client.MainApp.Service;

namespace Insight.WS.Client.MainApp
{
    public class Update
    {

        #region 属性

        /// <summary>
        /// 更新文件列表
        /// </summary>
        internal List<UpdateFile> UpdateFiles { get; set; }

        #endregion

        #region 变量声明

        private List<UpdateFile> _LocalFiles = new List<UpdateFile>();
        private string _RootPath;

        #endregion

        #region 构造函数

        /// <summary>
        /// 比较本地和远程文件版本差异
        /// </summary>
        /// <param name="files"></param>
        internal Update(IEnumerable<UpdateFile> files)
        {
            // 获取本地文件列表
            _RootPath = Application.StartupPath;
            GetLocalFiles(_RootPath);

            // 根据服务器文件列表比较文件版本，如本地文件不存在或版本比服务器上的低，则将该文件加入更新列表
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
        internal bool UpdateFile(UpdateFile file)
        {
            var path = _RootPath + file.Path + "\\";
            var restart = false;
            FileStream fs;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Start:
            try
            {
                fs = new FileStream(path + file.Name, FileMode.Create, FileAccess.Write);
            }
            catch
            {
                File.Move(file.Name, file.Name + ".bak");
                restart = true;
                goto Start;
            }

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
            // 读取目录下文件信息
            var dirInfo = new DirectoryInfo(dir);
            _LocalFiles.AddRange(from file in dirInfo.GetFiles()
                                 where ".dll.exe.frl".IndexOf(file.Extension) >= 0
                                 select new UpdateFile
                                 {
                                     Name = file.Name,
                                     Path = file.DirectoryName.Replace(_RootPath, ""),
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
