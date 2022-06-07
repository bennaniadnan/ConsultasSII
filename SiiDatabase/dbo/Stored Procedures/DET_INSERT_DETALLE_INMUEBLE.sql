CREATE PROCEDURE [dbo].[DET_INSERT_DETALLE_INMUEBLE](

	@IdRegistroInformacion int,
	@SituacionInmueble int,
	@ReferenciaCatastral varchar(25)
	)
AS
BEGIN
	IF  @ReferenciaCatastral IS NOT NULL
		AND @ReferenciaCatastral <> ''
		AND NOT EXISTS(select 1 from [dbo].[DetalleInmueble] 
			where [SituacionInmueble] = @SituacionInmueble
			AND [ReferenciaCatastral] = @ReferenciaCatastral
			AND [IdRegistroInformacion] = @IdRegistroInformacion) 
	BEGIN
		INSERT INTO [dbo].[DetalleInmueble]
				([IdRegistroInformacion]
				,[SituacionInmueble]
				,[ReferenciaCatastral])
		VALUES
				(@IdRegistroInformacion
				,@SituacionInmueble
				,@ReferenciaCatastral)
	END
END

