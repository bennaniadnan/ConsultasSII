CREATE TRIGGER [TRIGGER_LIBRO_REGISTRO_UPDATED]
	ON [dbo].[RegistroInformacion]
	AFTER DELETE, INSERT, UPDATE
	AS
	BEGIN
	IF OBJECT_ID(N'dbo.Libros', N'U') IS NOT NULL
		
	print '[TRIGGER_LIBRO_REGISTRO_UPDATED]'
	IF EXISTS(SELECT 1 FROM INSERTED) AND NOT EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		print 'insert'
		INSERT INTO [Libros]
			([Id]
			,[EstadoRegistro]
			,[NumeroFactura]
			,[FechaFactura]
			,[FechaRegContable]
			,[IdFiscal]
			,[IsNifContraparte]
			,[NombreContraparte]
			,[CodigoPaisContraparte]
			,[IDTypeContraparte]
			,[TipoFactura]
			,[ClaveRegimenEspecial]
			,[ImporteTotal]
			,[TipoNoSujeto]
			,[BaseNoSujeta]
			,[TipoDesglose]
			,[BaseExenta]
			,[CausaExencion]
			,[TipoDeSujecion]
			,[CuotaDeducible]
			,[Ejercicio]
			,[Periodo]
			,[IdEstadoCuadre]
			,[RefExterna]
			,[IdEstadoRegistro]
			,[IdLibroRegistro]
			,[IDContraparte]
			,[NifContraparte]
			,[NumSerieFacturaEmisor]
			,[FechaOperacion]
			,[Baja]
			,[IdEstadoLectura]
			,[BaseImponible]
			,[CuotaIVA]
			,[TipoRE]
			,[CuotaRE]
			)
		SELECT
			RI.Id,
			CASE WHEN RI.IdEstadoRegistro LIKE 1 THEN 'OK' ELSE 
				(CASE WHEN RI.IdEstadoRegistro LIKE 2 THEN 'AE' ELSE NULL END ) END AS EstadoRegistro,
			RI.NumSerieFacturaEmisor AS NumeroFactura,
			CONVERT(VARCHAR(10),RI.FechaExpedicionFacturaEmisor,103) AS FechaFactura,
			CONVERT(VARCHAR(10),RI.FechaRegContable,103) AS FechaRegContable,
			isnull(nullif(RI.NifContraparte,''),RI.IDContraparte) AS IdFiscal,
			CASE WHEN (RI.NifContraparte is not null AND RI.NifContraparte != '') 
				AND (RI.IDContraparte = '' OR RI.IDContraparte is null) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END AS IsNifContraparte,
			RI.NombreContraparte,
			RI.CodigoPaisContraparte,
			RI.IDTypeContraparte,
			RI.TipoFactura,
			RI.ClaveRegimenEspecialOTrascendencia AS ClaveRegimenEspecial,
			RI.ImporteTotal,
			CASE WHEN RI.ImporteTAIReglasLocalizacion > 0  AND RI.ImporteTAIReglasLocalizacion IS NOT NULL THEN 'RL' ELSE 
				(CASE WHEN RI.ImportePorArticulos7_14_Otros > 0 AND RI.ImportePorArticulos7_14_Otros IS NOT NULL THEN 'A7' ELSE NULL END) END AS TipoNoSujeto,
			isnull(nullif(RI.ImporteTAIReglasLocalizacion,0.00),RI.ImportePorArticulos7_14_Otros) AS BaseNoSujeta,
			CASE WHEN RI.TipoDesglose LIKE 0 THEN 'DI' ELSE (CASE WHEN RI.TipoDesglose LIKE 1 THEN 
				(CASE WHEN RI.DesgloseTipoOperacion LIKE 0 THEN 'EB' ELSE 'PS' END) ELSE NULL END) END AS TipoDesglose,
			RI.BaseImponible AS BaseExenta,
			RI.CausaExencion,
			CASE WHEN RI.TipoNoExenta LIKE 'S2' THEN 'ISP' ELSE '' END AS TipoDeSujecion,
			RI.CuotaDeducible,
			RI.Ejercicio,
			RI.Periodo,
			RI.IdEstadoCuadre,
			DC.RefExterna,
			RI.IdEstadoRegistro,
			RI.IdLibroRegistro,
			RI.IDContraparte,
			RI.NifContraparte,
			RI.NumSerieFacturaEmisor,
			RI.FechaOperacion,
			RI.Baja,
			RI.IdEstadoLectura, 
			SUM(ISNULL(DI.BaseImponible,0)) as BaseImponible,
			SUM(ISNULL(CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END,0)) AS CuotaIVA,
			SUM(ISNULL(DI.TipoRecargoEquivalencia,0)) AS TipoRE,
			SUM(ISNULL(DI.CuotaRecargoEquivalencia,0)) AS CuotaRE
		FROM INSERTED RI with (nolock)
		LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
		LEFT JOIN DatosComplementarios DC with (nolock) ON RI.Id = DC.IdRegistroInformacion
		group by 
			RI.Id, 
			RI.IdEstadoRegistro,-- EstadoRegistro,
			RI.NumSerieFacturaEmisor,
			RI.FechaExpedicionFacturaEmisor, --AS FechaFactura,
			RI.FechaRegContable,
			RI.NifContraparte,RI.IDContraparte, -- IdFiscal,
			RI.NifContraparte,
			RI.IDContraparte, --IsNifContraparte,
			RI.NombreContraparte,
			RI.CodigoPaisContraparte,
			RI.IDTypeContraparte,
			RI.TipoFactura,
			RI.ClaveRegimenEspecialOTrascendencia,
			RI.ImporteTotal,
			RI.ImporteTAIReglasLocalizacion,
			RI.ImportePorArticulos7_14_Otros, -- TipoNoSujeto,
			-- BaseNoSujeta,
			RI.TipoDesglose,
			RI.DesgloseTipoOperacion ,-- TipoDesglose,
			RI.BaseImponible,
			RI.CausaExencion,
			RI.TipoNoExenta,-- TipoDeSujecion,
			RI.CuotaDeducible,
			RI.Ejercicio,
			RI.Periodo,
			RI.IdEstadoCuadre,
			DC.RefExterna,
			RI.IdEstadoRegistro,
			RI.IdLibroRegistro,
			RI.IDContraparte,
			RI.NifContraparte,
			RI.NumSerieFacturaEmisor,
			RI.FechaOperacion,
			RI.Baja,
			RI.IdEstadoLectura
	END 
	IF EXISTS(SELECT 1 FROM DELETED) AND NOT EXISTS(SELECT 1 FROM INSERTED)
	BEGIN
		print 'delete'
		DELETE Libros WHERE Id in (SELECT Id FROM DELETED)

	END
	ELSE
	IF EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		print 'update'
		DELETE Libros WHERE Id in (SELECT Id FROM DELETED)
		INSERT INTO [Libros]
			([Id]
			,[EstadoRegistro]
			,[NumeroFactura]
			,[FechaFactura]
			,[FechaRegContable]
			,[IdFiscal]
			,[IsNifContraparte]
			,[NombreContraparte]
			,[CodigoPaisContraparte]
			,[IDTypeContraparte]
			,[TipoFactura]
			,[ClaveRegimenEspecial]
			,[ImporteTotal]
			,[TipoNoSujeto]
			,[BaseNoSujeta]
			,[TipoDesglose]
			,[BaseExenta]
			,[CausaExencion]
			,[TipoDeSujecion]
			,[CuotaDeducible]
			,[Ejercicio]
			,[Periodo]
			,[IdEstadoCuadre]
			,[RefExterna]
			,[IdEstadoRegistro]
			,[IdLibroRegistro]
			,[IDContraparte]
			,[NifContraparte]
			,[NumSerieFacturaEmisor]
			,[FechaOperacion]
			,[Baja]
			,[IdEstadoLectura]
			,[BaseImponible]
			,[CuotaIVA]
			,[TipoRE]
			,[CuotaRE]
			)
		SELECT
			RI.Id,
			CASE WHEN RI.IdEstadoRegistro LIKE 1 THEN 'OK' ELSE 
				(CASE WHEN RI.IdEstadoRegistro LIKE 2 THEN 'AE' ELSE NULL END ) END AS EstadoRegistro,
			RI.NumSerieFacturaEmisor AS NumeroFactura,
			CONVERT(VARCHAR(10),RI.FechaExpedicionFacturaEmisor,103) AS FechaFactura,
			CONVERT(VARCHAR(10),RI.FechaRegContable,103) AS FechaRegContable,
			isnull(nullif(RI.NifContraparte,''),RI.IDContraparte) AS IdFiscal,
			CASE WHEN (RI.NifContraparte is not null AND RI.NifContraparte != '') 
				AND (RI.IDContraparte = '' OR RI.IDContraparte is null) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END AS IsNifContraparte,
			RI.NombreContraparte,
			RI.CodigoPaisContraparte,
			RI.IDTypeContraparte,
			RI.TipoFactura,
			RI.ClaveRegimenEspecialOTrascendencia AS ClaveRegimenEspecial,
			RI.ImporteTotal,
			CASE WHEN RI.ImporteTAIReglasLocalizacion > 0  AND RI.ImporteTAIReglasLocalizacion IS NOT NULL THEN 'RL' ELSE 
				(CASE WHEN RI.ImportePorArticulos7_14_Otros > 0 AND RI.ImportePorArticulos7_14_Otros IS NOT NULL THEN 'A7' ELSE NULL END) END AS TipoNoSujeto,
			isnull(nullif(RI.ImporteTAIReglasLocalizacion,0.00),RI.ImportePorArticulos7_14_Otros) AS BaseNoSujeta,
			CASE WHEN RI.TipoDesglose LIKE 0 THEN 'DI' ELSE (CASE WHEN RI.TipoDesglose LIKE 1 THEN 
				(CASE WHEN RI.DesgloseTipoOperacion LIKE 0 THEN 'EB' ELSE 'PS' END) ELSE NULL END) END AS TipoDesglose,
			RI.BaseImponible AS BaseExenta,
			RI.CausaExencion,
			CASE WHEN RI.TipoNoExenta LIKE 'S2' THEN 'ISP' ELSE '' END AS TipoDeSujecion,
			RI.CuotaDeducible,
			RI.Ejercicio,
			RI.Periodo,
			RI.IdEstadoCuadre,
			DC.RefExterna,
			RI.IdEstadoRegistro,
			RI.IdLibroRegistro,
			RI.IDContraparte,
			RI.NifContraparte,    
			RI.NumSerieFacturaEmisor,
			RI.FechaOperacion,
			RI.Baja,
			RI.IdEstadoLectura,
			SUM(ISNULL(DI.BaseImponible,0)) as BaseImponible,
			SUM(ISNULL(CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END,0)) AS CuotaIVA,
			SUM(ISNULL(DI.TipoRecargoEquivalencia,0)) AS TipoRE,
			SUM(ISNULL(DI.CuotaRecargoEquivalencia,0)) AS CuotaRE
		FROM INSERTED RI with (nolock)
		LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
		LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
		group by 
			RI.Id, 
			RI.IdEstadoRegistro,-- EstadoRegistro,
			RI.NumSerieFacturaEmisor,
			RI.FechaExpedicionFacturaEmisor, --AS FechaFactura,
			RI.FechaRegContable,
			RI.NifContraparte,RI.IDContraparte, -- IdFiscal,
			RI.NifContraparte, 
			RI.IDContraparte, --IsNifContraparte,
			RI.NombreContraparte,
			RI.CodigoPaisContraparte,
			RI.IDTypeContraparte,
			RI.TipoFactura,
			RI.ClaveRegimenEspecialOTrascendencia,
			RI.ImporteTotal,
			RI.ImporteTAIReglasLocalizacion,
			RI.ImportePorArticulos7_14_Otros, -- TipoNoSujeto,
			-- BaseNoSujeta,
			RI.TipoDesglose,
			RI.DesgloseTipoOperacion ,-- TipoDesglose,
			RI.BaseImponible,
			RI.CausaExencion,
			RI.TipoNoExenta,-- TipoDeSujecion,
			RI.CuotaDeducible,
			RI.Ejercicio,
			RI.Periodo,
			RI.IdEstadoCuadre,
			DC.RefExterna,
			RI.IdEstadoRegistro,
			RI.IdLibroRegistro,
			RI.IDContraparte,
			RI.NifContraparte,
			RI.NumSerieFacturaEmisor,
			RI.FechaOperacion,
			RI.Baja,
			RI.IdEstadoLectura
	END
END	
