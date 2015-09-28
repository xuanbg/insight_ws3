using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using FastReport;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{

    public class General
    {

        /// <summary>
        /// 显示提示对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示错误对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示确认对话框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static DialogResult ShowConfirm(string msg, MessageBoxDefaultButton button = MessageBoxDefaultButton.Button2)
        {
            return MessageBox.Show(msg, "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, button);
        }

        /// <summary>
        /// 显示提问对话框
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ShowQuestion(string msg)
        {
            return MessageBox.Show(msg, "请选择", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
        }

        /// <summary>
        /// 计算字符串的Hash值
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>String Hash值</returns>
        public static string GetHash(string str)
        {
            var md5 = MD5.Create();
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(str.Trim()));
            return s.Aggregate("", (current, c) => current + c.ToString("X2"));
        }

        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns>String 序列号</returns>
        public static string GetCpuId()
        {
            var myCpu = new ManagementClass("win32_Processor").GetInstances();
            return (from ManagementObject cpu in myCpu select cpu.Properties["Processorid"].Value).Aggregate("", (current, val) => current + (val == null ? "" : val.ToString()));
        }

        /// <summary>
        /// 获取主板序列号
        /// </summary>
        /// <returns>String 序列号</returns>
        public static string GetMbId()
        {
            var myMb = new ManagementClass("Win32_BaseBoard").GetInstances();
            return (from ManagementObject mb in myMb select mb.Properties["SerialNumber"].Value).Aggregate("", (current, val) => current + (val == null ? "" : val.ToString()));
        }

        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        /// <returns>String 序列号</returns>
        public static string GetHdId()
        {
            var lpm = new ManagementClass("Win32_PhysicalMedia").GetInstances();
            return (from ManagementObject hd in lpm select hd.Properties["SerialNumber"].Value).Aggregate("", (current, val) => current + (val == null ? "" : val.ToString().Trim()));
        }

        /// <summary>
        /// 增加水印
        /// </summary>
        /// <param name="fr">Report对象实体</param>
        /// <param name="str">水印文字</param>
        /// <param name="size"></param>
        /// <returns>Report对象实体</returns>
        public static void AddWatermark(Report fr, string str, int size = 72)
        {
            var wm = new Watermark
            {
                Enabled = true,
                Text = str,
                Font = new Font("宋体", size, FontStyle.Bold)
            };

            for (var i = 0; i < fr.PreparedPages.Count; i++)
            {
                var pag = fr.PreparedPages.GetPage(i);
                pag.Watermark = wm;
                fr.PreparedPages.ModifyPage(i, pag);
            }
        }

        /// <summary>
        /// Image 转换为 byte[]数组
        /// </summary>
        /// <param name="img">图片</param>
        /// <returns>byte[] 数组</returns>
        public static byte[] ImageToByteArray(Image img)
        {
            if (img == null)
                return null;

            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 获取图片缩略图
        /// </summary>
        /// <param name="img">原图片</param>
        /// <returns>Image 缩略图</returns>
        public static Image GetThumbnail(Image img)
        {
            if (img == null) return null;

            var callb = new Image.GetThumbnailImageAbort(Callback);
            return img.GetThumbnailImage(120, 150, callb, IntPtr.Zero);
        }

        private static bool Callback()
        {
            return false;
        }

        /// <summary>
        /// 将打开的本地文档转换成电子影像
        /// </summary>
        /// <param name="slv">附件涉密等级</param>
        /// <param name="type">附件类型（默认0：附件）</param>
        /// <returns>ImageData List 电子影像对象集合</returns>
        public static List<ImageData> AddFiles(Guid? slv, int type = 0)
        {
            var imgs = new List<ImageData>();
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                if (dialog.ShowDialog() != DialogResult.OK) return null;

                var array = dialog.FileNames;
                foreach (var fileName in array)
                {
                    var fs = new FileStream(fileName, FileMode.Open);
                    var br = new BinaryReader(fs);
                    var bf = br.ReadBytes((int)fs.Length);
                    fs.Close();

                    var img = new ImageData
                    {
                        ID = Guid.NewGuid(),
                        ImageType = type,
                        Name = Path.GetFileNameWithoutExtension(fileName),
                        Expand = Path.GetExtension(fileName),
                        SecrecyDegree = slv,
                        Size = bf.LongLength,
                        Image = bf,
                        CreatorDeptId = MainForm.Session.DeptId,
                        CreatorUserId = MainForm.Session.UserId
                    };
                    imgs.Add(img);
                }
            }
            return imgs;
        }

        /// <summary>
        /// 根据ID获取ImageData对象实体
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public static void OpenAttach(Guid id)
        {
            var img = Commons.ImageData(id);
            var fn = img.Name + img.ID.ToString().Substring(23) + img.Expand;
            SaveFile(img.Image, fn);
        }

        /// <summary>
        /// 保存文件并打开
        /// </summary>
        /// <param name="file">文件内容</param>
        /// <param name="name">文件名</param>
        public static void SaveFile(byte[] file, string name)
        {
            var path = Path.GetTempPath() + name;
            if (!File.Exists(path))
            {
                var bw = new BinaryWriter(File.Create(path));
                bw.Write(file);
                bw.Flush();
                bw.Close();
            }
            Process.Start(path);
        }

        /// <summary>
        /// 验证18位身份证号码
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns>bool 是否合法</returns>
        public static bool CheckIdCard18(string id)
        {
            long n;
            if (long.TryParse(id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            var birth = id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            var arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            var wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            var ai = id.Remove(17).ToCharArray();
            var sum = 0;
            for (var i = 0; i < 17; i++)
            {
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString());
            }
            int y;
            Math.DivRem(sum, 11, out y);
            return arrVarifyCode[y] == id.Substring(17, 1).ToLower();
        }

        /// <summary>
        /// 验证15位身份证号码
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns>bool 是否合法</returns>
        public static bool CheckIdCard15(string id)
        {
            long n;
            if (long.TryParse(id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            var birth = id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time;
            return DateTime.TryParse(birth, out time);
        }

        /// <summary>
        /// 输入合法性验证
        /// </summary>
        /// <param name="type">输入类型</param>
        /// <param name="number">输入内容</param>
        /// <returns>bool 是否合法</returns>
        public static bool CheckInput(string type, string number)
        {
            if (string.IsNullOrEmpty(number)) return false;

            bool result;
            switch (type)
            {
                case "Tel":
                    result = RegexHelper.CheckInput(number, RegexHelper.IsValidTel);
                    break;

                case "Mobile":
                    result = RegexHelper.CheckInput(number, RegexHelper.IsValidMobile);
                    break;

                case "Fax":
                    result = RegexHelper.CheckInput(number, RegexHelper.IsValidTel);
                    break;

                case "Email":
                    result = RegexHelper.CheckInput(number, RegexHelper.IsValidEmail);
                    break;

                default:
                    result = true;
                    break;
            }
            return result;
        }

    }
}
