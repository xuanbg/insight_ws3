using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class NodeMove : DialogBase
    {

        #region 属性

        /// <summary>
        /// 返回结果集
        /// </summary>
        public DataRow ObjectData { get; set; }

        #endregion

        #region 变量声明

        private SYS_Organization _Org;
        private DataTable _OrgList;
        private DataView _Orgs;

        #endregion

        #region 构造方法

        public NodeMove()
        {
            InitializeComponent();
            treOrg.SelectImageList = imgOrgTreeNode;
            treOrg.CustomDrawNodeImages += Format.CustomDrawOrgTreeNodeImages;
        }

        #endregion

        #region 界面事件处理

        /// <summary>
        /// 在窗体加载时初始化组织机构树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Move_Load(object sender, EventArgs e)
        {
            InitTree();
        }

        /// <summary>
        /// 1、如选取节点类型不同，取消用户选择节点
        /// 2、如目标节点下存在同类同名节点，提示用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlOrgList_EditValueChanged(object sender, EventArgs e)
        {
            if (trlOrgList.EditValue != null)
            {
                var type = (int)_OrgList.Rows.Find(trlOrgList.EditValue)["NodeType"];
                var id = (Guid)trlOrgList.EditValue;
                if (type < (_Org.NodeType == 3 ? 2 : 1) || id == _Org.ParentId)
                {
                    trlOrgList.EditValue = null;
                    return;
                }

                var filter = string.Format("ParentId = '{0}' and 名称 = '{1}' and NodeType = {2}", id, _Org.Name, _Org.NodeType);
                _Orgs.RowFilter = filter;
                if (_Orgs.Count > 0)
                {
                    General.ShowError(string.Format("您所选择的移动目标节点【{0}】下已经存在同类的同名节点！\r\n请使用【合并】功能而非【移动】功能合并到目标节点！", _OrgList.Rows.Find(trlOrgList.EditValue)["名称"]));
                    trlOrgList.EditValue = null;
                }
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化组织机构树
        /// </summary>
        private void InitTree()
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _Org = cli.GetOrg(OpenForm.UserSession, ObjectId);
                _OrgList = cli.GetOrgs(OpenForm.UserSession);
                _Orgs = _OrgList.Copy().DefaultView;
            }

            RemoveNode();
            Format.InitTreeListLookUpEdit(trlOrgList, _OrgList, "全称");
            treOrg.Columns["全称"].Visible = false;
            treOrg.Columns["简称"].Visible = false;
            treOrg.Columns["编码"].Visible = false;
        }

        /// <summary>
        /// 移除无关节点
        /// </summary>
        private void RemoveNode()
        {
            foreach (var row in _OrgList.Select("NodeType <= " + (_Org.NodeType == 3 ? 2 : _Org.NodeType)))
            {
                if (row.RowState != DataRowState.Modified && (Guid)row["ID"] != _Org.ID && (Guid)row["ID"] != _Org.ParentId)
                {
                    row.SetModified();
                }
                if ((Guid)row["ID"] != _Org.ID && !string.IsNullOrEmpty(row["ParentId"].ToString()))
                {
                    LoopTree((Guid)row["ParentId"]);
                }
            }
            SubNodes(_Org.ID);
            foreach (var row in _OrgList.Rows.Cast<DataRow>().Where(row => row.RowState != DataRowState.Modified))
            {
                row.Delete();
            }
            _OrgList.AcceptChanges();
        }

        /// <summary>
        /// 设置所选节点的同类型节点及其父节点状态为不可删除
        /// </summary>
        /// <param name="id"></param>
        private void LoopTree(Guid id)
        {
            while (true)
            {
                var row = _OrgList.Rows.Find(id);
                if (row.RowState != DataRowState.Modified && (Guid) row["ID"] != _Org.ID)
                {
                    row.SetModified();
                }
                if (!string.IsNullOrEmpty(row["ParentId"].ToString()))
                {
                    id = (Guid) row["ParentId"];
                    continue;
                }
                break;
            }
        }

        /// <summary>
        /// 设置所选节点的子节点状态为可删除
        /// </summary>
        /// <param name="id"></param>
        private void SubNodes(Guid id)
        {
            foreach (var row in _OrgList.Select(string.Format("ParentId = '{0}'", id)))
            {
                if (row.RowState == DataRowState.Modified)
                {
                    row.AcceptChanges();
                }
                SubNodes((Guid)row["ID"]);
            }
        }

        #endregion

        #region 重写虚方法实现

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (trlOrgList.EditValue == null)
            {
                MessageBox.Show(string.Format("请选择节点【{0}】的移动目标节点！", _Org.Name));
                return;
            }

            _Org.ParentId = (Guid) trlOrgList.EditValue;
            var filter = "ParentId " + (_Org.ParentId == null ? "is null" : string.Format("= '{0}'", _Org.ParentId));
            _Orgs.RowFilter = filter;
            _Org.Index = _Orgs.Count + 1;

            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.UpdateOrgParentId(OpenForm.UserSession, _Org))
                {
                    General.ShowError(string.Format("对不起，节点【{0}】移动失败！", _Org.Name));
                    return;
                }
                
                ObjectData["ParentId"] = _Org.ParentId;
                ObjectData["Index"] = _Org.Index;
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
