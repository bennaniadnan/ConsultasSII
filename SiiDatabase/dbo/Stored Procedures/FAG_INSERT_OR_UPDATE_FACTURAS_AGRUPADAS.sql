CREATE PROCEDURE [dbo].[FAG_INSERT_OR_UPDATE_FACTURAS_AGRUPADAS]
(
	@Id int = null,
	@IdRegistroInformacion int,
	@NumSerieFacturaEmisor varchar(60),
	@FechaExpedicionFacturaEmisor Date
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from FacturasAgrupadas where @Id = Id))
begin 
update FacturasAgrupadas
set IdRegistroInformacion = @IdRegistroInformacion,
	NumSerieFacturaEmisor = @NumSerieFacturaEmisor,
	FechaExpedicionFacturaEmisor = @FechaExpedicionFacturaEmisor
where Id = @Id
end  
ELSE
begin 
INSERT INTO FacturasAgrupadas(IdRegistroInformacion, NumSerieFacturaEmisor, FechaExpedicionFacturaEmisor)
	VALUES (@IdRegistroInformacion, @NumSerieFacturaEmisor, @FechaExpedicionFacturaEmisor)
END
End





