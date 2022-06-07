CREATE PROCEDURE [dbo].[PAR_GET_PARAMETERS_BY_USERID]
	@UserId varchar(6)
AS
BEGIN
	SELECT p.IdCliente,
		p.FacturasAgrupadas,
		p.FacturasRectificadas,
		p.CobrosRECC,
		p.PagosRECC,
		p.MultiRegistrosCatastrales,
		p.TipoPresentacion,
		p.DatosComplementarios,
		p.Macrodato,
		p.ForPuenteConector,
		p.Validacion2021
	From [Parameters] p with(nolock)
		inner join Cliente c with(nolock) on c.Id= p.IdCliente
		inner join Usuario u with(nolock) on u.IdCliente = c.Id 
	where u.UserId = @UserId
END
