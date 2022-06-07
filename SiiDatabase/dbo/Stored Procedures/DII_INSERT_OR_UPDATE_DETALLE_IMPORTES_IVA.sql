
CREATE PROCEDURE [dbo].[DII_INSERT_OR_UPDATE_DETALLE_IMPORTES_IVA] (
	@Id int = null,
	@IdRegistro int,
	@IdTipoDetalleIva int,
	@TipoImpositivo decimal(15,2) ,
	@BaseImponible decimal(15,2),
	@CuotaRepercutida decimal(15,2),
	@CuotaSoportada decimal(15,2),
	@TipoRecargoEquivalencia decimal(15,2) ,
	@CuotaRecargoEquivalencia decimal(15,2),
	@ImporteCompensacionREAGYP  decimal(15,2),
	@PorcentCompensacionREAGYP decimal(15,2),
	@CargaImpositivaImplicita decimal(15,2) = 0,
	@CuotaRecargoMinorista decimal(15,2) = 0,
	@BienInversion varchar(1) = null
)
AS
BEGIN
if(@Id is not null and (exists(select 1 from DetalleImportesIVA where Id = @Id)))
begin
	update DetalleImportesIVA 
		set	
			IdTipoDetalleIVA =@IdTipoDetalleIva,
			IdRegistro = @IdRegistro,
			TipoImpositivo = @TipoImpositivo,
			BaseImponible = @BaseImponible,
			CuotaRepercutida = @CuotaRepercutida,
			CuotaSoportada = @CuotaSoportada,
			CargaImpositivaImplicita = @CargaImpositivaImplicita,
			CuotaRecargoMinorista = @CuotaRecargoMinorista,
			TipoRecargoEquivalencia = @TipoRecargoEquivalencia,
			CuotaRecargoEquivalencia = @CuotaRecargoEquivalencia,
			BienInversion = ISNULL(@BienInversion, BienInversion)
		where Id = @Id
End
else 
begin
INSERT INTO DetalleImportesIVA(IdRegistro, TipoImpositivo, BaseImponible,
			CuotaRepercutida, TipoRecargoEquivalencia, CuotaRecargoEquivalencia,
			ImporteCompensacionREAGYP, PorcentCompensacionREAGYP, IdTipoDetalleIva, CuotaSoportada, 
			CargaImpositivaImplicita, CuotaRecargoMinorista, BienInversion)
	VALUES(	@IdRegistro, @TipoImpositivo, @BaseImponible,
			@CuotaRepercutida, @TipoRecargoEquivalencia, @CuotaRecargoEquivalencia,
			@ImporteCompensacionREAGYP, @PorcentCompensacionREAGYP, @IdTipoDetalleIva, @CuotaSoportada, 
			@CargaImpositivaImplicita, @CuotaRecargoMinorista, @BienInversion)		
																
end							
END

