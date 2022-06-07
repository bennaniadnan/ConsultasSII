CREATE PROCEDURE [dbo].[REG_GET_REGISTROS_APROCESAR] 
(
	@IdUsuario varchar(6) = null,
	@IdEstadoLectura int = null,
	@IdLibroRegistro varchar(2) = null
)
AS
BEGIN
SELECT DISTINCT RI.[Id]
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
	  ,RI.IdEstadoRegistro as IdEstadoRegistroInformacion
	  ,ERI.Descripcion as EstadoRegistroInformacion
	  ,[IdEstadoLectura]
	  ,EL.Estado as EstadoLectura
  FROM [dbo].[RegistroInformacion] RI with (nolock)
  INNER JOIN
  [dbo].EstadoRegistro ERI with (nolock)
	ON RI.IdEstadoRegistro = ERI.Id
  INNER JOIN
  [dbo].LibroRegistro LR with (nolock)
	ON RI.IdLibroRegistro = LR.Id
  INNER JOIN
  [dbo].Periodo PE with (nolock)
	ON RI.Periodo = PE.Id
  INNER JOIN
  [dbo].Estadolectura EL with (nolock)
	ON RI.IdEstadoLectura = EL.Id
  LEFT JOIN
  [dbo].Cobros CO with (nolock)
	ON RI.Id= CO.IdRegistroInformacion
  LEFT JOIN
  [dbo].Pagos PA with (nolock)
	ON RI.Id = PA.IdRegistroInformacion
  where
	(
		RI.IdEstadoLectura in(1,2,4)
		AND isnull(RI.IdEstadoLectura,0) = isNULL(@IdEstadoLectura,isnull(RI.IdEstadoLectura,0))
		AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
	)
	OR (
		RI.IdEstadoLectura <> 2 
		AND  isNULL(@IdEstadoLectura,0) <> 2
		AND (CO.IdEstadoCobroPago = 0 OR PA.IdEstadoCobroPago = 0)
		AND isnull(RI.IdLibroRegistro,'') = isNULL(@IdLibroRegistro,isnull(RI.IdLibroRegistro,''))
		AND RI.IdEstadoRegistro not in (0,4) 
	)
	Group by RI.[Id],RI.IdLibroRegistro,LR.Descripcion,RI.Periodo,PE.Texte,RI.Ejercicio,[NifFacturaEmisor]
	  ,[NifContraparte],[NumSerieFacturaEmisor],[NombreContraparte],[NombreRazon],[FechaExpedicionFacturaEmisor]
      ,[ImporteTotal],RI.IdEstadoRegistro,ERI.Descripcion,[IdEstadoLectura],EL.Estado
	  --,RO.IdEstadoRegistro,ERO.Descripcion
	order by RI.IdLibroRegistro, RI.IdEstadoLectura, RI.Ejercicio, RI.Periodo
END
