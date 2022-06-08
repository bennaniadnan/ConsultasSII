using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione" +
        "s/es/aeat/burt/jdit/ws/VNifV2Sal.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione" +
        "s/es/aeat/burt/jdit/ws/VNifV2Sal.xsd", IsNullable = false)]
    public class VNifV2Sal
    {

        private List<Consultas.SII.Entities.Model.BaseType.Consulta.Response.ContribuyenteResponse> contribuyenteField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contribuyente")]
        public List<Consultas.SII.Entities.Model.BaseType.Consulta.Response.ContribuyenteResponse> Contribuyente
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





