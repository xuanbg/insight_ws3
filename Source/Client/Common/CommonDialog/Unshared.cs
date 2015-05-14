using System;
using System.Linq;
using System.Windows.Forms;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class Unshared : DialogBase
    {

        #region 属性

        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId { private get; set; }

        #endregion

        #region 构造方法

        public Unshared()
        {
            InitializeComponent(); 
        }

        #endregion

        #region 界面事件

        private void Transfer_Load(object sender, EventArgs e)
        {
            using (var cli = new CommonsClient(MainForm._Binding, MainForm._Address))
            {
                grdSharing.DataSource = cli.GetSharing(MainForm._Session, CustomerId);
                Format.GridFormat(gdvSharing);
            }
        }

        #endregion
        
        #region 重写确定按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (gdvSharing.RowCount > 0 && gdvSharing.GetSelectedRows().Length == 0)
            {
                General.ShowWarning("当前未选中任何要解除共享的用户！");
                return;
            }

            if (gdvSharing.RowCount > 0 && General.ShowConfirm("您确认要停止和选中的用户共享所选客户吗？") != DialogResult.OK)
            {
                return;
            }

            var ids = gdvSharing.GetSelectedRows().Select(h => (Guid) gdvSharing.GetDataRow(h)["ID"]).ToList();

            using (var cli = new CommonsClient(MainForm._Binding, MainForm._Address))
            {
                if (cli.UnShare(MainForm._Session, ids))
                    DialogResult = DialogResult.OK;
                else
                    General.ShowError("数据保存失败！如多次保存失败，请联系管理员。");
            }
        }

        #endregion

    }
}
