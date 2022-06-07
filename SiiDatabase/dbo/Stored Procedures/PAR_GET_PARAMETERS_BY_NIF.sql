CREATE PROCEDURE [dbo].[PAR_GET_PARAMETERS_BY_NIF]
	@Nif varchar(9)
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
	where c.Nif = @Nif
END
