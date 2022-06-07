using Consultas.SII.Contracts;
using Consultas.SII.Entities;
using Consultas.SII.Entities.Request;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IAgenciaTributariaService _agenciaTributariaService;

        public ConsultationService(IAgenciaTributariaService agenciaTributariaService)
        {
            _agenciaTributariaService = agenciaTributariaService;
        }
        public async Task<ICollection<ERegistroInformacion>> ConsultaLRAsync(ConsultaFacturasRequest request, ConsultaClavePaginacion clavePaginacion = null)
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
                    if (string.IsNullOrEmpty(result.ResponseXmlFilePath) || !File.Exists(result.ResponseXmlFilePath))
                    {
                        // Log and return

                        throw new FileNotFoundException("Could not get the response file from agency", result.ResponseXmlFilePath);
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


                    XmlFiles.NewResponseNamespaceSerializer(xmlResponseFile, dataUser.IdAgencia);
                    RespuestaConsultaEnvelope xmlResponse = XmlFiles.DeserializeXMLFileToObject<RespuestaConsultaEnvelope>(xmlResponseFile);
                    clavePaginacion = GetClavePaginacion(xmlResponse, request);
                    var resultRespuesta = MapResponse(xmlResponse, dataUser);
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
                    _siiRepository.InsertUpdateRegistroInformacion(registro, "A0", dataUser);
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
            List<ERegistroInformacion> MapResponse(RespuestaConsultaEnvelope xmlResponse, DataUser dataUser)
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
                            var mapperdRegistro = MapRegistroRespuestaConsultaLRFacturasEmitidas(dataUser, initialRegistro, vRegistroConsulta);
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
                            var mapperdRegistro = MapRegistroRespuestaConsultaLRFacturasRecibidas(dataUser, initialRegistro, vRegistroConsulta);
                            eRegistros.Add(mapperdRegistro);
                        }
                    }
                }

                return eRegistros;
            }
            ConsultaLRFacturasEmitidas GetConsultaLRFacturasEmitidas(ConsultaFacturasRequest request, DataUser dataUser, ConsultaClavePaginacion clavePaginacion)
            {
                ConsultaLRFacturasEmitidas consultaLR;
                var companyUsers = _puenteSiiAuthenticationRepository.GetCompanyUsersByFilter(new UsersFilter
                {
                    GesisaIdentifier = dataUser.IdUsuario
                });
                if (companyUsers != null && companyUsers.Any())
                {
                    var company = companyUsers.FirstOrDefault().Company;
                    if (company != null)
                    {
                        consultaLR = new ConsultaLRFacturasEmitidas()
                        {
                            Cabecera = GetConsultaCabecera(company, dataUser.IdAgencia),
                            FiltroConsulta = GetConsultaFiltroConsulta(request, dataUser.IdAgencia, clavePaginacion)
                        };
                        return consultaLR;
                    }
                    throw new ArgumentException($"company not found for this gesisa identifier '{dataUser.IdUsuario}'", nameof(dataUser.IdUsuario));
                }
                throw new ArgumentException($"user not found for this gesisa identifier '{dataUser.IdUsuario}'", nameof(dataUser.IdUsuario));
            }
            ConsultaLRFacturasRecibidas GetConsultaLRFacturasRecibidas(ConsultaFacturasRequest request, DataUser dataUser, ConsultaClavePaginacion clavePaginacion)
            {
                ConsultaLRFacturasRecibidas consultaLR;
                var companyUsers = _puenteSiiAuthenticationRepository.GetCompanyUsersByFilter(new UsersFilter
                {
                    GesisaIdentifier = dataUser.IdUsuario
                });
                if (companyUsers != null && companyUsers.Any())
                {
                    var company = companyUsers.FirstOrDefault().Company;
                    if (company != null)
                    {
                        consultaLR = new ConsultaLRFacturasRecibidas()
                        {
                            Cabecera = GetConsultaCabecera(company, dataUser.IdAgencia),
                            FiltroConsulta = GetConsultaFiltroConsulta(request, dataUser.IdAgencia, clavePaginacion)
                        };
                        return consultaLR;
                    }
                    throw new ArgumentException($"company not found for this gesisa identifier '{dataUser.IdUsuario}'", nameof(dataUser.IdUsuario));
                }
                throw new ArgumentException($"user not found for this gesisa identifier '{dataUser.IdUsuario}'", nameof(dataUser.IdUsuario));
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
            ConsultaCabecera GetConsultaCabecera(Company company, string idAgencia)
            {
                return new ConsultaCabecera()
                {
                    IDVersionSii = idAgencia == "ATC" ? 1.0m : 1.1m,
                    Titular = new ConsultaTitular()
                    {
                        NIF = company.NIF,
                        NombreRazon = company.Denomination
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
            string CreateRequestFile(ConsultaFacturasRequest request, DataUser dataUser, ConsultaClavePaginacion clavePaginacion)
            {
                string xmlRequestFile;
                if (request.IdLibroRegistro.Equals(EnumLibroRegistro.FE.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    var consultaFE = GetConsultaLRFacturasEmitidas(request, dataUser, clavePaginacion);
                    xmlRequestFile = XmlFiles.CreateXmlFileFromModel(consultaFE, dataUser.IdUsuario, ".xml");
                    XmlFiles.NewNamespaceSerializer(xmlRequestFile, dataUser.IdAgencia);
                }
                else if (request.IdLibroRegistro.Equals(EnumLibroRegistro.FR.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    var consultaFR = GetConsultaLRFacturasRecibidas(request, dataUser, clavePaginacion);
                    xmlRequestFile = XmlFiles.CreateXmlFileFromModel(consultaFR, dataUser.IdUsuario, ".xml");
                    XmlFiles.NewNamespaceSerializer(xmlRequestFile, dataUser.IdAgencia);
                }
                else
                {
                    throw new NotImplementedException($"Consultation not implemented for this document type '{request.IdLibroRegistro}'");
                }

                return xmlRequestFile;
            }

        }
    }
}
