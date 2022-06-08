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
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class ConsultaSujeta
	{
		private ConsultaExenta[] exentaField;


		private ConsultaNoExenta noExentaField;

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("DetalleExenta", IsNullable = false)]
		public ConsultaExenta[] Exenta
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
		public ConsultaNoExenta NoExenta
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

}
