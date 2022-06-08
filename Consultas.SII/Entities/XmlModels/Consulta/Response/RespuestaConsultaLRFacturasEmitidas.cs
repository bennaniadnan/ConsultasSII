using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd", IsNullable = false)]
	public partial class RespuestaConsultaLRFacturasEmitidas
	{

		private ConsultaCabecera cabeceraField;

		private ConsultaResponsePeriodoImpositivo periodoImpositivoField;

		private string indicadorPaginacionField;

		private string resultadoConsultaField;

		private RegistroRespuestaConsultaLRFacturasEmitidas[] registroRespuestaConsultaLRFacturasEmitidasField;

		private ConsultaResponsePeriodoLiquidacion periodoLiquidacionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public ConsultaCabecera Cabecera
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
		public ConsultaResponsePeriodoImpositivo PeriodoImpositivo
		{
			get
			{
				return this.periodoImpositivoField;
			}
			set
			{
				this.periodoImpositivoField = value;
			}
		}

		/// <remarks/>
		public ConsultaResponsePeriodoLiquidacion PeriodoLiquidacion
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
	
}
