using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class NodeMerge : DialogBase
    {

        #region 变量声明

        private SYS_Organization _Org;
        private SYS_OrgMerger _Merger;
        private DataTable _OrgList;
        private string _SourceNode;

        #endregion

        #region 构造方法

        public NodeMerge()
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
        private void Merge_Load(object sender, EventArgs e)
        {
            InitTree();
        }

        /// <summary>
        /// 如选取节点类型不同，取消用户选择节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlOrgList_EditValueChanged(object sender, EventArgs e)
        {
            if (trlOrgList.EditValue != null && (int)treOrg.FocusedNode.GetValue("NodeType") != _Org.NodeType)
            {
                trlOrgList.EditValue = null;
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
                _SourceNode = _OrgList.Rows.Find(ObjectId)["全称"].ToString();
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
            foreach (var row in _OrgList.Select("NodeType = " + _Org.NodeType))
            {
                if (row.RowState != DataRowState.Modified && (Guid)row["ID"] != _Org.ID)
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
            foreach (var row in _OrgList.Select(string.Format("NodeType = {0} and ParentId = '{1}'", _Org.NodeType, id)))
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
            if (General.ShowConfirm(string.Format("您确定要将节点【{0}】合并到【{1}】吗？\n\r警告！合并操作结果将不可逆转！", _SourceNode, trlOrgList.Text.Trim())) != DialogResult.OK) return;

            if (trlOrgList.EditValue == null)
            {
                General.ShowWarning(string.Format("请选择节点【{0}】的合并目标节点！", _Org.Name));
                return;
            }
            
            _Merger = new SYS_OrgMerger
            {
                OrgId = (Guid) trlOrgList.EditValue,
                MergerOrgId = ObjectId,
            };

            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.AddOrgMerger(OpenForm.UserSession, _Merger))
                {
                    General.ShowError(string.Format("对不起，节点【{0}】合并失败！", _Org.Name));
                    return;
                }
                
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
