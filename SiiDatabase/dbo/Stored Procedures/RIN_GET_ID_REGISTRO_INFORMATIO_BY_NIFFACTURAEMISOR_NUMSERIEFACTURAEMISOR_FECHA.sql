
CREATE PROCEDURE [dbo].[RIN_GET_ID_REGISTRO_INFORMATIO_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA]
(
	@NifFacturaEmisor varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60),
	@IdFactura varchar(20) = null,
	@FechaExpedicionFacturaEmisor date
)
AS
BEGIN
SELECT TOP(1) [Id]
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
      ,[CodigoPaisContraparte]
      ,[IDTypeContraparte]
      ,[IDContraparte]
      ,[CodigoPaisIdFactura]
      ,[IDTypeIdFactura]
      ,[IDIdFactura]
      ,[BaseRectificada]
      ,[CuotaRectificada]
      ,[CuotaRecargoRectificada]
      ,[TipoRectificativa]
      ,[FechaExpedicionFactura]
      ,[FechaOperacion]
      ,[ImporteTotal]
      ,[ClaveRegimenEspecialOTrascendencia]
      ,[BaseImponibleACoste]
      ,[DescripcionOperacion]
      ,[SituacionInmueble]
      ,[ReferenciaCatastral]
      ,[CausaExencion]
      ,[BaseImponible]
      ,[TipoNoExenta]
      ,[TipoNoSujeta]
      ,[ImportePorArticulos7_14_Otros]
      ,[ImporteTAIReglasLocalizacion]
      ,[ImporteTransmisionSujetoAIVA]
      ,[EmitidaPorTerceros]
      ,[NumeroDUA]
      ,[FechaRegContableDUA]
      ,[FechaRegContable]
      ,[CuotaDeducible]
      ,[TipoOperacion]
      ,[ClaveDeclarado]
      ,[EstadoMiembro]
      ,[PlazoOperacion]
      ,[DescripcionBienes]
      ,[DireccionOperador]
      ,[FacturasODocumentacion]
      ,[ProrrataAnualDefinitiva]
      ,[RegularizacionAnualDeduccion]
      ,[IdentificacionEntrega]
      ,[RegularizacionDeduccionEfectuada]
      ,[FechaInicioUtilizacion]
      ,[IdentificacionBien]
      ,[Baja]
      ,[FechaBaja]
      ,[IdEstadoLectura]
      ,[Cupon]
      ,[VariosDestinatarios]
      ,[NombreContraparte]
      ,[IdEstadoRegistro]
      ,[Ejercicio]
      ,[Periodo]
      ,[FechaFinPlazo]
      ,[ADeducirEnPeriodoPosterior]
      ,[EjercicioDeduccion]
      ,[PeriodoDeduccion]
	  ,DC.ClaveRegimen1
	  ,DC.ClaveRegimen2
	  ,DC.Autorizacion
	  ,DC.RefExterna
	  ,DC.SimplificadaArt
	  ,DC.NombreSucedida
	  ,DC.NifSucedida
	  ,DC.RegPrevio
	  ,DC.Macrodato
	  ,DC.FacturaEnergia
	  ,DC.SinDestinatario
	  ,RIGIC.PagoAnticipado
	  ,RIGIC.IdTipoBienOperacion
	  ,RIGIC.IdTipoDocumentoArt25
	  ,RIGIC.NumeroProtocolo
	  ,RIGIC.NombreNotario
  FROM [dbo].[RegistroInformacion] RI with (nolock)
  LEFT JOIN [dbo].[DatosComplementarios] DC  with (nolock)
	ON DC.IdRegistroInformacion = RI.Id
  LEFT JOIN [dbo].[RegistroInformacion_IGIC] RIGIC  with (nolock)
	ON RIGIC.IdRegistroInformacion = RI.Id
  where isnull(NifFacturaEmisor,'') = isNULL(@NifFacturaEmisor,isnull(NifFacturaEmisor,'')) 
		AND @NumSerieFacturaEmisor= NumSerieFacturaEmisor
		AND isnull(IDIdFactura,'') = isNULL(@IdFactura,isnull(IDIdFactura,''))
		AND @FechaExpedicionFacturaEmisor = FechaExpedicionFacturaEmisor	
	order by Id desc
END

