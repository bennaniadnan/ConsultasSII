using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste
{
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class ConsultaPeriodoImpositivo
	{

		private int ejercicioField;

		private string periodoField;

		/// <remarks/>
		public int Ejercicio
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
}
