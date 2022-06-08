using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute("Envelope", AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	[System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
	public partial class ConsultaEnvelope
	{

		private object headerField;

		private ConsultaBody bodyField;

		/// <remarks/>
		public object Header
		{
			get
			{
				return this.headerField;
			}
			set
			{
				this.headerField = value;
			}
		}

		/// <remarks/>
		public ConsultaBody Body
		{
			get
			{
				return this.bodyField;
			}
			set
			{
				this.bodyField = value;
			}
		}
	}


}
