CREATE PROCEDURE [dbo].[REG_UPDATE_REGISTROINFORMACION]
(
	@Id INT,
	@NifFacturaEmisor varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60) = null,
	@FechaExpedicionFacturaEmisor date = null,
	@NumSerieFacturaEmisorResumenFin varchar(60),
	@TipoFactura varchar(2),
	@NombreRazon varchar(120),
	@NifContraparte varchar(20),
	@CodigoPaisContraparte varchar(2),
	@IDTypeContraparte varchar(2),
	@IDContraparte varchar(20),
	@CodigoPaisIdFactura varchar(2),
	@IdTypeIdFactura varchar(2),
	@IDIdFactura varchar(20),
	@BaseRectificada decimal(15,2),
	@CuotaRectificada decimal(15,2),
	@CuotaRecargoRectificada decimal(15,2),
	@TipoRectificativa varchar(2),
	@FechaExpedicionFactura date,
	@FechaOperacion date,
	@ImporteTotal decimal(15,2),
	@ClaveRegimenEspecialOTrascendencia varchar(2),
	@BaseImponibleACoste decimal(15,2),
	@DescripcionOperacion varchar(500),
	@SituacionInmueble int,
	@ReferenciaCatastral varchar(25),
	@CausaExencion varchar(2),
	@BaseImponible decimal(15,2),
	@TipoNoExenta varchar(2),
	@TipoNoSujeta varchar(2),
	@ImportePorArticulos7_14_Otros decimal(15,2),
	@ImporteTAIReglasLocalizacion decimal(15,2),
	@ImporteTransmisionSujetoAIVA decimal(15,2),
	@EmitidaPorTerceros varchar(1),
	@NumeroDUA varchar(40),
	@FechaRegContableDUA date,
	@FechaRegContable date,
	@CuotaDeducible decimal(15,2),
	@TipoOperacion varchar(1),
	@ClaveDeclarado varchar(1),
	@EstadoMiembro varchar(2),
	@PlazoOperacion int,
	@DescripcionBienes varchar(120),
	@DireccionOperador varchar(150),
	@FacturasODocumentacion varchar(150),
	@ProrrataAnualDefinitiva varchar(5),
	@RegularizacionAnualDeduccion decimal(15,2),
	@IdentificacionEntrega varchar(40),
	@RegularizacionDeduccionEfectuada decimal(15,2),
	@FechaInicioUtilizacion date,
	@IdentificacionBien varchar(40),
	@IdEstadoLectura int,
	@Cupon varchar(1),
	@VariosDestinatarios varchar(20),
	@NombreContraparte varchar(120),
	@TipoDesglose int,
	@DesgloseTipoOperacion int,
	@FechaFinPlazo date = null,
	@ADeducirEnPeriodoPosterior varchar(1) = null,
	@EjercicioDeduccion int = null,
	@PeriodoDeduccion varchar(2) = null
)
AS
BEGIN
DECLARE @T Table (Id int)
UPDATE [dbo].[RegistroInformacion]
   SET [NifFacturaEmisor] = isnull(@NifFacturaEmisor, [NifFacturaEmisor]) 
	  ,[NumSerieFacturaEmisor] = isnull(@NumSerieFacturaEmisor, [NumSerieFacturaEmisor])
	  ,[FechaExpedicionFacturaEmisor] = isnull(@FechaExpedicionFacturaEmisor, [FechaExpedicionFacturaEmisor])
	  ,[NumSerieFacturaEmisorResumenFin] = @NumSerieFacturaEmisorResumenFin
      ,[TipoFactura] = @TipoFactura
      ,[NombreRazon] = @NombreRazon
      ,[NifContraparte] = @NifContraparte
      ,[CodigoPaisContraparte] = @CodigoPaisContraparte
      ,[IDTypeContraparte] = @IDTypeContraparte
      ,[IDContraparte] = @IDContraparte
      ,[CodigoPaisIdFactura] = @CodigoPaisIdFactura
      ,[IDTypeIdFactura] = @IDTypeIdFactura
      ,[IDIdFactura] = @IDIdFactura
      ,[BaseRectificada] = @BaseRectificada
      ,[CuotaRectificada] = @CuotaRectificada
      ,[CuotaRecargoRectificada] = @CuotaRecargoRectificada
      ,[TipoRectificativa] = @TipoRectificativa
      ,[FechaExpedicionFactura] = @FechaExpedicionFactura
      ,[FechaOperacion] = @FechaOperacion
      ,[ImporteTotal] = @ImporteTotal
      ,[ClaveRegimenEspecialOTrascendencia] = @ClaveRegimenEspecialOTrascendencia
      ,[BaseImponibleACoste] = @BaseImponibleACoste
      ,[DescripcionOperacion] = @DescripcionOperacion
      ,[SituacionInmueble] = @SituacionInmueble
      ,[ReferenciaCatastral] = @ReferenciaCatastral
      ,[TipoNoSujeta] = @TipoNoSujeta
      ,[ImporteTransmisionSujetoAIVA] = @ImporteTransmisionSujetoAIVA
      ,[EmitidaPorTerceros] = @EmitidaPorTerceros
      ,[NumeroDUA] = @NumeroDUA
      ,[FechaRegContableDUA] = @FechaRegContableDUA
      ,[FechaRegContable] = @FechaRegContable
      ,[CuotaDeducible] = @CuotaDeducible
      ,[TipoOperacion] = @TipoOperacion
      ,[ClaveDeclarado] = @ClaveDeclarado
      ,[EstadoMiembro] = @EstadoMiembro
      ,[PlazoOperacion] = @PlazoOperacion
      ,[DescripcionBienes] = @DescripcionBienes
      ,[DireccionOperador] = @DireccionOperador
      ,[FacturasODocumentacion] = @FacturasODocumentacion
      ,[ProrrataAnualDefinitiva] = @ProrrataAnualDefinitiva
      ,[RegularizacionAnualDeduccion] = @RegularizacionAnualDeduccion
      ,[IdentificacionEntrega] = @IdentificacionEntrega
      ,[RegularizacionDeduccionEfectuada] = @RegularizacionDeduccionEfectuada
      ,[FechaInicioUtilizacion] = @FechaInicioUtilizacion
      ,[IdentificacionBien] = @IdentificacionBien
      ,[IdEstadoLectura] = @IdEstadoLectura
      ,[Cupon] = @Cupon
      ,[VariosDestinatarios] = @VariosDestinatarios
      ,[NombreContraparte] = @NombreContraparte
      ,[CausaExencion] = @CausaExencion
      ,[BaseImponible] = @BaseImponible
      ,[TipoNoExenta] = @TipoNoExenta
      ,[ImportePorArticulos7_14_Otros] = @ImportePorArticulos7_14_Otros
      ,[ImporteTAIReglasLocalizacion] = @ImporteTAIReglasLocalizacion
      ,[TipoDesglose] = @TipoDesglose
      ,[DesgloseTipoOperacion] = @DesgloseTipoOperacion
      ,[FechaFinPlazo] = ISNULL(@FechaFinPlazo, [FechaFinPlazo])
	  ,[ADeducirEnPeriodoPosterior] = ISNULL(@ADeducirEnPeriodoPosterior, [ADeducirEnPeriodoPosterior])
	  ,[EjercicioDeduccion] = ISNULL(@EjercicioDeduccion, [EjercicioDeduccion])
	  ,[PeriodoDeduccion] = ISNULL(@PeriodoDeduccion, [PeriodoDeduccion])
	  OUTPUT inserted.id
	  INTO @T
 WHERE [Id] = @Id
 SELECT * FROM @T

END

