
CREATE PROCEDURE [dbo].[CLI_GET_CLIENT_BY_NIF] (
	@Nif varchar(9)
)
AS
BEGIN
SELECT [Id]
      ,[Nif]
      ,[NombreCliente]
      ,[Dirrection1]
      ,[Dirrection2]
      ,[CodigoPostal]
      ,[Poblacion]
      ,[Telefono]
      ,[EstadoCliente]
  FROM [dbo].[Cliente] with (nolock)
  where @Nif = [Nif] and [EstadoCliente]= 1
				
END



