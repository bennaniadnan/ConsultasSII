using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Nif;
using Consultas.SII.Entities.Model.BaseType.Consulta.Response;

namespace Consultas.SII.Entities.Model.BaseType.Consulta
{
    [System.Xml.Serialization.XmlTypeAttribute("Body", AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class ConsultaBody
    {
		private string idField;

        #region"Consultation contraste"
        private ConsultaLRFacturasEmitidas consultaLRFacturasEmitidasField;

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
        public ConsultaLRFacturasEmitidas ConsultaLRFacturasEmitidas
        {
            get
            {
                return this.consultaLRFacturasEmitidasField;
            }
            set
            {
                this.consultaLRFacturasEmitidasField = value;
            }
        }

        private ConsultaLRFacturasRecibidas consultaLRFacturasRecibidasField;

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
        public ConsultaLRFacturasRecibidas ConsultaLRFacturasRecibidas
		{
            get
            {
                return this.consultaLRFacturasRecibidasField;
            }
            set
            {
                this.consultaLRFacturasRecibidasField = value;
            }
        }
        #endregion

        #region"Consultation NIF"


        private VNifV2Ent vnifV2EntField;
        public VNifV2Ent VnifV2Ent
        {
            get
            {
                return this.vnifV2EntField;
            }
            set
            {
                this.vnifV2EntField = value;
            }
        }
        private List<Consultas.SII.Entities.Model.BaseType.Consulta.Response.ContribuyenteResponse> vNifV2SalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione" +
            "s/es/aeat/burt/jdit/ws/VNifV2Sal.xsd")]
        [System.Xml.Serialization.XmlArrayItemAttribute("Contribuyente", IsNullable = false)]
        public List<Consultas.SII.Entities.Model.BaseType.Consulta.Response.ContribuyenteResponse> VNifV2Sal
        {
            get
            {
                return this.vNifV2SalField;
            }
            set
            {
                this.vNifV2SalField = value;
            }
        }


		#endregion

		#region "Consultation Response"

		private RespuestaConsultaLRFacturasEmitidas respuestaConsultaLRFacturasEmitidasField;

		private RespuestaConsultaLRFacturasRecibidas respuestaConsultaLRFacturasRecibidasField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
		public RespuestaConsultaLRFacturasEmitidas RespuestaConsultaLRFacturasEmitidas
		{
			get
			{
				return this.respuestaConsultaLRFacturasEmitidasField;
			}
			set
			{
				this.respuestaConsultaLRFacturasEmitidasField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
		public RespuestaConsultaLRFacturasRecibidas RespuestaConsultaLRFacturasRecibidas
		{
			get
			{
				return this.respuestaConsultaLRFacturasRecibidasField;
			}
			set
			{
				this.respuestaConsultaLRFacturasRecibidasField = value;
			}
		} 
		#endregion
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
}
