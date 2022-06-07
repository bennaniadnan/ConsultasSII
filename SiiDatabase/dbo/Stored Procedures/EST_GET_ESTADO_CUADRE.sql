
CREATE PROCEDURE [dbo].[EST_GET_ESTADO_CUADRE]
AS
BEGIN
	select * from EstadoCuadre with(nolock)
END
