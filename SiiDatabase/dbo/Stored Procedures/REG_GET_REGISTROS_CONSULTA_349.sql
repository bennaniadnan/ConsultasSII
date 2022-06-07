CREATE PROCEDURE [dbo].[REG_GET_REGISTROS_CONSULTA_349]
	@IdLibroRegistro varchar(2),
	@Ejercicio INT = null,
	@Periodo varchar(2) = null,
	@NifOperador varchar(20) = null,
	@Start int = 0,
	@Records int = 20
AS
	SELECT Id, EstadoRegistro, NumeroFactura, FechaFactura, IdFiscal, IsNifContraparte, NombreContraparte, 
		CodigoPaisContraparte, IDTypeContraparte, TipoFactura, ClaveRegimenEspecial, ImporteTotal,
		TipoNoSujeto, BaseNoSujeta, TipoDesglose, BaseExenta, CausaExencion, TipoDeSujecion,
		CuotaDeducible, Ejercicio, Periodo, IdEstadoCuadre, RefExterna, CountDetalleIVA, 
		BaseImponible, CuotaIVA, TipoRE, CuotaRE, count(*) over() as TotalCount
	FROM [Libros] with (nolock)
	WHERE IdEstadoRegistro IN(1,2)
		AND IdLibroRegistro = @IdLibroRegistro 
		AND ISNULL(Ejercicio, '') = ISNULL(@Ejercicio, ISNULL(Ejercicio,''))
		AND ISNULL(Periodo, '') = ISNULL(@Periodo, ISNULL(Periodo,''))
		AND ISNULL(IdFiscal, '') = ISNULL(@NifOperador, ISNULL(IdFiscal,''))
		AND (Baja is null or Baja <> 1)
		AND IdEstadoLectura <> 2
	ORDER BY Id desc OFFSET @Start ROWS FETCH NEXT @Records ROWS ONLY
