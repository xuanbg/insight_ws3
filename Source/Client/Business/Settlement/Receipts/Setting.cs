using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Settlement.Receipt
{
    public partial class Setting : DialogBase
    {

        #region 属性

        /// <summary>
        /// 模块选项参数集合
        /// </summary>
        public List<SYS_ModuleParam> Parameters { get; private set; }

        #endregion

        #region 变量声明

        private DataTable _WorkflowList = null;
        private DataTable _TempletList;
        private DataTable _SchemeList;

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
            Parameters = Commons.ModuleParam(OpenForm.ModuleId);
            _TempletList = Commons.Templets("Bill");
            _SchemeList = Commons.CodeSchemes();

            Format.InitLookUpEdit(lokSecrecy, Commons.Dictionary("Securitylevel"));
            Format.InitLookUpEdit(lokDefault, Commons.Dictionary("Settlement"));
            Format.InitGridLookUpEdit(grlCheckWF, _WorkflowList);
            Format.InitGridLookUpEdit(grlReceiptT, _TempletList);
            Format.InitGridLookUpEdit(grlPaymentT, _TempletList);
            Format.InitGridLookUpEdit(grlCheckT, Commons.Templets("Apply"));
            Format.InitGridLookUpEdit(grlReceiptS, _SchemeList);
            Format.InitGridLookUpEdit(grlPaymentS, _SchemeList);
            Format.InitGridLookUpEdit(grlCheckS, _SchemeList);

            InitSetting();
        }

        /// <summary>
        /// 抹零级别变更后设置抹零模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbWipeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbWipeType.Enabled = cmbWipeLevel.SelectedIndex > 0;
            if (cmbWipeType.Enabled && cmbWipeType.SelectedIndex < 0) cmbWipeType.SelectedIndex = 1;
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
                    case "EEE681A7-BCCF-4AFF-909A-161CFFC184D4": cmbWipeLevel.SelectedIndex = int.Parse(mp.Value);
                        break;
                    case "2BFABFD1-4B70-4DFC-9DC0-8CBAE8422545": cmbWipeType.SelectedIndex = int.Parse(mp.Value);
                        break;
                    case "3773961E-30A3-400C-9497-C616E0AD38E3": if (mp.Value != null) lokSecrecy.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "212864FE-71CF-4838-AE55-1991D117B061": if (mp.Value != null) lokDefault.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "247F6E2B-8AD3-43C3-AA32-7748507102E0": if (mp.Value != null) grlCheckWF.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "8BC6C0B7-EEE5-4AD2-B1D7-086CFA92C54F": if (mp.Value != null) grlReceiptT.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "29A890C9-0E08-4471-99CF-358011B9A94C": if (mp.Value != null) grlPaymentT.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "4D897D4C-8982-429D-8810-0EFD396A4A02": if (mp.Value != null) grlCheckT.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "DD68AA9B-9893-4774-93A3-06082A436E55": if (mp.Value != null) grlReceiptS.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "1B03C4EA-61CA-4910-AC7F-5443FB43D816": if (mp.Value != null) grlPaymentS.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "C8C8AA66-41A6-4D25-AF9D-787AAF60DA0F": if (mp.Value != null) grlCheckS.EditValue = Guid.Parse(mp.Value);
                        break;
                }
            }

            if (cmbWipeLevel.SelectedIndex < 0) cmbWipeLevel.SelectedIndex = 0;
            if (lokSecrecy.EditValue == null) lokSecrecy.ItemIndex = 0;
            if (lokDefault.EditValue == null) lokDefault.ItemIndex = 0;
        }

        #endregion

        #region 保存数据

        /// <summary>
        /// 保存模块选项参数
        /// </summary>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            var mps = new[]
            {
                new[] {"EEE681A7-BCCF-4AFF-909A-161CFFC184D4", "抹零模式", cmbWipeLevel.SelectedIndex.ToString()},
                new[] {"2BFABFD1-4B70-4DFC-9DC0-8CBAE8422545", "抹零方式", cmbWipeType.SelectedIndex.ToString()},
                new[] {"3773961E-30A3-400C-9497-C616E0AD38E3", "涉密等级", lokSecrecy.EditValue == null ? null : lokSecrecy.EditValue.ToString()},
                new[] {"212864FE-71CF-4838-AE55-1991D117B061", "默认结算方式", lokDefault.EditValue == null ? null : lokDefault.EditValue.ToString()},
                new[] {"247F6E2B-8AD3-43C3-AA32-7748507102E0", "结账流程", grlCheckWF.EditValue == null ? null : grlCheckWF.EditValue.ToString()},
                new[] {"8BC6C0B7-EEE5-4AD2-B1D7-086CFA92C54F", "收据打印模板", grlReceiptT.EditValue == null ? null : grlReceiptT.EditValue.ToString()},
                new[] {"29A890C9-0E08-4471-99CF-358011B9A94C", "付款单打印模板", grlPaymentT.EditValue == null ? null : grlPaymentT.EditValue.ToString()},
                new[] {"4D897D4C-8982-429D-8810-0EFD396A4A02", "结账单打印模板", grlCheckT.EditValue == null ? null : grlCheckT.EditValue.ToString()},
                new[] {"DD68AA9B-9893-4774-93A3-06082A436E55", "收据编码方案", grlReceiptS.EditValue == null ? null : grlReceiptS.EditValue.ToString()},
                new[] {"1B03C4EA-61CA-4910-AC7F-5443FB43D816", "付款单编码方案", grlPaymentS.EditValue == null ? null : grlPaymentS.EditValue.ToString()},
                new[] {"C8C8AA66-41A6-4D25-AF9D-787AAF60DA0F", "结账单编码方案", grlCheckS.EditValue == null ? null : grlCheckS.EditValue.ToString()}
            };
            Parameters = UpdateParameter(Parameters, mps);
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
