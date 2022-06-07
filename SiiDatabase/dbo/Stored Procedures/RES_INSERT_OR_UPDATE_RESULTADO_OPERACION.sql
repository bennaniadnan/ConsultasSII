CREATE PROCEDURE [dbo].[RES_INSERT_OR_UPDATE_RESULTADO_OPERACION]
(
	@Id int = null ,
	@Descripcion varchar(30),
	@Orden int
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from ResultadoOperacion where Id = @Id))
begin 
update ResultadoOperacion
set Descripcion = @Descripcion,
	Orden = @Orden
where Id = @Id
end  
ELSE
begin 
INSERT INTO ResultadoOperacion (Id, Descripcion, Orden)
	VALUES (@Id, @Descripcion, @Orden)
END
End





