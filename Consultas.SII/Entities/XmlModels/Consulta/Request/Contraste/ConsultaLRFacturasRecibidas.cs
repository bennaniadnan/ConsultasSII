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
    public partial class ConsultaLRFacturasRecibidas
    {

        private ConsultaCabecera cabeceraField;

        private ConsultaFiltroConsulta filtroConsultaField;

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
		
		public ConsultaFiltroConsulta FiltroConsulta
        {
            get
            {
                return this.filtroConsultaField;
            }
            set
            {
                this.filtroConsultaField = value;
            }
        }
    }
}
