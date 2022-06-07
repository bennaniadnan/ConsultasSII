CREATE PROCEDURE [dbo].[REG_UPDATE_ESTADO_CUADRE] --'VF E ** 002804', '2018-06-21', 'B20951380', null, 1
(
	@NumSerieFacturaEmisor varchar(60),
	@FechaExpedicionFacturaEmisor date,
	@NifFacturaEmisor varchar(20) = null ,
	@IDIdFactura varchar(20) = null ,
	@IdEstadoCuadre int
)
AS
BEGIN	 
	DECLARE @T Table (Id int) 
	update RegistroInformacion
	set IdEstadoCuadre = @IdEstadoCuadre
	OUTPUT inserted.id
	INTO @T
	where NumSerieFacturaEmisor= @NumSerieFacturaEmisor
		AND FechaExpedicionFacturaEmisor = @FechaExpedicionFacturaEmisor
		AND isnull(NifFacturaEmisor,'') = isNULL(@NifFacturaEmisor,isnull(NifFacturaEmisor,'')) 
		AND isnull(IDIdFactura,'') = isNULL(@IDIdFactura,isnull(IDIdFactura,''))
	
	SELECT * FROM @T
End

