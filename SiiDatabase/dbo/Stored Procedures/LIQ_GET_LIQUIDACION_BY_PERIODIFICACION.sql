CREATE PROCEDURE [dbo].[LIQ_GET_LIQUIDACION_BY_PERIODIFICACION] (
	@Ejercicio int,
	@Periodo varchar(2)
)AS
BEGIN
	select * from (
	select isnull(sum(di.BaseImponible),0) as Base01, isnull(sum(di.CuotaRepercutida),0) as Cuota03 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FE'
			and di.TipoImpositivo = 4
			and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'F2' or ri.TipoFactura = 'F4')
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw1,(
	select isnull(sum(di.BaseImponible),0) as Base04, isnull(sum(di.CuotaRepercutida),0) as Cuota06 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FE'
			and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'F2' or ri.TipoFactura = 'F4')
			and di.TipoImpositivo = 10
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw2,(
	select isnull(sum(di.BaseImponible),0) as Base07, isnull(sum(di.CuotaRepercutida),0) as Cuota09 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FE'
			and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'F2' or ri.TipoFactura = 'F4')
			and di.TipoImpositivo = 21
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw3,(
	select isnull(sum(di.BaseImponible),0) as Base10, isnull(sum(di.CuotaSoportada),0) as Cuota11 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FR' 
			and ri.ClaveRegimenEspecialOTrascendencia = '09'
			--and ri.IDTypeContraparte = '02' 
			--and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'R1')
			--and di.TipoImpositivo <> 0
			--and di.[IdTipoDetalleIVA] = 0
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw4,(
	select isnull(sum(di.BaseImponible),0) as Base12, isnull(sum(di.CuotaSoportada),0) as Cuota13 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FR'
			and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'R1')
			and di.IdTipoDetalleIVA = 1
			and (ri.IDTypeContraparte <> '02' or ri.IdTypeContraparte is null)
			and di.TipoImpositivo = 21 
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw5,(
	select isnull(sum(di.BaseImponible),0) as Base14, isnull(sum(di.CuotaRepercutida),0) as Cuota15 
from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FE' 
			and (ri.TipoFactura = 'R1' or ri.TipoFactura = 'R5')
			and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null) 
			and ri.TipoNoExenta = 'S1'
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw6,(
	select isnull(sum(di.BaseImponible),0) as Base16, isnull(sum(di.CuotaRecargoEquivalencia),0) as Cuota18 
	--select distinct 0.00 as Base16, 0.00 as Cuota18
	from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FE' 
			--and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null) 
			--and ri.ClaveRegimenEspecialOTrascendencia = '01'
			--and di.CuotaRepercutida > 0
			and ri.TipoFactura not like '%R%'
			and di.IdTipoDetalleIVA in (0, 3)
			and di.TipoRecargoEquivalencia = 0.50
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
) as vw7,(
	select isnull(sum(di.BaseImponible),0) as Base19, isnull(sum(di.CuotaRecargoEquivalencia),0) as Cuota21 
	--select distinct 0.00 as Base19, 0.00 as Cuota21
	from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FE' 
		--and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null)  
		--and ri.ClaveRegimenEspecialOTrascendencia = '01'
			and ri.TipoFactura not like '%R%'
			and di.IdTipoDetalleIVA in (0, 3)
		and di.TipoRecargoEquivalencia = 1.40
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
)as vw8,(
	select isnull(sum(di.BaseImponible),0) as Base22, isnull(sum(di.CuotaRecargoEquivalencia),0) as Cuota24 
	--select distinct 0.00 as Base22, 0.00 as Cuota24
	from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FE' 
		--and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null)
		--and ri.ClaveRegimenEspecialOTrascendencia = '01'
		and ri.TipoFactura not like '%R%'
		and di.IdTipoDetalleIVA in (0, 3)
		and di.TipoRecargoEquivalencia = 5.20
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
)as vw9,(
	
	select isnull(sum(di.BaseImponible),0) as Base25, isnull(sum(di.CuotaRecargoEquivalencia),0) as Cuota26 
	--select distinct 0.00 as Base25, 0.00 as Cuota26
	from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FE' 
			--and (ri.TipoFactura = 'R1' or ri.TipoFactura = 'R5')
			--and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null) 
			--and ri.TipoNoExenta = 'S1'
			and ri.TipoFactura like '%R%'
			and ISNULL(di.CuotaRecargoEquivalencia, 0) < 0
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				

)as vw10,(
select * from
	(select 
		isnull(sum(di.BaseImponible),0) as Base28
		from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FR' 
			and (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)
			and ri.TipoFactura = 'F1'
			and (di.BienInversion = 'N' OR di.BienInversion is null)
			--and di.TipoImpositivo <> 0
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
					AND RI.IdEstadoRegistro in (1,2)) as Base28
	, (select isnull(sum(ri.CuotaDeducible),0) as Cuota29
		from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FR' 
			and (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)
			and ri.TipoFactura = 'F1'
			and (di.BienInversion = 'N' OR di.BienInversion is null)
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
					AND RI.IdEstadoRegistro in (1,2)) as Cuota29
				

)as vw11,(
select * from
	(select 
		isnull(sum(di.BaseImponible),0) as Base30
		from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FR' 
			and (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)
			and ri.TipoFactura = 'F1'
			and di.BienInversion = 'S'
			--and di.TipoImpositivo <> 0
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
					AND RI.IdEstadoRegistro in (1,2)) as Base30
	, (select isnull(sum(ri.CuotaDeducible),0) as Cuota31
		from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
		where ri.IdLibroRegistro = 'FR' 
			and (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)
			and ri.TipoFactura = 'F1'
			and di.BienInversion = 'S'
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
					AND RI.IdEstadoRegistro in (1,2)) as Cuota31
				

)as vw12,(
	select isnull(sum(di.BaseImponible),0) as Base32, isnull(sum(di.CuotaSoportada),0) as Cuota33 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FR' 
		--and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null) 
		and ri.TipoFactura = 'F5'
		and di.TipoImpositivo = 21
		and di.IdTipoDetalleIVA = 0
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				

)as vw13,(
	select isnull(sum(di.BaseImponible),0) as Base34, isnull(sum(di.CuotaSoportada),0) as Cuota35 
	--select distinct 0.00 as Base34, 0.00 as Cuota35 
	from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FR' 
		--and (ri.IDTypeContraparte not in('02', '06') or ri.IDTypeContraparte is null) 
		and ri.TipoFactura = 'F5'
		and di.TipoImpositivo = 21
		and di.IdTipoDetalleIVA = 0
		and di.BienInversion = 'S'
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				

)as vw14,(
select isnull(sum(di.BaseImponible),0) as Base36, isnull(sum(di.CuotaSoportada),0) as Cuota37 from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FR' 
		and ri.ClaveRegimenEspecialOTrascendencia = '09'
		and (di.BienInversion is null or di.BienInversion = 'N')
		--and ri.IDTypeContraparte = '02' 
		--and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'R1')
		--and di.TipoImpositivo <> 0
		--and di.[IdTipoDetalleIVA] = 0
		and ri.Ejercicio = @Ejercicio
		and (ri.Periodo = @Periodo OR @Periodo = '0A')
		AND RI.IdEstadoRegistro in (1,2)

)as vw15,(
	select isnull(sum(di.BaseImponible),0) as Base38, isnull(sum(di.CuotaSoportada),0) as Cuota39
	--select distinct 0.00 as Base38, 0.00 as Cuota39
	from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FR' 
		and ri.ClaveRegimenEspecialOTrascendencia = '09'
		--and ri.IDTypeContraparte = '02' 
		--and (ri.TipoFactura = 'F1' or ri.TipoFactura = 'R1')
		--and di.TipoImpositivo <> 0
		--and di.[IdTipoDetalleIVA] = 0
		and di.BienInversion = 'S'
		and ri.Ejercicio = @Ejercicio
		and (ri.Periodo = @Periodo OR @Periodo = '0A')
		AND RI.IdEstadoRegistro in (1,2)
				

)as vw16,(
select isnull(sum(di.BaseImponible),0) as Base40, isnull(sum(di.CuotaSoportada),0) as Cuota41 
--select distinct 0.00 as Base40, 0.00 as Cuota41 
from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	where ri.IdLibroRegistro = 'FR' 
		and ri.TipoFactura = 'R1'
		and (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)
		and di.TipoImpositivo <> 0 
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
)as vw17,(
--select isnull(sum(di.BaseImponible),0) as Base40, isnull(sum(di.CuotaSoportada),0) as Cuota41 
select distinct 0.00 as Cuota42 
from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	--where ri.IdLibroRegistro = 'FR' 
	--	and (ri.IDTypeContraparte = '02')
	--	and ri.TipoFactura in('F1','R1')
	--	and ri.ClaveRegimenEspecialOTrascendencia = '09'
	--	and di.TipoImpositivo = 0)
			where ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				

)as vw18,(
--select isnull(sum(di.BaseImponible),0) as Base40, isnull(sum(di.CuotaSoportada),0) as Cuota41 
select distinct 0.00 as Cuota43
from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	--where ri.IdLibroRegistro = 'FR' 
	--	and (ri.IDTypeContraparte = '02')
	--	and ri.TipoFactura in('F1','R1')
	--	and ri.ClaveRegimenEspecialOTrascendencia = '09'
	--	and di.TipoImpositivo = 0)
			where ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				

)as vw19,(
--select isnull(sum(di.BaseImponible),0) as Base40, isnull(sum(di.CuotaSoportada),0) as Cuota41 
select distinct 0.00 as Cuota44 
from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
	--where ri.IdLibroRegistro = 'FR' 
	--	and (ri.IDTypeContraparte = '02')
	--	and ri.TipoFactura in('F1','R1')
	--	and ri.ClaveRegimenEspecialOTrascendencia = '09'
	--	and di.TipoImpositivo = 0)
			where ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				

)as vw20,(
select (select isnull(sum(ri.[BaseImponible]),0)
from [dbo].[RegistroInformacion] ri
	where (ri.IDTypeContraparte = '02')
		and ri.ClaveRegimenEspecialOTrascendencia = '01'
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)) + 
(select isnull(sum(ri.[ImportePorArticulos7_14_Otros]),0) + isnull(sum(ri.[ImporteTAIReglasLocalizacion]),0)
from [dbo].[RegistroInformacion] ri
	where (ri.IDTypeContraparte = '02')
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)) as Base59
				

)as vw21,(
	select isnull(sum(ri.[BaseImponible]),0) as Base60
	from [dbo].[RegistroInformacion] ri
		where ((ri.ClaveRegimenEspecialOTrascendencia = '01' and ri.CausaExencion = 'E4') or (ri.ClaveRegimenEspecialOTrascendencia = '02'))
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
				AND RI.IdEstadoRegistro in (1,2)
				
	--			+ 
	--(select isnull(sum(ri.[BaseImponible]),0)
	--from [dbo].[RegistroInformacion] ri
	--	where ri.CausaExencion = 'E4'
	--			and ri.Ejercicio = @Ejercicio
	--			and (ri.Periodo = @Periodo OR @Periodo = '0A'))
				 --as Base60

)as vw22,(
	select (select isnull(sum(ri.[ImportePorArticulos7_14_Otros]),0)
	from [dbo].[RegistroInformacion] ri
		where  ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				and ((ri.Ejercicio = 2021 and ri.Periodo < '07') or ri.Ejercicio < 2021)
				AND RI.IdEstadoRegistro in (1,2)
				AND (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)) + 
	(select isnull(sum(ri.[ImporteTAIReglasLocalizacion]),0)
		from [dbo].[RegistroInformacion] ri
			where  ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
				and ((ri.Ejercicio = 2021 and ri.Periodo < '07') or ri.Ejercicio < 2021)
				AND RI.IdEstadoRegistro in (1,2)
				AND (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)) + 
	(select isnull(sum(di.[BaseImponible]),0)
		from [dbo].[RegistroInformacion] ri join [dbo].[DetalleImportesIVA] di on ri.Id = di.IdRegistro
			where ri.[TipoNoExenta] = 'S2'
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
				and ((ri.Ejercicio = 2021 and ri.Periodo < '07') or ri.Ejercicio < 2021)
				AND RI.IdEstadoRegistro in (1,2)
				) as Base61

)as vw23,(
	select (select isnull(sum(ri.[ImporteTAIReglasLocalizacion]),0)
	from [dbo].[RegistroInformacion] ri
		where ri.IDTypeContraparte = '02'
			and ri.ClaveRegimenEspecialOTrascendencia = '01'
			and ri.TipoFactura in ('F1', 'R1', 'R2', 'R3', 'R4')
			and ri.TipoDesglose = 2 and DesgloseTipoOperacion = 1 --Entrega
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				and ((ri.Ejercicio = 2021 and ri.Periodo >= '07') or ri.Ejercicio > 2021)
				AND RI.IdEstadoRegistro in (1,2)) + 
	(select isnull(sum(ri.[ImporteTAIReglasLocalizacion]),0)
		from [dbo].[RegistroInformacion] ri
			where  ri.TipoDesglose = 2 and DesgloseTipoOperacion = 2 --PrestacionServicios
				and (ri.IDTypeContraparte <> '02' or ri.idTypeContraparte is null)
				and ri.Ejercicio = @Ejercicio
				and (ri.Periodo = @Periodo OR @Periodo = '0A')
				and ((ri.Ejercicio = 2021 and ri.Periodo >= '07') or ri.Ejercicio > 2021)
				AND RI.IdEstadoRegistro in (1,2)) as Base120

)as vw24,(
	select (select isnull(sum(di.BaseImponible),0)
	from [dbo].[RegistroInformacion] ri
		join DetalleImportesIVA di on ri.Id = di.IdRegistro 
		where ri.IDTypeContraparte = '02'
			and ri.ClaveRegimenEspecialOTrascendencia = '01'
			and ri.TipoFactura in ('F1', 'R1', 'R2', 'R3', 'R4')
			and ri.TipoDesglose = 1 --DesgloseFactura
			and di.IdTipoDetalleIVA = 1 --DesgloseFactura
			and ri.TipoNoExenta in ('S1', 'S2')
			and ri.Ejercicio = @Ejercicio
			and (ri.Periodo = @Periodo OR @Periodo = '0A')
				and ((ri.Ejercicio = 2021 and ri.Periodo >= '07') or ri.Ejercicio > 2021)
				AND RI.IdEstadoRegistro in (1,2)) as Base122

)as vw25


END
