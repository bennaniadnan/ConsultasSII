CREATE PROCEDURE [dbo].[REG_GET_REGISTROS_ANULADOS]
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
	@Start int = 0,
	@Records int = 20,
	@IdEstadoCuadre int = null
)
AS
BEGIN
	SELECT DISTINCT
		RI.Id,
		CASE WHEN RI.IdEstadoRegistro LIKE 1 THEN 'OK' ELSE 
			(CASE WHEN RI.IdEstadoRegistro LIKE 2 THEN 'AE' ELSE 'Anulado' END ) END AS EstadoRegistro,
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
		SUM(ISNULL(DI.CuotaRecargoEquivalencia,0)) AS CuotaRE,
		count(*) over() as TotalCount
	FROM RegistroInformacion RI with (nolock) 
		INNER JOIN EstadoRegistro ER with (nolock) ON RI.IdEstadoRegistro = ER.id
		LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
		LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
	WHERE RI.IdEstadoRegistro = 4 AND Baja = 1
		AND IdLibroRegistro = @IdLibroRegistro 
		AND ISNULL(Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(Ejercicio,''))
		AND ISNULL(Periodo, '') = ISNULL(@Periodo, ISNULL(Periodo,''))
		AND 
		(
			(
				case when @IsIDOtros = 1 then ISNULL(IDContraparte,'') 
					else ISNULL(NifContraparte,'') end
			) = (
				case when @IsIDOtros = 1 then ISNULL(@NifContraparte, ISNULL(IDContraparte,'')) 
					else ISNULL(@NifContraparte, ISNULL(NifContraparte,'')) end
			)
		)
		AND ISNULL(RI.Id,'') = ISNULL(@IdFactura, ISNULL(RI.Id,''))
		AND ISNULL(NumSerieFacturaEmisor,'') = ISNULL(@NumSerieFacturaEmisor, ISNULL(NumSerieFacturaEmisor,''))
		AND (@FechaExpedicion IS NULL OR ISNULL(RI.FechaExpedicionFacturaEmisor,'') = ISNULL(CONVERT(VARCHAR(10),@FechaExpedicion,103), ISNULL(RI.FechaExpedicionFacturaEmisor, '')))
		AND (@FechaRegContable IS NULL OR ISNULL(FechaRegContable,'') = ISNULL(CONVERT(VARCHAR(10),@FechaRegContable,103), ISNULL(FechaRegContable, '')))
		AND (
			ISNULL(FechaOperacion,'') BETWEEN 
			ISNULL(CONVERT(VARCHAR(10),@FechaOperacionDesde,103), ISNULL(FechaOperacion, '')) AND 
			ISNULL(CONVERT(VARCHAR(10),@FechaOperacionHasta,103), ISNULL(FechaOperacion, ''))
			)
		AND (@IdEstadoCuadre is null or IdEstadoCuadre = @IdEstadoCuadre)
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
	ORDER BY RI.Id desc OFFSET @Start ROWS FETCH NEXT @Records ROWS ONLY


END