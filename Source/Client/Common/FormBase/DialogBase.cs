using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class DialogBase : XtraForm
    {

        #region 属性

        /// <summary>
        /// 数据ID
        /// </summary>
        public Guid ObjectId { get; set; }

        /// <summary>
        /// 打开对话框的窗体
        /// </summary>
        protected MdiBase OpenForm { get; private set; }

        #endregion

        #region 构造方法

        protected DialogBase()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体加载事件

        private void DialogBase_Load(object sender, EventArgs e)
        {
            OpenForm = (MdiBase)Owner;
        }

        #endregion

        #region 保护方法

        /// <summary>
        /// 更新/新增SYS_ModuleParam对象
        /// </summary>
        /// <param name="mpl"></param>
        /// <param name="mps"></param>
        protected List<SYS_ModuleParam> UpdateParameter(List<SYS_ModuleParam> mpl, string[][] mps)
        {
            foreach (var mp in mps)
            {
                var pid = Guid.Parse(mp[0]);
                if (mpl.Exists(p => p.ParamId == pid))
                {
                    mpl.Find(p => p.ParamId == pid).Value = mp[2];
                }
                else
                {
                    var pam = new SYS_ModuleParam
                    {
                        ModuleId = OpenForm.ModuleId,
                        ParamId = pid,
                        Name = mp[1],
                        Value = mp[2],
                        OrgId = OpenForm.UserSession.DeptId
                    };
                    mpl.Add(pam);
                }
            }
            return mpl;
        }

        /// <summary>
        /// 点击确定按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Confirm_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 点击取消按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void DialogClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) return;

            if (General.ShowConfirm("您确定要放弃所做的变更，并关闭对话框吗？") != DialogResult.OK)
                e.Cancel = true;
        }

        #endregion

    }
}
