CREATE PROCEDURE [dbo].[MED_GET_MEDIO]
AS
BEGIN
	SELECT [Id]
      ,[Descripcion]
  FROM [Medio] with(nolock)				
END

