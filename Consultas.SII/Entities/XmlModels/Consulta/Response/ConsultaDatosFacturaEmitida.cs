using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{

	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class ConsultaDetalleInmueble
	{

		private string situacionInmuebleField;

		private string referenciaCatastralField;

		/// <remarks/>
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
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public class ConsultaEntidadSucedida
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
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class ConsultaImporteRectificacion
	{

		private string baseRectificadaField;

		private string cuotaRectificadaField;

		private string cargaImpositivaImplicitaRectificadaField;

		private string cuotaRecargoRectificadoField;

		/// <remarks/>
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

		/// <remarks/>
		public string CargaImpositivaImplicitaRectificada
		{
			get
			{
				return this.cargaImpositivaImplicitaRectificadaField;
			}
			set
			{
				this.cargaImpositivaImplicitaRectificadaField = value;
			}
		}
	}
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class ConsultaIDFacturaRectificada
	{

		private string numSerieFacturaEmisorField;

		private string fechaExpedicionFacturaEmisorField;

		/// <remarks/>
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
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class ConsultaIDFacturaAgrupada
	{

		private string numSerieFacturaEmisorField;

		private string fechaExpedicionFacturaEmisorField;

		/// <remarks/>
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
		public string FechaExpedicionFacturaEmisor
		{
			get
			{
				return this.fechaExpedicionFacturaEmisorField.ToString();
			}
			set
			{
				this.fechaExpedicionFacturaEmisorField = value;
			}
		}
	}
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class ConsultaDatosFacturaEmitida
	{

		private string tipoFacturaField;

		private string tipoRectificativaField;

		private string fechaOperacionField;

		private string claveRegimenEspecialOTrascendenciaField;

		private decimal importeTotalField;

		private string descripcionOperacionField;

		private decimal? importeTransmisionSujetoAIVAField;

		private bool importeTransmisionSujetoAIVAFieldSpecified;

		private string emitidaPorTercerosField;

		private string variosDestinatariosField;

		private ConsultaResponseContraparte contraparteField;

		private ConsultaTipoDesglose tipoDesgloseField;

		private string cobrosField;

		private ConsultaIDFacturaAgrupada[] facturasAgrupadasField;

		private ConsultaIDFacturaRectificada[] facturasRectificadasField;

		private ConsultaImporteRectificacion importeRectificacionField;

		private string claveRegimenEspecialOTrascendenciaAdicional1Field;

		private string claveRegimenEspecialOTrascendenciaAdicional2Field;

		private string numRegistroAcuerdoFacturacionField;

		private decimal? baseImponibleACosteField;

		private string refExternaField;

		private string facturaSimplificadaArticulos72_73Field;

		private ConsultaEntidadSucedida entidadSucedidaField;

		private string regPrevioGGEEoREDEMEoCompetenciaField;

		private string macrodatoField;

		private ConsultaDetalleInmueble[] datosInmuebleField;

		private decimal? importeTransmisionInmueblesSujetoAIVAField;

		private string emitidaPorTercerosODestinatarioField;

		private string facturacionDispAdicionalTerceraYsextayDelMercadoOrganizadoDelGasField;

		private string cuponField;

		private string facturaSinIdentifDestinatarioAritculo61dField;

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("IDFacturaAgrupada", IsNullable = false)]
		public ConsultaIDFacturaAgrupada[] FacturasAgrupadas
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
		public ConsultaIDFacturaRectificada[] FacturasRectificadas
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
		public ConsultaImporteRectificacion ImporteRectificacion
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
		public decimal? BaseImponibleACoste
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
		public ConsultaEntidadSucedida EntidadSucedida
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
		public ConsultaDetalleInmueble[] DatosInmueble
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
		public decimal? ImporteTransmisionInmueblesSujetoAIVA
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
		public decimal ImporteTotal
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
		public decimal? ImporteTransmisionSujetoAIVA
		{
			get
			{
				return this.importeTransmisionSujetoAIVAField;
			}
			set
			{
				this.importeTransmisionSujetoAIVAField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ImporteTransmisionSujetoAIVASpecified
		{
			get
			{
				return this.importeTransmisionSujetoAIVAFieldSpecified;
			}
			set
			{
				this.importeTransmisionSujetoAIVAFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string EmitidaPorTerceros
		{
			get
			{
				return this.emitidaPorTercerosField;
			}
			set
			{
				this.emitidaPorTercerosField = value;
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
		public ConsultaResponseContraparte Contraparte
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
		public ConsultaTipoDesglose TipoDesglose
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
}
