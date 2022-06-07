CREATE PROCEDURE [dbo].[LIQ_GET_LIQUIDACION_BY_PERIODIFICACION_ATC_DI] (
	@Ejercicio int,
	@Periodo varchar(2),
	@IdAgencia varchar(10)
)AS
BEGIN

	SELECT ISNULL(SUM(DI.BaseImponible),0) AS BaseImponible
		 , ISNULL(SUM(DI.CuotaRepercutida),0) AS CuotaRepercutida
		 , ISNULL(SUM(DI.CuotaSoportada),0) AS CuotaSoportada
		 , ISNULL(SUM(RI.[ImportePorArticulos7_14_Otros]),0) AS ImportePorArticulos7_14_Otros
		 , ISNULL(SUM(RI.[ImporteTAIReglasLocalizacion]),0) AS ImporteTAIReglasLocalizacion
		 , ISNULL(SUM(RI.[BaseImponible]),0) AS BaseExenta
		 , ISNULL(SUM(RI.[CuotaDeducible]),0) AS CuotaExenta
		 , RI.ClaveRegimenEspecialOTrascendencia
		 , RI.IdLibroRegistro
		 , RI.TipoFactura
		 , RI.[TipoNoExenta]
		 , RI.IDTypeContraparte
		 , RI.CausaExencion
		 , DI.IdTipoDetalleIVA
		 , DI.TipoImpositivo
		--INTO #tmp 
		FROM [dbo].[RegistroInformacion] RI WITH (NOLOCK) 
			LEFT JOIN [dbo].[DetalleImportesIVA] DI WITH (NOLOCK)
			ON RI.Id = DI.IdRegistro
				WHERE RI.IdEstadoRegistro IN (1,2)
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
				GROUP BY RI.ClaveRegimenEspecialOTrascendencia
					, RI.IdLibroRegistro
					, RI.TipoFactura
					, RI.[TipoNoExenta]
					, RI.IDTypeContraparte
					, RI.CausaExencion
					, DI.IdTipoDetalleIVA
					, DI.TipoImpositivo


END

