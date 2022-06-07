CREATE PROCEDURE [dbo].[CON_GET_CONSULTA_349]
	@IdLibroRegistro VARCHAR(2) = null,
	@Ejercicio int,
	@Periodo VARCHAR(2)
AS
BEGIN
	SELECT RI.NombreContraparte, ISNULL(NULLIF(RI.NifContraparte, ''), RI.IDContraparte) as NifOperador, NULLIF(RI.CodigoPaisContraparte, '') as CodigoPais, 
		SUM(ISNULL(DI.BaseImponible, 0)) as BaseImponible,
		SUM(ISNULL(
			CASE WHEN DI.IdTipoDetalleIVA = 2 THEN DI.BaseImponible ELSE 0 END
			, 0)) as EntregaBienes,
		SUM(ISNULL(
			CASE WHEN DI.IdTipoDetalleIVA = 3 THEN DI.BaseImponible ELSE 0 END
			, 0)) as PrestacionServicios
	FROM RegistroInformacion RI JOIN DetalleImportesIVA DI 
		ON RI.Id = DI.IdRegistro
	WHERE RI.IdLibroRegistro = @IdLibroRegistro
		AND RI.Ejercicio = @Ejercicio
		AND RI.Periodo = @Periodo
		AND RI.IdEstadoRegistro in(1, 2)
	GROUP BY RI.NombreContraparte, RI.CodigoPaisContraparte, RI.IDContraparte, RI.NifContraparte

END
