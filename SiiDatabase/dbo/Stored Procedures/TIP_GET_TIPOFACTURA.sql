
CREATE PROCEDURE [dbo].[TIP_GET_TIPOFACTURA](
	@IdAgencia varchar(10)
)
	
AS
BEGIN
	IF (@IdAgencia = 'ATC')
	BEGIN
		SELECT Id, Descripcion, Orden, IdAgencia FROM TipoFactura
	END
	ELSE
	BEGIN
		SELECT Id, Descripcion, Orden, IdAgencia FROM TipoFactura where IdAgencia <> 'ATC'
	END

END

