CREATE  PROCEDURE [dbo].[LRG_GET_LIBROREGISTRO] 
AS
BEGIN
	SELECT [Id]
      ,[Descripcion]
      ,[Orden]
  FROM [LibroRegistro]with(nolock)				
END





