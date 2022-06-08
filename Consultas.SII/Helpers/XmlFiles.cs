using Consultas.SII.Entities;
using Consultas.SII.Entities.Model.BaseType.Consulta;
using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Consultas.SII.Helpers
{

	public static class XmlFiles
	{
		public static string[] GetXmlFilesFromDirectory(string pFolderDirectory)
		{
			string[] listFiles;
			if (!Directory.Exists(pFolderDirectory))
			{
				return null;
			}

			listFiles = Directory.GetFiles(pFolderDirectory);

			return listFiles;
		}

		public static string CovertToCsv<T>(IList<T> listToConvert) where T : class
		{
			string ret = String.Empty;
			if (listToConvert.Any())
			{
				List<List<string>> dataList = new List<List<string>>();
				//get properties and values 
				PropertyInfo[] props = listToConvert.First().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

				List<string> itemValues = props.Select(prop => prop.Name).ToList();
				dataList.Add(itemValues);

				foreach (var item in listToConvert)
				{
					//iterate through properties
					itemValues = new List<string>();
					foreach (var prop in props)
					{
						if (prop.GetValue(item) != null)
						{
							itemValues.Add(prop.GetValue(item).ToString());
						}
					}
					dataList.Add(itemValues);
				}

				//flatten out lists and return results
				ret = string.Join(Environment.NewLine, dataList.Select(i => string.Join(GlobalConfiguration.GenericConstants.CSVSEPARATOR.ToString(), i.Select(v => v.ToString()))));
			}

			return ret;
		}

		internal static XDocument SetNewResponseNameSpace(XDocument xDocument, string idAgencia)
		{
			string xDocumentString;
			if (idAgencia != "AEAT")
			{
				xDocumentString = xDocument.ToString();
				xDocumentString = xDocumentString.Replace(GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].Root, GlobalConfiguration.GenericConstants.NamespacesByAgency["AEAT"].Root);
				xDocument = XDocument.Parse(xDocumentString);
			}
			return xDocument;
		}

		internal static XDocument SetNewNameSpace(XDocument xDocument, string idAgencia)
		{
			string xDocumentString;
			if (idAgencia != "AEAT")
			{
				xDocumentString = xDocument.ToString();
				xDocumentString = xDocumentString.Replace(GlobalConfiguration.GenericConstants.NamespacesByAgency["AEAT"].Root, GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].Root);
				xDocument = XDocument.Parse(xDocumentString);
			}
			return xDocument;
		}

		private static XName getNewNameSpace(string idAgencia, XName name)
		{
			string current = name.Namespace.ToString();
			string schemaName = Path.GetFileNameWithoutExtension(current);
			XName xn = null;
			if (!string.IsNullOrWhiteSpace(schemaName))
			{

				if (GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].Sii.Contains(schemaName))
				{
					xn = XName.Get(name.LocalName, GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].Sii);
				}
				else if (GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiLR.Contains(schemaName))
				{
					xn = XName.Get(name.LocalName, GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiLR);
				}
				else if (GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiLRC.Contains(schemaName))
				{
					xn = XName.Get(name.LocalName, GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiLRC);
				}
				else if (GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiLRRC.Contains(schemaName))
				{
					xn = XName.Get(name.LocalName, GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiLRRC);
				}
				else if (GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiR.Contains(schemaName))
				{
					xn = XName.Get(name.LocalName, GlobalConfiguration.GenericConstants.NamespacesByAgency[idAgencia].SiiR);
				}
				else xn = name;
			}
			else xn = name;
			return xn;
		}

		public static string CreateXmlFileFromModel(Consultas.SII.Entities.Model.BaseType.Consulta.Request.Nif.VNifV2Ent pNifV2Ent, string fileName, string extention)
		{
			string XmlRequestDirectory = string.Format(GlobalConfiguration.BatchConstants.BridgeRequestDirectory, fileName);
			XmlRequestDirectory = GlobalConfiguration.BatchConstants.BridgeRequestDirectory.Replace("UserId", fileName);
			if (!Directory.Exists(XmlRequestDirectory))
			{
				Directory.CreateDirectory(XmlRequestDirectory);
			}

			XmlSerializer xs = new XmlSerializer(typeof(ConsultaEnvelope));
			string completeFileNamePath =
				Path.Combine(XmlRequestDirectory, $"ConsultaNif_{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}{extention}");

			TextWriter tw = new StreamWriter(completeFileNamePath, false, new UTF8Encoding(false));

			ConsultaEnvelope envelope = new ConsultaEnvelope()
			{
				Body = new ConsultaBody()
				{
					VnifV2Ent = pNifV2Ent
				}
			};

			xs.Serialize(tw, envelope);
			tw.Close();
			return completeFileNamePath;

		}

		internal static string CreateXmlFileFromModel(ConsultaLRFacturasEmitidas pConsultaLRFacturasEmitidas, string extention)
		{
			try
			{
				string XmlRequestDirectory = GlobalConfiguration.BatchConstants.BridgeRequestDirectory.Replace("UserId", "User");

				if (!Directory.Exists(XmlRequestDirectory))
				{
					Directory.CreateDirectory(XmlRequestDirectory);
				}

				XmlSerializer xs = new XmlSerializer(typeof(ConsultaEnvelope));
				string completeFileNamePath =
					Path.Combine(XmlRequestDirectory, $"ConsultaContraste_{DateTime.Now:yyyyMMdd_HHmmss}{extention}");


				TextWriter tw = new StreamWriter(completeFileNamePath, false, new UTF8Encoding(false));

				ConsultaEnvelope envelope = new ConsultaEnvelope()
				{
					Body = new ConsultaBody()
					{
						ConsultaLRFacturasEmitidas = pConsultaLRFacturasEmitidas
					}
				};

				xs.Serialize(tw, envelope);
				tw.Close();

				return completeFileNamePath;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		internal static string CreateXmlFileFromModel(ConsultaLRFacturasRecibidas pConsultaLRFacturasRecibidas, string extention)
		{

			string XmlRequestDirectory = GlobalConfiguration.BatchConstants.BridgeRequestDirectory.Replace("UserId", "User");

			if (!Directory.Exists(XmlRequestDirectory))
			{
				Directory.CreateDirectory(XmlRequestDirectory);
			}

			XmlSerializer xs = new XmlSerializer(typeof(ConsultaEnvelope));
			string completeFileNamePath =
				Path.Combine(XmlRequestDirectory, $"ConsultaContraste_{DateTime.Now:yyyyMMdd_HHmmss}{extention}");

			TextWriter tw = new StreamWriter(completeFileNamePath, false, new UTF8Encoding(false));

			ConsultaEnvelope envelope = new ConsultaEnvelope()
			{
				Body = new ConsultaBody()
				{
					ConsultaLRFacturasRecibidas = pConsultaLRFacturasRecibidas
				}
			};
			xs.Serialize(tw, envelope);
			tw.Close();

			return completeFileNamePath;
		}
		public static T CreateModelFromFile<T>(string pPAth)
		{
			T ret;
			XmlSerializer xs = new XmlSerializer(typeof(T));
			using (var sr = new StreamReader(pPAth))
			{
				ret = (T)xs.Deserialize(sr);
			}

			return ret;
		}

		public static T DeserializeXMLFileToObject<T>(string XmlFilename)
		{

			T returnObject = default(T);
			if (string.IsNullOrEmpty(XmlFilename)) return default(T);

			try
			{
				using (StreamReader xmlStream = new StreamReader(XmlFilename, new UTF8Encoding(false)))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					var vResult = serializer.Deserialize(xmlStream);
					returnObject = (T)vResult;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return returnObject;
		}

		//public static string SerializeObject<T>(this T toSerialize)
		//{
		//    try
		//    {
		//        XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

		//        using (StringWriter textWriter = new StringWriter())
		//        {
		//            .Serialize(textWriter, toSerialize);
		//            return textWriter.ToString();
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//}

		public static T Deserialize<T>(string XmlFileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			XDocument xmlDocument = StripNameSpace(XmlFileName);


			using (var reader = xmlDocument.Root.CreateReader())
			{
				return (T)xmlSerializer.Deserialize(reader);
			}
		}

		public static string Serialize<T>(string XmlFileName, Dictionary<string, XNamespace> nameSpacesDictionary)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			var doc = XDocument.Load(XmlFileName);

			//foreach(var elm in nameSpacesDictionary)
			//{

			//}

			XElement root = new XElement("soapenv" + "Envelope",
				new XAttribute(XNamespace.Xmlns + "vnif", "nameSpace")
			);

			doc.Root.Add(root);

			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, doc);
				return textWriter.ToString();
			}

		}

		private static XDocument StripNameSpace(string XmlFileName)
		{
			XDocument doc = null;
			using (StreamReader oReader = new StreamReader(XmlFileName, new UTF8Encoding(false)))
			{
				doc = XDocument.Load(oReader);
			}
			//var doc = XDocument.Load(XmlFileName);
			var namespaces = from a in doc.Descendants().Attributes()
							 where a.IsNamespaceDeclaration && a.Name != "xsi" || a.Name.LocalName == "schemaLocation"
							 select a;
			namespaces.Remove();

			var Striped = System.Text.RegularExpressions.Regex.Replace(
			doc.ToString(), @"( xmlns:?[^=]*=[""][^""]*[""])", "",
			System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);
			return XDocument.Parse(Striped);
		}

		public static XDocument Serialize<T>(T value)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

			XDocument doc = new XDocument();
			using (var writer = doc.CreateWriter())
			{
				xmlSerializer.Serialize(writer, value);
			}

			return doc;
		}


		public static void NewNamespaceSerializer(string XmlFileName, string idAgencia)
		{
			try
			{
				var doc = XDocument.Load(XmlFileName);
				if (idAgencia != "AEAT")
				{
					doc = SetNewNameSpace(doc, idAgencia);
					using (var writer = new XmlTextWriter(XmlFileName, new UTF8Encoding(false)))
					{
						doc.Save(writer);
					}

				}
			}
			catch (Exception ex)
			{
				//throw;
			}


		}
		public static void NewResponseNamespaceSerializer(string XmlFileName, string idAgencia)
		{
			try
			{
				//var doc = XDocument.Load(XmlFileName);
				XDocument doc = null;

				using (StreamReader oReader = new StreamReader(XmlFileName, new UTF8Encoding(false)))
				{
					doc = XDocument.Load(oReader);
				}
				if (idAgencia != "AEAT")
				{
					doc = SetNewResponseNameSpace(doc, idAgencia);
					using (var writer = new XmlTextWriter(XmlFileName, new UTF8Encoding(false)))
					{
						doc.Save(writer);
					}
					//doc.Save(XmlFileName);
				}
			}
			catch (Exception ex)
			{
				//throw;
			}


		}
	}

	public class GenericConstants
	{
		private readonly IConfiguration _configuration;
		public char CSVSEPARATOR { get; set; }
		public string CURL_PATH { get; set; }
		public string CERTIFICAT_PEM { get; set; }
		public string CERTIFICAT_PEM_KEY { get; set; }
		public string ENDPOINT_VNIFV2SOAP { get; set; }
		public Dictionary<string, AgencyNameSpace> NamespacesByAgency { get; set; }

		public GenericConstants(IConfiguration configuration)
		{
			_configuration = configuration;
			CURL_PATH = _configuration.GetSection("CURL_PATH").Value;

			CSVSEPARATOR = char.Parse(_configuration.GetSection("CSVSEPARATOR").Value);
			CERTIFICAT_PEM = _configuration.GetSection("CERTIFICAT_PEM").Value;
			CERTIFICAT_PEM_KEY = _configuration.GetSection("CERTIFICAT_PEM_KEY").Value;
			ENDPOINT_VNIFV2SOAP = _configuration.GetSection("ENDPOINT_VNIFV2SOAP").Value;
			NamespacesByAgency =
			new Dictionary<string, AgencyNameSpace>() {
				{
					"AEAT",
					new AgencyNameSpace() {
						Root = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws",
						Sii = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/SuministroInformacion.xsd",
						SiiLR = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/SuministroLR.xsd",
						SiiLRC = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/ConsultaLR.xsd",
						SiiLRRC = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd",
						SiiR = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/RespuestaSuministro.xsd",
						SoapAddressFE = _configuration.GetSection("ENDPOINT_AEAT_FE").Value,
						SoapAddressFR = _configuration.GetSection("ENDPOINT_AEAT_FR").Value

					}
				},{
					"ATA",
					new AgencyNameSpace() {
						Root = "https://sii.araba.eus/documentos",
						Sii = "https://sii.araba.eus/documentos/SuministroInformacion.xsd",
						SiiLR = "https://sii.araba.eus/documentos/SuministroLR.xsd",
						SiiLRC = "https://sii.araba.eus/documentos/ConsultaLR.xsd",
						SiiLRRC = "https://sii.araba.eus/documentos/RespuestaConsultaLR.xsd",
						SiiR = "https://sii.araba.eus/documentos/RespuestaSuministro.xsd",
						SoapAddressFE = _configuration.GetSection("ENDPOINT_ATA_FE").Value,
						SoapAddressFR = _configuration.GetSection("ENDPOINT_ATA_FR").Value
					}
				},{
					"ATG",
					new AgencyNameSpace() {
						Root = "https://egoitza.gipuzkoa.eus/ogasuna/sii/ficheros",
						Sii = "https://egoitza.gipuzkoa.eus/ogasuna/sii/ficheros/SuministroInformacion.xsd",
						SiiLR = "https://egoitza.gipuzkoa.eus/ogasuna/sii/ficheros/SuministroLR.xsd",
						SiiLRC = "https://egoitza.gipuzkoa.eus/ogasuna/sii/ficheros/ConsultaLR.xsd",
						SiiLRRC = "https://egoitza.gipuzkoa.eus/ogasuna/sii/ficheros/RespuestaConsultaLR.xsd",
						SiiR = "https://egoitza.gipuzkoa.eus/ogasuna/sii/ficheros/RespuestaSuministro.xsd",
						SoapAddressFE = _configuration.GetSection("ENDPOINT_ATG_FE").Value,
						SoapAddressFR = _configuration.GetSection("ENDPOINT_ATG_FR").Value

					}
				},{
					"ATN" /*AEAT*/,
					new AgencyNameSpace() {
						Root = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws",
						Sii = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/SuministroInformacion.xsd",
						SiiLR = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/SuministroLR.xsd",
						SiiLRC = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/ConsultaLR.xsd",
						SiiLRRC = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/RespuestaConsultaLR.xsd",
						SiiR = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/fact/ws/RespuestaSuministro.xsd",
						SoapAddressFE = _configuration.GetSection("ENDPOINT_ATN_FE").Value,
						SoapAddressFR = _configuration.GetSection("ENDPOINT_ATN_FR").Value

					}
				},{
					"ATB",
					new AgencyNameSpace() {
						Root = "http://www.bizkaia.eus/ogasuna/sii/documentos",
						Sii = "http://www.bizkaia.eus/ogasuna/sii/documentos/SuministroInformacion.xsd",
						SiiLR = "http://www.bizkaia.eus/ogasuna/sii/documentos/SuministroLR.xsd",
						SiiLRC = "http://www.bizkaia.eus/ogasuna/sii/documentos/ConsultaLR.xsd",
						SiiLRRC = "http://www.bizkaia.eus/ogasuna/sii/documentos/RespuestaConsultaLR.xsd",
						SiiR = "http://www.bizkaia.eus/ogasuna/sii/documentos/RespuestaSuministro.xsd",
						SoapAddressFE = _configuration.GetSection("ENDPOINT_ATB_FE").Value,
						SoapAddressFR = _configuration.GetSection("ENDPOINT_ATB_FR").Value

					}
				},{
					"ATC",
					new AgencyNameSpace() {
						Root = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/igic/ws",
						Sii = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/igic/ws/SuministroInformacion.xsd",
						SiiLR = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/igic/ws/SuministroLR.xsd",
						SiiLRC = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/igic/ws/ConsultaLR.xsd",
						SiiLRRC = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/igic/ws/RespuestaConsultaLR.xsd",
						SiiR = "https://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicaciones/es/aeat/ssii/igic/ws/RespuestaSuministro.xsd",
						SoapAddressFE = _configuration.GetSection("ENDPOINT_ATC_FE").Value,
						SoapAddressFR = _configuration.GetSection("ENDPOINT_ATC_FR").Value

					}
				}
			};
		}

	}
	public class BatchConstants
	{
		private readonly IConfiguration _configuration;
		public string BridgeRequestDirectory;
		public string BridgeResponseDirectory;
		public string BatBatchProcessPath;
		public string XML_Enviados = "XML_Enviados";
		public string XML_Respuesta = "XML_Respuesta";
		public string HubFilesDirectory;

		public BatchConstants(IConfiguration configuration)
		{
			_configuration = configuration;
			BridgeRequestDirectory = _configuration.GetSection("BridgeRequestDirectory").Value;
			BridgeResponseDirectory = _configuration.GetSection("BridgeResponseDirectory").Value;
			BatBatchProcessPath = _configuration.GetSection("BatBatchProcessPath").Value;
			HubFilesDirectory = _configuration.GetSection("HubFilesDirectory").Value;
		}


	}

	public static class ParserHelper
	{
		public static int parseToInt(this string inputValue)
		{
			int output = 0;
			int.TryParse(inputValue, out output);
			return output;
		}
		public static int? parseToNullableInt(this string inputValue)
		{
			int output = 0;

			if (int.TryParse(inputValue, out output))
				return output;
			return null;
		}
		public static double parseToDouble(this string inputValue)
		{
			double output = 0;
			double.TryParse(inputValue, out output);
			return output;
		}
		public static decimal parseToDecimal(this string inputValue)
		{
			decimal output = 0;
			decimal.TryParse(inputValue, out output);
			return output;
		}
		public static float parseToFloat(this string inputValue)
		{
			float output = 0;
			float.TryParse(inputValue, out output);
			return output;
		}
		public static bool parseToBool(this string inputValue)
		{
			bool output = false;
			bool.TryParse(inputValue, out output);
			return output;
		}
		public static DateTime parseToDateTime(this string inputValue)
		{
			DateTime output = new DateTime(1901, 1, 1);
			DateTime.TryParse(inputValue, out output);
			return output;
		}
		public static DateTime? parseToNullableDateTime(this string inputValue)
		{
			DateTime output = new DateTime(1901, 1, 1);
			if (DateTime.TryParse(inputValue, out output))
				return output;
			return null;
		}
		public static decimal? parseToNullableDecimal(this string inputValue)
		{
			decimal output = 0;
			if (decimal.TryParse(inputValue, out output))
				return output;
			return null;
		}
		public static TimeSpan parseToTimeSpan(this string inputValue)
		{
			TimeSpan output = TimeSpan.MinValue;
			TimeSpan.TryParse(inputValue, out output);
			return output;
		}
	}
	public static class GlobalConfiguration
	{
		public static IConfiguration Configuration { get; set; }
		public static BatchConstants BatchConstants { get; set; }
		public static GenericConstants GenericConstants { get; set; }


		public static string EnvironmentVariable
		{
			get
			{
				string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
				if (env == "Staging")
				{
					env = "Test";
				}
				return env;
			}
		}

		public static bool IsDeveloppement
		{
			get
			{
				string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
				bool isDevelopment = env?.ToUpper() == "DEVELOPMENT";
				return IsDeveloppement;
			}
		}

	}
}
