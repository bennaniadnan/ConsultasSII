CREATE PROCEDURE [dbo].[LRG_INSERT_OR_UPDATE_LIBRO_REGISTRO]
(
	@Id varchar(2) = null ,
	@Descripcion varchar(30),
	@Orden int
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from LibroRegistro where Id = @Id))
begin 
update LibroRegistro
set Descripcion = @Descripcion,
	Orden = @Orden
where Id = @Id
end  
ELSE
begin 
INSERT INTO LibroRegistro (Id, Descripcion, Orden)
	VALUES (@Id, @Descripcion, @Orden)
END
End





