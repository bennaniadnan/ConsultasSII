CREATE PROCEDURE  [dbo].[OPE_GET_OPERATION_BY_ID_AND_USER](
	-- Add the parameters for the stored procedure here
	@IdUsuario VARCHAR(6),
	@IdOperacion int
)
AS
BEGIN
SELECT  op.Id AS IdOperacion,
		op.IdTipoOperacion,
		dbo.TipoOperacion.Denominacion AS TipoOperacionDenominacion, 
		op.IdLibroRegistro, 
        dbo.LibroRegistro.Descripcion AS LibroRegistroDescripcion, 
        op.IdUsuario, 
        dbo.Usuario.Email,
        dbo.Usuario.UserName, 
        op.IdEstadoOperacion, 
        dbo.EstadoOperacion.Descripcion AS EstadoOperacionDescripcion, 
        op.IdResultadoOperacion, 
        dbo.ResultadoOperacion.Descripcion AS ResultadoOperacionDescripcion,
		EstadoOperacion.Orden as EstadoOperacionOrden, 
		ResultadoOperacion.Orden as ResultadoOperacionOrden, 
		op.FechaOperacion,
		op.HoraOperacion,
		op.Periodo,
		op.IdCliente,
		op.Ejercicio,
		op.FechaEntrada,
		op.HoraEntrada,
		count(case when RO.IdEstadoRegistro LIKE 0 then 1 end) as NRegistrosPendientes, 
		count(case when RO.IdEstadoRegistro LIKE 1 then 1 end) as NRegistrosAceptados,
		count(case when RO.IdEstadoRegistro LIKE 2 then 1 end) as NRegistrosRechazados,
		count(case when RO.IdEstadoRegistro LIKE 3 then 1 end) as NRegistrosAceptadosCondicionados,
		op.CSV,
		op.XmlEnviada,
		op.XmlRespuesta
FROM Operacion op with (nolock)
INNER JOIN RegistrosOperacion RO with (nolock)
    ON op.Id = RO.IdOperacion  INNER JOIN 
	dbo.TipoOperacion with (nolock)  ON op.IdTipoOperacion = dbo.TipoOperacion.Id INNER JOIN 
    dbo.LibroRegistro with (nolock) ON op.IdLibroRegistro = dbo.LibroRegistro.Id INNER JOIN
    dbo.EstadoOperacion with (nolock) ON op.IdEstadoOperacion = dbo.EstadoOperacion.Id INNER JOIN
    dbo.ResultadoOperacion with (nolock) ON op.IdResultadoOperacion = dbo.ResultadoOperacion.Id INNER JOIN
    dbo.Usuario with (nolock) ON op.IdUsuario = dbo.Usuario.UserId
	 where @IdUsuario = @IdUsuario and op.Id=@IdOperacion
	group by op.Id, op.IdTipoOperacion, dbo.TipoOperacion.Denominacion,
		op.Periodo,
		op.IdCliente,
		op.Ejercicio,
		op.FechaEntrada,
		op.HoraEntrada,
		 op.IdLibroRegistro, 
         dbo.LibroRegistro.Descripcion , op.IdUsuario, dbo.Usuario.Email, dbo.Usuario.UserName, op.IdEstadoOperacion, 
         dbo.EstadoOperacion.Descripcion , op.IdResultadoOperacion, dbo.ResultadoOperacion.Descripcion,
		 EstadoOperacion.Orden, ResultadoOperacion.Orden, FechaOperacion,HoraOperacion,op.CSV,op.XmlEnviada,op.XmlRespuesta
 

END
GO

