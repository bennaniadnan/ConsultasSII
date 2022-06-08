namespace Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class ConsultaPeriodoLiquidacion
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
