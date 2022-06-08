namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
	public partial class ConsultaNoSujeta
	{

		private ushort importeTAIReglasLocalizacionField;

		/// <remarks/>
		public ushort ImporteTAIReglasLocalizacion
		{
			get
			{
				return this.importeTAIReglasLocalizacionField;
			}
			set
			{
				this.importeTAIReglasLocalizacionField = value;
			}
		}
	}


}
