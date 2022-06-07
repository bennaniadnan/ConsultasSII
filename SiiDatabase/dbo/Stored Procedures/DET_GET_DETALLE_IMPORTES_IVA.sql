
CREATE PROCEDURE [dbo].[DET_GET_DETALLE_IMPORTES_IVA] 
	@IdRegistro int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [Id]
      ,[IdRegistro]
      ,[IdTipoDetalleIVA]
      ,[TipoImpositivo]
      ,[BaseImponible]
      ,[CuotaRepercutida]
      ,[CuotaSoportada]
      ,[CargaImpositivaImplicita]
      ,[CuotaRecargoMinorista]
      ,[TipoRecargoEquivalencia]
      ,[CuotaRecargoEquivalencia]
      ,[ImporteCompensacionREAGYP]
      ,[PorcentCompensacionREAGYP]
      ,[BienInversion]
      
  FROM [dbo].[DetalleImportesIVA] with (nolock)
  WHERE [IdRegistro] = @IdRegistro
END

