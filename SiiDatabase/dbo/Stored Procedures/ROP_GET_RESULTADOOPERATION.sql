CREATE  PROCEDURE [dbo].[ROP_GET_RESULTADOOPERATION] 
AS
BEGIN
	SELECT [Id]
      ,[Descripcion]
      ,[Orden]
  FROM [ResultadoOperacion] with(nolock)				
END





