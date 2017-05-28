﻿ALTER TABLE [dbo].[Customers] ADD [Age] [int] NOT NULL DEFAULT 20
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201703031937364_AddCustomerAge', N'_8.ScriptMigration.Migrations.Configuration',  0x1F8B0800000000000400ED5B4B6FE33610BE17E87F10746A8BAC95642FDBC0DE45EA6C0AA379354E16BD058C443B4425CA25A9C041D15FD6437F52FF42493D29929228F9B1E962918B4C7186F3F8381C8E26FFFEFDCFF8C33A0A9D6748288AF1C43D1A1DBA0EC47E1C20BC9CB8095BBC79E77E78FFED37E38F41B4763E15F3DE8A799C12D389FBC4D8EAC4F3A8FF0423404711F2494CE3051BF971E48120F68E0F0F7FF48E8E3CC859B89C97E38C6F13CC5004D31FFCE734C63E5CB10484977100439A8FF337F394AB7305224857C0871377EE13B46297684900E3B2B8CE69880017630EC385EB008C6396BE38B9A770CE488C97F3151F00E1DDCB0AF2790B1052980B7F524DB7D5E3F058E8E15584052B3FA12C8E7A323C7A9B1BC653C90799D72D0DC74DF7919B98BD08AD53F34DDC69BA0424AEA32E76320D899838711FDE8D14038F32978C0AEA03479B72500283E347FC1D38D324640981130C13464078E0DC248F21F27F812F77F1EF104F701286B2B45C5EFEAE36C0876E48BC8284BDDCC245AEC32C701DAF4EE7A984259944936937C3ECEDB1EB5CF1C5C163084B30489698B398C09F21865C3518DC00C620C182074CCDA9ADAEAC758E0865E2B1589243906F25D7B904EB0B8897EC69E2F247D739476B181423B918F718F19DC789184960D74A17604F0B9D2E6197FDDA197C8C000A772EE694C000B12920C155123D0A946F7BC12BF08C96294A94A5E72084F43C26D506BB85613A913EA155169A4662D24335E39CC4D16D1CE6D4E58B873B40969071E163D3DB799C105F916CEC553BBD75FF0B56C3F6BEA0FCBAEFDBD63AE354C56AE2F90E899DD9B5511A11B50D2415583123A9C099AD44FC6790F8CC2850FEEE21DD07D78B726A2599798606F6866926D4B7EE47E1CB8BD8CF0F529309E519D972339C0ED6ECD9384BDFA6CD5337DAB3A52D876CDB9CF8EBCE6D5B6B2F67E819A4A903523CEE78AD5F13902B9E87A3983BD22218691B1EF95548833E8A003FC46F087FCAEF0AEF5C67EE03C1D02227683F3CA5A0B1CDF8A286C08E3034EC54AD079B41C7ABCCE2EB6E6DCD7A732BED66D7B683B43C217671A068A775F7D96303D7534A631FA54C2455AAECA1AEFF471C38ADA94466EF2209E126E730442B0E3CBEF4C4FD41336813C3F2F8AC1856094D9DE9E16874A4EA2A69D5AE6C43E46812B22B8C54D29631A84B581BFE066B5898B787195AD0D9E82F0BA84AE2D683602FA3D86459DB314CB645A6316600F10024EF6D3108D7A63CEB9EC23C84D33C6AA88A08A673C894D49DBA4EB525358C6BD6A83349653230C8B4EF20CE6165A22F61DBB5BEEC13A32075872BEC24FBD77592AE2DD21CE3BD463DABBA6253A942693DCF964501338985E445F538AC2B67A17853FAA25BC0265CF50958924215285ACCD2119FBA4C3CC0366DE7A601219671AC6F2493155390DF06A2EEC0B581C58A13BD0C575551DCCBAAE245F5DC6B289F8F2FC16AC53323A99C9E8F38F3AC963E7D33EF5F678E321E9E4F0DE5E652DA72256E0FB084CA5BBE3497342D969E01061E81C8CDA641A44DAB05E78698552CA5C65FDD7345102B28C4738E4325336F0A43950DCFB95A114F5A530DA12174E8A4E9F70C10026248A0A7719844B829096FA3964ACE321369D89E575554965955A3F69CD2AAB1CC241DB0A7CF8BC632877CC89E875E1296D9E96F75CE634FF1B68A294F0395B2BF55945A61388B159BE0374D14FA63D74CB61BDC662553993E1B79355E288FCC4D1CD170865BF8A2917237EED0B77DDF2D5F2B72D5FC2ABFB0E75715B26466D5A83DA7BC9625B3C9875E0DD894BC63A3BD5FCBCD07048176FADDC0AF5ED8A99D3EB537FB77583D43D303B574A7698FC7D2449BB82B324D43194ABBB6E806B1724FC9C6E427619372F1BE72E559F540B97A8BC3B3437E8E8B62C78C8ACA6359EBB3D456CDC17B83A0E97ED7792868140361D17E0B1CE88782CB16E0D17EAD7C553869D67A6398B45D752D83B94235348A745E8807BAA4CE781B71A5F386FDAAC0D3A57F3784B44BBF3AA53CECCACBBF72C91FE717EEEE463AED069E4D11DFF8E26714A4B7EF17CA6034121346F33FC26988F8F15A4DB804182D2065D92727F7F8F0E85869C77B3DAD711EA54168285898FAE3F6FEDD0CE122F8B77D19EBF901576B45C3CF80F84F807C1781F5F732BB21ED661B31935ACA52D5376928DB4890A6A6B11E4CFBB55F7D19D092BB9D02FECCACBA9D1A7A9C1E1461B52F30331CC0F5C4FD33A53B7166BF3D48A407CE35E1A1E8C43974FEEAEB7DF9B0EF274045B9C9FAFA79D14F0A95DE5E96DEFD475F066EB716C00CFD3C1BF1537B7616610CFAC7C55ACB4EB059CBCEC0FE972F0327A62E932D1C09439B31EA0586DEFD12DA97CF018D1CDC5D90086B8290E7A694119E9D6A85168E3FECA3150855B9F52CDD0606C290254BF5CD195C412CFC2BEB65B34E47DDA3E4AB20B2CB003B6F4AD942FBC93E7DDF5CF7FE7CAE6F2F69ECC1F39BF6E16CAFE7668F48E82A477F3E3CD8D42BB68E0A731392FE39BCE1AB81F60F022D4D46D9859EA7028F317776765A3537B6987A901A5B904CACCD1D0E0DDD496DCD4926E64DFD2BEDAD4BDD9D4B46455A7B4076DCDDA47AB6DE53D0D5D4A4B59CFC2FFA974C9D4A9F45D57DB72335B71EED54FD1EBD457A3991C73EE9BF7779F4A56859B11095520CFD5AD42BE7CCF0222EC2B022513145C9C42F2103010F89A784A105F0197FED434AD37EEF4F204CD26AD0230C66F83A61AB84719561F418D6BE0E8B20DEB67EDA405597797C9DDEEDE83654E062225124B9C63F25280C4AB9CF0D97AE0616E274C8AF37C2974C5C73962F25A7AB185B32CACD571E6A77305A859C19BDC673F00C87C8764FE1055C02FFA5A80A3733E97644DDECE3330496044434E751D1F39F1CC341B47EFF1FBD146234C43E0000 , N'6.1.3-40302')
