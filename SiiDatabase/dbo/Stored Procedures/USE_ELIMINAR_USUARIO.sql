CREATE PROCEDURE [dbo].[USE_ELIMINAR_USUARIO]
	@idUsuario varchar(6)
AS
	DELETE [Usuario] WHERE UserId = @idUsuario