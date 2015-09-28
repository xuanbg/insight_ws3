--delete BASE_Category dbcc checkident(BASE_Category, reseed, 0)
--dbcc checkident(MasterData, reseed, 0)

/*****��ʼ����������*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 1, '����', 'Report', 1, 1 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 2, 'Ʊ��', 'Bill', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 3, '��ǩ', 'Label', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 4, '�����', 'Apply', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 5, '��ͬ', 'Contract', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 6, '����', 'Order', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 7, '����', 'Other', 1, 0

/*****��ʼ�����ʷ���*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 1, '�̶��ʲ�', 'FixedAssets', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 2, '��ֵ�׺�Ʒ', 'Consumable', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 3, '��ת����', 'Turnover', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 4, '�㲿��', 'Parts', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 5, 'ԭ����', 'Material', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 6, '���Ʒ', 'SemiProduct', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 7, '����Ʒ', 'Product', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 8, '��Ӫ��Ʒ', 'Commodity', 1, 1

/*****��ʼ����Ŀ����*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select '993D148D-C062-4850-8D3E-FD4F12814F99', 1, '������Ŀ', 'BuiltIn', 1, 0 union all
select '993D148D-C062-4850-8D3E-FD4F12814F99', 2, '�շ���Ŀ', 'Charge', 1, 1 union all
select '993D148D-C062-4850-8D3E-FD4F12814F99', 3, '֧����Ŀ', 'Spend', 1, 1


DECLARE @ModuleId UNIQUEIDENTIFIER
SET @ModuleId = '5C801552-1905-452B-AE7F-E57227BE70B8'

/*****��ʼ���ֵ������*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select @ModuleId, 1, 'ϵͳ�ֵ�', 'System', 1, 0 union all
select @ModuleId, 2, 'ҵ���ֵ�', 'Business', 0, 0 union all
select @ModuleId, 3, '�û��ֵ�', 'UserData', 1, 1

INSERT BASE_Category (ParentId, ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select ID, @ModuleId, 1, N'����/����', 'Country', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 2, N'��������', 'Region', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 3, N'��ҵ����', 'Industry', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 4, N'��ҵ����', 'Enterprise', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 5, N'�������', 'Currency', BuiltIn, Visible from BASE_Category where Alias = 'System' union all

select ID, @ModuleId, 1, N'���λ', 'Unit', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 2, N'���㷽ʽ', 'Settlement', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 3, N'���ܵȼ�', 'Securitylevel', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 4, N'��ϵ��ʽ', 'Contact', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 5, N'VIP�ȼ�', 'VIPlevel', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 6, N'�洢��ʽ', 'Storage', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 7, N'��λ', 'Position', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 8, N'����', 'WorkType', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 9, N'�ͻ�����', 'CustomerClass', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 10, N'�ͻ�״̬', 'CustomerStatu', BuiltIn, Visible from BASE_Category where Alias = 'Business'

/*****��ʼ�������ݷ��ࣨ�ֵ䣩*****/

INSERT BASE_Category (ParentId, ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select ID, @ModuleId, 1, N'����ĸ A', N'A', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 2, N'����ĸ B', N'B', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 3, N'����ĸ C', N'C', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 4, N'����ĸ D', N'D', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 5, N'����ĸ E', N'E', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 6, N'����ĸ F', N'F', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 7, N'����ĸ G', N'G', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 8, N'����ĸ H', N'H', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 9, N'����ĸ I', N'I', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 10, N'����ĸ J', N'J', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 11, N'����ĸ K', N'K', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 12, N'����ĸ L', N'L', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 13, N'����ĸ M', N'M', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 14, N'����ĸ N', N'N', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 15, N'����ĸ O', N'O', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 16, N'����ĸ P', N'P', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 17, N'����ĸ Q', N'Q', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 18, N'����ĸ R', N'R', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 19, N'����ĸ S', N'S', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 20, N'����ĸ T', N'T', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 21, N'����ĸ U', N'U', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 22, N'����ĸ V', N'V', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 23, N'����ĸ Y', N'Y', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 24, N'����ĸ Z', N'Z', BuiltIn, Visible from BASE_Category where Alias = 'Country'

INSERT BASE_Category (ParentId, ModuleId, [Index], Code, Name, Alias, BuiltIn, Visible)
select ID, @ModuleId, 1, N'110000', N'������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 2, N'120000', N'�����', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 3, N'130000', N'�ӱ�ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 4, N'140000', N'ɽ��ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 5, N'150000', N'���ɹ�������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 6, N'210000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 7, N'220000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 8, N'230000', N'������ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 9, N'310000', N'�Ϻ���', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 10, N'320000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 11, N'330000', N'�㽭ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 12, N'340000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 13, N'350000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 14, N'360000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 15, N'370000', N'ɽ��ʡ', '³', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 16, N'410000', N'����ʡ', 'ԥ', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 17, N'420000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 18, N'430000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 19, N'440000', N'�㶫ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 20, N'450000', N'����׳��������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 21, N'460000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 22, N'500000', N'������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 23, N'510000', N'�Ĵ�ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 24, N'520000', N'����ʡ', 'ǭ', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 25, N'530000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 26, N'540000', N'����������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 27, N'610000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 28, N'620000', N'����ʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 29, N'630000', N'�ຣʡ', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 30, N'640000', N'���Ļ���������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 31, N'650000', N'�½�ά���������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 32, N'710000', N'̨��ʡ', '̨', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 33, N'810000', N'����ر�������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 34, N'820000', N'�����ر�������', '��', BuiltIn, Visible from BASE_Category where Alias = 'Region'

INSERT BASE_Category (ParentId, ModuleId, [Index], Code, Name, BuiltIn, Visible)
select ID, @ModuleId, 1, N'110100', N'��Ͻ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'110200', N'��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'120100', N'��Ͻ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'120200', N'��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'130100', N'ʯ��ׯ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'130200', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'130300', N'�ػʵ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'130400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'130500', N'��̨��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'130600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'130700', N'�żҿ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'130800', N'�е���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'130900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'131000', N'�ȷ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'131100', N'��ˮ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'140100', N'̫ԭ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'140200', N'��ͬ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'140300', N'��Ȫ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'140400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'140500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'140600', N'˷����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'140700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'140800', N'�˳���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'140900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'141000', N'�ٷ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'141100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'150100', N'���ͺ�����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'150200', N'��ͷ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'150300', N'�ں���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'150400', N'�����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'150500', N'ͨ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'150600', N'������˹��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'150700', N'���ױ�����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'150800', N'�����׶���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'150900', N'�����첼��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'152200', N'�˰���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'152500', N'���ֹ�����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'152900', N'��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'210100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'210200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'210300', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'210400', N'��˳��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'210500', N'��Ϫ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'210600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'210700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'210800', N'Ӫ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'210900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'211000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'211100', N'�̽���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'211200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'211300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'211400', N'��«����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'220100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'220200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'220300', N'��ƽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'220400', N'��Դ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'220500', N'ͨ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'220600', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'220700', N'��ԭ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'220800', N'�׳���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'222400', N'�ӱ߳�����������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'230100', N'��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'230200', N'���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'230300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'230400', N'�׸���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'230500', N'˫Ѽɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'230600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'230700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'230800', N'��ľ˹��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'230900', N'��̨����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'231000', N'ĵ������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'231100', N'�ں���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'231200', N'�绯��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'232700', N'���˰������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'310100', N'��Ͻ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'310200', N'��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'320100', N'�Ͼ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'320200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'320300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'320400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'320500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'320600', N'��ͨ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'320700', N'���Ƹ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'320800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'320900', N'�γ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'321000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'321100', N'����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'321200', N'̩����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'321300', N'��Ǩ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'330100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'330200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'330300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'330400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'330500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'330600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'330700', N'����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'330800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'330900', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'331000', N'̨����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'331100', N'��ˮ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'340100', N'�Ϸ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'340200', N'�ߺ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'340300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'340400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'340500', N'����ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'340600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'340700', N'ͭ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'340800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'341000', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'341100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'341200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'341300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'341500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'341600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 15, N'341700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 16, N'341800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'350100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'350200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'350300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'350400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'350500', N'Ȫ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'350600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'350700', N'��ƽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'350800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'350900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'360100', N'�ϲ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'360200', N'��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'360300', N'Ƽ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'360400', N'�Ž���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'360500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'360600', N'ӥ̶��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'360700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'360800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'360900', N'�˴���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'361000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'361100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'370100', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 2, N'370200', N'�ൺ��', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 3, N'370300', N'�Ͳ���', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 4, N'370400', N'��ׯ��', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 5, N'370500', N'��Ӫ��', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 6, N'370600', N'��̨��', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 7, N'370700', N'Ϋ����', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 8, N'370800', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 9, N'370900', N'̩����', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 10, N'371000', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 11, N'371100', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 12, N'371200', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 13, N'371300', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 14, N'371400', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 15, N'371500', N'�ĳ���', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 16, N'371600', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 17, N'371700', N'������', BuiltIn, Visible from BASE_Category where Alias = '³' union all
select ID, @ModuleId, 1, N'410100', N'֣����', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 2, N'410200', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 3, N'410300', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 4, N'410400', N'ƽ��ɽ��', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 5, N'410500', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 6, N'410600', N'�ױ���', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 7, N'410700', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 8, N'410800', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 9, N'410900', N'�����', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 10, N'411000', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 11, N'411100', N'�����', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 12, N'411200', N'����Ͽ��', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 13, N'411300', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 14, N'411400', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 15, N'411500', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 16, N'411600', N'�ܿ���', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 17, N'411700', N'פ������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 18, N'419000', N'ʡֱϽ�ؼ���������', BuiltIn, Visible from BASE_Category where Alias = 'ԥ' union all
select ID, @ModuleId, 1, N'420100', N'�人��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'420200', N'��ʯ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'420300', N'ʮ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'420500', N'�˲���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'420600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'420700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'420800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'420900', N'Т����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'421000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'421100', N'�Ƹ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'421200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'421300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'422800', N'��ʩ����������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'429000', N'ʡֱϽ�ؼ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'430100', N'��ɳ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'430200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'430300', N'��̶��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'430400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'430500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'430600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'430700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'430800', N'�żҽ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'430900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'431000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'431100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'431200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'431300', N'¦����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'433100', N'��������������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'440100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'440200', N'�ع���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'440300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'440400', N'�麣��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'440500', N'��ͷ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'440600', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'440700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'440800', N'տ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'440900', N'ï����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'441200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'441300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'441400', N'÷����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'441500', N'��β��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'441600', N'��Դ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 15, N'441700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 16, N'441800', N'��Զ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 17, N'441900', N'��ݸ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 18, N'442000', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 19, N'445100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 20, N'445200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 21, N'445300', N'�Ƹ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'450100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'450200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'450300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'450400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'450500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'450600', N'���Ǹ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'450700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'450800', N'�����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'450900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'451000', N'��ɫ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'451100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'451200', N'�ӳ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'451300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'451400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'460100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'460200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'460300', N'��ɳ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'469000', N'ʡֱϽ�ؼ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'500100', N'��Ͻ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'500200', N'��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'510100', N'�ɶ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'510300', N'�Թ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'510400', N'��֦����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'510500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'510600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'510700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'510800', N'��Ԫ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'510900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'511000', N'�ڽ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'511100', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'511300', N'�ϳ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'511400', N'üɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'511500', N'�˱���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'511600', N'�㰲��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 15, N'511700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 16, N'511800', N'�Ű���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 17, N'511900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 18, N'512000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 19, N'513200', N'���Ӳ���Ǽ��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 20, N'513300', N'���β���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 21, N'513400', N'��ɽ����������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'520100', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 2, N'520200', N'����ˮ��', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 3, N'520300', N'������', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 4, N'520400', N'��˳��', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 5, N'520500', N'�Ͻ���', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 6, N'520600', N'ͭ����', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 7, N'522300', N'ǭ���ϲ���������������', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 8, N'522600', N'ǭ�������嶱��������', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 9, N'522700', N'ǭ�ϲ���������������', BuiltIn, Visible from BASE_Category where Alias = 'ǭ' union all
select ID, @ModuleId, 1, N'530100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'530300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'530400', N'��Ϫ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'530500', N'��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'530600', N'��ͨ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'530700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'530800', N'�ն���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'530900', N'�ٲ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'532300', N'��������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'532500', N'��ӹ���������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'532600', N'��ɽ׳������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'532800', N'��˫���ɴ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'532900', N'��������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'533100', N'�º���徰����������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 15, N'533300', N'ŭ��������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 16, N'533400', N'�������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'540100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'542100', N'��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'542200', N'ɽ�ϵ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'542300', N'�տ������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'542400', N'��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'542500', N'�������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'542600', N'��֥����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'610100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'610200', N'ͭ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'610300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'610400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'610500', N'μ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'610600', N'�Ӱ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'610700', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'610800', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'610900', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'611000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'620100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'620200', N'��������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'620300', N'�����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'620400', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'620500', N'��ˮ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'620600', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'620700', N'��Ҵ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'620800', N'ƽ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'620900', N'��Ȫ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'621000', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'621100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'621200', N'¤����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'622900', N'���Ļ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'623000', N'���ϲ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'630100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'630200', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'632200', N'��������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'632300', N'���ϲ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'632500', N'���ϲ���������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'632600', N'�������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'632700', N'��������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'632800', N'�����ɹ������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'640100', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'640200', N'ʯ��ɽ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'640300', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'640400', N'��ԭ��', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'640500', N'������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 1, N'650100', N'��³ľ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 2, N'650200', N'����������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 3, N'652100', N'��³������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 4, N'652200', N'���ܵ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 5, N'652300', N'��������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 6, N'652700', N'���������ɹ�������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 7, N'652800', N'���������ɹ�������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 8, N'652900', N'�����յ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 9, N'653000', N'�������տ¶�����������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 10, N'653100', N'��ʲ����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 11, N'653200', N'�������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 12, N'654000', N'���������������', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 13, N'654200', N'���ǵ���', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 14, N'654300', N'����̩����', BuiltIn, Visible from BASE_Category where Alias = '��' union all
select ID, @ModuleId, 15, N'659000', N'������ֱϽ�ؼ���������', BuiltIn, Visible from BASE_Category where Alias = '��'

INSERT BASE_Category (ParentId, ModuleId, [Index], Name, BuiltIn, Visible)
select ID, @ModuleId, 1, N'�Ƽ۵�λ', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 2, N'������λ', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 3, N'������λ', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 4, N'�����λ', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 5, N'�����λ', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 6, N'���ȵ�λ', BuiltIn, Visible from BASE_Category where Alias = 'Unit'

GO