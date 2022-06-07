CREATE PROCEDURE [dbo].[ESR_INSERT_OR_UPDATE_ESTADO_REGISTRO]
(
	@Id int = null ,
	@Descripcion varchar(30),
	@Orden int
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from EstadoRegistro where Id = @Id))
begin 
update EstadoRegistro
set Descripcion = @Descripcion,
	Orden = @Orden
where Id = @Id
end  
ELSE
begin 
INSERT INTO EstadoRegistro (Id, Descripcion, Orden)
	VALUES (@Id, @Descripcion, @Orden)
END
End





