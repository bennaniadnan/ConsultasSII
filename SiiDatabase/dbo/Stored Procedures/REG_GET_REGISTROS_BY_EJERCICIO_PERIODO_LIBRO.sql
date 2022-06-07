CREATE PROCEDURE [dbo].[REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO]
(
	@IdUsuario varchar(6) = null,
	@IdLibroRegistro varchar(2),
	@Ejercicio INT = null,
	@Periodo varchar(2) = null,
	@NifContraparte varchar(20) = null,
	@IdFactura varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60) = null,
	@FechaExpedicion date = null,
	@FechaRegContable date = null,
	@FechaOperacionDesde date = null,
	@FechaOperacionHasta date = null,
	@IsIDOtros bit = 0,
	@PageNumber int = 1,
	@Records int = 20
)
AS
BEGIN
	DECLARE @Offset int = (@PageNumber - 1) * @Records , @top int = @PageNumber * @Records, @count int = 0
	
	--CHECKPOINT; 
	--DBCC DROPCLEANBUFFERS; 

	SELECT @count = COUNT(RI.Id)
	 from RegistroInformacion RI with (nolock)
	 LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
	 LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
		WHERE RI.IdEstadoRegistro IN(1,2)
		AND RI.IdLibroRegistro = @IdLibroRegistro 
		AND ISNULL(RI.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(RI.Ejercicio,''))
		AND ISNULL(RI.Periodo, '') = ISNULL(@Periodo, ISNULL(RI.Periodo,''))
		AND 
		(
			(
				case when @IsIDOtros = 1 then ISNULL(RI.IDContraparte,'') 
					else ISNULL(RI.NifContraparte,'')end
			) = (
				case when @IsIDOtros = 1 then ISNULL(@NifContraparte, ISNULL(RI.IDContraparte,'')) 
					else ISNULL(@NifContraparte, ISNULL(RI.NifContraparte,''))end
			)
		)
		AND ISNULL(RI.Id,'') = ISNULL(@IdFactura, ISNULL(RI.Id,''))
		AND ISNULL(RI.NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(RI.NumSerieFacturaEmisor,''))
		AND ISNULL(RI.FechaExpedicionFacturaEmisor,'') = ISNULL(@FechaExpedicion, ISNULL(RI.FechaExpedicionFacturaEmisor, ''))
		AND ISNULL(RI.FechaRegContable,'') = ISNULL(@FechaRegContable, ISNULL(RI.FechaRegContable, ''))
		AND (
			ISNULL(RI.FechaOperacion,'') BETWEEN 
			ISNULL(@FechaOperacionDesde, ISNULL(RI.FechaOperacion, '')) AND 
			ISNULL(@FechaOperacionHasta, ISNULL(RI.FechaOperacion, ''))
			)
		AND (RI.Baja is null or RI.Baja!=1)
		AND RI.IdEstadoLectura <> 2

		print 'TotalRows =>'
		print @count


SELECT DISTINCT TOP(@top)
	RI.Id AS Id, 
	CASE WHEN RI.IdEstadoRegistro LIKE 1 THEN 'OK' ELSE 
		(CASE WHEN RI.IdEstadoRegistro LIKE 2 THEN 'AE' ELSE NULL END ) END AS EstadoRegistro,
	RI.NumSerieFacturaEmisor AS NumeroFactura,
	CONVERT(VARCHAR(10),RI.FechaExpedicionFacturaEmisor,103) AS FechaFactura,
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
	CASE WHEN DI.IdTipoDetalleIVA LIKE 0 THEN 'DI' ELSE 
		(CASE WHEN DI.IdTipoDetalleIVA LIKE 2 THEN 'EB' ELSE
			(CASE WHEN DI.IdTipoDetalleIVA LIKE 3 THEN 'PS' ELSE
				(CASE WHEN DI.IdTipoDetalleIVA LIKE 1 THEN 'ISP' ELSE NULL END)
			END)
		END)
	END AS TipoDetalleIVA,
	DI.Id as DetalleImportesId,
	DI.TipoImpositivo,
	DI.BaseImponible,
	CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END AS CuotaIVA,
	DI.TipoRecargoEquivalencia AS TipoRE,
	DI.CuotaRecargoEquivalencia AS CuotaRE
	into #tmp
	 from RegistroInformacion RI with (nolock)-- ON RO.IdRegistroInformacion = RI.Id
	LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
	LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
	WHERE RI.IdEstadoRegistro IN(1,2)
		AND RI.IdLibroRegistro = @IdLibroRegistro 
		AND ISNULL(RI.Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(RI.Ejercicio,''))
		AND ISNULL(RI.Periodo, '') = ISNULL(@Periodo, ISNULL(RI.Periodo,''))
		AND 
		(
			(
				case when @IsIDOtros = 1 then ISNULL(RI.IDContraparte,'') 
					else ISNULL(RI.NifContraparte,'') end
			) = (
				case when @IsIDOtros = 1 then ISNULL(@NifContraparte, ISNULL(RI.IDContraparte,'')) 
					else ISNULL(@NifContraparte, ISNULL(RI.NifContraparte,'')) end
			)
		)
		AND ISNULL(RI.Id,'') = ISNULL(@IdFactura, ISNULL(RI.Id,''))
		AND ISNULL(RI.NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(RI.NumSerieFacturaEmisor,''))
		AND (@FechaExpedicion IS NULL OR ISNULL(RI.FechaExpedicionFacturaEmisor,'') = ISNULL(@FechaExpedicion, ISNULL(RI.FechaExpedicionFacturaEmisor, '')))
		AND (@FechaRegContable IS NULL OR ISNULL(RI.FechaRegContable,'') = ISNULL(@FechaRegContable, ISNULL(RI.FechaRegContable, '')))
		AND (
			ISNULL(RI.FechaOperacion,'') BETWEEN 
			ISNULL(@FechaOperacionDesde, ISNULL(RI.FechaOperacion, '')) AND 
			ISNULL(@FechaOperacionHasta, ISNULL(RI.FechaOperacion, ''))
			)
		AND (RI.Baja is null or RI.Baja!=1)
		AND RI.IdEstadoLectura <> 2


	select *, @count as TotalCount--, count(*) over() as TotalCount 
		from #tmp ORDER BY #tmp.Id OFFSET @Offset ROWS FETCH NEXT @Records ROWS ONLY

	drop table #tmp	


END
