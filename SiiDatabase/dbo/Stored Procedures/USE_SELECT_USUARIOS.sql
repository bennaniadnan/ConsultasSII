CREATE PROCEDURE [dbo].[USE_SELECT_USUARIOS]
	@IdUsuario varchar(6)
AS
	SELECT U.* FROM [Usuario] U
	WHERE UserId = ISNULL(@IdUsuario, UserId)