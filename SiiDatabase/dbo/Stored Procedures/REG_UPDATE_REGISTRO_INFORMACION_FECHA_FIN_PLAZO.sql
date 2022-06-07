CREATE PROCEDURE [dbo].[REG_UPDATE_REGISTRO_INFORMACION_FECHA_FIN_PLAZO]
	@IdRegistro int,
    @FechaFinPlazo date
AS
	Update [RegistroInformacion] SET FechaFinPlazo = @FechaFinPlazo
	WHERE Id = @IdRegistro