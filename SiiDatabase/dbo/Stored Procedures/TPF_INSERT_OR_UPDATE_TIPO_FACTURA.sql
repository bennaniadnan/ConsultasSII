CREATE PROCEDURE [dbo].[TPF_INSERT_OR_UPDATE_TIPO_FACTURA]
(
	@Id varchar(2),
	@Descripcion varchar(200),
	@Orden int
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from TipoFactura where Id = @Id))
begin 
update TipoFactura
set Descripcion = @Descripcion,
	Orden = @Orden
where Id = @Id
end  
ELSE
begin 
INSERT INTO TipoFactura (Id, Descripcion, Orden)
	VALUES (@Id, @Descripcion, @Orden)
END
End





