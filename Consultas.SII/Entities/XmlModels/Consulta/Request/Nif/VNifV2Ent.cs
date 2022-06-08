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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/burt/jdit/ws/VNifV2Ent.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/burt/jdit/ws/VNifV2Ent.xsd", IsNullable = false)]
    public class VNifV2Ent
    {

        private List <Consulta.Request.Nif.Contribuyente> contribuyenteField;

        /// <remarks/>
        public List<Consulta.Request.Nif.Contribuyente> Contribuyentes
        {
            get
            {
                return this.contribuyenteField;
            }
            set
            {
                this.contribuyenteField = value;
            }
        }
    }
}
