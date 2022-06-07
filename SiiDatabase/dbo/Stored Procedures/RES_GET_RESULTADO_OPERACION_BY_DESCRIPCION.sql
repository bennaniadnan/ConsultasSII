CREATE PROCEDURE [dbo].[RES_GET_RESULTADO_OPERACION_BY_DESCRIPCION] (
	@Descripcion varchar(30)
)
AS
BEGIN
SELECT [Id]
      ,[Descripcion]
      ,[Orden]
  FROM [dbo].[ResultadoOperacion] with (nolock)
  where @Descripcion = Descripcion
				
END





