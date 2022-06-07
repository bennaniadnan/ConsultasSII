CREATE PROCEDURE [dbo].[TOP_INSERT_OR_UPDATE_TIPO_OPERACION] (
	@Id varchar(2) = null,
	@Denominacion VARCHAR(100),
	@EstructuraXML VARCHAR(100),
	@ClaseOperacion INT
)
AS
BEGIN
IF (@Id is not null and (exists(select 1 from TipoOperacion where @Id = Id)))
BEGIN
update TipoOperacion
set Denominacion = @Denominacion,
	EstructuraXML = @EstructuraXML,
	ClaseOperacion = @ClaseOperacion
WHERE @Id = Id
END
ELSE
BEGIN
INSERT INTO TipoOperacion (Id, Denominacion, EstructuraXML, ClaseOperacion)
	VALUES(@Id, @Denominacion, @EstructuraXML, @ClaseOperacion)
END
END





