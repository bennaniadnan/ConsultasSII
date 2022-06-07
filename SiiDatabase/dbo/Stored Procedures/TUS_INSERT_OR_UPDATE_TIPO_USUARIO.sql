CREATE PROCEDURE [dbo].[TUS_INSERT_OR_UPDATE_TIPO_USUARIO] (
	@Id int = null,
	@Descripcion varchar(50)
)
AS
BEGIN
IF (@Id is not null and (exists(select 1 from TipoUsuario where @Id = Id)))
BEGIN
update TipoUsuario
set Descripcion = @Descripcion
where id=@Id
END
ELSE
BEGIN
INSERT INTO TipoUsuario (Id, Descripcion)
VALUES(@Id, @Descripcion)
END
END





