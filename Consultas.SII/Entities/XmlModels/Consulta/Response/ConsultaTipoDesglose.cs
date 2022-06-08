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
	public partial class ConsultaTipoDesglose
	{

		private ConsultaDesgloseFactura desgloseFacturaField;

		private ConsultaDesgloseTipoOperacion desgloseTipoOperacionField;

		/// <remarks/>
		public ConsultaDesgloseFactura DesgloseFactura
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
		public ConsultaDesgloseTipoOperacion DesgloseTipoOperacion
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

}
