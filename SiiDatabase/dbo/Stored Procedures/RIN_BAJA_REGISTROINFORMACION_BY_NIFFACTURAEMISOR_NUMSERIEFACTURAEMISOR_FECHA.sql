
CREATE PROCEDURE [dbo].[RIN_BAJA_REGISTROINFORMACION_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA] (
	@NifFacturaEmisor varchar(20) = null,
	@IdFactura varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60),
	@FechaExpedicionFacturaEmisor date
)
AS
BEGIN  
DECLARE @T Table (Id int) 
UPDATE RegistroInformacion
SET Baja = 'true',
	FechaBaja = GETDATE()
	OUTPUT inserted.Id
	INTO @T
  where isnull(NifFacturaEmisor,'') = isNULL(@NifFacturaEmisor,isnull(NifFacturaEmisor,'')) 
		AND @NumSerieFacturaEmisor= NumSerieFacturaEmisor
		AND isnull(IDIdFactura,'') = isNULL(@IdFactura,isnull(IDIdFactura,''))
	    AND cast(FechaExpedicionFacturaEmisor as date) = cast(@FechaExpedicionFacturaEmisor as date)
	  
	  SELECT top(1) * FROM @T
END

