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
	public partial class ConsultaIDOtro
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

}
