
CREATE PROCEDURE [dbo].[REG_GET_REGISTROS_INFORMATIO_BY_EJERCICIO]
(
	@Ejercicio int,
    @SiFechPlazoNonNull bit = 0
)
AS
BEGIN
SELECT [Id]
      ,[IdLibroRegistro]
      ,[NifDeclarante]
      ,[NifFacturaEmisor]
      ,[NumSerieFacturaEmisor]
      ,[NumSerieFacturaEmisorResumenFin]
      ,[FechaExpedicionFacturaEmisor]
      ,[TipoFactura]
      ,[NombreRazon]
      ,[NIFRepresentante]
      ,[NifContraparte]
      ,[IDIdFactura]
      ,[FechaExpedicionFactura]
      ,[FechaOperacion]
      ,[ImporteTotal]
      ,[ClaveRegimenEspecialOTrascendencia]
      ,[EmitidaPorTerceros]
      ,[FechaRegContable]
      ,[IdEstadoLectura]
      ,[IdEstadoRegistro]
      ,[Ejercicio]
      ,[Periodo]
      ,[FechaFinPlazo]
  FROM [dbo].[RegistroInformacion] RI with (nolock)
  where RI.Ejercicio = @Ejercicio
  AND RI.IdEstadoRegistro in(1,2) AND (@SiFechPlazoNonNull = 1 OR RI.FechaFinPlazo IS NULL)
END

