CREATE PROCEDURE [dbo].[ROP_GET_LAST_REGISTROOPERACION_BY_REGISTROINFORMACION] (
	@IdRegistroInformacion int
)
AS
BEGIN
SELECT top 1 Id,[IdOperacion]
      ,[IdRegistroInformacion]
      ,[IdEstadoRegistro]
      ,[CodigoErrorRegistro]
      ,[DescripcionErrorRegistro]
  FROM [dbo].[RegistrosOperacion] with (nolock)
  where IdRegistroInformacion = @IdRegistroInformacion 
  Order by Id desc
END





