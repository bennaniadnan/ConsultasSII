﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste
{
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
		"es/es/aeat/ssii/fact/ws/ConsultaLR.xsd", IsNullable = false)]
	public partial class ConsultaContraparte
	{

		private string nombreRazonField;

		private string nIFField;

		private ConsultaIDOtro iDOtroField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NombreRazon
		{
			get
			{
				return this.nombreRazonField;
			}
			set
			{
				this.nombreRazonField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public string NIF
		{
			get
			{
				return this.nIFField;
			}
			set
			{
				this.nIFField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacion" +
			"es/es/aeat/ssii/fact/ws/SuministroInformacion.xsd")]
		public ConsultaIDOtro IDOtro
		{
			get
			{
				return this.iDOtroField;
			}
			set
			{
				this.iDOtroField = value;
			}
		}
	}

}
