/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


DECLARE @Env varchar(4) = 'PROD';

IF NOT EXISTS(SELECT * FROM [AgencyCommunicationUrls])
BEGIN
	IF (@Env = 'DEV')
	BEGIN
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CL', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/llaa/SiiLLAAV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fe/SiiFactINMV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'AEAT', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fr/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATN', N'https://prewww1.aeat.es/wlpl/SSII-FACT/ws/fe/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATC', N'https://sede.bcan.es/tributos/middlewarecaut/services/sii/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATA', N'https://pruebas-sii.araba.eus/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATG', N'https://sii-prep.eitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATB', N'https://pruapps.bizkaia.eus/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')

		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'AEAT', N'https://www7.aeat.es/wlpl/ADSI-LICO/ws/IESA1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'AEAT', N'https://www7.aeat.es/wlpl/ADSI-LICO/ws/IEST1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'AEAT', N'https://www7.aeat.es/wlpl/ADSI-LICO/ws/IESH1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'AEAT', N'https://www7.aeat.es/wlpl/ADSI-LICO/ws/IESM1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'AEAT', N'https://www7.aeat.es/wlpl/ADSI-LICO/ws/IESX4V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATN', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATN', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATN', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATN', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATN', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATG', N'https://silicie-prep.eitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESA1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATG', N'https://silicie-prep.eitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESH1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATG', N'https://silicie-prep.eitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IEST1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATG', N'https://silicie-prep.eitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESM1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATG', N'https://silicie-prep.eitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESX4V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATC', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATC', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATC', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATC', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATC', N'https://siihacienda.navarra.es/SII_PRUEBAS.proxy/Silicie.ashx')

		
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATB', N'https://pruapps.bizkaia.eus/IGIE000M/IESA1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATB', N'https://pruapps.bizkaia.eus/IGIE000M/IEST1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATB', N'https://pruapps.bizkaia.eus/IGIE000M/IESH1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATB', N'https://pruapps.bizkaia.eus/IGIE000M/IESM1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATB', N'https://pruapps.bizkaia.eus/IGIE000M/IESX4V1Service')
	END
	ELSE
	BEGIN
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATC', N'https://sede.gobiernodecanarias.org/tributos/middleware/services/sii/SiiFactPAGV1SOAP')

		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CL', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/llaa/SiiLLAAV1SOAP')

		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FA', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FE', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'FR', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BE', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fe/SiiFactFEV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'BR', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fr/SiiFactFRV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATN', N'https://www1.agenciatributaria.gob.es/wlpl/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATA', N'https://sii.araba.eus/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATG', N'https://sii.egoitza.gipuzkoa.eus/JBS/HACI/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'CO', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fe/SiiFactCOBV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'PA', N'ATB', N'https://sii.bizkaia.eus/SSII-FACT/ws/fr/SiiFactPAGV1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/ADSI-LICO/ws/IESA1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/ADSI-LICO/ws/IEST1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/ADSI-LICO/ws/IESH1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/ADSI-LICO/ws/IESM1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'AEAT', N'https://www1.agenciatributaria.gob.es/wlpl/ADSI-LICO/ws/IESX4V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATN', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATN', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATN', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATN', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATN', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATG', N'https://silicie.egoitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESA1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATG', N'https://silicie.egoitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESH1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATG', N'https://silicie.egoitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IEST1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATG', N'https://silicie.egoitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESM1V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATG', N'https://silicie.egoitza.gipuzkoa.eus/JBS/HACI/HIESuministroLibrosContaWEB/ADSI-LICO/ws/IESX4V1SOAP')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATC', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATC', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATC', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATC', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATC', N'https://siihacienda.navarra.es/SII_PRODUCCION.proxy/Silicie.ashx')
		
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AA', N'ATB', N'https://silicie.bizkaia.eus/IGIE000M/IESA1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AT', N'ATB', N'https://silicie.bizkaia.eus/IGIE000M/IEST1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AH', N'ATB', N'https://silicie.bizkaia.eus/IGIE000M/IESH1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AM', N'ATB', N'https://silicie.bizkaia.eus/IGIE000M/IESM1V1Service')
		INSERT [dbo].[AgencyCommunicationUrls] ([DocumentType], [Agency], [Url]) VALUES (N'AX', N'ATB', N'https://silicie.bizkaia.eus/IGIE000M/IESX4V1Service')
	END
END



IF NOT EXISTS(SELECT * FROM [dbo].[Periodo])
BEGIN
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'01', N'Enero', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'02', N'Febrero', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'03', N'Marzo', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'04', N'Abril', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'05', N'Mayo', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'06', N'Junio', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'07', N'Julio', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'08', N'Agosto', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'09', N'Septiembre', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'0A', N'Anual', N'A')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'10', N'Octubre', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'11', N'Noviembre', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'12', N'Diciembre', N'M')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'T1', N'Primer trimestre', N'T')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'T2', N'Segundo trimestre', N'T')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'T3', N'Tercer trimestre', N'T')
INSERT [dbo].[Periodo] ([Id], [Texte], [TipoPresentacion]) VALUES (N'T4', N'Cuarto trimestre', N'T')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[EstadoCobroPago])
BEGIN
INSERT [dbo].[EstadoCobroPago] ([Id], [Name], [Descripcion]) VALUES (0, N'Pendiente', N'Pendiente de procesar')
INSERT [dbo].[EstadoCobroPago] ([Id], [Name], [Descripcion]) VALUES (1, N'PendienteRespuesta', N'Procesado y pendiente de recibir respuesta')
INSERT [dbo].[EstadoCobroPago] ([Id], [Name], [Descripcion]) VALUES (2, N'Aceptado', N'Procesado y Aceptado en la agencia tributaria')
INSERT [dbo].[EstadoCobroPago] ([Id], [Name], [Descripcion]) VALUES (3, N'Rechazado', N'Procesado y Rechazado en la agencia tributaria')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[ResultadoOperacion])
BEGIN
INSERT [dbo].[ResultadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (0, N'Pendiente', 1)
INSERT [dbo].[ResultadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (1, N'Aceptado', 2)
INSERT [dbo].[ResultadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (2, N'Aceptado con errores', 3)
INSERT [dbo].[ResultadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (3, N'Rechazado', 4)
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoOperacion])
BEGIN
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'A0', N'Alta', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'A1', N'Modificación (Corrección de errores registrales)', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'A4', N'Modificación Factura Régimen de Viajeros	', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'A5', N'Alta de las devoluciones del IVA de viajeros', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'A6', N'Modificacion de las devoluciones del IVA de viajeros', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'BJ', N'Baja', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'C1', N'Cobros', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'P1', N'Pagos', N'--', NULL)
INSERT [dbo].[TipoOperacion] ([Id], [Denominacion], [EstructuraXML], [ClaseOperacion]) VALUES (N'CX', N'Consulta', N'--', NULL)
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoUsuario])
BEGIN
INSERT [dbo].[TipoUsuario] ([id], [Descripcion]) VALUES (1, N'Admin')
INSERT [dbo].[TipoUsuario] ([id], [Descripcion]) VALUES (2, N'User')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[EstadoOperacion])
BEGIN
INSERT [dbo].[EstadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (0, N'Pendiente', 1)
INSERT [dbo].[EstadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (1, N'Enviada', 2)
INSERT [dbo].[EstadoOperacion] ([Id], [Descripcion], [Orden]) VALUES (2, N'Procesada', 3)
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[LibroRegistro])
BEGIN
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'BI', N'Bienes Inversion', 3)
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'CO', N'Cobros', 6)
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'FE', N'Facturas Emitidas', 1)
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'FR', N'Facturas Recibidas', 5)
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'MS', N'Operaciones en metálico y seguros', 2)
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'OI', N'Operacion Intracomunitaria', 4)
INSERT [dbo].[LibroRegistro] ([Id], [Descripcion], [Orden]) VALUES (N'PA', N'Pas', 7)
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoDocumento])
BEGIN
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'00', NULL)
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'02', N'NIF-IVA')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'03', N'PASAPORTE')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'04', N'DOCUMENTO OFICIAL DE IDENTIFICACIÓN EXPEDIDO POR EL PAIS O TERRITORIO DE RESIDENCIA')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'05', N'CERTIFICADO DE RESIDENCIA')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'06', N'OTRO DOCUMENTO PROBATORIO')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion]) VALUES (N'07', N'NO CENSADO')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoFactura])
BEGIN
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'24', N'CUOTA DEDUCIBLES POR CESE RE COMERCIANTE MINORISTA (MODELO 424)', 12, N'ATC')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'25', N'DOCUMENTO DE INGRESO ARTICULO 25 LEY 19/1994', 13, N'ATC')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'F1', N'FACTURA', 1, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'F2', N'FACTURA SIMPLIFICADA', 2, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'F3', N'FACTURA EMITIDA EN SUSTITUCIÓN DE FACTURAS SIMPLIFICADAS FACTURADAS Y DECLARADAS CON ANTERIORIDAD ', 8, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'F4', N'ASIENTO RESUMEN DE FACTURAS', 9, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'F5', N'IMPORTACIONES (DUA)', 10, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'F6', N'OTROS JUSTIFICANTES CONTABLES Y DOCUMENTOS JUSTIFICATIVOS DEL DERECHO A LA DEDUCCIÓN', 11, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'LC', N'ADUANAS - LIQUIDACIÓN COMPLEMENTARIA', NULL, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'R1', N'FACTURA RECTIFICATIVA: Error fundado en derecho y Art. 80 Uno y Dos LIVA', 3, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'R2', N'FACTURA RECTIFICATIVA: Art 80 Tres LIVA - concurso', 4, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'R3', N'FACTURA RECTIFICATIVA: Art 80 Cuatro LIVA - deuda incobrable', 5, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'R4', N'FACTURA RECTIFICATIVA: Resto ', 6, N'AEAT')
INSERT [dbo].[TipoFactura] ([id], [Descripcion], [Orden], [IdAgencia]) VALUES (N'R5', N'FACTURA RECTIFICATIVA: Factura rectificativa simplificada', 7, N'AEAT')
END
UPDATE [dbo].[TipoFactura] SET Descripcion = 'OTROS JUSTIFICANTES CONTABLES Y DOCUMENTOS JUSTIFICATIVOS DEL DERECHO A LA DEDUCCIÓN' WHERE id = 'F6'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[EstadoCuadre])
BEGIN
INSERT [dbo].[EstadoCuadre] ([Id], [Name], [DisplayName], [Descripcion]) VALUES (1, N'NoContrastable', N'No contrastable', N'Estas facturas no permiten contrastarse.')
INSERT [dbo].[EstadoCuadre] ([Id], [Name], [DisplayName], [Descripcion]) VALUES (2, N'EnProcesoDeContraste', N'En proceso de contraste', N'Estado "temporal" entre el alta/modificación de la factura y su')
INSERT [dbo].[EstadoCuadre] ([Id], [Name], [DisplayName], [Descripcion]) VALUES (3, N'NoContrastada', N'No contrastada', N'El emisor o el receptor no han registrado la factura (no hay coincidencia')
INSERT [dbo].[EstadoCuadre] ([Id], [Name], [DisplayName], [Descripcion]) VALUES (4, N'ParcialmenteContrastada', N'Parcialmente contrastada', N'El emisor y el receptor han registrado la factura (coincidencia')
INSERT [dbo].[EstadoCuadre] ([Id], [Name], [DisplayName], [Descripcion]) VALUES (5, N'Contrastada', N'Contrastada', N'El emisor y el receptor han registrado la factura (coincidencia en el NIF del')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[Estadolectura])
BEGIN
INSERT [dbo].[Estadolectura] ([id], [Estado]) VALUES (0, N'Alta')
INSERT [dbo].[Estadolectura] ([id], [Estado]) VALUES (1, N'Modificada')
INSERT [dbo].[Estadolectura] ([id], [Estado]) VALUES (2, N'Baja')
INSERT [dbo].[Estadolectura] ([id], [Estado]) VALUES (3, N'A procesar')
INSERT [dbo].[Estadolectura] ([id], [Estado]) VALUES (4, N'Alta Pendiente')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[Medio])
BEGIN
INSERT [dbo].[Medio] ([Id], [Descripcion]) VALUES (N'01', N'Transferencia')
INSERT [dbo].[Medio] ([Id], [Descripcion]) VALUES (N'02', N'Cheque')
INSERT [dbo].[Medio] ([Id], [Descripcion]) VALUES (N'03', N'No se cobra / paga (fecha límite de deven / deven forzoso en  concurso de acreedores). ')
INSERT [dbo].[Medio] ([Id], [Descripcion]) VALUES (N'04', N'Otros')
INSERT [dbo].[Medio] ([Id], [Descripcion]) VALUES (N'05', N'Domicilliación bancaria')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoDetalleIVA])
BEGIN
INSERT [dbo].[TipoDetalleIVA] ([Id], [Descripcion]) VALUES (0, N'Desglose Impuesto')
INSERT [dbo].[TipoDetalleIVA] ([Id], [Descripcion]) VALUES (1, N'Inversion Sujeto Pasivo')
INSERT [dbo].[TipoDetalleIVA] ([Id], [Descripcion]) VALUES (2, N'Bienes Entrega')
INSERT [dbo].[TipoDetalleIVA] ([Id], [Descripcion]) VALUES (3, N'Prestacion Servicios')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoBienOperacion])
BEGIN
INSERT [dbo].[TipoBienOperacion] ([Id], [Descripcion]) VALUES (N'01', N'Adquisición, entrega o ejecución de obras que tengan por objeto de bienes inmuebles')
INSERT [dbo].[TipoBienOperacion] ([Id], [Descripcion]) VALUES (N'02', N'Adquisición, entrega o ejecución de obras que tengan por objeto de bienes muebles')
INSERT [dbo].[TipoBienOperacion] ([Id], [Descripcion]) VALUES (N'03', N'Adquisición o cesión de elementos del inmovilizado intangible consistente en el derecho de uso de propiedad industrial o intelectual')
INSERT [dbo].[TipoBienOperacion] ([Id], [Descripcion]) VALUES (N'04', N'Adquisición o cesión del inmovilizado intangible consistente en el derecho de uso de conocimientos no patentados')
INSERT [dbo].[TipoBienOperacion] ([Id], [Descripcion]) VALUES (N'05', N'Adquisición o cesión del inmovilizado intangible consistente en concesiones administrativas')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoDocumentoArt25])
BEGIN
INSERT [dbo].[TipoDocumentoArt25] ([Id], [Descripcion]) VALUES (N'01', N'Notarial')
INSERT [dbo].[TipoDocumentoArt25] ([Id], [Descripcion]) VALUES (N'02', N'Privado')
INSERT [dbo].[TipoDocumentoArt25] ([Id], [Descripcion]) VALUES (N'03', N'Otros')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[EstadoRegistro])
BEGIN
INSERT [dbo].[EstadoRegistro] ([id], [Descripcion], [Orden]) VALUES (0, N'Pendiente', 1)
INSERT [dbo].[EstadoRegistro] ([id], [Descripcion], [Orden]) VALUES (1, N'Aceptado', 2)
INSERT [dbo].[EstadoRegistro] ([id], [Descripcion], [Orden]) VALUES (2, N'Aceptado Con Errores', 3)
INSERT [dbo].[EstadoRegistro] ([id], [Descripcion], [Orden]) VALUES (3, N'Rechazado', 4)
INSERT [dbo].[EstadoRegistro] ([id], [Descripcion], [Orden]) VALUES (4, N'Baja', 5)
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[ClaveRegimen])
BEGIN
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'01', N'FR', N'ATC', N'Operación de régimen general.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'02', N'FR', N'ATC', N'Operaciones por las que los empresarios satisfacen compensaciones en las adquisiciones a personas acogidas al Régimen especial de la agricultura, ganadería y pesca.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'03', N'FR', N'ATC', N'Operaciones a las que se aplique los regímenes especiales de bienes usados y de objetos de arte, antigüedades y objetos de colección.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'04', N'FR', N'ATC', N'Régimen especial del oro de inversión.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'05', N'FR', N'ATC', N'Régimen especial de las agencias de viajes.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'06', N'FR', N'ATC', N'Régimen especial grupo de entidades en IGIC (Nivel Avanzado)')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'07', N'FR', N'ATC', N'Régimen especial del criterio de caja.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'08', N'FR', N'ATC', N'Operaciones sujetas al IPSI  / IVA (Impuesto sobre la Producción, los Servicios y la Importación  / Impuesto sobre el Valor Añadido).')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'09', N'FR', N'ATC', N'Adquisiciones intracomunitarias de bienes y prestaciones de servicios.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'12', N'FR', N'ATC', N'Operaciones de arrendamiento de local de necio.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'13', N'FR', N'ATC', N'Factura correspondiente a una importación (informada sin asociar a un DUA).')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'14', N'FR', N'ATC', N'Facturas anteriores a la inclusión en el SII')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'15', N'FR', N'ATC', N'Régimen especial de comerciante minorista')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'16', N'FR', N'ATC', N'Régimen especial del pequeño empresario o profesional')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'17', N'FR', N'ATC', N'Operaciones interiores exentas por aplicación artículo 25 Ley 19/1994')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'01', N'FE', N'ATC', N'Operación de régimen general.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'02', N'FE', N'ATC', N'Exportación.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'03', N'FE', N'ATC', N'Operaciones a las que se aplique los regímenes especiales de bienes usados y de objetos de arte, antigüedades y objetos de colección.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'04', N'FE', N'ATC', N'Régimen especial del oro de inversión.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'05', N'FE', N'ATC', N'Régimen especial de las agencias de viajes.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'06', N'FE', N'ATC', N'Régimen especial grupo de entidades en IGIC (Nivel Avanzado)')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'07', N'FE', N'ATC', N'Régimen especial del criterio de caja.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'08', N'FE', N'ATC', N'Operaciones sujetas al IPSI  / IVA (Impuesto sobre la Producción, los Servicios y la Importación  / Impuesto sobre el Valor Añadido).')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'09', N'FE', N'ATC', N'Facturación de las prestaciones de servicios de agencias de viaje que actúan como mediadoras en nombre y por cuenta ajena (D.A.4ª RD1619/2012)')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'10', N'FE', N'ATC', N'Cobros por cuenta de terceros de honorarios profesionales o de derechos derivados de la propiedad industrial, de autor u otros por cuenta de sus socios, asociados o colegiados efectuados por sociedades, asociaciones, colegios profesionales u otras entidades que realicen estas funciones de cobro.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'11', N'FE', N'ATC', N'Operaciones de arrendamiento de local de necio')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'14', N'FE', N'ATC', N'Factura con IGIC pendiente de deven en certificaciones de obra cuyo destinatario sea una Administración Pública.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'15', N'FE', N'ATC', N'Factura con IGIC pendiente de deven en operaciones de tracto sucesivo.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'16', N'FE', N'ATC', N'Facturas anteriores a la inclusión en el SII')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'17', N'FE', N'ATC', N'Régimen especial de comerciante minorista')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'18', N'FE', N'ATC', N'Régimen especial del pequeño empresario o profesional')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'19', N'FE', N'ATC', N'Operaciones interiores exentas por aplicación artículo 25 Ley 19/1994')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'01', N'FR', N'AEAT', N'Operación de régimen general.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'02', N'FR', N'AEAT', N'Operaciones por las que los empresarios satisfacen compensaciones en las adquisiciones a personas acogidas al Régimen especial de la agricultura, ganadería y pesca.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'03', N'FR', N'AEAT', N'Operaciones a las que se aplique los regímenes especiales de bienes usados y de objetos de arte, antigüedades y objetos de colección.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'04', N'FR', N'AEAT', N'Régimen especial del oro de inversión.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'05', N'FR', N'AEAT', N'Régimen especial de las agencias de viajes.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'06', N'FR', N'AEAT', N'Régimen especial grupo de entidades en IVA (Nivel Avanzado)')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'07', N'FR', N'AEAT', N'Régimen especial del criterio de caja.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'08', N'FR', N'AEAT', N'Operaciones sujetas al IPSI  / IVA (Impuesto sobre la Producción, los Servicios y la Importación  / Impuesto sobre el Valor Añadido).')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'09', N'FR', N'AEAT', N'Adquisiciones intracomunitarias de bienes y prestaciones de servicios.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'12', N'FR', N'AEAT', N'Operaciones de arrendamiento de local de necio.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'13', N'FR', N'AEAT', N'Factura correspondiente a una importación (informada sin asociar a un DUA).')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'14', N'FR', N'AEAT', N'Facturas anteriores a la inclusión en el SII')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'01', N'FE', N'AEAT', N'Operación de régimen general.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'02', N'FE', N'AEAT', N'Exportación.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'03', N'FE', N'AEAT', N'Operaciones a las que se aplique los regímenes especiales de bienes usados y de objetos de arte, antigüedades y objetos de colección.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'04', N'FE', N'AEAT', N'Régimen especial del oro de inversión.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'05', N'FE', N'AEAT', N'Régimen especial de las agencias de viajes.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'06', N'FE', N'AEAT', N'Régimen especial grupo de entidades en IVA (Nivel Avanzado)')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'07', N'FE', N'AEAT', N'Régimen especial del criterio de caja.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'08', N'FE', N'AEAT', N'Operaciones sujetas al IPSI  / IVA (Impuesto sobre la Producción, los Servicios y la Importación  / Impuesto sobre el Valor Añadido).')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'09', N'FE', N'AEAT', N'Facturación de las prestaciones de servicios de agencias de viaje que actúan como mediadoras en nombre y por cuenta ajena (D.A.4ª RD1619/2012)')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'10', N'FE', N'AEAT', N'Cobros por cuenta de terceros de honorarios profesionales o de derechos derivados de la propiedad industrial, de autor u otros por cuenta de sus socios, asociados o colegiados efectuados por sociedades, asociaciones, colegios profesionales u otras entidades que realicen estas funciones de cobro.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'11', N'FE', N'AEAT', N'Operaciones de arrendamiento de local de necio')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'12', N'FE', N'AEAT', N'Operaciones de arrendamiento de local de necio no sujetos a retención.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'13', N'FE', N'AEAT', N'Operaciones de arrendamiento de local de necio sujetas y no sujetas a retención.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'14', N'FE', N'AEAT', N'Factura con IVA pendiente de deven en certificaciones de obra cuyo destinatario sea una Administración Pública.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'15', N'FE', N'AEAT', N'Factura con IVA pendiente de deven en operaciones de tracto sucesivo.')
INSERT [dbo].[ClaveRegimen] ([Id], [IdLibroRegistro], [IdAgencia], [Descripcion]) VALUES (N'16', N'FE', N'AEAT', N'Primer semestre 2017 y otras facturas anteriores a la inclusión en el SII')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[CausaExencion])
BEGIN
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E1', N'AEAT', N'EXENTA Art. 20')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E1', N'ATC', N'EXENTA Art. 50 Ley 4/2012')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E2', N'AEAT', N'EXENTA Art. 21')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E2', N'ATC', N'EXENTA Art. 11 Ley 20/1991')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E3', N'AEAT', N'EXENTA Art. 22')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E3', N'ATC', N'EXENTA Art. 12 Ley 20/1991')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E4', N'AEAT', N'EXENTA Art. 23 y 24')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E4', N'ATC', N'EXENTA Art. 13 Ley 20/1991')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E5', N'AEAT', N'EXENTA Art. 25')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E5', N'ATC', N'EXENTA Art. 25 Ley 19/1994')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E6', N'AEAT', N'EXENTA Otros')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E6', N'ATC', N'EXENTA Art. 47 Ley 19/1994')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E7', N'ATC', N'EXENTA Art. 110 Ley 4/2012')
INSERT [dbo].[CausaExencion] ([CausaExencion], [IdAgencia], [Descripcion]) VALUES (N'E8', N'ATC', N'EXENTA Otros')
END
GO
IF NOT EXISTS(SELECT * FROM [dbo].[TipoLibro])
BEGIN
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'01', N'Factura Emitida')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'02', N'Factura Recibida')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'03', N'Baja Factura Emitida')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'04', N'Baja Factura Recibida')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'05', N'Cobro Emitada')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'06', N'Pago Recibida')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'07', N'Cobro Metalico')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'08', N'Baja Cobro Metalico')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'09', N'Operacion Intracomunitaria')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'10', N'Baja Operacion Intracomunitaria')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'11', N'Bienes Inversion')
INSERT [dbo].[TipoLibro] ([Id], [Descripcion]) VALUES (N'12', N'Baja Bienes Inversion')
END
