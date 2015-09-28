using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Common
{
    public partial class WizardBase : XtraForm
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { protected get; set; }

        /// <summary>
        /// 数据ID
        /// </summary>
        public Guid ObjectId { protected get; set; }

        /// <summary>
        /// 打开向导的窗体
        /// </summary>
        protected MdiBase OpenForm { get; private set; }

        #endregion

        #region 构造方法

        protected WizardBase()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 设置父窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WizardBase_Load(object sender, EventArgs e)
        {
            OpenForm = (MdiBase)Owner;
        }

        /// <summary>
        /// 关闭向导时弹出确认对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && General.ShowConfirm($"您确定要放弃{(IsEdit ? "编辑" : "新建")}离开向导吗？") != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

    }
}
