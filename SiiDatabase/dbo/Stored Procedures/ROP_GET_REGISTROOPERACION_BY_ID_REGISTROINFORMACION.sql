CREATE PROCEDURE [dbo].[ROP_GET_REGISTROOPERACION_BY_ID_REGISTROINFORMACION] (
	@IdRegistroInformacion int
)
AS
BEGIN
SELECT Id
	  ,[IdOperacion]
	  ,[IdRegistroInformacion]
      ,[IdEstadoRegistro]
      ,[CodigoErrorRegistro]
      ,[DescripcionErrorRegistro]
  FROM [dbo].[RegistrosOperacion] with (nolock)
  where IdRegistroInformacion = @IdRegistroInformacion 
  
END





