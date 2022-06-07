
CREATE PROCEDURE [dbo].[IDT_GET_IDTYPE](
	@IdAgencia varchar(10)	
)
AS
BEGIN
	IF (@IdAgencia = 'ATC')
	BEGIN
		SELECT Id, Descripcion FROM dbo.TipoDocumento where Id <> '02'
	END
	ELSE
	BEGIN
		SELECT Id, Descripcion FROM dbo.TipoDocumento
	END
END

