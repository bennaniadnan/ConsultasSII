using Consultas.SII.Contracts;
using Consultas.SII.Entities;

using Gesisa.Apps.Common;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Repositories
{
    public class SiiRepository : ISiiRepository
    {
        private readonly ILogger<SiiRepository> _logsManager;

        public SiiRepository(ILogger<SiiRepository> logsManager)
        {
            _logsManager = logsManager;
        }
        public Result<int> InsertUpdateRegistroInformacion(ERegistroInformacion RegistroInfo, string pIdTipoOperacion, DataUser dataUser)
        {
            _logsManager.LogDebug($"SiiRepository.InsertUpdateRegistroInformacion(RegistroInfo=> id:'{RegistroInfo.Id},estado:'{RegistroInfo.IdEstadoRegistro},fechaPlazo:'{RegistroInfo.FechaFinPlazo}', pIdTipoOperacion:'{pIdTipoOperacion}')", UserId: dataUser.IdUsuario);

            Result<int> result;
            try
            {
                using IDbConnection connection = _connectionFactory.GetConnectionByUser(dataUser);
                ERegistroInformacion eRegistroInformacion = GetRegistroInformacionByEjercioNifSerie(
                    RegistroInfo.FechaExpedicionFacturaEmisor,
                    RegistroInfo.NifFacturaEmisor,
                    RegistroInfo.IDIdFactura,
                    RegistroInfo.NumSerieFacturaEmisor,
                    dataUser.IdAgencia,
                    connection, dataUser);

                string IDTypeContraparte = GetIdType(dataUser.IdAgencia, connection, dataUser).Exists(i => i.Id == RegistroInfo.IDTypeContraparte) ?
                    RegistroInfo.IDTypeContraparte : null;
                string IDTypeIdFactura = GetIdType(dataUser.IdAgencia, connection, dataUser).Exists(t => t.Id == RegistroInfo.IDTypeIdFactura) ?
                    RegistroInfo.IDTypeIdFactura : null;
                string TipoFactura = GetTipoFactura(dataUser.IdAgencia, connection, dataUser).Exists(i => i.Id == RegistroInfo.TipoFactura) ?
                    RegistroInfo.TipoFactura : null;
                string ClaveRegimenEspecialOTrascendencia = GetClaveRegimenBy(RegistroInfo.IdLibroRegistro, dataUser.IdAgencia, connection, dataUser)
                    .Exists(c => c.Id == RegistroInfo.ClaveRegimenEspecialOTrascendencia) ?
                    RegistroInfo.ClaveRegimenEspecialOTrascendencia : null;
                string Periodo = GetPeriodosByTipoPresentacion("M", connection, dataUser).Exists(p => p.Id == RegistroInfo.Periodo) ?
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
                _logsManager.LogDebug($"SiiRepository.InsertUpdateRegistroInformacion() insertedid => '{oReturn}'", UserId: dataUser.IdUsuario);

                int regId = (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                    && eRegistroInformacion != null
                    && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado))
                        ? RegistroInfo.Id : oReturn;

                if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                        && eRegistroInformacion != null
                        && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                    || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                {
                    DeleteDetalleImportesIva(regId, connection, dataUser);
                }
                if (RegistroInfo.ListDetailIva != null)
                {
                    foreach (EDetalleImportesIVA detailIva in RegistroInfo.ListDetailIva)
                    {
                        detailIva.IdRegistro = regId;
                        InsertUpdateDetalleImportesIVA(detailIva, connection, dataUser);
                    }
                }

                if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                        && eRegistroInformacion != null
                        && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                    || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                {
                    DeleteFacturasAgrupadas(regId, connection, dataUser);
                }
                if (RegistroInfo.ListFacturasAgrupadas != null)
                {
                    foreach (EFacturasAgrupadas fAgrupada in RegistroInfo.ListFacturasAgrupadas)
                    {
                        fAgrupada.IdRegistroInformacion = regId;
                        InsesrtUpdateFacturasAgrupadas(fAgrupada, connection, dataUser);
                    }
                }

                if (((pIdTipoOperacion == "A0" || pIdTipoOperacion == "A5")
                        && eRegistroInformacion != null
                        && eRegistroInformacion.IdEstadoRegistro == EnumEstadoRegistro.Rechazado)
                    || (pIdTipoOperacion != "A0" && pIdTipoOperacion != "A5"))
                {
                    DeleteFacturasRectificadas(regId, connection, dataUser);
                }
                if (RegistroInfo.ListFacturasRectificadas != null)
                {
                    foreach (EFacturasRectificadas fRectificada in RegistroInfo.ListFacturasRectificadas)
                    {
                        fRectificada.IdRegistroInformacion = regId;
                        InsesrtUpdateFacturasRectificadas(fRectificada, connection, dataUser);
                    }
                }

                if (RegistroInfo.DatosComplementarios != null)
                {
                    RegistroInfo.DatosComplementarios.IdRegistroInformacion = regId;
                    RegistroInfo.DatosComplementarios.Macrodato = Math.Abs(RegistroInfo.ImporteTotal != null ? ((decimal)RegistroInfo.ImporteTotal) : 0) >= 100000000 ? "S" : "N";
                    if (RegistroInfo.DatosComplementarios.IdRegistroInformacion != 0)
                    {
                        InsertUpdateDatosComplementarios(RegistroInfo.DatosComplementarios, connection, dataUser);
                    }
                }
                if (RegistroInfo.IdEstadoCuadre == EnumEstadoCuadre.ParcialmenteContrastada)
                {
                    RegistroInfo.Id = oReturn;
                    InsertUpdateDatosDescuadreCotraparte(RegistroInfo.Id, connection, dataUser);
                }
                if (dataUser.IdAgencia == "ATC" && RegistroInfo.RegistroInformacion_IGIC != null)
                {
                    RegistroInfo.RegistroInformacion_IGIC.IdRegistroInformacion = regId;
                    if (RegistroInfo.RegistroInformacion_IGIC.IdRegistroInformacion != 0)
                    {
                        int returnId = InsertUpdateRegistroInformacion_IGIC(RegistroInfo.RegistroInformacion_IGIC, connection, dataUser);
                        if (returnId == 0)
                        {

                            _logsManager.LogError("Se ha producido un error al insertar Registro Informacion IGIC de la factura: " + RegistroInfo.NumSerieFacturaEmisor, UserId: dataUser.IdUsuario);
                            Console.WriteLine("Se ha producido un error al insertar Registro Informacion IGIC de la factura: " + RegistroInfo.NumSerieFacturaEmisor);

                            result = new TResult<int>(RegistroInfo.Id)
                            {
                                Message = "Se ha producido un error al insertar el registro IGIC",
                                Status = StatusResponse.KO
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
                        DeleteDetalleInmuebleByRegistro(regId, connection, dataUser);
                    }
                    foreach (var item in RegistroInfo.DetalleInmuebles)
                    {

                        item.IdRegistroInformacion = regId;
                        if (regId != 0)
                        {
                            InsertDetalleInmueble(item, connection, dataUser);
                        }
                    }
                }

                result = new TResult<int>(RegistroInfo.Id)
                {
                    Message = "Tus cambios se han guardado con éxito.",
                    Status = StatusResponse.OK,
                    Result = regId
                };

            }
            catch (Exception ex)
            {

                _logsManager.LogError(ex.Message, ex, UserId: dataUser.IdUsuario);
                //Console.WriteLine("Error in insertion of registro información, Numero Serie Factura Emisor : " + RegistroInfo.NumSerieFacturaEmisor);
                Console.WriteLine("Se ha producido un error al procesar la factura: " + RegistroInfo.NumSerieFacturaEmisor);
                result = new TResult<int>(RegistroInfo.Id)
                {
                    Message = $"Se ha producido un error al procesar la factura: {RegistroInfo.NumSerieFacturaEmisor}",
                    Status = StatusResponse.KO
                };
                //throw ex;
            }
            return result;
        }

    }
}
