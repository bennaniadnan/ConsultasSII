namespace Consultas.SII.Entities.Model.BaseType.Consulta.Response
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd")]
	public partial class ConsultaEstadoFactura
	{

		private byte estadoCuadreField;

		private string timestampEstadoCuadreField;

		private string timestampUltimaModificacionField;

		private string estadoRegistroField;

		/// <remarks/>
		public byte EstadoCuadre
		{
			get
			{
				return this.estadoCuadreField;
			}
			set
			{
				this.estadoCuadreField = value;
			}
		}

		/// <remarks/>
		public string TimestampEstadoCuadre
		{
			get
			{
				return this.timestampEstadoCuadreField;
			}
			set
			{
				this.timestampEstadoCuadreField = value;
			}
		}

		/// <remarks/>
		public string TimestampUltimaModificacion
		{
			get
			{
				return this.timestampUltimaModificacionField;
			}
			set
			{
				this.timestampUltimaModificacionField = value;
			}
		}

		/// <remarks/>
		public string EstadoRegistro
		{
			get
			{
				return this.estadoRegistroField;
			}
			set
			{
				this.estadoRegistroField = value;
			}
		}

		public int? CodigoErrorRegistro { get; set; }
		public string DescripcionErrorRegistro { get; set; }
	}


}
