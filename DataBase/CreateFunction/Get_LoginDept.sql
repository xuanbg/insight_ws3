IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_LoginDept') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_LoginDept
GO


/*****��ֵ��������ȡ��¼�û��Ŀɵ�¼����*****/

CREATE FUNCTION Get_LoginDept(
@LoginName                 VARCHAR(32)      --�û���¼��
)

RETURNS TABLE AS

RETURN

--����ְλ��Ա�û�
select D.ID, D.FullName
from Sys_User U
join Sys_OrgMember M on M.UserId = U.ID
join Sys_Organization P on P.ID = M.OrgId
  and P.Validity = 1
join Sys_Organization D on D.ID = P.ParentId
where U.LoginName = @loginName

union --�ϲ�ְλ��Ա�û�
select D.ID, D.FullName
from Sys_User U
join Sys_OrgMember M on M.UserId = U.ID
join Sys_OrgMerger OM on OM.MergerOrgId = M.OrgId
join Sys_Organization P on P.ID = OM.OrgId
join Sys_Organization D on D.ID = P.ParentId
where U.LoginName = @loginName

GO