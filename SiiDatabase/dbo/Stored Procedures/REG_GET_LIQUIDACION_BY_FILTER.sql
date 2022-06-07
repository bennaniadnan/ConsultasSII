CREATE PROCEDURE  [dbo].[REG_GET_LIQUIDACION_BY_FILTER] (
	-- Add the parameters for the stored procedure here
	@IdLibroRegistro varchar(2) = null,
	@Ejercicio int,
	@Periodo varchar(2),
	@IDTypeContraparte varchar(2) = null,
	@IdTipoDetalleIVA int = null,
	@TipoImpositivo decimal(15,2) = null,
	@ClaveRegimen varchar(2) = null,
	@IdTipoFactura varchar(2) = null,
	@CausaExencion varchar(2) = null,
	@TipoNoExenta varchar(2) = null
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
	CASE WHEN RI.TipoDesglose LIKE 0 THEN 'DI' ELSE (CASE WHEN RI.TipoDesglose LIKE 1 THEN 
		(CASE WHEN RI.DesgloseTipoOperacion LIKE 0 THEN 'EB' ELSE 'PS' END) ELSE NULL END) END AS TipoDesglose,
	RI.BaseImponible AS BaseExenta,
	RI.CausaExencion,
	CASE WHEN RI.TipoNoExenta LIKE 'S2' THEN 'ISP' ELSE '' END AS TipoDeSujecion,
	RI.CuotaDeducible,
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
		FROM Operacion OP with (nolock) 
			 INNER JOIN RegistrosOperacion RO with (nolock) ON OP.Id = RO.IdOperacion
			 INNER JOIN RegistroInformacion RI with (nolock) ON RO.IdRegistroInformacion = RI.Id
			 INNER JOIN EstadoRegistro ER with (nolock) ON ER.Id = RI.IdEstadoRegistro
			 LEFT JOIN DetalleImportesIVA DI with (nolock) ON RI.Id = DI.IdRegistro
			 LEFT JOIN DatosComplementarios DC  with (nolock) ON RI.Id = DC.IdRegistroInformacion
			 LEFT OUTER JOIN RegistrosOperacion RO2 with (nolock) 
				ON RI.Id = RO2.IdRegistroInformacion
					and RO.Id < RO2.Id
				where RI.IdEstadoRegistro IN (1,2) AND RO2.id IS NULL
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
					AND isnull(RI.CausaExencion,'') = isNULL(@CausaExencion,isnull(RI.CausaExencion,''))
					AND isnull(RI.TipoNoExenta,'') = isNULL(@TipoNoExenta,isnull(RI.TipoNoExenta,''))
					AND isnull(RI.ClaveRegimenEspecialOTrascendencia,'') = isNULL(@ClaveRegimen,isnull(RI.ClaveRegimenEspecialOTrascendencia,''))
END
GO
