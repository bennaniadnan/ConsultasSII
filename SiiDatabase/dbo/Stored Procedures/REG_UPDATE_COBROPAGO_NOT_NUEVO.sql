CREATE PROCEDURE [dbo].[REG_UPDATE_COBROPAGO_NOT_NUEVO]
(
	@IdLibroRegistro varchar(2)
)
AS
BEGIN
	IF(@IdLibroRegistro = 'CO')
	BEGIN
		UPDATE c
			SET c.Nuevo = 0
		FROM Cobros c join RegistroInformacion ri
			on ri.Id = c.IdRegistroInformacion
			WHERE ri.IdLibroRegistro = 'FE'
	END
	ELSE IF(@IdLibroRegistro = 'PA')
	BEGIN
		UPDATE p
			SET p.Nuevo = 0
		FROM Pagos p join RegistroInformacion ri
			on ri.Id = p.IdRegistroInformacion
			WHERE ri.IdLibroRegistro = 'FR'
	END
END

