CREATE PROCEDURE [dbo].[DET_GET_DETALLE_INMUEBLE](
	@IdRegistroInformacion int = 0
)
AS
BEGIN
	SELECT * from DetalleInmueble WHERE IdRegistroInformacion = @IdRegistroInformacion
END

