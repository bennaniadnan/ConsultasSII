namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd", IsNullable = false)]
	public partial class ConsultaPrestacionServicios
	{

		private ConsultaNoSujeta noSujetaField;

		/// <remarks/>
		public ConsultaNoSujeta NoSujeta
		{
			get
			{
				return this.noSujetaField;
			}
			set
			{
				this.noSujetaField = value;
			}
		}
	}


}
