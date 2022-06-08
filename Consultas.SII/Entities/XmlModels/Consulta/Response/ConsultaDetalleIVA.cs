using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class ConsultaDetalleIVA
	{

		private byte tipoImpositivoField;

		private decimal baseImponibleField;

		private decimal cuotaRepercutidaField;

		/// <remarks/>
		public byte TipoImpositivo
		{
			get
			{
				return this.tipoImpositivoField;
			}
			set
			{
				this.tipoImpositivoField = value;
			}
		}

		/// <remarks/>
		public decimal BaseImponible
		{
			get
			{
				return this.baseImponibleField;
			}
			set
			{
				this.baseImponibleField = value;
			}
		}

		/// <remarks/>
		public decimal CuotaRepercutida
		{
			get
			{
				return this.cuotaRepercutidaField;
			}
			set
			{
				this.cuotaRepercutidaField = value;
			}
		}
	}

}
