using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class ConsultaNoExenta
	{

		private string tipoNoExentaField;

		private ConsultaDetalleIVA[] desgloseIVAField;

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
		public ConsultaDetalleIVA[] DesgloseIVA
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

}
