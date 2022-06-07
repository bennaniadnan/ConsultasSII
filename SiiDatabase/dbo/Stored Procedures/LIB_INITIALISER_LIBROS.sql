CREATE PROCEDURE [dbo].[LIB_INITIALISER_LIBROS]
AS
	DELETE [Libros]
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
			--,[TipoDetalleIVA]
			--,[DetalleImportesId]
			--,[TipoImpositivo]
			--,[BaseImponible]
			--,[CuotaIVA]
			--,[TipoRE]
			--,[CuotaRE]
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
SELECT DISTINCT --TOP(@top)
	RI.Id AS Id, 
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
	--CASE WHEN DI.IdTipoDetalleIVA LIKE 0 THEN 'DI' ELSE 
	--	(CASE WHEN DI.IdTipoDetalleIVA LIKE 2 THEN 'EB' ELSE
	--		(CASE WHEN DI.IdTipoDetalleIVA LIKE 3 THEN 'PS' ELSE
	--			(CASE WHEN DI.IdTipoDetalleIVA LIKE 1 THEN 'ISP' ELSE NULL END)
	--		END)
	--	END)
	--END AS TipoDetalleIVA,
	--DI.Id as DetalleImportesId,
	--DI.TipoImpositivo,
	--DI.BaseImponible,
	--CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END AS CuotaIVA,
	--DI.TipoRecargoEquivalencia AS TipoRE,
	--DI.CuotaRecargoEquivalencia AS CuotaRE
	RI.IdEstadoRegistro,
    RI.IdLibroRegistro,
    RI.IDContraparte,
    RI.NifContraparte,    
    RI.NumSerieFacturaEmisor,
    RI.FechaOperacion,
    RI.Baja,
    RI.IdEstadoLectura, 
	--COUNT(DI.Id) as CountDetalleIVA
	SUM(ISNULL(DI.BaseImponible,0)) as BaseImponible,
	SUM(ISNULL(CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END,0)) AS CuotaIVA,
	SUM(ISNULL(DI.TipoRecargoEquivalencia,0)) AS TipoRE,
	SUM(ISNULL(DI.CuotaRecargoEquivalencia,0)) AS CuotaRE
	--into #tmp
	FROM RegistroInformacion RI with (nolock)-- ON RO.IdRegistroInformacion = RI.Id
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
	--having COUNT(DI.Id) > 1
	order by RI.Id desc