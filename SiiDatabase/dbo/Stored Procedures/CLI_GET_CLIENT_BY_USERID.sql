
CREATE PROCEDURE [dbo].[CLI_GET_CLIENT_BY_USERID] 
( 
	@UserId varchar(6)
)
AS
BEGIN
	SELECT C.* FROM Cliente C with(nolock)
		JOIN Usuario U with(nolock)
			ON U.IdCliente = C.Id
		WHERE U.UserId = @UserId
END
