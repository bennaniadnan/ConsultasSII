using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public class RegistroRespuestaConsultaLRFacturasEmitidas
    {

        private ConsultaResponseIDFactura iDFacturaField;

        private ConsultaDatosFacturaEmitida datosFacturaEmitidaField;

        private ConsultaDatosPresentacion datosPresentacionField;

        private ConsultaEstadoFactura estadoFacturaField;

        /// <remarks/>
        public ConsultaResponseIDFactura IDFactura
        {
            get
            {
                return this.iDFacturaField;
            }
            set
            {
                this.iDFacturaField = value;
            }
        }

        /// <remarks/>
        public ConsultaDatosFacturaEmitida DatosFacturaEmitida
        {
            get
            {
                return this.datosFacturaEmitidaField;
            }
            set
            {
                this.datosFacturaEmitidaField = value;
            }
        }

        /// <remarks/>
        public ConsultaDatosPresentacion DatosPresentacion
        {
            get
            {
                return this.datosPresentacionField;
            }
            set
            {
                this.datosPresentacionField = value;
            }
        }

        /// <remarks/>
        public ConsultaEstadoFactura EstadoFactura
        {
            get
            {
                return this.estadoFacturaField;
            }
            set
            {
                this.estadoFacturaField = value;
            }
        }
    }
}
