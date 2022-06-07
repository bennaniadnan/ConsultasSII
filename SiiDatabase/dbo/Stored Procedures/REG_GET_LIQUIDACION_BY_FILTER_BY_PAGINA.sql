CREATE PROCEDURE  [dbo].[REG_GET_LIQUIDACION_BY_FILTER_BY_PAGINA] 
(
	@IdLibroRegistro varchar(2) = null,
	@Ejercicio int,
	@Periodo varchar(2),
	@IDTypeContraparte varchar(2) = null,
	@IdTipoDetalleIVA int = null,
	@TipoImpositivo decimal(15,2) = null,
	@TipoRE decimal(15,2) = null,
	@ClaveRegimen varchar(2) = null,
	@IdTipoFactura varchar(2) = null,
	@CausaExencion varchar(2) = null,
	@TipoNoExenta varchar(2) = null,
	@Start int = 0,
	@Records int = 10,
	@IdAgencia varchar(10) = null,
	@RowDataId varchar(2) = null,
	@BienInversion VARCHAR = null
)
AS
BEGIN
SELECT DISTINCT 
	RI.Id AS Id,
	ER.Descripcion AS EstadoRegistro,
	RI.NumSerieFacturaEmisor AS NumeroFactura,
	CONVERT(VARCHAR(10),RI.FechaExpedicionFacturaEmisor,103) AS FechaFactura,
	isnull(nullif(RI.NifContraparte,''),RI.IDContraparte) AS IdFiscal,
	RI.NombreContraparte,
	RI.CodigoPaisContraparte,
	RI.IDTypeContraparte,
	RI.TipoFactura,
	RI.ClaveRegimenEspecialOTrascendencia AS ClaveRegimenEspecial,
	RI.ImporteTotal,
	CASE WHEN RI.ImporteTAIReglasLocalizacion > 0  AND RI.ImporteTAIReglasLocalizacion IS NOT NULL THEN 'RL' ELSE 
		(CASE WHEN RI.ImportePorArticulos7_14_Otros > 0 AND RI.ImportePorArticulos7_14_Otros IS NOT NULL THEN 'A7' ELSE NULL END) END AS TipoNoSujeto,
	isnull(nullif(RI.ImporteTAIReglasLocalizacion,0.00),RI.ImportePorArticulos7_14_Otros) AS BaseNoSujeta,
	CASE WHEN RI.TipoDesglose LIKE 1 THEN 'DI' ELSE (CASE WHEN RI.TipoDesglose LIKE 2 THEN 
		(CASE WHEN RI.DesgloseTipoOperacion LIKE 1 THEN 'EB' ELSE 'PS' END) ELSE NULL END) END AS TipoDesglose,
	RI.BaseImponible AS BaseExenta,
	RI.CausaExencion,
	CASE WHEN RI.TipoNoExenta LIKE 'S2' THEN 'ISP' ELSE '' END AS TipoDeSujecion,
	RI.TipoNoExenta,
	RI.CuotaDeducible,
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
	--DI.CuotaRecargoEquivalencia AS CuotaRE,
	SUM(ISNULL(DI.BaseImponible,0)) as BaseImponible,
	SUM(ISNULL(CASE WHEN RI.IdLibroRegistro LIKE 'FE' THEN DI.CuotaRepercutida ELSE DI.CuotaSoportada END,0)) AS CuotaIVA,
	--SUM(ISNULL(DI.TipoRecargoEquivalencia,0)) AS TipoRE,
	SUM(ISNULL(DI.CuotaRecargoEquivalencia,0)) AS CuotaRE, 
	COUNT(*) over() as TotalCount
		FROM RegistroInformacion RI with (nolock) 
			 INNER JOIN EstadoRegistro ER with (nolock) ON ER.Id = RI.IdEstadoRegistro
			 LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
			 LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
		where RI.IdEstadoRegistro IN (1,2) 
		--AND (@IdAgencia IS NULL OR @RowDataId IS NULL OR ((@IdAgencia = 'ATC' AND 
		--((@RowDataId in ('01','02','03','04','05','06') AND RI.TipoNoExenta <> 'S2' AND (RI.TipoFactura = 'F1' OR RI.TipoFactura = 'F2' OR RI.TipoFactura = 'F4'))
		--OR (@RowDataId = '11' AND (RI.TipoFactura = 'F1' OR RI.TipoFactura = 'F2'))
		--OR (@RowDataId = '22' OR (isnull(nullif(RI.ImporteTAIReglasLocalizacion,0.00),RI.ImportePorArticulos7_14_Otros) <> 0 OR RI.TipoNoExenta = 'S2'))
		--OR @RowDataId not in ('01','02','03','04','05','06', '11', '22') ))
		--OR (@IdAgencia <> 'ATC' AND
		--(@RowDataId not in ('01','02','03','04','05','06','07','08','09','121','122','14','25','26')
		--OR (@RowDataId in ('01','02','03') AND (RI.TipoFactura = 'F1' OR RI.TipoFactura = 'F2' OR RI.TipoFactura = 'F4'))
		----OR (@RowDataId = '04' AND ((RI.TipoFactura = 'F1' OR RI.TipoFactura = 'R1') AND RI.TipoImpositivo <> 0))
		--OR (@RowDataId = '05' AND (RI.IDTypeContraparte <> '02' AND (RI.TipoFactura = 'F1' OR RI.TipoFactura = 'R1')))
		--OR (@RowDataId = '06' AND (RI.IDTypeContraparte <> '02' OR RI.IDTypeContraparte <> '06') AND
		--		   (RI.TipoFactura = 'R1' OR RI.TipoFactura = 'R5'))
		--OR (@RowDataId in ('07','08','09') AND (RI.IDTypeContraparte <> '02' OR RI.IDTypeContraparte <> '06'))
		--OR (@RowDataId in ('121','122') AND RI.IDTypeContraparte <> '02')
		--OR (@RowDataId = '14' AND (RI.IDTypeContraparte <> '02' OR RI.IDTypeContraparte <> '06'))
		--OR (@RowDataId = '25' AND ((RI.CausaExencion = 'E4' AND RI.ClaveRegimenEspecialOTrascendencia = '01') OR RI.ClaveRegimenEspecialOTrascendencia = '02'))
		--OR (@RowDataId = '26' AND ((isnull(nullif(RI.ImporteTAIReglasLocalizacion,0.00),RI.ImportePorArticulos7_14_Otros) <> 0 AND RI.IDTypeContraparte <> '02') OR RI.TipoNoExenta = 'S2'))))))
			AND (
				(RI.Periodo = @Periodo 
				AND (
					RI.FechaOperacion IS NULL
					OR @Periodo = RIGHT('0' + convert(varchar(2), MONTH(RI.FechaOperacion)), 2)
					OR RI.IdLibroRegistro = 'FR'
				)) 
				OR @Periodo = '0A'
			)
			AND (
				RI.Ejercicio = @Ejercicio
				AND(
					RI.FechaOperacion IS NULL
					OR RI.IdLibroRegistro = 'FR'
					OR @Ejercicio = YEAR(RI.FechaOperacion)	
				)
			)
			AND isnull(RI.IDTypeContraparte,'') = isNULL(@IDTypeContraparte,isnull(RI.IDTypeContraparte,''))
			AND isnull(DI.IdTipoDetalleIVA,-1) = isNULL(@IdTipoDetalleIVA,isnull(DI.IdTipoDetalleIVA,-1))
			AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
			AND isnull(RI.TipoFactura,'') = isNULL(@IdTipoFactura,isnull(RI.TipoFactura,''))
			AND isnull(DI.TipoImpositivo, -1) = isNULL(@TipoImpositivo,isnull(DI.TipoImpositivo, -1))
			AND isnull(DI.TipoRecargoEquivalencia, -1) = isNULL(@TipoRE,isnull(DI.TipoRecargoEquivalencia, -1))
			AND isnull(nullif(DI.BienInversion, 'N'), '') = isNULL(nullif(@BienInversion, 'N'),isnull(nullif(DI.BienInversion, 'N'), ''))
			AND isnull(RI.CausaExencion,'') = isNULL(@CausaExencion,isnull(RI.CausaExencion,''))
			AND isnull(RI.TipoNoExenta,'') = isNULL(@TipoNoExenta,isnull(RI.TipoNoExenta,''))
			AND isnull(RI.ClaveRegimenEspecialOTrascendencia,'') = isNULL(@ClaveRegimen,isnull(RI.ClaveRegimenEspecialOTrascendencia,''))
			group by 
			RI.Id,
			ER.Descripcion,
			RI.NumSerieFacturaEmisor,
			RI.FechaExpedicionFacturaEmisor,
			RI.NifContraparte,
			RI.IDContraparte,
			RI.NombreContraparte,
			RI.CodigoPaisContraparte,
			RI.IDTypeContraparte,
			RI.TipoFactura,
			RI.ClaveRegimenEspecialOTrascendencia,
			RI.ImporteTotal,
			RI.ImporteTAIReglasLocalizacion,
			RI.ImportePorArticulos7_14_Otros,
			RI.TipoDesglose,
			RI.DesgloseTipoOperacion,
			RI.BaseImponible,
			RI.CausaExencion,
			RI.TipoNoExenta,
			RI.CuotaDeducible,
			DC.RefExterna
			ORDER BY Id desc --OFFSET @Start ROWS FETCH NEXT @Records ROWS ONLY				
END
