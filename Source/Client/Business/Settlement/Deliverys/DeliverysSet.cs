using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Settlement
{
    public partial class DeliverysSet : DialogBase
    {

        #region 属性

        /// <summary>
        /// 模块选项参数集合
        /// </summary>
        public List<SYS_ModuleParam> Parameters { get; private set; }

        #endregion

        #region 变量声明

        private DataTable _SecrecyList;
        private DataTable _TemplateList;
        private DataTable _SchemeList;

        #endregion

        #region 构造方法

        public DeliverysSet()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        private void Setting_Load(object sender, EventArgs e)
        {
            Parameters = Commons.DeptParam(OpenForm.ModuleId);
            _TemplateList = Commons.Templets("Bill");
            _SchemeList = Commons.CodeSchemes();

            InitSecrecyList();
            InitGridEdit(grlStoneInTemp, _TemplateList);
            InitGridEdit(grlStoneOutTemp, _TemplateList);
            InitGridEdit(grlStoneBakTemp, _TemplateList);
            InitGridEdit(grlStoneInScheme, _SchemeList);
            InitGridEdit(grlStoneOutScheme, _SchemeList);
            InitGridEdit(grlStoneBakScheme, _SchemeList);
            InitSetting();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化涉密等级列表
        /// </summary>
        private void InitSecrecyList()
        {
            _SecrecyList = Commons.Dictionary("Securitylevel");

            lokSecrecy.Properties.DataSource = _SecrecyList;
            lokSecrecy.Properties.DisplayMember = "Name";
            lokSecrecy.Properties.ValueMember = "ID";
            lokSecrecy.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(lokSecrecy.Properties.DisplayMember));
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        private void InitGridEdit(GridLookUpEdit control, DataTable table)
        {
            control.Properties.DataSource = table;
            control.Properties.DisplayMember = "Name";
            control.Properties.ValueMember = "ID";
            control.Properties.PopulateViewColumns();
            Format.GridFormat(control.Properties.View);
        }

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
                    case "16EBDC03-B0BB-481B-8EDC-0B9F29A97911": if (mp.Value != null) grlStoneInTemp.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "8A5AF44F-B0CE-4D0A-B0CF-FFB8315613C8": if (mp.Value != null) grlStoneOutTemp.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "42244164-E340-48C7-B153-920497B6F069": if (mp.Value != null) grlStoneBakTemp.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "2F2ED486-2C52-4D83-AF61-85F6736C8337": if (mp.Value != null) grlStoneInScheme.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "A22F4C4D-6A43-4F02-BB22-429F6FB78580": if (mp.Value != null) grlStoneOutScheme.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "56C7ED33-4263-46D4-BA11-E99BC6BDBCBB": if (mp.Value != null) grlStoneBakScheme.EditValue = Guid.Parse(mp.Value);
                        break;
                    case "F52A5EB0-D491-49BE-9FCB-2031D8AABB3C": if (mp.Value != null) lokSecrecy.EditValue = Guid.Parse(mp.Value);
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
            var tpi = grlStoneInTemp.EditValue == null ? null : grlStoneInTemp.EditValue.ToString();
            var tpo = grlStoneOutTemp.EditValue == null ? null : grlStoneOutTemp.EditValue.ToString();
            var tpb = grlStoneBakTemp.EditValue == null ? null : grlStoneBakTemp.EditValue.ToString();
            var smi = grlStoneInScheme.EditValue == null ? null : grlStoneInScheme.EditValue.ToString();
            var smo = grlStoneOutScheme.EditValue == null ? null : grlStoneOutScheme.EditValue.ToString();
            var smb = grlStoneBakScheme.EditValue == null ? null : grlStoneBakScheme.EditValue.ToString();
            var sec = lokSecrecy.EditValue == null ? null : lokSecrecy.EditValue.ToString();
            var mps = new[]
            {
                new[] {"16EBDC03-B0BB-481B-8EDC-0B9F29A97911", "入库单打印模板", tpi},
                new[] {"8A5AF44F-B0CE-4D0A-B0CF-FFB8315613C8", "出库单打印模板", tpo},
                new[] {"42244164-E340-48C7-B153-920497B6F069", "退库单打印模板", tpb},
                new[] {"2F2ED486-2C52-4D83-AF61-85F6736C8337", "入库单编码方案", smi},
                new[] {"A22F4C4D-6A43-4F02-BB22-429F6FB78580", "出库单编码方案", smo},
                new[] {"56C7ED33-4263-46D4-BA11-E99BC6BDBCBB", "退库单编码方案", smb},
                new[] {"F52A5EB0-D491-49BE-9FCB-2031D8AABB3C", "涉密等级", sec}
            };
            Parameters = UpdateParameter(Parameters, mps);
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
