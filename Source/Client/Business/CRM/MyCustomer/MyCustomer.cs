using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Business.CRM.Service;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.Business.CRM
{
    public partial class MyCustomer : MdiBase
    {

        #region 变量声明

        private DataTable _Customers;
        private DataTable _CustomerInfo;
        private DataTable _Contacts;
        private DataTable _ContactInfo;
        private DataTable _Region;
        private DataTable _Statu;
        private DataTable _Class;
        private Guid _CustomerId;
        private Guid _ContactId;
        private bool _HasCustomer;
        private bool _HasContact;
        private string _TypeFilter;
        private string _Filter;
        private int _Type;
        #endregion

        #region 构造函数

        public MyCustomer()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 加载窗体时初始化查询/筛选条件和客户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyCustomer_Load(object sender, EventArgs e)
        {
            InitToolBar();

            _Class = Commons.Dictionary("CustomerClass");
            _Statu = Commons.Dictionary("CustomerStatu");

            InitCheckBox("Statu", _Statu);
            InitCheckBox("Class", _Class);
            InitData();
        }

        /// <summary>
        /// 第一次加载时获取行政区划数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyCustomer_Shown(object sender, EventArgs e)
        {
            var ts = new ThreadStart(GetRegion);
            var td = new Thread(ts);
            td.Start();
        }

        private void chkStatu_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckEdit c in palStatu.Controls)
            {
                c.Checked = chkStatu.Checked;
            }
        }

        private void chkClass_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckEdit c in palClass.Controls)
            {
                c.Checked = chkClass.Checked;
            }
        }

        /// <summary>
        /// 选择/取消选择筛选条件后刷新客户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            var statuFilter = palStatu.Controls.Cast<CheckEdit>().Aggregate("'-1'", (current, check) => current + (check.Checked ? $" ,'{check.Properties.Caption}'" : ""));
            var classFilter = palClass.Controls.Cast<CheckEdit>().Aggregate("'-1'", (current, check) => current + (check.Checked ? $" ,'{check.Properties.Caption}'" : ""));
            _TypeFilter = $"-1{(chkMy.Checked ? " ,2" : "")}{(chkSub.Checked ? " ,0" : "")}{(chkUnion.Checked ? " ,1" : "")}";
            _Filter = $"Type in ({_TypeFilter}) and 状态 in ({statuFilter}) and Class in ({classFilter})";
            InitCustomer();
        }

        /// <summary>
        /// 改变所选客户后刷新工具栏按钮状态、详细信息和联系人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvCustomer_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _CustomerId = _HasCustomer ? (Guid)gdvCustomer.GetFocusedDataRow()["CustomerId"] : Guid.Empty;
            _Type = _HasCustomer ? (int)gdvCustomer.GetFocusedDataRow()["Type"] : -1; 
            var enable =(bool)gdvCustomer.GetFocusedDataRow()["Enable"];
            SwitchItemStatus(new Context("EditCustomer", _Type > 0), new Context("DelCustomer", _Type > 1 && enable), new Context("Transfer", _Type > 1),
                             new Context("Sharing", _Type > 1), new Context("Unshared", _Type > 1), new Context("Enable", _Type > 1 && !enable));
            grdOther.Visible = false;
            InitCustomerInfo();
            InitContact();
        }

        /// <summary>
        /// 双击客户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvCustomer_DoubleClick(object sender, EventArgs e)
        {
            var edit = barManager.Items["EditCustomer"];
            if (_Type > 0 && edit.Enabled) Customer(true);
        }

        private void glvContact_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _ContactId = _HasContact ? (Guid)glvContact.GetFocusedDataRow()["ID"] : Guid.Empty;
            grdOther.Visible = false;
        }

        /// <summary>
        /// 双击联系人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glvContact_DoubleClick(object sender, EventArgs e)
        {
            var edit = barManager.Items["EditContact"];
            if (_Type > 0 && edit.Enabled) Contact(true);
        }

        /// <summary>
        /// 输入回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 清空查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
            Filter_CheckedChanged(null, null);
        }

        /// <summary>
        /// 点击查看其它联系方式按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbeView_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            grdOther.Visible = grdOther.Visible == false;
            if (grdOther.Visible) InitContactInfo();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            _Contacts = Commons.GetContacts();
            _ContactInfo = Commons.GetContactInfos();

            using (var cli = new CRMClient(Binding, Address))
            {
                _Customers = cli.GetCustomers(UserSession);
                _CustomerInfo = cli.GetCustomerInfo(UserSession);
            }

            Filter_CheckedChanged(null, null);
        }

        /// <summary>
        /// 初始化筛选框
        /// </summary>
        private void InitCheckBox(string type, DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var check = new CheckEdit
                {
                    Location = new Point(4 + 90*i, 4),
                    Size = new Size(90, 21),
                    Checked = true
                };
                check.Properties.Caption = dt.Rows[i]["Name"].ToString();
                check.CheckedChanged += Filter_CheckedChanged;

                if (type == "Statu")
                {
                    palStatu.Controls.Add(check);
                }
                else
                {
                    palClass.Controls.Add(check);
                }
            }
        }

        /// <summary>
        /// 初始化客户列表
        /// </summary>
        private void InitCustomer()
        {
            var dv = _Customers.Copy().DefaultView;
            dv.RowFilter = _Filter;
            var dt = dv.ToTable();
            dt.PrimaryKey = new[] { dt.Columns["ID"] };
            var dl = (from DataRow row in dt.Rows let str = $"CustomerId = '{row["CustomerId"]}'" where (int) row["Type"] == 0 && dt.Select(str).Length > 1 select row["ID"]).ToList();
            dl.ForEach(id => dt.Rows.Find(id).Delete());
            dt.AcceptChanges();
            _HasCustomer = dt.Rows.Count > 0;

            grdCustomer.DataSource = dt;
            Format.GridFormat(gdvCustomer);
            gdvCustomer.Columns["状态"].Width = 60;
            gdvCustomer.Columns["状态"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvCustomer.Columns["客户经理"].Width = 60;
            gdvCustomer.Columns["客户经理"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvCustomer.Columns["名称"].Width = 200;
            gdvCustomer.Columns["简称"].Width = 80;
            gdvCustomer.Columns["经营范围"].Width = 120;
            gdvCustomer.Columns["资产规模"].Width = 60;
            gdvCustomer.Columns["资产规模"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvCustomer.Columns["员工人数"].Width = 60;
            gdvCustomer.Columns["员工人数"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvCustomer.Columns["地址"].Width = 315;
            gdvCustomer.Columns["邮编"].Width = 60;
            gdvCustomer.Columns["邮编"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            if (_HasCustomer) return;

            SwitchItemStatus(new Context("EditCustomer", false), new Context("DelCustomer", false),
                new Context("Enable", false), new Context("Transfer", false), new Context("Sharing", false),
                new Context("NewContact", false), new Context("EditContact", false), new Context("DelContact", false));
            _CustomerId = Guid.Empty;
            InitCustomerInfo();
            InitContact();
        }

        /// <summary>
        /// 初始化客户详细信息列表
        /// </summary>
        private void InitCustomerInfo()
        {
            var dv = _CustomerInfo.DefaultView;
            dv.RowFilter = $"CustomerId = '{_CustomerId}'";

            vrdInfo.RowHeaderWidth = 80;
            vrdInfo.RecordWidth = 240;
            vrdInfo.DataSource = dv;
            vrdInfo.Rows[0].Visible = false;
            vrdInfo.Rows[11].Height = 46;
        }

        /// <summary>
        /// 初始化联系人列表
        /// </summary>
        private void InitContact()
        {
            var dv = _Contacts.DefaultView;
            dv.RowFilter = $"ParentId = '{_CustomerId}'";
            _HasContact = dv.Count > 0;

            grdContact.DataSource = dv;
            SwitchItemStatus(new Context("NewContact", _Type > 0), new Context("EditContact", _Type > 0 && _HasContact), new Context("DelContact", _Type > 1 && _HasContact));
        }

        /// <summary>
        /// 初始化联系方式列表
        /// </summary>
        private void InitContactInfo()
        {
            var dv = _ContactInfo.Copy().DefaultView;
            dv.RowFilter = $"MasterDataId = '{glvContact.GetFocusedDataRow()["ID"]}'";

            grdOther.DataSource = dv;
            Format.GridFormat(gdvOther);
            gdvOther.Columns["联系方式"].Width = 80;
            gdvOther.Columns["号码"].Width = 140;
            gdvOther.Columns["主要"].Width = 40;
        }

        /// <summary>
        /// 根据输入条件查询数据
        /// </summary>
        private void Search()
        {
            _Filter = $"Type in ({_TypeFilter}) and 名称 like '%{bteSearch.Text.Trim()}%'";
            InitCustomer();
        }

        /// <summary>
        /// 获取行政区划数据
        /// </summary>
        private void GetRegion()
        {
            _Region = Commons.Dictionary("Region", false);
        }

        #endregion

        #region 按钮事件

        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitData();
                    break;

                case "NewCustomer":
                    Customer(false);
                    break;

                case "EditCustomer":
                    Customer(true);
                    break;

                case "DelCustomer":
                    DelCustomer();
                    break;

                case "Sharing":
                    Transfer(false);
                    break;

                case "Unshared":
                    Unshared();
                    break;

                case "Transfer":
                    Transfer(true);
                    break;

                case "Enable":
                    Enable();
                    break;

                case "NewContact":
                    Contact(false);
                    break;

                case "EditContact":
                    Contact(true);
                    break;

                case "DelContact":
                    DelContact();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑客户
        /// </summary>
        /// <param name="isEdit"></param>
        private void Customer(bool isEdit)
        {
            var rowHandle = gdvCustomer.FocusedRowHandle;
            var dig = new Customer
            {
                Owner = this,
                ObjectId = _CustomerId,
                IsEdit = isEdit,
                RegionData = _Region,
                StatuData = _Statu,
                ClassData = _Class
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitData();
                gdvCustomer.FocusedRowHandle = rowHandle;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除客户，如不能删除则设置状态为停用
        /// </summary>
        private void DelCustomer()
        {
            var row = gdvCustomer.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除客户【{row["名称"]}】吗?") != DialogResult.OK) return;

            switch (Commons.DelMasterData(_CustomerId))
            {
                case 0:
                    General.ShowError("对不起，该客户已经被使用，且无法停用！");
                    break;

                case 1:
                    _Customers.Rows.Find(row["ID"]).Delete();
                    _Customers.AcceptChanges();
                    InitCustomer();
                    break;

                case 2:
                    General.ShowWarning("该客户已被使用，无法删除，已停用！");
                    _Customers.Rows.Find(row["ID"])["Statu"] = "停用";
                    InitCustomer();
                    break;
            }
        }

        /// <summary>
        /// 共享/移交客户
        /// </summary>
        private void Transfer(bool isTransfer)
        {
            var dig = new Handover
            {
                Owner = this,
                IsTransfer = isTransfer,
                ObjectId = _CustomerId,
                MUId = isTransfer ? (Guid?) gdvCustomer.GetFocusedDataRow()["ID"] : null
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitData();
            }
            dig.Close();
        }

        /// <summary>
        /// 取消共享
        /// </summary>
        private void Unshared()
        {
            var dig = new Unshared
            {
                Owner = this,
                CustomerId = _CustomerId
            };
            dig.ShowDialog();
            dig.Close();
        }

        /// <summary>
        /// 将停用的选定数据重新启用
        /// </summary>
        private void Enable()
        {
            var row = gdvCustomer.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要启用【{row["名称"]}】吗?") != DialogResult.OK) return;

            if (!Commons.EnableMasterData(_CustomerId, "MDG_Customer"))
            {
                General.ShowError($"对不起，客户【{row["名称"]}】启用失败！");
                return;
            }
            
            _Customers.Rows.Find(row["ID"])["Statu"] = "正常";
            InitCustomer();
        }

        /// <summary>
        /// 新建/编辑联系人
        /// </summary>
        /// <param name="isEdit"></param>
        private void Contact(bool isEdit)
        {
            var fcr = glvContact.FocusedRowHandle;
            var dig = new Contact
            {
                Owner = this,
                ObjectId = isEdit ? _ContactId : Guid.Empty,
                ParentId = _CustomerId,
                IsEdit = isEdit
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                _Contacts = Commons.GetContacts();
                _ContactInfo = Commons.GetContactInfos();
                InitContact();
                glvContact.FocusedRowHandle = fcr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        private void DelContact()
        {
            var row = glvContact.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除【{row["姓名"]}】吗?") != DialogResult.OK) return;

            if (Commons.DelMasterData(_ContactId) <= 0)
            {
                General.ShowError($"对不起！删除联系人【{row["名称"]}】失败。");
                return;
            }
            
            if (row["主要联系人"].ToString() == "是")
            {
                General.ShowWarning("您删除了一个主要联系人，请为该客户设定一个新的主要联系人！");
            }
            _Contacts.Rows.Find(row["ID"]).Delete();
            _Contacts.AcceptChanges();
            InitContact();
        }

        #endregion

    }
}
