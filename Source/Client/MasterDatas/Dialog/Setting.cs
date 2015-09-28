using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class Setting : DialogBase
    {

        #region 属性

        /// <summary>
        /// 模块选项参数集合
        /// </summary>
        public List<SYS_ModuleParam> Parameters { get; private set; }

        #endregion
         
        #region 构造方法

        public Setting()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        private void Setting_Load(object sender, EventArgs e)
        {
            Parameters = Commons.DeptParam(OpenForm.ModuleId);
            Format.InitGridLookUpEdit(grlTemplate, Commons.Templets("Other"));
            InitSetting();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitSetting()
        {
            foreach (var mp in Parameters)
            {
                var pid = mp.ParamId.ToString().ToUpper();
                switch (pid)
                {
                    case "85A80D3E-6DB7-496E-BF6F-B1008B1D87B2": if (mp.Value != null) grlTemplate.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "9B2CB116-6E3B-4A9F-9279-E3F568514BEE": chkNeedCode.Checked = bool.Parse(mp.Value);
                        break;
                    case "6EEF8490-B3F5-46BA-86FB-7F0F93B89537": chkNeedType.Checked = bool.Parse(mp.Value);
                        break;
                    case "DC385162-A8E1-4762-80AD-8314BB522B08": chkNeedLeader.Checked = bool.Parse(mp.Value);
                        break;
                    case "4CFB84C4-482B-49D6-9463-7FE92B23B9FE": chkNeedId.Checked = bool.Parse(mp.Value);
                        break;
                    case "5CE32EC5-1E64-416E-8570-DE7DEEAE18AD": chkNeedPhone.Checked = bool.Parse(mp.Value);
                        break;
                    case "9308DB9F-193B-444C-B0FF-1A4617022D04": chkNeedMail.Checked = bool.Parse(mp.Value);
                        break;
                }
            }
        }

        #endregion

        #region 保存数据

        /// <summary>
        /// 保存模块选项参数
        /// </summary>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            var val = grlTemplate.EditValue == null ? null : grlTemplate.EditValue.ToString();
            var mps = new[]
            {
                new[] {"85A80D3E-6DB7-496E-BF6F-B1008B1D87B2", "打印模板", val},
                new[] {"9B2CB116-6E3B-4A9F-9279-E3F568514BEE", "工号是否必填", chkNeedCode.Checked.ToString()},
                new[] {"6EEF8490-B3F5-46BA-86FB-7F0F93B89537", "工种是否必填", chkNeedType.Checked.ToString()},
                new[] {"DC385162-A8E1-4762-80AD-8314BB522B08", "直属领导是否必填", chkNeedLeader.Checked.ToString()},
                new[] {"4CFB84C4-482B-49D6-9463-7FE92B23B9FE", "身份证号是否必填", chkNeedId.Checked.ToString()},
                new[] {"5CE32EC5-1E64-416E-8570-DE7DEEAE18AD", "移动电话是否必填", chkNeedPhone.Checked.ToString()},
                new[] {"9308DB9F-193B-444C-B0FF-1A4617022D04", "电子邮件是否必填", chkNeedMail.Checked.ToString()}
            };
            Parameters = UpdateParameter(Parameters, mps);
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
