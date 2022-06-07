CREATE PROCEDURE [dbo].[FRC_INSERT_OR_UPDATE_FACTURAS_RECTIFICADAS]
(
	@Id int = null,
	@IdRegistroInformacion int,
	@NumSerieFacturaEmisor varchar(60),
	@FechaExpedicionFacturaEmisor Date
)
AS
BEGIN	
if @Id is not null and (exists(select 1 from FacturasRectificadas where @Id = Id))
begin 
update FacturasRectificadas
set IdRegistroInformacion = @IdRegistroInformacion,
	NumSerieFacturaEmisor = @NumSerieFacturaEmisor,
	FechaExpedicionFacturaEmisor = @FechaExpedicionFacturaEmisor
where Id = @Id
end  
ELSE
begin 
INSERT INTO FacturasRectificadas(IdRegistroInformacion, NumSerieFacturaEmisor, FechaExpedicionFacturaEmisor)
	VALUES (@IdRegistroInformacion, @NumSerieFacturaEmisor, @FechaExpedicionFacturaEmisor)
END
End





