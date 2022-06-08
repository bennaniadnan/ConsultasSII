using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Request.Nif
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione" +
    "s/es/aeat/burt/jdit/ws/VNifV2Ent.xsd")]
    public class Contribuyente
    {

        private string nifField;

        private string nombreField;

        /// <remarks/>
        public string Nif
        {
            get
            {
                return this.nifField;
            }
            set
            {
                this.nifField = value;
            }
        }

        /// <remarks/>
        public string Nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }
}
