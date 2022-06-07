-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CLT_INSERT_OR_UPDATE_CLIENTE] (
	-- Add the parameters for the stored procedure here
	@Id int = null,
	@Nif varchar(9),
	@NombreCliente varchar(100),
	@Dirrection1 varchar(100),
	@Dirrection2 varchar(100),
	@CodigoPostal int,
	@Poblacion varchar(100),
	@Telefono varchar(20),
	@EstadoCliente int
)
AS
BEGIN
if (@Id is not null and (exists(select 1 from [dbo].Cliente where Id=@Id))) 
begin
update Cliente
	set Nif = @Nif,
		NombreCliente = @NombreCliente,
		Dirrection1 = @Dirrection1,
		Dirrection2 = @Dirrection2,
		CodigoPostal = @CodigoPostal,
		Poblacion = @Poblacion,
		Telefono = @Telefono,
		EstadoCliente = @EstadoCliente
	where Id=@Id
end
else
BEGIN
INSERT INTO Cliente(NIF, NombreCliente, Dirrection1, Dirrection2,
					CodigoPostal, Poblacion, Telefono, EstadoCliente)
			VALUES (@NIF, @NombreCliente, @Dirrection1, @Dirrection2,
					@CodigoPostal, @Poblacion, @Telefono, @EstadoCliente)
END
END





