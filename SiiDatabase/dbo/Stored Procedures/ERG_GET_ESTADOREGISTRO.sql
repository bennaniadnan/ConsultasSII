


CREATE PROCEDURE [dbo].[ERG_GET_ESTADOREGISTRO] 
AS
BEGIN
	SELECT [id]
      ,[Descripcion]
      ,[Orden]
  FROM [dbo].[EstadoRegistro] with(nolock)				
END



