CREATE PROCEDURE [dbo].[PGO_INSERT_OR_UPDATE_PAGOS] (
	@Id int = null,
	@IdRegistroInformacion int,
	@Fecha date,
	@Importe decimal(15,2),
	@IdMedio varchar(2),
	@Cuenta_O_Medio varchar(34),
	@Nuevo bit = 0,
	@IdEstadoCobroPago int = 0
)
AS
BEGIN
	IF EXISTS (select Id from Pagos 
				where Id = ISNULL(@Id, 0))
	BEGIN
		UPDATE Pagos
		SET Fecha = isnull(@Fecha, Fecha),
			Importe = isnull(@Importe, Importe),
			IdMedio = isnull(@IdMedio, IdMedio),
			Cuenta_O_Medio = isnull(@Cuenta_O_Medio, Cuenta_O_Medio),
			Nuevo = isnull(@Nuevo, Nuevo),
			IdEstadoCobroPago = isnull(@IdEstadoCobroPago, IdEstadoCobroPago)
		WHERE Id = @Id
	END
	--ELSE IF EXISTS (select Id from Pagos 
	--			where IdRegistroInformacion = @IdRegistroInformacion
	--			AND Fecha = @Fecha
	--			AND Importe = @Importe
	--			AND IdMedio = @IdMedio
	--			AND Cuenta_O_Medio = @Cuenta_O_Medio
	--			AND Nuevo = @Nuevo)
	--BEGIN
	--	UPDATE Pagos
	--	SET Fecha = isnull(@Fecha, Fecha),
	--		Importe = isnull(@Importe, Importe),
	--		IdMedio = isnull(@IdMedio, IdMedio),
	--		Cuenta_O_Medio = isnull(@Cuenta_O_Medio, Cuenta_O_Medio),
	--		Nuevo = isnull(@Nuevo, Nuevo)
	--	WHERE IdRegistroInformacion = @IdRegistroInformacion
	--			AND Fecha = @Fecha
	--			AND Importe = @Importe
	--			AND IdMedio = @IdMedio
	--			AND Cuenta_O_Medio = @Cuenta_O_Medio
	--			AND Nuevo = @Nuevo
	--END
	ELSE
	BEGIN
		INSERT INTO Pagos(IdRegistroInformacion, Fecha, Importe,IdMedio, Cuenta_O_Medio, Nuevo, IdEstadoCobroPago)
			VALUES(	@IdRegistroInformacion, @Fecha, @Importe,@IdMedio, @Cuenta_O_Medio, @Nuevo, @IdEstadoCobroPago)																	
	END
END
