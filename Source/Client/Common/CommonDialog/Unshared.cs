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

        /// <summary>
        /// 打开对话框初始化窗体内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Transfer_Load(object sender, EventArgs e)
        {
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                grdSharing.DataSource = cli.GetSharing(MainForm.Session, CustomerId);
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
            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                if (!cli.UnShare(MainForm.Session, ids))
                {
                    General.ShowError("数据保存失败！如多次保存失败，请联系管理员。");
                    return;
                }
                
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
