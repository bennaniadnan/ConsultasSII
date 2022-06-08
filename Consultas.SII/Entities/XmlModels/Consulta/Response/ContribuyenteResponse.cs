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
    public class ContribuyenteResponse
    {

        private string nifField;

        private string nombreField;

        private string resultadoField;

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

        /// <remarks/>
        public string Resultado
        {
            get
            {
                return this.resultadoField;
            }
            set
            {
                this.resultadoField = value;
            }
        }
    }
}
