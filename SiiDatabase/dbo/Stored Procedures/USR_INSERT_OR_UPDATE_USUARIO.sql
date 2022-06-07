CREATE PROCEDURE [dbo].[USR_INSERT_OR_UPDATE_USUARIO] (
	@Id varchar(128) = null,
	@IdCliente int,
	@Email varchar(100),
	@Nombre varchar(25),
	@Apellidos varchar(50),
	@TelUsuario varchar(20),
	@TipoUsuario int,
	@EstadoUsuario int,
	@UserName varchar(50),
	@UserId varchar(6)
)
AS
BEGIN
IF (exists(select 1 from Usuario where @Id = Id))
BEGIN
	update Usuario
	set Email = @Email,
		Apellidos = @Apellidos,
		Nombre = @Nombre,
		UserId = ISNULL(NULLIF(@UserId,''), UserId),
		UserName = ISNULL(NULLIF(@UserName,''), UserName),
		TelUsuario = @TelUsuario,
		TipoUsuario = @TipoUsuario,
		EstadoUsuario = @EstadoUsuario
		WHERE Id = @Id
END
ELSE
BEGIN
	INSERT INTO Usuario (Id, UserId, UserName, IdCliente, Email, Nombre, Apellidos, TelUsuario, TipoUsuario, EstadoUsuario)
	VALUES(@Id, @UserId, @UserName, @IdCliente, @Email, @Nombre, @Apellidos, @TelUsuario, @TipoUsuario, @EstadoUsuario)
END
END
