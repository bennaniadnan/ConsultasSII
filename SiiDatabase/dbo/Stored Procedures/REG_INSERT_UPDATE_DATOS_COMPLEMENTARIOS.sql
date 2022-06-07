CREATE PROCEDURE [dbo].[REG_INSERT_UPDATE_DATOS_COMPLEMENTARIOS]
	
	@IdRegistroInformacion INT,
	@ClaveRegimen1 varchar(2),
	@ClaveRegimen2 varchar(2),
	@Autorizacion varchar(15),
	@RefExterna varchar(60),
	@SimplificadaArt char(1),
	@NombreSucedida varchar(160),
	@NifSucedida varchar(9),
	@RegPrevio char(1), 
	@Macrodato char(1), 
	@FacturaEnergia char(1), 
	@SinDestinatario char(1)
AS
BEGIN
	IF(exists(select 1 from DatosComplementarios where @IdRegistroInformacion = IdRegistroInformacion))
	BEGIN
		update DatosComplementarios
		set ClaveRegimen1 = @ClaveRegimen1,
			ClaveRegimen2 = @ClaveRegimen2, 
			Autorizacion = @Autorizacion,
			RefExterna = @RefExterna, 
			SimplificadaArt = @SimplificadaArt, 
			NombreSucedida = @NombreSucedida , 
			NifSucedida = @NifSucedida,
			RegPrevio = @RegPrevio, 
			Macrodato = @Macrodato, 
			FacturaEnergia = @FacturaEnergia, 
			SinDestinatario = @SinDestinatario
		WHERE IdRegistroInformacion = @IdRegistroInformacion
	END
	ELSE
	BEGIN
		insert into DatosComplementarios(
			IdRegistroInformacion, ClaveRegimen1, ClaveRegimen2, Autorizacion,
			RefExterna, SimplificadaArt, NombreSucedida, NifSucedida,
			RegPrevio, Macrodato, FacturaEnergia, SinDestinatario) 
		values (
			@IdRegistroInformacion, @ClaveRegimen1, @ClaveRegimen2, @Autorizacion,
			@RefExterna, @SimplificadaArt, @NombreSucedida, @NifSucedida,
			@RegPrevio, @Macrodato, @FacturaEnergia, @SinDestinatario)
	END
END

