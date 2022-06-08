using Consultas.SII.Contracts;
using Consultas.SII.Entities;
using Consultas.SII.Entities.Enumerator;
using Consultas.SII.Entities.Model.BaseType.Consulta;
using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using Consultas.SII.Entities.Model.BaseType.Consulta.Response;
using Consultas.SII.Entities.Model.BaseType.Consulta.Response.AEAT;

using Gesisa.Apps.Common.Enums;
using Gesisa.Apps.Common.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

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

	public static class ConvertExtension
	{
		public static int ToInteger(this string value)
		{
			int result = 0;
			if (int.TryParse(value, out result))
			{
			}
			return result;
		}

		public static string ToJson(this object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}


		public static EnumEstadoRegistro? ToNullableEnumEstadoRegistro(this string pEstadoString)
		{

			switch (pEstadoString)
			{
				case "Correcto":
				case "Correcta":
					pEstadoString = "Aceptado";
					break;
				case "ParcialmenteCorrecto":
				case "AceptadaConErrores":
					pEstadoString = "AceptadoConErrores";
					break;
				case "Incorrecto":
					pEstadoString = "Rechazado";
					break;
				case "Anulada":
					pEstadoString = "Baja";
					break;
				default:
					break;
			}
			if (Enum.TryParse(typeof(EnumEstadoRegistro), pEstadoString, out object? estado))
			{
				return (EnumEstadoRegistro)estado;
			}
			return null;
		}
	}
	public class ApplicationSecrets
	{

	}
	/// <summary>
	/// the application configuration accessor
	/// </summary>
	public partial class ApplicationSettingsAccessor
	{
		/// <inheritdoc/>
		public EnvironmentType GetEnvironmentType()
		{
			switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
			{
				case "Production":
					return EnvironmentType.Production;
				case "Staging":
				case "Test":
					return EnvironmentType.Staging;
				default:
					return EnvironmentType.Development;
			}
		}

		/// <inheritdoc/>
		public string GetCsvFilesOutputDirectory() => _applicationSettings.Paths.CsvFilesDirectory;

		/// <inheritdoc/>
		public string GetTempFileOutPutsDirectory() => _applicationSettings.Paths.TempFilesDirectory;

		/// <inheritdoc/>
		public string GetXmlRequestDirectory() => _applicationSettings.Paths.XmlRequestDirectory;

		/// <inheritdoc/>
		public string GetXmlResponseDirectory() => _applicationSettings.Paths.XmlResponseDirectory;

		/// <inheritdoc/>
		public int GetMaxAllowedRecordsCount() => _applicationSettings.TaxAgency.MaxAllowedRecordsCount;

		/// <inheritdoc/>
		public (string certificate, string certificateKey) GetAgenciaTributariaCerticate()
			=> (
				_applicationSettings.TaxAgency.CertificateSettings.Certificate,
				_applicationSettings.TaxAgency.CertificateSettings.CertificateKey
			);

		/// <inheritdoc/>
		public int GetCurlCommandTimeOut() => _applicationSettings.TaxAgency.CurlCommandTimeOut;

		/// <inheritdoc/>
		public int GetCurlConnectionTimeOut() => _applicationSettings.TaxAgency.CurlConnectionTimeOut;

		/// <inheritdoc/>
		public string GetCurlProgramPath() => _applicationSettings.TaxAgency.CurlProgramPath;
		/// <inheritdoc/>
		public int GetPasswordExpirationDays() => _applicationSettings.AccountSettings.PasswordExpirationDays;

		/// <inheritdoc/>
		public string GetTestXmlResponseFilePath()
		{
			return @"C:\SII_XMLDATOS\AAAAAA\XML_Respuesta\ConsultaContraste_AAAAAA_20220118_182718.xml";
		}

		/// <summary>
		/// get the email Settings
		/// </summary>
		/// <returns>the email settings</returns>
		public EmailSettings GetEmailSettings() => _applicationSettings.EmailSettings;

		/// <inheritdoc/>
		public string GetUrl(string pathName)
		{
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// partial part for <see cref="ApplicationSettingsAccessor"/>
	/// </summary>
	public partial class ApplicationSettingsAccessor : IApplicationSettingsAccessor
	{
		private readonly IDisposable _secretsChangedDisposable;
		private ApplicationSettings _applicationSettings;

		/// <summary>
		/// create an instant of <see cref="ApplicationSettingsAccessor"/>
		/// </summary>
		/// <param name="options"></param>
		public ApplicationSettingsAccessor(IOptionsMonitor<ApplicationSettings> options)
		{
			_applicationSettings = options.CurrentValue;
			_secretsChangedDisposable = options.OnChange(e => _applicationSettings = e);
		}

		/// <summary>
		/// the object destructor
		/// </summary>
		~ApplicationSettingsAccessor()
		{
			_secretsChangedDisposable?.Dispose();
		}

		public string ApplicationName => throw new NotImplementedException();


	}


	/// <summary>
	/// the implementation for <see cref="IApplicationSecretsAccessor"/>
	/// </summary>
	public partial class ApplicationSecretsAccessor
	{

	}

	/// <summary>
	/// partial part for <see cref="ApplicationSecretsAccessor"/>
	/// </summary>
	public partial class ApplicationSecretsAccessor : IApplicationSecretsAccessor
	{
		private readonly IDisposable _secretsChangedDisposable;
		private ApplicationSecrets _secrets;

		/// <summary>
		/// create an instant of <see cref="ApplicationSecretsAccessor"/>
		/// </summary>
		/// <param name="options">the options monitor instant</param>
		public ApplicationSecretsAccessor(IOptionsMonitor<ApplicationSecrets> options)
		{
			_secrets = options.CurrentValue;
			_secretsChangedDisposable = options.OnChange(e => _secrets = e);
		}

		/// <summary>
		/// the object destructor
		/// </summary>
		~ApplicationSecretsAccessor()
		{
			_secretsChangedDisposable?.Dispose();
		}
	}

	/// <summary>
	/// this class hold the global application settings extracted from IConfiguration in the appSettings.json file
	/// any changes to the AppSetting file should be applied here also
	/// </summary>
	public class ApplicationSettings
	{
		/// <summary>
		/// the paths settings
		/// </summary>
		public PathsSettings Paths { get; set; }

		/// <summary>
		/// the application mail settings
		/// </summary>
		public EmailSettings EmailSettings { get; set; }

		/// <summary>
		/// the TaxAgency related settings
		/// </summary>
		public TaxAgencySettings TaxAgency { get; set; }

		public AccountSettings AccountSettings { get; set; }
	}

	public class ApplicationModelsMappingProfile : AutoMapper.Profile
	{
		public ApplicationModelsMappingProfile()
		{

			#region "Suministro"
			CreateMap<DetalleInmueble, EDetalleInmueble>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.SituacionInmueble, o => o.MapFrom(c => c.SituacionInmueble.parseToInt()))
				.ForMember(x => x.ReferenciaCatastral, o => o.MapFrom(c => c.ReferenciaCatastral));

			CreateMap<IDFacturaAgrupada, EFacturasAgrupadas>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.NumSerieFacturaEmisor, o => o.MapFrom(c => c.NumSerieFacturaEmisor.Trim()))
				.ForMember(x => x.FechaExpedicionFacturaEmisor, o => o.MapFrom(c => !string.IsNullOrEmpty(c.FechaExpedicionFacturaEmisor)
														? c.FechaExpedicionFacturaEmisor.parseToDateTime() : new DateTime(1901, 1, 1).Date));



			CreateMap<IDFacturaRectificada, EFacturasRectificadas>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.NumSerieFacturaEmisor, o => o.MapFrom(c => c.NumSerieFacturaEmisor.Trim()))
				.ForMember(x => x.FechaExpedicionFacturaEmisor, o => o.MapFrom(c => !string.IsNullOrEmpty(c.FechaExpedicionFacturaEmisor)
							? c.FechaExpedicionFacturaEmisor.parseToDateTime() : new DateTime(1901, 1, 1).Date));

			CreateMap<DetalleIVA, EDetalleImportesIVA>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistro, o => o.Ignore())
				.ForMember(x => x.IdTipoDetalleIVA, o => o.Ignore())
				.ForMember(x => x.CuotaRecargoMinorista, o => o.Ignore())
				.ForMember(x => x.CargaImpositivaImplicita, o => o.Ignore())
				.ForMember(x => x.TipoImpositivo, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoImpositivo) ? c.TipoImpositivo.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BaseImponible, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BaseImponible) ? c.BaseImponible.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRepercutida, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRepercutida) ? c.CuotaRepercutida.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaSoportada, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaSoportada) ? c.CuotaSoportada.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoEquivalencia) ? c.CuotaRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.TipoRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoRecargoEquivalencia) ? c.TipoRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.ImporteCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.ImporteCompensacionREAGYP) ? c.ImporteCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.PorcentCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.PorcentCompensacionREAGYP) ? c.PorcentCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BienInversion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BienInversion) ? c.BienInversion.Trim() : null));

			CreateMap<RespuestaConsultaDetalleIGIC, EDetalleImportesIVA>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistro, o => o.Ignore())
				.ForMember(x => x.IdTipoDetalleIVA, o => o.Ignore())
				.ForMember(x => x.TipoImpositivo, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoImpositivo) ? c.TipoImpositivo.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BaseImponible, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BaseImponible) ? c.BaseImponible.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRepercutida, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRepercutida) ? c.CuotaRepercutida.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaSoportada, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaSoportada) ? c.CuotaSoportada.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoMinorista, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoMinorista) ? c.CuotaRecargoMinorista.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CargaImpositivaImplicita, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CargaImpositivaImplicita) ? c.CargaImpositivaImplicita.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoEquivalencia) ? c.CuotaRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.TipoRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoRecargoEquivalencia) ? c.TipoRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.ImporteCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.ImporteCompensacionREAGYP) ? c.ImporteCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.PorcentCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.PorcentCompensacionREAGYP) ? c.PorcentCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BienInversion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BienInversion) ? c.BienInversion.Trim() : null));

			CreateMap<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistro, o => o.Ignore())
				.ForMember(x => x.IdTipoDetalleIVA, o => o.Ignore())
				.ForMember(x => x.CuotaRecargoMinorista, o => o.Ignore())
				.ForMember(x => x.CargaImpositivaImplicita, o => o.Ignore())
				.ForMember(x => x.TipoImpositivo, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoImpositivo) ? c.TipoImpositivo.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BaseImponible, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BaseImponible) ? c.BaseImponible.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRepercutida, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRepercutida) ? c.CuotaRepercutida.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaSoportada, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaSoportada) ? c.CuotaSoportada.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoEquivalencia) ? c.CuotaRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.TipoRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoRecargoEquivalencia) ? c.TipoRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.ImporteCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.ImporteCompensacionREAGYP) ? c.ImporteCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.PorcentCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.PorcentCompensacionREAGYP) ? c.PorcentCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BienInversion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BienInversion) ? c.BienInversion.Trim() : null));

			CreateMap<DetalleIGIC, EDetalleImportesIVA>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistro, o => o.Ignore())
				.ForMember(x => x.IdTipoDetalleIVA, o => o.Ignore())
				.ForMember(x => x.TipoImpositivo, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoImpositivo) ? c.TipoImpositivo.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BaseImponible, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BaseImponible) ? c.BaseImponible.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRepercutida, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRepercutida) ? c.CuotaRepercutida.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaSoportada, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaSoportada) ? c.CuotaSoportada.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoMinorista, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoMinorista) ? c.CuotaRecargoMinorista.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CargaImpositivaImplicita, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CargaImpositivaImplicita) ? c.CargaImpositivaImplicita.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoEquivalencia) ? c.CuotaRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.TipoRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoRecargoEquivalencia) ? c.TipoRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.ImporteCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.ImporteCompensacionREAGYP) ? c.ImporteCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.PorcentCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.PorcentCompensacionREAGYP) ? c.PorcentCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BienInversion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BienInversion) ? c.BienInversion.Trim() : null));


			#endregion "Suministro"

			#region "Respuesta"



			CreateMap<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistro, o => o.Ignore())
				.ForMember(x => x.IdTipoDetalleIVA, o => o.Ignore())
				.ForMember(x => x.CuotaRecargoMinorista, o => o.Ignore())
				.ForMember(x => x.CargaImpositivaImplicita, o => o.Ignore())
				.ForMember(x => x.TipoImpositivo, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoImpositivo) ? c.TipoImpositivo.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BaseImponible, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BaseImponible) ? c.BaseImponible.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRepercutida, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRepercutida) ? c.CuotaRepercutida.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaSoportada, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaSoportada) ? c.CuotaSoportada.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.CuotaRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.CuotaRecargoEquivalencia) ? c.CuotaRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.TipoRecargoEquivalencia, o => o.MapFrom(c => !string.IsNullOrEmpty(c.TipoRecargoEquivalencia) ? c.TipoRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.ImporteCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.ImporteCompensacionREAGYP) ? c.ImporteCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.PorcentCompensacionREAGYP, o => o.MapFrom(c => !string.IsNullOrEmpty(c.PorcentCompensacionREAGYP) ? c.PorcentCompensacionREAGYP.Trim().Replace(".", ",").parseToDecimal() : 0))
				.ForMember(x => x.BienInversion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.BienInversion) ? c.BienInversion.Trim() : null));

			CreateMap<RespuestaConsultaIDFacturaAgrupada, EFacturasAgrupadas>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.NumSerieFacturaEmisor, o => o.MapFrom(c => c.NumSerieFacturaEmisor))
				.ForMember(x => x.FechaExpedicionFacturaEmisor, o => o.MapFrom(c => c.FechaExpedicionFacturaEmisor.parseToNullableDateTime()));

			CreateMap<RespuestaConsultaIDFacturaRectificada, EFacturasRectificadas>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.NumSerieFacturaEmisor, o => o.MapFrom(c => c.NumSerieFacturaEmisor))
				.ForMember(x => x.FechaExpedicionFacturaEmisor, o => o.MapFrom(c => c.FechaExpedicionFacturaEmisor.parseToNullableDateTime()));


			CreateMap<Entities.Model.BaseType.Consulta.Response.AEAT.RespuestaConsultaLRFacturasEmitidas, ERegistroInformacion>()
				.ForMember(x => x.IdLibroRegistro, o => o.MapFrom(c => EnumLibroRegistro.FE.ToString()))
				.ForMember(x => x.NifDeclarante, o => o.MapFrom(c => c.Cabecera.Titular.NIF))
				.ForMember(x => x.NombreRazon, o => o.MapFrom(c => c.Cabecera.Titular.NombreRazon))
				.ForMember(x => x.Periodo, o => o.MapFrom(c => c.PeriodoLiquidacion.Periodo))
				.ForMember(x => x.Ejercicio, o => o.MapFrom(c => c.PeriodoLiquidacion.Ejercicio));

			CreateMap<RespuestaConsultaDatosFacturaEmitida, EDatosComplementarios>()
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.ClaveRegimen1, o => o.MapFrom(c => c.ClaveRegimenEspecialOTrascendenciaAdicional1))
				.ForMember(x => x.ClaveRegimen2, o => o.MapFrom(c => c.ClaveRegimenEspecialOTrascendenciaAdicional2))
				.ForMember(x => x.SimplificadaArt, o => o.MapFrom(c => c.FacturaSimplificadaArticulos72_73))
				.ForMember(x => x.SinDestinatario, o => o.MapFrom(c => c.FacturaSinIdentifDestinatarioAritculo61d))
				.ForMember(x => x.Macrodato, o => o.MapFrom(c => c.Macrodato))
				.ForMember(x => x.RefExterna, o => o.MapFrom(c => c.RefExterna))
				.ForMember(x => x.NifSucedida, o => o.MapFrom(c => c.EntidadSucedida.NIF))
				.ForMember(x => x.NombreSucedida, o => o.MapFrom(c => c.EntidadSucedida.NombreRazon))
				.ForMember(x => x.RegPrevio, o => o.MapFrom(c => c.RegPrevioGGEEoREDEMEoCompetencia))
				.ForMember(x => x.NumRegistroAcuerdoFacturacion, o => o.MapFrom(c => c.NumRegistroAutorizacionFacturacion))
				.ForMember(x => x.FacturaEnergia, o => o.MapFrom(c => c.FacturacionDispAdicionalTerceraYsextayDelMercadoOrganizadoDelGas));

			CreateMap<RespuestaConsultaDatosDescuadreContraparte, EDatosDescuadreContraparte>()
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.SumBaseImponibleISP, o => o.MapFrom(c => c.SumBaseImponibleISP.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.SumBaseImponible, o => o.MapFrom(c => c.SumBaseImponible.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.SumCuota, o => o.MapFrom(c => c.SumCuota.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.SumCuotaRecargoEquivalencia, o => o.MapFrom(c => c.SumCuotaRecargoEquivalencia.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.ImporteTotal, o => o.MapFrom(c => c.ImporteTotal.Trim().Replace(".", ",").parseToDecimal()));

			CreateMap<RespuestaConsultaDetalleInmueble, EDetalleInmueble>()
				.ForMember(x => x.Id, o => o.Ignore())
				.ForMember(x => x.IdRegistroInformacion, o => o.Ignore())
				.ForMember(x => x.SituacionInmueble, o => o.MapFrom(c => c.SituacionInmueble.parseToInt()))
				.ForMember(x => x.ReferenciaCatastral, o => o.MapFrom(c => c.ReferenciaCatastral));

			CreateMap<Entities.Model.BaseType.Consulta.Response.AEAT.RegistroRespuestaConsultaLRFacturasEmitidas, ERegistroInformacion>()
				.ForMember(x => x.IdLibroRegistro, o => o.MapFrom(c => EnumLibroRegistro.FE.ToString()))
				.ForMember(x => x.NumSerieFacturaEmisor, o => o.MapFrom(c => c.IDFactura.NumSerieFacturaEmisor.Trim()))
				.ForMember(x => x.NumSerieFacturaEmisorResumenFin, o => o.MapFrom(c => c.IDFactura.NumSerieFacturaEmisorResumenFin.Trim()))
				.ForMember(x => x.FechaExpedicionFacturaEmisor, o => o.MapFrom(c => !string.IsNullOrEmpty(c.IDFactura.FechaExpedicionFacturaEmisor)
							? c.IDFactura.FechaExpedicionFacturaEmisor.parseToDateTime() : new DateTime(1900, 1, 1)))
				.ForMember(x => x.NifFacturaEmisor, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.NIF.Trim()))
				.ForMember(x => x.IDIdFactura, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.IDOtro.ID.Trim()))
				.ForMember(x => x.IDTypeIdFactura, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.IDOtro.IDType.Trim()))
				.ForMember(x => x.CodigoPaisIdFactura, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.IDOtro.CodigoPais.Trim()))

				.ForMember(x => x.TipoFactura, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaEmitida.TipoFactura) ? c.DatosFacturaEmitida.TipoFactura : null))
				.ForMember(x => x.TipoRectificativa, o => o.MapFrom(c => c.DatosFacturaEmitida.TipoRectificativa))
				.ForMember(x => x.FechaOperacion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaEmitida.FechaOperacion)
							? c.DatosFacturaEmitida.FechaOperacion.parseToNullableDateTime() : null))
				.ForMember(x => x.ClaveRegimenEspecialOTrascendencia, o => o.MapFrom(c => c.DatosFacturaEmitida.ClaveRegimenEspecialOTrascendencia))
				.ForMember(x => x.ImporteTotal, o => o.MapFrom(c => c.DatosFacturaEmitida.ImporteTotal.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.BaseImponibleACoste, o => o.MapFrom(c => c.DatosFacturaEmitida.BaseImponibleACoste.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.DescripcionOperacion, o => o.MapFrom(c => c.DatosFacturaEmitida.DescripcionOperacion))
				.ForMember(x => x.ImporteTransmisionSujetoAIVA, o => o.MapFrom(c => c.DatosFacturaEmitida.ImporteTransmisionInmueblesSujetoAIVA.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.EmitidaPorTerceros, o => o.MapFrom(c => c.DatosFacturaEmitida.EmitidaPorTercerosODestinatario))
				.ForMember(x => x.VariosDestinatarios, o => o.MapFrom(c => c.DatosFacturaEmitida.VariosDestinatarios))
				.ForMember(x => x.Cupon, o => o.MapFrom(c => c.DatosFacturaEmitida.Cupon))
				.ForMember(x => x.BaseRectificada, o => o.MapFrom(c => c.DatosFacturaEmitida.ImporteRectificacion.BaseRectificada.Trim().Replace(".", ",").parseToNullableDecimal()))
				.ForMember(x => x.CuotaRectificada, o => o.MapFrom(c => c.DatosFacturaEmitida.ImporteRectificacion.CuotaRectificada.Trim().Replace(".", ",").parseToNullableDecimal()))
				.ForMember(x => x.CuotaRecargoRectificada, o => o.MapFrom(c => c.DatosFacturaEmitida.ImporteRectificacion.CuotaRecargoRectificado.Trim().Replace(".", ",").parseToNullableDecimal()))
				.ForMember(x => x.DesgloseTipoOperacion, o => o.MapFrom(c => c.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega != null ? 1 : 2))

				.ForMember(x => x.NifContraparte, o => o.MapFrom(c => c.DatosFacturaEmitida.Contraparte.NIF))
				.ForMember(x => x.NombreContraparte, o => o.MapFrom(c => c.DatosFacturaEmitida.Contraparte.NombreRazon))
				.ForMember(x => x.NIFRepresentante, o => o.MapFrom(c => c.DatosFacturaEmitida.Contraparte.NIFRepresentante))
				.ForMember(x => x.CodigoPaisContraparte, o => o.MapFrom(c => c.DatosFacturaEmitida.Contraparte.IDOtro.CodigoPais))
				.ForMember(x => x.IDTypeContraparte, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaEmitida.Contraparte.IDOtro.IDType) ? c.DatosFacturaEmitida.Contraparte.IDOtro.IDType : null))
				.ForMember(x => x.IDContraparte, o => o.MapFrom(c => c.DatosFacturaEmitida.Contraparte.IDOtro.ID.Trim()))
				.ForMember(x => x.TipoDesglose, o => o.MapFrom(c => c.DatosFacturaEmitida.TipoDesglose.DesgloseFactura != null ? 1 : 2))

				.ForMember(x => x.IdEstadoCuadre, o => o.MapFrom(c => c.EstadoFactura.EstadoCuadre))
				.ForMember(x => x.IdEstadoRegistro, o => o.MapFrom(c => c.EstadoFactura.EstadoRegistro.ToNullableEnumEstadoRegistro()))
				.ForMember(x => x.CodigoErrorRegistro, o => o.MapFrom(c => !string.IsNullOrEmpty(c.EstadoFactura.CodigoErrorRegistro) ? c.EstadoFactura.CodigoErrorRegistro.Trim().parseToNullableInt() : null))
				.ForMember(x => x.DescripcionErrorRegistro, o => o.MapFrom(c => !string.IsNullOrEmpty(c.EstadoFactura.DescripcionErrorRegistro) ? c.EstadoFactura.DescripcionErrorRegistro.Trim().parseToNullableInt() : null));


			CreateMap<Entities.Model.BaseType.Consulta.Response.AEAT.RespuestaConsultaLRFacturasRecibidas, ERegistroInformacion>()
				.ForMember(x => x.IdLibroRegistro, o => o.MapFrom(c => EnumLibroRegistro.FR.ToString()))
				.ForMember(x => x.NifDeclarante, o => o.MapFrom(c => c.Cabecera.Titular.NIF))
				.ForMember(x => x.NombreRazon, o => o.MapFrom(c => c.Cabecera.Titular.NombreRazon))
				.ForMember(x => x.Periodo, o => o.MapFrom(c => c.PeriodoLiquidacion.Periodo))
				.ForMember(x => x.Ejercicio, o => o.MapFrom(c => c.PeriodoLiquidacion.Ejercicio));

			CreateMap<Entities.Model.BaseType.Consulta.Response.AEAT.RegistroRespuestaConsultaLRFacturasRecibidas, ERegistroInformacion>()
				.ForMember(x => x.IdLibroRegistro, o => o.MapFrom(c => EnumLibroRegistro.FR.ToString()))
				.ForMember(x => x.NifFacturaEmisor, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.NIF.Trim()))
				.ForMember(x => x.NumSerieFacturaEmisor, o => o.MapFrom(c => c.IDFactura.NumSerieFacturaEmisor.Trim()))
				.ForMember(x => x.FechaExpedicionFacturaEmisor, o => o.MapFrom(c => !string.IsNullOrEmpty(c.IDFactura.FechaExpedicionFacturaEmisor)
							? c.IDFactura.FechaExpedicionFacturaEmisor.parseToDateTime() : new DateTime(1900, 1, 1)))
				.ForMember(x => x.IDIdFactura, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.IDOtro.ID.Trim()))
				.ForMember(x => x.CodigoPaisIdFactura, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.IDOtro.CodigoPais.Trim()))
				.ForMember(x => x.IDTypeIdFactura, o => o.MapFrom(c => c.IDFactura.IDEmisorFactura.IDOtro.IDType.Trim()))

				.ForMember(x => x.IdEstadoCuadre, o => o.MapFrom(c => !string.IsNullOrEmpty(c.EstadoFactura.EstadoCuadre) ? c.EstadoFactura.EstadoCuadre.Trim().parseToNullableInt() : null))
				.ForMember(x => x.IdEstadoRegistro, o => o.MapFrom(c => c.EstadoFactura.EstadoRegistro.ToNullableEnumEstadoRegistro()))
				.ForMember(x => x.CodigoErrorRegistro, o => o.MapFrom(c => !string.IsNullOrEmpty(c.EstadoFactura.CodigoErrorRegistro) ? c.EstadoFactura.CodigoErrorRegistro.Trim().parseToNullableInt() : null))
				.ForMember(x => x.DescripcionErrorRegistro, o => o.MapFrom(c => !string.IsNullOrEmpty(c.EstadoFactura.DescripcionErrorRegistro) ? c.EstadoFactura.DescripcionErrorRegistro.Trim().parseToNullableInt() : null))

				.ForMember(x => x.NifContraparte, o => o.MapFrom(c => c.DatosFacturaRecibida.Contraparte.NIF))
				.ForMember(x => x.NombreContraparte, o => o.MapFrom(c => c.DatosFacturaRecibida.Contraparte.NombreRazon))
				.ForMember(x => x.NIFRepresentante, o => o.MapFrom(c => c.DatosFacturaRecibida.Contraparte.NIFRepresentante))
				.ForMember(x => x.CodigoPaisContraparte, o => o.MapFrom(c => c.DatosFacturaRecibida.Contraparte.IDOtro.CodigoPais))
				.ForMember(x => x.IDTypeContraparte, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaRecibida.Contraparte.IDOtro.IDType) ? c.DatosFacturaRecibida.Contraparte.IDOtro.IDType : null))
				.ForMember(x => x.IDContraparte, o => o.MapFrom(c => c.DatosFacturaRecibida.Contraparte.IDOtro.ID.Trim()))

				.ForMember(x => x.TipoFactura, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaRecibida.TipoFactura) ? c.DatosFacturaRecibida.TipoFactura : null))
				.ForMember(x => x.TipoRectificativa, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaRecibida.TipoRectificativa) ? c.DatosFacturaRecibida.TipoRectificativa : null))
				.ForMember(x => x.BaseRectificada, o => o.MapFrom(c => c.DatosFacturaRecibida.ImporteRectificacion.BaseRectificada.Trim().Replace(".", ",").parseToNullableDecimal()))
				.ForMember(x => x.CuotaRectificada, o => o.MapFrom(c => c.DatosFacturaRecibida.ImporteRectificacion.CuotaRectificada.Trim().Replace(".", ",").parseToNullableDecimal()))
				.ForMember(x => x.CuotaRecargoRectificada, o => o.MapFrom(c => c.DatosFacturaRecibida.ImporteRectificacion.CuotaRecargoRectificado.Trim().Replace(".", ",").parseToNullableDecimal()))
				.ForMember(x => x.FechaOperacion, o => o.MapFrom(c => c.DatosFacturaRecibida.FechaOperacion))
				.ForMember(x => x.ClaveRegimenEspecialOTrascendencia, o => o.MapFrom(c => c.DatosFacturaRecibida.ClaveRegimenEspecialOTrascendencia))
				.ForMember(x => x.ImporteTotal, o => o.MapFrom(c => c.DatosFacturaRecibida.ImporteTotal.Trim().Replace(".", ",").parseToDecimal()))
				.ForMember(x => x.BaseImponibleACoste, o => o.MapFrom(c => c.DatosFacturaRecibida.BaseImponibleACoste.parseToDecimal()))
				.ForMember(x => x.DescripcionOperacion, o => o.MapFrom(c => c.DatosFacturaRecibida.DescripcionOperacion))
				.ForMember(x => x.FechaRegContable, o => o.MapFrom(c => c.DatosFacturaRecibida.FechaRegContable.parseToNullableDateTime()))
				.ForMember(x => x.CuotaDeducible, o => o.MapFrom(c => c.DatosFacturaRecibida.CuotaDeducible.Trim().Replace(".", ",").parseToNullableDecimal()))

				.ForMember(x => x.TipoDesglose, o => o.MapFrom(c => 1))
				.ForMember(x => x.DesgloseTipoOperacion, o => o.MapFrom(c => c.DatosFacturaRecibida.DesgloseFactura.InversionSujetoPasivo != null ? 1 : 2))
				.ForMember(x => x.ADeducirEnPeriodoPosterior, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaRecibida.ADeducirEnPeriodoPosterior) ? c.DatosFacturaRecibida.ADeducirEnPeriodoPosterior.Trim() : null))
				.ForMember(x => x.EjercicioDeduccion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaRecibida.EjercicioDeduccion) ? c.DatosFacturaRecibida.EjercicioDeduccion.Trim().parseToNullableInt() : null))
				.ForMember(x => x.PeriodoDeduccion, o => o.MapFrom(c => !string.IsNullOrEmpty(c.DatosFacturaRecibida.PeriodoDeduccion) ? c.DatosFacturaRecibida.PeriodoDeduccion.Trim() : null));


			#endregion
		}
	}

	/// <summary>
	/// this class defines the TaxAgency settings
	/// </summary>
	public class PathsSettings
	{
		public string CsvFilesDirectory { get; set; }
		public string TempFilesDirectory { get; set; }
		public string XmlRequestDirectory { get; set; }
		public string XmlResponseDirectory { get; set; }
	}

	/// <summary>
	/// this class defines the TaxAgency settings
	/// </summary>
	public class TaxAgencySettings
	{
		public int MaxAllowedRecordsCount { get; set; }
		public int CurlCommandTimeOut { get; set; }
		public int CurlConnectionTimeOut { get; set; }
		public string CurlProgramPath { get; set; }
		public CertificateSettings CertificateSettings { get; set; }
	}

	/// <summary>
	/// this class defines the Certificate settings
	/// </summary>
	public class CertificateSettings
	{
		public string Certificate { get; set; }
		public string CertificateKey { get; set; }
	}

	/// <summary>
	/// this class defines the Certificate settings
	/// </summary>
	public class AccountSettings
	{
		public int PasswordExpirationDays { get; set; }
	}
	public static class DatabaseConstants
	{

		#region "Database Name"

		/// <summary>
		/// SII CONNECTIONSTRING instance Properties.Resources.ResourceManager.GetString("SII_CONNECTIONSTRING"); 
		/// </summary>
		//public static string DAO_SIIAUTHENTICATION_CONNECTIONSTRING = @"Data Source=siisql;Initial Catalog=B08996274;Integrated Security=False;User Id=SiiAuthenticationUser;Password=SiiVerano17@@;MultipleActiveResultSets=True";
		//public static string DAO_SII_CONNECTIONSTRING = @"Data Source=DESKTOP-PANBFFQ\SQLSERVEREXPRESS;Initial Catalog=gesisa;Integrated Security=True";
		//public static string DAO_SIIAUTHENTICATION_CONNECTIONSTRING = @"Data Source=ADNAN\SQLEXPRESS;Initial Catalog=SiiAuthentication;Integrated Security=True";
		//public static string DAO_SIIAUTHENTICATION_CONNECTIONSTRING = @"Data Source=siitest\SQLEXPRESS;Initial Catalog=SiiAuthentication;Integrated Security=True";
		public static string DAO_SIIAUTHENTICATION_CONNECTIONSTRING;// = Properties.Settings.Default.SiiConnectionString;




		/// <summary>
		/// AGREGADORCRUCEROS instance
		/// </summary>  
		#endregion

		#region "GET"
		/// <summary>
		/// Get EXEMPLE List
		/// </summary>
		/// 


		//AuthDB
		public static string USE_GET_USUARIO_BY_EMAIL = "USE_GET_USUARIO_BY_EMAIL";
		public static string USE_INSERT_UPDATE_USUARIO = "USE_INSERT_UPDATE_USUARIO";
		public static string USE_GET_USUARIO_BY_RESETCODE = "USE_GET_USUARIO_BY_RESETCODE";
		public static string USE_GET_USUARIO = "USE_GET_USUARIO";
		public static string USE_SELECT_USUARIOS = "USE_SELECT_USUARIOS";
		public static string SOC_SELECT_DATABASENAME = "SOC_SELECT_DATABASENAME";
		public static string COM_UPDATE_SOCIEDAD = "COM_UPDATE_SOCIEDAD";
		public static string COM_GET_SOCIEDAD = "COM_GET_SOCIEDAD";
		public static string USE_GET_SOCIEDAD_USUARIO = "USE_GET_SOCIEDAD_USUARIO";
		public static string SOC_INSERT_UPDATE_SOCIEDAD = "SOC_INSERT_UPDATE_SOCIEDAD";



		//SiiDB
		public static string DET_GET_DETALLE_INMUEBLE = "DET_GET_DETALLE_INMUEBLE";
		public static string REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO_ALL_RECORDS = "REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO_ALL_RECORDS";
		public static string CLA_GET_CLAVEREGIMEN_BY_IDLIBROREGISTRO = "CLA_GET_CLAVEREGIMEN_BY_IDLIBROREGISTRO";
		public static string TIP_GET_TIPOFACTURA = "TIP_GET_TIPOFACTURA";
		public static string IDT_GET_IDTYPE = "IDT_GET_IDTYPE";
		public static string PER_GET_PERIODOS_BY_TIPOPRESENTACION = "PER_GET_PERIODOS_BY_TIPOPRESENTACION";
		public static string PAR_GET_PARAMETERS_BY_USERID = "PAR_GET_PARAMETERS_BY_USERID";
		public static string PAR_GET_PARAMETERS_BY_NIF = "PAR_GET_PARAMETERS_BY_NIF";
		public static string CRD_GET_CREDENCIAL_BY_IDUSER = "CRD_GET_CREDENCIAL_BY_IDUSER";
		public static string CRD_GET_CREDENCIAL_BY_USERNAME = "CRD_GET_CREDENCIAL_BY_USERNAME";
		public static string OPE_GET_OPERATIONS_BY_FILTER = "OPE_GET_OPERATIONS_BY_FILTER";
		public static string OPE_GET_OPERATION_BY_ID_AND_USER = "OPE_GET_OPERATION_BY_ID_AND_USER";
		public static string OPR_GET_OPERATION_BY_USER = "OPR_GET_OPERATION_BY_USER";
		public static string RIN_GET_ID_REGISTRO_INFORMATIO_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA = "RIN_GET_ID_REGISTRO_INFORMATIO_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA";
		public static string CLI_GET_CLIENT_BY_NIF = "CLI_GET_CLIENT_BY_NIF";
		public static string USR_GET_EMAIL_BY_IDUSER = "USR_GET_EMAIL_BY_IDUSER";

		public static string REG_GET_REGISTROINFORMACION_BY_NIFEMISOR_NUMSERIE_FECHAEXPEDICION = "REG_GET_REGISTROINFORMACION_BY_NIFEMISOR_NUMSERIE_FECHAEXPEDICION";
		public static string REG_GET_REGISTROSINFORMACION_BY_FILTER = "REG_GET_REGISTROSINFORMACION_BY_FILTER";
		public static string REG_GET_REGISTROINFORMACION_BY_ID = "REG_GET_REGISTROINFORMACION_BY_ID";
		public static string REG_GET_ESTADO_LECTURA_BY_IDREGISTRO = "REG_GET_ESTADO_LECTURA_BY_IDREGISTRO";
		public static string REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO = "REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO";
		public static string REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO_INDEX = "REG_GET_REGISTROS_BY_EJERCICIO_PERIODO_LIBRO_INDEX";
		public static string OPE_GET_LATEST_OPERATIONS = "OPE_GET_LATEST_OPERATIONS";
		public static string OPE_GET_LATEST_OPERATIONS_BY_FILTER = "OPE_GET_LATEST_OPERATIONS_BY_FILTER";
		public static string REG_GET_REGISTROS_APROCESAR = "REG_GET_REGISTROS_APROCESAR";
		public static string REG_GET_REGISTROS_PENDIENTES_CORRECCION = "REG_GET_REGISTROS_PENDIENTES_CORRECCION";

		public static string TOP_GET_TIPOOPERATION = "TOP_GET_TIPOOPERATION";
		public static string ROP_GET_RESULTADOOPERATION = "ROP_GET_RESULTADOOPERATION";
		public static string EOP_GET_ESTADOOPERATION = "EOP_GET_ESTADOOPERATION";
		public static string ERG_GET_ESTADOREGISTRO = "ERG_GET_ESTADOREGISTRO";
		public static string LRG_GET_LIBROREGISTRO = "LRG_GET_LIBROREGISTRO";

		public static string DET_GET_DETALLE_IMPORTES_IVA = "DET_GET_DETALLE_IMPORTES_IVA";
		public static string FAG_GET_FACTURAS_AGRUPADAS = "FAG_GET_FACTURAS_AGRUPADAS";
		public static string FRC_GET_FACTURAS_RECTIFICADAS = "FRC_GET_FACTURAS_RECTIFICADAS";
		public static string COB_GET_COBROS_EMITIDAS = "COB_GET_COBROS_EMITIDAS";
		public static string PAG_GET_PAGOS_RECIBIDAS = "PAG_GET_PAGOS_RECIBIDAS";
		public static string ROP_GET_REGISTROOPERACION_BY_ID_REGISTROINFORMACION = "ROP_GET_REGISTROOPERACION_BY_ID_REGISTROINFORMACION";

		public static string OPE_GET_OPERACIONES_BY_EJERCICIO_AND_LIBRO = "OPE_GET_OPERACIONES_BY_EJERCICIO_AND_LIBRO";
		public static string REG_GET_FACTURAS_BY_LIBRO_ESTADO = "REG_GET_FACTURAS_BY_LIBRO_ESTADO";

		public static string REG_GET_FACTURAS_MODIFICADA_BAJA = "REG_GET_FACTURAS_MODIFICADA_BAJA";

		public static string REG_GET_OPEARACIONES_TO_MODAL = "REG_GET_OPEARACIONES_TO_MODAL";

		public static string GET_REG_LIQUIDACION = "GET_REG_LIQUIDACION";

		public static string REG_GET_LIQUIDACION_BY_FILTER = "REG_GET_LIQUIDACION_BY_FILTER";

		public static object REG_GET_LIQUIDACION_BY_FILTER_BY_PAGINA { get; set; }

		public static string LIQ_GET_LIQUIDACION_BY_PERIODIFICACION = "LIQ_GET_LIQUIDACION_BY_PERIODIFICACION";

		public static string LIQ_GET_LIQUIDACION_BY_PERIODIFICACION_ATC = "LIQ_GET_LIQUIDACION_BY_PERIODIFICACION_ATC";

		public static string EST_GET_ESTADO_CUADRE = "EST_GET_ESTADO_CUADRE";

		public static string DAT_GET_DATOS_DESCUADRE_BY_IDREGISTRO = "DAT_GET_DATOS_DESCUADRE_BY_IDREGISTRO";

		public static string TIP_GET_TIPOBIENOPERACION = "TIP_GET_TIPOBIENOPERACION";

		public static string TIP_GET_TIPODOCUMENTO_ART25 = "TIP_GET_TIPODOCUMENTO_ART25";

		public static string REG_GET_REGISTROINFORMACION_IGIC_BYID = "REG_GET_REGISTROINFORMACION_IGIC_BYID";

		public static string CAU_GET_CAUSAEXENCION = "CAU_GET_CAUSAEXENCION";

		public static string CLI_GET_CLIENT_BY_USERID = "CLI_GET_CLIENT_BY_USERID";

		public static string LIQ_GET_LIQUIDACION_BY_PERIODIFICACION_ATC_DI = "LIQ_GET_LIQUIDACION_BY_PERIODIFICACION_ATC_DI";
		#endregion

		#region "INSERT/UPDATE"
		/// <summary>
		/// INSERT UPDATE 
		/// </summary>
		public static string REG_UPDATE_ESTADO_CUADRE = "REG_UPDATE_ESTADO_CUADRE";
		public static string DET_INSERT_DETALLE_INMUEBLE = "DET_INSERT_DETALLE_INMUEBLE";
		public static string USR_INSERT_OR_UPDATE_USUARIO = "USR_INSERT_OR_UPDATE_USUARIO";
		public static string CLI_INSERT_ASPNET_CLIENT_CONNECTION = "CLI_INSERT_ASPNET_CLIENT_CONNECTION";
		public static string USE_INSERT_ASP_NET_USER = "USE_INSERT_ASP_NET_USER";

		public static string OPR_INSERT_OR_UPDATE_OPERACION = "OPR_INSERT_OR_UPDATE_OPERACION";
		public static string CLT_INSERT_OR_UPDATE_CLIENTE = "CLT_INSERT_OR_UPDATE_CLIENTE";
		public static string DII_INSERT_OR_UPDATE_DETALLE_IMPORTES_IVA = "DII_INSERT_OR_UPDATE_DETALLE_IMPORTES_IVA";
		public static string RIN_INSERT_OR_UPDATE_REGISTRO_INFORMACION = "RIN_INSERT_OR_UPDATE_REGISTRO_INFORMACION";
		public static string LRG_INSERT_OR_UPDATE_LIBRO_REGISTRO = "LRG_INSERT_OR_UPDATE_LIBRO_REGISTRO";
		public static string ROP_INSERT_OR_UPDATE_REGISTROS_OPERACION = "ROP_INSERT_OR_UPDATE_REGISTROS_OPERACION";
		public static string TOP_INSERT_OR_UPDATE_TIPO_OPERACION = "TOP_INSERT_OR_UPDATE_TIPO_OPERACION";
		public static string ESO_INSERT_OR_UPDATE_ESTADO_OPERACION = "ESO_INSERT_OR_UPDATE_ESTADO_OPERACION";
		public static string RES_INSERT_OR_UPDATE_RESULTADO_OPERACION = "RES_INSERT_OR_UPDATE_RESULTADO_OPERACION";
		public static string FAG_INSERT_OR_UPDATE_FACTURAS_AGRUPADAS = "FAG_INSERT_OR_UPDATE_FACTURAS_AGRUPADAS";
		public static string FRC_INSERT_OR_UPDATE_FACTURAS_RECTIFICADAS = "FRC_INSERT_OR_UPDATE_FACTURAS_RECTIFICADAS";
		public static string CBR_INSERT_OR_UPDATE_COBROS = "CBR_INSERT_OR_UPDATE_COBROS";
		public static string PGO_INSERT_OR_UPDATE_PAGOS = "PGO_INSERT_OR_UPDATE_PAGOS";
		public static string ESR_INSERT_OR_UPDATE_ESTADO_REGISTRO = "ESR_INSERT_OR_UPDATE_ESTADO_REGISTRO";
		public static string TUS_INSERT_OR_UPDATE_TIPO_USUARIO = "TUS_INSERT_OR_UPDATE_TIPO_USUARIO";

		public static string REG_UPDATE_ESTADO_LECTURA_TO_PROCESSADA = "REG_UPDATE_ESTADO_LECTURA_TO_PROCESSADA";
		public static string REG_UPDATE_ESTADO_LECTURA_BY_ID = "REG_UPDATE_ESTADO_LECTURA_BY_ID";

		public static string REG_UPDATE_REGISTRO_INFORMACION_ESTADO = "REG_UPDATE_REGISTRO_INFORMACION_ESTADO";
		public static string REG_INSERT_UPDATE_DATOS_COMPLEMENTARIOS = "REG_INSERT_UPDATE_DATOS_COMPLEMENTARIOS";
		public static string PAR_INSERT_UPDATE_PARAMETERS_BY_CLIENTID = "PAR_INSERT_UPDATE_PARAMETERS_BY_CLIENTID";

		public static string DAT_INSERT_UPDATE_DATOS_DESCUADRE_CONTRAPARTE = "DAT_INSERT_UPDATE_DATOS_DESCUADRE_CONTRAPARTE";

		public static string REG_INSERT_UPDATE_REGISTROINFORMACION_IGIC = "REG_INSERT_UPDATE_REGISTROINFORMACION_IGIC";
		public static string REG_UPDATE_REGISTROINFORMACION = "REG_UPDATE_REGISTROINFORMACION";
		public static string CLI_UPDATE_CLIENTE = "CLI_UPDATE_CLIENTE";




		#endregion

		#region "DELETE"

		public static string DET_DELETE_DETALLE_INMUEBLE_BY_IDREGISTRO =
			"DET_DELETE_DETALLE_INMUEBLE_BY_IDREGISTRO";

		public static string DII_DELETE_DETALLE_IMPORTESIVA_BY_IDREGISTROINFORMACION =
			"DII_DELETE_DETALLE_IMPORTESIVA_BY_IDREGISTROINFORMACION";

		public static string FAG_DELETE_FACTURA_AGRUPADA_BY_IDREGISTROINFORMACION =
			"FAG_DELETE_FACTURA_AGRUPADA_BY_IDREGISTROINFORMACION";

		public static string FRC_DELETE_FACTURA_RECTIFICADA_BY_IDREGISTROINFORMACION =
			"FRC_DELETE_FACTURA_RECTIFICADA_BY_IDREGISTROINFORMACION";

		public static string RIN_BAJA_REGISTROINFORMACION_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA =
			"RIN_BAJA_REGISTROINFORMACION_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA";

		public static string COB_DELETE_COBROS_EMITIDAS_BY_IDREGISTROINFORMACION =
			"COB_DELETE_COBROS_EMITIDAS_BY_IDREGISTROINFORMACION";

		public static string PAG_DELETE_PAGOS_RECIBIDAS_BY_IDREGISTROINFORMACION =
			"PAG_DELETE_PAGOS_RECIBIDAS_BY_IDREGISTROINFORMACION";

		public static string RIN_BAJA_REGISTROINFORMACION_BY_ID =
					"RIN_BAJA_REGISTROINFORMACION_BY_ID";

		public static string PAG_DELETE_PAGO_BY_ID = "PAG_DELETE_PAGO_BY_ID";
		public static string COB_DELETE_COBRO_BY_ID = "COB_DELETE_COBRO_BY_ID";

		public static string MED_GET_MEDIO = "MED_GET_MEDIO";
		public static string REG_UPDATE_COBROPAGO_NOT_NUEVO = "REG_UPDATE_COBROPAGO_NOT_NUEVO";
		public static string REG_UPDATE_COBROPAGO_ESTADO = "REG_UPDATE_COBROPAGO_ESTADO";

		public static string OPE_GET_OPERATIONS_BY_CSV = "OPE_GET_OPERATIONS_BY_CSV";

		public static object REG_COUNT_REGISTROS_PENDIENTES_CORRECCION { get; set; }
		public static object REG_COUNT_REGISTROS_APROCESAR { get; set; }
		public static object OPE_UPDATE_COUNT_OPERACIONES_PERIODO { get; set; }
		public static object QUE_UPDATE_FILEQUEUE { get; set; }
		public static object QUE_GET_FILEQUEUE_BY_FILEGUID { get; set; }
		public static object STA_GET_STATION_BY_FILEGUID { get; set; }
		public static object OPE_INSERT_OPERATION { get; set; }
		public static object LOG_INSERT_LOGS { get; set; }
		public static string REG_GET_REGISTROS_INFORMATIO_BY_EJERCICIO { get; set; }
		public static object REG_UPDATE_REGISTRO_INFORMACION_FECHA_FIN_PLAZO { get; set; }
		public static object OPE_RECALCUL_OPERACIONES_PERIODO { get; set; }
		public static object REG_COUNT_REGISTROS_APROCESAR_LIBROS { get; set; }
		public static object REG_COUNT_REGISTROS_PENDIENTES_CORRECCION_LIBROS { get; set; }
		public static object LIB_COUNT_LIBROS { get; set; }
		public static object OPE_GET_OPERACIONES_PERIODOS_BY_EJERCICIO { get; set; }
		public static object REG_GET_REGISTROS_PENDIENTES_CORRECCION_ALL { get; set; }
		public static object REG_GET_REGISTROSINFORMACION_BY_FILTER_ALL { get; set; }
		public static object OPE_GET_LATEST_OPERATIONS_BY_FILTER_START_RECORDS { get; set; }
		public static object REG_UPDATE_REGISTRO_INFORMACION_FECHA_FIN_PLAZO_BY_TABLE { get; set; }
		public static object OPE_COUNT_OPERACIONES_USUARIO { get; set; }
		public static object USE_ELIMINAR_USUARIO { get; set; }
		public static object USE_UPDATE_FOTO { get; set; }

		public static string LIB_GET_LIBROS_BY_SELECTED_IDS = "LIB_GET_LIBROS_BY_SELECTED_IDS";
		public static string LIB_GET_LIBROS_BY_OTROS_FILTERS = "LIB_GET_LIBROS_BY_OTROS_FILTERS";
		public static string LIB_GET_LIBROS_BY_EJERCICIO_PERIODO_LIBRO = "LIB_GET_LIBROS_BY_EJERCICIO_PERIODO_LIBRO";
		public static string REG_GET_REGISTROS_ANULADOS = "REG_GET_REGISTROS_ANULADOS";
		#endregion

		#region "AuthV2"
		public static string COM_DELETE_COMPANYUSERS_BY_GESISAIDENTIFIER { get; } = "COM_DELETE_COMPANYUSERS_BY_GESISAIDENTIFIER";
		public static string USE_DELETE_USER { get; } = "USE_DELETE_USER";
		public static string COM_GET_COMPANYUSERS_BYFILTER { get; } = "COM_GET_COMPANYUSERS_BYFILTER";
		public static string COM_GET_COMPANY { get; } = "COM_GET_COMPANY";
		public static string COM_GET_COMPANYCONNECTION { get; } = "COM_GET_COMPANYCONNECTION";
		public static string USE_GET_USERS { get; } = "USE_GET_USERS";
		public static string COM_INSERT_COMPANY { get; } = "COM_INSERT_COMPANY";
		public static string COM_UPDATE_COMPANY { get; } = "COM_UPDATE_COMPANY";
		public static string COM_INSERT_COMPANYUSERS { get; } = "COM_INSERT_COMPANYUSERS";
		public static string COM_UPDATE_COMPANYUSERS { get; } = "COM_UPDATE_COMPANYUSERS";
		public static string USE_INSERT_USER { get; } = "USE_INSERT_USER";
		public static string USE_UPDATE_USER { get; } = "USE_UPDATE_USER";
		public static string CON_GET_CONSULTA_349 { get; } = "CON_GET_CONSULTA_349";
		public static string REG_GET_REGISTROS_CONSULTA_349 { get; set; } = "REG_GET_REGISTROS_CONSULTA_349";
		#endregion


	}

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
