

CREATE PROCEDURE [dbo].[ESR_GET_ESTADO_REGISTRO_BY_DESCRIPCION] (
	@Descripcion varchar(30)
)
AS
BEGIN
SELECT [Id]
      ,[Descripcion]
      ,[Orden]
  FROM [dbo].[EstadoRegistro] with (nolock)
  where @Descripcion = Descripcion
				
END




