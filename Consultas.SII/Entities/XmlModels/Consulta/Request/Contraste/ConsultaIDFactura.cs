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
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd", IsNullable = false)]
	public partial class ConsultaIDFactura
    {

		private ConsultaIDEmisorFactura iDEmisorFacturaField;
		private string numSerieFacturaEmisorField;

        private string fechaExpedicionFacturaEmisorField;
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
            "es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public ConsultaIDEmisorFactura IDEmisorFactura
		{
			get
			{
				return this.iDEmisorFacturaField;
			}
			set
			{
				this.iDEmisorFacturaField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
            "es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
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
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
            "es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
        public string FechaExpedicionFacturaEmisor
        {
            get
            {
                return this.fechaExpedicionFacturaEmisorField;
            }
            set
            {
                this.fechaExpedicionFacturaEmisorField = value;
            }
        }
    }
}
