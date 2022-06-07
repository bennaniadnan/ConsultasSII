CREATE PROCEDURE [dbo].[ESO_INSERT_OR_UPDATE_ESTADO_OPERACION]
(
	@Id int = null ,
	@Descripcion varchar(30),
	@Orden int
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from EstadoOperacion where Id = @Id))
begin 
update EstadoOperacion
set Descripcion = @Descripcion,
	Orden = @Orden
where Id = @Id
end  
ELSE
begin 
INSERT INTO EstadoOperacion (Id, Descripcion, Orden)
	VALUES (@Id, @Descripcion, @Orden)
END
End





