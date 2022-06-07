CREATE PROCEDURE [dbo].[LIB_GET_LIBROS_BY_EJERCICIO_PERIODO_LIBRO]
	@IdUsuario varchar(6) = null,
	@IdLibroRegistro varchar(2),
	@Ejercicio INT = null,
	@Periodo varchar(2) = null,
	@NifContraparte varchar(20) = null,
	@IdFactura varchar(20) = null,
	@NumSerieFacturaEmisor varchar(60) = null,
	@FechaExpedicion date = null,
	@FechaRegContable date = null,
	@FechaOperacionDesde date = null,
	@FechaOperacionHasta date = null,
	@IsIDOtros bit = 0,
	@Start int = 0,
	@Records int = 20,
	@SelectedRows SelectedIds READONLY,
	@IdEstadoCuadre int = null
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
		AND (Baja is null or Baja <> 1)
		AND IdEstadoLectura <> 2
	ORDER BY Id desc OFFSET @Start ROWS FETCH NEXT @Records ROWS ONLY