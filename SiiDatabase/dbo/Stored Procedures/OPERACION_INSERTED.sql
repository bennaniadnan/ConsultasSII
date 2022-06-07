CREATE PROCEDURE [dbo].[OPERACION_INSERTED]
	@IdOperacion int
AS
	DECLARE @Pendientes int = 0, @Aceptados int = 0, @AceptadosCondicionados int = 0, @Rechazados int = 0,
	@Ejercicio int,
	@Periodo VARCHAR(2),
	@IdLibroRegistro VARCHAR(2),
	@FueraPlazo int = 0,
	@NoFueraPlazo int = 0,
	@NonIdentificado int = 0,
	@Total int = 0

	SELECT 
			@Pendientes = ISNULL(COUNT(CASE WHEN RO.IdEstadoRegistro like 0 then 1 end),0),
			@Aceptados = ISNULL(COUNT(CASE WHEN RO.IdEstadoRegistro like 1 then 1 end),0),
			@AceptadosCondicionados = ISNULL(COUNT(CASE WHEN RO.IdEstadoRegistro like 2 then 1 end),0),
			@Rechazados = ISNULL(COUNT(CASE WHEN RO.IdEstadoRegistro like 3 then 1 end),0)
		FROM [RegistrosOperacion] RO
		WHERE IdOperacion = @IdOperacion

		UPDATE [Operacion]
		SET Pendientes = @Pendientes,
		Aceptados = @Aceptados, 
		AceptadosCondicionados = @AceptadosCondicionados,
		Rechazados = @Rechazados
		WHERE Id = @IdOperacion
		
	SELECT 
		@Ejercicio = O.Ejercicio, 
		@Periodo = O.Periodo,
		@IdLibroRegistro = O.IdLibroRegistro,
		@Pendientes = ISNULL(COUNT(CASE WHEN O.IdResultadoOperacion like 0 then 1 end),0), 
		@Aceptados = ISNULL(COUNT(CASE WHEN O.IdResultadoOperacion like 1 then 1 end),0), 
		@AceptadosCondicionados = ISNULL(COUNT(CASE WHEN O.IdResultadoOperacion like 2 then 1 end),0), 
		@Rechazados = ISNULL(COUNT(CASE WHEN O.IdResultadoOperacion like 3 then 1 end),0)
	FROM [Operacion] O 
	WHERE O.Id = @IdOperacion
	GROUP BY O.Ejercicio,  O.Periodo, O.IdLibroRegistro
	
	SELECT 
		@FueraPlazo = ISNULL(COUNT(CASE WHEN RI.IdEstadoRegistro in(1,2) AND RI.FechaFinPlazo IS NOT NULL AND O.FechaOperacion IS NOT NULL AND O.FechaOperacion > RI.FechaFinPlazo then 1 end),0),
		@NoFueraPlazo = ISNULL(COUNT(CASE WHEN RI.IdEstadoRegistro in(1,2) AND RI.FechaFinPlazo IS NOT NULL AND O.FechaOperacion IS NOT NULL AND O.FechaOperacion <= RI.FechaFinPlazo then 1 end),0),
		@NonIdentificado = ISNULL(COUNT(CASE WHEN RI.IdEstadoRegistro in(1,2) AND RI.FechaFinPlazo IS NULL OR O.FechaOperacion IS NULL then 1 end),0),
		@Total = ISNULL(COUNT(CASE WHEN RI.IdEstadoRegistro in(1,2) then 1 end),0)
	FROM [Operacion] O 
	LEFT JOIN [RegistrosOperacion] RO ON RO.IdOperacion = O.Id
	LEFT JOIN [RegistroInformacion] RI ON RI.Id = RO.IdRegistroInformacion
	WHERE O.Id = @IdOperacion

	IF @Total <> @FueraPlazo + @NoFueraPlazo + @NonIdentificado
		RAISERROR (N'Calcul total fuera es incorrecto @Total = %d, @FueraPlazo = %d, @NoFueraPlazo = %d @NonIdentificado = %d, @IdOperacion = %d.', 16, 1, @Total, @FueraPlazo, @NoFueraPlazo, @NonIdentificado, @IdOperacion)
	IF NOT EXISTS(SELECT 1 FROM [Operaciones_Periodo] WHERE Ejercicio = @Ejercicio)
	BEGIN
		
		INSERT [Operaciones_Periodo] (Ejercicio, Periodo, Pendientes, Aceptados, ConErrores, Rechazados,IdLibroRegistro,FueraPlazo,NoFueraPlazo)
			SELECT @Ejercicio, p.Id, 0, 0, 0, 0, l.Id, 0, 0 FROM [Periodo] p, LibroRegistro l
		
	END
	UPDATE [Operaciones_Periodo] SET Pendientes = ISNULL(Pendientes,0) + ISNULL(@Pendientes,0), 
	Aceptados = ISNULL(Aceptados,0) + ISNULL(@Aceptados,0), ConErrores = ISNULL(ConErrores,0) + ISNULL(@AceptadosCondicionados,0), 
	Rechazados = ISNULL(Rechazados,0) + ISNULL(@Rechazados,0), FueraPlazo = ISNULL(FueraPlazo,0) + ISNULL(@FueraPlazo,0),
		NoFueraPlazo = ISNULL(NoFueraPlazo,0) + ISNULL(@NoFueraPlazo,0), NonIdentificado = ISNULL(NonIdentificado,0) + ISNULL(@NonIdentificado,0)
	WHERE Ejercicio = @Ejercicio AND Periodo = @Periodo AND IdLibroRegistro = @IdLibroRegistro
GO
