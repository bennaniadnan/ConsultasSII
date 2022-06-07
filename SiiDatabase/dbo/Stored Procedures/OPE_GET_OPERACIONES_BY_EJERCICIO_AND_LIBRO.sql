
CREATE PROCEDURE [dbo].[OPE_GET_OPERACIONES_BY_EJERCICIO_AND_LIBRO]-- 2017, 'TEST01', 'FE'
(
	@Ejercicio INT ,
	@IdUsuario varchar(6) ,
	@IdLibroRegistro varchar(2) = null
)
AS
BEGIN
Declare @TipoPresentacion char = (select distinct p.TipoPresentacion 
	from dbo.Parameters p with(nolock) join 
	Cliente c with(nolock) on c.Id = p.IdCliente join 
	Usuario u with(nolock) on c.Id = u.IdCliente
	WHERE u.UserId = @IdUsuario)
	
SELECT OP.Ejercicio, OP.Periodo as Periodo,
	 SUM(OP.Pendientes) as Pendientes,
	 SUM(OP.Aceptados) as Acceptadas,
	 SUM(OP.ConErrores) as AcceptadasConErrores,
	 SUM(OP.Rechazados) as Rechazadas
	 FROM 
	 Periodo TP with(nolock) JOIN
	 [Operaciones_Periodo] OP with(nolock) 
	 ON TP.Id = OP.Periodo 
	 WHERE OP.Ejercicio = @Ejercicio AND ISNULL(@IdLibroRegistro,OP.IdLibroRegistro) = OP.IdLibroRegistro
	 AND (TP.TipoPresentacion = @TipoPresentacion OR TP.TipoPresentacion = 'A')
	 GROUP BY OP.Ejercicio, OP.Periodo,TP.TipoPresentacion, TP.Id
	 order BY TP.TipoPresentacion desc, TP.Id

END
GO