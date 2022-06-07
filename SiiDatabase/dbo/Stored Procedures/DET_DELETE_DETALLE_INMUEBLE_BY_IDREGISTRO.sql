CREATE PROCEDURE [dbo].[DET_DELETE_DETALLE_INMUEBLE_BY_IDREGISTRO]
	@IdRegistroInformacion int
AS
BEGIN
	DELETE FROM [dbo].[DetalleInmueble]
      WHERE IdRegistroInformacion = @IdRegistroInformacion
END

