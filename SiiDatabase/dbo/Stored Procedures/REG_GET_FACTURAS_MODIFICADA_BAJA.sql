CREATE PROCEDURE [dbo].[REG_GET_FACTURAS_MODIFICADA_BAJA]
(
	@IdUser varchar(6),
	@IdLibroRegistro varchar(2),
	@IdEstadoLectura int,
	@IdAgencia varchar(4)
)
AS
BEGIN
	IF(@IdAgencia <> 'ATC')
	BEGIN
		IF(@IdLibroRegistro = 'FR' AND @IdEstadoLectura in (1,4))
		BEGIN
			SELECT distinct
				RI.Id,
				DE.Id as DetalleImportesId,
				@IdUser AS Usuario,
				RI.NifDeclarante ,
				RI.NombreRazon,
				RI.NIFRepresentante,
				--CASE WHEN RI.IdEstadoRegistro LIKE 3 THEN 'A0' ELSE 'A1' END as IdTipoOperacion,
				CASE WHEN op.IdTipoOperacion IN('A5', 'A6') THEN (
					CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A5' 
					ELSE 'A6' END)
				ELSE (CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A0' 
					ELSE 'A1' END) 
				END as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				RI.NifFacturaEmisor,
				RI.NumSerieFacturaEmisor,
				RI.NumSerieFacturaEmisorResumenFin, 
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END AS FechaEmisor,
				RI.TipoFactura,
				RI.NombreContraparte,
				RI.NifContraparte,
				RI.CodigoPaisContraparte,
				CASE WHEN RI.IDTypeContraparte = '00' OR RI.IDTypeContraparte = '' OR RI.IDTypeContraparte = ' ' THEN null ELSE RI.IDTypeContraparte END as IDTypeContraparte,
				RI.IDContraparte,
				FG.Id as Agrupada,
				FR.Id as Rectificada,
				isnull(RI.BaseRectificada,0.00) as BaseRectificada,
				isnull(RI.CuotaRectificada,0.00) as CuotaRectificada,
				isnull(RI.CuotaRecargoRectificada,0.00) as CuotaRecargoRectificada,
				RI.TipoRectificativa,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicion,
				CASE WHEN RI.FechaOperacion NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaOperacion,103) ELSE '' END as FechaOperacion,
				isnull(RI.ImporteTotal,0.00) as ImporteTotal,
				CASE WHEN RI.DesgloseTipoOperacion = 2 THEN CAST((CAST(RI.ClaveRegimenEspecialOTrascendencia as int) + 90) as varchar) ELSE RI.ClaveRegimenEspecialOTrascendencia END as ClaveRegimenEspecialOTrascendencia ,
				isnull(RI.BaseImponibleACoste,0.00) as BaseImponibleACoste, 
				RI.DescripcionOperacion,  
				DIN.SituacionInmueble,
				DIN.ReferenciaCatastral,
				RI.NumeroDUA,
				CASE WHEN RI.FechaRegContableDUA NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaRegContableDUA,103) ELSE '' END as FechaDUA,
				CASE WHEN RI.FechaRegContable NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaRegContable,103) ELSE '' END as FechaRegDUA,
				isnull(RI.CuotaDeducible,0.00) as CuotaDeducible,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.TipoImpositivo,0.00) ELSE 0.00 END as TipoImpositivoPasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.BaseImponible,0.00) ELSE 0.00 END as BaseImponiblePasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.CuotaSoportada,0.00) ELSE 0.00 END as CuotaSoportadaPasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.TipoRecargoEquivalencia,0.00) ELSE 0.00 END as TipoRecargoEquivalenciaPasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.CuotaRecargoEquivalencia,0.00) ELSE 0.00 END as CuotaRecargoEquivalenciaPasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.TipoImpositivo,0.00) ELSE 0.00 END as TipoImpositivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.BaseImponible,0.00) ELSE 0.00 END as BaseImponible,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.CuotaSoportada,0.00) ELSE 0.00 END as CuotaSoportada,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.TipoRecargoEquivalencia,0.00) ELSE 0.00 END as TipoRecargoEquivalencia,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.CuotaRecargoEquivalencia,0.00) ELSE 0.00 END as CuotaRecargoEquivalencia,
				isnull(DE.CargaImpositivaImplicita,0.00) as CargaImpositivaImplicita,
				isnull(DE.CuotaRecargoMinorista,0.00) as CuotaRecargoMinorista,
				isnull(DE.PorcentCompensacionREAGYP,0.00) as PorcentCompensacionREAGYP,
				isnull(DE.ImporteCompensacionREAGYP,0.00) as ImporteCompensacionREAGYP,
				DE.IdTipoDetalleIVA,
				DC.SimplificadaArt,
				DC.SinDestinatario,
				DC.RegPrevio,
				DC.Macrodato,
				DC.RefExterna,
				--DC.FacturaEnergia,
				DC.ClaveRegimen1,
				DC.ClaveRegimen2,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.BienInversion,'') ELSE '' END as BienInversion,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.BienInversion,'') ELSE '' END as BienInversionPasivo,
				RI.EjercicioDeduccion,
				RI.PeriodoDeduccion
	       
			FROM RegistroInformacion AS RI with(nolock)
				LEFT JOIN RegistrosOperacion AS RO with(nolock)ON RO.IdRegistroInformacion = RI.Id
				LEFT JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
			LEFT JOIN DetalleImportesIVA AS DE with(nolock)ON DE.IdRegistro = RI.Id
			LEFT JOIN FacturasAgrupadas AS FG with(nolock)ON FG.IdRegistroInformacion = RI.Id
			LEFT JOIN FacturasRectificadas AS FR with(nolock)ON FR.IdRegistroInformacion = RI.Id
				LEFT JOIN DetalleInmueble AS DIN with(nolock) ON DIN.IdRegistroInformacion = RI.Id
				LEFT JOIN DatosComplementarios AS DC with(nolock) ON DC.IdRegistroInformacion = RI.Id
	
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END
		ELSE IF (@IdLibroRegistro = 'FE' AND @IdEstadoLectura in (1,4))
		BEGIN
			SELECT  distinct
				RI.id,
				DI.Id as DetalleImportesId,
				@IdUser AS Usuario,
				RI.NifDeclarante ,
				RI.NombreRazon,
				RI.NIFRepresentante,
				--CASE WHEN RI.IdEstadoRegistro LIKE 3 THEN 'A0' ELSE 'A1' END as IdTipoOperacion,
				CASE WHEN op.IdTipoOperacion IN('A5', 'A6') THEN (
					CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A5' 
					ELSE 'A6' END)
				ELSE (CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A0' 
					ELSE 'A1' END) 
				END as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				RI.NifFacturaEmisor,
				RI.NumSerieFacturaEmisor,
				RI.NumSerieFacturaEmisorResumenFin, 
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor,
				RI.TipoFactura,
				RI.NombreContraparte,
				RI.NifContraparte,
				RI.CodigoPaisContraparte,
				CASE WHEN RI.IDTypeContraparte = '00' OR RI.IDTypeContraparte = '' OR RI.IDTypeContraparte = ' ' THEN null ELSE RI.IDTypeContraparte END as IDTypeContraparte,
				RI.IDContraparte,
				FA.Id as Agrupada,
				FR.Id as Rectificada,
				isnull(RI.BaseRectificada,0.00) as BaseRectificada,
				isnull(RI.CuotaRectificada,0.00) as CuotaRectificada,
				isnull(RI.CuotaRecargoRectificada,0.00) as CuotaRecargoRectificada,
				RI.TipoRectificativa,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicion,
				CASE WHEN RI.FechaOperacion NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaOperacion,103) ELSE '' END as FechaOperacion,
				isnull(RI.ImporteTotal,0.00) ImporteTotal,
				CASE WHEN RI.DesgloseTipoOperacion = 2 THEN CAST((CAST(RI.ClaveRegimenEspecialOTrascendencia as int) + 90) as varchar) ELSE RI.ClaveRegimenEspecialOTrascendencia END as ClaveRegimenEspecialOTrascendencia ,
				isnull(RI.BaseImponibleACoste,0.00) BaseImponibleACoste, 
				RI.DescripcionOperacion,  
				DIN.SituacionInmueble,
				DIN.ReferenciaCatastral,
				RI.CausaExencion,
				isnull(RI.BaseImponible,0.00) BaseImponible,
				isnull(RI.ImportePorArticulos7_14_Otros,0.00) ImportePorArticulos7_14_Otros,
				isnull(RI.ImporteTAIReglasLocalizacion,0.00) ImporteTAIReglasLocalizacion,
				isnull(RI.ImporteTransmisionSujetoAIVA,0.00) ImporteTransmisionSujetoAIVA,
				RI.EmitidaPorTerceros,
				RI.VariosDestinatarios,
				'N' AS Cupon,----------------------------Minoraci¢n
				RI.TipoNoExenta,
				isnull(DI.BaseImponible,0.00) BaseImponibleDI,
				isnull(DI.TipoImpositivo,0.00) TipoImpositivo,
				isnull(DI.CuotaRepercutida,0.00) CuotaRepercutida,
				isnull(DI.TipoRecargoEquivalencia,0.00) TipoRecargoEquivalencia,
				isnull(DI.CuotaRecargoEquivalencia,0.00) CuotaRecargoEquivalencia,
				isnull(DI.PorcentCompensacionREAGYP,0.00) PorcentCompensacionREAGYP,
				isnull(DI.ImporteCompensacionREAGYP,0.00) ImporteCompensacionREAGYP,
				-- datos Cmp
				DC.SimplificadaArt,
				DC.SinDestinatario,
				DC.RegPrevio,
				DC.Macrodato,
				DC.RefExterna,
				DC.FacturaEnergia,
				DC.ClaveRegimen1,
				DC.ClaveRegimen2
	
			FROM RegistroInformacion AS RI with(nolock)
				LEFT JOIN RegistrosOperacion AS RO with(nolock)ON RO.IdRegistroInformacion = RI.Id
				LEFT JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
				LEFT JOIN DetalleImportesIVA AS DI with(nolock) ON DI.IdRegistro = RI.Id
				LEFT JOIN FacturasAgrupadas AS FA with(nolock) ON FA.IdRegistroInformacion = RI.Id
				LEFT JOIN FacturasRectificadas AS FR with(nolock) ON FR.IdRegistroInformacion = RI.Id
				LEFT JOIN DetalleInmueble AS DIN with(nolock) ON DIN.IdRegistroInformacion = RI.Id
				LEFT JOIN DatosComplementarios AS DC with(nolock) ON DC.IdRegistroInformacion = RI.Id
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id

		END
		ELSE IF (@IdLibroRegistro = 'FR' AND @IdEstadoLectura = 2)
		BEGIN
			SELECT  distinct
				RI.id,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				'BJ' as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				ri.NifFacturaEmisor,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor
				,ri.NombreContraparte
				,ri.CodigoPaisContraparte
				,CASE WHEN RI.IDTypeContraparte = '00' OR RI.IDTypeContraparte = '' OR RI.IDTypeContraparte = ' ' THEN null ELSE RI.IDTypeContraparte END as IDTypeContraparte
				,ri.IDContraparte
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END
		ELSE IF (@IdLibroRegistro = 'FE' AND @IdEstadoLectura = 2)
		BEGIN
			SELECT  distinct
				RI.id,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				'BJ' as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				ri.NifFacturaEmisor,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor
				,ri.NombreContraparte
				,ri.CodigoPaisContraparte
				,CASE WHEN RI.IDTypeContraparte = '00' OR RI.IDTypeContraparte = '' OR RI.IDTypeContraparte = ' ' THEN null ELSE RI.IDTypeContraparte END as IDTypeContraparte
				,ri.IDContraparte
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END
		ELSE IF (@IdLibroRegistro = 'CO')
		BEGIN
			SELECT  distinct
				CO.id,
				RI.Id as IdRegistro,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				ri.NombreContraparte,
				ri.NifFacturaEmisor,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor,
				CASE WHEN CO.Fecha NOT LIKE '1900-01-01' THEN convert(varchar(10),CO.Fecha,103) ELSE '' END as Fecha,
				isnull(CO.Importe,0.00) as Importe,
				CO.IdMedio,
				CO.Cuenta_O_Medio
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
				LEFT JOIN Cobros CO ON 
					CO.IdRegistroInformacion = RI.Id 
					AND CO.Nuevo = 1
					AND CO.IdEstadoCobroPago = 0
			WHERE RI.IdLibroRegistro = 'FE' AND Nuevo = 1 AND RI.IdEstadoLectura in(0, 1, 3) AND @IdEstadoLectura = 1
				--AND RI.Id in(
				--	select distinct IdRegistroInformacion from Pagos where Nuevo = 1
				--)
			ORDER BY CO.Id
		END
		ELSE IF (@IdLibroRegistro = 'PA')
		BEGIN
			SELECT  distinct
				PA.id,
				RI.Id as IdRegistro,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				ri.NombreContraparte,
				ri.NifFacturaEmisor,
				CASE WHEN ri.IDTypeIdFactura = '00' OR ri.IDTypeIdFactura = '' OR ri.IDTypeIdFactura = ' ' THEN null ELSE ri.IDTypeIdFactura END as IDTypeIdFactura,
				ri.CodigoPaisIdFactura,
				ri.IDIdFactura,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor,
				CASE WHEN PA.Fecha NOT LIKE '1900-01-01' THEN convert(varchar(10),PA.Fecha,103) ELSE '' END as Fecha,
				isnull(PA.Importe,0.00) as Importe,
				PA.IdMedio,
				PA.Cuenta_O_Medio
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
				LEFT JOIN Pagos PA ON 
					PA.IdRegistroInformacion = RI.Id 
					AND PA.Nuevo = 1
					AND PA.IdEstadoCobroPago = 0
			WHERE RI.IdLibroRegistro = 'FR' AND Nuevo = 1 AND RI.IdEstadoLectura in(0, 1, 3) AND @IdEstadoLectura = 1
				--AND RI.Id in(
				--	select distinct IdRegistroInformacion from Pagos where Nuevo = 1
				--)
			ORDER BY PA.Id
		END
	END
	ELSE
	BEGIN
		IF(@IdLibroRegistro = 'FR' AND @IdEstadoLectura in (1,4))
		BEGIN
			SELECT distinct
				RI.id,
				DE.Id as DetalleImportesId,
				@IdUser AS Usuario,
				RI.NifDeclarante ,
				RI.NombreRazon,
				RI.NIFRepresentante,
				--CASE WHEN RI.IdEstadoRegistro LIKE 3 THEN 'A0' ELSE 'A1' END as IdTipoOperacion,
				CASE WHEN op.IdTipoOperacion IN('A5', 'A6') THEN (
					CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A5' 
					ELSE 'A6' END)
				ELSE (CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A0' 
					ELSE 'A1' END) 
				END as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				RI.NifFacturaEmisor,
				RI.NumSerieFacturaEmisor,
				RI.NumSerieFacturaEmisorResumenFin, 
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END AS FechaEmisor,
				RI.TipoFactura,
				RI.NombreContraparte,
				RI.NifContraparte,
				RI.CodigoPaisContraparte,
				CASE WHEN RI.IDTypeContraparte = '00' OR RI.IDTypeContraparte = '' OR RI.IDTypeContraparte = ' ' THEN null ELSE RI.IDTypeContraparte END as IDTypeContraparte,
				RI.IDContraparte,
				FG.Id as Agrupada,
				FR.Id as Rectificada,
				isnull(RI.BaseRectificada,0.00) BaseRectificada,
				isnull(RI.CuotaRectificada,0.00) CuotaRectificada,
				isnull(RI.CuotaRecargoRectificada,0.00) CuotaRecargoRectificada,
				RI.TipoRectificativa,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicion,
				CASE WHEN RI.FechaOperacion NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaOperacion,103) ELSE '' END as FechaOperacion,
				isnull(RI.ImporteTotal,0.00) ImporteTotal,
				CASE WHEN RI.DesgloseTipoOperacion = 2 THEN CAST((CAST(RI.ClaveRegimenEspecialOTrascendencia as int) + 90) as varchar) ELSE RI.ClaveRegimenEspecialOTrascendencia END as ClaveRegimenEspecialOTrascendencia ,
				isnull(RI.BaseImponibleACoste,0.00) BaseImponibleACoste, 
				RI.DescripcionOperacion,  
				DIN.SituacionInmueble,
				DIN.ReferenciaCatastral,
				--RI.NumeroDUA,
				--CASE WHEN RI.FechaRegContableDUA NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaRegContableDUA,103) ELSE '' END as FechaDUA,
				CASE WHEN RI.FechaRegContable NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaRegContable,103) ELSE '' END as FechaRegDUA,
				isnull(RI.CuotaDeducible,0.00) CuotaDeducible,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.TipoImpositivo,0.00) ELSE 0.00 END as TipoImpositivoPasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.BaseImponible,0.00) ELSE 0.00 END as BaseImponiblePasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.CuotaSoportada,0.00) ELSE 0.00 END as CuotaSoportadaPasivo,
				--CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.TipoRecargoEquivalencia,0.00) ELSE 0.00 END as TipoRecargoEquivalenciaPasivo,
				--CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.CuotaRecargoEquivalencia,0.00) ELSE 0.00 END as CuotaRecargoEquivalenciaPasivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.TipoImpositivo,0.00) ELSE 0.00 END as TipoImpositivo,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.BaseImponible,0.00) ELSE 0.00 END as BaseImponible,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.CuotaSoportada,0.00) ELSE 0.00 END as CuotaSoportada,
				--CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.TipoRecargoEquivalencia,0.00) ELSE 0.00 END as TipoRecargoEquivalencia,
				--CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.CuotaRecargoEquivalencia,0.00) ELSE 0.00 END as CuotaRecargoEquivalencia,
				isnull(DE.CargaImpositivaImplicita,0.00) as CargaImpositivaImplicita,
				isnull(DE.CuotaRecargoMinorista,0.00) as CuotaRecargoMinorista,
				isnull(DE.PorcentCompensacionREAGYP,0.00) as PorcentCompensacionREAGYP,
				isnull(DE.ImporteCompensacionREAGYP,0.00) as ImporteCompensacionREAGYP,
				DE.IdTipoDetalleIVA,
				DC.SimplificadaArt,
				DC.SinDestinatario,
				DC.RegPrevio,
				DC.Macrodato,
				DC.RefExterna,
				--DC.FacturaEnergia,
				RIGIC.PagoAnticipado,
				RIGIC.IdTipoBienOperacion,
				RIGIC.IdTipoDocumentoArt25,
				RIGIC.NumeroProtocolo,
				RIGIC.NombreNotario,
				DC.ClaveRegimen1,
				DC.ClaveRegimen2,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 0 THEN isnull(DE.BienInversion,'') ELSE '' END as BienInversion,
				CASE WHEN DE.IdTipoDetalleIVA LIKE 1 THEN isnull(DE.BienInversion,'') ELSE '' END as BienInversionPasivo,
				RI.EjercicioDeduccion,
				RI.PeriodoDeduccion
	       
			FROM RegistroInformacion AS RI with(nolock)
				LEFT JOIN RegistrosOperacion AS RO with(nolock)ON RO.IdRegistroInformacion = RI.Id
				LEFT JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
			LEFT JOIN DatosComplementarios AS DC with(nolock)ON RI.Id = DC.IdRegistroInformacion
			LEFT JOIN RegistroInformacion_IGIC AS RIGIC with(nolock)ON RI.Id = RIGIC.IdRegistroInformacion
			LEFT JOIN DetalleImportesIVA AS DE with(nolock)ON DE.IdRegistro = RI.Id
			LEFT JOIN FacturasAgrupadas AS FG with(nolock)ON FG.IdRegistroInformacion = RI.Id
			LEFT JOIN FacturasRectificadas AS FR with(nolock)ON FR.IdRegistroInformacion = RI.Id
				LEFT JOIN DetalleInmueble AS DIN with(nolock) ON DIN.IdRegistroInformacion = RI.Id
	
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END
		ELSE IF (@IdLibroRegistro = 'FE' AND @IdEstadoLectura in (1,4))
		BEGIN
			SELECT  distinct
				RI.id,
				DI.Id as DetalleImportesId,
				@IdUser AS Usuario,
				RI.NifDeclarante,
				RI.NombreRazon,
				RI.NIFRepresentante,
				--CASE WHEN RI.IdEstadoRegistro LIKE 3 THEN 'A0' ELSE 'A1' END as IdTipoOperacion,
				CASE WHEN op.IdTipoOperacion IN('A5', 'A6') THEN (
						CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A5' 
						ELSE 'A6' END)
					ELSE (CASE WHEN RI.IdEstadoRegistro in (0,3) THEN 'A0' 
						ELSE 'A1' END) 
					END as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				RI.NifFacturaEmisor,
				RI.NumSerieFacturaEmisor,
				RI.NumSerieFacturaEmisorResumenFin, 
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor,
				RI.TipoFactura,
				RI.NombreContraparte,
				RI.NifContraparte,
				RI.CodigoPaisContraparte,
				CASE WHEN RI.IDTypeContraparte = '00' OR RI.IDTypeContraparte = '' OR RI.IDTypeContraparte = ' ' THEN null ELSE RI.IDTypeContraparte END as IDTypeContraparte,
				RI.IDContraparte,
				FA.Id as Agrupada,
				FR.Id as Rectificada,
				isnull(RI.BaseRectificada,0.00) BaseRectificada,
				isnull(RI.CuotaRectificada,0.00) CuotaRectificada,
				isnull(RI.CuotaRecargoRectificada,0.00) CuotaRecargoRectificada,
				RI.TipoRectificativa,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicion,
				CASE WHEN RI.FechaOperacion NOT LIKE '1900-01-01' THEN convert(varchar(10),RI.FechaOperacion,103) ELSE '' END as FechaOperacion,
				isnull(RI.ImporteTotal,0.00) ImporteTotal,
				CASE WHEN RI.DesgloseTipoOperacion = 2 THEN CAST((CAST(RI.ClaveRegimenEspecialOTrascendencia as int) + 90) as varchar) ELSE RI.ClaveRegimenEspecialOTrascendencia END as ClaveRegimenEspecialOTrascendencia ,
				isnull(RI.BaseImponibleACoste,0.00) BaseImponibleACoste, 
				RI.DescripcionOperacion,  
				DIN.SituacionInmueble,
				DIN.ReferenciaCatastral,
				RI.CausaExencion,
				isnull(RI.BaseImponible,0.00) BaseImponible,
				isnull(RI.ImportePorArticulos7_14_Otros,0.00) ImportePorArticulos7_14_Otros,
				isnull(RI.ImporteTAIReglasLocalizacion,0.00) ImporteTAIReglasLocalizacion,
				isnull(RI.ImporteTransmisionSujetoAIVA,0.00) ImporteTransmisionSujetoAIVA,
				RI.EmitidaPorTerceros,
				RI.VariosDestinatarios,
				'N' AS Cupon,----------------------------Minoraci¢n
				RI.TipoNoExenta,
				isnull(DI.BaseImponible,0.00) BaseImponibleDI,
				isnull(DI.TipoImpositivo,0.00) TipoImpositivo,
				isnull(DI.CuotaRepercutida,0.00) CuotaRepercutida,
				isnull(DI.TipoRecargoEquivalencia,0.00) TipoRecargoEquivalencia,
				isnull(DI.CuotaRecargoEquivalencia,0.00) CuotaRecargoEquivalencia,
				--DI.PorcentCompensacionREAGYP,
				--DI.ImporteCompensacionREAGYP,
				DI.BienInversion,
				DC.SimplificadaArt,
				DC.SinDestinatario,
				DC.RegPrevio,
				DC.Macrodato,
				DC.RefExterna,
				DC.FacturaEnergia,
				RIGIC.PagoAnticipado,
				RIGIC.IdTipoBienOperacion,
				RIGIC.IdTipoDocumentoArt25,
				RIGIC.NumeroProtocolo,
				RIGIC.NombreNotario
				--DC.ClaveRegimen1,
				--DC.ClaveRegimen2
			FROM RegistroInformacion AS RI with(nolock)
				Left JOIN RegistrosOperacion AS RO with(nolock)ON RO.IdRegistroInformacion = RI.Id
				Left JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
				LEFT JOIN DatosComplementarios AS DC with(nolock)ON RI.Id = DC.IdRegistroInformacion
				LEFT JOIN RegistroInformacion_IGIC AS RIGIC with(nolock)ON RI.Id = RIGIC.IdRegistroInformacion
				LEFT JOIN DetalleImportesIVA AS DI with(nolock) ON DI.IdRegistro = RI.Id
				LEFT JOIN FacturasAgrupadas AS FA with(nolock) ON FA.IdRegistroInformacion = RI.Id
				LEFT JOIN FacturasRectificadas AS FR with(nolock) ON FR.IdRegistroInformacion = RI.Id
				LEFT JOIN DetalleInmueble AS DIN with(nolock) ON DIN.IdRegistroInformacion = RI.Id
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END	
		ELSE IF (@IdLibroRegistro = 'FR' AND @IdEstadoLectura = 2)
		BEGIN
			SELECT  distinct
				RI.id,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				'BJ' as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				ri.NifFacturaEmisor,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor
				,ri.NombreContraparte
				,ri.CodigoPaisContraparte
				,CASE WHEN ri.IDTypeContraparte = '00' OR ri.IDTypeContraparte = '' OR ri.IDTypeContraparte = ' ' THEN null ELSE ri.IDTypeContraparte END as IDTypeContraparte
				,ri.IDContraparte
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END
		ELSE IF (@IdLibroRegistro = 'FE' AND @IdEstadoLectura = 2)
		BEGIN
			SELECT  distinct
				RI.id,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				'BJ' as IdTipoOperacion,
				RI.Ejercicio,
				RI.Periodo,
				ri.NifFacturaEmisor,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor
				,ri.NombreContraparte
				,ri.CodigoPaisContraparte
				,CASE WHEN ri.IDTypeContraparte = '00' OR ri.IDTypeContraparte = '' OR ri.IDTypeContraparte = ' ' THEN null ELSE ri.IDTypeContraparte END as IDTypeContraparte
				,ri.IDContraparte
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
			WHERE RI.IdEstadoLectura = @IdEstadoLectura and RI.IdLibroRegistro = @IdLibroRegistro
			ORDER BY ri.Id
		END
		ELSE IF (@IdLibroRegistro = 'CO')
		BEGIN
			SELECT  distinct
				CO.id,
				RI.Id as IdRegistro,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				ri.NombreContraparte,
				ri.NifFacturaEmisor,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor,
				CASE WHEN CO.Fecha NOT LIKE '1900-01-01' THEN convert(varchar(10),CO.Fecha,103) ELSE '' END as Fecha,
				isnull(CO.Importe,0.00) as Importe,
				CO.IdMedio,
				CO.Cuenta_O_Medio
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
				LEFT JOIN Cobros CO ON 
					CO.IdRegistroInformacion = RI.Id 
					AND CO.Nuevo = 1
					AND CO.IdEstadoCobroPago = 0
			WHERE RI.IdLibroRegistro = 'FE' AND Nuevo = 1 AND RI.IdEstadoLectura in(0, 1, 3) AND @IdEstadoLectura = 1
				--AND RI.Id in(
				--	select distinct IdRegistroInformacion from Pagos where Nuevo = 1
				--)
			ORDER BY CO.Id
		END
		ELSE IF (@IdLibroRegistro = 'PA')
		BEGIN
			SELECT  distinct
				PA.id,
				RI.Id as IdRegistro,
				@IdUser AS Usuario,
				ri.NifDeclarante,
				ri.NombreRazon,
				ri.NIFRepresentante,
				ri.NombreContraparte,
				ri.NifFacturaEmisor,
				CASE WHEN ri.IDTypeIdFactura = '00' OR ri.IDTypeIdFactura = '' OR ri.IDTypeIdFactura = ' ' THEN null ELSE ri.IDTypeIdFactura END as IDTypeIdFactura,
				ri.CodigoPaisIdFactura,
				ri.IDIdFactura,
				ri.NumSerieFacturaEmisor,
				CASE WHEN RI.FechaExpedicionFacturaEmisor NOT LIKE '1900-01-01' THEN convert(varchar(10),ri.FechaExpedicionFacturaEmisor,103) ELSE '' END as FechaExpedicionFacturaEmisor,
				CASE WHEN PA.Fecha NOT LIKE '1900-01-01' THEN convert(varchar(10),PA.Fecha,103) ELSE '' END as Fecha,
				isnull(PA.Importe,0.00) as Importe,
				PA.IdMedio,
				PA.Cuenta_O_Medio
			FROM RegistrosOperacion AS RO with(nolock)
				INNER JOIN RegistroInformacion AS RI with(nolock)ON RO.IdRegistroInformacion = RI.Id
				INNER JOIN Operacion AS OP with(nolock)ON RO.IdOperacion = OP.Id
				LEFT JOIN Pagos PA ON 
					PA.IdRegistroInformacion = RI.Id 
					AND PA.Nuevo = 1
					AND PA.IdEstadoCobroPago = 0
			WHERE RI.IdLibroRegistro = 'FR' AND Nuevo = 1 AND RI.IdEstadoLectura in(0, 1, 3) AND @IdEstadoLectura = 1
				--AND RI.Id in(
				--	select distinct IdRegistroInformacion from Pagos where Nuevo = 1
				--)
			ORDER BY PA.Id
		END
	END
END