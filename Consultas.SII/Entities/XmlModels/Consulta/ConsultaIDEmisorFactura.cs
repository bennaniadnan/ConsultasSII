using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class ConsultaIDEmisorFactura
	{

		private string nombreRazonField;
		private ConsultaIDOtro iDOtroField;

		private string nIFField;

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

		public ConsultaIDOtro IDOtro
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

}
