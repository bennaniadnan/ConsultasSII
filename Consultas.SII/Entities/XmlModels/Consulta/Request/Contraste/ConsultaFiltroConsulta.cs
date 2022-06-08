using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste
{
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd", IsNullable = false)]
	public class FechaPresentacion
	{

		private string desdeField;

		private string hastaField;


		public string Desde
		{
			get
			{
				return this.desdeField;
			}
			set
			{
				this.desdeField = value;
			}
		}

		public string Hasta
		{
			get
			{
				return this.hastaField;
			}
			set
			{
				this.hastaField = value;
			}
		}
	}
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd", IsNullable = false)]
	public class ConsultaFiltroConsulta
    {
        private ConsultaPeriodoImpositivo periodoImpositivoField;

        private ConsultaIDFactura iDFacturaField;
		
		private ConsultaPeriodoLiquidacion periodoLiquidacionField;

		private ConsultaContraparte contraparteField;

        private FechaPresentacion fechaPresentacion;

        private string estadoCuadre;

		private ConsultaClavePaginacion clavePaginacionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public ConsultaPeriodoLiquidacion PeriodoLiquidacion
		{
			get
			{
				return this.periodoLiquidacionField;
			}
			set
			{
				this.periodoLiquidacionField = value;
			}
		}


		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
            "es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
        public ConsultaPeriodoImpositivo PeriodoImpositivo
        {
            get
            {
                return this.periodoImpositivoField;
            }
            set
            {
                this.periodoImpositivoField = value;
            }
        }

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
		public ConsultaIDFactura IDFactura
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
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
		public ConsultaContraparte Contraparte
		{
			get
			{
				return this.contraparteField;
			}
			set
			{
				this.contraparteField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
		public FechaPresentacion FechaPresentacion
		{
			get
			{
				return this.fechaPresentacion;
			}
			set
			{
				this.fechaPresentacion = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
		public string EstadoCuadre
		{
			get
			{
				return this.estadoCuadre;
			}
			set
			{
				this.estadoCuadre = value;
			}
		}
		/// <remarks/>
		public ConsultaClavePaginacion ClavePaginacion
		{
			get
			{
				return this.clavePaginacionField;
			}
			set
			{
				this.clavePaginacionField = value;
			}
		}

	}
}
