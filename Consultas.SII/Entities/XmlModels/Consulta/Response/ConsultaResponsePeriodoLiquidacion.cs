namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd", IsNullable = false)]
	public partial class ConsultaResponsePeriodoLiquidacion
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
