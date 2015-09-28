using System;
using System.Drawing;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class AdvEdit : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑模式
        /// </summary>
        public bool IsEdit { private get; set; }

        /// <summary>
        /// 轮播广告对象
        /// </summary>
        public BIZ_Advertiser Advertiser { get; set; }

        #endregion

        #region 变量声明

        private string _Path;

        #endregion

        #region 构造函数

        public AdvEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvEdit_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "编辑轮播图" : "新建轮播图";
            spiIndex.EditValue = Advertiser.Sort;
            txtCode.EditValue = Advertiser.ProductCode;
            txtName.EditValue = Advertiser.Name;
            txtImage.EditValue = Advertiser.ImageURL;
        }

        /// <summary>
        /// 输入跳转地址后禁用商品编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTarget_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            txtCode.Enabled = e.Value == null;
        }

        /// <summary>
        /// 输入商品编号后禁用跳转地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            txtTarget.Enabled = e.Value == null;
        }

        /// <summary>
        /// 选择轮播图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog { Filter = "图片文件(*.png *.jpg *.jpeg *.bmp)|*.png;*.jpg;*.jpeg;*.bmp" };
            if (open.ShowDialog() != DialogResult.OK) return;

            _Path = open.FileName;
            Advertiser.ImageURL = open.SafeFileName;
            txtImage.EditValue = _Path;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 点击确定保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTarget.Text.Trim() + txtCode.Text.Trim()))
            {
                General.ShowWarning("跳转地址和商品编号不能全部为空！请输入一个跳转地址或一个商品编号。");
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("商品名称不能为空！请输入商品名称。");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtImage.Text.Trim()))
            {
                General.ShowWarning("轮播图片不能为空！请选择图片文件。");
                btnUpload.Focus();
                return;
            }

            Advertiser.Name = txtName.Text.Trim();
            Advertiser.TargetURL = (string) txtTarget.EditValue;
            Advertiser.Sort = (int) spiIndex.Value;
            Advertiser.ProductCode = (string) txtCode.EditValue;

            using (var cli = new ManagerClient(OpenForm.Binding, OpenForm.Address))
            {
                byte[] buff = null;
                if (Advertiser.ImageURL != txtImage.Text)
                {
                    var img = Image.FromFile(_Path);
                    buff = General.ImageToByteArray(img);
                }

                var result = IsEdit ? cli.EditAdvertiser(OpenForm.UserSession, Advertiser, buff) : cli.AddAdvertiser(OpenForm.UserSession, Advertiser, buff);
                if (!result)
                {
                    General.ShowWarning("对不起，轮播图保存失败！如多次保存失败，请联系管理员。");
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
