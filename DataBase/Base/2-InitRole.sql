USE Insight_Base
GO


/*****��ʼ����ɫ�������û�*****/

DECLARE @RoleId UNIQUEIDENTIFIER
delete SYS_Role where Name = '�����û�'
insert SYS_Role (Name, Description, BuiltIn, CreatorUserId) 
select '�����û�', '���ý�ɫ����ɫ��ԱΪȫ���û���Ա', 1, '00000000-0000-0000-0000-000000000000';
select @RoleId = ID from Sys_Role where SN = scope_identity()

-- ��ʼ����ɫ��Ա
insert SYS_Role_UserGroup (RoleId, GroupId, CreatorUserId)
select @RoleId, ID, '00000000-0000-0000-0000-000000000000' from SYS_UserGroup where Name = 'AllUsers'

-- ���ù���Ȩ��
insert SYS_RolePerm_Action (RoleId, ActionId, Action, CreatorUserId)
select @RoleId, A.ID, 1, '00000000-0000-0000-0000-000000000000'
from SYS_ModuleAction A
where A.ModuleId in('CED5A90C-092E-4B38-B21D-433DFD96BFDB', '05C1B3B4-1536-4DE7-864A-B98C474F438B')
  and A.ID not in('C6D59DAF-18C8-4A05-AA22-BA27CBC4595B', '076890FA-483A-4EBC-9168-D94367741FE9', 'EDBC058A-BDC2-4108-B690-1C2E9E65AD97')

-- ��������Ȩ��
insert SYS_RolePerm_Data (RoleId, ModuleId, Mode, Permission, CreatorUserId)
select @RoleId, '5C801552-1905-452B-AE7F-E57227BE70B8', 1, 1, '00000000-0000-0000-0000-000000000000' union all
select @RoleId, '5C801552-1905-452B-AE7F-E57227BE70B8', 0, 0, '00000000-0000-0000-0000-000000000000'
GO


/*****��ʼ����ɫ��ϵͳ����Ա*****/

DECLARE @RoleId UNIQUEIDENTIFIER
delete SYS_Role where Name = 'ϵͳ����Ա'
insert SYS_Role (Name, Description, BuiltIn, CreatorUserId) 
select 'ϵͳ����Ա', '���ý�ɫ����ɫ��ԱΪϵͳ����Ա���Ա', 1, '00000000-0000-0000-0000-000000000000';
select @RoleId = ID from Sys_Role where SN = scope_identity()

-- ��ʼ����ɫ��Ա
insert SYS_Role_UserGroup (RoleId, GroupId, CreatorUserId)
select @RoleId, ID, '00000000-0000-0000-0000-000000000000' from SYS_UserGroup where Name = 'Administers'

-- ���ù���Ȩ��
insert SYS_RolePerm_Action (RoleId, ActionId, Action, CreatorUserId)
select @RoleId, A.ID, 1, '00000000-0000-0000-0000-000000000000'
from SYS_ModuleAction A
join SYS_Module M on M.ID = A.ModuleId
  and (A.ID = 'EDBC058A-BDC2-4108-B690-1C2E9E65AD97'
    or M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
  
-- ��������Ȩ��
insert SYS_RolePerm_Data (RoleId, ModuleId, Mode, Permission, CreatorUserId)
select @RoleId, M.ID, 0, 1, '00000000-0000-0000-0000-000000000000'
from SYS_Module M
where M.Type = 1
and (M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
union all
select @RoleId, M.ID, 1, 1, '00000000-0000-0000-0000-000000000000'
from SYS_Module M
where M.Type = 1
and (M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
union all
select @RoleId, M.ID, 5, 1, '00000000-0000-0000-0000-000000000000'
from SYS_Module M
where M.Type = 1
and (M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
GO