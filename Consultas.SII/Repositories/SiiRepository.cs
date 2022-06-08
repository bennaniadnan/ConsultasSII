using Consultas.SII.Contracts;
using Consultas.SII.Entities;
using Consultas.SII.Entities.Enumerator;
using Consultas.SII.Helpers;

using Dapper;

using Gesisa.Apps.Common;
using Gesisa.Apps.Common.Enums;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Repositories
{

    public partial class AgencyCommunicationUrlRepository : IAgencyCommunicationUrlRepository
    {
        public async Task<AgencyCommunicationUrl> GetAgencyCommunicationUrlAsync(string agency, string invoiceType)
        {
            using var conn = _connectionFactory.GetPuenteSiiDatabaseConnectionString;

            var data = await conn.QueryFirstOrDefaultAsync<AgencyCommunicationUrl>(
                $"SELECT * FROM {TableName} WHERE Agency = @agency AND DocumentType = @documentType",
                new
                {
                    Agency = agency,
                    documentType = invoiceType
                });

            return data;
        }
    }

    /// <summary>
    /// partial part for <see cref="AgencyCommunicationUrlRepository"/>
    /// </summary>
    public partial class AgencyCommunicationUrlRepository
    {
        private readonly string TableName = "[dbo].[AgencyCommunicationUrls]";

        private readonly ILogger _logger;
        private readonly IConnectionFactory _connectionFactory;

        public AgencyCommunicationUrlRepository(
            IConnectionFactory connectionFactory,
            ILogger<AgencyCommunicationUrlRepository> logger)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
        }
    }
    public class SiiRepository : ISiiRepository
    {
        private readonly ILogger<SiiRepository> _logsManager;
        private readonly IConnectionFactory _connectionFactory;

        public SiiRepository(ILogger<SiiRepository> logsManager,
            IConnectionFactory connectionFactory)
        {
            _logsManager = logsManager;
            _connectionFactory = connectionFactory;
        }
        public ERegistroInformacion GetRegistroInformacionByEjercioNifSerie(
            DateTime FechaExpedicionFacturaEmisor,
            string NifFacturaEmisor,
            string IDFactura,
            string NumSerieFacturaEmisor,
            string idAgencia)
        {
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                ERegistroInformacion eRegistroInformacion = GetRegistroInformacionByEjercioNifSerie(FechaExpedicionFacturaEmisor, NifFacturaEmisor, IDFactura, NumSerieFacturaEmisor, idAgencia, connection);
                return eRegistroInformacion;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }
        public Result<int> InsertUpdateRegistroInformacion(ERegistroInformacion RegistroInfo, string pIdTipoOperacion, string idAgencia)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateRegistroInformacion(RegistroInfo=> id:'{RegistroInfo.Id},estado:'{RegistroInfo.IdEstadoRegistro},fechaPlazo:'{RegistroInfo.FechaFinPlazo}', pIdTipoOperacion:'{pIdTipoOperacion}')");

            Result<int> result;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                ERegistroInformacion eRegistroInformacion = GetRegistroInformacionByEjercioNifSerie(
                    RegistroInfo.FechaExpedicionFacturaEmisor,
                    RegistroInfo.NifFacturaEmisor,
                    RegistroInfo.IDIdFactura,
                    RegistroInfo.NumSerieFacturaEmisor,
                    idAgencia,
                    connection);

                string IDTypeContraparte = GetIdType(idAgencia, connection).Exists(i => i.Id == RegistroInfo.IDTypeContraparte) ?
                    RegistroInfo.IDTypeContraparte : null;
                string IDTypeIdFactura = GetIdType(idAgencia, connection).Exists(t => t.Id == RegistroInfo.IDTypeIdFactura) ?
                    RegistroInfo.IDTypeIdFactura : null;
                string TipoFactura = GetTipoFactura(idAgencia, connection).Exists(i => i.Id == RegistroInfo.TipoFactura) ?
                    RegistroInfo.TipoFactura : null;
                string ClaveRegimenEspecialOTrascendencia = GetClaveRegimenBy(RegistroInfo.IdLibroRegistro, idAgencia, connection)
                    .Exists(c => c.Id == RegistroInfo.ClaveRegimenEspecialOTrascendencia) ?
                    RegistroInfo.ClaveRegimenEspecialOTrascendencia : null;
                string Periodo = GetPeriodosByTipoPresentacion("M", connection).Exists(p => p.Id == RegistroInfo.Periodo) ?
                    RegistroInfo.Periodo : null;
                if (!string.IsNullOrEmpty(pIdTipoOperacion))
                {
                    if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                            && eRegistroInformacion != null
                            && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                        || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                    {
                        if (eRegistroInformacion != null && eRegistroInformacion.Id > 0)
                        {
                            RegistroInfo.Id = eRegistroInformacion.Id;
                            RegistroInfo.IdEstadoLectura = eRegistroInformacion.IdEstadoLectura;
                        }
                    }
                    else
                    {
                        RegistroInfo.IdEstadoLectura = 0;
                    }
                }

                int oReturn = connection.QuerySingleOrDefault<int>(
                       nameof(DatabaseConstants.RIN_INSERT_OR_UPDATE_REGISTRO_INFORMACION),
                       new
                       {
                           Id = RegistroInfo.Id > 0 ? RegistroInfo?.Id : null,
                           RegistroInfo.IdLibroRegistro,
                           RegistroInfo.NifDeclarante,
                           RegistroInfo.NifFacturaEmisor,
                           RegistroInfo.NumSerieFacturaEmisor,
                           RegistroInfo.NumSerieFacturaEmisorResumenFin,
                           RegistroInfo.FechaExpedicionFacturaEmisor,
                           RegistroInfo.NombreRazon,
                           RegistroInfo.NIFRepresentante,
                           RegistroInfo.NifContraparte,
                           RegistroInfo.IDContraparte,
                           RegistroInfo.IDIdFactura,
                           RegistroInfo.BaseRectificada,
                           RegistroInfo.CuotaRectificada,
                           RegistroInfo.CuotaRecargoRectificada,
                           RegistroInfo.TipoRectificativa,
                           RegistroInfo.FechaExpedicionFactura,
                           RegistroInfo.FechaOperacion,
                           RegistroInfo.ImporteTotal,
                           RegistroInfo.DescripcionOperacion,
                           RegistroInfo.SituacionInmueble,
                           RegistroInfo.ReferenciaCatastral,
                           RegistroInfo.CausaExencion,
                           RegistroInfo.BaseImponible,
                           RegistroInfo.BaseImponibleACoste,
                           RegistroInfo.TipoNoExenta,
                           RegistroInfo.TipoNoSujeta,
                           RegistroInfo.ImportePorArticulos7_14_Otros,
                           RegistroInfo.ImporteTAIReglasLocalizacion,
                           RegistroInfo.ImporteTransmisionSujetoAIVA,
                           RegistroInfo.EmitidaPorTerceros,
                           RegistroInfo.NumeroDUA,
                           RegistroInfo.FechaRegContableDUA,
                           RegistroInfo.FechaRegContable,
                           RegistroInfo.CuotaDeducible,
                           RegistroInfo.TipoOperacion,
                           RegistroInfo.ClaveDeclarado,
                           RegistroInfo.EstadoMiembro,
                           RegistroInfo.PlazoOperacion,
                           RegistroInfo.DescripcionBienes,
                           RegistroInfo.DireccionOperador,
                           RegistroInfo.FacturasODocumentacion,
                           RegistroInfo.ProrrataAnualDefinitiva,
                           RegistroInfo.RegularizacionAnualDeduccion,
                           RegistroInfo.IdentificacionEntrega,
                           RegistroInfo.RegularizacionDeduccionEfectuada,
                           RegistroInfo.Ejercicio,
                           RegistroInfo.FechaInicioUtilizacion,
                           RegistroInfo.IdentificacionBien,
                           RegistroInfo.Baja,
                           RegistroInfo.VariosDestinatarios,
                           RegistroInfo.Cupon,
                           RegistroInfo.NombreContraparte,
                           RegistroInfo.IdEstadoRegistro,
                           RegistroInfo.TipoDesglose,
                           RegistroInfo.DesgloseTipoOperacion,
                           RegistroInfo.CodigoPaisContraparte,
                           RegistroInfo.CodigoPaisIdFactura,
                           IDTypeContraparte,
                           IDTypeIdFactura,
                           TipoFactura,
                           ClaveRegimenEspecialOTrascendencia,
                           Periodo,
                           FechaBaja = RegistroInfo.FechaBaja.HasValue ? RegistroInfo.FechaBaja : null,
                           RegistroInfo.IdEstadoLectura,
                           RegistroInfo.FechaFinPlazo,
                           RegistroInfo.ADeducirEnPeriodoPosterior,
                           RegistroInfo.EjercicioDeduccion,
                           RegistroInfo.PeriodoDeduccion
                       },
                       commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                    );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateRegistroInformacion() insertedid => '{oReturn}'");

                int regId = (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                    && eRegistroInformacion != null
                    && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado))
                        ? RegistroInfo.Id : oReturn;

                if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                        && eRegistroInformacion != null
                        && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                    || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                {
                    DeleteDetalleImportesIva(regId, connection);
                }
                if (RegistroInfo.ListDetailIva != null)
                {
                    foreach (EDetalleImportesIVA detailIva in RegistroInfo.ListDetailIva)
                    {
                        detailIva.IdRegistro = regId;
                        InsertUpdateDetalleImportesIVA(detailIva, connection);
                    }
                }

                if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                        && eRegistroInformacion != null
                        && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                    || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                {
                    DeleteFacturasAgrupadas(regId, connection);
                }
                if (RegistroInfo.ListFacturasAgrupadas != null)
                {
                    foreach (EFacturasAgrupadas fAgrupada in RegistroInfo.ListFacturasAgrupadas)
                    {
                        fAgrupada.IdRegistroInformacion = regId;
                        InsesrtUpdateFacturasAgrupadas(fAgrupada, connection);
                    }
                }

                if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                        && eRegistroInformacion != null
                        && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                    || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                {
                    DeleteFacturasRectificadas(regId, connection);
                }
                if (RegistroInfo.ListFacturasRectificadas != null)
                {
                    foreach (EFacturasRectificadas fRectificada in RegistroInfo.ListFacturasRectificadas)
                    {
                        fRectificada.IdRegistroInformacion = regId;
                        InsesrtUpdateFacturasRectificadas(fRectificada, connection);
                    }
                }

                if (RegistroInfo.DatosComplementarios != null)
                {
                    RegistroInfo.DatosComplementarios.IdRegistroInformacion = regId;
                    RegistroInfo.DatosComplementarios.Macrodato = Math.Abs(RegistroInfo.ImporteTotal != null ? ((decimal)RegistroInfo.ImporteTotal) : 0) >= 100000000 ? "S" : "N";
                    if (RegistroInfo.DatosComplementarios.IdRegistroInformacion != 0)
                    {
                        InsertUpdateDatosComplementarios(RegistroInfo.DatosComplementarios, connection);
                    }
                }
                if (RegistroInfo.IdEstadoCuadre == EnumEstadoCuadre.ParcialmenteContrastada)
                {
                    RegistroInfo.Id = oReturn;
                    InsertUpdateDatosDescuadreCotraparte(RegistroInfo.Id, connection);
                }
                if (idAgencia == "ATC" && RegistroInfo.RegistroInformacion_IGIC != null)
                {
                    RegistroInfo.RegistroInformacion_IGIC.IdRegistroInformacion = regId;
                    if (RegistroInfo.RegistroInformacion_IGIC.IdRegistroInformacion != 0)
                    {
                        int returnId = InsertUpdateRegistroInformacion_IGIC(RegistroInfo.RegistroInformacion_IGIC, connection);
                        if (returnId == 0)
                        {

                            _logsManager.LogError("Se ha producido un error al insertar Registro Informacion IGIC de la factura: " + RegistroInfo.NumSerieFacturaEmisor);
                            Console.WriteLine("Se ha producido un error al insertar Registro Informacion IGIC de la factura: " + RegistroInfo.NumSerieFacturaEmisor);

                            result = new Result<int>()
                            {
                                Message = "Se ha producido un error al insertar el registro IGIC",
                                Status = ResultStatus.Failed,
                                Data = RegistroInfo.Id
                            };
                        }
                    }
                }

                if (RegistroInfo.DetalleInmuebles != null && RegistroInfo.IdLibroRegistro == "FE")
                {
                    //delete previous data
                    if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                            && eRegistroInformacion != null
                            && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                        || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                    {
                        DeleteDetalleInmuebleByRegistro(regId, connection);
                    }
                    foreach (var item in RegistroInfo.DetalleInmuebles)
                    {

                        item.IdRegistroInformacion = regId;
                        if (regId != 0)
                        {
                            InsertDetalleInmueble(item, connection);
                        }
                    }
                }

                result = new Result<int>()
                {
                    Message = "Tus cambios se han guardado con éxito.",
                    Status = ResultStatus.Succeed,
                    Data = regId
                };

            }
            catch (Exception ex)
            {

                _logsManager.LogError(ex.Message, ex);
                result = new Result<int>()
                {
                    Message = $"Se ha producido un error al procesar la factura: {RegistroInfo.NumSerieFacturaEmisor}",
                    Status = ResultStatus.Failed,
                    Data = RegistroInfo.Id
                };
            }
            return result;
        }

        public int InsertDetalleInmueble(EDetalleInmueble vDetalleInmueble, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertDetalleInmueble()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.DET_INSERT_DETALLE_INMUEBLE,
                    new
                    {
                        vDetalleInmueble.IdRegistroInformacion,
                        vDetalleInmueble.SituacionInmueble,
                        vDetalleInmueble.ReferenciaCatastral
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertDetalleInmueble() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsertDetalleInmueble(EDetalleInmueble vDetalleInmueble)
        {
            _logsManager.LogDebug($"SiiRepository.InsertDetalleInmueble()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.DET_INSERT_DETALLE_INMUEBLE,
                    new
                    {
                        vDetalleInmueble.IdRegistroInformacion,
                        vDetalleInmueble.SituacionInmueble,
                        vDetalleInmueble.ReferenciaCatastral
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertDetalleInmueble() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsertUpdateDatosComplementarios(EDatosComplementarios vDatosComplementarios, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosComplementarios()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.REG_INSERT_UPDATE_DATOS_COMPLEMENTARIOS,
                    new
                    {
                        vDatosComplementarios.IdRegistroInformacion,
                        ClaveRegimen1 = !string.IsNullOrEmpty(vDatosComplementarios.ClaveRegimen1) ? vDatosComplementarios.ClaveRegimen1 : null,
                        ClaveRegimen2 = !string.IsNullOrEmpty(vDatosComplementarios.ClaveRegimen2) ? vDatosComplementarios.ClaveRegimen2 : null,
                        vDatosComplementarios.Autorizacion,
                        vDatosComplementarios.RefExterna,
                        vDatosComplementarios.NombreSucedida,
                        vDatosComplementarios.NifSucedida,
                        vDatosComplementarios.SimplificadaArt,
                        vDatosComplementarios.RegPrevio,
                        vDatosComplementarios.Macrodato,
                        vDatosComplementarios.FacturaEnergia,
                        vDatosComplementarios.SinDestinatario,
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosComplementarios() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public string InsertUpdateDatosComplementarios(EDatosComplementarios vDatosComplementarios)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosComplementarios()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                connection.Execute(
                    DatabaseConstants.REG_INSERT_UPDATE_DATOS_COMPLEMENTARIOS,
                    new
                    {
                        vDatosComplementarios.IdRegistroInformacion,
                        ClaveRegimen1 = !string.IsNullOrEmpty(vDatosComplementarios.ClaveRegimen1) ? vDatosComplementarios.ClaveRegimen1 : null,
                        ClaveRegimen2 = !string.IsNullOrEmpty(vDatosComplementarios.ClaveRegimen2) ? vDatosComplementarios.ClaveRegimen2 : null,
                        vDatosComplementarios.Autorizacion,
                        vDatosComplementarios.RefExterna,
                        vDatosComplementarios.NombreSucedida,
                        vDatosComplementarios.NifSucedida,
                        vDatosComplementarios.SimplificadaArt,
                        vDatosComplementarios.RegPrevio,
                        vDatosComplementarios.Macrodato,
                        vDatosComplementarios.FacturaEnergia,
                        vDatosComplementarios.SinDestinatario,
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosComplementarios() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted.ToString();
        }

        public int InsertUpdateRegistroInformacion_IGIC(ERegistroInformacion_IGIC vRegistroInformacion_IGIC, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateRegistroInformacion_IGIC()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.REG_INSERT_UPDATE_REGISTROINFORMACION_IGIC,
                    new
                    {
                        IdRegistroInformacion = vRegistroInformacion_IGIC.IdRegistroInformacion > 0 ? vRegistroInformacion_IGIC?.IdRegistroInformacion : null,
                        vRegistroInformacion_IGIC.PagoAnticipado,
                        vRegistroInformacion_IGIC.IdTipoBienOperacion,
                        vRegistroInformacion_IGIC.IdTipoDocumentoArt25,
                        vRegistroInformacion_IGIC.NumeroProtocolo,
                        vRegistroInformacion_IGIC.NombreNotario
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                    );

                inserted = vRegistroInformacion_IGIC.IdRegistroInformacion;
            }
            catch (SqlException ex)
            {
                _logsManager.LogError(ex.Message, ex);

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

            }
            return inserted;
        }

        public int InsertUpdateRegistroInformacion_IGIC(ERegistroInformacion_IGIC vRegistroInformacion_IGIC)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateRegistroInformacion_IGIC()");

            try
            {

                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                connection.Execute(
                    DatabaseConstants.REG_INSERT_UPDATE_REGISTROINFORMACION_IGIC,
                    new
                    {
                        IdRegistroInformacion = vRegistroInformacion_IGIC.IdRegistroInformacion > 0 ? vRegistroInformacion_IGIC?.IdRegistroInformacion : null,
                        vRegistroInformacion_IGIC.PagoAnticipado,
                        vRegistroInformacion_IGIC.IdTipoBienOperacion,
                        vRegistroInformacion_IGIC.IdTipoDocumentoArt25,
                        vRegistroInformacion_IGIC.NumeroProtocolo,
                        vRegistroInformacion_IGIC.NombreNotario
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                    );
                return vRegistroInformacion_IGIC.IdRegistroInformacion;
            }
            catch (SqlException ex)
            {
                _logsManager.LogError(ex.Message, ex);
                return 0;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                return 0;
            }
        }

        public int InsertUpdateDatosDescuadreCotraparte(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosDescuadreCotraparte(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            int inserted;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.DAT_INSERT_UPDATE_DATOS_DESCUADRE_CONTRAPARTE,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosDescuadreCotraparte() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        public int InsertUpdateDatosDescuadreCotraparte(int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosDescuadreCotraparte(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.DAT_INSERT_UPDATE_DATOS_DESCUADRE_CONTRAPARTE,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateDatosDescuadreCotraparte() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }


        public int InsertUpdateDetalleImportesIVA(EDetalleImportesIVA vDetalleImportesIVA, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateDetalleImportesIVA()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                       DatabaseConstants.DII_INSERT_OR_UPDATE_DETALLE_IMPORTES_IVA,
                       new
                       {
                           vDetalleImportesIVA.IdRegistro,
                           vDetalleImportesIVA.TipoImpositivo,
                           vDetalleImportesIVA.BaseImponible,
                           vDetalleImportesIVA.CuotaRepercutida,
                           vDetalleImportesIVA.CuotaSoportada,
                           vDetalleImportesIVA.TipoRecargoEquivalencia,
                           vDetalleImportesIVA.CuotaRecargoEquivalencia,
                           vDetalleImportesIVA.ImporteCompensacionREAGYP,
                           vDetalleImportesIVA.PorcentCompensacionREAGYP,
                           vDetalleImportesIVA.IdTipoDetalleIVA,
                           vDetalleImportesIVA.CargaImpositivaImplicita,
                           vDetalleImportesIVA.CuotaRecargoMinorista,
                           vDetalleImportesIVA.BienInversion
                       },
                       commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                       );
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsertUpdateDetalleImportesIVA(EDetalleImportesIVA vDetalleImportesIVA)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateDetalleImportesIVA()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                       nameof(DatabaseConstants.DII_INSERT_OR_UPDATE_DETALLE_IMPORTES_IVA),
                       new
                       {
                           vDetalleImportesIVA.IdRegistro,
                           vDetalleImportesIVA.TipoImpositivo,
                           vDetalleImportesIVA.BaseImponible,
                           vDetalleImportesIVA.CuotaRepercutida,
                           vDetalleImportesIVA.CuotaSoportada,
                           vDetalleImportesIVA.TipoRecargoEquivalencia,
                           vDetalleImportesIVA.CuotaRecargoEquivalencia,
                           vDetalleImportesIVA.ImporteCompensacionREAGYP,
                           vDetalleImportesIVA.PorcentCompensacionREAGYP,
                           vDetalleImportesIVA.IdTipoDetalleIVA,
                           vDetalleImportesIVA.CargaImpositivaImplicita,
                           vDetalleImportesIVA.CuotaRecargoMinorista,
                           vDetalleImportesIVA.BienInversion
                       },
                       commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                       );
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsesrtUpdateFacturasAgrupadas(EFacturasAgrupadas vFacturasAgrupadas)
        {
            _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasAgrupadas()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.FAG_INSERT_OR_UPDATE_FACTURAS_AGRUPADAS,
                    new
                    {
                        vFacturasAgrupadas.IdRegistroInformacion,
                        vFacturasAgrupadas.NumSerieFacturaEmisor,
                        vFacturasAgrupadas.FechaExpedicionFacturaEmisor
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasAgrupadas() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        public int InsesrtUpdateFacturasRectificadas(EFacturasRectificadas vFacturasRectificadas)
        {
            _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasRectificadas()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.FRC_INSERT_OR_UPDATE_FACTURAS_RECTIFICADAS,
                    new
                    {
                        vFacturasRectificadas.IdRegistroInformacion,
                        vFacturasRectificadas.NumSerieFacturaEmisor,
                        vFacturasRectificadas.FechaExpedicionFacturaEmisor
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasRectificadas() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        private int InsesrtUpdateFacturasAgrupadas(EFacturasAgrupadas vFacturasAgrupadas, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasAgrupadas()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.FAG_INSERT_OR_UPDATE_FACTURAS_AGRUPADAS,
                    new
                    {
                        vFacturasAgrupadas.IdRegistroInformacion,
                        vFacturasAgrupadas.NumSerieFacturaEmisor,
                        vFacturasAgrupadas.FechaExpedicionFacturaEmisor
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasAgrupadas() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        private int InsesrtUpdateFacturasRectificadas(EFacturasRectificadas vFacturasRectificadas, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasRectificadas()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.FRC_INSERT_OR_UPDATE_FACTURAS_RECTIFICADAS,
                    new
                    {
                        vFacturasRectificadas.IdRegistroInformacion,
                        vFacturasRectificadas.NumSerieFacturaEmisor,
                        vFacturasRectificadas.FechaExpedicionFacturaEmisor
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsesrtUpdateFacturasRectificadas() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        private int InsertUpdateCobros(ECobro vCobro, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateCobros()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.CBR_INSERT_OR_UPDATE_COBROS,
                    new
                    {
                        Id = vCobro.Id > 0 ? vCobro?.Id : null,
                        vCobro.IdRegistroInformacion,
                        vCobro.Fecha,
                        vCobro.Importe,
                        vCobro.IdMedio,
                        vCobro.Cuenta_O_Medio,
                        vCobro.Nuevo,
                        IdEstadoCobroPago = vCobro.IdEstadoCobroPago.HasValue ? vCobro.IdEstadoCobroPago : 0
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateCobros() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsertUpdateCobros(ECobro vCobro)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateCobros()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.CBR_INSERT_OR_UPDATE_COBROS,
                    new
                    {
                        Id = vCobro.Id > 0 ? vCobro?.Id : null,
                        vCobro.IdRegistroInformacion,
                        vCobro.Fecha,
                        vCobro.Importe,
                        vCobro.IdMedio,
                        vCobro.Cuenta_O_Medio,
                        vCobro.Nuevo,
                        IdEstadoCobroPago = vCobro.IdEstadoCobroPago.HasValue ? vCobro.IdEstadoCobroPago : 0
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdateCobros() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsertUpdatePagos(EPago vPago)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdatePagos()");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.PGO_INSERT_OR_UPDATE_PAGOS,
                    new
                    {
                        Id = vPago.Id > 0 ? vPago?.Id : null,
                        vPago.IdRegistroInformacion,
                        vPago.Fecha,
                        vPago.Importe,
                        vPago.IdMedio,
                        vPago.Cuenta_O_Medio,
                        vPago.Nuevo,
                        IdEstadoCobroPago = vPago.IdEstadoCobroPago.HasValue ? vPago.IdEstadoCobroPago : 0
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdatePagos() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        public int InsertUpdatePagos(EPago vPago, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdatePagos()");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.PGO_INSERT_OR_UPDATE_PAGOS,
                    new
                    {
                        Id = vPago.Id > 0 ? vPago?.Id : null,
                        vPago.IdRegistroInformacion,
                        vPago.Fecha,
                        vPago.Importe,
                        vPago.IdMedio,
                        vPago.Cuenta_O_Medio,
                        vPago.Nuevo,
                        IdEstadoCobroPago = vPago.IdEstadoCobroPago.HasValue ? vPago.IdEstadoCobroPago : 0
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.InsertUpdatePagos() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
            return inserted;
        }

        #region "DELETE"

        public int DeleteDetalleImportesIva(int idRegistro, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteDetalleImportesIva(idRegistro: '{idRegistro}')");

            int inserted;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.DII_DELETE_DETALLE_IMPORTESIVA_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = idRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteDetalleImportesIva() inserted: '{inserted}'.");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        public int DeleteFacturasRectificadas(int idRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteDetalleImportesIva(idRegistroInformacion: '{idRegistroInformacion}')");

            int inserted;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.FRC_DELETE_FACTURA_RECTIFICADA_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = idRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteDetalleImportesIva() inserted: '{inserted}')");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        public int DeleteFacturasAgrupadas(int idRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteFacturasAgrupadas(idRegistroInformacion: '{idRegistroInformacion}')");

            int inserted;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.FAG_DELETE_FACTURA_AGRUPADA_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = idRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteFacturasAgrupadas() inserted: '{inserted}'.");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeleteDetalleImportesIva(int idRegistro)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteDetalleImportesIva(idRegistro: '{idRegistro}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.DII_DELETE_DETALLE_IMPORTESIVA_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = idRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteDetalleImportesIva() inserted: '{inserted}'.");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        public int DeleteFacturasRectificadas(int idRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteFacturasRectificadas(idRegistroInformacion: '{idRegistroInformacion}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.FRC_DELETE_FACTURA_RECTIFICADA_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = idRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteFacturasRectificadas() inserted: '{inserted}')");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                throw;
            }
            return inserted;
        }

        public int DeleteFacturasAgrupadas(int idRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteFacturasAgrupadas(idRegistroInformacion: '{idRegistroInformacion}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.FAG_DELETE_FACTURA_AGRUPADA_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = idRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteFacturasAgrupadas() inserted: '{inserted}')");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int HideRegistroInformacion(string NifFacturaEmisor, string IdFactura, string NumSerieFacturaEmisor, DateTime? FechaExpedicionFacturaEmisor)
        {
            _logsManager.LogDebug($"SiiRepository.HideRegistroInformacion(NifFacturaEmisor: '{NifFacturaEmisor}', IdFactura: '{IdFactura}', NumSerieFacturaEmisor: '{NumSerieFacturaEmisor}', FechaExpedicionFacturaEmisor: '{FechaExpedicionFacturaEmisor}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                int vIdRegistro = connection.QuerySingleOrDefault<int>(
                    DatabaseConstants.RIN_BAJA_REGISTROINFORMACION_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA,
                    new
                    {
                        NifFacturaEmisor = !string.IsNullOrEmpty(NifFacturaEmisor) ? NifFacturaEmisor : null,
                        IdFactura = !string.IsNullOrEmpty(IdFactura) ? IdFactura : null,
                        NumSerieFacturaEmisor = NumSerieFacturaEmisor.Trim(),
                        FechaExpedicionFacturaEmisor = FechaExpedicionFacturaEmisor?.Date,
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );

                inserted = vIdRegistro;
                _logsManager.LogDebug($"SiiRepository.HideRegistroInformacion() inserted => '{inserted}'.");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }
        public int BajaRegistroInformacionById(int pIdOperacion, int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.HideRegistroInformacion(pIdOperacion => '{pIdOperacion}', pIdRegistroInformacion:'{pIdRegistroInformacion}')");

            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                int vIdRegistro = connection.QuerySingleOrDefault<int>(
                    DatabaseConstants.RIN_BAJA_REGISTROINFORMACION_BY_ID,
                    new
                    {
                        IdOperacion = pIdOperacion,
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.HideRegistroInformacion() inserted: '{vIdRegistro}'");
                return vIdRegistro;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public int DeleteCobrosEmitidas(int pIdRegistro)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteCobrosEmitidas(pIdRegistro => '{pIdRegistro}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.COB_DELETE_COBROS_EMITIDAS_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = pIdRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteCobrosEmitidas() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeletePagosRecibidas(int pIdRegistro)
        {
            _logsManager.LogDebug($"SiiRepository.DeletePagosRecibidas(pIdRegistro => '{pIdRegistro}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.PAG_DELETE_PAGOS_RECIBIDAS_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = pIdRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeletePagosRecibidas() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeleteCobrosEmitidas(int pIdRegistro, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteCobrosEmitidas(pIdRegistro => '{pIdRegistro}')");

            int inserted = 0;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.COB_DELETE_COBROS_EMITIDAS_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = pIdRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteCobrosEmitidas(inserted => '{inserted}')");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeletePagosRecibidas(int pIdRegistro, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteCobrosEmitidas(pIdRegistro => '{pIdRegistro}')");

            int inserted;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.PAG_DELETE_PAGOS_RECIBIDAS_BY_IDREGISTROINFORMACION,
                    new
                    {
                        IdRegistroInformacion = pIdRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteCobrosEmitidas() inserted: '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeleteCobroById(int pId)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteCobroById(pId => '{pId}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.COB_DELETE_COBRO_BY_ID,
                    new
                    {
                        Id = pId
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteCobroById() inserted => '{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeletePagoById(int pId)
        {
            _logsManager.LogDebug($"SiiRepository.DeletePagoById(pId => '{pId}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.PAG_DELETE_PAGO_BY_ID,
                    new
                    {
                        Id = pId
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeletePagoById() inserted:'{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeleteDetalleInmuebleByRegistro(int pIdRegistro)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteDetalleInmuebleByRegistro(pIdRegistro:'{pIdRegistro}')");

            int inserted = 0;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                inserted = connection.Execute(
                    DatabaseConstants.DET_DELETE_DETALLE_INMUEBLE_BY_IDREGISTRO,
                    new
                    {
                        IdRegistroInformacion = pIdRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteDetalleInmuebleByRegistro() inserted:'{inserted}'");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        public int DeleteDetalleInmuebleByRegistro(int pIdRegistro, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.DeleteDetalleInmuebleByRegistro(pIdRegistro:'{pIdRegistro}')");

            int inserted;
            try
            {
                inserted = connection.Execute(
                    DatabaseConstants.DET_DELETE_DETALLE_INMUEBLE_BY_IDREGISTRO,
                    new
                    {
                        IdRegistroInformacion = pIdRegistro
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout
                );
                _logsManager.LogDebug($"SiiRepository.DeleteDetalleInmuebleByRegistro() inserted:'{inserted}')");

            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return inserted;
        }

        #endregion
        private ERegistroInformacion GetRegistroInformacionByEjercioNifSerie(
            DateTime FechaExpedicionFacturaEmisor,
            string NifFacturaEmisor,
            string IDFactura,
            string NumSerieFacturaEmisor,
            string idAgencia,
            IDbConnection connection)
        {
            try
            {
                _logsManager.LogDebug($"SiiRepository.GetRegistroInformacionByEjercioNifSerie(@NifFacturaEmisor='{NifFacturaEmisor}', @IDFactura='{IDFactura}', @NumSerieFacturaEmisor: '{NumSerieFacturaEmisor}', idAgencia: '{idAgencia}')");
                ERegistroInformacion eRegistroInformacion = connection.Query<ERegistroInformacion, EDatosComplementarios, ERegistroInformacion_IGIC, ERegistroInformacion>(
                    DatabaseConstants.RIN_GET_ID_REGISTRO_INFORMATIO_BY_NIFFACTURAEMISOR_NUMSERIEFACTURAEMISOR_FECHA,
                    (ri, dc, igic) =>
                    {
                        ri.DatosComplementarios = dc;
                        if (idAgencia == "ATC")
                        {
                            ri.RegistroInformacion_IGIC = igic;
                        }
                        return ri;
                    },
                    new
                    {
                        NumSerieFacturaEmisor,
                        FechaExpedicionFacturaEmisor = FechaExpedicionFacturaEmisor.Date,
                        NifFacturaEmisor = !string.IsNullOrEmpty(NifFacturaEmisor) ? NifFacturaEmisor : null,
                        IDFactura = !string.IsNullOrEmpty(IDFactura) ? IDFactura : null,
                    },
                    splitOn: "ClaveRegimen1,PagoAnticipado",
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout)?.FirstOrDefault();

                _logsManager.LogDebug($"SiiRepository.GetRegistroInformacionByEjercioNifSerie(): Id Registro Selected => {eRegistroInformacion?.Id}, IdEstadoRegistro: '{eRegistroInformacion?.IdEstadoRegistro}', IdEstadoLectura: '{eRegistroInformacion?.IdEstadoLectura}', FechaOperacion: {eRegistroInformacion?.FechaOperacion}, {eRegistroInformacion?.FechaFinPlazo}, FechaExpedicionFacturaEmisor: {eRegistroInformacion?.FechaExpedicionFacturaEmisor}, NifFacturaEmisor: {eRegistroInformacion?.NifFacturaEmisor}, IDIdFactura: {eRegistroInformacion?.IDIdFactura}");

                if (eRegistroInformacion != null && eRegistroInformacion.Id > 0)
                {
                    eRegistroInformacion.ListDetailIva = GetDetalleImportesIva(eRegistroInformacion.Id, connection);
                    eRegistroInformacion.ListCobros = GetCobrosEmitidas(eRegistroInformacion.Id, connection);
                    eRegistroInformacion.ListPagos = GetPagosRecibidas(eRegistroInformacion.Id, connection);
                    eRegistroInformacion.ListFacturasAgrupadas = GetFacturasAgrupadas(eRegistroInformacion.Id, connection);
                    eRegistroInformacion.ListFacturasRectificadas = GetFacturasRectificadas(eRegistroInformacion.Id, connection);
                    eRegistroInformacion.DetalleInmuebles = GetDetalleInmuebleByRegistro(eRegistroInformacion.Id, connection);
                    if (eRegistroInformacion.IdEstadoCuadre != null && eRegistroInformacion.IdEstadoCuadre == EnumEstadoCuadre.ParcialmenteContrastada)
                    {
                        eRegistroInformacion.DatosDescuadreContraparte = GetDatosDescuadreContraparte(eRegistroInformacion.Id, connection);
                    }
                }
                return eRegistroInformacion;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }
        public EDatosDescuadreContraparte GetDatosDescuadreContraparte(int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetDatosDescuadreContraparte(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            EDatosDescuadreContraparte descuadreContraparte = new EDatosDescuadreContraparte() { IdRegistroInformacion = pIdRegistroInformacion };
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                descuadreContraparte = connection.QuerySingleOrDefault<EDatosDescuadreContraparte>(DatabaseConstants.DAT_GET_DATOS_DESCUADRE_BY_IDREGISTRO,
                    new
                    {
                        descuadreContraparte.IdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout);
                return descuadreContraparte;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }
        public EDatosDescuadreContraparte GetDatosDescuadreContraparte(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetDatosDescuadreContraparte(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            EDatosDescuadreContraparte descuadreContraparte = new EDatosDescuadreContraparte() { IdRegistroInformacion = pIdRegistroInformacion };
            try
            {
                descuadreContraparte = connection.QuerySingleOrDefault<EDatosDescuadreContraparte>(DatabaseConstants.DAT_GET_DATOS_DESCUADRE_BY_IDREGISTRO,
                    new
                    {
                        descuadreContraparte.IdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout);
                return descuadreContraparte;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EDetalleInmueble> GetDetalleInmuebleByRegistro(int IdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetDetalleInmuebleByRegistro()");

            List<EDetalleInmueble> detalleInmueble = new List<EDetalleInmueble>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                detalleInmueble = connection.Query<EDetalleInmueble>(DatabaseConstants.DET_GET_DETALLE_INMUEBLE,
                        new
                        {
                            IdRegistroInformacion
                        },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return detalleInmueble;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<EDetalleInmueble> GetDetalleInmuebleByRegistro(int IdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetDetalleInmuebleByRegistro()");

            List<EDetalleInmueble> detalleInmueble = new List<EDetalleInmueble>();
            try
            {
                detalleInmueble = connection.Query<EDetalleInmueble>(DatabaseConstants.DET_GET_DETALLE_INMUEBLE,
                        new
                        {
                            IdRegistroInformacion
                        },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return detalleInmueble;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ECausaExencion> GetCausaExencion(string IdAgencia)
        {
            _logsManager.LogDebug($"SiiRepository.GetCausaExencion()");

            List<ECausaExencion> causaExencions = new List<ECausaExencion>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                causaExencions = connection.Query<ECausaExencion>(DatabaseConstants.CAU_GET_CAUSAEXENCION,
                        new
                        {
                            IdAgencia = IdAgencia == "ATC" ? IdAgencia : "AEAT"
                        },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return causaExencions;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<ETipoBienOperacion> GetTipoBienOperacion()
        {
            _logsManager.LogDebug($"SiiRepository.GetTipoBienOperacion()");

            List<ETipoBienOperacion> tipoBienOperacion = new List<ETipoBienOperacion>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                tipoBienOperacion = connection.Query<ETipoBienOperacion>(DatabaseConstants.TIP_GET_TIPOBIENOPERACION,
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return tipoBienOperacion;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<ETipoDocumentoArt25> GetTipoDocumentoArt25()
        {
            _logsManager.LogDebug($"SiiRepository.GetTipoDocumentoArt25()");

            List<ETipoDocumentoArt25> tipoDocumentoArt25 = new List<ETipoDocumentoArt25>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                tipoDocumentoArt25 = connection.Query<ETipoDocumentoArt25>(DatabaseConstants.TIP_GET_TIPODOCUMENTO_ART25,
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return tipoDocumentoArt25;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public ERegistroInformacion_IGIC GetRegistroInformacion_IGIC_ById(int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetRegistroInformacion_IGIC_ById()");

            ERegistroInformacion_IGIC eRegistro;
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                eRegistro = connection.QuerySingleOrDefault<ERegistroInformacion_IGIC>(DatabaseConstants.REG_GET_REGISTROINFORMACION_IGIC_BYID,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout);
                return eRegistro;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        private List<EPaisResidencia> GetIdType(string IdAgencia, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetIdType()");

            List<EPaisResidencia> idTypeList = new List<EPaisResidencia>();
            try
            {
                idTypeList = connection.Query<EPaisResidencia>(DatabaseConstants.IDT_GET_IDTYPE,
                    new
                    {
                        IdAgencia
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                _logsManager.LogDebug($"SiiRepository.GetIdType() {idTypeList?.Count} {nameof(EPaisResidencia)}.");

                return idTypeList;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EPaisResidencia> GetIdType(string IdAgencia)
        {
            _logsManager.LogDebug($"SiiRepository.GetIdType(IdAgencia:'{IdAgencia}')");

            List<EPaisResidencia> idTypeList = new List<EPaisResidencia>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                idTypeList = connection.Query<EPaisResidencia>(DatabaseConstants.IDT_GET_IDTYPE,
                    new
                    {
                        IdAgencia
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return idTypeList;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<ETipoFactura> GetTipoFactura(string IdAgencia, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetTipoFactura()");

            List<ETipoFactura> tipoFacturaList = new List<ETipoFactura>();
            try
            {
                tipoFacturaList = connection.Query<ETipoFactura>(DatabaseConstants.TIP_GET_TIPOFACTURA,
                    new
                    {
                        IdAgencia
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return tipoFacturaList;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<ETipoFactura> GetTipoFactura(string IdAgencia)
        {
            _logsManager.LogDebug($"SiiRepository.GetTipoFactura()");

            List<ETipoFactura> tipoFacturaList = new List<ETipoFactura>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                tipoFacturaList = connection.Query<ETipoFactura>(DatabaseConstants.TIP_GET_TIPOFACTURA,
                    new
                    {
                        IdAgencia
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return tipoFacturaList;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EClaveRegimen> GetClaveRegimenBy(string pIdLibroRegistro, string IdAgencia, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetClaveRegimenBy()");

            List<EClaveRegimen> claveRegimenList = new List<EClaveRegimen>();
            try
            {
                claveRegimenList = connection.Query<EClaveRegimen>(DatabaseConstants.CLA_GET_CLAVEREGIMEN_BY_IDLIBROREGISTRO,
                    new
                    {
                        IdLibroRegistro = pIdLibroRegistro,
                        IdAgencia = IdAgencia == "ATC" ? IdAgencia : "AEAT"
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return claveRegimenList;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EClaveRegimen> GetClaveRegimenBy(string pIdLibroRegistro, string IdAgencia)
        {
            _logsManager.LogDebug($"SiiRepository.GetClaveRegimenBy()");

            List<EClaveRegimen> claveRegimenList = new List<EClaveRegimen>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                claveRegimenList = connection.Query<EClaveRegimen>(DatabaseConstants.CLA_GET_CLAVEREGIMEN_BY_IDLIBROREGISTRO,
                    new
                    {
                        IdLibroRegistro = pIdLibroRegistro,
                        IdAgencia = IdAgencia == "ATC" ? IdAgencia : "AEAT"
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return claveRegimenList;

        }

        public List<EPeriodo> GetPeriodosByTipoPresentacion(string pTipoPresentacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetPeriodosByTipoPresentacion()");

            List<EPeriodo> periodosList = new List<EPeriodo>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                periodosList = connection.Query<EPeriodo>(DatabaseConstants.PER_GET_PERIODOS_BY_TIPOPRESENTACION,
                    new
                    {
                        TipoPresentacion = pTipoPresentacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return periodosList;

        }

        public List<EPeriodo> GetPeriodosByTipoPresentacion(string pTipoPresentacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetPeriodosByTipoPresentacion()");

            List<EPeriodo> periodosList = new List<EPeriodo>();
            try
            {
                periodosList = connection.Query<EPeriodo>(DatabaseConstants.PER_GET_PERIODOS_BY_TIPOPRESENTACION,
                    new
                    {
                        TipoPresentacion = pTipoPresentacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
            return periodosList;
        }


        public List<EDetalleImportesIVA> GetDetalleImportesIva(int pIdRegistroInformacion)
        {

            List<EDetalleImportesIVA> oResultat = new List<EDetalleImportesIVA>();
            try
            {
                _logsManager.LogDebug($"SiiRepository.GetDetalleImportesIva()");

                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                oResultat = connection.Query<EDetalleImportesIVA>(DatabaseConstants.DET_GET_DETALLE_IMPORTES_IVA,
                    new
                    {
                        IdRegistro = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }
        public List<ECobro> GetCobrosEmitidas(int pIdRegistroInformacion)
        {

            List<ECobro> oResultat = new List<ECobro>();
            try
            {
                _logsManager.LogDebug($"SiiRepository.GetCobrosEmitidas()");

                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                oResultat = connection.Query<ECobro>(DatabaseConstants.COB_GET_COBROS_EMITIDAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }
        public List<EPago> GetPagosRecibidas(int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetPagosRecibidas()");
            List<EPago> oResultat = new List<EPago>();
            try
            {

                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                oResultat = connection.Query<EPago>(DatabaseConstants.PAG_GET_PAGOS_RECIBIDAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EFacturasAgrupadas> GetFacturasAgrupadas(int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetFacturasAgrupadas()");

            List<EFacturasAgrupadas> oResultat = new List<EFacturasAgrupadas>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                oResultat = connection.Query<EFacturasAgrupadas>(DatabaseConstants.FAG_GET_FACTURAS_AGRUPADAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EFacturasRectificadas> GetFacturasRectificadas(int pIdRegistroInformacion)
        {
            _logsManager.LogDebug($"SiiRepository.GetFacturasRectificadas(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            List<EFacturasRectificadas> oResultat = new List<EFacturasRectificadas>();
            try
            {
                using IDbConnection connection = _connectionFactory.GetPuenteSiiDatabaseConnectionString;
                oResultat = connection.Query<EFacturasRectificadas>(DatabaseConstants.FRC_GET_FACTURAS_RECTIFICADAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EDetalleImportesIVA> GetDetalleImportesIva(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetDetalleImportesIva(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            List<EDetalleImportesIVA> oResultat = new List<EDetalleImportesIVA>();
            try
            {
                oResultat = connection.Query<EDetalleImportesIVA>(DatabaseConstants.DET_GET_DETALLE_IMPORTES_IVA,
                    new
                    {
                        IdRegistro = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<ECobro> GetCobrosEmitidas(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetCobrosEmitidas(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            List<ECobro> oResultat = new List<ECobro>();
            try
            {
                oResultat = connection.Query<ECobro>(DatabaseConstants.COB_GET_COBROS_EMITIDAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EPago> GetPagosRecibidas(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetPagosRecibidas(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            List<EPago> oResultat = new List<EPago>();
            try
            {
                oResultat = connection.Query<EPago>(DatabaseConstants.PAG_GET_PAGOS_RECIBIDAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EFacturasAgrupadas> GetFacturasAgrupadas(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetFacturasAgrupadas(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            List<EFacturasAgrupadas> oResultat = new List<EFacturasAgrupadas>();
            try
            {
                oResultat = connection.Query<EFacturasAgrupadas>(DatabaseConstants.FAG_GET_FACTURAS_AGRUPADAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

        public List<EFacturasRectificadas> GetFacturasRectificadas(int pIdRegistroInformacion, IDbConnection connection)
        {
            _logsManager.LogDebug($"SiiRepository.GetFacturasRectificadas(pIdRegistroInformacion: '{pIdRegistroInformacion}')");

            List<EFacturasRectificadas> oResultat = new List<EFacturasRectificadas>();
            try
            {
                oResultat = connection.Query<EFacturasRectificadas>(DatabaseConstants.FRC_GET_FACTURAS_RECTIFICADAS,
                    new
                    {
                        IdRegistroInformacion = pIdRegistroInformacion
                    },
                    commandType: CommandType.StoredProcedure, commandTimeout: _connectionFactory.CommandTimeout).ToList();
                return oResultat;
            }
            catch (Exception ex)
            {
                _logsManager.LogError(ex.Message, ex);

                throw;
            }
        }

    }
}
