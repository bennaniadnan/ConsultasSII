
CREATE PROCEDURE  [dbo].[REG_GET_REGISTROSINFORMACION_BY_FILTER] 
(
	@IdOperacion int = null,
	@IdUsuario varchar(128) = null,
	@NifFacturaEmisor varchar(20) =null,
	@NifContraparte varchar(20) =null,
	@NumSerieFacturaEmisor varchar(60) =null,
	@IdEstadoRegistro  int =null,
	@NombreContraparte varchar(120) =null,
	@FechaExpedicionFacturaEmisorIni date =null,
	@FechaExpedicionFacturaEmisorFin date =null,
	@IdEstadoLectura int =null,
	@IdLibroRegistro varchar(2) =null,
	@PageNumber int = 1
	
)
AS
BEGIN

	DECLARE @Records int = 20
	DECLARE @Offset int = (@PageNumber - 1) * @Records, @top int = @PageNumber * @Records, @count int = 0

	SELECT @count = COUNT(RI.[Id])
	  FROM [dbo].[RegistroInformacion] RI with (nolock) 
	  INNER JOIN
	  [dbo].[RegistrosOperacion] RO with (nolock)
		ON RO.IdRegistroInformacion = RI.Id and RO.IdOperacion = isnull(@IdOperacion,RO.IdOperacion)
	  where   
	  RO.IdOperacion  = isnull(@IdOperacion,RO.IdOperacion)
	
		--AND OP.IdUsuario = @IdUsuario
		AND isnull(RI.IdEstadolectura,0) = isNULL(@IdEstadoLectura,isnull(RI.IdEstadolectura,0))
		AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
	
	
		AND isnull(RI.NifFacturaEmisor,'') = isNULL(@NifFacturaEmisor,isnull(RI.NifFacturaEmisor,''))
		AND isnull(RI.NifContraparte,'') = isNULL(@NifContraparte,isnull(RI.NifContraparte,''))
		AND isnull(RI.NumSerieFacturaEmisor,'') = isNULL(@NumSerieFacturaEmisor,isnull(RI.NumSerieFacturaEmisor,''))
		AND isnull(RO.IdEstadoRegistro,0) = isNULL(@IdEstadoRegistro,isnull(RO.IdEstadoRegistro,0))
		AND isnull(RI.NombreContraparte,'') = isNULL(@NombreContraparte,isnull(RI.NombreContraparte,''))
		AND isnull(RI.FechaExpedicionFacturaEmisor,cast('19000101' as date)) = 
			isNULL(@FechaExpedicionFacturaEmisorIni,isnull(RI.FechaExpedicionFacturaEmisor,cast('19000101' as date)))
	
	SELECT DISTINCT TOP(@top)
		   RI.[Id] 
		  ,RI.IdLibroRegistro
		  ,LR.Descripcion as LibroRegistro
		  ,RI.Periodo
		  ,PE.Texte as PETexte
		  ,RI.Ejercicio
		  ,[NifFacturaEmisor]
		  ,[NifContraparte]
		  ,[NumSerieFacturaEmisor]
		  ,[NombreContraparte]
		  ,[NombreRazon]
		  ,[FechaExpedicionFacturaEmisor]
		  ,[ImporteTotal]
		  ,Convert(decimal,0) as ImporteCobroPago
		  ,1 as IdEstadoRegistroOperacion--RO.IdEstadoRegistro as IdEstadoRegistroOperacion
		  ,ERO.Descripcion as EstadoRegistroOperacion
		  ,RI.IdEstadoRegistro as IdEstadoRegistroInformacion
		  ,ERI.Descripcion as EstadoRegistroInformacion
		  ,[IdEstadoLectura]
		  ,EL.Estado as EstadoLectura
		  into #tmp
	  FROM [dbo].[RegistroInformacion] RI with (nolock) 
	  INNER JOIN
	  [dbo].[RegistrosOperacion] RO with (nolock)
		ON RO.IdRegistroInformacion = RI.Id and RO.IdOperacion = isnull(@IdOperacion,RO.IdOperacion)
	  INNER JOIN
	  [dbo].EstadoRegistro ERI with (nolock)
		ON RI.IdEstadoRegistro = ERI.Id
	  INNER JOIN
	  [dbo].EstadoRegistro ERO with (nolock)
		ON RO.IdEstadoRegistro = ERO.Id
	  INNER JOIN
	  [dbo].LibroRegistro LR with (nolock)
		ON RI.IdLibroRegistro = LR.Id
	  INNER JOIN
	  [dbo].Periodo PE with (nolock)
		ON RI.Periodo = PE.Id
	  INNER JOIN
	  [dbo].Estadolectura EL with (nolock)
		ON RI.IdEstadoLectura = EL.Id
	  where   
	  RO.IdOperacion  = isnull(@IdOperacion,RO.IdOperacion)
		AND isnull(RI.IdEstadolectura,0) = isNULL(@IdEstadoLectura,isnull(RI.IdEstadolectura,0))
		AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
		AND isnull(RI.NifFacturaEmisor,'') = isNULL(@NifFacturaEmisor,isnull(RI.NifFacturaEmisor,''))
		AND isnull(RI.NifContraparte,'') = isNULL(@NifContraparte,isnull(RI.NifContraparte,''))
		AND isnull(RI.NumSerieFacturaEmisor,'') = isNULL(@NumSerieFacturaEmisor,isnull(RI.NumSerieFacturaEmisor,''))
		AND isnull(RO.IdEstadoRegistro,0) = isNULL(@IdEstadoRegistro,isnull(RO.IdEstadoRegistro,0))
		AND isnull(RI.NombreContraparte,'') = isNULL(@NombreContraparte,isnull(RI.NombreContraparte,''))
		AND isnull(RI.FechaExpedicionFacturaEmisor,cast('19000101' as date)) = 
			isNULL(@FechaExpedicionFacturaEmisorIni,isnull(RI.FechaExpedicionFacturaEmisor,cast('19000101' as date)))
			
	  Group by RI.[Id],RI.IdLibroRegistro,LR.Descripcion,RI.Periodo,PE.Texte,RI.Ejercicio,[NifFacturaEmisor]
		  ,[NifContraparte],[NumSerieFacturaEmisor],[NombreContraparte],[NombreRazon],[FechaExpedicionFacturaEmisor]
		  ,[ImporteTotal],RO.IdEstadoRegistro,ERO.Descripcion,RI.IdEstadoRegistro,ERI.Descripcion,[IdEstadoLectura],EL.Estado
		  
	SELECT *, @count as TotalCount
	from #tmp 
	order by #tmp.IdLibroRegistro, #tmp.Ejercicio, #tmp.Periodo OFFSET @Offset ROWS FETCH NEXT @Records ROWS ONLY
	Drop table #tmp
END
GO
