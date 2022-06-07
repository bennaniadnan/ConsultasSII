CREATE PROCEDURE [dbo].[REG_UPDATE_REGISTRO_INFORMACION_ESTADO] (
	
	@IdRegistroInformacion int,
	@IdEstadoRegistro int
	)
AS
BEGIN
UPDATE RegistroInformacion
	SET IdEstadoRegistro = @IdEstadoRegistro
	WHERE Id = @IdRegistroInformacion

END



