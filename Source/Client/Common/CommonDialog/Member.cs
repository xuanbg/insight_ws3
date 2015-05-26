using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Insight.WS.Client.Common
{
    public partial class Member : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否添加成员
        /// </summary>
        public bool IsAdd { private get; set; }

        /// <summary>
        /// 可选列表
        /// </summary>
        public DataTable List { private get; set; }

        /// <summary>
        /// 选中的ID集合
        /// </summary>
        public List<Guid> IdList { get; private set; }

        #endregion

        #region 构造方法

        public Member()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件处理

        /// <summary>
        /// 加载可选的用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Member_Load(object sender, EventArgs e)
        {
            Text = IsAdd ? "添加成员" : "移除成员";
            grdSelect.DataSource = List;

            Format.GridFormat(gdvSelect, 0);
            gdvSelect.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            gdvSelect.Columns[1].Width = 100;
            gdvSelect.Columns[2].Width = 100;
            gdvSelect.Columns[3].Width = 140;
        }

        #endregion

        #region 重写虚方法

        /// <summary>
        /// 点击确定按钮将选中成员ID添加到IdList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            IdList = new List<Guid>();
            foreach (var index in gdvSelect.GetSelectedRows().Where(index => index >= 0))
            {
                IdList.Add((Guid)gdvSelect.GetDataRow(index)["ID"]);
            }

            if (IdList.Count == 0)
            {
                General.ShowWarning("当前未选中任何成员！");
                return;
            }
            
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
