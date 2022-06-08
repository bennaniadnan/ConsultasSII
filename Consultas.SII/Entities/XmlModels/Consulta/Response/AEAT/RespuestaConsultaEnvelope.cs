using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response.AEAT
{
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd", IsNullable = false)]
	public partial class RespuestaConsultaLRFacturasRecibidas
	{

		private RespuestaConsultaCabecera cabeceraField;

		private RespuestaConsultaPeriodoLiquidacion periodoLiquidacionField;

		private string indicadorPaginacionField;

		private string resultadoConsultaField;

		private RegistroRespuestaConsultaLRFacturasRecibidas[] registroRespuestaConsultaLRFacturasRecibidasField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaCabecera Cabecera
		{
			get
			{
				return this.cabeceraField;
			}
			set
			{
				this.cabeceraField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaPeriodoLiquidacion PeriodoLiquidacion
		{
			get
			{
				return this.periodoLiquidacionField;
			}
			set
			{
				this.periodoLiquidacionField = value;
			}
		}

		/// <remarks/>
		public string IndicadorPaginacion
		{
			get
			{
				return this.indicadorPaginacionField;
			}
			set
			{
				this.indicadorPaginacionField = value;
			}
		}

		/// <remarks/>
		public string ResultadoConsulta
		{
			get
			{
				return this.resultadoConsultaField;
			}
			set
			{
				this.resultadoConsultaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("RegistroRespuestaConsultaLRFacturasRecibidas", IsNullable = false)]
		public RegistroRespuestaConsultaLRFacturasRecibidas[] RegistroRespuestaConsultaLRFacturasRecibidas
		{
			get
			{
				return this.registroRespuestaConsultaLRFacturasRecibidasField;
			}
			set
			{
				this.registroRespuestaConsultaLRFacturasRecibidasField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RegistroRespuestaConsultaLRFacturasRecibidas
	{

		private RespuestaConsultaIDFactura iDFacturaField;

		private RespuestaConsultaDatosFacturaRecibida datosFacturaRecibidaField;

		private RespuestaConsultaDatosPresentacion datosPresentacionField;

		private RespuestaConsultaEstadoFactura estadoFacturaField;

		private RespuestaConsultaDatosDescuadreContraparte datosDescuadreContraparteField;

		/// <remarks/>
		public RespuestaConsultaIDFactura IDFactura
		{
			get
			{
				return this.iDFacturaField;
			}
			set
			{
				this.iDFacturaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosFacturaRecibida DatosFacturaRecibida
		{
			get
			{
				return this.datosFacturaRecibidaField;
			}
			set
			{
				this.datosFacturaRecibidaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosPresentacion DatosPresentacion
		{
			get
			{
				return this.datosPresentacionField;
			}
			set
			{
				this.datosPresentacionField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaEstadoFactura EstadoFactura
		{
			get
			{
				return this.estadoFacturaField;
			}
			set
			{
				this.estadoFacturaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosDescuadreContraparte DatosDescuadreContraparte
		{
			get
			{
				return this.datosDescuadreContraparteField;
			}
			set
			{
				this.datosDescuadreContraparteField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDatosFacturaRecibida
	{

		private string tipoFacturaField;

		private string tipoRectificativaField;

		private RespuestaConsultaIDFacturaAgrupada[] facturasAgrupadasField;

		private RespuestaConsultaIDFacturaRectificada[] facturasRectificadasField;

		private RespuestaConsultaImporteRectificacion importeRectificacionField;

		private string fechaOperacionField;

		private string claveRegimenEspecialOTrascendenciaField;

		private string claveRegimenEspecialOTrascendenciaAdicional1Field;

		private string claveRegimenEspecialOTrascendenciaAdicional2Field;

		private string numRegistroAcuerdoFacturacionField;

		private string importeTotalField;

		private string baseImponibleACosteField;

		private string descripcionOperacionField;

		private string refExternaField;

		private string facturaSimplificadaArticulos72_73Field;

		private RespuestaConsultaEntidadSucedida entidadSucedidaField;

		private string regPrevioGGEEoREDEMEoCompetenciaField;

		private string macrodatoField;

		private RespuestaConsultaDesgloseFactura desgloseFacturaField;

		private RespuestaConsultaContraparte contraparteField;

		private string fechaRegContableField;

		private string cuotaDeducibleField;

		private string pagosField;
		private string aDeducirEnPeriodoPosteriorField;
		private string ejercicioDeduccionField;
		private string periodoDeduccionField;

		/// <remarks/>
		public string TipoFactura
		{
			get
			{
				return this.tipoFacturaField;
			}
			set
			{
				this.tipoFacturaField = value;
			}
		}

		/// <remarks/>
		public string TipoRectificativa
		{
			get
			{
				return this.tipoRectificativaField;
			}
			set
			{
				this.tipoRectificativaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("IDFacturaAgrupada", IsNullable = false)]
		public RespuestaConsultaIDFacturaAgrupada[] FacturasAgrupadas
		{
			get
			{
				return this.facturasAgrupadasField;
			}
			set
			{
				this.facturasAgrupadasField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("IDFacturaRectificada", IsNullable = false)]
		public RespuestaConsultaIDFacturaRectificada[] FacturasRectificadas
		{
			get
			{
				return this.facturasRectificadasField;
			}
			set
			{
				this.facturasRectificadasField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaImporteRectificacion ImporteRectificacion
		{
			get
			{
				return this.importeRectificacionField;
			}
			set
			{
				this.importeRectificacionField = value;
			}
		}

		/// <remarks/>
		public string FechaOperacion
		{
			get
			{
				return this.fechaOperacionField;
			}
			set
			{
				this.fechaOperacionField = value;
			}
		}

		/// <remarks/>
		public string ClaveRegimenEspecialOTrascendencia
		{
			get
			{
				return this.claveRegimenEspecialOTrascendenciaField;
			}
			set
			{
				this.claveRegimenEspecialOTrascendenciaField = value;
			}
		}

		/// <remarks/>
		public string ClaveRegimenEspecialOTrascendenciaAdicional1
		{
			get
			{
				return this.claveRegimenEspecialOTrascendenciaAdicional1Field;
			}
			set
			{
				this.claveRegimenEspecialOTrascendenciaAdicional1Field = value;
			}
		}

		/// <remarks/>
		public string ClaveRegimenEspecialOTrascendenciaAdicional2
		{
			get
			{
				return this.claveRegimenEspecialOTrascendenciaAdicional2Field;
			}
			set
			{
				this.claveRegimenEspecialOTrascendenciaAdicional2Field = value;
			}
		}

		/// <remarks/>
		public string NumRegistroAcuerdoFacturacion
		{
			get
			{
				return this.numRegistroAcuerdoFacturacionField;
			}
			set
			{
				this.numRegistroAcuerdoFacturacionField = value;
			}
		}

		/// <remarks/>
		public string ImporteTotal
		{
			get
			{
				return this.importeTotalField;
			}
			set
			{
				this.importeTotalField = value;
			}
		}

		/// <remarks/>
		public string BaseImponibleACoste
		{
			get
			{
				return this.baseImponibleACosteField;
			}
			set
			{
				this.baseImponibleACosteField = value;
			}
		}

		/// <remarks/>
		public string DescripcionOperacion
		{
			get
			{
				return this.descripcionOperacionField;
			}
			set
			{
				this.descripcionOperacionField = value;
			}
		}

		/// <remarks/>
		public string RefExterna
		{
			get
			{
				return this.refExternaField;
			}
			set
			{
				this.refExternaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FacturaSimplificadaArticulos7.2_7.3")]
		public string FacturaSimplificadaArticulos72_73
		{
			get
			{
				return this.facturaSimplificadaArticulos72_73Field;
			}
			set
			{
				this.facturaSimplificadaArticulos72_73Field = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaEntidadSucedida EntidadSucedida
		{
			get
			{
				return this.entidadSucedidaField;
			}
			set
			{
				this.entidadSucedidaField = value;
			}
		}

		/// <remarks/>
		public string RegPrevioGGEEoREDEMEoCompetencia
		{
			get
			{
				return this.regPrevioGGEEoREDEMEoCompetenciaField;
			}
			set
			{
				this.regPrevioGGEEoREDEMEoCompetenciaField = value;
			}
		}

		/// <remarks/>
		public string Macrodato
		{
			get
			{
				return this.macrodatoField;
			}
			set
			{
				this.macrodatoField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDesgloseFactura DesgloseFactura
		{
			get
			{
				return this.desgloseFacturaField;
			}
			set
			{
				this.desgloseFacturaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaContraparte Contraparte
		{
			get
			{
				return this.contraparteField;
			}
			set
			{
				this.contraparteField = value;
			}
		}

		/// <remarks/>
		public string FechaRegContable
		{
			get
			{
				return this.fechaRegContableField;
			}
			set
			{
				this.fechaRegContableField = value;
			}
		}

		/// <remarks/>
		public string CuotaDeducible
		{
			get
			{
				return this.cuotaDeducibleField;
			}
			set
			{
				this.cuotaDeducibleField = value;
			}
		}

		/// <remarks/>
		public string Pagos
		{
			get
			{
				return this.pagosField;
			}
			set
			{
				this.pagosField = value;
			}
		}
		/// <remarks/>
		public string ADeducirEnPeriodoPosterior
		{
			get
			{
				return this.aDeducirEnPeriodoPosteriorField;
			}
			set
			{
				this.aDeducirEnPeriodoPosteriorField = value;
			}
		}
		/// <remarks/>
		public string EjercicioDeduccion
		{
			get
			{
				return this.ejercicioDeduccionField;
			}
			set
			{
				this.ejercicioDeduccionField = value;
			}
		}
		/// <remarks/>
		public string PeriodoDeduccion
		{
			get
			{
				return this.periodoDeduccionField;
			}
			set
			{
				this.periodoDeduccionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDesgloseFactura
	{

		private RespuestaConsultaInversionSujetoPasivo inversionSujetoPasivoField;

		private RespuestaConsultaDetalleIVA[] desgloseIVAField;

		private RespuestaConsultaSujeta sujetaField;

		private RespuestaConsultaNoSujeta noSujetaField;
		private RespuestaConsultaDetalleIGIC[] desgloseIGICField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaSujeta Sujeta
		{
			get
			{
				return this.sujetaField;
			}
			set
			{
				this.sujetaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaNoSujeta NoSujeta
		{
			get
			{
				return this.noSujetaField;
			}
			set
			{
				this.noSujetaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("InversionSujetoPasivo")]
		public RespuestaConsultaInversionSujetoPasivo InversionSujetoPasivo
		{
			get
			{
				return this.inversionSujetoPasivoField;
			}
			set
			{
				this.inversionSujetoPasivoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIVA", IsNullable = false)]
		public RespuestaConsultaDetalleIVA[] DesgloseIVA
		{
			get
			{
				return this.desgloseIVAField;
			}
			set
			{
				this.desgloseIVAField = value;
			}
		}

		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIGIC", IsNullable = false)]
		public RespuestaConsultaDetalleIGIC[] DesgloseIGIC
		{
			get
			{
				return this.desgloseIGICField;
			}
			set
			{
				this.desgloseIGICField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaInversionSujetoPasivo
	{

		private RespuestaConsultaDetalleIVA[] detalleIVAField;
		private RespuestaConsultaDetalleIGIC[] detalleIGICField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DetalleIVA", IsNullable = false)]
		public RespuestaConsultaDetalleIVA[] DetalleIVA
		{
			get
			{
				return this.detalleIVAField;
			}
			set
			{
				this.detalleIVAField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DetalleIGIC", IsNullable = false)]
		public RespuestaConsultaDetalleIGIC[] DetalleIGIC
		{
			get
			{
				return this.detalleIGICField;
			}
			set
			{
				this.detalleIGICField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaDesgloseIVA
	{

		private RespuestaConsultaDetalleIVA detalleIVAField;

		/// <remarks/>
		public RespuestaConsultaDetalleIVA DetalleIVA
		{
			get
			{
				return this.detalleIVAField;
			}
			set
			{
				this.detalleIVAField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class RespuestaConsultaDetalleIVA
	{

		private string tipoImpositivoField;

		private string baseImponibleField;

		private string cuotaSoportadaField;

		private string cuotaRepercutidaField;

		private string tipoRecargoEquivalenciaField;

		private string cuotaRecargoEquivalenciaField;

		private string porcentCompensacionREAGYPField;

		private string importeCompensacionREAGYPField;
		private string bienInversionField;

		/// <remarks/>
		public string TipoImpositivo
		{
			get
			{
				return this.tipoImpositivoField;
			}
			set
			{
				this.tipoImpositivoField = value;
			}
		}

		/// <remarks/>
		public string BaseImponible
		{
			get
			{
				return this.baseImponibleField;
			}
			set
			{
				this.baseImponibleField = value;
			}
		}

		/// <remarks/>
		public string CuotaSoportada
		{
			get
			{
				return this.cuotaSoportadaField;
			}
			set
			{
				this.cuotaSoportadaField = value;
			}
		}

		/// <remarks/>
		public string CuotaRepercutida
		{
			get
			{
				return this.cuotaRepercutidaField;
			}
			set
			{
				this.cuotaRepercutidaField = value;
			}
		}

		/// <remarks/>
		public string TipoRecargoEquivalencia
		{
			get
			{
				return this.tipoRecargoEquivalenciaField;
			}
			set
			{
				this.tipoRecargoEquivalenciaField = value;
			}
		}

		/// <remarks/>
		public string CuotaRecargoEquivalencia
		{
			get
			{
				return this.cuotaRecargoEquivalenciaField;
			}
			set
			{
				this.cuotaRecargoEquivalenciaField = value;
			}
		}

		/// <remarks/>
		public string PorcentCompensacionREAGYP
		{
			get
			{
				return this.porcentCompensacionREAGYPField;
			}
			set
			{
				this.porcentCompensacionREAGYPField = value;
			}
		}

		/// <remarks/>
		public string ImporteCompensacionREAGYP
		{
			get
			{
				return this.importeCompensacionREAGYPField;
			}
			set
			{
				this.importeCompensacionREAGYPField = value;
			}
		}

		/// <remarks/>
		public string BienInversion
		{
			get
			{
				return this.bienInversionField;
			}
			set
			{
				this.bienInversionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/igic/ws/SuministroInformacion.xsd")]
	public partial class RespuestaConsultaDetalleIGIC
	{

		private string tipoImpositivoField;

		private string baseImponibleField;

		private string cuotaSoportadaField;

		private string cuotaRepercutidaField;

		private string tipoRecargoEquivalenciaField;

		private string cuotaRecargoEquivalenciaField;

		private string porcentCompensacionREAGYPField;

		private string importeCompensacionREAGYPField;
		private string cargaImpositivaImplicitaField;
		private string cuotaRecargoMinoristaField;
		private string bienInversionField;

		/// <remarks/>
		public string TipoImpositivo
		{
			get
			{
				return this.tipoImpositivoField;
			}
			set
			{
				this.tipoImpositivoField = value;
			}
		}

		/// <remarks/>
		public string BaseImponible
		{
			get
			{
				return this.baseImponibleField;
			}
			set
			{
				this.baseImponibleField = value;
			}
		}

		/// <remarks/>
		public string CuotaSoportada
		{
			get
			{
				return this.cuotaSoportadaField;
			}
			set
			{
				this.cuotaSoportadaField = value;
			}
		}

		/// <remarks/>
		public string CuotaRepercutida
		{
			get
			{
				return this.cuotaRepercutidaField;
			}
			set
			{
				this.cuotaRepercutidaField = value;
			}
		}

		/// <remarks/>
		public string CargaImpositivaImplicita
		{
			get
			{
				return this.cargaImpositivaImplicitaField;
			}
			set
			{
				this.cargaImpositivaImplicitaField = value;
			}
		}

		/// <remarks/>
		public string CuotaRecargoMinorista
		{
			get
			{
				return this.cuotaRecargoMinoristaField;
			}
			set
			{
				this.cuotaRecargoMinoristaField = value;
			}
		}

		/// <remarks/>
		public string TipoRecargoEquivalencia
		{
			get
			{
				return this.tipoRecargoEquivalenciaField;
			}
			set
			{
				this.tipoRecargoEquivalenciaField = value;
			}
		}

		/// <remarks/>
		public string CuotaRecargoEquivalencia
		{
			get
			{
				return this.cuotaRecargoEquivalenciaField;
			}
			set
			{
				this.cuotaRecargoEquivalenciaField = value;
			}
		}

		/// <remarks/>
		public string PorcentCompensacionREAGYP
		{
			get
			{
				return this.porcentCompensacionREAGYPField;
			}
			set
			{
				this.porcentCompensacionREAGYPField = value;
			}
		}

		/// <remarks/>
		public string ImporteCompensacionREAGYP
		{
			get
			{
				return this.importeCompensacionREAGYPField;
			}
			set
			{
				this.importeCompensacionREAGYPField = value;
			}
		}
		/// <remarks/>
		public string BienInversion
		{
			get
			{
				return this.bienInversionField;
			}
			set
			{
				this.bienInversionField = value;
			}
		}
	}



	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute("Envelope", AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	[System.Xml.Serialization.XmlRootAttribute(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
	public partial class RespuestaConsultaEnvelope
	{

		private object headerField;

		private RespuestaConsultaBody bodyField;

		/// <remarks/>
		public object Header
		{
			get
			{
				return this.headerField;
			}
			set
			{
				this.headerField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaBody Body
		{
			get
			{
				return this.bodyField;
			}
			set
			{
				this.bodyField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	public partial class RespuestaConsultaBody
	{

		private RespuestaConsultaLRFacturasEmitidas respuestaConsultaLRFacturasEmitidasField;

		private RespuestaConsultaLRFacturasRecibidas respuestaConsultaLRFacturasRecibidasField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
		public RespuestaConsultaLRFacturasEmitidas RespuestaConsultaLRFacturasEmitidas
		{
			get
			{
				return this.respuestaConsultaLRFacturasEmitidasField;
			}
			set
			{
				this.respuestaConsultaLRFacturasEmitidasField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
		public RespuestaConsultaLRFacturasRecibidas RespuestaConsultaLRFacturasRecibidas
		{
			get
			{
				return this.respuestaConsultaLRFacturasRecibidasField;
			}
			set
			{
				this.respuestaConsultaLRFacturasRecibidasField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd", IsNullable = false)]
	public partial class RespuestaConsultaLRFacturasEmitidas
	{

		private RespuestaConsultaCabecera cabeceraField;

		private RespuestaConsultaPeriodoLiquidacion periodoLiquidacionField;

		private string indicadorPaginacionField;

		private string resultadoConsultaField;

		private RegistroRespuestaConsultaLRFacturasEmitidas[] registroRespuestaConsultaLRFacturasEmitidasField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaCabecera Cabecera
		{
			get
			{
				return this.cabeceraField;
			}
			set
			{
				this.cabeceraField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaPeriodoLiquidacion PeriodoLiquidacion
		{
			get
			{
				return this.periodoLiquidacionField;
			}
			set
			{
				this.periodoLiquidacionField = value;
			}
		}

		/// <remarks/>
		public string IndicadorPaginacion
		{
			get
			{
				return this.indicadorPaginacionField;
			}
			set
			{
				this.indicadorPaginacionField = value;
			}
		}

		/// <remarks/>
		public string ResultadoConsulta
		{
			get
			{
				return this.resultadoConsultaField;
			}
			set
			{
				this.resultadoConsultaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("RegistroRespuestaConsultaLRFacturasEmitidas")]
		public RegistroRespuestaConsultaLRFacturasEmitidas[] RegistroRespuestaConsultaLRFacturasEmitidas
		{
			get
			{
				return this.registroRespuestaConsultaLRFacturasEmitidasField;
			}
			set
			{
				this.registroRespuestaConsultaLRFacturasEmitidasField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaCabecera
	{

		private string iDVersionSiiField;

		private RespuestaConsultaTitular titularField;

		/// <remarks/>
		public string IDVersionSii
		{
			get
			{
				return this.iDVersionSiiField;
			}
			set
			{
				this.iDVersionSiiField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaTitular Titular
		{
			get
			{
				return this.titularField;
			}
			set
			{
				this.titularField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class RespuestaConsultaTitular
	{

		private string nombreRazonField;

		private string nIFField;

		/// <remarks/>
		public string NombreRazon
		{
			get
			{
				return this.nombreRazonField;
			}
			set
			{
				this.nombreRazonField = value;
			}
		}

		/// <remarks/>
		public string NIF
		{
			get
			{
				return this.nIFField;
			}
			set
			{
				this.nIFField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaPeriodoLiquidacion
	{

		private string ejercicioField;

		private string periodoField;

		/// <remarks/>
		public string Ejercicio
		{
			get
			{
				return this.ejercicioField;
			}
			set
			{
				this.ejercicioField = value;
			}
		}

		/// <remarks/>
		public string Periodo
		{
			get
			{
				return this.periodoField;
			}
			set
			{
				this.periodoField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RegistroRespuestaConsultaLRFacturasEmitidas
	{

		private RespuestaConsultaIDFactura iDFacturaField;

		private RespuestaConsultaDatosFacturaEmitida datosFacturaEmitidaField;

		private RespuestaConsultaDatosPresentacion datosPresentacionField;

		private RespuestaConsultaEstadoFactura estadoFacturaField;

		private RespuestaConsultaDatosDescuadreContraparte datosDescuadreContraparteField;

		/// <remarks/>
		public RespuestaConsultaIDFactura IDFactura
		{
			get
			{
				return this.iDFacturaField;
			}
			set
			{
				this.iDFacturaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosFacturaEmitida DatosFacturaEmitida
		{
			get
			{
				return this.datosFacturaEmitidaField;
			}
			set
			{
				this.datosFacturaEmitidaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosPresentacion DatosPresentacion
		{
			get
			{
				return this.datosPresentacionField;
			}
			set
			{
				this.datosPresentacionField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaEstadoFactura EstadoFactura
		{
			get
			{
				return this.estadoFacturaField;
			}
			set
			{
				this.estadoFacturaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosDescuadreContraparte DatosDescuadreContraparte
		{
			get
			{
				return this.datosDescuadreContraparteField;
			}
			set
			{
				this.datosDescuadreContraparteField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaIDFactura
	{

		private RespuestaConsultaIDEmisorFactura iDEmisorFacturaField;

		private string numSerieFacturaEmisorField;

		private string numSerieFacturaEmisorResumenFinField;

		private string fechaExpedicionFacturaEmisorField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaIDEmisorFactura IDEmisorFactura
		{
			get
			{
				return this.iDEmisorFacturaField;
			}
			set
			{
				this.iDEmisorFacturaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NumSerieFacturaEmisor
		{
			get
			{
				return this.numSerieFacturaEmisorField;
			}
			set
			{
				this.numSerieFacturaEmisorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NumSerieFacturaEmisorResumenFin
		{
			get
			{
				return this.numSerieFacturaEmisorResumenFinField;
			}
			set
			{
				this.numSerieFacturaEmisorResumenFinField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string FechaExpedicionFacturaEmisor
		{
			get
			{
				return this.fechaExpedicionFacturaEmisorField;
			}
			set
			{
				this.fechaExpedicionFacturaEmisorField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaIDEmisorFactura
	{

		private string nIFField;
		private RespuestaConsultaIDOtro iDOtroField;
		private string nombreRazonField;
		private string nIFRepresentanteField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NombreRazon
		{
			get
			{
				return this.nombreRazonField;
			}
			set
			{
				this.nombreRazonField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NIFRepresentante
		{
			get
			{
				return this.nIFRepresentanteField;
			}
			set
			{
				this.nIFRepresentanteField = value;
			}
		}

		/// <remarks/>
		public string NIF
		{
			get
			{
				return this.nIFField;
			}
			set
			{
				this.nIFField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaIDOtro IDOtro
		{
			get
			{
				return this.iDOtroField;
			}
			set
			{
				this.iDOtroField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDatosFacturaEmitida
	{

		private string tipoFacturaField;

		private string tipoRectificativaField;

		private RespuestaConsultaIDFacturaAgrupada[] facturasAgrupadasField;

		private RespuestaConsultaIDFacturaRectificada[] facturasRectificadasField;

		private RespuestaConsultaImporteRectificacion importeRectificacionField;

		private string fechaOperacionField;

		private string claveRegimenEspecialOTrascendenciaField;

		private string claveRegimenEspecialOTrascendenciaAdicional1Field;

		private string claveRegimenEspecialOTrascendenciaAdicional2Field;

		private string numRegistroAcuerdoFacturacionField;

		private string importeTotalField;

		private string baseImponibleACosteField;

		private string descripcionOperacionField;

		private string refExternaField;

		private string facturaSimplificadaArticulos72_73Field;

		private RespuestaConsultaEntidadSucedida entidadSucedidaField;

		private string regPrevioGGEEoREDEMEoCompetenciaField;

		private string macrodatoField;

		private RespuestaConsultaDetalleInmueble[] datosInmuebleField;

		private string importeTransmisionInmueblesSujetoAIVAField;

		private string emitidaPorTercerosODestinatarioField;

		private string facturacionDispAdicionalTerceraYsextayDelMercadoOrganizadoDelGasField;

		private string variosDestinatariosField;

		private string cuponField;

		private string facturaSinIdentifDestinatarioAritculo61dField;

		private RespuestaConsultaContraparte contraparteField;

		private RespuestaConsultaTipoDesglose tipoDesgloseField;

		private string cobrosField;

		private string numRegistroAutorizacionFacturacionField;

		private string regPrevioGGEEoREDEMEField;

		private RespuestaConsultaDatosArticulo25 datosArticulo25Field;

		private string importeTransmisionInmueblesSujetoAIGICField;

		/// <remarks/>
		public string TipoFactura
		{
			get
			{
				return this.tipoFacturaField;
			}
			set
			{
				this.tipoFacturaField = value;
			}
		}

		/// <remarks/>
		public string TipoRectificativa
		{
			get
			{
				return this.tipoRectificativaField;
			}
			set
			{
				this.tipoRectificativaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("IDFacturaAgrupada", IsNullable = false)]
		public RespuestaConsultaIDFacturaAgrupada[] FacturasAgrupadas
		{
			get
			{
				return this.facturasAgrupadasField;
			}
			set
			{
				this.facturasAgrupadasField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("IDFacturaRectificada", IsNullable = false)]
		public RespuestaConsultaIDFacturaRectificada[] FacturasRectificadas
		{
			get
			{
				return this.facturasRectificadasField;
			}
			set
			{
				this.facturasRectificadasField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaImporteRectificacion ImporteRectificacion
		{
			get
			{
				return this.importeRectificacionField;
			}
			set
			{
				this.importeRectificacionField = value;
			}
		}

		/// <remarks/>
		public string FechaOperacion
		{
			get
			{
				return this.fechaOperacionField;
			}
			set
			{
				this.fechaOperacionField = value;
			}
		}

		/// <remarks/>
		public string ClaveRegimenEspecialOTrascendencia
		{
			get
			{
				return this.claveRegimenEspecialOTrascendenciaField;
			}
			set
			{
				this.claveRegimenEspecialOTrascendenciaField = value;
			}
		}

		/// <remarks/>
		public string ClaveRegimenEspecialOTrascendenciaAdicional1
		{
			get
			{
				return this.claveRegimenEspecialOTrascendenciaAdicional1Field;
			}
			set
			{
				this.claveRegimenEspecialOTrascendenciaAdicional1Field = value;
			}
		}

		/// <remarks/>
		public string ClaveRegimenEspecialOTrascendenciaAdicional2
		{
			get
			{
				return this.claveRegimenEspecialOTrascendenciaAdicional2Field;
			}
			set
			{
				this.claveRegimenEspecialOTrascendenciaAdicional2Field = value;
			}
		}

		/// <remarks/>
		public string NumRegistroAcuerdoFacturacion
		{
			get
			{
				return this.numRegistroAcuerdoFacturacionField;
			}
			set
			{
				this.numRegistroAcuerdoFacturacionField = value;
			}
		}

		/// <remarks/>
		public string ImporteTotal
		{
			get
			{
				return this.importeTotalField;
			}
			set
			{
				this.importeTotalField = value;
			}
		}

		/// <remarks/>
		public string BaseImponibleACoste
		{
			get
			{
				return this.baseImponibleACosteField;
			}
			set
			{
				this.baseImponibleACosteField = value;
			}
		}

		/// <remarks/>
		public string DescripcionOperacion
		{
			get
			{
				return this.descripcionOperacionField;
			}
			set
			{
				this.descripcionOperacionField = value;
			}
		}

		/// <remarks/>
		public string RefExterna
		{
			get
			{
				return this.refExternaField;
			}
			set
			{
				this.refExternaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FacturaSimplificadaArticulos7.2_7.3")]
		public string FacturaSimplificadaArticulos72_73
		{
			get
			{
				return this.facturaSimplificadaArticulos72_73Field;
			}
			set
			{
				this.facturaSimplificadaArticulos72_73Field = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaEntidadSucedida EntidadSucedida
		{
			get
			{
				return this.entidadSucedidaField;
			}
			set
			{
				this.entidadSucedidaField = value;
			}
		}

		/// <remarks/>
		public string RegPrevioGGEEoREDEMEoCompetencia
		{
			get
			{
				return this.regPrevioGGEEoREDEMEoCompetenciaField;
			}
			set
			{
				this.regPrevioGGEEoREDEMEoCompetenciaField = value;
			}
		}

		/// <remarks/>
		public string Macrodato
		{
			get
			{
				return this.macrodatoField;
			}
			set
			{
				this.macrodatoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleInmueble", IsNullable = false)]
		public RespuestaConsultaDetalleInmueble[] DatosInmueble
		{
			get
			{
				return this.datosInmuebleField;
			}
			set
			{
				this.datosInmuebleField = value;
			}
		}

		/// <remarks/>
		public string ImporteTransmisionInmueblesSujetoAIVA
		{
			get
			{
				return this.importeTransmisionInmueblesSujetoAIVAField;
			}
			set
			{
				this.importeTransmisionInmueblesSujetoAIVAField = value;
			}
		}

		/// <remarks/>
		public string EmitidaPorTercerosODestinatario
		{
			get
			{
				return this.emitidaPorTercerosODestinatarioField;
			}
			set
			{
				this.emitidaPorTercerosODestinatarioField = value;
			}
		}

		/// <remarks/>
		public string FacturacionDispAdicionalTerceraYsextayDelMercadoOrganizadoDelGas
		{
			get
			{
				return this.facturacionDispAdicionalTerceraYsextayDelMercadoOrganizadoDelGasField;
			}
			set
			{
				this.facturacionDispAdicionalTerceraYsextayDelMercadoOrganizadoDelGasField = value;
			}
		}

		/// <remarks/>
		public string VariosDestinatarios
		{
			get
			{
				return this.variosDestinatariosField;
			}
			set
			{
				this.variosDestinatariosField = value;
			}
		}

		/// <remarks/>
		public string Cupon
		{
			get
			{
				return this.cuponField;
			}
			set
			{
				this.cuponField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FacturaSinIdentifDestinatarioAritculo6.1.d")]
		public string FacturaSinIdentifDestinatarioAritculo61d
		{
			get
			{
				return this.facturaSinIdentifDestinatarioAritculo61dField;
			}
			set
			{
				this.facturaSinIdentifDestinatarioAritculo61dField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaContraparte Contraparte
		{
			get
			{
				return this.contraparteField;
			}
			set
			{
				this.contraparteField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaTipoDesglose TipoDesglose
		{
			get
			{
				return this.tipoDesgloseField;
			}
			set
			{
				this.tipoDesgloseField = value;
			}
		}

		/// <remarks/>
		public string NumRegistroAutorizacionFacturacion
		{
			get
			{
				return this.numRegistroAutorizacionFacturacionField;
			}
			set
			{
				this.numRegistroAutorizacionFacturacionField = value;
			}
		}

		/// <remarks/>
		public string RegPrevioGGEEoREDEME
		{
			get
			{
				return this.regPrevioGGEEoREDEMEField;
			}
			set
			{
				this.regPrevioGGEEoREDEMEField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDatosArticulo25 DatosArticulo25
		{
			get
			{
				return this.datosArticulo25Field;
			}
			set
			{
				this.datosArticulo25Field = value;
			}
		}

		/// <remarks/>
		public string ImporteTransmisionInmueblesSujetoAIGIC
		{
			get
			{
				return this.importeTransmisionInmueblesSujetoAIGICField;
			}
			set
			{
				this.importeTransmisionInmueblesSujetoAIGICField = value;
			}
		}

		/// <remarks/>
		public string Cobros
		{
			get
			{
				return this.cobrosField;
			}
			set
			{
				this.cobrosField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaIDFacturaAgrupada
	{

		private string numSerieFacturaEmisorField;

		private string fechaExpedicionFacturaEmisorField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NumSerieFacturaEmisor
		{
			get
			{
				return this.numSerieFacturaEmisorField;
			}
			set
			{
				this.numSerieFacturaEmisorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string FechaExpedicionFacturaEmisor
		{
			get
			{
				return this.fechaExpedicionFacturaEmisorField;
			}
			set
			{
				this.fechaExpedicionFacturaEmisorField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaIDFacturaRectificada
	{

		private string numSerieFacturaEmisorField;

		private string fechaExpedicionFacturaEmisorField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NumSerieFacturaEmisor
		{
			get
			{
				return this.numSerieFacturaEmisorField;
			}
			set
			{
				this.numSerieFacturaEmisorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string FechaExpedicionFacturaEmisor
		{
			get
			{
				return this.fechaExpedicionFacturaEmisorField;
			}
			set
			{
				this.fechaExpedicionFacturaEmisorField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaImporteRectificacion
	{

		private string baseRectificadaField;

		private string cuotaRectificadaField;

		private string cuotaRecargoRectificadoField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string BaseRectificada
		{
			get
			{
				return this.baseRectificadaField;
			}
			set
			{
				this.baseRectificadaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string CuotaRectificada
		{
			get
			{
				return this.cuotaRectificadaField;
			}
			set
			{
				this.cuotaRectificadaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string CuotaRecargoRectificado
		{
			get
			{
				return this.cuotaRecargoRectificadoField;
			}
			set
			{
				this.cuotaRecargoRectificadoField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaEntidadSucedida
	{

		private string nombreRazonField;

		private string nIFField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NombreRazon
		{
			get
			{
				return this.nombreRazonField;
			}
			set
			{
				this.nombreRazonField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NIF
		{
			get
			{
				return this.nIFField;
			}
			set
			{
				this.nIFField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDetalleInmueble
	{

		private string situacionInmuebleField;

		private string referenciaCatastralField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string SituacionInmueble
		{
			get
			{
				return this.situacionInmuebleField;
			}
			set
			{
				this.situacionInmuebleField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string ReferenciaCatastral
		{
			get
			{
				return this.referenciaCatastralField;
			}
			set
			{
				this.referenciaCatastralField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaContraparte
	{

		private string nombreRazonField;

		private string nIFRepresentanteField;

		private string nIFField;

		private RespuestaConsultaIDOtro iDOtroField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NombreRazon
		{
			get
			{
				return this.nombreRazonField;
			}
			set
			{
				this.nombreRazonField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NIFRepresentante
		{
			get
			{
				return this.nIFRepresentanteField;
			}
			set
			{
				this.nIFRepresentanteField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NIF
		{
			get
			{
				return this.nIFField;
			}
			set
			{
				this.nIFField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaIDOtro IDOtro
		{
			get
			{
				return this.iDOtroField;
			}
			set
			{
				this.iDOtroField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaIDOtro
	{

		private string codigoPaisField;

		private string iDTypeField;

		private string idField;

		/// <remarks/>
		public string CodigoPais
		{
			get
			{
				return this.codigoPaisField;
			}
			set
			{
				this.codigoPaisField = value;
			}
		}

		/// <remarks/>
		public string IDType
		{
			get
			{
				return this.iDTypeField;
			}
			set
			{
				this.iDTypeField = value;
			}
		}

		/// <remarks/>
		public string ID
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaTipoDesglose
	{

		private RespuestaConsultaDesgloseFactura desgloseFacturaField;

		private RespuestaConsultaDesgloseTipoOperacion desgloseTipoOperacionField;

		/// <remarks/>
		public RespuestaConsultaDesgloseFactura DesgloseFactura
		{
			get
			{
				return this.desgloseFacturaField;
			}
			set
			{
				this.desgloseFacturaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaDesgloseTipoOperacion DesgloseTipoOperacion
		{
			get
			{
				return this.desgloseTipoOperacionField;
			}
			set
			{
				this.desgloseTipoOperacionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaSujeta
	{

		private RespuestaConsultaDetalleExenta[] exentaField;

		private RespuestaConsultaNoExenta noExentaField;

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleExenta", IsNullable = false)]
		public RespuestaConsultaDetalleExenta[] Exenta
		{
			get
			{
				return this.exentaField;
			}
			set
			{
				this.exentaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaNoExenta NoExenta
		{
			get
			{
				return this.noExentaField;
			}
			set
			{
				this.noExentaField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class RespuestaConsultaExenta
	{

		private RespuestaConsultaDetalleExenta detalleExentaField;

		/// <remarks/>
		public RespuestaConsultaDetalleExenta DetalleExenta
		{
			get
			{
				return this.detalleExentaField;
			}
			set
			{
				this.detalleExentaField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class RespuestaConsultaDetalleExenta
	{

		private string causaExencionField;

		private string baseImponibleField;

		/// <remarks/>
		public string CausaExencion
		{
			get
			{
				return this.causaExencionField;
			}
			set
			{
				this.causaExencionField = value;
			}
		}

		/// <remarks/>
		public string BaseImponible
		{
			get
			{
				return this.baseImponibleField;
			}
			set
			{
				this.baseImponibleField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class RespuestaConsultaNoExenta
	{

		private string tipoNoExentaField;

		private RespuestaConsultaDetalleIVA[] desgloseIVAField;
		private RespuestaConsultaDetalleIGIC[] desgloseIGICField;

		/// <remarks/>
		public string TipoNoExenta
		{
			get
			{
				return this.tipoNoExentaField;
			}
			set
			{
				this.tipoNoExentaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIVA", IsNullable = false)]
		public RespuestaConsultaDetalleIVA[] DesgloseIVA
		{
			get
			{
				return this.desgloseIVAField;
			}
			set
			{
				this.desgloseIVAField = value;
			}
		}

		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIGIC", IsNullable = false)]
		public RespuestaConsultaDetalleIGIC[] DesgloseIGIC
		{
			get
			{
				return this.desgloseIGICField;
			}
			set
			{
				this.desgloseIGICField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaNoSujeta
	{

		private string importePorArticulos7_14_OtrosField;

		private string importeTAIReglasLocalizacionField;

		/// <remarks/>
		public string ImportePorArticulos7_14_Otros
		{
			get
			{
				return this.importePorArticulos7_14_OtrosField;
			}
			set
			{
				this.importePorArticulos7_14_OtrosField = value;
			}
		}

		/// <remarks/>
		public string ImporteTAIReglasLocalizacion
		{
			get
			{
				return this.importeTAIReglasLocalizacionField;
			}
			set
			{
				this.importeTAIReglasLocalizacionField = value;
			}
		}

		public string ImportePorArticulos9_Otros { get; set; }
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDesgloseTipoOperacion
	{

		private RespuestaConsultaPrestacionServicios prestacionServiciosField;

		private RespuestaConsultaEntrega entregaField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaPrestacionServicios PrestacionServicios
		{
			get
			{
				return this.prestacionServiciosField;
			}
			set
			{
				this.prestacionServiciosField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaEntrega Entrega
		{
			get
			{
				return this.entregaField;
			}
			set
			{
				this.entregaField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaPrestacionServicios
	{

		private RespuestaConsultaSujeta sujetaField;

		private RespuestaConsultaNoSujeta noSujetaField;

		/// <remarks/>
		public RespuestaConsultaSujeta Sujeta
		{
			get
			{
				return this.sujetaField;
			}
			set
			{
				this.sujetaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaNoSujeta NoSujeta
		{
			get
			{
				return this.noSujetaField;
			}
			set
			{
				this.noSujetaField = value;
			}
		}
	}

	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaEntrega
	{

		private RespuestaConsultaSujeta sujetaField;

		private RespuestaConsultaNoSujeta noSujetaField;

		/// <remarks/>
		public RespuestaConsultaSujeta Sujeta
		{
			get
			{
				return this.sujetaField;
			}
			set
			{
				this.sujetaField = value;
			}
		}

		/// <remarks/>
		public RespuestaConsultaNoSujeta NoSujeta
		{
			get
			{
				return this.noSujetaField;
			}
			set
			{
				this.noSujetaField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDatosPresentacion
	{

		private string nIFPresentadorField;

		private string timestampPresentacionField;

		private string cSVField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NIFPresentador
		{
			get
			{
				return this.nIFPresentadorField;
			}
			set
			{
				this.nIFPresentadorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string TimestampPresentacion
		{
			get
			{
				return this.timestampPresentacionField;
			}
			set
			{
				this.timestampPresentacionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string CSV
		{
			get
			{
				return this.cSVField;
			}
			set
			{
				this.cSVField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaEstadoFactura
	{

		private string estadoCuadreField;

		private string timestampEstadoCuadreField;

		private string timestampUltimaModificacionField;

		private string estadoRegistroField;

		private string codigoErrorRegistroField;

		private string descripcionErrorRegistroField;

		/// <remarks/>
		public string EstadoCuadre
		{
			get
			{
				return this.estadoCuadreField;
			}
			set
			{
				this.estadoCuadreField = value;
			}
		}

		/// <remarks/>
		
		public string TimestampEstadoCuadre
		{
			get
			{
				return this.timestampEstadoCuadreField;
			}
			set
			{
				this.timestampEstadoCuadreField = value;
			}
		}

		/// <remarks/>
		
		public string TimestampUltimaModificacion
		{
			get
			{
				return this.timestampUltimaModificacionField;
			}
			set
			{
				this.timestampUltimaModificacionField = value;
			}
		}

		/// <remarks/>
		public string EstadoRegistro
		{
			get
			{
				return this.estadoRegistroField;
			}
			set
			{
				this.estadoRegistroField = value;
			}
		}

		/// <remarks/>
		public string CodigoErrorRegistro
		{
			get
			{
				return this.codigoErrorRegistroField;
			}
			set
			{
				this.codigoErrorRegistroField = value;
			}
		}

		/// <remarks/>
		public string DescripcionErrorRegistro
		{
			get
			{
				return this.descripcionErrorRegistroField;
			}
			set
			{
				this.descripcionErrorRegistroField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDatosDescuadreContraparte
	{

		private string sumBaseImponibleISPField;

		private string sumBaseImponibleField;

		private string sumCuotaField;

		private string sumCuotaRecargoEquivalenciaField;

		private string importeTotalField;

		/// <remarks/>
		public string SumBaseImponibleISP
		{
			get
			{
				return this.sumBaseImponibleISPField;
			}
			set
			{
				this.sumBaseImponibleISPField = value;
			}
		}

		/// <remarks/>
		public string SumBaseImponible
		{
			get
			{
				return this.sumBaseImponibleField;
			}
			set
			{
				this.sumBaseImponibleField = value;
			}
		}

		/// <remarks/>
		public string SumCuota
		{
			get
			{
				return this.sumCuotaField;
			}
			set
			{
				this.sumCuotaField = value;
			}
		}

		/// <remarks/>
		public string SumCuotaRecargoEquivalencia
		{
			get
			{
				return this.sumCuotaRecargoEquivalenciaField;
			}
			set
			{
				this.sumCuotaRecargoEquivalenciaField = value;
			}
		}

		/// <remarks/>
		public string ImporteTotal
		{
			get
			{
				return this.importeTotalField;
			}
			set
			{
				this.importeTotalField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/igic/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDatosArticulo25
	{

		private RespuestaConsultaDetalleArticulo25 detalleArticulo25Field;

		/// <remarks/>
		public RespuestaConsultaDetalleArticulo25 DetalleArticulo25
		{
			get
			{
				return this.detalleArticulo25Field;
			}
			set
			{
				this.detalleArticulo25Field = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/igic/ws/RespuestaConsultaLR.xsd")]
	public partial class RespuestaConsultaDetalleArticulo25
	{

		private string pagoAnticipadoArt25Field;

		private string tipoBienArt25Field;

		private RespuestaConsultaIDDocumentoArt25 iDDocumentoArt25Field;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/igic/ws/SuministroInformacion.xsd")]
		public string PagoAnticipadoArt25
		{
			get
			{
				return this.pagoAnticipadoArt25Field;
			}
			set
			{
				this.pagoAnticipadoArt25Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/igic/ws/SuministroInformacion.xsd")]
		public string TipoBienArt25
		{
			get
			{
				return this.tipoBienArt25Field;
			}
			set
			{
				this.tipoBienArt25Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/igic/ws/SuministroInformacion.xsd")]
		public RespuestaConsultaIDDocumentoArt25 IDDocumentoArt25
		{
			get
			{
				return this.iDDocumentoArt25Field;
			}
			set
			{
				this.iDDocumentoArt25Field = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/igic/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/igic/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class RespuestaConsultaIDDocumentoArt25
	{

		private string tipoDocumArt25Field;

		private string numeroProtocoloField;

		private string apellidosNombreNotarioField;

		/// <remarks/>
		public string TipoDocumArt25
		{
			get
			{
				return this.tipoDocumArt25Field;
			}
			set
			{
				this.tipoDocumArt25Field = value;
			}
		}

		/// <remarks/>
		public string NumeroProtocolo
		{
			get
			{
				return this.numeroProtocoloField;
			}
			set
			{
				this.numeroProtocoloField = value;
			}
		}

		/// <remarks/>
		public string ApellidosNombreNotario
		{
			get
			{
				return this.apellidosNombreNotarioField;
			}
			set
			{
				this.apellidosNombreNotarioField = value;
			}
		}
	}

}
