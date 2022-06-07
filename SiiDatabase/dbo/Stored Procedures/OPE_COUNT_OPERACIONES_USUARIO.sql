CREATE PROCEDURE [dbo].[OPE_COUNT_OPERACIONES_USUARIO]
	@idUsuario varchar(6)
AS
	SELECT COUNT(1) FROM [Operacion] where IdUsuario = @idUsuario
