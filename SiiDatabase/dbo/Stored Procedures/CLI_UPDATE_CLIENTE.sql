CREATE PROCEDURE [dbo].[CLI_UPDATE_CLIENTE]
	@Id            INT,
	@Nif           VARCHAR (9),
	@NombreCliente varchar(100),
	@Dirrection1   VARCHAR (100),
	@Dirrection2   VARCHAR (100),
	@CodigoPostal  varchar(50),
	@Poblacion     VARCHAR (100),
	@Telefono      VARCHAR (20),
	@EstadoCliente INT          

AS
	UPDATE [Cliente] SET NombreCliente = @NombreCliente, Dirrection1 = @Dirrection1, Dirrection2 = @Dirrection2,
	CodigoPostal = @CodigoPostal, Poblacion = @Poblacion, Telefono = @Telefono WHERE Id = @Id
