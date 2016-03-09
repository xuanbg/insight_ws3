IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Employee') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Employee
GO


/*****��ͼ����ѯ����Ա��*****/

CREATE VIEW Employee
AS

select M.ID, O.ParentId as DeptId, isnull(E.Thumbnail, 0x89504E470D0A1A0A0000000D4948445200000078000000960804000000BF2384AB000000097048597300000B1300000B1301009A9C18000003196943435050686F746F73686F70204943432070726F66696C65000078DA6360609EE0E8E2E4CA24C0C050505452E41EE418191119A5C07E9E818D819981818181812131B9B8C03120C087818181212F3F2F9501037CBBC6C0C8C0C0C07059D7D1C5C9958134C09A5C5054C2C0C070808181C12825B538998181E10B0303437A794941090303630C03038348527641090303630103038348764890330303630B0303134F496A450903030383737E416551667A468982A1A5A5A582634A7E52AA42706571496A6EB182675E727E51417E5162496A0A030303D40E060606065E97FC1205F7C4CC3C05435355062A8388C82805F4F0418821407269511984C5C8C0C0C020C0A0C5E0C750C9B08AE101A3346314E33CC6A74C864C0D4C979835981B99EFB2D8B0CC636566CD66BDCAE6C4B6895D857D2687004727272B67331733571B3737F7441E299EA5BCC6BC87F882F99EF1570B0809AC1674137C24D428AC287C58245D945774AB589C38A7F85689144961C9A35215D2BAD24F64E6C886CA09CA9D95EF51F051E455BCA03445394A4549E5B5EA56B546753F0D598DB79AFBB4266AA7EA58EB0AE9BED23BA23FDFA0C630CAC8D258D2F8B7C93DD3C3662BCCFB2D2A2C13AD7CAC2D6C546D45EC58ECBEDA3F77B8ED78C1E998F35E97ADAEEBDD56BA2FF558E4B9D06B81F7429FC5BECBFC56F9AF0FD81AB837E858F0F9905BA1CFC2BE4430450A4629451BC7B8C546C5E5C5B724CC4EDC9C7436F9792A539A5CBA4D46546655D6ACEC3D39F7F298F2D50B7C0A8B8B66171F2E795B2651EE52515839AFEA6CF5DF5ABDBAF8FA490DC71A7F371BB4A4B7CE6BBBDE21D8E9DDD5DE7DB897A1CFBEBF6EC2BE89FF273B4E699D7A623AEF8CE099B3663D9AA335B764DEBE055C0BC3162D5EFC71A9C3B209CB1FAE345ED5BAFAE65ADD754DEB6F6E34D8D4B1F9C156AB6D53B77FD8E9BB6BD51E8EBDE9FB8E1F503FD879E8F511BFA39B8F8B9FA83DF9E4B4F7992DE764CFB75FF87429EEF2A9AB16D796DD10BDD97AEBEB9DF4BB37EFFB3C38F0C8F4F1EAA78ACF66BE107CD9F59AF94DDDDB9FEF4B3F7CFA54F0F9DDD7BC6FEF7EE4FFFCF0BBF8CFB77F55FFFF03002ABF1D8AF36F515B000000206348524D00007A25000080830000F9FF000080E9000075300000EA6000003A980000176F925FC54600000AE94944415478DAECDD799C55651DC7F137336CB3B08CA0A0A6A4E61EB86396C44E08844086394A546669A0692F95E4A5A610A6166A6A8B5626A2B9946220B8B0892B8A695899E642814A21EBA86CCE30FD711FAEC37067E62EE7CE0C75BE7FCD3973CE79E6C3B3FC96E7F7BC6851EDFF4B0562E01838068E8163E01838068E8163E01838068E8163E01838068E8163E01838068E8163E018B8F1D432D5CDDE4DF5D714E9A09D12AD55DA6CBD552A73F9DCA274819B401DECADBBE3ECA34CA9D62A6DB2C65F3CE205555136D4A2BAA97BB8ABA30DD0CB7E3AA5F8ED46F3DC6061743DDCB4C0BD9D6CA8831A786A8BC9A6ECFA437A80F1066B53E3CE5A6F5BEA2D1B6CD1527B9F76A2BDD1C60F55B93A8F8B569E55EC28E38D4CC256FABBC5E67ACD3BD6ECF06437635CA635265BE4D95D750E97BB2BF9F30A73DDEF091FD4F9F4487728C57CDFF5B7DC877453D8E157AC062B5DA1AF33CDA90797197E0CFA5BE8F706ED8A8EC79FFDD87AD7E9E34A6FA6F1FC9D3E04BB3BC52C57EE8A66A9BDBDFD3D8375E677FA2A561CAE2F0E7DBE0B9AA574B587DD7534D0B976C3FBFA5BD2FCCD522BD5593B8AABACC2D35E70B752ED8C37B6B99AA5368ED7CB61DA6BABDA161596586869965F7BC89DCEC610077ABD39021F6792810A6B19A50A33DDE4F9ACBE38CD194A75766CB6C00579E9D50E4AB531C6A306D7C24D2C596778DC75297DE786F462181D07378F217DA8613E632F252A6DD5530BB0DC4B5EF3BE02C57AE8A9138A5CA097F33D9D610B5B2DF3397457985D14151D7077E719A1F34EF7A7B8D50AD5C9F60E73BAB3B5C7B1EE33DE8C0CDB7917ECA79DF54D37A40B7DCF42DFDC097799AFBBD4721FDBBE4A2F9BA0BFF9602FD39C9A615BFF09A982A2A61BD25DDC6874327E9DEB19ABB5D2D13AF3BC95F28D170C31C904B4739BB5E666D0DA9A60E45A3615F0EEA61B18E6D7AF4DF3A7B4E6D656DFB7D63528F62B7D2D4BBBBD6D098729DBB199EB906EE33701779951C6793E83A5E45A93431038292C6FE9A82CFC837DD434C0537D112CD1DFEC8CDFBE22048AA7673093F708C05B9A0278AC7160B111190CCA9AC3738237D0C205DAA63D85607588A01A15784F9781F79C138C45E67AC7F5A0A77E69BED129C4D49B1B1F78AC03B0CD45FE9CC357EEF12A1895D6D3253E5163AD6E54E032A78179A6E5342DD69A098E569AC6D3ADC35343C3D06E44E0C3F5C036B7E46CD81261440FC7A7F1EC0637ABC6B1694F81C880F7032BB28C7A6A6AB17FA150F7B496B9E921F8EFD3D8C0078645676DCEC0EFF82BF8545A4F7F6839E8DAD8C0FB83753646E09C2E0B83BA24AD7C58A2E5B71A17B845583C3E8824F8783DC4B87BA7F1EC910E054F362E704178736324C02FDB84B2B456DE331561597A69BC28811361C7A64880DFB606ADD2001EE414709F771A1BB85584C0152AC06E0D06A23F518CB56E6F6CC7637B0F6F8904F8431BD2002EF1CB60BA6E08DE592302B70CCEFEDA4880378774CD27EA79E6B31E33022C3035FBA6B24D00B40D26644324C055E13BFB2B08017E6D1D6256E8FF25BE91CB52996D0F9768172130FF069DEB0C122704DC479DE65FB934946D0F9729C34761E3332A4BDC5E49CADE1BE074F04763BC9F5B43D9F6F0A7B54785551101BF0D3AEA983202BE462BAC7661AEB8D9031FAF0596656B0D77D26A1FA1638ABC36D7381A4CF146EE0D650B9CA8BC792EBB64780AADB10125290288739D09E6BB358A86B2033ECC5190F52EE0CE5A190675ED9878841F8155BE138D1B9B1DF0409D5111412CFCB1AFF55C303F3BE24E57822DCEF28F681ACA16189E8DB087B78F9603ED99BCD3CD4D2126BB3CA4819A08787B86719E2895E8C17DF54ADED9536754B9DAB5D135930DF01845F8B7DF470ABCC44BC185DCAE4A5B51EDFE289BC91CF840E5E0A1DC3C9E14B33811D2F74DDAE295D6A16568AFC980BF6D376CF65B51EB8990E839215CBFEB297076F0B39A04F8085F03F75B1C39F063FE024E0ED7D5A6DA8822B73ABFA98027E8844D6EAC23AAC945EF876DF2110E08775E320114BBDE1F836D6854E0A161B7617A8416B8A6EEB1115D8C4CDEB9D9F74375D770B3CCF4155D726B22934ABC624F3B12EF39312A37A0965A996930963AA146F268A4AB6A38246F78DC1C4BD349D3E65A4D7BA923C15579C2E523B781EE215597D00CFD5C1D22663EE59B1EF094BB8D73443E7B7898195A6296E1F2A927F4C2D3FAD95A2B5C39D9971DB34317ADB5D83C33FC33FD1E4E17B88BF90EC73AE516345841D3CAA63A36AC8B14D75B71B9D979C1AFFA920752A41D8E31483F07EFB0D3B8DCA3EEF2D4CEC516D90317BA2B1425547845418AEABADA58CF1857AB8712CEE22DF6AF772B7BAB0E0E030B0CA92327DAD6914ED2D3B135A2E76D66FBB947A2029E90F1118B979D90229C3BC99C0CBE719A7B1AF0090618A87F8D34D5037E1ADC979C16AD11599C28D998B22E67DF8CBE7149032668A9A9BEA897A9C9BCCB288FB856FBFA5E6A388957A8A39FA799D9A852A99FDED89C62400B33EF6DD36D0D3B17F5FD6555C91AF8FAD6F5C516FB857267EA86221739CAB7EA2EB1699906C4ED196D6C74D51B6B52D65125E6E43A13235ED9DF34D934E39DA314033C689815D1E6B4EAD29E8605F720959687ACC6883C98B3E52E36281CDAEBE1E6BA16D6A881BF661F547938E56F177B13AD4CCCB624A5013D6BA40783233ABC318087B8103C59C729B25521A83CCE5D696D7E67AE0DCE0B4EE757F20F7CAAE92156FE51CA250B6E0C89A18116E4E9F0CC8A50CED83B54A1E409B8D4147787FD9F4B3D564F08F8D510041EE46113C30E55B49AA3025D4269445E80FB7AD0C460792735B099B95279C88615996276284E8D526F8442C8BDF203FC49377944FFE0787EC70F1A7C6395725784F0AF9799EE4D2675A2D1C6B06BBD47F4C05D5D6291F15A074F6EB05FA4F55EA52B7DC1E3E16AB4F9EECCB6B22EA5B54F1450B48F16B893F32D745570172B4C322CA313BE4F1AE692B0C152E474B3FCC190B48B88EB779512E14987E880BBB9D822D7873C44B57B0DF2838C6BB63E74B57EA6863DE6625F32CBC3C6E69AC42104A06DB2732D6BEB28A72AB74FF27AAE1B328A8176D4EB2E74BBB38CD61505FAE8E355333CE0851C801346B15DAE3D5CE824779B6F4212778E9186E4809BD05F7DD7892E4F1EAE3BC425E6B9D7C969040F75CDE23A3BB365DACBD349CAF54A0E932D16B8D5EC6C8F5AA474FF6F335CB91314A283D14EF19C3BDCEFBD9DB22FC7D856679AB84AB56E61AA65990038DC9795D7F05BD67BC86F2DC88B9F5468B03106D6A8D87ACD34B75B59E399531AD8D5AA0E1EC1AC45C333EFE1438D33BA86ABFFA63FB8CF8B794BE155996DB6238C706AF0940E7695B12EAB01D9BA816F6C4F3D64B1688D3731B95F5BE5797778281892FC6AA9A56E31D4193EAF0007BBCF649727DDD3F52A1B3C7C5D924CECA639A45BB8C64549DFE561D32CC8F6E84CD66A6DA873F50D5757BA223814FBAA56DDE0E458BF684526C017B82EE403EFF133CF682A1538CB64BBA3D228B332793593ACE5219E5186779D9B223FDCD8EAEF5E9DF0BCBE9994B66492B5FCBA326C734E33C0657EA8E5E999FB0E626AE03D42D6E9CEE88A4972D42D5E0E7D9D17E0CF38089BF2B0CB9FAD3E08B1559F94B57A390327363B96853293E6A145AA704038D31231700FF06A64C5C151E8156B509C6BBEB33EE0173527AD0F798C4EF900EE08119725E5AA7561BC75C8ED33A95DCB84173ACA7E0DFAAD8DA56DDA86A45C513E801398236B1497341F95E663481769BE6A9D8F1E7E455964A17DB46A9BEBA18316F1FF991603C7C031700C1C03C7C031700C1C03C7C031700C1C03C7C031700C1C03C7C031700C1C03C7C031700C1C03C7C031700C1C03C7C0FF03FAEF005518B35F97FC5D160000000049454E44AE426082) as Photo,
M.Name as ����, case when E.Gender = 0 then 'Ů' else '��' end as �Ա�, O.Name as ְλ,
case when E.Status = 1 then '����' when E.Status = 2 then '�ݼ�' else '��ְ' end as ״̬, L.Name as ֱ���쵼, M.Code as ����,
D.Name as ����, E.IdCardNo as ����֤��, case when E.LoginUser = 1 then '��' else '��' end as ��¼, M.Alias as ��¼�ʺ�,
T.Number as �绰����, P.Number as �ƶ��绰, A.Number as �����ʼ�,
E.EntryDate as ��ְ����, E.DimissionDate as ��ְ����, E.OfficeAddress as �칫�ص�, E.HomeAddress as ��ͥסַ, E.Description as ��ע
from MasterData M
join MDG_Employee E on E.MID = M.ID
join MDR_ET R on R.EmployeeId = M.ID
join SYS_Organization O on O.ID = R.TitleId
left join MasterData D on D.ID = E.WorkType
left join MasterData L on L.ID = E.DirectLeader
left join MDS_Contact_Info T on T.MasterDataId = M.ID
  and T.IsMaster = 1
  and T.InfoTypeId = (select ID from MasterData where Alias = 'Tel')
left join MDS_Contact_Info P on P.MasterDataId = M.ID
  and P.IsMaster = 1
  and P.InfoTypeId = (select ID from MasterData where Alias = 'Mobile')
left join MDS_Contact_Info A on A.MasterDataId = M.ID
  and A.IsMaster = 1
  and A.InfoTypeId = (select ID from MasterData where Alias = 'Email')

GO