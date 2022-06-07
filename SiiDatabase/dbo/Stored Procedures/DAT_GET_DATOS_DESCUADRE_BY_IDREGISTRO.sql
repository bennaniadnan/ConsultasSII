
CREATE PROCEDURE [dbo].[DAT_GET_DATOS_DESCUADRE_BY_IDREGISTRO]
	@IdRegistroInformacion int
AS
BEGIN
	SELECT * FROM [dbo].[DatosDescuadreContraparte] WITH(NOLOCK) WHERE [IdRegistroInformacion] = @IdRegistroInformacion;
END
