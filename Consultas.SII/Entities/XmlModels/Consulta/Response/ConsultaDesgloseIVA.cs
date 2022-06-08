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
	public partial class ConsultaDesgloseIVA
	{

		private ConsultaDetalleIVA detalleIVAField;

		/// <remarks/>
		public ConsultaDetalleIVA DetalleIVA
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

}
