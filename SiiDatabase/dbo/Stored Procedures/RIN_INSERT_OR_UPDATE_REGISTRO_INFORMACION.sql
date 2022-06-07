
CREATE PROCEDURE [dbo].[RIN_INSERT_OR_UPDATE_REGISTRO_INFORMACION]
(
	@Id INT = null,
	@IdLibroRegistro varchar(2),
	@NifDeclarante varchar(9),
	@NifFacturaEmisor varchar(20),
	@NumSerieFacturaEmisor varchar(60),
	@NumSerieFacturaEmisorResumenFin varchar(60),
	@FechaExpedicionFacturaEmisor date,
	@TipoFactura varchar(2),
	@NombreRazon varchar(120),
	@NIFRepresentante varchar(9),
	@NifContraparte varchar(20),
	@CodigoPaisContraparte varchar(2),--CodigoPais--------------------------
	@IDTypeContraparte varchar(2),--ClvNumIDsFclResid----------------------------
	@IDContraparte varchar(20),--NifIdResid-----------------------------
	@CodigoPaisIdFactura varchar(2),------------------------------
	@IDTypeIdFactura varchar(2),-------------------------------
	@IDIdFactura varchar(20),-------------------------------
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
	@CausaExencion varchar(2),-----------------------
	@BaseImponible decimal(15,2),------------------
	@TipoNoExenta varchar(2),--------------------
	@TipoNoSujeta varchar(2),---!!!!!!!!!!!!!!!!!!!!----------------
	@ImportePorArticulos7_14_Otros decimal(15,2),--ImpNoSujeta-------------------
	@ImporteTAIReglasLocalizacion decimal(15,2),----------------------
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
	@Ejercicio int,
	@Periodo varchar(2),
	@FechaInicioUtilizacion date,
	@IdentificacionBien varchar(40),
	@Baja bit = null,
	@FechaBaja DateTime = null,
	@IdEstadoLectura int,
	@Cupon varchar(1),
	@VariosDestinatarios varchar(20),
	@NombreContraparte varchar(120),
	@IdEstadoRegistro int,
	@TipoDesglose int,
	@DesgloseTipoOperacion int,
	@FechaFinPlazo date = null,
	@ADeducirEnPeriodoPosterior varchar(1) = null,
	@EjercicioDeduccion int = null,
	@PeriodoDeduccion varchar(2) = null
)
AS
BEGIN
IF(exists(select 1 from RegistroInformacion where 
		(ISNULL(@NifFacturaEmisor, ISNULL(@IDIdFactura, '')) = ISNULL(NifFacturaEmisor, ISNULL(IDIdFactura, '')) 
		AND @NumSerieFacturaEmisor= NumSerieFacturaEmisor
		AND @FechaExpedicionFacturaEmisor = FechaExpedicionFacturaEmisor) OR
		ISNULL(@Id, 0) = Id))
BEGIN
DECLARE @T Table (Id int)
UPDATE RegistroInformacion
SET 
	NifDeclarante = ISNULL(@NifDeclarante, NifDeclarante),
	NifFacturaEmisor = @NifFacturaEmisor,
	NumSerieFacturaEmisor = @NumSerieFacturaEmisor,
	NumSerieFacturaEmisorResumenFin = @NumSerieFacturaEmisorResumenFin,
	FechaExpedicionFacturaEmisor = @FechaExpedicionFacturaEmisor,
	TipoFactura = @TipoFactura,
	NombreRazon = @NombreRazon,
	NIFRepresentante = @NIFRepresentante,
	NifContraparte = @NifContraparte,
	CodigoPaisContraparte = @CodigoPaisContraparte,
	IDTypeContraparte = @IDTypeContraparte,
	IDContraparte = @IDContraparte,
	CodigoPaisIdFactura = @CodigoPaisIdFactura,
	IDTypeIdFactura = @IDTypeIdFactura,
	IDIdFactura = @IDIdFactura,	
	BaseRectificada = @BaseRectificada,
	CuotaRectificada = @CuotaRectificada,
	CuotaRecargoRectificada = @CuotaRecargoRectificada,
	TipoRectificativa = @TipoRectificativa,
	FechaExpedicionFactura = @FechaExpedicionFactura,
	FechaOperacion = @FechaOperacion,
	ImporteTotal = @ImporteTotal,
	ClaveRegimenEspecialOTrascendencia = @ClaveRegimenEspecialOTrascendencia,
	BaseImponibleACoste = @BaseImponibleACoste,
	DescripcionOperacion = @DescripcionOperacion,
	SituacionInmueble = @SituacionInmueble,
	ReferenciaCatastral = @ReferenciaCatastral,
	CausaExencion = @CausaExencion,
	BaseImponible = @BaseImponible,
	TipoNoExenta = @TipoNoExenta,
	TipoNoSujeta = @TipoNoSujeta,
	ImportePorArticulos7_14_Otros = @ImportePorArticulos7_14_Otros,
	ImporteTAIReglasLocalizacion = @ImporteTAIReglasLocalizacion,
	ImporteTransmisionSujetoAIVA = @ImporteTransmisionSujetoAIVA,
	EmitidaPorTerceros = @EmitidaPorTerceros,
	NumeroDUA = @NumeroDUA,
	FechaRegContableDUA = @FechaRegContableDUA,
	FechaRegContable = @FechaRegContable,
	CuotaDeducible = @CuotaDeducible,
	TipoOperacion = @TipoOperacion,
	ClaveDeclarado = @ClaveDeclarado,
	EstadoMiembro = @EstadoMiembro,
	PlazoOperacion = @PlazoOperacion,
	DescripcionBienes = @DescripcionBienes,
	DireccionOperador = @DireccionOperador,
	FacturasODocumentacion = @FacturasODocumentacion,
	ProrrataAnualDefinitiva = @ProrrataAnualDefinitiva,
	RegularizacionAnualDeduccion = @RegularizacionAnualDeduccion,
	IdentificacionEntrega = @IdentificacionEntrega,
	RegularizacionDeduccionEfectuada = @RegularizacionDeduccionEfectuada,
	Ejercicio = isnull(@Ejercicio,Ejercicio),
	Periodo = isnull(@Periodo,Periodo),
	FechaInicioUtilizacion = @FechaInicioUtilizacion,
	IdentificacionBien = @IdentificacionBien,
	Baja = @Baja,
	FechaBaja = @FechaBaja,
	IdEstadoLectura = @IdEstadoLectura,
	Cupon = @Cupon,
	VariosDestinatarios = @VariosDestinatarios,
	NombreContraparte = @NombreContraparte,
	--IdEstadoRegistro = @IdEstadoRegistro,
	TipoDesglose = @TipoDesglose,
	DesgloseTipoOperacion = @DesgloseTipoOperacion,
	FechaFinPlazo = ISNULL(@FechaFinPlazo,FechaFinPlazo),
	[ADeducirEnPeriodoPosterior] = ISNULL(@ADeducirEnPeriodoPosterior, [ADeducirEnPeriodoPosterior]),
	[EjercicioDeduccion] = ISNULL(@EjercicioDeduccion, [EjercicioDeduccion]),
	[PeriodoDeduccion] = ISNULL(@PeriodoDeduccion, [PeriodoDeduccion])
	OUTPUT inserted.id
	INTO @T
WHERE (ISNULL(@NifFacturaEmisor, ISNULL(@IDIdFactura, '')) = ISNULL(NifFacturaEmisor, ISNULL(IDIdFactura, '')) 
		AND @NumSerieFacturaEmisor= NumSerieFacturaEmisor
		AND @FechaExpedicionFacturaEmisor = FechaExpedicionFacturaEmisor) OR
		ISNULL(@Id, 0) = Id
	SELECT TOP(1) * FROM @T
END
ELSE
BEGIN
INSERT INTO RegistroInformacion (
	IdLibroRegistro,
	NifDeclarante, NifFacturaEmisor, NumSerieFacturaEmisor,
	NumSerieFacturaEmisorResumenFin, FechaExpedicionFacturaEmisor,
	TipoFactura, NombreRazon, NIFRepresentante,
	NifContraparte, CodigoPaisContraparte, IDTypeContraparte, IDContraparte,
	CodigoPaisIdFactura,IDTypeIdFactura,IDIdFactura,
	BaseRectificada, CuotaRectificada, CuotaRecargoRectificada,
	TipoRectificativa, FechaExpedicionFactura, FechaOperacion,
	ImporteTotal, ClaveRegimenEspecialOTrascendencia,
	BaseImponibleACoste, DescripcionOperacion, SituacionInmueble, ReferenciaCatastral,
	CausaExencion, BaseImponible, TipoNoExenta, TipoNoSujeta,
	ImportePorArticulos7_14_Otros, ImporteTAIReglasLocalizacion, 
	ImporteTransmisionSujetoAIVA, EmitidaPorTerceros,
	NumeroDUA, FechaRegContableDUA, FechaRegContable,
	CuotaDeducible, TipoOperacion, ClaveDeclarado,
	EstadoMiembro, PlazoOperacion, DescripcionBienes,
	DireccionOperador, FacturasODocumentacion,
	ProrrataAnualDefinitiva, RegularizacionAnualDeduccion, IdentificacionEntrega,
	RegularizacionDeduccionEfectuada, Ejercicio, Periodo, FechaInicioUtilizacion,
	IdentificacionBien, Baja, FechaBaja, IdEstadoLectura,Cupon,VariosDestinatarios,
	NombreContraparte,IdEstadoRegistro,TipoDesglose,DesgloseTipoOperacion,
	FechaFinPlazo,ADeducirEnPeriodoPosterior,EjercicioDeduccion,PeriodoDeduccion
	)
VALUES (@IdLibroRegistro, 
	@NifDeclarante,@NifFacturaEmisor,@NumSerieFacturaEmisor,
	@NumSerieFacturaEmisorResumenFin,@FechaExpedicionFacturaEmisor,
	@TipoFactura,@NombreRazon,@NIFRepresentante,
	@NifContraparte,@CodigoPaisContraparte, @IDTypeContraparte, @IDContraparte,
	@CodigoPaisIdFactura,@IDTypeIdFactura,@IDIdFactura,
	@BaseRectificada,@CuotaRectificada,@CuotaRecargoRectificada,
	@TipoRectificativa,@FechaExpedicionFactura,@FechaOperacion,
	@ImporteTotal,@ClaveRegimenEspecialOTrascendencia,
	@BaseImponibleACoste,@DescripcionOperacion,@SituacionInmueble,@ReferenciaCatastral,
	@CausaExencion, @BaseImponible, @TipoNoExenta, @TipoNoSujeta,
	@ImportePorArticulos7_14_Otros, @ImporteTAIReglasLocalizacion, 
	@ImporteTransmisionSujetoAIVA,@EmitidaPorTerceros,
	@NumeroDUA,@FechaRegContableDUA,@FechaRegContable,
	@CuotaDeducible,@TipoOperacion,@ClaveDeclarado,
	@EstadoMiembro,@PlazoOperacion,@DescripcionBienes,
	@DireccionOperador,@FacturasODocumentacion,
	@ProrrataAnualDefinitiva,@RegularizacionAnualDeduccion,@IdentificacionEntrega,
	@RegularizacionDeduccionEfectuada,@Ejercicio, @Periodo, @FechaInicioUtilizacion,
	@IdentificacionBien, @Baja, @FechaBaja, @IdEstadoLectura,@Cupon,@VariosDestinatarios,
	@NombreContraparte,ISNULL(@IdEstadoRegistro, 0),@TipoDesglose,@DesgloseTipoOperacion,
	@FechaFinPlazo,@ADeducirEnPeriodoPosterior,@EjercicioDeduccion,@PeriodoDeduccion)
SELECT SCOPE_IDENTITY()
END
END
