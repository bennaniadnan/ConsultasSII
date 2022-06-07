CREATE PROCEDURE [dbo].[TOP_GET_TIPOOPERATION] 
AS
BEGIN
	SELECT [Id]
      ,[Denominacion]
      ,[EstructuraXML]
      ,[ClaseOperacion]
  FROM [TipoOperacion] with(nolock)				
END





