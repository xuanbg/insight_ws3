using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout.Events;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Common;
using Insight.WS.Client.MasterDatas.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class Employee : MdiBase
    {

        #region 变量声明

        private DataTable _OrgList;
        private DataTable _Employee;
        private Guid _TemplateId;
        private bool _HasEmployee;
        private bool _CanEdit;
        private bool _CanVacation;
        private bool _CanReturn;
        private bool _CanReinstated;

        public bool _NeedCoed;
        public bool _NeedType;
        public bool _NeedLeader;
        public bool _NeedId;
        public bool _NeedPhone;
        public bool _NeedMail;

        #endregion

        #region 构造函数

        public Employee()
        {
            InitializeComponent();
            treOrgList.CustomDrawNodeImages += Format.CustomDrawOrgTreeNodeImages;
        }

        #endregion

        #region 界面事件

        private void Employee_Load(object sender, EventArgs e)
        {
            InitToolBar();
            LoadParameters();
            InitOrgTree();
        }

        /// <summary>
        /// 点击分类刷新列表内容
        /// </summary>
        /// <param name="sender">引用</param>
        /// <param name="e">分类事件</param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            using (var cli = new MasterDatasClient(Binding, Address))
            {
                _Employee = cli.GetEmployees(UserSession, (Guid) e.Node.GetValue("ID"));
            }

            InitEmployee();
        }

        /// <summary>
        /// 选择项目切换工具栏图标状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvEmployee_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (!_HasEmployee) return;
            var row = gdvEmployee.GetFocusedDataRow();
            _CanEdit = (int)row["Permission"] == 1;
            _CanVacation = _CanEdit && row["状态"].ToString() == "正常";
            _CanReturn = _CanEdit && row["状态"].ToString() == "休假";
            _CanReinstated = _CanEdit && row["状态"].ToString() == "离职";
            SwitchItemStatus(new Context("Edit", _CanEdit), new Context("Delete", _CanEdit), new Context("Print", _CanEdit), new Context("Preview", _CanEdit), new Context("Vacation", _CanVacation), new Context("Return", _CanReturn), new Context("Quit", _CanVacation), new Context("Reinstated", _CanReinstated));
        }

        /// <summary>
        /// 双击项目进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (_CanEdit) EmployeeData(true);
        }

        /// <summary>
        /// 刷新卡片状态图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvEmployee_CustomCardCaptionImage(object sender, LayoutViewCardCaptionImageEventArgs e)
        {
            e.ImageList = imgCard;
            e.ImageIndex = gdvEmployee.FocusedRowHandle == e.RowHandle ? 0 : 1;
        }

        /// <summary>
        /// 选择查看范围后刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitEmployee();
        }

        /// <summary>
        /// 输入回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteditSearch_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化组织机构树
        /// </summary>
        private void InitOrgTree()
        {
            _OrgList = Commons.OrgTree();

            var ids = new List<object>();
            treOrgList.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => ids.Add(n.GetValue("ID")));
            var fid = treOrgList.FocusedNode == null ? null : treOrgList.FocusedNode.GetValue("ID");

            var dv = _OrgList.DefaultView;
            dv.RowFilter = "NodeType < 3";
            treOrgList.DataSource = dv;
            Format.TreeFormat(treOrgList);
            treOrgList.ExpandToLevel(0);
            treOrgList.MoveFirst();

            ids.ForEach(id => { treOrgList.FindNodeByKeyID(id).Expanded = true; });
            treOrgList.FocusedNode = treOrgList.FindNodeByKeyID(fid);
        }

        /// <summary>
        /// 初始化费用数据
        /// </summary>
        private void InitEmployee()
        {
            var dv = _Employee.Copy().DefaultView;
            dv.RowFilter = cmbStatus.SelectedIndex == 0 ? "状态 <> '离职'" : "状态 = '离职'";
            _HasEmployee = dv.Count > 0;
            grdEmployee.DataSource = dv;

            SwitchItemStatus(new Context("Entry", (int)treOrgList.FocusedNode.GetValue("NodeType") == 2));
            if (!_HasEmployee)
            {
                SwitchItemStatus(new Context("Edit", false), new Context("Delete", false), new Context("Print", false), new Context("Preview", false), new Context("Vacation", false), new Context("Return", false), new Context("Quit", false), new Context("Reinstated", false));
            }
        }

        /// <summary>
        /// 根据输入条件查询数据
        /// </summary>
        private void Search()
        {
            if (bteSearch.EditValue == null) return;
            using (var cli = new MasterDatasClient(Binding, Address))
            {
                _Employee = cli.GetEmployeesForName(UserSession, bteSearch.Text.Trim());
            }

            _HasEmployee = _Employee.Rows.Count > 0;
            InitEmployee();
        }

        /// <summary>
        /// 载入选项参数
        /// </summary>
        private void LoadParameters()
        {
            ReadModuleParameter();

            // 打印模板
            var pvs = GetParameter("85A80D3E-6DB7-496E-BF6F-B1008B1D87B2");
            _TemplateId = pvs.Count > 0 && pvs[0] != null ? Guid.Parse(pvs[0]) : Guid.Empty;

            // 工号是否必填
            pvs = GetParameter("9B2CB116-6E3B-4A9F-9279-E3F568514BEE");
            _NeedCoed = pvs.Count > 0 && bool.Parse(pvs[0]);

            // 工种是否必填
            pvs = GetParameter("6EEF8490-B3F5-46BA-86FB-7F0F93B89537");
            _NeedType = pvs.Count > 0 && bool.Parse(pvs[0]);

            // 直属领导是否必填
            pvs = GetParameter("DC385162-A8E1-4762-80AD-8314BB522B08");
            _NeedLeader = pvs.Count > 0 && bool.Parse(pvs[0]);

            // 身份证号是否必填
            pvs = GetParameter("4CFB84C4-482B-49D6-9463-7FE92B23B9FE");
            _NeedId = pvs.Count > 0 && bool.Parse(pvs[0]);

            // 移动电话是否必填
            pvs = GetParameter("5CE32EC5-1E64-416E-8570-DE7DEEAE18AD");
            _NeedPhone = pvs.Count > 0 && bool.Parse(pvs[0]);

            // 电子邮件是否必填
            pvs = GetParameter("9308DB9F-193B-444C-B0FF-1A4617022D04");
            _NeedMail = pvs.Count > 0 && bool.Parse(pvs[0]);
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 点击工具条中的按钮
        /// </summary>
        /// <param name="sender">引用</param>
        /// <param name="e">工具条事件</param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitOrgTree();
                    break;

                case "Entry":
                    EmployeeData(false);
                    break;

                case "Edit":
                    EmployeeData(true);
                    break;

                case "Delete":
                    DeleteData();
                    break;

                case "Print":
                    PrintImage((Guid)gdvEmployee.GetFocusedDataRow()["ID"], _TemplateId);
                    break;

                case "Preview":
                    PreviewImage((Guid)gdvEmployee.GetFocusedDataRow()["ID"], _TemplateId);
                    break;

                case "Vacation":
                    UpdateStatus(1, "休假");
                    break;

                case "Return":
                    UpdateStatus(2, "销假");
                    break;

                case "Quit":
                    UpdateStatus(3, "离职");
                    break;

                case "Reinstated":
                    UpdateStatus(4, "复职");
                    break;

                case "Setting":
                    Setting();
                    break;
            }
        }

        /// <summary>
        /// 添加编辑数据
        /// </summary>
        /// <param name="isEdit"></param>
        private void EmployeeData(bool isEdit)
        {
            var fr = gdvEmployee.FocusedRowHandle;
            var dig = new EmployeeData
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId =
                    isEdit ? (Guid) gdvEmployee.GetFocusedDataRow()["ID"] : (Guid) treOrgList.FocusedNode.GetValue("ID")
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitOrgTree();
                gdvEmployee.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void DeleteData()
        {
            var row = gdvEmployee.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要删除【{0}】吗?", row["姓名"])) != DialogResult.OK) return;

            var result = Commons.DelMasterData((Guid)row["ID"]);
            if (result > 0)
            {
                _Employee.Rows.Find(row["ID"]).Delete();
                _Employee.AcceptChanges();
            }
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="stu"></param>
        /// <param name="msg"></param>
        private void UpdateStatus(int stu, string msg)
        {
            var row = gdvEmployee.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("员工【{0}】确定要{1}吗?", row["姓名"], msg)) != DialogResult.OK) return;

            using (var cli = new MasterDatasClient(Binding, Address))
            {
                var result = cli.UpdateStatus(UserSession, (Guid) row["ID"], stu);
                if (!result)
                {
                    General.ShowError(string.Format("对不起，员工【{0}】{1}操作失败！", row["名称"], msg));
                    return;
                }
                
                _Employee.Rows.Find(row["ID"])["状态"] = stu%2 == 0 ? "正常" : msg;
                if (stu == 3) _Employee.Rows.Find(row["ID"])["离职日期"] = DateTime.Now;
                if (stu == 4) _Employee.Rows.Find(row["ID"])["离职日期"] = DBNull.Value;
                InitEmployee();
            }
        }

        private void Setting()
        {
            var dig = new Setting {Owner = this};
            if (dig.ShowDialog() == DialogResult.OK)
            {
                WriteModuleParameter(dig.Parameters);
                LoadParameters();
                InitOrgTree();
            }
            dig.Close();
        }

        #endregion

    }
}
