using AutoMapper;

using Consultas.SII.Contracts;
using Consultas.SII.Entities;
using Consultas.SII.Entities.Enumerator;
using Consultas.SII.Entities.Model.BaseType.Consulta;
using Consultas.SII.Entities.Model.BaseType.Consulta.Request.Contraste;
using Consultas.SII.Entities.Model.BaseType.Consulta.Response.AEAT;
using Consultas.SII.Entities.Request;
using Consultas.SII.Helpers;

using Gesisa.Apps.Common;
using Gesisa.Apps.Common.Enums;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Services
{
    /// <summary>
    /// resolver for resolving soap endpoints
    /// </summary>
    public partial class AgencySoapEndPointResolver : IAgencySoapEndPointResolver
    {
        /// <inheritdoc/>
        public async Task<string> ResolveAsync(string agency, string invoiceType)
        {
            var communicationUrl = await _repository.GetAgencyCommunicationUrlAsync(agency, invoiceType);

            if (communicationUrl is null)
                return string.Empty;

            return communicationUrl.Url;
        }
    }

    /// <summary>
    /// partial part for <see cref="AgencySoapEndPointResolver"/>
    /// </summary>
    public partial class AgencySoapEndPointResolver : IAgencySoapEndPointResolver
    {
        private readonly IAgencyCommunicationUrlRepository _repository;

        public AgencySoapEndPointResolver(IAgencyCommunicationUrlRepository repository)
        {
            _repository = repository;
        }
    }
    public class ConsultationService : IConsultationService
    {
        private readonly IAgenciaTributariaService _agenciaTributariaService;
        private readonly IMapper _mapper;
        private readonly ISiiRepository _siiRepository;
        private readonly ILogger<ConsultationService> _loggerManager;

        public ConsultationService(IAgenciaTributariaService agenciaTributariaService,
            IMapper mapper,
            ISiiRepository siiRepository,
            ILogger<ConsultationService> loggerManager)
        {
            _agenciaTributariaService = agenciaTributariaService;
            _mapper = mapper;
            _siiRepository = siiRepository;
            _loggerManager = loggerManager;
        }
        public async Task<ListResult<ERegistroInformacion>> ConsultaLRAsync(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion = null)
        {
            List<ERegistroInformacion> mappedRegistros = new List<ERegistroInformacion>();
            try
            {
                do
                {
                    // 1. Map to request xml
                    string xmlRequestFile = CreateRequestFile(request, clavePaginacion);
                    // 2. Call Process Service
                    var result = await _agenciaTributariaService.SendXmlRequestAsync(request.IdAgencia, request.IdLibroRegistro, xmlRequestFile);
                    // 3. Map response
                    if (!result.IsSuccess())
                    {
                        // Log and return
                        _loggerManager.LogError($"{result.Message}");
                        return new ListResult<ERegistroInformacion>()
                        {
                            Message = result.Message,
                            Errors = result.Errors,
                            Code = result.Code,
                            LogTraceCode = result.LogTraceCode,
                            Status = result.Status,
                            Data = mappedRegistros
                        };
                    }
                    var xmlResponseFile = result.Data.ResponseXmlFilePath;
                    if (string.IsNullOrEmpty(xmlResponseFile) || !File.Exists(xmlResponseFile))
                    {

                        _loggerManager.LogError($"FileNotFound: failed to read consultation xml response '{xmlResponseFile}'");
                        return new ListResult<ERegistroInformacion>()
                        {
                            Message = result.Message,
                            Errors = result.Errors,
                            Code = result.Code,
                            LogTraceCode = result.LogTraceCode,
                            Status = result.Status,
                            Data = mappedRegistros
                        };
                    }


                    XmlFiles.NewResponseNamespaceSerializer(xmlResponseFile, request.IdAgencia);
                    RespuestaConsultaEnvelope xmlResponse = XmlFiles.DeserializeXMLFileToObject<RespuestaConsultaEnvelope>(xmlResponseFile);
                    clavePaginacion = GetClavePaginacion(xmlResponse, request);
                    var resultRespuesta = MapResponse(xmlResponse);
                    if (resultRespuesta.Any())
                    {
                        mappedRegistros.AddRange(resultRespuesta);
                    }
                    else
                    {
                        _loggerManager.LogError($"failed to Map consultation xml response '{xmlResponseFile}'");
                    }
                } while (clavePaginacion != null);

                // 4. Register to a fake database
                foreach (var registro in mappedRegistros)
                {
                    _siiRepository.InsertUpdateRegistroInformacion(registro, "A0", request.IdAgencia);
                }

                // 5. Log and return 
                return mappedRegistros;
            }
            catch (NotImplementedException ex)
            {
                return new ListResult<ERegistroInformacion>()
                {
                    Message = $"NotImplementedException: reached a not implmented code, {ex.Message}",
                    Errors = Result.GetErrorsFromException(ex),
                    Code = ResultCode.NotFound,
                    Status = ResultStatus.Failed,
                    Data = mappedRegistros
                };
            }
            catch (ArgumentException ex)
            {

                return new ListResult<ERegistroInformacion>()
                {
                    Message = $"ArgumentException: {ex.Message}",
                    Errors = Result.GetErrorsFromException(ex),
                    Code = ResultCode.ValidationFailed,
                    Status = ResultStatus.Failed,
                    Data = mappedRegistros
                };
            }
            catch (Exception ex)
            {
                return new ListResult<ERegistroInformacion>()
                {
                    Message = $"{ex.GetType().Name}: {ex.Message}",
                    Errors = Result.GetErrorsFromException(ex),
                    Code = ResultCode.OperationFailedException,
                    Status = ResultStatus.Failed,
                    Data = mappedRegistros
                };
            }
            List<ERegistroInformacion> MapResponse(RespuestaConsultaEnvelope xmlResponse)
            {
                List<ERegistroInformacion> eRegistros = new List<ERegistroInformacion>();
                if (xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas != null)
                {
                    var initialRegistro = _mapper.Map<RespuestaConsultaLRFacturasEmitidas, ERegistroInformacion>(xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas);
                    if (xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas.RegistroRespuestaConsultaLRFacturasEmitidas != null &&
                        xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas.RegistroRespuestaConsultaLRFacturasEmitidas.Any())
                    {
                        foreach (var vRegistroConsulta in xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas.RegistroRespuestaConsultaLRFacturasEmitidas)
                        {
                            var mapperdRegistro = MapRegistroRespuestaConsultaLRFacturasEmitidas(request, initialRegistro, vRegistroConsulta);
                            eRegistros.Add(mapperdRegistro);
                        }
                    }
                }
                else if (xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas != null)
                {
                    var initialRegistro = _mapper.Map<RespuestaConsultaLRFacturasRecibidas, ERegistroInformacion>(xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas);
                    if (xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas.RegistroRespuestaConsultaLRFacturasRecibidas != null &&
                        xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas.RegistroRespuestaConsultaLRFacturasRecibidas.Any())
                    {
                        foreach (var vRegistroConsulta in xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas.RegistroRespuestaConsultaLRFacturasRecibidas)
                        {
                            var mapperdRegistro = MapRegistroRespuestaConsultaLRFacturasRecibidas(request, initialRegistro, vRegistroConsulta);
                            eRegistros.Add(mapperdRegistro);
                        }
                    }
                }

                return eRegistros;
            }
            ConsultaLRFacturasEmitidas GetConsultaLRFacturasEmitidas(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion)
            {
                ConsultaLRFacturasEmitidas consultaLR;
                        consultaLR = new ConsultaLRFacturasEmitidas()
                        {
                            Cabecera = GetConsultaCabecera(request.CompanyNif, request.CompanyDenomination, request.IdAgencia),
                            FiltroConsulta = GetConsultaFiltroConsulta(request, request.IdAgencia, clavePaginacion)
                        };
                        return consultaLR;
            }
            ConsultaLRFacturasRecibidas GetConsultaLRFacturasRecibidas(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion)
            {
                ConsultaLRFacturasRecibidas consultaLR;
                        consultaLR = new ConsultaLRFacturasRecibidas()
                        {
                            Cabecera = GetConsultaCabecera(request.CompanyNif, request.CompanyDenomination, request.IdAgencia),
                            FiltroConsulta = GetConsultaFiltroConsulta(request, request.IdAgencia, clavePaginacion)
                        };
                        return consultaLR;
            }
            ConsultaFiltroConsulta GetConsultaFiltroConsulta(ConsultaFacturasRequest request, string idAgencia, ConsultaClavePaginacion clavePaginacion = null)
            {
                ConsultaPeriodoImpositivo periodoImpositivo = null;
                ConsultaPeriodoLiquidacion periodoLiquidacion = null;
                if (idAgencia == "ATC")
                {
                    periodoImpositivo = new ConsultaPeriodoImpositivo()
                    {
                        Ejercicio = request.Ejercicio,
                        Periodo = request.Periodo
                    };
                }
                else
                {
                    periodoLiquidacion = new ConsultaPeriodoLiquidacion()
                    {
                        Ejercicio = request.Ejercicio,
                        Periodo = request.Periodo
                    };
                }

                return new ConsultaFiltroConsulta()
                {
                    PeriodoLiquidacion = periodoLiquidacion,
                    PeriodoImpositivo = periodoImpositivo,
                    ClavePaginacion = clavePaginacion
                };
            }
            ConsultaCabecera GetConsultaCabecera(string nif, string denominacion, string idAgencia)
            {
                return new ConsultaCabecera()
                {
                    IDVersionSii = idAgencia == "ATC" ? 1.0m : 1.1m,
                    Titular = new ConsultaTitular()
                    {
                        NIF = nif,
                        NombreRazon = denominacion
                    },
                };
            }
            ConsultaClavePaginacion GetClavePaginacion(RespuestaConsultaEnvelope xmlResponse, ConsultaFacturasRequest request)
            {
                ConsultaClavePaginacion clavePaginacion = null;


                if (request.IdLibroRegistro.Equals(EnumLibroRegistro.FE.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas?.IndicadorPaginacion == "S" &&
                    xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas.RegistroRespuestaConsultaLRFacturasEmitidas.Any())
                    {
                        var last = xmlResponse.Body.RespuestaConsultaLRFacturasEmitidas.RegistroRespuestaConsultaLRFacturasEmitidas.LastOrDefault();
                        clavePaginacion = new ConsultaClavePaginacion()
                        {
                            FechaExpedicionFacturaEmisor = last.IDFactura.FechaExpedicionFacturaEmisor,
                            NumSerieFacturaEmisor = last.IDFactura.NumSerieFacturaEmisor,
                            IDEmisorFactura = new ConsultaIDEmisorFactura()
                            {
                                NIF = last.IDFactura.IDEmisorFactura.NIF
                            }
                        };
                    }
                }
                else if (request.IdLibroRegistro.Equals(EnumLibroRegistro.FR.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas?.IndicadorPaginacion == "S" &&
                        xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas.RegistroRespuestaConsultaLRFacturasRecibidas.Any())
                    {
                        var last = xmlResponse.Body.RespuestaConsultaLRFacturasRecibidas.RegistroRespuestaConsultaLRFacturasRecibidas.LastOrDefault();
                        clavePaginacion = new ConsultaClavePaginacion()
                        {
                            FechaExpedicionFacturaEmisor = last.IDFactura.FechaExpedicionFacturaEmisor,
                            NumSerieFacturaEmisor = last.IDFactura.NumSerieFacturaEmisor,
                            IDEmisorFactura = new ConsultaIDEmisorFactura()
                            {
                                NIF = last.IDFactura.IDEmisorFactura.NIF
                            }
                        };
                    }
                }
                return clavePaginacion;
            }
            string CreateRequestFile(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion)
            {
                string xmlRequestFile;
                if (request.IdLibroRegistro.Equals(EnumLibroRegistro.FE.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    var consultaFE = GetConsultaLRFacturasEmitidas(request, clavePaginacion);
                    xmlRequestFile = XmlFiles.CreateXmlFileFromModel(consultaFE, ".xml");
                    XmlFiles.NewNamespaceSerializer(xmlRequestFile, request.IdAgencia);
                }
                else if (request.IdLibroRegistro.Equals(EnumLibroRegistro.FR.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    var consultaFR = GetConsultaLRFacturasRecibidas(request, clavePaginacion);
                    xmlRequestFile = XmlFiles.CreateXmlFileFromModel(consultaFR, ".xml");
                    XmlFiles.NewNamespaceSerializer(xmlRequestFile, request.IdAgencia);
                }
                else
                {
                    throw new NotImplementedException($"Consultation not implemented for this document type '{request.IdLibroRegistro}'");
                }

                return xmlRequestFile;
            }

        }

        private ERegistroInformacion MapRegistroRespuestaConsultaLRFacturasEmitidas(ConsultaFacturasRequest request, ERegistroInformacion registro, RegistroRespuestaConsultaLRFacturasEmitidas vRegistroConsulta)
        {
            var mapperdRegistro = _mapper.Map<RegistroRespuestaConsultaLRFacturasEmitidas, ERegistroInformacion>(vRegistroConsulta);
            mapperdRegistro.NombreRazon = registro.NombreRazon;
            mapperdRegistro.Ejercicio = registro.Ejercicio;
            mapperdRegistro.Periodo = registro.Periodo;
            mapperdRegistro.NifDeclarante = registro.NifDeclarante;
            if (vRegistroConsulta.DatosFacturaEmitida.FacturasAgrupadas != null && vRegistroConsulta.DatosFacturaEmitida.FacturasAgrupadas.Any())
                mapperdRegistro.ListFacturasAgrupadas = vRegistroConsulta.DatosFacturaEmitida.FacturasAgrupadas.Select(x => _mapper.Map<RespuestaConsultaIDFacturaAgrupada, EFacturasAgrupadas>(x)).ToList();
            if (vRegistroConsulta.DatosFacturaEmitida.FacturasRectificadas != null && vRegistroConsulta.DatosFacturaEmitida.FacturasRectificadas.Any())
                mapperdRegistro.ListFacturasRectificadas = vRegistroConsulta.DatosFacturaEmitida.FacturasRectificadas.Select(x => _mapper.Map<RespuestaConsultaIDFacturaRectificada, EFacturasRectificadas>(x)).ToList();
            if (vRegistroConsulta.DatosDescuadreContraparte != null)
                mapperdRegistro.DatosDescuadreContraparte = _mapper.Map<RespuestaConsultaDatosDescuadreContraparte, EDatosDescuadreContraparte>(vRegistroConsulta.DatosDescuadreContraparte);
            mapperdRegistro.DatosComplementarios = _mapper.Map<RespuestaConsultaDatosFacturaEmitida, EDatosComplementarios>(vRegistroConsulta.DatosFacturaEmitida);

            if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura != null)
            {
                List<EDetalleImportesIVA> vDetalleImportesIvaDesglose = new List<EDetalleImportesIVA>();
                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta != null)
                {
                    if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.Exenta != null && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.Exenta.Any())
                    {
                        mapperdRegistro.CausaExencion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.Exenta[0].CausaExencion;
                        mapperdRegistro.BaseImponible = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.Exenta[0].BaseImponible?.Trim()?.Replace(".", ",").parseToDecimal();
                    }
                    if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta != null)
                    {
                        mapperdRegistro.TipoNoExenta = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.TipoNoExenta;
                        if (request.IdAgencia != "ATC")
                        {
                            if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.DesgloseIVA != null
                                && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.DesgloseIVA.Any())
                            {
                                vDetalleImportesIvaDesglose = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                                    .DesgloseFactura.Sujeta.NoExenta.DesgloseIVA.Select(x => _mapper.Map<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>(x)).ToList();
                                vDetalleImportesIvaDesglose.ForEach(x => x.IdTipoDetalleIVA = 0);
                            }
                        }
                        else
                        {
                            if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.DesgloseIGIC != null
                                && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.DesgloseIGIC.Any())
                            {
                                vDetalleImportesIvaDesglose = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                                    .DesgloseFactura.Sujeta.NoExenta.DesgloseIGIC.Select(x => _mapper.Map<RespuestaConsultaDetalleIGIC, EDetalleImportesIVA>(x)).ToList();
                                vDetalleImportesIvaDesglose.ForEach(x => x.IdTipoDetalleIVA = 0);
                            }
                        }
                    }
                }
                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.NoSujeta != null)
                {
                    if (request.IdAgencia == "ATC")
                    {
                        mapperdRegistro.ImportePorArticulos7_14_Otros = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.NoSujeta.ImportePorArticulos9_Otros?.Trim()?.Replace(".", ",").parseToDecimal();
                    }
                    else
                    {
                        mapperdRegistro.ImportePorArticulos7_14_Otros = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.NoSujeta.ImportePorArticulos7_14_Otros?.Trim()?.Replace(".", ",").parseToDecimal();
                    }
                    mapperdRegistro.ImporteTAIReglasLocalizacion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseFactura.NoSujeta.ImporteTAIReglasLocalizacion?.Trim()?.Replace(".", ",").parseToDecimal();
                }

                if (mapperdRegistro.ListDetailIva != null)
                {
                    mapperdRegistro.ListDetailIva.AddRange(vDetalleImportesIvaDesglose);
                }
                else if (mapperdRegistro.ListDetailIva == null && vDetalleImportesIvaDesglose.Any())
                {
                    mapperdRegistro.ListDetailIva = vDetalleImportesIvaDesglose;
                }
            }
            if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion != null)
            {

                List<EDetalleImportesIVA> vDetalleImportesIvaPrestacion = new List<EDetalleImportesIVA>();
                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                        .DesgloseTipoOperacion.PrestacionServicios != null)
                {
                    if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta != null)
                    {
                        if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.Exenta != null && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.Exenta.Any())
                        {
                            mapperdRegistro.CausaExencion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.Exenta[0].CausaExencion;
                            mapperdRegistro.BaseImponible = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.Exenta[0].BaseImponible?.Trim()?.Replace(".", ",").parseToDecimal();
                        }
                        if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta != null)
                        {
                            mapperdRegistro.TipoNoExenta = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.TipoNoExenta;
                            if (request.IdAgencia != "ATC")
                            {
                                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.DesgloseIVA != null
                                                                && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.DesgloseIVA.Any())
                                {
                                    vDetalleImportesIvaPrestacion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                                        .DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.DesgloseIVA.Select(x => _mapper.Map<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>(x)).ToList();
                                    vDetalleImportesIvaPrestacion.ForEach(x => x.IdTipoDetalleIVA = 3);

                                }
                            }
                            else
                            {
                                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.DesgloseIGIC != null
                                                                                                        && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.DesgloseIGIC.Any())
                                {
                                    vDetalleImportesIvaPrestacion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                                        .DesgloseTipoOperacion.PrestacionServicios.Sujeta.NoExenta.DesgloseIGIC.Select(x => _mapper.Map<RespuestaConsultaDetalleIGIC, EDetalleImportesIVA>(x)).ToList();
                                    vDetalleImportesIvaPrestacion.ForEach(x => x.IdTipoDetalleIVA = 3);

                                }
                            }
                        }
                    }
                    if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.NoSujeta != null)
                    {
                        if (request.IdAgencia == "ATC")
                        {
                            mapperdRegistro.ImportePorArticulos7_14_Otros = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.NoSujeta.ImportePorArticulos9_Otros?.Trim()?.Replace(".", ",").parseToDecimal();
                        }
                        else
                        {
                            mapperdRegistro.ImportePorArticulos7_14_Otros = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.NoSujeta.ImportePorArticulos7_14_Otros?.Trim()?.Replace(".", ",").parseToDecimal();
                        }
                        mapperdRegistro.ImporteTAIReglasLocalizacion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.PrestacionServicios.NoSujeta.ImporteTAIReglasLocalizacion?.Trim()?.Replace(".", ",").parseToDecimal();
                    }
                    if (mapperdRegistro.ListDetailIva != null)
                    {
                        mapperdRegistro.ListDetailIva.AddRange(vDetalleImportesIvaPrestacion);
                    }
                    else
                    {
                        mapperdRegistro.ListDetailIva = vDetalleImportesIvaPrestacion;
                    }
                }
                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                    .DesgloseTipoOperacion.Entrega != null)
                {
                    List<EDetalleImportesIVA> vDetalleImportesIvaEntrega = new List<EDetalleImportesIVA>();
                    if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta != null)
                    {
                        if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.Exenta != null && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.Exenta.Any())
                        {
                            mapperdRegistro.CausaExencion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.Exenta[0].CausaExencion;
                            mapperdRegistro.BaseImponible = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.Exenta[0].BaseImponible?.Trim()?.Replace(".", ",").parseToDecimal();

                        }
                        if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.NoExenta != null)
                        {
                            mapperdRegistro.TipoNoExenta = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.TipoNoExenta;

                            if (request.IdAgencia != "ATC")
                            {
                                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.DesgloseIVA != null
                                                                && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.DesgloseIVA.Any())
                                {
                                    vDetalleImportesIvaEntrega = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                                        .DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.DesgloseIVA.Select(x => _mapper.Map<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>(x)).ToList();
                                    vDetalleImportesIvaEntrega.ForEach(x => x.IdTipoDetalleIVA = 2);

                                }
                            }
                            else
                            {
                                if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.DesgloseIGIC != null
                                                                && vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.DesgloseIGIC.Any())
                                {
                                    vDetalleImportesIvaEntrega = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose
                                        .DesgloseTipoOperacion.Entrega.Sujeta.NoExenta.DesgloseIGIC.Select(x => _mapper.Map<RespuestaConsultaDetalleIGIC, EDetalleImportesIVA>(x)).ToList();
                                    vDetalleImportesIvaEntrega.ForEach(x => x.IdTipoDetalleIVA = 2);

                                }
                            }
                        }
                    }
                    if (vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.NoSujeta != null)
                    {
                        if (request.IdAgencia == "ATC")
                        {
                            mapperdRegistro.ImportePorArticulos7_14_Otros = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.NoSujeta.ImportePorArticulos9_Otros?.Trim()?.Replace(".", ",").parseToDecimal();
                        }
                        else
                        {
                            mapperdRegistro.ImportePorArticulos7_14_Otros = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.NoSujeta.ImportePorArticulos7_14_Otros?.Trim()?.Replace(".", ",").parseToDecimal();
                        }
                        mapperdRegistro.ImporteTAIReglasLocalizacion = vRegistroConsulta.DatosFacturaEmitida.TipoDesglose.DesgloseTipoOperacion.Entrega.NoSujeta.ImporteTAIReglasLocalizacion?.Trim()?.Replace(".", ",").parseToDecimal();
                    }

                    if (mapperdRegistro.ListDetailIva != null)
                    {
                        mapperdRegistro.ListDetailIva.AddRange(vDetalleImportesIvaEntrega);
                    }
                    else
                    {
                        mapperdRegistro.ListDetailIva = vDetalleImportesIvaEntrega;
                    }
                }
            }

            return mapperdRegistro;
        }

        private ERegistroInformacion MapRegistroRespuestaConsultaLRFacturasRecibidas(ConsultaFacturasRequest request, ERegistroInformacion initialRegistro, RegistroRespuestaConsultaLRFacturasRecibidas vRegistroConsulta)
        {
            var mapperdRegistro = _mapper.Map<RegistroRespuestaConsultaLRFacturasRecibidas, ERegistroInformacion>(vRegistroConsulta);
            mapperdRegistro.NombreRazon = initialRegistro.NombreRazon;
            mapperdRegistro.Ejercicio = initialRegistro.Ejercicio;
            mapperdRegistro.Periodo = initialRegistro.Periodo;
            mapperdRegistro.NifDeclarante = initialRegistro.NifDeclarante;
            if (vRegistroConsulta.DatosFacturaRecibida.FacturasAgrupadas != null && vRegistroConsulta.DatosFacturaRecibida.FacturasAgrupadas.Any())
                mapperdRegistro.ListFacturasAgrupadas = vRegistroConsulta.DatosFacturaRecibida.FacturasAgrupadas.Select(x => _mapper.Map<RespuestaConsultaIDFacturaAgrupada, EFacturasAgrupadas>(x)).ToList();
            if (vRegistroConsulta.DatosFacturaRecibida.FacturasRectificadas != null && vRegistroConsulta.DatosFacturaRecibida.FacturasRectificadas.Any())
                mapperdRegistro.ListFacturasRectificadas = vRegistroConsulta.DatosFacturaRecibida.FacturasRectificadas.Select(x => _mapper.Map<RespuestaConsultaIDFacturaRectificada, EFacturasRectificadas>(x)).ToList();
            if (vRegistroConsulta.DatosDescuadreContraparte != null)
                mapperdRegistro.DatosDescuadreContraparte = _mapper.Map<RespuestaConsultaDatosDescuadreContraparte, EDatosDescuadreContraparte>(vRegistroConsulta.DatosDescuadreContraparte);
            mapperdRegistro.DatosComplementarios = _mapper.Map<RespuestaConsultaDatosFacturaRecibida, EDatosComplementarios>(vRegistroConsulta.DatosFacturaRecibida);

            List<EDetalleImportesIVA> vListDetalleIva;

            if (request.IdAgencia == "ATC")
            {
                mapperdRegistro.RegistroInformacion_IGIC = _mapper.Map<RegistroRespuestaConsultaLRFacturasRecibidas, ERegistroInformacion_IGIC>(vRegistroConsulta);
            }

            if (vRegistroConsulta.DatosFacturaRecibida != null && vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura != null)
            {
                try
                {
                    if (request.IdAgencia != "ATC")
                    {
                        if (vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.DesgloseIVA != null)
                        {
                            vListDetalleIva = vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.DesgloseIVA.Select(x => _mapper.Map<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>(x)).ToList();
                            vListDetalleIva.ForEach(x => x.IdTipoDetalleIVA = 0);
                            mapperdRegistro.ListDetailIva = vListDetalleIva;
                        }
                        if (vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.InversionSujetoPasivo != null)
                        {
                            vListDetalleIva = vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.InversionSujetoPasivo.DetalleIVA.Select(x => _mapper.Map<RespuestaConsultaDetalleIVA, EDetalleImportesIVA>(x)).ToList();
                            if (vListDetalleIva != null && vListDetalleIva.Any())
                            {
                                vListDetalleIva.ForEach(x => x.IdTipoDetalleIVA = 1);
                            }

                            if (mapperdRegistro.ListDetailIva != null)
                            {
                                mapperdRegistro.ListDetailIva.AddRange(vListDetalleIva);
                            }
                            else
                            {
                                mapperdRegistro.ListDetailIva = vListDetalleIva;
                            }
                        }
                    }
                    else
                    {
                        if (vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.DesgloseIGIC != null &&
                            vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.DesgloseIGIC.Any())
                        {

                            vListDetalleIva = vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.DesgloseIGIC.Select(x => _mapper.Map<RespuestaConsultaDetalleIGIC, EDetalleImportesIVA>(x)).ToList();
                            vListDetalleIva.ForEach(x => x.IdTipoDetalleIVA = 0);
                            mapperdRegistro.ListDetailIva = vListDetalleIva;
                        }
                        if (vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.InversionSujetoPasivo != null &&
                            vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.InversionSujetoPasivo.DetalleIGIC.Any())
                        {
                            vListDetalleIva = vRegistroConsulta.DatosFacturaRecibida.DesgloseFactura.InversionSujetoPasivo.DetalleIGIC.Select(x => _mapper.Map<RespuestaConsultaDetalleIGIC, EDetalleImportesIVA>(x)).ToList();
                            if (vListDetalleIva != null && vListDetalleIva.Count > 0)
                            {
                                vListDetalleIva.ForEach(x => x.IdTipoDetalleIVA = 1);
                            }

                            if (mapperdRegistro.ListDetailIva != null)
                            {
                                mapperdRegistro.ListDetailIva.AddRange(vListDetalleIva);
                            }
                            else
                            {
                                mapperdRegistro.ListDetailIva = vListDetalleIva;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }


            }

            return mapperdRegistro;
        }

    }
}
