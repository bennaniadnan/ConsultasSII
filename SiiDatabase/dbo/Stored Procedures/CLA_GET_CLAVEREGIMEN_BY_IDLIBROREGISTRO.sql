CREATE PROCEDURE [dbo].[CLA_GET_CLAVEREGIMEN_BY_IDLIBROREGISTRO]
	@IdLibroRegistro varchar(2),
	@IdAgencia varchar(10)
AS
BEGIN
	SELECT Id, Descripcion, IdLibroRegistro, IdAgencia FROM [dbo].ClaveRegimen
		WHERE Descripcion IS NOT NULL
		AND IdAgencia = @IdAgencia
		AND IdLibroRegistro = @IdLibroRegistro
END

