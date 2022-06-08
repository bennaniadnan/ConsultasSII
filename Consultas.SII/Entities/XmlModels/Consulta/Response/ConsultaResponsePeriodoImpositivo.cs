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
    [System.Xml.Serialization.XmlTypeAttribute("PeriodoImpositivo", AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
    [System.Xml.Serialization.XmlRootAttribute("PeriodoImpositivo", Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd", IsNullable = false)]
    public class ConsultaResponsePeriodoImpositivo
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
