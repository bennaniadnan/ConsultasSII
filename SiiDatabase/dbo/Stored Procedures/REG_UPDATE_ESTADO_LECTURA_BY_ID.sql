CREATE PROCEDURE [dbo].[REG_UPDATE_ESTADO_LECTURA_BY_ID]
(
	@IdRegistroInformacion int,
	@IdEstadoLectura int
)
AS
BEGIN

UPDATE RegistroInformacion
SET IdEstadoLectura = @IdEstadoLectura
WHERE Id = @IdRegistroInformacion

END



