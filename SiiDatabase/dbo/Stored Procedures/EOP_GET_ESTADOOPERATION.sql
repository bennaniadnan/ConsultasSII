CREATE  PROCEDURE [dbo].[EOP_GET_ESTADOOPERATION] 
AS
BEGIN
	SELECT [Id]
      ,[Descripcion]
      ,[Orden]
  FROM [EstadoOperacion] with(nolock)				
END





