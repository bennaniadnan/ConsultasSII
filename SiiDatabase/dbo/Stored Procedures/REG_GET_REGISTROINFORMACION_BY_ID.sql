
CREATE PROCEDURE  [dbo].[REG_GET_REGISTROINFORMACION_BY_ID](
	@IdRegistroInformacion int
	,@IdOperacion int
)
AS
BEGIN
	IF (@IdOperacion = 0)
	BEGIN
		SELECT RI.[Id]
			  ,RI.[IdLibroRegistro]
			  ,[NifDeclarante]
			  ,[NifFacturaEmisor]
			  ,[NumSerieFacturaEmisor]
			  ,[NumSerieFacturaEmisorResumenFin]
			  ,[FechaExpedicionFacturaEmisor]
			  ,[FechaFinPlazo]
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
			  ,RI.[FechaOperacion]
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
			  ,RI.[Ejercicio]
			  ,RI.Periodo
			  ,[FechaInicioUtilizacion]
			  ,[IdentificacionBien]
			  ,[Baja]
			  ,[FechaBaja]
			  ,[IdEstadoLectura]
			  ,[Cupon]
			  ,[VariosDestinatarios]
			  ,[NombreContraparte]
			  ,[TipoDesglose]
			  ,[DesgloseTipoOperacion]
			  ,RI.IdEstadoRegistro
			  ,RI.IdEstadoCuadre
			  ,RI.ADeducirEnPeriodoPosterior
			  ,RI.EjercicioDeduccion
			  ,RI.PeriodoDeduccion
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
  
		  where @IdRegistroInformacion = RI.Id
	END
	ELSE
	BEGIN
		SELECT RI.[Id]
			  ,RI.[IdLibroRegistro]
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
			  ,RI.[FechaOperacion]
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
			  ,RI.[Ejercicio]
			  ,RI.Periodo
			  ,[FechaInicioUtilizacion]
			  ,[IdentificacionBien]
			  ,[Baja]
			  ,[FechaBaja]
			  ,[IdEstadoLectura]
			  ,[Cupon]
			  ,[VariosDestinatarios]
			  ,[NombreContraparte]
			  ,[TipoDesglose]
			  ,[DesgloseTipoOperacion]
			  ,RI.IdEstadoRegistro
			  ,RI.IdEstadoCuadre
			  ,ER.Descripcion
			  ,RO.CodigoErrorRegistro
			  ,RO.DescripcionErrorRegistro
			  ,op.CSV
			  ,RI.ADeducirEnPeriodoPosterior
			  ,RI.EjercicioDeduccion
			  ,RI.PeriodoDeduccion
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
		  Left join dbo.RegistrosOperacion RO with (nolock)
		  inner join dbo.Operacion op with (nolock) on op.Id = RO.IdOperacion
		  ON RI.Id = RO.IdRegistroInformacion
		  LEFT JOIN [dbo].[DatosComplementarios] DC  with (nolock)
			ON DC.IdRegistroInformacion = RI.Id
		  LEFT JOIN [dbo].[RegistroInformacion_IGIC] RIGIC  with (nolock)
			ON RIGIC.IdRegistroInformacion = RI.Id
		  Join dbo.EstadoRegistro ER with (nolock)
		  ON ER.Id = RO.IdEstadoRegistro
  
		  where @IdRegistroInformacion = RI.Id and @IdOperacion = RO.IdOperacion
	END
END

