--delete BASE_Category dbcc checkident(BASE_Category, reseed, 0)
--dbcc checkident(MasterData, reseed, 0)

/*****初始化报表分类*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 1, '报表', 'Report', 1, 1 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 2, '票据', 'Bill', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 3, '标签', 'Label', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 4, '申请表', 'Apply', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 5, '合同', 'Contract', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 6, '订单', 'Order', 1, 0 union all
select 'DD46BA9F-A345-4CEC-AE00-26561460E470', 7, '其它', 'Other', 1, 0

/*****初始化物资分类*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 1, '固定资产', 'FixedAssets', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 2, '低值易耗品', 'Consumable', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 3, '周转材料', 'Turnover', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 4, '零部件', 'Parts', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 5, '原材料', 'Material', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 6, '半成品', 'SemiProduct', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 7, '产成品', 'Product', 1, 1 union all
select 'AE251B20-4B82-4754-B404-77CE35F4F57E', 8, '主营商品', 'Commodity', 1, 1

/*****初始化项目分类*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select '993D148D-C062-4850-8D3E-FD4F12814F99', 1, '内置项目', 'BuiltIn', 1, 0 union all
select '993D148D-C062-4850-8D3E-FD4F12814F99', 2, '收费项目', 'Charge', 1, 1 union all
select '993D148D-C062-4850-8D3E-FD4F12814F99', 3, '支出项目', 'Spend', 1, 1


DECLARE @ModuleId UNIQUEIDENTIFIER
SET @ModuleId = '5C801552-1905-452B-AE7F-E57227BE70B8'

/*****初始化字典根分类*****/

INSERT BASE_Category (ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select @ModuleId, 1, '系统字典', 'System', 1, 0 union all
select @ModuleId, 2, '业务字典', 'Business', 0, 0 union all
select @ModuleId, 3, '用户字典', 'UserData', 1, 1

INSERT BASE_Category (ParentId, ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select ID, @ModuleId, 1, N'国家/地区', 'Country', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 2, N'行政区划', 'Region', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 3, N'行业类型', 'Industry', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 4, N'企业类型', 'Enterprise', BuiltIn, Visible from BASE_Category where Alias = 'System' union all
select ID, @ModuleId, 5, N'结算币种', 'Currency', BuiltIn, Visible from BASE_Category where Alias = 'System' union all

select ID, @ModuleId, 1, N'规格单位', 'Unit', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 2, N'结算方式', 'Settlement', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 3, N'涉密等级', 'Securitylevel', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 4, N'联系方式', 'Contact', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 5, N'VIP等级', 'VIPlevel', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 6, N'存储方式', 'Storage', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 7, N'岗位', 'Position', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 8, N'工种', 'WorkType', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 9, N'客户类型', 'CustomerClass', BuiltIn, Visible from BASE_Category where Alias = 'Business' union all
select ID, @ModuleId, 10, N'客户状态', 'CustomerStatu', BuiltIn, Visible from BASE_Category where Alias = 'Business'

/*****初始化主数据分类（字典）*****/

INSERT BASE_Category (ParentId, ModuleId, [Index], Name, Alias, BuiltIn, Visible)
select ID, @ModuleId, 1, N'首字母 A', N'A', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 2, N'首字母 B', N'B', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 3, N'首字母 C', N'C', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 4, N'首字母 D', N'D', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 5, N'首字母 E', N'E', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 6, N'首字母 F', N'F', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 7, N'首字母 G', N'G', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 8, N'首字母 H', N'H', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 9, N'首字母 I', N'I', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 10, N'首字母 J', N'J', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 11, N'首字母 K', N'K', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 12, N'首字母 L', N'L', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 13, N'首字母 M', N'M', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 14, N'首字母 N', N'N', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 15, N'首字母 O', N'O', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 16, N'首字母 P', N'P', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 17, N'首字母 Q', N'Q', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 18, N'首字母 R', N'R', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 19, N'首字母 S', N'S', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 20, N'首字母 T', N'T', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 21, N'首字母 U', N'U', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 22, N'首字母 V', N'V', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 23, N'首字母 Y', N'Y', BuiltIn, Visible from BASE_Category where Alias = 'Country' union all
select ID, @ModuleId, 24, N'首字母 Z', N'Z', BuiltIn, Visible from BASE_Category where Alias = 'Country'

INSERT BASE_Category (ParentId, ModuleId, [Index], Code, Name, Alias, BuiltIn, Visible)
select ID, @ModuleId, 1, N'110000', N'北京市', '京', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 2, N'120000', N'天津市', '津', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 3, N'130000', N'河北省', '冀', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 4, N'140000', N'山西省', '晋', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 5, N'150000', N'内蒙古自治区', '蒙', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 6, N'210000', N'辽宁省', '辽', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 7, N'220000', N'吉林省', '吉', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 8, N'230000', N'黑龙江省', '黑', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 9, N'310000', N'上海市', '沪', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 10, N'320000', N'江苏省', '苏', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 11, N'330000', N'浙江省', '浙', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 12, N'340000', N'安徽省', '皖', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 13, N'350000', N'福建省', '闽', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 14, N'360000', N'江西省', '赣', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 15, N'370000', N'山东省', '鲁', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 16, N'410000', N'河南省', '豫', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 17, N'420000', N'湖北省', '鄂', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 18, N'430000', N'湖南省', '湘', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 19, N'440000', N'广东省', '粤', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 20, N'450000', N'广西壮族自治区', '桂', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 21, N'460000', N'海南省', '琼', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 22, N'500000', N'重庆市', '渝', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 23, N'510000', N'四川省', '川', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 24, N'520000', N'贵州省', '黔', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 25, N'530000', N'云南省', '滇', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 26, N'540000', N'西藏自治区', '藏', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 27, N'610000', N'陕西省', '陕', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 28, N'620000', N'甘肃省', '甘', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 29, N'630000', N'青海省', '青', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 30, N'640000', N'宁夏回族自治区', '宁', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 31, N'650000', N'新疆维吾尔自治区', '新', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 32, N'710000', N'台湾省', '台', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 33, N'810000', N'香港特别行政区', '港', BuiltIn, Visible from BASE_Category where Alias = 'Region' union all
select ID, @ModuleId, 34, N'820000', N'澳门特别行政区', '澳', BuiltIn, Visible from BASE_Category where Alias = 'Region'

INSERT BASE_Category (ParentId, ModuleId, [Index], Code, Name, BuiltIn, Visible)
select ID, @ModuleId, 1, N'110100', N'市辖区', BuiltIn, Visible from BASE_Category where Alias = '京' union all
select ID, @ModuleId, 2, N'110200', N'县', BuiltIn, Visible from BASE_Category where Alias = '京' union all
select ID, @ModuleId, 1, N'120100', N'市辖区', BuiltIn, Visible from BASE_Category where Alias = '津' union all
select ID, @ModuleId, 2, N'120200', N'县', BuiltIn, Visible from BASE_Category where Alias = '津' union all
select ID, @ModuleId, 1, N'130100', N'石家庄市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 2, N'130200', N'唐山市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 3, N'130300', N'秦皇岛市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 4, N'130400', N'邯郸市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 5, N'130500', N'邢台市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 6, N'130600', N'保定市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 7, N'130700', N'张家口市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 8, N'130800', N'承德市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 9, N'130900', N'沧州市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 10, N'131000', N'廊坊市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 11, N'131100', N'衡水市', BuiltIn, Visible from BASE_Category where Alias = '冀' union all
select ID, @ModuleId, 1, N'140100', N'太原市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 2, N'140200', N'大同市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 3, N'140300', N'阳泉市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 4, N'140400', N'长治市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 5, N'140500', N'晋城市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 6, N'140600', N'朔州市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 7, N'140700', N'晋中市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 8, N'140800', N'运城市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 9, N'140900', N'忻州市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 10, N'141000', N'临汾市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 11, N'141100', N'吕梁市', BuiltIn, Visible from BASE_Category where Alias = '晋' union all
select ID, @ModuleId, 1, N'150100', N'呼和浩特市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 2, N'150200', N'包头市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 3, N'150300', N'乌海市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 4, N'150400', N'赤峰市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 5, N'150500', N'通辽市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 6, N'150600', N'鄂尔多斯市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 7, N'150700', N'呼伦贝尔市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 8, N'150800', N'巴彦淖尔市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 9, N'150900', N'乌兰察布市', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 10, N'152200', N'兴安盟', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 11, N'152500', N'锡林郭勒盟', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 12, N'152900', N'阿拉善盟', BuiltIn, Visible from BASE_Category where Alias = '蒙' union all
select ID, @ModuleId, 1, N'210100', N'沈阳市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 2, N'210200', N'大连市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 3, N'210300', N'鞍山市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 4, N'210400', N'抚顺市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 5, N'210500', N'本溪市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 6, N'210600', N'丹东市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 7, N'210700', N'锦州市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 8, N'210800', N'营口市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 9, N'210900', N'阜新市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 10, N'211000', N'辽阳市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 11, N'211100', N'盘锦市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 12, N'211200', N'铁岭市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 13, N'211300', N'朝阳市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 14, N'211400', N'葫芦岛市', BuiltIn, Visible from BASE_Category where Alias = '辽' union all
select ID, @ModuleId, 1, N'220100', N'长春市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 2, N'220200', N'吉林市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 3, N'220300', N'四平市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 4, N'220400', N'辽源市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 5, N'220500', N'通化市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 6, N'220600', N'白山市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 7, N'220700', N'松原市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 8, N'220800', N'白城市', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 9, N'222400', N'延边朝鲜族自治州', BuiltIn, Visible from BASE_Category where Alias = '吉' union all
select ID, @ModuleId, 1, N'230100', N'哈尔滨市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 2, N'230200', N'齐齐哈尔市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 3, N'230300', N'鸡西市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 4, N'230400', N'鹤岗市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 5, N'230500', N'双鸭山市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 6, N'230600', N'大庆市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 7, N'230700', N'伊春市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 8, N'230800', N'佳木斯市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 9, N'230900', N'七台河市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 10, N'231000', N'牡丹江市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 11, N'231100', N'黑河市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 12, N'231200', N'绥化市', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 13, N'232700', N'大兴安岭地区', BuiltIn, Visible from BASE_Category where Alias = '黑' union all
select ID, @ModuleId, 1, N'310100', N'市辖区', BuiltIn, Visible from BASE_Category where Alias = '沪' union all
select ID, @ModuleId, 2, N'310200', N'县', BuiltIn, Visible from BASE_Category where Alias = '沪' union all
select ID, @ModuleId, 1, N'320100', N'南京市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 2, N'320200', N'无锡市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 3, N'320300', N'徐州市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 4, N'320400', N'常州市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 5, N'320500', N'苏州市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 6, N'320600', N'南通市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 7, N'320700', N'连云港市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 8, N'320800', N'淮安市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 9, N'320900', N'盐城市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 10, N'321000', N'扬州市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 11, N'321100', N'镇江市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 12, N'321200', N'泰州市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 13, N'321300', N'宿迁市', BuiltIn, Visible from BASE_Category where Alias = '苏' union all
select ID, @ModuleId, 1, N'330100', N'杭州市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 2, N'330200', N'宁波市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 3, N'330300', N'温州市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 4, N'330400', N'嘉兴市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 5, N'330500', N'湖州市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 6, N'330600', N'绍兴市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 7, N'330700', N'金华市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 8, N'330800', N'衢州市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 9, N'330900', N'舟山市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 10, N'331000', N'台州市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 11, N'331100', N'丽水市', BuiltIn, Visible from BASE_Category where Alias = '浙' union all
select ID, @ModuleId, 1, N'340100', N'合肥市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 2, N'340200', N'芜湖市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 3, N'340300', N'蚌埠市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 4, N'340400', N'淮南市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 5, N'340500', N'马鞍山市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 6, N'340600', N'淮北市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 7, N'340700', N'铜陵市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 8, N'340800', N'安庆市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 9, N'341000', N'黄山市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 10, N'341100', N'滁州市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 11, N'341200', N'阜阳市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 12, N'341300', N'宿州市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 13, N'341500', N'六安市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 14, N'341600', N'亳州市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 15, N'341700', N'池州市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 16, N'341800', N'宣城市', BuiltIn, Visible from BASE_Category where Alias = '皖' union all
select ID, @ModuleId, 1, N'350100', N'福州市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 2, N'350200', N'厦门市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 3, N'350300', N'莆田市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 4, N'350400', N'三明市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 5, N'350500', N'泉州市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 6, N'350600', N'漳州市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 7, N'350700', N'南平市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 8, N'350800', N'龙岩市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 9, N'350900', N'宁德市', BuiltIn, Visible from BASE_Category where Alias = '闽' union all
select ID, @ModuleId, 1, N'360100', N'南昌市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 2, N'360200', N'景德镇市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 3, N'360300', N'萍乡市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 4, N'360400', N'九江市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 5, N'360500', N'新余市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 6, N'360600', N'鹰潭市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 7, N'360700', N'赣州市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 8, N'360800', N'吉安市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 9, N'360900', N'宜春市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 10, N'361000', N'抚州市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 11, N'361100', N'上饶市', BuiltIn, Visible from BASE_Category where Alias = '赣' union all
select ID, @ModuleId, 1, N'370100', N'济南市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 2, N'370200', N'青岛市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 3, N'370300', N'淄博市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 4, N'370400', N'枣庄市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 5, N'370500', N'东营市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 6, N'370600', N'烟台市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 7, N'370700', N'潍坊市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 8, N'370800', N'济宁市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 9, N'370900', N'泰安市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 10, N'371000', N'威海市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 11, N'371100', N'日照市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 12, N'371200', N'莱芜市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 13, N'371300', N'临沂市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 14, N'371400', N'德州市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 15, N'371500', N'聊城市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 16, N'371600', N'滨州市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 17, N'371700', N'菏泽市', BuiltIn, Visible from BASE_Category where Alias = '鲁' union all
select ID, @ModuleId, 1, N'410100', N'郑州市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 2, N'410200', N'开封市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 3, N'410300', N'洛阳市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 4, N'410400', N'平顶山市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 5, N'410500', N'安阳市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 6, N'410600', N'鹤壁市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 7, N'410700', N'新乡市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 8, N'410800', N'焦作市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 9, N'410900', N'濮阳市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 10, N'411000', N'许昌市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 11, N'411100', N'漯河市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 12, N'411200', N'三门峡市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 13, N'411300', N'南阳市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 14, N'411400', N'商丘市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 15, N'411500', N'信阳市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 16, N'411600', N'周口市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 17, N'411700', N'驻马店市', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 18, N'419000', N'省直辖县级行政区划', BuiltIn, Visible from BASE_Category where Alias = '豫' union all
select ID, @ModuleId, 1, N'420100', N'武汉市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 2, N'420200', N'黄石市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 3, N'420300', N'十堰市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 4, N'420500', N'宜昌市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 5, N'420600', N'襄阳市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 6, N'420700', N'鄂州市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 7, N'420800', N'荆门市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 8, N'420900', N'孝感市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 9, N'421000', N'荆州市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 10, N'421100', N'黄冈市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 11, N'421200', N'咸宁市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 12, N'421300', N'随州市', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 13, N'422800', N'恩施土家族苗族自治州', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 14, N'429000', N'省直辖县级行政区划', BuiltIn, Visible from BASE_Category where Alias = '鄂' union all
select ID, @ModuleId, 1, N'430100', N'长沙市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 2, N'430200', N'株洲市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 3, N'430300', N'湘潭市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 4, N'430400', N'衡阳市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 5, N'430500', N'邵阳市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 6, N'430600', N'岳阳市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 7, N'430700', N'常德市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 8, N'430800', N'张家界市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 9, N'430900', N'益阳市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 10, N'431000', N'郴州市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 11, N'431100', N'永州市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 12, N'431200', N'怀化市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 13, N'431300', N'娄底市', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 14, N'433100', N'湘西土家族苗族自治州', BuiltIn, Visible from BASE_Category where Alias = '湘' union all
select ID, @ModuleId, 1, N'440100', N'广州市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 2, N'440200', N'韶关市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 3, N'440300', N'深圳市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 4, N'440400', N'珠海市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 5, N'440500', N'汕头市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 6, N'440600', N'佛山市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 7, N'440700', N'江门市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 8, N'440800', N'湛江市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 9, N'440900', N'茂名市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 10, N'441200', N'肇庆市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 11, N'441300', N'惠州市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 12, N'441400', N'梅州市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 13, N'441500', N'汕尾市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 14, N'441600', N'河源市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 15, N'441700', N'阳江市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 16, N'441800', N'清远市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 17, N'441900', N'东莞市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 18, N'442000', N'中山市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 19, N'445100', N'潮州市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 20, N'445200', N'揭阳市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 21, N'445300', N'云浮市', BuiltIn, Visible from BASE_Category where Alias = '粤' union all
select ID, @ModuleId, 1, N'450100', N'南宁市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 2, N'450200', N'柳州市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 3, N'450300', N'桂林市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 4, N'450400', N'梧州市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 5, N'450500', N'北海市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 6, N'450600', N'防城港市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 7, N'450700', N'钦州市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 8, N'450800', N'贵港市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 9, N'450900', N'玉林市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 10, N'451000', N'百色市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 11, N'451100', N'贺州市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 12, N'451200', N'河池市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 13, N'451300', N'来宾市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 14, N'451400', N'崇左市', BuiltIn, Visible from BASE_Category where Alias = '桂' union all
select ID, @ModuleId, 1, N'460100', N'海口市', BuiltIn, Visible from BASE_Category where Alias = '琼' union all
select ID, @ModuleId, 2, N'460200', N'三亚市', BuiltIn, Visible from BASE_Category where Alias = '琼' union all
select ID, @ModuleId, 3, N'460300', N'三沙市', BuiltIn, Visible from BASE_Category where Alias = '琼' union all
select ID, @ModuleId, 4, N'469000', N'省直辖县级行政区划', BuiltIn, Visible from BASE_Category where Alias = '琼' union all
select ID, @ModuleId, 1, N'500100', N'市辖区', BuiltIn, Visible from BASE_Category where Alias = '渝' union all
select ID, @ModuleId, 2, N'500200', N'县', BuiltIn, Visible from BASE_Category where Alias = '渝' union all
select ID, @ModuleId, 1, N'510100', N'成都市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 2, N'510300', N'自贡市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 3, N'510400', N'攀枝花市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 4, N'510500', N'泸州市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 5, N'510600', N'德阳市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 6, N'510700', N'绵阳市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 7, N'510800', N'广元市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 8, N'510900', N'遂宁市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 9, N'511000', N'内江市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 10, N'511100', N'乐山市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 11, N'511300', N'南充市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 12, N'511400', N'眉山市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 13, N'511500', N'宜宾市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 14, N'511600', N'广安市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 15, N'511700', N'达州市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 16, N'511800', N'雅安市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 17, N'511900', N'巴中市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 18, N'512000', N'资阳市', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 19, N'513200', N'阿坝藏族羌族自治州', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 20, N'513300', N'甘孜藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 21, N'513400', N'凉山彝族自治州', BuiltIn, Visible from BASE_Category where Alias = '川' union all
select ID, @ModuleId, 1, N'520100', N'贵阳市', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 2, N'520200', N'六盘水市', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 3, N'520300', N'遵义市', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 4, N'520400', N'安顺市', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 5, N'520500', N'毕节市', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 6, N'520600', N'铜仁市', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 7, N'522300', N'黔西南布依族苗族自治州', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 8, N'522600', N'黔东南苗族侗族自治州', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 9, N'522700', N'黔南布依族苗族自治州', BuiltIn, Visible from BASE_Category where Alias = '黔' union all
select ID, @ModuleId, 1, N'530100', N'昆明市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 2, N'530300', N'曲靖市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 3, N'530400', N'玉溪市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 4, N'530500', N'保山市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 5, N'530600', N'昭通市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 6, N'530700', N'丽江市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 7, N'530800', N'普洱市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 8, N'530900', N'临沧市', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 9, N'532300', N'楚雄彝族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 10, N'532500', N'红河哈尼族彝族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 11, N'532600', N'文山壮族苗族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 12, N'532800', N'西双版纳傣族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 13, N'532900', N'大理白族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 14, N'533100', N'德宏傣族景颇族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 15, N'533300', N'怒江傈僳族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 16, N'533400', N'迪庆藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '滇' union all
select ID, @ModuleId, 1, N'540100', N'拉萨市', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 2, N'542100', N'昌都地区', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 3, N'542200', N'山南地区', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 4, N'542300', N'日喀则地区', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 5, N'542400', N'那曲地区', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 6, N'542500', N'阿里地区', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 7, N'542600', N'林芝地区', BuiltIn, Visible from BASE_Category where Alias = '藏' union all
select ID, @ModuleId, 1, N'610100', N'西安市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 2, N'610200', N'铜川市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 3, N'610300', N'宝鸡市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 4, N'610400', N'咸阳市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 5, N'610500', N'渭南市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 6, N'610600', N'延安市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 7, N'610700', N'汉中市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 8, N'610800', N'榆林市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 9, N'610900', N'安康市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 10, N'611000', N'商洛市', BuiltIn, Visible from BASE_Category where Alias = '陕' union all
select ID, @ModuleId, 1, N'620100', N'兰州市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 2, N'620200', N'嘉峪关市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 3, N'620300', N'金昌市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 4, N'620400', N'白银市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 5, N'620500', N'天水市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 6, N'620600', N'武威市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 7, N'620700', N'张掖市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 8, N'620800', N'平凉市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 9, N'620900', N'酒泉市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 10, N'621000', N'庆阳市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 11, N'621100', N'定西市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 12, N'621200', N'陇南市', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 13, N'622900', N'临夏回族自治州', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 14, N'623000', N'甘南藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '甘' union all
select ID, @ModuleId, 1, N'630100', N'西宁市', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 2, N'630200', N'海东市', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 3, N'632200', N'海北藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 4, N'632300', N'黄南藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 5, N'632500', N'海南藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 6, N'632600', N'果洛藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 7, N'632700', N'玉树藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 8, N'632800', N'海西蒙古族藏族自治州', BuiltIn, Visible from BASE_Category where Alias = '青' union all
select ID, @ModuleId, 1, N'640100', N'银川市', BuiltIn, Visible from BASE_Category where Alias = '宁' union all
select ID, @ModuleId, 2, N'640200', N'石嘴山市', BuiltIn, Visible from BASE_Category where Alias = '宁' union all
select ID, @ModuleId, 3, N'640300', N'吴忠市', BuiltIn, Visible from BASE_Category where Alias = '宁' union all
select ID, @ModuleId, 4, N'640400', N'固原市', BuiltIn, Visible from BASE_Category where Alias = '宁' union all
select ID, @ModuleId, 5, N'640500', N'中卫市', BuiltIn, Visible from BASE_Category where Alias = '宁' union all
select ID, @ModuleId, 1, N'650100', N'乌鲁木齐市', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 2, N'650200', N'克拉玛依市', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 3, N'652100', N'吐鲁番地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 4, N'652200', N'哈密地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 5, N'652300', N'昌吉回族自治州', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 6, N'652700', N'博尔塔拉蒙古自治州', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 7, N'652800', N'巴音郭楞蒙古自治州', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 8, N'652900', N'阿克苏地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 9, N'653000', N'克孜勒苏柯尔克孜自治州', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 10, N'653100', N'喀什地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 11, N'653200', N'和田地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 12, N'654000', N'伊犁哈萨克自治州', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 13, N'654200', N'塔城地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 14, N'654300', N'阿勒泰地区', BuiltIn, Visible from BASE_Category where Alias = '新' union all
select ID, @ModuleId, 15, N'659000', N'自治区直辖县级行政区划', BuiltIn, Visible from BASE_Category where Alias = '新'

INSERT BASE_Category (ParentId, ModuleId, [Index], Name, BuiltIn, Visible)
select ID, @ModuleId, 1, N'计价单位', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 2, N'数量单位', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 3, N'质量单位', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 4, N'体积单位', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 5, N'面积单位', BuiltIn, Visible from BASE_Category where Alias = 'Unit' union all
select ID, @ModuleId, 6, N'长度单位', BuiltIn, Visible from BASE_Category where Alias = 'Unit'

GO