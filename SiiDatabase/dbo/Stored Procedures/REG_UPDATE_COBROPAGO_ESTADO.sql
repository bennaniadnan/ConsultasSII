CREATE PROCEDURE [dbo].[REG_UPDATE_COBROPAGO_ESTADO]
	@Id int,
	@IdLibroRegistro varchar(2),
	@Estado int
AS
BEGIN
	IF (@IdLibroRegistro in ('FE', 'FA', 'CO', 'CE'))
	BEGIN
		UPDATE Cobros SET
			IdEstadoCobroPago = @Estado
		WHERE Id = @Id
	END
	ELSE IF (@IdLibroRegistro in ('FR', 'PA', 'PR'))
	BEGIN
		UPDATE Pagos SET
			IdEstadoCobroPago = @Estado
		WHERE Id = @Id
	END
END
