using System;
using System.Collections.Generic;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{

	[System.Serializable()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "https://sii.araba.eus/documentos/SuministroInformacion.xsd")]
	public partial class IDFacturaRectificada
	{

		private string numSerieFacturaEmisorField;

		private string fechaExpedicionFacturaEmisorField;

		/// <remarks/>
		public string NumSerieFacturaEmisor
		{
			get => this.numSerieFacturaEmisorField;
			set => this.numSerieFacturaEmisorField = value;
		}

		/// <remarks/>
		public string FechaExpedicionFacturaEmisor
		{
			get => this.fechaExpedicionFacturaEmisorField;
			set => this.fechaExpedicionFacturaEmisorField = value;
		}
	}
	public partial class ImporteRectificacion
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
	public partial class IDFacturaAgrupada
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
	public class EntidadSucedida
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
	public partial class DetalleIGIC
	{

		private string tipoImpositivoField;

		private string baseImponibleField;

		private string cuotaRepercutidaField;

		private string cuotaSoportadaField;

		private string cargaImpositivaImplicitaField;

		private string cuotaRecargoMinoristaField;

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
	public partial class DetalleIVA
	{

		private string tipoImpositivoField;

		private bool tipoImpositivoFieldSpecified;

		private string baseImponibleField;

		private string cuotaSoportadaField;

		private bool cuotaSoportadaFieldSpecified;

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
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TipoImpositivoSpecified
		{
			get
			{
				return this.tipoImpositivoFieldSpecified;
			}
			set
			{
				this.tipoImpositivoFieldSpecified = value;
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
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool CuotaSoportadaSpecified
		{
			get
			{
				return this.cuotaSoportadaFieldSpecified;
			}
			set
			{
				this.cuotaSoportadaFieldSpecified = value;
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
	public partial class InversionSujetoPasivo
	{

		private List<DetalleIVA> detalleIVAField;

		private List<DetalleIGIC> detalleIGICField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DetalleIVA", IsNullable = false)]
		public List<DetalleIVA> DetalleIVA
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
		public List<DetalleIGIC> DetalleIGIC
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
	public partial class NoSujeta
	{

		private string importePorArticulos7_14_OtrosField;

		private string importePorArticulos9_OtrosField;

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
		public string ImportePorArticulos9_Otros
		{
			get
			{
				return this.importePorArticulos9_OtrosField;
			}
			set
			{
				this.importePorArticulos9_OtrosField = value;
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
	}
	public partial class NoExenta
	{

		private string tipoNoExentaField;

		private List<DetalleIVA> desgloseIVAField;

		private List<DetalleIGIC> desgloseIGICField;

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIGIC", IsNullable = false)]
		public List<DetalleIGIC> DesgloseIGIC
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
		public List<DetalleIVA> DesgloseIVA
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
	}
	public partial class Exenta
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
	public partial class DetalleExenta
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
	public partial class Sujeta
	{

		private DetalleExenta[] exentaField;

		private NoExenta noExentaField;

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleExenta", IsNullable = false)]
		public DetalleExenta[] Exenta
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
		public NoExenta NoExenta
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
	public partial class DesgloseFactura
	{
		private InversionSujetoPasivo inversionSujetoPasivoField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("InversionSujetoPasivo")]
		public InversionSujetoPasivo InversionSujetoPasivo
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
		//private List<DetalleIVA> inversionSujetoPasivoField;


		//private List<DetalleIGIC> inversionSujetoPasivoIGICField;

		private List<DetalleIVA> desgloseIVAField;

		private List<DetalleIGIC> desgloseIGICField;

		private Sujeta sujetaField;

		private NoSujeta noSujetaField;

		/// <remarks/>
		public Sujeta Sujeta
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
		public NoSujeta NoSujeta
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

		///// <remarks/>
		//[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIVA", IsNullable = false)]
		//public List<DetalleIVA> InversionSujetoPasivoIVA
		//{
		//    get
		//    {
		//        return this.inversionSujetoPasivoField;
		//    }
		//    set
		//    {
		//        this.inversionSujetoPasivoField = value;
		//    }
		//}


		//[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIGIC", IsNullable = false)]
		//public List<DetalleIGIC> InversionSujetoPasivo
		//{
		//	get
		//	{
		//		return this.inversionSujetoPasivoIGICField;
		//	}
		//	set
		//	{
		//		this.inversionSujetoPasivoIGICField = value;
		//	}
		//}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIVA", IsNullable = false)]
		public List<DetalleIVA> DesgloseIVA
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

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleIGIC", IsNullable = false)]
		public List<DetalleIGIC> DesgloseIGIC
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
	public partial class IDOtro
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
	public partial class Contraparte
	{
		public Contraparte()
		{
			IDOtro = new IDOtro();
		}

		private string nombreRazonField;

		private string nIFRepresentanteField;

		private string nIFField;

		private IDOtro iDOtroField;

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
		public IDOtro IDOtro
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
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class DatosFacturaRecibida
	{

		private string tipoFacturaField;

		private string tipoRectificativaField;


		private IDFacturaAgrupada[] facturasAgrupadasField;

		private IDFacturaRectificada[] facturasRectificadasField;

		private ImporteRectificacion importeRectificacionField;

		private DateTime? fechaOperacionField;

		private string claveRegimenEspecialOTrascendenciaField;

		private string claveRegimenEspecialOTrascendenciaAdicional1Field;

		private string claveRegimenEspecialOTrascendenciaAdicional2Field;

		private string numRegistroAcuerdoFacturacionField;

		private decimal? importeTotalField;

		private decimal? baseImponibleACosteField;

		private string descripcionOperacionField;

		private string refExternaField;

		private string facturaSimplificadaArticulos72_73Field;

		private EntidadSucedida entidadSucedidaField;

		private string regPrevioGGEEoREDEMEoCompetenciaField;

		private string macrodatoField;

		private DesgloseFactura desgloseFacturaField;

		private Contraparte contraparteField;

		private DateTime fechaRegContableField;

		private decimal cuotaDeducibleField;

		private string pagosField;

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
		public IDFacturaAgrupada[] FacturasAgrupadas
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
		public IDFacturaRectificada[] FacturasRectificadas
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
		public ImporteRectificacion ImporteRectificacion
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
		public DateTime? FechaOperacion
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
		public decimal? ImporteTotal
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
		public EntidadSucedida EntidadSucedida
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
		public DesgloseFactura DesgloseFactura
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
		public Contraparte Contraparte
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
		public DateTime FechaRegContable
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
		public decimal CuotaDeducible
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
	}
	public partial class DatosPresentacion
	{

		private string nIFPresentadorField;

		private string timestampPresentacionField;

		/// <remarks/>


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
	}
	public class EstadoFactura
	{

		private string estadoCuadreField;

		private TimeSpan timestampEstadoCuadreField;

		private TimeSpan timestampUltimaModificacionField;

		private string estadoRegistroField;
		private int? codigoErrorRegistro;
		private string descripcionErrorRegistro;

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
		public TimeSpan TimestampEstadoCuadre
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
		public TimeSpan TimestampUltimaModificacion
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
		public int? CodigoErrorRegistro
		{
			get
			{
				return this.codigoErrorRegistro;
			}
			set
			{
				this.codigoErrorRegistro = value;
			}
		}
		/// <remarks/>
		public string DescripcionErrorRegistro
		{
			get
			{
				return this.descripcionErrorRegistro;
			}
			set
			{
				this.descripcionErrorRegistro = value;
			}
		}
	}
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public class RegistroRespuestaConsultaLRFacturasRecibidas
	{

        private ConsultaResponseIDFactura iDFacturaField;

        private DatosFacturaRecibida datosFacturaRecibidaField;

        private DatosPresentacion datosPresentacionField;

        private EstadoFactura estadoFacturaField;

        /// <remarks/>
        public ConsultaResponseIDFactura IDFactura
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
        public DatosFacturaRecibida DatosFacturaRecibida
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
        public DatosPresentacion DatosPresentacion
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
        public EstadoFactura EstadoFactura
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
    }
}
