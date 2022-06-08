using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
        "es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
        "es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
    public partial class ConsultaCabecera
    {

        private decimal iDVersionSiiField;

        private ConsultaTitular titularField;

        /// <remarks/>
        public decimal IDVersionSii
        {
            get
            {
                return this.iDVersionSiiField;
            }
            set
            {
                this.iDVersionSiiField = value;
            }
        }

        /// <remarks/>
        public ConsultaTitular Titular
        {
            get
            {
                return this.titularField;
            }
            set
            {
                this.titularField = value;
            }
        }
    }
}
